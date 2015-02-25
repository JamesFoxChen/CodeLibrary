using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 路径工具类
    /// </summary>
    public class WebPathUtil
    {
        /// <summary>
        /// 获取程序上的虚拟目录的根路径
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;
                return ("/" == applicationPath) ? string.Empty : applicationPath;
            }
        }
    }
}
