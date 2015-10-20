using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.CrossDomain.DomainModel.Background.Base;

namespace CL.CrossDomain.DomainModel.Background.Other.Request
{
    public class MPollImagesRequest : RequestBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 业务编号
        /// </summary>
        public int? BizID { get; set; }

        /// <summary>
        /// 图片编号
        /// </summary>
        public String ImageID { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public String ImageLink { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int? OrderIndex { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updated { get; set; }
    }
}
