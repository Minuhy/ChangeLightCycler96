using ChangeDate.src.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeDate.src
{
    class CrackServiceMD5
    {
        public static string ChooseFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // 该值确定是否可以选择多个文件
            dialog.Title = "请选择要操作的软件"; // 弹窗的标题
            dialog.Filter = "LC96程序(*.exe)|*.exe"; // 筛选文件
            dialog.ShowHelp = true; //是否显示“帮助”按钮

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string dir = dialog.FileName.Substring(0, dialog.FileName.LastIndexOf("\\") + 1);
                return dir;
            }

            MessageBox.Show("没有选择文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return null;
        }

        public static bool CancelMD5()
        {
            string path = ChooseFile();
            if (path != null)
            {
                string res = WriteFile(ZooFileData.crack, path);
                if (res == null)
                {
                    MessageBox.Show(string.Format("成功，已将修改后的dll文件写入至 {0}", Path.Combine(path, "Roche.LC120.Infrastructure.Services.dll")));
                    return true;
                }
                else
                {
                    MessageBox.Show("失败：" + res);
                }
            }

            return false;
        }

        public static bool RebuildMD5()
        {
            string path = ChooseFile();
            if (path != null)
            {
                string res = WriteFile(ZooFileData.normal, path);
                if (res == null)
                {
                    MessageBox.Show(string.Format("成功，已将原文件写入至 {0}", Path.Combine(path, "Roche.LC120.Infrastructure.Services.dll")));
                    return true;
                }
                else
                {
                    MessageBox.Show("失败：" + res);
                }
            }
            return false;
        }

        public static string WriteFile(byte[] bytes, string dir)
        {
            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(dir, "Roche.LC120.Infrastructure.Services.dll"), FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    fileStream.Write(bytes,0,bytes.Length);
                    fileStream.Flush();
                }
                return null;
            }catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
