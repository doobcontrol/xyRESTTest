using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xyRESTTestLib.Properties;

namespace xyRESTTestLib
{
    public class xyTest
    {
        private static readonly HttpClient sharedClient = new HttpClient();
        public static void setBaseAddress(string rootUrl)
        {
            sharedClient.BaseAddress = new Uri(rootUrl);
        }
        public static string getBaseAddress()
        {
            return sharedClient.BaseAddress.AbsoluteUri;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        static Dictionary<string, HttpMethod> methodMap =
            new Dictionary<string, HttpMethod>()
        {
            {nameof(ReqMethod.GET), HttpMethod.Get },
            {nameof(ReqMethod.POST), HttpMethod.Post },
            {nameof(ReqMethod.PUT), HttpMethod.Put },
            {nameof(ReqMethod.DELETE), HttpMethod.Delete },
        };


        public static ITestHandler TestHandler;
        public static HttpRequestMessage makeHttpRequestMessage(
            TestTask testTask,
            Dictionary<string, string> contextPars
            )
        {
            var requestInfo = testTask.requestInfo;
            var testHandler = TestHandler;
            var rMsg = new HttpRequestMessage(
                methodMap[requestInfo.method], requestInfo.url);

            if (requestInfo.headers != null)
            {
                var headers = testHandler.ParseHeaders(
                    requestInfo.headers, contextPars);
                foreach (var header in headers)
                {
                    rMsg.Headers.Add(header.Key, header.Value);
                }
            }
            if (requestInfo.body != null
                && (requestInfo.method == "POST"
                || requestInfo.method == "PUT"))
            {
                HttpContent? content = testHandler.ParseRequestBody(
                        requestInfo.body, contextPars);
                if (content != null)
                {
                    rMsg.Content = content;
                }
            }

            return rMsg;
        }

        public static async Task<(bool result, ResponseInfo responseInfo)> oneTestAsync(
            TestTask testTask,
            Dictionary<string, string> contextPars,
            StreamWriter rw
            )
        {
            DateTime startTime = DateTime.Now;
            rw.WriteLine(
                string.Format(Resources.strTestStartTime, startTime)
                );
            // Prepare request
            var rMsg = makeHttpRequestMessage(testTask, contextPars);
            HttpResponseMessage response;
            try
            {
                response = await sharedClient.SendAsync(rMsg);
            }
            catch (Exception e)
            {
                rw.WriteLine(
                    string.Format(Resources.strErrorWhenSendingRequest_, e.Message)
                    );
                rw.WriteLine(
                    string.Format(
                        Resources.strTestTime,
                        (DateTime.Now - startTime).TotalSeconds)
                    );
                return (false, null);
            }

            ResponseInfo responseInfo = await GetResponseInfoAsync(response);

            // Assert response (And get data to contextPars)
            bool assert = true;
            foreach (var assertInfo in testTask.assertInfos)
            {
                rw.WriteLine(string.Format(Resources.strAssertType, assertInfo.assertType));
                var assertResult = await TestHandler.AssertResponse(
                    responseInfo, assertInfo, contextPars, rw);
                if (!assertResult)
                {
                    assert = false;
                }
            }

            // Human Intervention
            if(testTask.HumanInterventions != null 
                && testTask.HumanInterventions.Count > 0
                && humanIntervention != null) {
                foreach(var hi in testTask.HumanInterventions)
                {
                    humanIntervention(
                        (HumanInterventionType)Enum.Parse(typeof(HumanInterventionType), hi), 
                        contextPars);
                }
            }

            rw.WriteLine(
                string.Format(
                    Resources.strTestTime,
                    (DateTime.Now - startTime).TotalSeconds)
                );
            return (assert, responseInfo);
        }
        public static async Task<(bool result,
            List<ResponseInfo> responseInfo)> oneAutoGenerateTestAsync(
            TestTask testTask,
            Dictionary<string, string> contextPars,
            StreamWriter rw
            )
        {
            var testDataList = TestHandler.GenerateTestDatas(testTask.dataGenerator);
            (bool result, ResponseInfo? responseInfo) testResult;
            var responseInfos = new List<ResponseInfo>();
            foreach (var testData in testDataList)
            {
                var newTask = TestHandler.ApplyLocalPars(testTask, testData);
                rw.WriteLine(
                    string.Format(
                        Resources.strTestData,
                        string.Join(", ", testData))
                    );
                testResult = await oneTestAsync(newTask, contextPars, rw);
                responseInfos.Add(testResult.responseInfo);
                if (!testResult.result)
                {
                    rw.WriteLine(Resources.strFailed);
                    rw.WriteLine();
                    return (false, responseInfos);
                }
                rw.WriteLine(Resources.strSucceed);
            }
            return (true, responseInfos);
        }
        public static async Task<(bool result,
            List<ResponseInfo> responseInfo)> oneTaskAsync(
            TestTask task, StreamWriter sw, Dictionary<string, string> contextPars
            )
        {
            sw.WriteLine(string.Format(Resources.strTestCaseName, task.name));
            sw.WriteLine(string.Format(Resources.strTargetApi, task.requestInfo.url));
            sw.WriteLine(string.Format(Resources.strRequestMethod, task.requestInfo.method));

            (bool result, List<ResponseInfo> responseInfo) testResult;
            if (task.dataGenerator == null)
            {
                var oneResult = await oneTestAsync(task, contextPars, sw);
                if (!oneResult.result)
                {
                    sw.WriteLine(Resources.strFailed);
                    sw.WriteLine();
                    return (false, new List<ResponseInfo> { oneResult.responseInfo });
                }
                testResult = (true, new List<ResponseInfo> { oneResult.responseInfo });
            }
            else
            {
                testResult = await oneAutoGenerateTestAsync(task, contextPars, sw);
                if (!testResult.result)
                {
                    return (false, testResult.responseInfo);
                }
            }
            sw.WriteLine(Resources.strSucceed);
            sw.WriteLine();
            return testResult;
        }
        public static async Task<bool> batchTestAsync(
            List<TestTask> tasks, StreamWriter sw, Dictionary<string, string> contextPars
            )
        {
            foreach (var task in tasks)
            {
                (bool result, List<ResponseInfo> responseInfo) taskSucced = 
                    await oneTaskAsync(task, sw, contextPars);
                if (!taskSucced.result)
                {
                    return false;
                }
            }
            return true;
        }
        public static async Task<bool> runProjectAsync(
            TestProject testProject, 
            Dictionary<string, string> contextPars,
            string outputfile)
        {
            bool retB;
            using (StreamWriter sw = new StreamWriter(outputfile, true))
            {
                DateTime startTime = DateTime.Now;
                sw.WriteLine(string.Format(
                        Resources.strTestProjectName,
                        testProject.name));
                sw.WriteLine(string.Format(
                        Resources.strTestProjectRootUrl,
                        testProject.rootUrl));
                sw.WriteLine();

                sw.WriteLine(Resources.strStartTest);
                sw.WriteLine();

                retB = await batchTestAsync(testProject.tasks, sw, contextPars);

                if (retB)
                {
                    sw.WriteLine(Resources.strAllTestFinishedSucceed);
                }

                sw.WriteLine(
                    string.Format(
                        Resources.strTestTime,
                        (DateTime.Now - startTime).TotalSeconds)
                    );
                sw.WriteLine();
            }

            return retB;
        }

        public static void saveTestProject(TestProject testProject)
        {
            var json = JsonSerializer.Serialize(testProject);
            File.WriteAllText(
                Path.Combine(testProject.projectDir, testProject.projectFile), 
                json);
        }
        public static TestProject loadTestProject(string projectFile)
        {
            var json = File.ReadAllText(projectFile);

            var projectDataDic = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            var projectName = projectDataDic["name"].ToString() ?? "";
            var rootUrl = projectDataDic["rootUrl"].ToString() ?? "";
            var tasksString = projectDataDic["tasks"].ToString() ?? "[]";
            var tasksList = 
                JsonSerializer.Deserialize<List<TestTask>>(tasksString) ?? new List<TestTask>();

            var projectDir = Path.GetDirectoryName(projectFile);
            var projectFileName = Path.GetFileName(projectFile);

            var testProject = new TestProject(projectDir ?? "", projectFileName ?? "")
            {
                name = projectName,
                rootUrl = rootUrl,
                tasks = tasksList
            };

            foreach (var task in testProject.tasks)
            {
                if (task.requestInfo != null && task.requestInfo.headers != null)
                {
                    foreach (var header in task.requestInfo.headers)
                    {
                        if (header.Key == nameof(HeaderType.Authorization))
                        {
                            task.requestInfo.headers[header.Key] =
                                JsonSerializer.Deserialize<AuthHeaderInfo>(header.Value.ToString());
                        }
                        else if(header.Key == nameof(HeaderType.Accept))
                        {
                            task.requestInfo.headers[header.Key] = header.Value.ToString();
                        }
                    }
                }
            }

            return testProject;
        }
        public static string HandleProjectParams(
            Dictionary<string, string> parsDic, string inputStr)
        {
            string pattern = @"\$\{(?<parName>\w+)\}";
            MatchCollection matches = Regex.Matches(inputStr, pattern);
            string returnStr = inputStr;
            foreach (Match match in matches)
            {
                returnStr = returnStr.Replace(match.Value, 
                    parsDic[match.Groups["parName"].Value]);
            }
            return returnStr;
        }
        public static bool CheckCaseContextParams(
            Dictionary<string, string> parsDic, List<string> missngParams, TestTask testTask)
        {
            var inputStr = JsonSerializer.Serialize(testTask);
            string pattern = @"\$\{(?<parName>\w+)\}";
            MatchCollection matches = Regex.Matches(inputStr, pattern);
            foreach (Match match in matches)
            {
                if (!parsDic.ContainsKey(match.Groups["parName"].Value))
                {
                    missngParams.Add(match.Groups["parName"].Value);
                    
                }
            }
            if (missngParams.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string HandleCaseParams(
            Dictionary<string, string> parsDic, string inputStr)
        {
            string pattern = @"\{\{(?<parName>\w+)\}\}";
            MatchCollection matches = Regex.Matches(inputStr, pattern);
            string returnStr = inputStr;
            foreach (Match match in matches)
            {
                returnStr = returnStr.Replace(match.Value,
                    parsDic[match.Groups["parName"].Value]);
            }
            return returnStr;
        }
        public static List<string> GetProjectParams(TestProject testProject, int index)
        {
            var parsList = new List<string>();

            foreach(var task in testProject.tasks)
            {
                if(testProject.tasks.IndexOf(task) >= index)
                {
                    break;
                }
                if (task.assertInfos != null)
                {
                    foreach (var assertInfo in task.assertInfos)
                    {
                        if (assertInfo.readList != null)
                        {
                            foreach (var readItem in assertInfo.readList)
                            {
                                if (!parsList.Contains(readItem.Key))
                                {
                                    parsList.Add(readItem.Key);
                                }
                            }
                        }
                    }
                }
                if (task.HumanInterventions != null)
                {
                    parsList.Add(captchaCode);
                    parsList.Remove(captchaImg);
                }
            }

            return parsList;
        }
        public static List<string> GetCaseParams(TestTask testTask)
        {
            var parsList = new List<string>();
            if (testTask.dataGenerator != null)
            {
                parsList.AddRange(testTask.dataGenerator.ParamList);
            }
            return parsList;
        }
        private static async Task<ResponseInfo> GetResponseInfoAsync(HttpResponseMessage response)
        {
            int statusCode = (int)response.StatusCode;
            Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>();
            foreach(var header in response.Headers)
            {
                headers.Add(header.Key, header.Value.ToList());
            }
            string? mediaType = response.Content.Headers.ContentType?.MediaType;

            string? content;
            bool contentIsBinary;
            if (mediaType != null && (mediaType.StartsWith("text/") 
                || mediaType.Contains("json") || mediaType.Contains("xml")))
            {
                // Content is likely text
                content = await response.Content.ReadAsStringAsync();
                contentIsBinary = false;
            }
            else
            {
                // Content is likely binary
                string timestamp = DateTime.Now.ToString("_yyyyMMdd_HHmmss_fffff");
                string fileName = timestamp;
                if (!Directory.Exists(Temp_file_dir))
                {
                    Directory.CreateDirectory(Temp_file_dir);
                }
                string saveFile = Path.Combine(Temp_file_dir, fileName);
                using var fs = new FileStream(
                    saveFile, FileMode.Create, FileAccess.Write);
                using var contentStream = response.Content.ReadAsStream();
                await contentStream.CopyToAsync(fs);
                content = saveFile;
                contentIsBinary = true;
            }

            return new ResponseInfo(
                statusCode,
                contentIsBinary = contentIsBinary,
                content = content,
                headers = headers,
                mediaType = mediaType
                );
        }

        // Content Type
        public const string CT_app_json = "application/json";
        public const string CT_multipart_form_data = "multipart/form-data";
        public const string CT_application_octet_stream = "application/octet-stream";
        public static List<string> ContentTypeList = new List<string>()
        {
            CT_app_json,
            CT_multipart_form_data,
            CT_application_octet_stream
        };
        public const string CT_app_pdf = "application/pdf";
        public const string CT_app_zip = "application/zip";
        public const string CT_app_gzip = "application/gzip";
        public const string CT_image_jpeg = "image/jpeg";
        public const string CT_image_png = "image/png";
        public const string CT_image_gif = "image/gif";
        public const string CT_image_webp = "image/webp";
        public const string CT_image_bmp = "image/bmp";
        public const string CT_audio_mpeg = "audio/mpeg";
        public const string CT_audio_wav = "audio/wav";
        public const string CT_video_mp4 = "video/mp4";
        public const string CT_video_webm = "video/webm";
        public static List<string> BinaryContentTypeList = new List<string>()
        {
            CT_application_octet_stream,
            CT_app_pdf,
            CT_app_zip,
            CT_app_gzip,
            CT_image_jpeg,
            CT_image_png,
            CT_image_gif,
            CT_image_webp,
            CT_image_bmp,
            CT_audio_mpeg,
            CT_audio_wav,
            CT_video_mp4,
            CT_video_webm
        };

        // Data Generator Type
        public const string DGT_Basic_File = "DataFile";

        // Sub work file Dirs
        public const string Temp_file_dir = "temp";
        public const string Report_file_dir = "reports";
        public const string Download_file_dir = "downloads";
        public const string Testdata_file_dir = "testdata";

        // Test report file name
        public const string Testreport_file_name = "report";

        // Captcha context parameters name
        public const string captchaCode = "captchaCode";
        public const string captchaImg = "captchaImg";

        public static HumanIntervention humanIntervention;
    }
    public class TestTask
    {
        public required string name { get; set; }
        public required RequestInfo requestInfo { get; set; }
        public required List<AssertInfo> assertInfos { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataGenerator? dataGenerator { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? HumanInterventions { get; set; }
    }
    public class TestProject
    {
        public required string name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? rootUrl { get; set; }
        public required List<TestTask> tasks { get; set; }

        [JsonIgnore]
        public string projectDir { get; }
        [JsonIgnore]
        public string projectFile { get; }
        public TestProject(string projectDir, string projectFile)
        {
            this.projectDir = projectDir;
            this.projectFile = projectFile;
        }
    }

    public class RequestInfo
    {
        public required string url { get; set; }
        public required string method { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object>? headers { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContentInfo? body { get; set; }
    }
    public class DataGenerator
    {
        public required List<string> ParamList { get; set; }
        public required string GeneratorType { get; set; }
        public required Dictionary<string, string> GeneratorInfo { get; set; }
    }
    public class AssertInfo
    {
        public required string assertType { get; set; } = "StatusCode";
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? expected { get; set; }

        // Assert exist and read to contextPars, for use in later test
        // The key is the variable name to store in contextPars,
        // the value is the jsonPath(or search schame) to read data from response body
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? readList { get; set; }

        // Assert value, key is the jsonPath to read data from response body,
        // value is the expected value to assert
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? assertList { get; set; }

        // If assertType is ContentType,
        // saveFilePath is the file path to save the response content(the downloaded file),
        // for later check
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? saveFilePath { get; set; }
    }
    public class ResponseInfo
    {
        public ResponseInfo(
            int statusCode,
            bool contentIsBinary = false,
            string? content = null, 
            Dictionary<string, List<string>>? headers = null,
            string? mediaType = null) {
            StatusCode = statusCode;
            ContentIsBinary = contentIsBinary;
            Content = content;
            Headers = headers;
            MediaType = mediaType;
        }
        public int StatusCode { get; }
        // When ContentIsBinary is true, the Content property contains the file path where
        // the downloaded file is saved.
        public bool ContentIsBinary { get; }
        public string? Content { get; }
        public Dictionary<string, List<string>>? Headers { get; }
        public string? MediaType { get; }
    }

    public enum JCType
    {
        SimpleJson
    }
    public enum ReqMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
    }
    public enum HeaderType
    {
        Authorization,
        Accept
    }
    public enum AuthType
    {
        Basic,
        Bearer
    }
    public enum AssertType
    {
        StatusCode,
        JsonContent,
        ContentType
    }
    public enum GeneratorType
    {
        Basic
    }
    public enum HumanInterventionType
    {
        SimpleImageCaptcha,
    }
    public delegate void HumanIntervention(
        HumanInterventionType hi, Dictionary<string, string> contextPars);
}
