using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.Invoicing;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Invoicing.Request;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Invoicing
{
    public partial class StockIn : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtProductName.Attributes.Add("readonly", "true");
                this.txtBarCode.Attributes.Add("readonly", "true");
                this.txtStockInCount.Text = "0";
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            var brandInfo = new StockInRequest
            {
                ProductID = this.hdProductID.Value,
                BarCode = this.txtBarCode.Text,
                StockInCount = this.txtStockInCount.Text.ToInt32(),
                UserID = "123"
            };

            var biz = new StockInBiz();
            bool result = biz.StockIn(brandInfo).IsSuccess;
            base.AlertAndRedirectCommon(result, "StockInLog.aspx");
        }
    }
}