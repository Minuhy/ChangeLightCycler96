using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDate
{
    public partial class FormDispose : Form
    {
        int timeCount;

        DateTime targetDateTime;
        double offsetTime;
        int mode = FormMain.TIME_PICK_MODE;

        string[] files;
        string outputDir;

        bool isFinsh;

        bool isStop;

        Thread thread;

        /// <summary>
        /// 偏移模式
        /// </summary>
        /// <param name="files"></param>
        /// <param name="offsetTime"></param>
        /// <param name="outputDir"></param>
        public FormDispose(List<string> files, double offsetTime, string outputDir) : this()
        {
            mode = FormMain.OFFSET_MODE;

            this.files = files.ToArray();
            this.offsetTime = offsetTime;
            this.outputDir = outputDir;

            Start();
        }

        /// <summary>
        /// 时间选择模式
        /// </summary>
        /// <param name="files"></param>
        /// <param name="targetDateTime"></param>
        /// <param name="outputDir"></param>
        public FormDispose(List<string> files, DateTime targetDateTime, string outputDir) : this()
        {
            mode = FormMain.TIME_PICK_MODE;

            this.files = files.ToArray();
            this.targetDateTime = targetDateTime;
            this.outputDir = outputDir;

            Start();
        }

        private void Start()
        {
            timeCount = 0;

            isFinsh = false;
            isStop = false;


            timer.Enabled = true;
            timer.Start();

            ThreadStart disposeRef = new ThreadStart(dispose);
            thread = new Thread(disposeRef);
            thread.Start();

        }

        public FormDispose()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                if (!isFinsh)
                {
                    timeCount++;
                    int min = timeCount / 60;
                    int sec = timeCount % 60;
                    lbTime.Text = string.Format("{0}:{1}", min, sec);
                }
            }
        }

        /// <summary>
        /// 处理日志
        /// </summary>
        /// <param name="value"></param>
        private void Log(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // 写日志
                    lbLog.Items.Add(value);

                    ListBox listBox = lbLog;
                    int visibleItems = listBox.ClientSize.Height / listBox.ItemHeight;
                    listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0);

                    while (listBox.Items.Count > 4096)
                    {
                        listBox.Items.RemoveAt(0);  // 删除最早的数据
                    }
                }));
            }
        }

        /// <summary>
        /// 供多线程修改当前处理文件的
        /// </summary>
        /// <param name="index"></param>
        private void CurrentFile(int value)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // 改进度
                    if (value < 0)
                    {
                        Finsh();
                    }
                    else if (value < files.Length)
                    {
                        // 设置处理进度
                        string strCount = string.Format("当前处理：{0}/{1}", value + 1, files.Length);
                        lbCount.Text = strCount;
                        // 设置当前文件
                        string strCurrentFile = string.Format("正在处理：{0}", files[value]);
                        lbCurrent.Text = strCurrentFile;
                        // 设置进度条
                        int p = (value + 1) * 100 / files.Length;
                        if (p < pbMain.Minimum)
                        {
                            p = pbMain.Minimum;
                        }
                        else if (p > pbMain.Maximum)
                        {
                            p = pbMain.Maximum;
                        }
                        pbMain.Value = p;
                    }
                }));
            }

        }

        /// <summary>
        /// 处理日志
        /// </summary>
        /// <param name="value"></param>
        private void FinshMsg(string value)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(value, "完成");
                }));
            }

        }

        /// <summary>
        /// 处理完成后调用
        /// </summary>
        private void Finsh()
        {
            isFinsh = true;
            lbCurrent.Text = "已完成";
            timer.Stop();
            btnFinsh.Text = "完成";
        }

        private string ShortPath(string path, int len)
        {
            string res = path;
            if (res.Length > len*2+4)
            {
                res = res.Substring(0, len) + "……" + res.Substring(res.Length - len, len);
            }
            return res;
        }

        private void dispose()
        {
            int count = 0;
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    Log("<<<<<<==========" + i + "==========>>>>>>");
                    if (isFinsh || isStop)
                    {
                        return;
                    }

                    CurrentFile(i);

                    string filePath = files[i];
                    // 加载文件
                    ProcessFile process = new ProcessFile(filePath);
                    Log("源文件：" + ShortPath(filePath,20) + " -> 已加载");

                    double offset;
                    // 判断要不要找最小时间
                    if (mode == FormMain.TIME_PICK_MODE)
                    {
                        DateTime[] allTime = process.ExtractAllTime();
                        DateTime minTime = allTime[0];
                        // Log("所有时间：");
                        foreach (DateTime dt in allTime)
                        {
                            // Log(dt.ToString("F"));
                            if (minTime > dt)
                            {
                                minTime = dt;
                            }
                        }

                        Log(string.Format("最小时间：{0}", minTime.ToString("F")));

                        TimeSpan timeDifference =  targetDateTime - minTime;
                        // Log(string.Format("时间间隔：{0}", timeDifference.TotalDays));
                        offset = timeDifference.TotalDays;
                    }
                    else
                    {
                        offset = offsetTime;
                    }
                    // 修改时间
                    process.AdjustmentTime(offset);
                    Log("时间偏移：" + offset + "天");

                    // 保存文件
                    string newPath = outputDir.Replace("/","\\");
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\")+1, filePath.Length - filePath.LastIndexOf("\\")-1);
                    if (newPath.EndsWith("\\"))
                    {
                        newPath += fileName;
                    }
                    else
                    {
                        newPath += "\\" + fileName;
                    }
                    
                    process.SaveFile(newPath);
                    Log(string.Format("保存文件：{0} -> 成功", ShortPath(filePath, 20)));
                    // 打扫现场
                    process.Dispose();

                    count++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Log(string.Format("失败：{0}",  ShortPath(files[i], 20)));
                    Log(string.Format("原因：{0}", e.Message));
                }
            }
            CurrentFile(-1);
            Log(string.Format("共{0}个文件，成功处理{1}个文件！", files.Length, count));
            Thread.Sleep(200);
            FinshMsg(string.Format("共{0}个文件，成功处理{1}个文件！", files.Length, count));
        }

        private void BtnFinsh_Click(object sender, EventArgs e)
        {
            if (isFinsh)
            {
                Close();
                return;
            }

            if (!isStop)
            {
                DialogResult result = MessageBox.Show("确定要取消么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Log(string.Format("已取消操作"));
                    isStop = true;
                    lbCurrent.Text = "已取消";
                    timer.Stop();
                    btnFinsh.Text = "完成";
                }
            }
            else
            {
                Close();
            }
        }
    }
}
