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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_selectFille_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_FileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            string inFile = txt_FileName.Text;
            string outFile = inFile + ".dat";
            string password = txt_pwd.Text;
            if (string.IsNullOrWhiteSpace(inFile))
            {
                MessageBox.Show("请选择要加密的文件。");
                btn_selectFille.Focus();
                return;
            }

            DESFileClass.EncryptFile(inFile, outFile, password);  //加密文件
            if (cb_IsDel.Checked)
            {
                //删除加密前的文件
                File.Delete(inFile);
            }

            txt_FileName.Text = string.Empty;
            MessageBox.Show("加密成功");

        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            string inFile = txt_FileName.Text;
            if (string.IsNullOrWhiteSpace(inFile))
            {
                MessageBox.Show("请选择要解密的文件。");
                btn_selectFille.Focus();
                return;
            }
            string outFile = inFile.Substring(0, inFile.Length - 4);
            string password = txt_pwd.Text;
            

            DESFileClass.DecryptFile(inFile, outFile, password);//解密文件
            if (cb_IsDel.Checked)
            {
                //删除解密前的文件
                File.Delete(inFile);
                txt_FileName.Text = string.Empty;
            }
            MessageBox.Show("解密成功");
        }
    }
}
