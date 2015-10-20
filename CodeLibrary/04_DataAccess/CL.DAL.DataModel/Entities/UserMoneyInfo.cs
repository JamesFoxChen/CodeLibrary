using System;
using System.ComponentModel.DataAnnotations;

namespace CL.DAL.DataModel.Entities
{

    /// <summary>
    /// 用户可用金额信息
    /// </summary>
     [Serializable]
    public class UserMoneyInfo
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public UserMoneyInfo()
        {
            this.ID = null;
            this.Updated = null;
            this.Value = null;
        }

        /// <summary>
        ///编号
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        ///值
        /// </summary>
        public decimal? Value { get; set; }
    }
}
