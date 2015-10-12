using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CL.Web.Background.Pages.Other
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label0.Text = "请求开始时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Label1.Text = "服务器名称：" + Server.MachineName;//服务器名称  
            Label2.Text = "服务器IP地址：" + Request.ServerVariables["LOCAL_ADDR"];//服务器IP地址  
            Label3.Text = "HTTP访问端口：" + Request.ServerVariables["SERVER_PORT"];//HTTP访问端口"
            Label4.Text = ".NET解释引擎版本：" + ".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;//.NET解释引擎版本  
            Label5.Text = "服务器操作系统版本：" + Environment.OSVersion.ToString();//服务器操作系统版本  
            Label6.Text = "服务器IIS版本：" + Request.ServerVariables["SERVER_SOFTWARE"];//服务器IIS版本  
            Label7.Text = "服务器域名：" + Request.ServerVariables["SERVER_NAME"];//服务器域名  
            Label8.Text = "虚拟目录的绝对路径：" + Request.ServerVariables["APPL_RHYSICAL_PATH"];//虚拟目录的绝对路径  
            Label9.Text = "执行文件的绝对路径：" + Request.ServerVariables["PATH_TRANSLATED"];//执行文件的绝对路径  
            Label10.Text = "虚拟目录Session总数：" + Session.Contents.Count.ToString();//虚拟目录Session总数  
            Label11.Text = "虚拟目录Application总数：" + Application.Contents.Count.ToString();//虚拟目录Application总数  
            Label12.Text = "域名主机：" + Request.ServerVariables["HTTP_HOST"];//域名主机  
            Label13.Text = "服务器区域语言：" + Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];//服务器区域语言  
            Label14.Text = "用户信息：" + Request.ServerVariables["HTTP_USER_AGENT"];
            Label14.Text = "CPU个数：" + Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");//CPU个数  
            Label15.Text = "CPU类型：" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");//CPU类型  
            Label16.Text = "请求来源地址：" + Request.Headers["X-Real-IP"];  //真实请求IP地址
        }
    }
}