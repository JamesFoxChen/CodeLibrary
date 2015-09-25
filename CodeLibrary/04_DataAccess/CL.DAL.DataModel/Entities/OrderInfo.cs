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
    public class OrderInfo
    {
        /// <summary>
        ///(构造函数)
        /// </summary>
        public OrderInfo()
        {
            this.BlancePrice = null;
            this.CancelDate = null;
            this.CancelReason = null;
            this.CityID = null;
            this.CompleteDate = null;
            this.CompleteStatus = null;
            this.Consigner = null;
            this.ConsignerAddr = null;
            this.ConsignerDate = null;
            this.ConsignerMobile = null;
            this.Created = null;
            this.DataSource = null;
            this.DeliveryDate = null;
            this.DeliveryStatus = null;
            this.DeliveryType = null;
            this.DisplayID = null;
            this.ExpressCompany = null;
            this.ID = null;
            this.IntegralAmount = null;
            this.LocationID = null;
            this.OrderStatus = null;
            this.PayDate = null;
            this.PayPrice = null;
            this.PayStatus = null;
            this.PayType = null;
            this.Postage = null;
            this.ProvinceID = null;
            this.Remark = null;
            this.ReturnApplyDate = null;
            this.ReturnApplyPhotos = null;
            this.ReturnApplyReason = null;
            this.ReturnRefundDate = null;
            this.ReturnRefundReason = null;
            this.ReturnRefundStatus = null;
            this.ReturnRefundUserName = null;
            this.ReturnReplyDate = null;
            this.ReturnReplyReason = null;
            this.ReturnReplyUserName = null;
            this.TotalPrice = null;
            this.TotalWeight = null;
            this.Updated = null;
            this.UserID = null;
            this.UserType = null;
            this.WayBill = null;
        }

        /// <summary>
        ///ID
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        ///余额抵扣金额
        /// </summary>
        public string BlancePrice { get; set; }

        /// <summary>
        ///退货时间
        /// </summary>
        public DateTime? CancelDate { get; set; }

        /// <summary>
        ///取消原因
        /// </summary>
        public string CancelReason { get; set; }

        /// <summary>
        ///城市编号
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        ///完成时间
        /// </summary>
        public DateTime? CompleteDate { get; set; }

        /// <summary>
        ///完成状态
        /// </summary>
        public int? CompleteStatus { get; set; }

        /// <summary>
        ///收货人
        /// </summary>
        public string Consigner { get; set; }

        /// <summary>
        ///收货人地址
        /// </summary>
        public string ConsignerAddr { get; set; }

        /// <summary>
        ///收货时间
        /// </summary>
        public DateTime? ConsignerDate { get; set; }

        /// <summary>
        ///收货人手机号
        /// </summary>
        public string ConsignerMobile { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        ///数据来源
        /// </summary>
        public int? DataSource { get; set; }

        /// <summary>
        ///配送时间
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        ///配送状态
        /// </summary>
        public int? DeliveryStatus { get; set; }

        /// <summary>
        ///配送方式
        /// </summary>
        public int? DeliveryType { get; set; }

        /// <summary>
        ///显示编号
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        ///快递公司
        /// </summary>
        public string ExpressCompany { get; set; }

    

        /// <summary>
        ///积分抵扣值
        /// </summary>
        public string IntegralAmount { get; set; }

        /// <summary>
        ///位置编号
        /// </summary>
        public int? LocationID { get; set; }

        /// <summary>
        ///订单状态
        /// </summary>
        public int? OrderStatus { get; set; }

        /// <summary>
        ///支付时间
        /// </summary>
        public DateTime? PayDate { get; set; }

        /// <summary>
        ///总金额实付金额
        /// </summary>
        public string PayPrice { get; set; }

        /// <summary>
        ///支付状态
        /// </summary>
        public int? PayStatus { get; set; }

        /// <summary>
        ///支付方式
        /// </summary>
        public int? PayType { get; set; }

        /// <summary>
        ///邮费
        /// </summary>
        public string Postage { get; set; }

        /// <summary>
        ///省份编号
        /// </summary>
        public int? ProvinceID { get; set; }

        /// <summary>
        ///订单备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        ///退货申请时间
        /// </summary>
        public DateTime? ReturnApplyDate { get; set; }

        /// <summary>
        ///退货申请图片
        /// </summary>
        public string ReturnApplyPhotos { get; set; }

        /// <summary>
        ///退货申请原因
        /// </summary>
        public string ReturnApplyReason { get; set; }

        /// <summary>
        ///退货退款时间
        /// </summary>
        public DateTime? ReturnRefundDate { get; set; }

        /// <summary>
        ///退货退款原因
        /// </summary>
        public string ReturnRefundReason { get; set; }

        /// <summary>
        ///退货退款状态
        /// </summary>
        public int? ReturnRefundStatus { get; set; }

        /// <summary>
        ///退货退款人
        /// </summary>
        public string ReturnRefundUserName { get; set; }

        /// <summary>
        ///退货回复时间
        /// </summary>
        public DateTime? ReturnReplyDate { get; set; }

        /// <summary>
        ///退货回复原因
        /// </summary>
        public string ReturnReplyReason { get; set; }

        /// <summary>
        ///退货回复人
        /// </summary>
        public string ReturnReplyUserName { get; set; }

        /// <summary>
        ///总金额
        /// </summary>
        public string TotalPrice { get; set; }

        /// <summary>
        ///总重量
        /// </summary>
        public int? TotalWeight { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        ///用户编号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        ///用户类型
        /// </summary>
        public int? UserType { get; set; }

        /// <summary>
        ///运单号
        /// </summary>
        public string WayBill { get; set; }
    }
}
