using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 邮件工具类
    /// </summary>
    public class MailUtil
    {

        ////检索 COM 类工厂中 CLSID 为 {F812B147-0E26-4222-8EE4-9F753CD2B39C} 的组件失败，原因是出现以下错误: 80040154 没有注册类 (异常来自 HRESULT:0x80040154 (REGDB_E_CLASSNOTREG))。
        ////需要在服务器安装JMail44_pro.exe

        //public void SendMail(string title, string body, string toMail, string parHost = "", string parSendName = "", string parSendPwd = "")
        //{
        //    try
        //    {
        //        string host = parHost == "" ? "mail.sohu.com" : parHost;
        //        string senderName = parSendName == "" ? "jameshappy027@sohu.com" : parSendName;
        //        string senderPwd = parSendPwd == "" ? "jameshappy027" : parSendPwd;
        //        int port = 25;

        //        ReceiveEmail(senderName, senderPwd, port, host);
        //        MailMessage mail = new MailMessage(senderName, toMail);
        //        mail.Subject = title;
        //        mail.Body = body;
        //        SmtpClient client = new SmtpClient(host, port);
        //        client.Credentials = new NetworkCredential(senderName, senderPwd);
        //        client.Send(mail);
        //        client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //void client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{

        //}

        ///// <summary>
        ///// 收取邮件
        ///// </summary>
        ///// <param name="parEmail"></param>
        ///// <param name="parPwd"></param>
        ///// <param name="parPort"></param>
        ///// <param name="parPort"></param>
        //public void ReceiveEmail(string parEmail, string parPwd, int parPort, string host)
        //{
        //    jmail.POP3Class popMail = new jmail.POP3Class();
        //    jmail.Message mailMessage;
        //    jmail.Attachments atts;
        //    jmail.Attachment att;
        //    string pop = host;
        //    popMail.Connect(parEmail, parPwd, pop, 110);
        //    popMail.Disconnect();
        //    popMail = null;
        //}
    }
}
