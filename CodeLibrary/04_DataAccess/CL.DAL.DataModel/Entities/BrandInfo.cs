using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    ///(实体类)
    /// </summary>
    [Serializable]
    public class BrandInfo
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public BrandInfo()
        {
            this.BrandName = null;
            this.Company = null;
            this.Created = null;
            this.DataSource = null;
            this.ID = null;
            this.Introduce = null;
            this.LogoImage = null;
            this.OrderIndex = null;
            this.Phone = null;
            this.ShowStatus = null;
            this.Updated = null;
        }

        /// <summary>
        ///ID
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        ///品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        ///所属公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///数据来源
        /// </summary>
        public int? DataSource { get; set; }

        /// <summary>
        ///品牌介绍
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        ///图片Logo
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        ///序号
        /// </summary>
        public int? OrderIndex { get; set; }

        /// <summary>
        ///电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///上下架状态
        /// </summary>
        public int? ShowStatus { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? Updated { get; set; }
    }
}
