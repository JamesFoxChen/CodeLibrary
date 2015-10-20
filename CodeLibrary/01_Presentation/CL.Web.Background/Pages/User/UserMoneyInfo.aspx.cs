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
    public partial class UserMoneyInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Pagnation.InnerQueryData = BindDataSource;
        }

        /// <summary>
        /// 页面上的查询按钮(不用修改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataSource(1);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="index">索引号</param>
        public void BindDataSource(Int32 index)
        {
            var request = new UserMoneyInfoRequest
            {
                UserName = this.txtUserName.Text.Trim(),
                Mobile = this.txtMobile.Text.Trim(),
                PageSize = PageUtil.DefaultPageSize,
                PageIndex = index
            };

            var biz = new UserMoneyBiz();
            var info = biz.GetUserMoneyInfo(request);
            this.lblUserName.Text = info.UserName;
            this.lblMobile.Text = info.Mobile;
            this.lblTotalValue.Text = info.Value.ToString();

            int totalCount = 0;
            var data = biz.GetUserMoneyLog(info.UserID, request.PageIndex, request.PageSize, ref totalCount);

            base.BindList(this.rpt, this.divList, this.lblMsg, data, totalCount, request.PageIndex, request.PageSize);

            this.Pagnation.hdTotalCount.Value = totalCount.ToString();
        }
    }
}