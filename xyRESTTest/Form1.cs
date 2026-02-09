using System;
using System.Net;
using xyRESTTestLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace xyRESTTest
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient sharedClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            AssertInfo assertInfoStatusOK = new AssertInfo()
            {
                assertType = "StatusCode",
                expected = HttpStatusCode.OK
            };
            AssertInfo assertInfoStatusUnauthorized = new AssertInfo()
            {
                assertType = "StatusCode",
                expected = HttpStatusCode.Unauthorized
            };
            AssertInfo assertInfoStatusInternalServerError = new AssertInfo()
            {
                assertType = "StatusCode",
                expected = HttpStatusCode.InternalServerError
            };

            var HeaderAuthBearer = new AuthHeaderInfo()
            {
                scheme = "Bearer",
                authToken = "${AuthToken}"
            };
            var HeaderAuthBasic = new AuthHeaderInfo()
            {
                scheme = "Basic",
                username = "admin",
                password = "admin"
            };

            var testHandler = new TestHandler();

            var testTaskList = new List<TestTask>();

            RequestInfo requestInfo = new RequestInfo()
            {
                url = "http://192.168.168.130:8080/auth/login",
                method = "GET",
                headers = new Dictionary<string, object>()
                {
                    { "Authorization", HeaderAuthBasic }
                }
            };
            TestTask testTask = new TestTask()
            {
                name = "Login Test",
                requestInfo = requestInfo,
                assertInfos = new List<AssertInfo>() { assertInfoStatusOK,
                    new AssertInfo()
                    {
                        assertType = "BodyContains",
                        expected = "token",
                        readData = new Dictionary<string, object>()
                        {
                            {
                                "AuthToken",
                                "data.token"
                            }
                        }
                    },
                },
                testHandler = testHandler
            };
            testTaskList.Add(testTask);

            var testTask_LoginFial = testTask;
            HeaderAuthBasic = new AuthHeaderInfo()
            {
                scheme = "Basic",
                username = "admin",
                password = "wrongpassword"
            };
            testTask_LoginFial.requestInfo.headers = new Dictionary<string, object>()
            {
                { "Authorization", HeaderAuthBasic }
            };
            testTask_LoginFial.name = "Login Fail Test";
            testTask_LoginFial.assertInfos = 
                new List<AssertInfo>() { assertInfoStatusUnauthorized };
            testTaskList.Add(testTask_LoginFial);

            object bodyPars = new List<string>() { "000", "John", "12456" };
            requestInfo = new RequestInfo()
            {
                url = "http://192.168.168.130:8080/user",
                method = "POST",
                headers = new Dictionary<string, object>()
                {
                    { "Authorization", HeaderAuthBearer }
                },
                body = ("jsonOneUser", bodyPars)
            };
            testTask = new TestTask()
            {
                name = "Add User Test",
                requestInfo = requestInfo,
                assertInfos = new List<AssertInfo>() { assertInfoStatusOK },
                testHandler = testHandler
            };
            testTaskList.Add(testTask);

            var testTask_AddFial = testTask;
            testTask_AddFial.name = "Add User Fail Test";
            testTask_AddFial.assertInfos =
                new List<AssertInfo>() { assertInfoStatusInternalServerError };
            testTaskList.Add(testTask_AddFial);

            for (int i = 0; i < 50; i++)
            {
                var newTestTask = testTask;
                bodyPars = new List<string>()
                {
                        (i+1).ToString("D5"),
                        "user" + GenerateRandomString(5),
                        GenerateRandomString(10)
                };
                newTestTask.requestInfo.body = ("jsonOneUser", bodyPars);
                newTestTask.name = "Add User Test " + 
                    ((List<string>)bodyPars)[0];
                testTaskList.Add(newTestTask);
            }

            // Update user test
            bodyPars = new List<string>() { "000", "John2222", "12456" };
            requestInfo = new RequestInfo()
            {
                url = "http://192.168.168.130:8080/user/000",
                method = "PUT",
                headers = new Dictionary<string, object>()
                {
                    { "Authorization", HeaderAuthBearer }
                },
                body = ("jsonOneUser", bodyPars)
            };
            testTask = new TestTask()
            {
                name = "Update user test",
                requestInfo = requestInfo,
                assertInfos = new List<AssertInfo>() { assertInfoStatusOK },
                testHandler = testHandler
            };
            testTaskList.Add(testTask);

            // Delete user test
            requestInfo = new RequestInfo()
            {
                url = "http://192.168.168.130:8080/user/000",
                method = "DELETE",
                headers = new Dictionary<string, object>()
                {
                    { "Authorization", HeaderAuthBearer }
                }
            };
            testTask = new TestTask()
            {
                name = "Delete user test",
                requestInfo = requestInfo,
                assertInfos = new List<AssertInfo>() { assertInfoStatusOK },
                testHandler = testHandler
            };
            testTaskList.Add(testTask);

            for (int i = 0; i < 50; i++)
            {
                var newTestTask = testTask;
                string userid = (i + 1).ToString("D5");
                newTestTask.requestInfo.url =
                    "http://192.168.168.130:8080/user/" + userid;
                newTestTask.name = "Delete User Test " + userid;
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
