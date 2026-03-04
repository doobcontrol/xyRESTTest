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
            var rMsg = new HttpRequestMessage();

            rMsg.RequestUri = new Uri(requestInfo.url);
            rMsg.Method = methodMap[requestInfo.method];
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

        public static async Task<bool> oneTestAsync(
            TestTask testTask,
            Dictionary<string, string> contextPars,
            StreamWriter rw
            )
        {
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
                return false;
            }

            // Assert response (And get data to contextPars)
            bool assert = true;
            foreach (var assertInfo in testTask.assertInfos)
            {
                rw.WriteLine(string.Format(Resources.strAssertType, assertInfo.assertType));
                rw.WriteLine(string.Format(Resources.strExpectedValue, assertInfo.expected));
                var assertResult = await TestHandler.AssertResponse(
                    response, assertInfo, contextPars, rw);
                if (!assertResult)
                {
                    assert = false;
                }
            }

            return assert;
        }
        public static async Task<bool> oneAutoGenerateTestAsync(
            TestTask testTask,
            Dictionary<string, string> contextPars,
            StreamWriter rw
            )
        {
            var testDataList = TestHandler.GenerateTestDatas(testTask.dataGenerator);
            foreach (var testData in testDataList)
            {
                var newTask = TestHandler.ApplyLocalPars(testTask, testData);
                rw.WriteLine(
                    string.Format(
                        Resources.strTestData,
                        string.Join(", ", testData))
                    );
                if (!await oneTestAsync(newTask, contextPars, rw))
                {
                    rw.WriteLine(Resources.strFailed);
                    rw.WriteLine();
                    return false;
                }
                rw.WriteLine(Resources.strSucceed);
            }
            return true;
        }
        public static async Task<bool> batchTestAsync(
            List<TestTask> tasks, StreamWriter sw, Dictionary<string, string> contextPars
            )
        {
            DateTime startTime = DateTime.Now;
            sw.WriteLine(Resources.strStartTest);
            sw.WriteLine();
            foreach (var task in tasks)
            {
                sw.WriteLine(string.Format(Resources.strTestCaseName, task.name));
                sw.WriteLine(string.Format(Resources.strTargetApi, task.requestInfo.url));
                sw.WriteLine(string.Format(Resources.strRequestMethod, task.requestInfo.method));

                if (task.dataGenerator == null)
                {
                    if (!await oneTestAsync(task, contextPars, sw))
                    {
                        sw.WriteLine(Resources.strFailed);
                        sw.WriteLine();
                        return false;
                    }
                }
                else
                {
                    if(!await oneAutoGenerateTestAsync(task, contextPars, sw))
                    {
                        return false;
                    }
                }
                sw.WriteLine(Resources.strSucceed);
                sw.WriteLine();
            }
            sw.WriteLine(Resources.strAllTestFinishedSucceed);
            sw.WriteLine(
                string.Format(
                    Resources.strTestTime,
                    (DateTime.Now - startTime).TotalSeconds)
                );
            sw.WriteLine();

            return true;
        }
        public static async Task<bool> runProjectAsync(
            TestProject testProject, Dictionary<string, string> contextPars)
        {
            var path = Path.GetDirectoryName(testProject.projectFile);
            var outputfile = Path.GetFileNameWithoutExtension(testProject.projectFile);
            outputfile = Path.Combine(
                path ?? "", $"{outputfile}_testReport.txt");

            bool retB;
            using (StreamWriter sw = new StreamWriter(outputfile, true))
            {
                retB = await batchTestAsync(testProject.tasks, sw, contextPars);
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
            var tasksString = projectDataDic["tasks"].ToString() ?? "[]";
            var tasksList = 
                JsonSerializer.Deserialize<List<TestTask>>(tasksString) ?? new List<TestTask>();

            var projectDir = Path.GetDirectoryName(projectFile);
            var projectFileName = Path.GetFileName(projectFile);

            var testProject = new TestProject(projectDir ?? "", projectFileName ?? "")
            {
                    name = projectName,
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
    }
    public class TestTask
    {
        public required string name { get; set; }
        public required RequestInfo requestInfo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required List<AssertInfo> assertInfos { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataGenerator? dataGenerator { get; set; }
    }
    public class TestProject
    {
        public required string name { get; set; }
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
}
