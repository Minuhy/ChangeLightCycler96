using ChangeDate.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDate
{
    public partial class FormMain : Form
    {
        public const int OFFSET_MODE = 1;
        public const int TIME_PICK_MODE = 2;

        DateTime targetDateTime;
        double offsetTime;
        int mode = TIME_PICK_MODE;

        List<string> files;
        string outputDir;


        StringBuilder logCache;
        public FormMain()
        {
            // 监听载入资源
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            logCache = new StringBuilder();
            InitializeComponent();
            Log("启动完成");
        }

        /// <summary>
        /// 动态加载资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //默认命名空间+文件夹名+.[注意]
            string resourceName = "ChangeDate.src.lib." + new AssemblyName(args.Name).Name + ".dll";

            // LogHelper.Debug("在加载资源：" + resourceName);
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }

                return null;
            }
        }

        /// <summary>
        /// 简单输出日志
        /// </summary>
        /// <param name="txt"></param>
        private void Log(string txt)
        {
            logCache.Append(DateTime.Now.ToString("F"));
            logCache.Append(" : ");
            logCache.Append(txt);
            logCache.Append("\n");

            if (logCache.Length > 4096 * 60)
            {
                logCache.Remove(0, txt.Length + 1 + 3 + DateTime.Now.ToString("F").Length);
            }

            Console.WriteLine(DateTime.Now.ToString("F") + " : " + txt);
        }

        /// <summary>
        /// 文件拖放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbFiles_DragDrop(object sender, DragEventArgs e)
        {
            // 文件拖放事件
            if (sender == lbFiles)
            {
                foreach (Object v in (Array)e.Data.GetData(DataFormats.FileDrop))
                {
                    lbFiles.Items.Add(v);
                }
                Log(string.Format("拖放添加了 {0} 个文件到列表中", ((Array)e.Data.GetData(DataFormats.FileDrop)).Length));
            }
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true; // 该值确定是否可以选择多个文件
            dialog.Title = "请选择要添加的文件"; // 弹窗的标题
            dialog.Filter = "LC96文件(*.lc96p)|*.lc96p|所有文件(*.*)|*.*"; // 筛选文件
            dialog.ShowHelp = true; //是否显示“帮助”按钮

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in dialog.FileNames)
                {
                    lbFiles.Items.Add(file);
                }
                Log(string.Format("添加了 {0} 个文件到列表中", dialog.FileNames.Length));
            }
        }

        /// <summary>
        /// 双击了列表，删除条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lbFiles == sender)
            {
                int index = lbFiles.SelectedIndex;
                if (index < lbFiles.Items.Count && index >= 0)
                {
                    object f = lbFiles.SelectedItem;
                    lbFiles.Items.RemoveAt(index);
                    Log("移除文件：" + f);
                }
            }
        }

        /// <summary>
        /// 清除列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearList_Click(object sender, EventArgs e)
        {
            // 清除原来的
            if (sender == btnClearList)
            {
                lbFiles.Items.Clear();
                Log("清除文件");
            }
        }

        /// <summary>
        /// 文件拖放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbFiles_DragEnter(object sender, DragEventArgs e)
        {
            // 文件拖放事件
            if (sender == lbFiles)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// 选择要保存的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChooseDir_Click(object sender, EventArgs e)
        {
            if (sender == btnChooseDir)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "选择修改后文件的保存文件夹";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbFilesNewDir.Text = dialog.SelectedPath;
                    Log("选择保存位置：" + tbFilesNewDir.Text);
                }
            }
        }

        /// <summary>
        /// 开始处理任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (sender == btnStart)
            {
                if (ReadyStart())
                {
                    Start();
                }
            }
        }

        /// <summary>
        /// 取消验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbCancelMD5_Click(object sender, EventArgs e)
        {
            if (sender == lbCancelMD5)
            {
                DialogResult result = MessageBox.Show("取消验证请点“是”，恢复验证请点“否”，终止操作请点“取消”。", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // 修改软件，取消验证
                    if(CrackServiceMD5.CancelMD5())
                    {
                        Log("成功修改软件：取消验证");
                    }
                }
                else if (result == DialogResult.No)
                {
                    if (CrackServiceMD5.RebuildMD5())
                    {
                        Log("成功修改软件：恢复验证");
                    }
                }
            }
        }

        /// <summary>
        /// 关于 和 日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbAbout_Click(object sender, EventArgs e)
        {
            if (sender == lbAbout)
            {
                new LogForm(logCache.ToString()).ShowDialog();
            }
        }

        /// <summary>
        /// 开始处理
        /// </summary>
        private void Start()
        {
            if (mode == TIME_PICK_MODE)
            {
                new FormDispose(files, targetDateTime, outputDir).ShowDialog();
            }
            else if (mode == OFFSET_MODE)
            {
                new FormDispose(files, offsetTime, outputDir).ShowDialog();
            }
            else
            {
                MessageBox.Show("未知的模式", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 准备和校验待处理的数据
        /// </summary>
        /// <returns></returns>
        private bool ReadyStart()
        {
            Log("准备待处理的数据......");

            // 要处理的数据

            List<string> filesList = new List<string>();
            foreach (object obj in lbFiles.Items)
            {
                string filePath = obj.ToString();
                if (!filesList.Contains(filePath))
                {
                    if (filePath.EndsWith(".lc96p"))
                    {
                        if (File.Exists(filePath))
                        {
                            filesList.Add(filePath);
                        }
                        else
                        {
                            Log(string.Format("不能处理的文件：{0}（文件不存在）", filePath));
                        }
                    }
                    else
                    {
                        Log(string.Format("不能处理的文件：{0}（文件后缀必须为“.lc96p”）", filePath));
                    }
                }
                else
                {
                    Log(string.Format("文件重复：{0}", filePath));
                }
            }

            int fileCount = filesList.Count();
            if (fileCount > 0)
            {
                Log(string.Format("待处理文件总数：{0}", fileCount));
                files = filesList;
            }
            else
            {
                MessageBox.Show("没有要处理的文件！（具体情况请查阅日志）", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log("没有要处理的文件！");
                return false;
            }

            // 新日期
            if (tcTimePick.SelectedIndex == 0)
            {
                Log(string.Format("处理模式：指定时间"));
                targetDateTime = dtpChooseTime.Value;
                mode = TIME_PICK_MODE;
                Log(string.Format("要调整到的日期：{0}", targetDateTime.ToString("F")));
            }
            else if (tcTimePick.SelectedIndex == 1)
            {
                Log(string.Format("处理模式：时间偏移"));
                if (!double.TryParse(tbOffset.Text.Trim(), out offsetTime))
                {
                    MessageBox.Show(string.Format("{0} 无法转换，请在偏移时间中输入正确的天数！（整数或浮点数）", tbOffset.Text), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log(string.Format("天数格式输入不正确！操作终止：{0}", tbOffset.Text));
                    return false;
                }
                mode = OFFSET_MODE;
                Log(string.Format("要调整的时间偏移：{0}", offsetTime));
            }

            // 新目录位置
            string outputPath = tbFilesNewDir.Text;

            if (!Directory.Exists(outputPath))
            {
                try
                {
                    Log(string.Format("尝试创建文件夹：{0}", outputPath));
                    Directory.CreateDirectory(outputPath);
                }
                catch (Exception e)
                {
                    Log(string.Format("尝试创建文件夹“{0}”时出错！", e.Message));
                }
            }

            if (!Directory.Exists(outputPath))
            {
                MessageBox.Show(string.Format("{0} 作为输出文件夹不存在！请重新选择保存位置！", outputPath), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(string.Format("{0} 作为输出文件夹不存在！", outputPath));
                return false;
            }
            outputDir = outputPath;
            Log(string.Format("文件输出位置：{0}", outputPath));

            // 总结报告
            string tips;
            if (mode == OFFSET_MODE)
            {
                tips = string.Format("本次需要处理共{0}个文件，偏移文件Summary时间为{1}天，输出保存位置为{2}，接下来的操作将会直接覆盖保存位置下的同名文件，是否继续？", files.Count, offsetTime.ToString("F"), outputDir);
                Log(string.Format("本次需要处理共{0}个文件，偏移文件Summary时间为{1}天，输出保存位置为{2}", files.Count, offsetTime.ToString("F"), outputDir));
            }
            else if (mode == TIME_PICK_MODE)
            {
                tips = string.Format("本次需要处理共{0}个文件，调整文件Summary时间为{1}，输出保存位置为{2}，接下来的操作将会直接覆盖保存位置下的同名文件，是否继续？", files.Count, targetDateTime.ToString("F"), outputDir);
                Log(string.Format("本次需要处理共{0}个文件，调整文件Summary时间为{1}，输出保存位置为{2}", files.Count, targetDateTime.ToString("F"), outputDir));
            }
            else
            {
                Log("检测时间调整模式失败！");
                MessageBox.Show("未知的模式", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 申请开始
            DialogResult result = MessageBox.Show(tips, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Log("准备结束，已获得同意，开始处理文件...");
                return true;
            }

            return false;
        }

    }
}
