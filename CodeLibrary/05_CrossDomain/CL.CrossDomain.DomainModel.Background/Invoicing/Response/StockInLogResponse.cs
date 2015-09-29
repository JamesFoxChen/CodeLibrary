using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Invoicing.Response
{
    public class StockInLogListResponse
    {
        public List<StockInLogListInfoResposne> DataList { get; set; }

        public int TotalCount { get; set; }
    }

    /// <summary>
    /// 入库返回详细信息
    /// </summary>
    public class StockInLogListInfoResposne
    {
        /// <summary>
        /// ID
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// 显示编号
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 规格编号
        /// </summary>
        public string SpecID { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int? StockInCount { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public String BarCode { get; set; }

        /// <summary>
        /// 操作人编码
        /// </summary>
        public String UserID { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? Created { get; set; }
    }
}
