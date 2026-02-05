using System.Net;

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
        private void button1_Click(object sender, EventArgs e)
        {
            var hcontent = new StringContent(
                textBox3.Text,
                System.Text.Encoding.UTF8,
                "application/json"
                );
            var rMsg = tools.makeHttpRequestMessage(
                textBox2.Text,
                methodMap[comboBox1.Text],
                headers,
                hcontent
                );

            sharedClient.SendAsync(rMsg)
                .ContinueWith((requestTask) =>
            {
                var response = requestTask.Result;
                response.Content.ReadAsStringAsync().ContinueWith((readTask) =>
                {
                    var content = readTask.Result;
                    this.Invoke(() =>
                    {
                        textBox1.Text = content;
                    });
                });
                string headerOutput = "";
                foreach (var header in response.Headers)
                {
                    string value = string.Join(", ", header.Value);
                    headerOutput += $"{header.Key}: {value}{Environment.NewLine}";
                }
                this.Invoke(() =>
                {
                    textBox4.Text = headerOutput;
                    label3.Text = $"Status Code: {(int)response.StatusCode} {response.ReasonPhrase}";
                });
            });
        }

        Dictionary<string, string> headers =
            new Dictionary<string, string>();
        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FAB = new FrmAuthBasic();
            if (FAB.ShowDialog() == DialogResult.OK)
            {
                var hString = "Basic " +
                    tools.Base64Encode($"{FAB.Username}:{FAB.Password}");
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
    }
}
