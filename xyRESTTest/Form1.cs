using System;
using System.Net;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient sharedClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, HttpMethod> methodMap =
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
        private async void button1_Click(object sender, EventArgs e)
        {
            var testTaskList = new List<TestTask>();

            TaskRequest taskRequest = new TaskRequest()
            {
                url = "http://192.168.168.130:8080/auth/login",
                method = HttpMethod.Get
            };
            TestTask testTask = new TestTask()
            {
                name = "Login Test",
                request = taskRequest,
                headerCreaters = new Dictionary<
                    Func<List<object>, 
                    Dictionary<string, string>, 
                    Dictionary<string, string>>, List<object>>()
                {
                    {
                        authBasicHeader,
                        new List<Object>() { "admin", "admin" }
                    }
                },
                asserts = new List<
                    Func<HttpResponseMessage, 
                    Dictionary<string, string>, Task<bool>>>()
                {
                    AssertStatusCodeOK
                },
                getDatas = new List<
                    Func<HttpResponseMessage, 
                    Dictionary<string, string>, 
                    Task<Dictionary<string, string>>>>()
                {
                    getAuthToken
                }
            };
            testTaskList.Add(testTask);

            taskRequest = new TaskRequest()
            {
                url = "http://192.168.168.130:8080/user",
                method = HttpMethod.Post
            };
            testTask = new TestTask()
            {
                name = "Add User Test",
                request = taskRequest,
                headerCreaters = new Dictionary<
                    Func<List<object>,
                    Dictionary<string, string>,
                    Dictionary<string, string>>, List<object>>()
                {
                    {
                        authBearerHeader,
                        null
                    }
                },
                contentCreater = addUserContent,
                contentCreaterPars = new List<Object>()
                { "1", "testuser", "123456" },
                asserts = new List<
                    Func<HttpResponseMessage,
                    Dictionary<string, string>, Task<bool>>>()
                {
                    AssertStatusCodeOK
                },
                getDatas = new List<
                    Func<HttpResponseMessage,
                    Dictionary<string, string>,
                    Task<Dictionary<string, string>>>>()
                {}
            };
            //testTaskList.Add(testTask);

            for(int i = 0; i < 50; i++)
            {
                var newTestTask = testTask;
                List<Object> newPars = new List<Object>()
                {
                        (i+1).ToString("D5"), 
                        "user" + GenerateRandomString(5), 
                        GenerateRandomString(10)
                };
                newTestTask.contentCreaterPars = newPars;
                testTaskList.Add(newTestTask);
            }

            await xyTest.batchTestAsync(testTaskList);
            tabControl1.SelectedIndex = 1;
        }




        Dictionary<string, string> headers =
            new Dictionary<string, string>();
        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FAB = new FrmAuthBasic();
            if (FAB.ShowDialog() == DialogResult.OK)
            {
                var hString = "Basic " +
                    xyTest.Base64Encode($"{FAB.Username}:{FAB.Password}");
                listBox1.Items.Add("Authorization: " + hString);
                headers["Authorization"] = hString;
            }
        }

        private void bearerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FAB = new FrmAuthBearer();
            if (FAB.ShowDialog() == DialogResult.OK)
            {
                var hString = "Bearer " + FAB.Token;
                listBox1.Items.Add("Authorization: " + hString);
                headers["Authorization"] = hString;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            headers.Clear();
            listBox1.Items.Clear();
        }




        private Dictionary<string, string> authBasicHeader(
            List<Object> pars,
            Dictionary<string, string> contextPars
            )
        {
            var auHeader = new Dictionary<string, string>();
            string username = pars[0].ToString() ?? "";
            string password = pars[1].ToString() ?? "";
            var authString = xyTest.Base64Encode($"{username}:{password}");
            auHeader["Authorization"] = "Basic " + authString;
            return auHeader;
        }
        private Dictionary<string, string> authBearerHeader(
            List<Object> pars, 
            Dictionary<string, string> contextPars
            )
        {
            var auHeader = new Dictionary<string, string>();
            auHeader["Authorization"] = "Bearer " + contextPars["AuthToken"];
            return auHeader;
        }
        private StringContent addUserContent(
            List<Object> pars,
            Dictionary<string, string> contextPars
            )
        {
            var userRecord =
                $"{{\"FID\":\"{pars[0]}\", \"FUserName\":\"{pars[1]}\", \"FPassword\":\"{pars[2]}\"}}";
            return new StringContent(userRecord);
        }

        private async Task<bool> AssertStatusCodeOK(
            HttpResponseMessage response, 
            Dictionary<string, string> contextPars
            )
        {
            label3.Text = $"Status Code: {(int)response.StatusCode}";
            return response.StatusCode == HttpStatusCode.OK;
        }

        private async Task<Dictionary<string, string>> getAuthToken(
            HttpResponseMessage response, 
            Dictionary<string, string> contextPars
            )
        {
            var data = new Dictionary<string, string>();
            var contentString = await response.Content.ReadAsStringAsync();
            var token = new JsonTools(contentString)
                .GetValueByPath("data.token") ?? "";
            data["AuthToken"] = token;
            textBox1.Text = token;
            textBox4.Text = response.Headers.ToString();
            return data;
        }

        private static Random random = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string GenerateRandomString(int length)
        {
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = Chars[random.Next(Chars.Length)];
            }
            return new string(result);
        }
    }
}
