using System;
using System.Collections.Generic;
using System.Web.UI;
using CL.CrossDomain.DomainModel.Background.User.Response;


namespace CL.Web.Background
{
    public partial class Left : Page
    {
        //public List<GetRightInfoResponse> Menu;
        protected void Page_Load(object sender, EventArgs e)
        {

            //var u = (GetRightInfoResponse)Session["admin"];//重点 
            //if (u != null)
            //{
            //    Menu = u.Menu;

            //}
            //else
            //{
            //    Response.Write("<script>alert('你尚未登录！');top.location.href='/Login.aspx';</script>");
            //    return;
            //}
        }
    }
}