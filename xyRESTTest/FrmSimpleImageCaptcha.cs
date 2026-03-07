using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class FrmSimpleImageCaptcha : Form
    {
        Dictionary<string, string> contextPars;
        public FrmSimpleImageCaptcha(Dictionary<string, string> contextPars)
        {
            this.contextPars = contextPars;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;

            pictureBox1.Resize += (s, e) =>
            {
                if (pictureBox1.Width < pictureBox1.Parent.Width)
                {
                    pictureBox1.Left = (pictureBox1.Parent.Width - pictureBox1.Width)/2;
                }
                if (pictureBox1.Height < pictureBox1.Parent.Height)
                {
                    pictureBox1.Top = (pictureBox1.Parent.Height - pictureBox1.Height) / 2;
                }
            };

            DisplayImageFromBase64(contextPars[xyTest.captchaImg], pictureBox1);
            LoadStringResources();
        }
        private void LoadStringResources()
        {
            this.Text = Resources.strSimpleImageCaptcha;
            BtnOk.Text = Resources.strOk;
        }
        public void DisplayImageFromBase64(string base64DataUri, PictureBox pictureBox)
        {
            // Define the prefix to remove
            string prefix = "data:image/png;base64,";

            // Check if the string contains the prefix and remove it
            if (base64DataUri.StartsWith(prefix))
            {
                base64DataUri = base64DataUri.Substring(prefix.Length);
            }

            try
            {
                // Convert the base64 string to a byte array
                byte[] imageBytes = Convert.FromBase64String(base64DataUri);

                // Create a MemoryStream from the byte array
                // It's important to keep the stream open for the lifetime of the Image object
                MemoryStream ms = new MemoryStream(imageBytes);

                // Create an Image object from the stream
                Image image = Image.FromStream(ms);

                // Assign the image to the PictureBox control
                pictureBox.Image = image;

                // Note: For production code, consider managing the MemoryStream's lifetime carefully
                // to avoid GDI+ errors, possibly by creating a Bitmap object and disposing of the stream immediately.

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid base64 string format: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error creating image: " + ex.Message);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            contextPars.Remove(xyTest.captchaImg);
            contextPars[xyTest.captchaCode] = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
