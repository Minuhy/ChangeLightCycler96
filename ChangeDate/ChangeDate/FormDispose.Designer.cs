
namespace ChangeDate
{
    partial class FormDispose
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDispose));
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.btnFinsh = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.Location = new System.Drawing.Point(14, 14);
            this.pbMain.Margin = new System.Windows.Forms.Padding(5);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(456, 30);
            this.pbMain.TabIndex = 0;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(8, 49);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(164, 21);
            this.lbCount.TabIndex = 1;
            this.lbCount.Text = "当前处理：0/10";
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurrent.Location = new System.Drawing.Point(12, 83);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(77, 14);
            this.lbCurrent.TabIndex = 2;
            this.lbCurrent.Text = "正在处理：";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(405, 49);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(65, 21);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "00:00";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFinsh
            // 
            this.btnFinsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinsh.Location = new System.Drawing.Point(352, 109);
            this.btnFinsh.Name = "btnFinsh";
            this.btnFinsh.Size = new System.Drawing.Size(120, 40);
            this.btnFinsh.TabIndex = 4;
            this.btnFinsh.Text = "取消";
            this.btnFinsh.UseVisualStyleBackColor = true;
            this.btnFinsh.Click += new System.EventHandler(this.BtnFinsh_Click);
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 161);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(460, 238);
            this.lbLog.TabIndex = 5;
            // 
            // FormDispose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnFinsh);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbCurrent);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.pbMain);
            this.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FormDispose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "处理文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnFinsh;
        private System.Windows.Forms.ListBox lbLog;
    }
}