using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.User;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.User.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.User
{
    public partial class UpdateUserMoney : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var request = new UserMoneyInfoRequest
                {
                    UserName = Request["ID"]
                };

                var biz = new UserMoneyBiz();
                var data = biz.GetUserMoneyInfo(request);
                this.lblUserName.Text = data.UserName;
                this.lblUserMoney.Text = data.Value.ToString();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            var request = new UpdateUserMoneyInfoRequest
            {
                ID = Request["ID"],
                Value = this.txtValue.Text.ToDecimal(),
                Type = 1,
                OperateID = "1"
            };
            var biz = new UserMoneyBiz();
            var response = biz.UpdateUserMoneyInfo(request);
            if (response.IsSuccess)
            {
                Response.Write("<script>alert('操作成功！');location.href='UserList.aspx';</script>");
            }
        }
    }
}