using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CL.Framework.Utils
{
    public class JSUtil
    {
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="strMsg">消息</param>
        /// <param name="strUrl">跳转页面，若为空则无跳转</param>
        public static void ShowMessage(Page page, string strMsg, string strUrl)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'>");
            Builder.AppendFormat("alert('{0}');", strMsg);
            if (strUrl != string.Empty)
            {
                Builder.AppendFormat("location.href='{0}'", strUrl);
            }
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(typeof(string), "message", Builder.ToString());
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面</param>
        /// <param name="strMsg">消息</param>
        /// <param name="strUrl">跳转页面，若为空则无跳转</param>
        public static void ShowMessage(Page page, string strMsg)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript'>");
            Builder.AppendFormat("alert('{0}');", strMsg);
            //if (strUrl != string.Empty)
            //{
            //    Builder.AppendFormat("location.href='{0}'", strUrl);
            //}
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(typeof(string), "message", Builder.ToString());
        }
    }
}
