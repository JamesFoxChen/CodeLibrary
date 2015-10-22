using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Plugin.Sms
{
    internal class SmsMngInner
    {
        public static bool Sendcode(string PhoneNumber, string Module, string[] Content)
        {
            string ret = null;

            CCPRestSDK api = new CCPRestSDK();
            bool isInit = api.init(SmsConstant.SmsRestAddress, SmsConstant.SmsRestPort);//正式上线

            api.setAccount(SmsConstant.AccountSID, SmsConstant.AccountToken);
            api.setAppId(SmsConstant.AppId);

            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.SendTemplateSMS(PhoneNumber, Module, Content);//
                    ret = getDictionaryData(retData);
                }
                else
                {
                    ret = "初始化失败";
                }
            }
            catch (Exception exc)
            {
                ret = exc.Message;
            }

            return true;
        }
 


        private static string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}
