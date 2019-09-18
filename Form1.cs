using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            // open dialog form
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            DialogResult dr = openFileDialog.ShowDialog(new Form() { TopMost = true, WindowState = FormWindowState.Minimized });
            if (dr == DialogResult.OK)
            {
                //get file name
                fileName = openFileDialog.FileName;
                this.textBox1.Text = fileName;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string strCmdText = "'/C C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\installutil.exe " + fileName;
                //open command prompt and execute command
                Process.Start("CMD.exe", strCmdText);
                label1.ForeColor = Color.Green;
                label1.Text = "Service Install Suscessfully";
            }
            catch (Exception ex)
            {
                label1.ForeColor = Color.Red;
                label1.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strCmdText = "'/C C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\installutil.exe -u " + fileName;
                //open command prompt and execute command
                Process.Start("CMD.exe", strCmdText);
                label1.ForeColor = Color.Green;
                label1.Text = "Service Unistall Suscessfully";
            }catch(Exception ex)
            {
                label1.Text = ex.Message;
            }
        }
    }
}
