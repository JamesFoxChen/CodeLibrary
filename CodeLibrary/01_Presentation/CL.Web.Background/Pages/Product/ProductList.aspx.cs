using System;
using System.Web.UI.WebControls;
using CL.Biz.Background.Product;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Product
{
    public partial class ProductList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Pagnation.InnerQueryData = BindDataSource;
            if (!IsPostBack)
            {
                base.BindDDL(this.ddlShowStatus, ShowStatus.上架);
                base.BindDDL(this.ddlDataSource, DataSourceType.PC端);
                BindDataSource(1);
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataSource(1);
        }

        public void BindDataSource(Int32 index)
        {
            var request = new ProductListRequest
            {
                PageIndex = index,
                PageSize = PageUtil.DefaultPageSize,
                ShowStatus = this.ddlShowStatus.SelectedValue.ToInt32OrNull(),
                DataSource = this.ddlDataSource.SelectedValue.ToInt32OrNull(),
                ProductName = txtProductName.Text
            };

            var biz = new ProductInfoBiz();
            var data = biz.GetProductList(request);

            base.BindList(this.rpt, this.divList, this.lblMsg, data.DataList, data.TotalCount, request.PageIndex, request.PageSize);
            this.Pagnation.hdTotalCount.Value = data.TotalCount.ToString();
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var biz = new ProductInfoBiz();
                bool result = biz.DeleteProductInfo(e.CommandArgument.ToString()).IsSuccess;
                base.AlertAndRedirectCommon(result, "ProductList.aspx");
            }
            BindDataSource(1);
        }
    }
}