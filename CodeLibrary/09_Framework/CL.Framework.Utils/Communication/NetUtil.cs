using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 网络相关工具类
    /// </summary>
    public class NetUtil
    {
        /// <summary>
        /// 通过外部网站得到本机的外部IP
        /// </summary>
        /// <returns></returns>
        public static string GetOuterIP()
        {
            string result = String.Empty;
            try
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(result))
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return result;
        }
    }
}
