using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Biz.Common;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;

namespace CL.Plugin.Sms
{
    public class SmSend
    {
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public static bool SendVerifyCode(string mobile)
        {
            try
            {
                //1、发送短信(验证码随机生成4位数字）
                Random Rdm = new Random();
                int iRdm = Rdm.Next(1000, 9999);

                string[] Content = { iRdm.ToString() };

                bool result = SmsMngInner.Sendcode(mobile, SmsConstant.VerifyCodeModuleID, Content); //3、短信流水写入SendSmsLog表

                //2、手机、验证码信息写入UserVerifyCode表
                var db = new CLDbContext();
                var info = new SmsVerifyCode();
                info.ID = StringUtil.GetGUID();
                info.Mobile = mobile;
                info.Code = iRdm.ToString();
                info.IsVeify = YesNo.否.GetHashCode();
                info.Created = DateTime.Now;
                info.DueDate = DateTime.Now.AddSeconds(Constant.SmsExpiredTime);
                db.SmsVerifyCode.Add(info);
                return db.SaveChanges() > 0 && result;
            }
            catch (Exception ex)
            {
                TextLogUtil.Error("发送验证码(SendVerifyCode)\r\nMsg：" + ex.Message + "\r\nStack：" + ex.StackTrace);
                return false;
            }
            return true;

        }

        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="orderId">订单号</param>
        /// <param name="billWay">运单号</param>
        /// <returns></returns>
        public static bool DeliverGoods(string mobile, string orderId, string billWay)
        {
            try
            {
                string[] Content = { orderId, billWay };
                SmsMngInner.Sendcode(mobile, SmsConstant.DeliverGoodsModuleID, Content); //3、短信流水写入SendSmsLog表
                //1、发送短信
            }
            catch (Exception ex)
            {
                TextLogUtil.Error("发货(DeliverGoods)\r\nMsg：" + ex.Message + "\r\nStack：" + ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
