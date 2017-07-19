using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 加密解密
{
    public partial class FormFolder : Form
    {
        public string status;
        //bool flag = true;
        string[] arr;
        private string _pathkey;

        public FormFolder()
        {
            InitializeComponent();
            arr = new string[6];
            status = "";
            arr[0] = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
            arr[1] = ".{21EC2020-3AEA-1069-A2DD-08002B30309D}";
            arr[2] = ".{2559a1f4-21d7-11d4-bdaf-00c04f60b9f0}";
            arr[3] = ".{645FF040-5081-101B-9F08-00AA002F954E}";
            arr[4] = ".{2559a1f1-21d7-11d4-bdaf-00c04f60b9f0}";
            arr[5] = ".{7007ACC7-3202-11D1-AAD2-00805FC1270E}";
        }

        public string pathkey
        {
            get { return _pathkey; }
            set { _pathkey = value; }
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            if (rWLock.Checked)
                status = arr[0];
            else if (rCtrlPan.Checked)
                status = arr[1];
            else if (rWebBrow.Checked)
                status = arr[2];
            else if (rRclbin.Checked)
                status = arr[3];
            else if (rHlpSprt.Checked)
                status = arr[4];
            else if (rNetw.Checked)
                status = arr[5];



            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                string selectedpath = d.Parent.FullName + d.Name;
                if (folderBrowserDialog1.SelectedPath.LastIndexOf(".{") == -1)//通过文件夹名称，判断加密
                {
                    SetPwd(folderBrowserDialog1.SelectedPath);
                    if (!d.Root.Equals(d.Parent.FullName))
                    {
                        d.MoveTo(d.Parent.FullName + "\\" + d.Name + status);//文件夹重命名
                    }
                    else d.MoveTo(d.Parent.FullName + d.Name + status);
                    txtFolderPath.Text = folderBrowserDialog1.SelectedPath;

                }
                else//解密文件夹
                {
                    status = GetStatus(status);
                    bool s = CheckPwd();
                    if (s)
                    {
                        File.Delete(folderBrowserDialog1.SelectedPath + "\\key.xml");
                        string path = folderBrowserDialog1.SelectedPath.Substring(0, folderBrowserDialog1.SelectedPath.LastIndexOf("."));
                        d.MoveTo(path);
                        txtFolderPath.Text = path;

                    }
                }
            }

            private bool checkpassword()
            {
                XmlTextReader read;
                if (pathkey == null)
                    read = new XmlTextReader(fldrDialog.SelectedPath + "\\p.xml");
                else
                    read = new XmlTextReader(pathkey + "\\p.xml");
                if (read.ReadState == ReadState.Error)
                    return true;
                else
                {
                    try
                    {
                        while (read.Read())
                            if (read.NodeType == XmlNodeType.Text)
                            {
                                checkpassword c = new checkpassword();
                                c.pass = read.Value;
                                if (c.ShowDialog() == DialogResult.OK)
                                {
                                    read.Close();
                                    return c.status;
                                }

                            }
                    }
                    catch { return true; }

                }
                read.Close();
                return false;
            }

            private Boolean setpassword(string path)
            {
                frmPassword p = new frmPassword();
                p.path = path;
                p.ShowDialog();
                return true;
            }
            private string getstatus(string stat)
            {
                for (int i = 0; i < 6; i++)
                    if (stat.LastIndexOf(arr[i]) != -1)
                        stat = stat.Substring(stat.LastIndexOf("."));
                return stat;
            }






        }

        private void FormFolder_Load(object sender, EventArgs e)
        {
            if (this.pathkey != null)
            {

                DirectoryInfo d = new DirectoryInfo(pathkey);
                string selectedpath = d.Parent.FullName + d.Name;
                if (pathkey.LastIndexOf(".{") == -1)
                {
                    txtPath.Text = pathkey;
                    DialogResult r;
                    r = MessageBox.Show("Do You want to set password ? ",
                             "Question?", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        setpassword(pathkey);
                    }
                    status = arr[0];
                    if (!d.Root.Equals(d.Parent.FullName))
                        d.MoveTo(d.Parent.FullName + "\\" + d.Name + status);
                    else d.MoveTo(d.Parent.FullName + d.Name + status);
                    picStat.Image = Image.FromFile(Application.StartupPath + "\\lock.jpg");
                }
                else
                {
                    status = getstatus(status);
                    bool s = checkpassword();
                    if (s)
                    {
                        File.Delete(pathkey + "\\p.xml");
                        d.MoveTo(pathkey.Substring(0, pathkey.LastIndexOf(".")));
                        txtPath.Text = pathkey.Substring(0, pathkey.LastIndexOf("."));
                        picStat.Image = Image.FromFile(Application.StartupPath + "\\unlock.jpg");
                    }
                }
            }
        }
    }
}
