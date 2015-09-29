using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Product.Request
{
    public class ProductInfoRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// 显示编号
        /// </summary>
        public String DisplayID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public String ProductName { get; set; }

        /// <summary>
        /// 品牌编号
        /// </summary>
        public String BrandID { get; set; }

        /// <summary>
        /// 默认商品图片
        /// </summary>
        public String DefaultPhotoUrl { get; set; }

        /// <summary>
        /// 商品详细图片
        /// </summary>
        public String PhotoUrl { get; set; }

        /// <summary>
        /// 上下架状态
        /// </summary>
        public Int32? ShowStatus { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32? OrderIndex { get; set; }

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

     }
}
