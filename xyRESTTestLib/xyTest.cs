using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            {"GET", HttpMethod.Get },
            {"POST", HttpMethod.Post },
            {"PUT", HttpMethod.Put },
            {"DELETE", HttpMethod.Delete },
            {"PATCH", HttpMethod.Patch },
            {"HEAD", HttpMethod.Head },
            {"OPTIONS", HttpMethod.Options },
            {"TRACE", HttpMethod.Trace }
        };

        public static HttpRequestMessage makeHttpRequestMessage(
            TestTask testTask,
            Dictionary<string, string> contextPars
            )
        {
            var requestInfo = testTask.requestInfo;
            var testHandler = testTask.testHandler;
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
                rw.WriteLine("Error when sending request: " + e.Message);
                return false;
            }

            // Assert response (And get data to contextPars)
            bool assert = true;
            foreach (var assertInfo in testTask.assertInfos)
            {
                rw.WriteLine("Assert: " + assertInfo.assertType);
                var assertResult = await testTask.testHandler.AssertResponse(
                    response, assertInfo, contextPars, rw);
                if (!assertResult)
                {
                    rw.WriteLine("... Failed");
                    assert = false;
                }
                else
                {
                    rw.WriteLine("... Succeed");
                }
            }

            return assert;
        }

        public static async Task<bool> batchTestAsync(
            List<TestTask> tasks, string reportFile = "testReport.txt"
            )
        {
            using (StreamWriter sw = new StreamWriter(reportFile, true))
            {
                DateTime startTime = DateTime.Now;
                sw.WriteLine("Start test...");
                sw.WriteLine();
                var contextPars = new Dictionary<string, string>();
                foreach (var task in tasks)
                {
                    sw.WriteLine("Test: " + task.name);
                    sw.WriteLine("API: " + task.requestInfo.url);
                    if (!await oneTestAsync(task, contextPars, sw))
                    {
                        sw.WriteLine("... Failed");
                        return false;
                    }
                    sw.WriteLine("... succeed");
                    sw.WriteLine();
                }
                sw.WriteLine("All test finished succeed");
                sw.WriteLine("Time used: " + (DateTime.Now - startTime).TotalSeconds + " seconds");
            }
            return true;
        }
        public static async Task<bool> runProjectAsync(TestProject testProject)
        {
            var path = Path.GetDirectoryName(testProject.projectFile);
            var outputfile = Path.GetFileNameWithoutExtension(testProject.projectFile);
            outputfile = Path.Combine(
                path ?? "", $"{outputfile}_testReport.txt");

            return await batchTestAsync(testProject.tasks, outputfile);
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

        public const string CT_app_json = "application/json";
    }
    public class TestTask
    {
        public required string name { get; set; }
        public required RequestInfo requestInfo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required List<AssertInfo> assertInfos { get; set; }
        public ITestHandler testHandler;
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
}
