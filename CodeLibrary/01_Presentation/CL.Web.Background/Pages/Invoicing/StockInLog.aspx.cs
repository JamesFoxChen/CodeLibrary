using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL.Biz.Background.Invoicing;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Invoicing.Request;
using CL.Web.Background.Pages.Common;

namespace CL.Web.Background.Pages.Invoicing
{
    public partial class StockInLog : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 给控件赋值, 用于创建列表html
            this.Pagnation.InnerQueryData = BindDataSource;
            if (!IsPostBack)
            {
                this.txtProductName.Attributes.Add("readonly", "true");
                BindDataSource(1);
            }
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
        /// 在这里作查询
        /// </summary>
        /// <param name="index">索引号</param>
        public void BindDataSource(Int32 index)
        {
            var request = new StockInLogRequest
            {
                ProductID = this.hfProductID.Value.Trim(),
                BarCode = this.txtBarCode.Text.Trim(),
                StockInStart = this.txtDateStart.Text.ToDateTimeOrNull(),
                StockInEnd = this.txtDateEnd.Text.ToMaxOfDay(),
                PageSize = PageUtil.DefaultPageSize,
                PageIndex = index
            };

            var biz = new StockInBiz();
            var data = biz.GetStockInLogList(request);

            base.BindList(this.rpt, this.divList, this.lblMsg, data.DataList, data.TotalCount, request.PageIndex, request.PageSize);

            this.Pagnation.hdTotalCount.Value = data.TotalCount.ToString();
        }
    }
}