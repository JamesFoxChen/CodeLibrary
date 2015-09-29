using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Product.Request
{
    public class BrandListRequest
    {

        public BrandListRequest()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 上下架
        /// </summary>
        public int? ShowStatus { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string BrandName { get; set; }

        public int? DataSource { get; set; }
    }
}
