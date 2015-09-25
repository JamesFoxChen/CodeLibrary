using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    ///(实体类)
    /// </summary>
    [Serializable]
    public class OrderProductInfo
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public OrderProductInfo()
        {
            this.CommentStatus = null;
            this.Created = null;
            this.DataSource = null;
            this.Integral = null;
            this.MarketPrice = null;
            this.OrderID = null;
            this.ProductID = null;
            this.ProductName = null;
            this.PurchaseNum = null;
            this.SalesPrice = null;
            this.SpecID = null;
            this.SpecName = null;
            this.Type = null;
            this.Updated = null;
        }


        /// <summary>
        ///订单编号
        /// </summary>
        [Key, Column(Order = 1)]
        public string OrderID { get; set; }

        /// <summary>
        ///商品ID
        /// </summary>
        [Key, Column(Order = 2)]
        public string ProductID { get; set; }


        /// <summary>
        ///规格编号
        /// </summary>
        [Key, Column(Order = 3)]
        public string SpecID { get; set; }


        /// <summary>
        ///评价状态
        /// </summary>
        public int? CommentStatus { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///数据来源
        /// </summary>
        public int? DataSource { get; set; }

        /// <summary>
        ///积分
        /// </summary>
        public int? Integral { get; set; }

        /// <summary>
        ///市场价
        /// </summary>
        public string MarketPrice { get; set; }


        /// <summary>
        ///商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///购买数量
        /// </summary>
        public int? PurchaseNum { get; set; }

        /// <summary>
        ///销售价
        /// </summary>
        public string SalesPrice { get; set; }

        /// <summary>
        ///规格名称
        /// </summary>
        public string SpecName { get; set; }

        /// <summary>
        ///类型（普通、秒杀、预定）
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? Updated { get; set; }
    }
}
