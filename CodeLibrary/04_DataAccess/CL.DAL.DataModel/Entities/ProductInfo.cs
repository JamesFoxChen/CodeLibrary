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
    public class ProductInfo
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public ProductInfo()
        {
            this.BarCode = null;
            this.BrandID = null;
            this.Created = null;
            this.DataSource = null;
            this.DefaultPhotoUrl = null;
            this.DisplayID = null;
            this.ID = null;
            this.Integral = null;
            this.MarketPrice = null;
            this.OrderIndex = null;
            this.PhotoUrl = null;
            this.ProductDesc = null;
            this.ProductName = null;
            this.ProductNote = null;
            this.SalesPrice = null;
            this.SellCount = null;
            this.ShowStatus = null;
            this.StorageCount = null;
            this.Updated = null;
            this.Weight = null;
        }

        /// <summary>
        ///商品ID
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        ///条形码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        ///品牌编号
        /// </summary>
        public string BrandID { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///数据来源
        /// </summary>
        public int? DataSource { get; set; }

        /// <summary>
        ///商品默认图片
        /// </summary>
        public string DefaultPhotoUrl { get; set; }

        /// <summary>
        ///显示编号
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        ///积分
        /// </summary>
        public decimal? Integral { get; set; }

        /// <summary>
        ///市场价
        /// </summary>
        public decimal? MarketPrice { get; set; }

        /// <summary>
        ///序号
        /// </summary>
        public int? OrderIndex { get; set; }

        /// <summary>
        ///商品图片
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        ///商品描述
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        ///商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///商品说明
        /// </summary>
        public string ProductNote { get; set; }

        /// <summary>
        ///销售价
        /// </summary>
        public decimal? SalesPrice { get; set; }

        /// <summary>
        ///销售数量
        /// </summary>
        public int? SellCount { get; set; }


        /// <summary>
        ///上架状态
        /// </summary>
        public int? ShowStatus { get; set; }

        /// <summary>
        ///库存数量
        /// </summary>
        public int? StorageCount { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        ///净重
        /// </summary>
        public int? Weight { get; set; }
    }
}
