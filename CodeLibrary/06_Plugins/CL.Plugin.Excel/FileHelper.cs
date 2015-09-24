using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CL.Plugin.Excel
{
    /// <summary>
    /// 文件助手
    /// </summary>
    public class WebFileHelper
    {
        #region 属性
        /// <summary>
        /// 文件信息
        /// </summary>
        public FileInfo file { get; set; }
        #endregion


        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path">文件路径</param>
        public WebFileHelper(string path)
        {
            file = new FileInfo(path);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="file">文件对象</param>
        public WebFileHelper(FileInfo file)
        {
            this.file = file;
        }
        #endregion


        #region 公共方法
        /// <summary>
        /// 通过文件路径获取文件名
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            if (file.Exists == false)
            {
                return string.Empty;
            }
            return file.Name;
        }

        /// <summary>
        /// 通过文件路径获取后缀名
        /// </summary>
        /// <returns></returns>
        public string GetFileSubfix()
        {
            if (file.Exists == false)
            {
                return string.Empty;
            }
            return file.Extension.Replace(".", string.Empty);
        }

        /// <summary>
        /// 获取文件修改日期
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件修改日期</returns>
        public DateTime GetFileModiTime(string filePath)
        {
            if (file.Exists)
            {
                return File.GetLastWriteTimeUtc(file.FullName).AddHours(8);
            }
            //文件不存在返回最大日期
            else
            {
                return DateTime.MaxValue;
            }
        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <returns></returns>
        public Stream GetFileStream()
        {
            return file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        #endregion
    }

    /// <summary>
    /// 上传文件类
    /// </summary>
    public class UploadFile
    {
        #region 属性
        /// <summary>
        /// 文件锁
        /// </summary>
        private static object objLock;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string filePath { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// PostedFile文件
        /// </summary>
        public HttpPostedFile hpf { get; set; }
        #endregion


        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        static UploadFile()
        {
            objLock = new object();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hpf">postfile文件</param>
        /// <param name="fileName">保存的文件名称</param>
        public UploadFile(HttpPostedFile hpf, string fileName)
            : this(hpf, fileName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadFiles"))
        {
            // HttpRuntime.AppDomainAppPath
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hpf">postfile文件</param>
        /// <param name="fileName">保存的文件名称</param>
        /// <param name="filePath">上传路径</param>
        public UploadFile(HttpPostedFile hpf, string fileName, string filePath)
        {
            this.hpf = hpf;
            this.fileName = fileName;
            this.filePath = filePath;
        }
        #endregion


        #region 方法
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public void Upload()
        {
            lock (objLock)
            {
                FileInfo fi;
                DirectoryInfo foderDir;
                string FilePath;

                foderDir = new DirectoryInfo(filePath);
                FilePath = Path.Combine(filePath, fileName);
                fi = new FileInfo(FilePath);

                //判断文件是否存在,存在则删除
                if (fi.Exists == true)
                {
                    fi.Delete();
                }
                //文件不存在，判断路径是否存在，如果不存在则创建目录
                else if (foderDir.Exists == false)
                {
                    foderDir.Create();
                }

                hpf.SaveAs(fi.FullName);
            }
        }
        #endregion
    }


    /// <summary>
    /// 下载助手
    /// </summary>
    public class DownloadFile
    {
        #region 属性
        /// <summary>
        /// 文件锁
        /// </summary>
        private static object objLock;
        /// <summary>
        /// 分块下载，每块的大小
        /// </summary>
        private static long ChunkSize;
        /// <summary>
        /// 缓冲区
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// 要下载的流
        /// </summary>
        public Stream stream { get; set; }
        /// <summary>
        /// 下载的文件名
        /// </summary>
        public string fileName { get; set; }
        #endregion


        #region 构造函数
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static DownloadFile()
        {
            ChunkSize = 102400;
            objLock = new object();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public DownloadFile(Stream s, string fileName)
        {
            stream = s;
            this.fileName = fileName;
            buffer = new byte[ChunkSize];
        }
        #endregion


        #region 方法
        /// <summary>
        /// 下载文件
        /// </summary>
        public void Download()
        {
            lock (objLock)
            {
                long dataLengthToRead;
                int lengthRead, chunkSize;
                HttpResponse hr;

                if (stream == null)
                {
                    throw new FileNotFoundException("未找到资源文件！");
                }

                hr = HttpContext.Current.Response;
                hr.Clear();
                //获取下载的文件总大小
                dataLengthToRead = stream.Length;

                chunkSize = Convert.ToInt32(ChunkSize);

                hr.ContentType = "application/octet-stream";
                hr.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
                while (dataLengthToRead > 0 && hr.IsClientConnected)
                {
                    //读取的大小
                    lengthRead = stream.Read(buffer, 0, chunkSize);
                    hr.OutputStream.Write(buffer, 0, lengthRead);
                    hr.Flush();
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                hr.Close();
                stream.Close();
            }
        }
        #endregion
    }
}
