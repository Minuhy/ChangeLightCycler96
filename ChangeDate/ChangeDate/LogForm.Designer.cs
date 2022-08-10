
namespace ChangeDate
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.lbVersion = new System.Windows.Forms.Label();
            this.llbWeb = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lbBlog = new System.Windows.Forms.Label();
            this.lbGit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(9, 10);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(230, 21);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "版本：V1（2022-8-9）";
            this.lbVersion.Click += new System.EventHandler(this.LbVersion_Click);
            // 
            // llbWeb
            // 
            this.llbWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llbWeb.AutoSize = true;
            this.llbWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llbWeb.Location = new System.Drawing.Point(11, 246);
            this.llbWeb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbWeb.Name = "llbWeb";
            this.llbWeb.Size = new System.Drawing.Size(241, 21);
            this.llbWeb.TabIndex = 1;
            this.llbWeb.TabStop = true;
            this.llbWeb.Text = "By：http://minuy.top/";
            this.llbWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlbWeb_LinkClicked);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(354, 241);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 31);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "确定";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLog.Location = new System.Drawing.Point(14, 33);
            this.tbLog.Margin = new System.Windows.Forms.Padding(2);
            this.tbLog.MaxLength = 235025525;
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(434, 202);
            this.tbLog.TabIndex = 0;
            this.tbLog.WordWrap = false;
            // 
            // lbBlog
            // 
            this.lbBlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBlog.AutoSize = true;
            this.lbBlog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbBlog.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbBlog.Location = new System.Drawing.Point(393, 9);
            this.lbBlog.Name = "lbBlog";
            this.lbBlog.Size = new System.Drawing.Size(54, 21);
            this.lbBlog.TabIndex = 4;
            this.lbBlog.Text = "博客";
            this.lbBlog.Click += new System.EventHandler(this.LbBlog_Click);
            // 
            // lbGit
            // 
            this.lbGit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGit.AutoSize = true;
            this.lbGit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGit.ForeColor = System.Drawing.Color.Firebrick;
            this.lbGit.Location = new System.Drawing.Point(311, 9);
            this.lbGit.Name = "lbGit";
            this.lbGit.Size = new System.Drawing.Size(76, 21);
            this.lbGit.TabIndex = 5;
            this.lbGit.Text = "GitHub";
            this.lbGit.Click += new System.EventHandler(this.LbGit_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 281);
            this.Controls.Add(this.lbGit);
            this.Controls.Add(this.lbBlog);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.llbWeb);
            this.Controls.Add(this.lbVersion);
            this.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于 和 日志";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.LinkLabel llbWeb;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label lbBlog;
        private System.Windows.Forms.Label lbGit;
    }
}