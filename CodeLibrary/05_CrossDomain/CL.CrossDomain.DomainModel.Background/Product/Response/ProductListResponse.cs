using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Product.Response
{
    public class ProductListResponse
    {
        public List<ProductListInfoResponse> DataList { get; set; }
        public int TotalCount { get; set; }
    }

    public class ProductListInfoResponse
    {
        /// <summary>
        /// ID
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public String BrandName { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public String ProductName { get; set; }

        /// <summary>
        /// 上下架状态
        /// </summary>
        public Int32? ShowStatus { get; set; }

        /// <summary>
        /// 上下架状态描述
        /// </summary>
        public String ShowStatusDesc { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32? OrderIndex { get; set; }

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal? MarketPrice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public decimal? SalesPrice { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        public Int32? DataSource { get; set; }

        /// <summary>
        /// 数据来源描述
        /// </summary>
        public string DataSourceDesc { get; set; }


        /// <summary>
        /// 显示编号
        /// </summary>
        public string DisplayID { get; set; }
    }
}
