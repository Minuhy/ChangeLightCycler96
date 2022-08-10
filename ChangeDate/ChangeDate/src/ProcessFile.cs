using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ChangeDate
{
    class ProcessFile
    {
        string[] FILES_NAME = {
               "rdml_data.xml",
            "instrument_data.xml" ,
            "app_data.xml",
            "module_data.xml",
            "calculated_data.xml",
            "manifest.xml",
            "hash.key"
        };

        const int DATA_RDML = 0;
        const int DATA_INSTRUMENT = 1;
        const int DATA_APP = 2;
        const int DATA_MODULE = 3;
        const int DATA_CALCULATED = 4;
        const int FILE_MANIFEST = 5;

        List<FileStreamContainer> source = new List<FileStreamContainer>();
        List<FileStringContainer> target = new List<FileStringContainer>();
        MemoryStream destinationStream = null;
        MemoryStream manifestStream = null;

        public ProcessFile(string file)
        {
            LoadFile(file);
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void LoadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("无效的文件路径！");
            }

            FileShare read = FileShare.Read;

            FileStream stream = null;
            try
            {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, read);
                using (ZipInputStream zipInputStream = new ZipInputStream(stream, true))
                {
                    ZipEntry entry;
                    List<ZipEntry> zipEntries = new List<ZipEntry>();
                    while ((entry = zipInputStream.GetNextEntry()) != null)
                    {
                        if (!entry.IsDirectory)
                        {
                            zipEntries.Add(entry);
                            switch (entry.FileName)
                            {
                                case "rdml_data.xml":
                                    {
                                        MemoryStream rdmlStream = new MemoryStream();
                                        CopyStream(zipInputStream, rdmlStream);
                                        source.Add(new FileStreamContainer(FILES_NAME[DATA_RDML], rdmlStream));
                                        break;
                                    }
                                case "instrument_data.xml":
                                    {
                                        MemoryStream instrumentStream = new MemoryStream();
                                        CopyStream(zipInputStream, instrumentStream);
                                        source.Add(new FileStreamContainer(FILES_NAME[DATA_INSTRUMENT], instrumentStream));
                                        break;
                                    }
                                case "app_data.xml":
                                    {
                                        MemoryStream appStream = new MemoryStream();
                                        CopyStream(zipInputStream, appStream);
                                        source.Add(new FileStreamContainer(FILES_NAME[DATA_APP], appStream));
                                        break;
                                    }
                                case "module_data.xml":
                                    {
                                        MemoryStream moduleStream = new MemoryStream();
                                        CopyStream(zipInputStream, moduleStream);
                                        source.Add(new FileStreamContainer(FILES_NAME[DATA_MODULE], moduleStream));
                                        break;
                                    }
                                case "calculated_data.xml":
                                    {
                                        MemoryStream calculatedStream = new MemoryStream();
                                        CopyStream(zipInputStream, calculatedStream);
                                        source.Add(new FileStreamContainer(FILES_NAME[DATA_CALCULATED], calculatedStream));
                                        break;
                                    }
                                case "hash.key":
                                    destinationStream = new MemoryStream();
                                    CopyStream(zipInputStream, destinationStream);
                                    break;

                                case "manifest.xml":
                                    manifestStream = new MemoryStream();
                                    CopyStream(zipInputStream, manifestStream);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// 调整时间
        /// </summary>
        /// <param name="totalDays">偏移的天数</param>
        public void AdjustmentTime(double totalDays)
        {
            Log("-------> 开始调整时间：");
            foreach (string fileName in FILES_NAME)
            {
                MemoryStream memoryStream = FindStream(source, fileName);
                if (memoryStream != null)
                {
                    MemoryStream stream = new MemoryStream();
                    CopyStream(memoryStream, stream);
                    var sr = new StreamReader(stream);
                    string myStr = sr.ReadToEnd();
                    memoryStream.Position = 0;
                    stream.Close();
                    // Console.WriteLine(myStr);

                    MatchCollection collection = Regex.Matches(myStr, "[0-9][0-9][0-9][0-9]-[01][0-9]-[0-3][0-9]T[012][0-9]:[0-6][0-9]:[0-6][0-9]");
                    Log(string.Format("找到{0}个匹配的字符串！", collection.Count));
                    for (int i = 0; i < collection.Count; i++)
                    {
                        Log(string.Format("第{0}个：{1}", i, collection[i].ToString()));
                        string dateString = collection[i].ToString().Replace("T", " ");
                        DateTime dt = Convert.ToDateTime(dateString);
                        Log(string.Format("转换后格式：{0}", dt.ToString("F")));

                        // 调整后时间
                        DateTime dtAfter = dt.AddDays(totalDays);
                        Log(string.Format("调整后时间：{0}", dtAfter.ToString("F")));
                        string dateStringAfter = dtAfter.ToString("yyyy-MM-dd HH:mm:ss").Replace(" ", "T");
                        Log(string.Format("第{0}个调整后：{1}", i, dateStringAfter));

                        myStr = myStr.Replace(collection[i].ToString(), dateStringAfter);
                    }
                    FileStringContainer fileStringContainer = new FileStringContainer(fileName, myStr);
                    target.Add(fileStringContainer);
                }
                else
                {
                    Log(string.Format("{0} 内容为空！", fileName));
                }
            }
        }


        /// <summary>
        /// 提取出所有的时间
        /// </summary>
        /// <returns></returns>
        public DateTime[] ExtractAllTime()
        {
            List<DateTime> dateTimes = new List<DateTime>();
            foreach (string fileName in FILES_NAME)
            {
                MemoryStream memoryStream = FindStream(source, fileName);
                if (memoryStream != null)
                {
                    MemoryStream stream = new MemoryStream();
                    CopyStream(memoryStream, stream);
                    var sr = new StreamReader(stream);
                    string myStr = sr.ReadToEnd();
                    memoryStream.Position = 0;
                    stream.Close();
                    // Console.WriteLine(myStr);

                    MatchCollection collection = Regex.Matches(myStr, "[0-9][0-9][0-9][0-9]-[01][0-9]-[0-3][0-9]T[012][0-9]:[0-6][0-9]:[0-6][0-9]");
                    Log(string.Format("找到{0}个匹配的字符串！", collection.Count));
                    for (int i = 0; i < collection.Count; i++)
                    {
                        Log(string.Format("第{0}个：{1}", i, collection[i]));
                        string dateString = collection[i].ToString().Replace("T", " ");
                        DateTime dt = Convert.ToDateTime(dateString);
                        Log(string.Format("转换后格式：{0}", dt.ToString("F")));
                        dateTimes.Add(dt);
                    }
                }
                else
                {
                    Log(string.Format("{0} 内容为空！", fileName));
                }
            }
            return dateTimes.ToArray();
        }

        /// <summary>
        /// 销毁本对象
        /// </summary>
        public void Dispose()
        {
            foreach (FileStreamContainer fileStream in source)
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }

            foreach (FileStringContainer stringContainer in target)
            {
                stringContainer.Dispose();
            }

            if (destinationStream != null)
            {
                destinationStream.Flush();
                destinationStream.Close();
                destinationStream.Dispose();
            }
            if (manifestStream != null)
            {
                manifestStream.Flush();
                manifestStream.Close();
                manifestStream.Dispose();
            }

            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="txt">日志内容</param>
        public static void Log(string txt)
        {
            Console.WriteLine(txt);
        }

        public static MemoryStream FindStream(List<FileStreamContainer> source, string name)
        {
            foreach (FileStreamContainer stream in source)
            {
                if (stream.Name.Equals(name))
                {
                    return stream.Stream;
                }
            }

            return null;
        }

        public static string FindString(List<FileStringContainer> source, string name)
        {
            foreach (FileStringContainer str in source)
            {
                if (str.Name.Equals(name))
                {
                    // Log(name);
                    // Log("------");
                    // Log(str.Str);
                    // Log("------");
                    return str.Str;
                }
            }

            return null;
        }

        /// <summary>
        /// 复制流
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <param name="destinationStream"></param>
        public static void CopyStream(Stream sourceStream, Stream destinationStream)
        {
            int num;
            byte[] buffer = new byte[0x800];
            while ((num = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, num);
            }
            destinationStream.Seek(0L, SeekOrigin.Begin);
        }


        /// <summary>
        /// 计算MD5校验码
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static string ComputeHashKey(MemoryStream[] files)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] seed = new byte[0];
            seed = (from item in files
                    where item != null
                    select item).Aggregate<MemoryStream, byte[]>(seed, (current, item) => current.Concat<byte>(item.ToArray()).ToArray<byte>());
            byte[] buffer2 = md.ComputeHash(seed);
            StringBuilder builder = new StringBuilder(buffer2.Length * 2);
            foreach (byte num in buffer2)
            {
                builder.AppendFormat("{0:x2}", num);
            }
            return builder.ToString();
        }


        public void SaveFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("不正确的保存路径！");
            }

            // Tuple<rdml, rocheLC96InstrumentData, rocheLC96AppExtension, rocheLC96ModuleData, rocheLC96CalculatedData, lc96manifest> tuple = new Lc96Writer(domainModelContainer, this.globalConfigurationService, this.userConfigurationService).Translate();

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);


                using (ZipOutputStream zipStream = new ZipOutputStream(fileStream, true))
                {
                    MemoryStream stream2 = new MemoryStream();
                    // XmlSerializer serializer = new XmlSerializer(typeof(rdml));
                    using (StreamWriter writer2 = new StreamWriter(stream2))
                    {
                        // serializer.Serialize((TextWriter)writer2, tuple.Item1);
                        string zipFileName = FILES_NAME[DATA_RDML];
                        string str = FindString(target, zipFileName);
                        writer2.Write(str);
                        writer2.Flush();
                        zipStream.PutNextEntry(zipFileName);
                        WriteToOutputStream(zipStream, stream2);
                        List<FileStreamContainer> list = new List<FileStreamContainer> {
                        new FileStreamContainer(zipFileName, stream2)
                    };

                        StreamWriter writer3 = null;
                        StreamWriter writer4 = null;
                        StreamWriter writer5 = null;
                        StreamWriter writer6 = null;
                        StreamWriter textWriter = null;

                        zipFileName = FILES_NAME[DATA_INSTRUMENT];
                        str = FindString(target, zipFileName);
                        if (str != null)
                        {
                            MemoryStream stream3 = new MemoryStream();
                            // XmlSerializer serializer2 = new XmlSerializer(typeof(rocheLC96InstrumentData));
                            writer3 = new StreamWriter(stream3);
                            writer3.Write(str);
                            writer3.Flush();
                            zipStream.PutNextEntry(zipFileName/*"instrument_data.xml"*/);
                            WriteToOutputStream(zipStream, stream3);
                            list.Add(new FileStreamContainer(zipFileName, stream3));
                        }

                        zipFileName = FILES_NAME[DATA_APP];
                        str = FindString(target, zipFileName);
                        if (str != null)
                        {
                            MemoryStream stream4 = new MemoryStream();
                            // XmlSerializer serializer3 = new XmlSerializer(typeof(rocheLC96AppExtension));
                            writer4 = new StreamWriter(stream4);
                            // serializer3.Serialize((TextWriter)writer4, tuple.Item3);
                            writer4.Write(str);
                            writer4.Flush();
                            zipStream.PutNextEntry(zipFileName);
                            WriteToOutputStream(zipStream, stream4);
                            list.Add(new FileStreamContainer(zipFileName, stream4));
                        }
                        zipFileName = FILES_NAME[DATA_MODULE];
                        str = FindString(target, zipFileName);
                        if (str != null)
                        {
                            MemoryStream stream5 = new MemoryStream();
                            // XmlSerializer serializer4 = new XmlSerializer(typeof(rocheLC96ModuleData));
                            writer5 = new StreamWriter(stream5);
                            // serializer4.Serialize((TextWriter)writer5, tuple.Item4);
                            writer5.Write(str);
                            writer5.Flush();
                            zipStream.PutNextEntry(zipFileName);
                            WriteToOutputStream(zipStream, stream5);
                            list.Add(new FileStreamContainer(zipFileName, stream5));
                        }
                        zipFileName = FILES_NAME[DATA_CALCULATED];
                        str = FindString(target, zipFileName);
                        if (str != null)
                        {
                            MemoryStream stream6 = new MemoryStream();
                            // XmlSerializer serializer5 = new XmlSerializer(typeof(rocheLC96CalculatedData));
                            writer6 = new StreamWriter(stream6);
                            // serializer5.Serialize((TextWriter)writer6, tuple.Item5);
                            writer6.Write(str);
                            writer6.Flush();
                            zipStream.PutNextEntry(zipFileName);
                            WriteToOutputStream(zipStream, stream6);
                            list.Add(new FileStreamContainer(zipFileName, stream6));
                        }

                        zipFileName = FILES_NAME[FILE_MANIFEST];
                        MemoryStream memoryStream = new MemoryStream();
                        CopyStream(manifestStream, memoryStream);
                        var sr = new StreamReader(memoryStream);
                        string manifestString = sr.ReadToEnd();
                        manifestStream.Position = 0;

                        if (manifestString != null)
                        {
                            IEnumerable<MemoryStream> source = from f in list
                                                               where f.Stream != null
                                                               orderby f.Name
                                                               select f.Stream;
                            string hashkey = ComputeHashKey(source.ToArray<MemoryStream>());

                            Log(string.Format("计算出的新的Hash值：{0}", hashkey));

                            // 替换哈希值
                            MatchCollection collection = Regex.Matches(manifestString, "hashkey=\".*\"");
                            hashkey = "hashkey=\"" + hashkey + "\"";
                            if (collection.Count > 0)
                            {
                                manifestString = manifestString.Replace(collection[0].ToString(), hashkey);
                                Log(string.Format("替换Hash值：{0} -> {1}", collection[0].ToString(), hashkey));
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder(manifestString);
                                string oldStr = "experiment";
                                string newStr = "experiment " + hashkey;
                                manifestString = sb.Replace(oldStr, newStr, 0, manifestString.IndexOf(oldStr) + hashkey.Length + 1).ToString();//指定替换的范围实现替换一次,并且指定范围中要只有一个替换的字符串
                                                                                                                                               // manifestString = manifestString.Replace("experiment", );
                                Log(string.Format("原始Hash值丢失，添加Hash值：{0}", hashkey));
                            }

                            MemoryStream stream7 = new MemoryStream();
                            // XmlSerializer serializer6 = new XmlSerializer(typeof(lc96manifest));
                            textWriter = new StreamWriter(stream7);
                            // XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                            // namespaces.Add(string.Empty, string.Empty);
                            // serializer6.Serialize(textWriter, tuple.Item6, namespaces);
                            textWriter.Write(manifestString);
                            // Log(manifestString);
                            textWriter.Flush();
                            zipStream.PutNextEntry(zipFileName);
                            WriteToOutputStream(zipStream, stream7);
                            // log.DebugFormat(CultureInfo.CurrentCulture, "Hash key \"{0}\" written in manifest file.", new object[] { tuple.Item6.experiment.hashkey });
                        }
                    }
                    zipStream.Flush();
                    ((FileStream)fileStream).Flush(true);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                Log("已保存：" + filePath);
            }
            // fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            // domainModelContainer.ExperimentOrigin = ExperimentOriginOption.FromWritableFile;
        }

        private void WriteToOutputStream(ZipOutputStream output, Stream dataStream)
        {
            int num;
            dataStream.Seek(0L, SeekOrigin.Begin);
            byte[] buffer = new byte[0x800];
            while ((num = dataStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, num);
            }
        }


    }

    class FileStringContainer : IDisposable
    {
        private bool disposed;

        public FileStringContainer(string name, string str)
        {
            Name = name;
            Str = str;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public string Name { get; set; }

        public string Str { get; set; }
    }
    class FileStreamContainer : IDisposable
    {
        private bool disposed;

        public FileStreamContainer(string name, MemoryStream stream)
        {
            Name = name;
            Stream = stream;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                if (Stream != null)
                {
                    Stream.Flush();
                    Stream.Close();
                }
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        public string Name { get; set; }

        public MemoryStream Stream { get; set; }
    }
}
