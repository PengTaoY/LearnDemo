using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.IO;

namespace WebCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = this.textBox1.Text.Trim();
            string htmlCode = GetHTML(url);

            Regex reg = new Regex("[a-zA-Z0-9_-]+@\\w+\\.[a-z]+(\\.[a-z]+)?");

            string filePath = Directory.GetCurrentDirectory() + "\\b.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            MatchCollection ms = reg.Matches(htmlCode);
            if (ms != null && ms.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(filePath,true))
                {
                    foreach (Match m in ms)
                    {
                        string o = m.Groups[0].Value;

                        sw.WriteLine(o);
                    }
                    MessageBox.Show("抓取完成");
                }

            }

           

        }

        private string GetHTML(string url)
        {
            WebClient web = new WebClient();
            byte[] buffer = web.DownloadData(url);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
