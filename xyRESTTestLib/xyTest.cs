using System.Text;
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
                foreach(var header in headers)
                {
                    rMsg.Headers.Add(header.Key, header.Value);
                }
            }
            if (requestInfo.body != null
                && (requestInfo.method == "POST"
                || requestInfo.method == "PUT"))
            {
                string? contentStr = testHandler.ParseRequestBody(
                        requestInfo.body, contextPars);
                if(contentStr != null)
                {
                    Encoding encodeing = 
                        Encoding.GetEncoding(requestInfo.body.Value.encoding);
                    rMsg.Content = new StringContent(
                        contentStr, encodeing, requestInfo.body.Value.ctype);
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
            var response = await sharedClient.SendAsync(rMsg);

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

        public static void saveTestProject(TestProject testProject)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(testProject);
            File.WriteAllText(testProject.projectFile, json);
        }
        public static TestProject loadTestProject(string projectFile)
        {
            var json = File.ReadAllText(projectFile);
            var testProject = System.Text.Json.JsonSerializer.Deserialize<TestProject>(json);

            return testProject;
        }
    }
    public class TestTask
    {
        public string name { get; set; }
        public RequestInfo requestInfo { get; set; }
        public List<AssertInfo> assertInfos { get; set; }
        public ITestHandler testHandler { get; set; }
    }
    public class TestProject
    {
        public string name { get; set; }
        public string projectFile { get; set; }
        public List<TestTask> tasks { get; set; }
    }

    public class RequestInfo
    {
        public string url { get; set; }
        public string method { get; set; }
        public Dictionary<string, object>? headers { get; set; }
        public ContentInfo? body { get; set; }
    }
    public class AssertInfo
    {
        public string assertType { get; set; }
        public object expected { get; set; }
        public object readData { get; set; }
    }
}
