using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.DAL.DataModel.Entities
{

    /// <summary>
    /// 用户可用金额流水
    /// </summary>
     [Serializable]
    public class UserMoneyLog
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public UserMoneyLog()
        {
            this.Created = null;
            this.ID = null;
            this.OrderID = null;
            this.Remark = null;
            this.Type = null;
            this.UserID = null;
            this.Value = null;
            this.OperateID = null;
        }

        /// <summary>
        ///编号
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        ///用户编号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        ///余额值
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        ///订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        ///类型
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///操作人编号
        /// </summary>
        public string OperateID { get; set; }
    }
}
