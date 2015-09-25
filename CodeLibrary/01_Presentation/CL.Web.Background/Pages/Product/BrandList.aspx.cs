using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.Product;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Product
{
    public partial class BrandList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 给控件赋值, 用于创建列表html
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
            var request = new BrandListRequest
            {
                PageIndex = index,
                PageSize = PageUtil.DefaultPageSize,
                ShowStatus = this.ddlShowStatus.SelectedValue.ToInt32OrNull(),
                DataSource = this.ddlDataSource.SelectedValue.ToInt32OrNull(),
                BrandName = txtBrandName.Text
            };

            BrandInfoBiz brandInfoBiz = new BrandInfoBiz();
            var data = brandInfoBiz.GetBrandList(request);

            base.BindList(this.rpt, this.divList, this.lblMsg, data.DataList, data.TotalCount, request.PageIndex, request.PageSize);
            this.Pagnation.hdTotalCount.Value = data.TotalCount.ToString();
        }

        protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //var ProductInfoPopularBiz = new ProductInfoPopularBiz();
            //if (e.CommandName == "Delete")
            //{
            //    BrandInfoBiz brandInfoBiz = new BrandInfoBiz();
            //    //删除
            //    int response = brandInfoBiz.DeleteBrand(e.CommandArgument.ToString(), base.CurrentAdminInfo.ID, base.CurrentAdminInfo.AdminName);
            //    if (response == 0)
            //        Response.Write("<script>alert('已关联商品的品牌不能删除！');</script>");
            //}
            //BindDataSource(1);
        }
    }
}