using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyRESTTest.Properties;
using xyRESTTestLib;

namespace xyRESTTest
{
    public partial class UcHeaderEdit : UserControl
    {
        string headerName = string.Empty;
        object? headerValue;

        public string HeaderName { get => headerName; }
        public object? HeaderValue { get => headerValue; }
        public event EventHandler<EventArgs>? editorSelectorCountChanged;
        public UcHeaderEdit(
            KeyValuePair<string, object>? header, ComboBox cbEs)
        {
            InitializeComponent();
            LoadStringResources();
            Leave += (s, e) => { Hide(); };

            if (header != null)
            {
                this.headerName = header.Value.Key;
                this.headerValue = header.Value.Value;

                CreateHeaderValueEdit(this.headerName);
            }
            else
            {
                PnlEditor.Controls.Clear();
                PnlEditorSelector.Controls.Add(cbEs);
                cbEs.Tag = this;
            }
        }
        public void LoadStringResources()
        {
            BtnOk.Text = Resources.strOk;
            BtnCancel.Text = Resources.strCancel;
            if(PnlEditor.Controls.Count > 0)   
            {
                var headerValueEdit = PnlEditor.Controls[0];
                if(headerValueEdit is UcAuthHeader uah)
                {
                    uah.LoadStringResources();
                }
            }
        }

        private Control headerValueEdit;
        public event EventHandler<EventArgs>? Edited;
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Here you can add code to save the header information entered by the user
            if(headerValueEdit != null)
            {
                if(headerValueEdit is TextBox tb)
                {
                    headerValue = tb.Text??"";
                }
                else if(headerValueEdit is UcAuthHeader uah)
                {
                    headerValue = uah.AuthHeader;
                }
            }
            if(headerValue != null)
            {
                Edited?.Invoke(this, new EventArgs());
            }

            Hide();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        public void setEditor()
        {
            var editorSelector = PnlEditorSelector.Controls[0] as ComboBox;
            headerName = editorSelector.Text;
            CreateHeaderValueEdit(headerName);

            editorSelector.Items.Remove(headerName);
            editorSelectorCountChanged?.Invoke(this, new EventArgs());
            PnlEditorSelector.Controls.Clear();

            if (headerValueEdit is TextBox tb)
            {
                headerValue = tb.Text ?? "";
            }
            else if (headerValueEdit is UcAuthHeader uah)
            {
                headerValue = uah.AuthHeader;
            }
            Edited?.Invoke(this, new EventArgs());
        }
        private void CreateHeaderValueEdit(string headerType)
        {
            if (headerType == nameof(HeaderType.Authorization))
            {
                if (headerValue is not AuthHeaderInfo)
                {
                    headerValue = null;
                }
                if (headerValue == null)
                {
                    headerValue = new AuthHeaderInfo();
                }

                headerValueEdit = new UcAuthHeader((AuthHeaderInfo)headerValue)
                { Dock = DockStyle.Fill };
                PnlEditor.Controls.Clear();
                PnlEditor.Controls.Add(headerValueEdit);
            }
            else if (headerType == nameof(HeaderType.Accept))
            {
                headerValueEdit = new TextBox()
                { Dock = DockStyle.Top };
                if (headerValue != null)
                {
                    if(headerValue is JsonElement s)
                    {
                        headerValueEdit.Text = s.ToString();
                    }
                }
                PnlEditor.Controls.Clear();
                PnlEditor.Controls.Add(headerValueEdit);
            }
        }

        public void clear()
        {
            PnlEditorSelector.Controls.Clear();

            headerName = string.Empty;
            headerValue = null;
            editorSelectorCountChanged = null;
            Edited = null;
        }
    }
}
