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
                rMsg.Content = new StringContent(
                    testHandler.ParseRequestBody(
                        requestInfo.body, contextPars)
                    );
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
    }
    public struct TestTask
    {
        public string name;
        public RequestInfo requestInfo;
        public List<AssertInfo> assertInfos;
        public ITestHandler testHandler;
    }

    public struct RequestInfo
    {
        public string url;
        public string method;
        public Object? headers;
        public Object? body;
    }
    public struct AssertInfo
    {
        public string assertType;
        public object expected;
        public object readData;
    }
}
