using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Product.Request
{
    public class BrandInfoRequest
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
        /// 图片Logo
        /// </summary>
        public String LogoImage { get; set; }

        /// <summary>
        /// 上下架状态
        /// </summary>
        public Int32? ShowStatus { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// 品牌介绍
        /// </summary>
        public String Introduce { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public String Company { get; set; }

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
