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

        public static HttpRequestMessage makeHttpRequestMessage(
            TaskRequest taskRequest
            )
        {
            var rMsg = new HttpRequestMessage();
            rMsg.RequestUri = new Uri(taskRequest.url);
            rMsg.Method = taskRequest.method;
            if (taskRequest.headers != null)
            {
                foreach (var header in taskRequest.headers)
                {
                    rMsg.Headers.Add(header.Key, header.Value);
                }
            }
            if (taskRequest.content != null
                && (taskRequest.method == HttpMethod.Post 
                || taskRequest.method == HttpMethod.Put))
            {
                rMsg.Content = taskRequest.content;
            }

            return rMsg;
        }

        public static async Task<bool> oneTestAsync(
            TestTask testTask, 
            Dictionary<string, string> contextPars,
            StreamWriter sw
            )
        {
            // Prepare request
            // Headers
            if (testTask.headerCreaters != null)
            {
                foreach (var headerCreater in testTask.headerCreaters)
                {
                    var headers = headerCreater.Key(headerCreater.Value, contextPars);
                    if (testTask.request.headers == null)
                    {
                        testTask.request.headers = new Dictionary<string, string>();
                    }
                    foreach (var kv in headers)
                    {
                        testTask.request.headers[kv.Key] = kv.Value;
                    }
                }
            }
            // Content
            if (testTask.contentCreater != null)
            {;
                testTask.request.content =
                    testTask.contentCreater(testTask.contentCreaterPars, 
                    contextPars);
            }
            var rMsg = makeHttpRequestMessage(testTask.request);
            var response = await sharedClient.SendAsync(rMsg);

            //if(testTask.contentCreaterPars != null)
            //{
            //    sw.WriteLine(string.Join(",", testTask.contentCreaterPars));
            //}
            // Assert response
            foreach (var assert in testTask.asserts)
            {
                if (!await assert(response, contextPars))
                {
                    sw.WriteLine("assert: " + assert.Method.Name);
                    sw.WriteLine("HTTP status code: " + response.StatusCode);
                    return false;
                }
            }

            // Get info for following tests
            foreach (var getData in testTask.getDatas)
            {
                var data = await getData(response, contextPars);
                foreach (var kv in data)
                {
                    contextPars[kv.Key] = kv.Value;
                }
            }

            return true;
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
                    sw.WriteLine("API: " + task.request.url);
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
    public struct TaskRequest
    {
        public string url;
        public HttpMethod method;
        public Dictionary<string, string>? headers;
        public HttpContent? content;
    }
    public struct TestTask
    {
        public string name;
        public TaskRequest request;
        public Dictionary<
            Func<List<Object>, Dictionary<string, string>, 
                Dictionary<string, string>>, List<Object>>
            headerCreaters;
        public Func<List<Object>, Dictionary<string, string>, StringContent> 
            contentCreater;
        public List<Object> contentCreaterPars;
        public List<Func<HttpResponseMessage, Dictionary<string, string>, 
            Task<bool>>> asserts;
        public List<Func<HttpResponseMessage, Dictionary<string, string>, 
            Task<Dictionary<string, string>>>> getDatas;
    }
}
