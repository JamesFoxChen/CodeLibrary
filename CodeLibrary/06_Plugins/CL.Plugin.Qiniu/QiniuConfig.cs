using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.Qiniu
{
    internal class QiniuConfig
    {
        /// <summary>
        /// cdnPath为网站服务器本地路径，本地备份一份，再上传到七牛空间一份
        /// </summary>
        public static string cdnPath = "/cdnPath/";

        /// <summary>
        /// 空间名
        /// </summary>
        public static string bucket = "gossip";// ConfigurationManager.AppSettings["QiniuSpace"];

        /// <summary>
        /// 七牛外域名
        /// </summary>
        public static readonly string Domain = "7b1f5a.com1.z0.glb.clouddn.com";// ConfigurationManager.AppSettings["QiniuDomain"];

        /// <summary>
        /// 图片URL前缀
        /// </summary>
        public static string ImageUrlPredix = "http://7b1f5a.com1.z0.glb.clouddn.com/";//ConfigurationManager.AppSettings["QiniuImageUrlPredix"];

        public static string VERSION = "6.1.8";

        public static string USER_AGENT = getUa();

        #region 帐户信息
        /// <summary>
        /// 七牛提供的公钥，用于识别用户
        /// </summary>
        public static string ACCESS_KEY = "HVexchF05pFWdyuHMs2vlHkplOhlQN3bHlHPZW8x";
        /// <summary>
        /// 七牛提供的秘钥，不要在客户端初始化该变量
        /// </summary>
        public static string SECRET_KEY = "8iSV6oY25A5NlzjV5bQUTDnr4UsA8pH8PSVao3pY";
        #endregion

        #region 七牛服务器地址
        /// <summary>
        /// 七牛资源管理服务器地址
        /// </summary>
        public static string RS_HOST = "http://rs.Qbox.me";
        /// <summary>
        /// 七牛资源上传服务器地址.
        /// </summary>
        public static string UP_HOST = "http://up.qiniu.com";
        /// <summary>
        /// 七牛资源列表服务器地址.
        /// </summary>
        public static string RSF_HOST = "http://rsf.Qbox.me";

        public static string PREFETCH_HOST = "http://iovip.qbox.me";

        public static string API_HOST = "http://api.qiniu.com";
        #endregion

        /// <summary>
        /// 七牛SDK对所有的字节编码采用utf-8形式 .
        /// </summary>
        public static Encoding Encoding = Encoding.UTF8;

        /// <summary>
        /// 初始化七牛帐户、请求地址等信息，不应在客户端调用。
        /// </summary>
        public static void Init()
        {
            if (ConfigurationManager.AppSettings["USER_AGENT"] != null)
            {
                USER_AGENT = ConfigurationManager.AppSettings["USER_AGENT"];
            }
            if (ConfigurationManager.AppSettings["ACCESS_KEY"] != null)
            {
                ACCESS_KEY = ConfigurationManager.AppSettings["ACCESS_KEY"];
            }
            if (ConfigurationManager.AppSettings["SECRET_KEY"] != null)
            {
                SECRET_KEY = ConfigurationManager.AppSettings["SECRET_KEY"];
            }
            if (ConfigurationManager.AppSettings["RS_HOST"] != null)
            {
                RS_HOST = ConfigurationManager.AppSettings["RS_HOST"];
            }
            if (ConfigurationManager.AppSettings["UP_HOST"] != null)
            {
                UP_HOST = ConfigurationManager.AppSettings["UP_HOST"];
            }
            if (ConfigurationManager.AppSettings["RSF_HOST"] != null)
            {
                RSF_HOST = ConfigurationManager.AppSettings["RSF_HOST"];
            }
            if (ConfigurationManager.AppSettings["PREFETCH_HOST"] != null)
            {
                PREFETCH_HOST = ConfigurationManager.AppSettings["PREFETCH_HOST"];
            }
        }
        private static string getUa()
        {
            return "QiniuCsharp/" + VERSION + " (" + Environment.OSVersion.Version.ToString() + "; )";
        }
    }

    /// <summary>
    /// 图片大小
    /// </summary>
    public enum QiniuImageSize
    {
        [Description("原图")]
        原图 = 1,
        [Description("低质量原图")]
        低质量原图 = 2,
        [Description("大图")]
        大图 = 3,
        [Description("中图")]
        中图 = 4,
        [Description("小图")]
        小图 = 5
    }

    /// <summary>
    /// 图片质量
    /// </summary>
    public enum QiniuImageQuality
    {
        [Description("原图")]
        原图,
        [Description("大图")]
        好 = 150,
        [Description("中图")]
        中 = 75,
        [Description("小图")]
        差 = 50,
    }
}
