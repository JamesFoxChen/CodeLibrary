using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CL.Biz.Background.Product;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;

namespace CL.Web.Background.Pages.Common
{
    public partial class ProductListQuery : AuthLoginPage
    {
        public String PaginationHtml;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 给控件赋值, 用于创建列表html
            this.Pagnation.InnerQueryData = BindDataSource;
            if (!IsPostBack)
            {
                BindDDL(this.ddlShowStatus, ShowStatus.上架);
                BindDataSource(1);
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataSource(1);
        }

        void BindDataSource(Int32 index)
        {
            var request = new ProductListRequest
            {
                PageIndex = index,
                PageSize = PageUtil.DefaultPageSize,
                ShowStatus = this.ddlShowStatus.SelectedValue.ToInt32OrNull(),
                DisplayID = this.txtDisplayID.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                CreatedStartDate = this.txtCreatedStartDate.Text.ToDateTimeOrNull(),
                CreatedEndDate = this.txtCreatedEndDate.Text.ToMaxOfDay()
            };
            var biz = new ProductInfoBiz();
            var data = biz.GetProductList(request);
            BindList(this.rpt, this.divList, this.lblMsg, data.DataList, data.TotalCount, request.PageIndex, request.PageSize);

            this.Pagnation.hdTotalCount.Value = data.TotalCount.ToString();
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
    }
}