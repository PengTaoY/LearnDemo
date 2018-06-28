using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this.form_MouseWheel);
        }

        public static string tb = string.Empty;

        private void form_MouseWheel(object sender, MouseEventArgs e)
        {
            //添加滚轮事件，来改变透明度
            if (e.Delta > 0)
            {
                if (this.Opacity - 0.05 >= 0)
                {
                    this.Opacity -= 0.05;
                }
            }
            else
            {
                if (this.Opacity + 0.05 <= 1)
                {
                    this.Opacity += 0.05;
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string Uri = textBox1.Text;
        //    if (!string.IsNullOrEmpty(Uri) && button1.Text == "转到")
        //    {
        //        if (!Uri.Contains("http"))
        //        {
        //            Uri = "http://" + Uri;
        //        }

        //        webBrowser1.Url = new Uri(Uri);

        //        this.button1.Text = "测试";
        //        this.textBox1.Visible = false;
        //        return;
        //    }

        //    if (button1.Text == "测试")
        //    {
        //        webBrowser1.Url = new Uri("http://www.ething.net");
        //        button1.Text = "转到";
        //        this.textBox1.Visible = true;
        //        return;
        //    }
        //}

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Url = textBox1.Text;
                if (!string.IsNullOrEmpty(Url))
                {
                    if (!Url.Contains("http"))
                    {
                        Url = "http://" + Url;
                    }
                    Url = Url.Replace(" ", "");
                    webBrowser1.Url = new Uri(Url);
                    this.textBox1.Visible = false;
                    return;
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }
    }
}
