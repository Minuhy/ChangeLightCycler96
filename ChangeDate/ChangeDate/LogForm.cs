using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDate
{
    public partial class LogForm : Form
    {
        public LogForm(string show)
        {
            InitializeComponent();

            string[] lines = show.Split('\n');
            tbLog.Lines = lines;

            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.ScrollToCaret();
        }

        /// <summary>
        /// 打开网址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LlbWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(sender == llbWeb)
            {
                System.Diagnostics.Process.Start("http://minuy.top/");
            }
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbVersion_Click(object sender, EventArgs e)
        {
            if (sender == lbVersion)
            {
                MessageBox.Show("版本：V1，By：http://minuy.top/");
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if(btnExit == sender)
            {
                Close();
            }
        }

        private void LbBlog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.cnblogs.com/minuy/p/16570891.html");
        }

        private void LbGit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Minuy/ChangeLightCycler96");
        }
    }
}
