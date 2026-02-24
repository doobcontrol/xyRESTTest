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

        public static async Task<bool> batchTestAsync(
            List<TestTask> tasks, StreamWriter sw
            )
        {
            DateTime startTime = DateTime.Now;
            sw.WriteLine(Resources.strStartTest);
            sw.WriteLine();
            var contextPars = new Dictionary<string, string>();
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
                    var testDataList = TestHandler.GenerateTestDatas(task.dataGenerator);
                    foreach (var testData in testDataList)
                    {
                        var newTask = TestHandler.ApplyLocalPars(task, testData);
                        sw.WriteLine(
                            string.Format(
                                Resources.strTestData,
                                string.Join(", ", testData))
                            );
                        if (!await oneTestAsync(newTask, contextPars, sw))
                        {
                            sw.WriteLine(Resources.strFailed);
                            sw.WriteLine();
                            return false;
                        }
                        sw.WriteLine(Resources.strSucceed);
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
        public static async Task<bool> runProjectAsync(TestProject testProject)
        {
            var path = Path.GetDirectoryName(testProject.projectFile);
            var outputfile = Path.GetFileNameWithoutExtension(testProject.projectFile);
            outputfile = Path.Combine(
                path ?? "", $"{outputfile}_testReport.txt");

            bool retB;
            using (StreamWriter sw = new StreamWriter(outputfile, true))
            {
                retB = await batchTestAsync(testProject.tasks, sw);
            }

            return retB;
        }

        public static void saveTestProject(TestProject testProject)
        {
            var json = JsonSerializer.Serialize(testProject);
            File.WriteAllText(testProject.projectFile, json);
        }
        public static TestProject loadTestProject(string projectFile)
        {
            var json = File.ReadAllText(projectFile);
            var testProject = JsonSerializer.Deserialize<TestProject>(json);

            foreach (var task in testProject.tasks)
            {
                if (task.requestInfo != null && task.requestInfo.headers != null)
                {
                    foreach (var header in task.requestInfo.headers)
                    {
                        if (header.Key == "Authorization")
                        {
                            task.requestInfo.headers[header.Key] =
                                JsonSerializer.Deserialize<AuthHeaderInfo>(header.Value.ToString());
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
        public required string projectFile { get; set; }
        public required List<TestTask> tasks { get; set; }
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
        JsonContent
    }
    public enum GeneratorType
    {
        Basic
    }
}
