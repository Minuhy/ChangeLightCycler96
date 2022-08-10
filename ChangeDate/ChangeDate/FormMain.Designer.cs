
namespace ChangeDate
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.tcTimePick = new System.Windows.Forms.TabControl();
            this.tpSpecify = new System.Windows.Forms.TabPage();
            this.lbTimeTip = new System.Windows.Forms.Label();
            this.dtpChooseTime = new System.Windows.Forms.DateTimePicker();
            this.tpOffset = new System.Windows.Forms.TabPage();
            this.lbDateTimeOffsetTips = new System.Windows.Forms.Label();
            this.lbDay = new System.Windows.Forms.Label();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbFilesNewDir = new System.Windows.Forms.TextBox();
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.lbCancelMD5 = new System.Windows.Forms.Label();
            this.panFunction = new System.Windows.Forms.Panel();
            this.lbAbout = new System.Windows.Forms.Label();
            this.gbFiles.SuspendLayout();
            this.tcTimePick.SuspendLayout();
            this.tpSpecify.SuspendLayout();
            this.tpOffset.SuspendLayout();
            this.gbLocal.SuspendLayout();
            this.panFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbFiles.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(12, 81);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(6);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(382, 312);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbFiles_DragDrop);
            this.lbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbFiles_DragEnter);
            this.lbFiles.DoubleClick += new System.EventHandler(this.LbFiles_DoubleClick);
            // 
            // gbFiles
            // 
            this.gbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiles.Controls.Add(this.btnAddFiles);
            this.gbFiles.Controls.Add(this.btnClearList);
            this.gbFiles.Controls.Add(this.lbFiles);
            this.gbFiles.Location = new System.Drawing.Point(13, 13);
            this.gbFiles.Margin = new System.Windows.Forms.Padding(6);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Padding = new System.Windows.Forms.Padding(6);
            this.gbFiles.Size = new System.Drawing.Size(406, 410);
            this.gbFiles.TabIndex = 1;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "拖入文件（双击移除）";
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(9, 34);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(120, 38);
            this.btnAddFiles.TabIndex = 2;
            this.btnAddFiles.Text = "添加文件";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.BtnAddFiles_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(277, 34);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(120, 38);
            this.btnClearList.TabIndex = 1;
            this.btnClearList.Text = "移除所有";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // tcTimePick
            // 
            this.tcTimePick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTimePick.Controls.Add(this.tpSpecify);
            this.tcTimePick.Controls.Add(this.tpOffset);
            this.tcTimePick.Location = new System.Drawing.Point(2, 2);
            this.tcTimePick.Margin = new System.Windows.Forms.Padding(2);
            this.tcTimePick.Name = "tcTimePick";
            this.tcTimePick.SelectedIndex = 0;
            this.tcTimePick.Size = new System.Drawing.Size(362, 105);
            this.tcTimePick.TabIndex = 3;
            // 
            // tpSpecify
            // 
            this.tpSpecify.Controls.Add(this.lbTimeTip);
            this.tpSpecify.Controls.Add(this.dtpChooseTime);
            this.tpSpecify.Location = new System.Drawing.Point(4, 31);
            this.tpSpecify.Margin = new System.Windows.Forms.Padding(2);
            this.tpSpecify.Name = "tpSpecify";
            this.tpSpecify.Padding = new System.Windows.Forms.Padding(2);
            this.tpSpecify.Size = new System.Drawing.Size(354, 70);
            this.tpSpecify.TabIndex = 0;
            this.tpSpecify.Text = "指定时间";
            this.tpSpecify.UseVisualStyleBackColor = true;
            // 
            // lbTimeTip
            // 
            this.lbTimeTip.AutoSize = true;
            this.lbTimeTip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimeTip.Location = new System.Drawing.Point(5, 42);
            this.lbTimeTip.Name = "lbTimeTip";
            this.lbTimeTip.Size = new System.Drawing.Size(341, 12);
            this.lbTimeTip.TabIndex = 3;
            this.lbTimeTip.Text = "指定文件中的最早时间，为保证文件完整性，其他时间依次后移";
            // 
            // dtpChooseTime
            // 
            this.dtpChooseTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpChooseTime.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.dtpChooseTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChooseTime.Location = new System.Drawing.Point(5, 8);
            this.dtpChooseTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtpChooseTime.Name = "dtpChooseTime";
            this.dtpChooseTime.Size = new System.Drawing.Size(339, 32);
            this.dtpChooseTime.TabIndex = 0;
            // 
            // tpOffset
            // 
            this.tpOffset.Controls.Add(this.lbDateTimeOffsetTips);
            this.tpOffset.Controls.Add(this.lbDay);
            this.tpOffset.Controls.Add(this.tbOffset);
            this.tpOffset.Location = new System.Drawing.Point(4, 31);
            this.tpOffset.Margin = new System.Windows.Forms.Padding(2);
            this.tpOffset.Name = "tpOffset";
            this.tpOffset.Padding = new System.Windows.Forms.Padding(2);
            this.tpOffset.Size = new System.Drawing.Size(354, 70);
            this.tpOffset.TabIndex = 1;
            this.tpOffset.Text = "偏移时间";
            this.tpOffset.UseVisualStyleBackColor = true;
            // 
            // lbDateTimeOffsetTips
            // 
            this.lbDateTimeOffsetTips.AutoSize = true;
            this.lbDateTimeOffsetTips.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateTimeOffsetTips.Location = new System.Drawing.Point(5, 42);
            this.lbDateTimeOffsetTips.Name = "lbDateTimeOffsetTips";
            this.lbDateTimeOffsetTips.Size = new System.Drawing.Size(323, 12);
            this.lbDateTimeOffsetTips.TabIndex = 2;
            this.lbDateTimeOffsetTips.Text = "正数为向后偏移，负数为向前偏移，支持浮点（0.5为半天）";
            // 
            // lbDay
            // 
            this.lbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDay.AutoSize = true;
            this.lbDay.Location = new System.Drawing.Point(317, 11);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(32, 22);
            this.lbDay.TabIndex = 1;
            this.lbDay.Text = "天";
            // 
            // tbOffset
            // 
            this.tbOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOffset.Location = new System.Drawing.Point(5, 8);
            this.tbOffset.Margin = new System.Windows.Forms.Padding(2);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(307, 32);
            this.tbOffset.TabIndex = 0;
            this.tbOffset.Text = "0";
            this.tbOffset.WordWrap = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(13, 334);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(342, 43);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "修改";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // tbFilesNewDir
            // 
            this.tbFilesNewDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilesNewDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilesNewDir.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFilesNewDir.Location = new System.Drawing.Point(4, 29);
            this.tbFilesNewDir.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilesNewDir.Multiline = true;
            this.tbFilesNewDir.Name = "tbFilesNewDir";
            this.tbFilesNewDir.Size = new System.Drawing.Size(352, 97);
            this.tbFilesNewDir.TabIndex = 5;
            // 
            // gbLocal
            // 
            this.gbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocal.Controls.Add(this.btnChooseDir);
            this.gbLocal.Controls.Add(this.tbFilesNewDir);
            this.gbLocal.Location = new System.Drawing.Point(2, 111);
            this.gbLocal.Margin = new System.Windows.Forms.Padding(2);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Padding = new System.Windows.Forms.Padding(2);
            this.gbLocal.Size = new System.Drawing.Size(360, 176);
            this.gbLocal.TabIndex = 6;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "保存位置";
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDir.Location = new System.Drawing.Point(182, 130);
            this.btnChooseDir.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(174, 42);
            this.btnChooseDir.TabIndex = 6;
            this.btnChooseDir.Text = "选择保存位置";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.BtnChooseDir_Click);
            // 
            // lbCancelMD5
            // 
            this.lbCancelMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCancelMD5.AutoSize = true;
            this.lbCancelMD5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCancelMD5.ForeColor = System.Drawing.Color.Blue;
            this.lbCancelMD5.Location = new System.Drawing.Point(3, 388);
            this.lbCancelMD5.Name = "lbCancelMD5";
            this.lbCancelMD5.Size = new System.Drawing.Size(98, 22);
            this.lbCancelMD5.TabIndex = 7;
            this.lbCancelMD5.Text = "取消校验";
            this.lbCancelMD5.Click += new System.EventHandler(this.LbCancelMD5_Click);
            // 
            // panFunction
            // 
            this.panFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panFunction.Controls.Add(this.lbAbout);
            this.panFunction.Controls.Add(this.tcTimePick);
            this.panFunction.Controls.Add(this.lbCancelMD5);
            this.panFunction.Controls.Add(this.gbLocal);
            this.panFunction.Controls.Add(this.btnStart);
            this.panFunction.Location = new System.Drawing.Point(428, 12);
            this.panFunction.Name = "panFunction";
            this.panFunction.Size = new System.Drawing.Size(369, 411);
            this.panFunction.TabIndex = 8;
            // 
            // lbAbout
            // 
            this.lbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAbout.AutoSize = true;
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAbout.Location = new System.Drawing.Point(235, 388);
            this.lbAbout.Name = "lbAbout";
            this.lbAbout.Size = new System.Drawing.Size(131, 22);
            this.lbAbout.TabIndex = 8;
            this.lbAbout.Text = "2022-8-9 v1";
            this.lbAbout.Click += new System.EventHandler(this.LbAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 432);
            this.Controls.Add(this.panFunction);
            this.Controls.Add(this.gbFiles);
            this.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(823, 471);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LightCycler文件时间修改";
            this.gbFiles.ResumeLayout(false);
            this.tcTimePick.ResumeLayout(false);
            this.tpSpecify.ResumeLayout(false);
            this.tpSpecify.PerformLayout();
            this.tpOffset.ResumeLayout(false);
            this.tpOffset.PerformLayout();
            this.gbLocal.ResumeLayout(false);
            this.gbLocal.PerformLayout();
            this.panFunction.ResumeLayout(false);
            this.panFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.TabControl tcTimePick;
        private System.Windows.Forms.TabPage tpSpecify;
        private System.Windows.Forms.TabPage tpOffset;
        private System.Windows.Forms.DateTimePicker dtpChooseTime;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbFilesNewDir;
        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.Label lbCancelMD5;
        private System.Windows.Forms.Panel panFunction;
        private System.Windows.Forms.Label lbAbout;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Label lbDateTimeOffsetTips;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Label lbTimeTip;
    }
}

