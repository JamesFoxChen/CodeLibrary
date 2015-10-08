
using System;
using CL.Biz.Common;

namespace CL.Web.Background
{
    /// <summary>
    /// 翻页控件
    /// </summary>
    public partial class Pagnation : System.Web.UI.UserControl
    {
        /// <summary>
        /// 每页大小
        /// </summary>
        public int DefaultPageSize = PageUtil.DefaultPageSize;

        /// <summary>
        /// 查询回调
        /// </summary>
        public Action<Int32> InnerQueryData { get; set; }

        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hdCurrentPageIndex.Value = Request[this.hdCurrentPageIndex.Name] ?? "1";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            InnerQueryData(1);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.hdCurrentPageIndex.Value = 1.ToString();
            InnerQueryData(1);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            int pageIndex = Convert.ToInt32(this.hdCurrentPageIndex.Value);
            if (pageIndex > 1) pageIndex--;
            this.hdCurrentPageIndex.Value = pageIndex.ToString();

            InnerQueryData(pageIndex);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            int iRecordCount = Convert.ToInt32(this.hdTotalCount.Value);
            int length = iRecordCount % DefaultPageSize > 0 ? iRecordCount / DefaultPageSize + 1 : iRecordCount / DefaultPageSize;
            int pageIndex = Convert.ToInt32(this.hdCurrentPageIndex.Value);
            if (pageIndex < length) pageIndex++;
            this.hdCurrentPageIndex.Value = pageIndex.ToString();
            InnerQueryData(pageIndex);
        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            int iRecordCount = Convert.ToInt32(this.hdTotalCount.Value);
            int length = iRecordCount % DefaultPageSize > 0 ? iRecordCount / DefaultPageSize + 1 : iRecordCount / DefaultPageSize;
            this.hdCurrentPageIndex.Value = length.ToString();
            InnerQueryData(length);
        }
    }
}