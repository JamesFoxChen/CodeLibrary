using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace CL.Framework.Utils
{
    public class HttpRequestResponseUtil
    {
        /// <summary>
        /// 以XElement对象形式请求并返回XElement数据
        /// </summary>
        /// <param name="requestDataXml"></param>
        /// <returns></returns>
        public static XElement GetRemoteData(XElement requestDataXml, string url, string method = "POST")
        {
            XElement xe = null;

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(requestDataXml.ToString());

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = method;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            // 发送数据.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // 返回数据
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            xe = XElement.Parse(content);
            return xe;
        }


        /// <summary>
        /// 以Xml字符串对象形式请求并返回Xml字符串数据
        /// </summary>
        /// <param name="requestDataXml"></param>
        /// <returns></returns>
        public static string GetRemoteData(string requestData, string url, string method = "POST")
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(requestData);

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = method;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            // 发送数据.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // 返回数据
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();

            return content;
        }
    }
}
