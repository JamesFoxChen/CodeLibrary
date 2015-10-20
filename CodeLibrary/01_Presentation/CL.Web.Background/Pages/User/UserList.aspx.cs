using System;

using System.Web.UI.WebControls;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.User.Request;
using CL.Web.Background.Pages.Common;
using CL.Biz.Background.User;


namespace CL.Web.Background.Pages.User
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 给控件赋值, 用于创建列表html
            this.Pagnation.InnerQueryData = BindDataSource;
            if (!IsPostBack)
            {
                base.BindDDL(this.ddlAccountStatus, UserAccountStatus.正常);
                base.BindDDL(this.ddlUserType, UserType.代理商);
                base.BindDDL(this.ddlDataSource, DataSourceType.PC端);

                BindDataSource(1);
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataSource(1);
        }

        /// <summary>
        /// 在这里作查询
        /// </summary>
        /// <param name="index">索引号</param>
        public void BindDataSource(Int32 index)
        {
            var request = new GetUserInfoListRequest
            {
                UserName = this.txtUserName.Text.Trim(),
                Mobile = this.txtMobile.Text.Trim(),
                TrueName = this.txtTrueName.Text.Trim(),
                AccountStatus = this.ddlAccountStatus.SelectedValue.ToInt32OrNull(),
                DataSource = this.ddlDataSource.SelectedValue.ToInt32OrNull(),
                UserType = this.ddlUserType.SelectedValue.ToInt32OrNull(),
                RegDateStart = this.txtDateStart.Text.ToDateTimeOrNull(),
                RegDateEnd = this.txtDateEnd.Text.ToMaxOfDay(),
                PageSize = PageUtil.DefaultPageSize,
                PageIndex = index
            };

            var biz = new UserInfoBiz();
            var data = biz.GetUserInfoList(request);

            base.BindList(this.rpt, this.divList, this.lblMsg, data.DataList, data.TotalCount, request.PageIndex, request.PageSize);

            this.Pagnation.hdTotalCount.Value = data.TotalCount.ToString();
        }
        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            new UserInfoBiz();
            if (e.CommandName == "UpdateAccountStatus")
            {
                Response.Write("<script>alert('操作成功！');location.href='UserList.aspx';</script>");
            }
        }
    }
}