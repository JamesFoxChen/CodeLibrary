using System;
using System.Data;
using System.Web.UI.WebControls;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.User.Request;
using CL.Web.Background.Pages.Common;
using CL.Biz.Background.User;
using CL.Plugin.Excel;


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

        private GetUserInfoListRequest getQueryModel(int? index = null)
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
            };

            if (index != null)
            {
                request.PageSize = PageUtil.DefaultPageSize;
                request.PageIndex = index.Value;
            }
            return request;
        }

        public void BindDataSource(int index)
        {
            var request = this.getQueryModel(index);
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var request = this.getQueryModel(1);
            var biz = new UserInfoBiz();
            var data = biz.GetUserInfoList(request);

            var dt = new DataTable();
            dt.Columns.Add("会员名");
            dt.Columns.Add("用户类型");
            dt.Columns.Add("注册时间");

            foreach (var item in data.DataList)
            {
                dt.Rows.Add(new object[]
                    {
                        item.UserName,
                        item.UserTypeDesc,
                        item.Created.ToString()
                    });
            }

            ExcelHelper eh = new ExcelHelper();
            eh.FillDataNew("用户信息", dt, "用户信息", true);
            eh.ExportExcelFile("用户信息");
        }
    }
}