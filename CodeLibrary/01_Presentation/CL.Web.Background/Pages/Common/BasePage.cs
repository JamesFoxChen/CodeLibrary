using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CL.Biz.Common;

namespace CL.Web.Background.Pages.Common
{
    public class BasePage : Page
    {
        public String PaginationHtml;

        //protected GetAdminInfoResponse CurrentAdminInfo
        //{
        //    get { return (GetAdminInfoResponse) Session["admin"]; }
        //}
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string url = HttpContext.Current.Request.Url.AbsolutePath;

            ////测试用 陈志
            //var biz = new AdminInfoBiz();
            //GetAdminInfoResponse adminInfo = biz.Login("admin", FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"));

            //var rightInfobiz = new RightInfoBiz();
            //adminInfo.Menu = rightInfobiz.GetRightList(adminInfo.ID);
            //Session["admin"] = adminInfo;
            ////测试用 陈志

            //GetAdminInfoResponse adminInfosession = (GetAdminInfoResponse)Session["admin"];//重点 
            //if (adminInfosession != null)
            //{
            //    int type = 0;
            //    foreach (var item in adminInfosession.Menu)
            //    {
            //        foreach (var rightInfo in item.rightInfoFrist)
            //        {
            //            if (rightInfo.URL != null)
            //            {
            //                if (rightInfo.URL.ToLower() == url.ToLower())
            //                {
            //                    //有权限
            //                    type = 1;
            //                    break;
            //                }
            //            }

            //        }
            //    }
            //    if (type == 0)//无权限
            //    {
            //        Response.Write("<script>window.open('/NoAuthority.html','_top');</script>");
            //        Session.Clear();
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('你尚未登录！');top.location.href='/Login.aspx';</script>");
            //}
        }

        protected void BindList(Repeater rpt, HtmlGenericControl divList, Label lblMsg,
            object datalist, int totalCount, int pageIndex, int pageSize)
        {
            if (totalCount > 0)
            {
                rpt.DataSource = datalist;
                rpt.DataBind();
                divList.Visible = true;
                PaginationHtml = PageUtil.GetPaginationHTML(pageIndex, totalCount, pageSize, "", "", false);
                lblMsg.Visible = false;
            }
            else
            {
                divList.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "无数据";
            }
        }

        protected void BindDDL(DropDownList ddl, Enum value)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择", ""));
            foreach (var item in value.GetEumKeyValue())
            {
                ddl.Items.Add(new ListItem(item.Value, item.Key));
            }
        }

        protected void BindDDLWithoutEmpty(DropDownList ddl, Enum value)
        {
            ddl.Items.Clear();
            foreach (var item in value.GetEumKeyValue())
            {
                ddl.Items.Add(new ListItem(item.Value, item.Key));
            }
        }

        #region 提示弹框并跳转
        protected void Alert(string msg, string redirect)
        {
            Response.Write(string.Format("<script>alert('{0}');location.href='{1}';</script>", msg, redirect));
        }

        protected void AlertAndRedirectCommon(bool b, string redirect = "")
        {
            var msg = b ? "操作成功" : "操作失败";
            Response.Write(string.Format("<script>alert('{0}');location.href='{1}';</script>", msg, redirect));
        }
        #endregion

        protected void Alert(string msg = "")
        {
            msg = string.IsNullOrWhiteSpace(msg) ? "操作完成" : msg;
            Response.Write(string.Format("<script>alert('{0}');</script>", msg));
        }
    }

    public class ErrorPage : Page
    {
        public Exception ex { get; set; }
    }
}