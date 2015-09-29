using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.DAL.DataModel.Entities
{
    /// <summary>
    ///(实体类)
    /// </summary>
    [Serializable]
    public class StockInLog
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public StockInLog()
        {
            this.Created = null;
            this.ID = null;
            this.ProductID = null;
            this.SpecID = null;
            this.StockInCount = null;
            this.UserID = null;
        }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///秒杀ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///商品ID
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        ///规格类别编号
        /// </summary>
        public string SpecID { get; set; }

        /// <summary>
        ///入库数量
        /// </summary>
        public int? StockInCount { get; set; }

        /// <summary>
        ///操作人
        /// </summary>
        public string UserID { get; set; }
    }
}
