

using System;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CL.Web.Background.Pages.Common
{
    public class AuthLoginPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //GetAdminInfoResponse adminInfosession = (GetAdminInfoResponse)Session["admin"];// 
            //if (adminInfosession == null)
            //{
            //    Response.Write("<script>alert('你尚未登录！');top.location.href='/Login.aspx';</script>");
            //}
        }
    }
}