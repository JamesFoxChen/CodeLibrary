using System;
using System.Web.UI.WebControls;
using CL.Biz.Background.Other;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Display
{
    public partial class MPollImageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource(1);
            }
        }

        public void BindDataSource(Int32 index)
        {
            var biz = new MPollImagesBiz();
            var datalist = biz.GetMPollImageList();
            rpt.DataSource = datalist;
            rpt.DataBind();
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "IsDelete")
            {
                string id = e.CommandArgument.ToString();
                var biz = new MPollImagesBiz();
                if (biz.DeleteMPollImage(id, "", "") > 0)
                {
                    Response.Write("<script>alert('删除成功！');</script>");
                    BindDataSource(1);
                }
            }
        }
    }
}