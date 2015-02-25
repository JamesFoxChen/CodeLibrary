using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Framework.Utils
{
    public class ConfigUtil
    {
        public static bool IsLog
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsLog"]);
            }
        }
        public static string LogName
        {
            get
            {
                return ConfigurationManager.AppSettings["LogName"].ToString(CultureInfo.InvariantCulture);
            }
        }
        public static string LogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["LogPath"].ToString(CultureInfo.InvariantCulture);
            }
        }
        public static long MaxTxtLength
        {
            get
            {
                return Convert.ToInt64(ConfigurationManager.AppSettings["MaxTxtLength"]);
            }
        }
        public static int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }
        public static int CacheExpireTime
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpireTime"]);
            }
        }
        public static string SendName
        {
            get
            {
                return ConfigurationManager.AppSettings["SendName"].ToString(CultureInfo.InvariantCulture);
            }
        }
        public static string SendPwd
        {
            get
            {
                return ConfigurationManager.AppSettings["SendPwd"].ToString(CultureInfo.InvariantCulture);
            }
        }
        public static bool IsResponseFormatJson
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsResponseFormatJson"]);
            }
        }
    }
}
