namespace CL.Biz.Common
{
    public class Constant
    {
        public static string Newline = "\r\n";

        /// <summary>
        /// 短信过期时间（秒）
        /// </summary>
        public static int SmsExpiredTime
        {
            get { return 60; }
        }
    }
}
