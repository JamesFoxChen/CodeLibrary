using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.CrossDomain.DomainModel.Background.User.Request;
using CL.CrossDomain.DomainModel.Background.User.Response;
using CL.CrossDomain.DomainModel.Common;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;

namespace CL.Biz.Background.User
{
    public class UserMoneyBiz
    {
        /// <summary>
        /// 获取用户余额
        /// </summary>
        /// <returns></returns>
        public UserMoneyInfoResponse GetUserMoneyInfo(UserMoneyInfoRequest request)
        {
            var db = new CLDbContext();

            //获取用户余额
            var result = from ue in db.UserMoneyInfo
                         join ui in db.UserInfo
                         on ue.ID equals ui.ID
                         where ui.UserName == request.UserName || ui.Mobile == request.Mobile
                         select new UserMoneyInfoResponse
                         {
                             UserName = ui.UserName,
                             UserID = ui.ID,
                             Mobile = ui.Mobile,
                             Value = ue.Value.Value
                         };

            var response = result.FirstOrDefault();
            if (response == null)
                return new UserMoneyInfoResponse();

            return response;
        }

        /// <summary>
        /// 获取用户余额详细
        /// </summary>
        /// <returns></returns>
        public List<UserMoneyLogResponse> GetUserMoneyLog(string userId, int pageIndex, int pageSize, ref int totalCount)
        {
            var response = new List<UserMoneyLogResponse>();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return response;
            }

            try
            {
                var db = new CLDbContext();
                var result = from ue in db.UserMoneyLog
                             join ui in db.UserInfo
                             on ue.UserID equals ui.ID into emp
                             from ui in emp.DefaultIfEmpty()
                             where ue.UserID == userId
                             orderby ue.Created descending
                             select new UserMoneyLogResponse
                             {
                                 Value = ue.Value,
                                 UserID = ue.UserID,
                                 UserName = ui.UserName,
                                 OrderID = ue.OrderID,
                                 Created = ue.Created,
                                 Type = ue.Type,
                                 Remark = ue.Remark
                             };

                totalCount = result.Count();
                return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                string msg = "获取用户余额详细(GetUserMoneyLog)\r\nMsg：" + ex.Message + "\r\nStack：" + ex.StackTrace;
                TextLogUtil.ErrorWithException(msg, ex);
                return null;
            }
        }


        /// <summary>
        /// 更新用户余额
        /// </summary>
        /// <returns></returns>
        public ResponseInfo UpdateUserMoneyInfo(UpdateUserMoneyInfoRequest request)
        {
            var db = new CLDbContext();
            var info = db.UserMoneyInfo.First(p => p.ID == request.ID);
            info.Value += request.Value;
            info.Updated = DateTime.Now;

            db.UserMoneyLog.Add(new UserMoneyLog
            {
                ID = StringUtil.GetGUID(),
                UserID = request.ID,
                Value = request.Value,
                Type = request.Type,
                OperateID = request.OperateID,
                Created = DateTime.Now,
                Remark = "后台修改金额"
            });

            int i = db.SaveChanges();

            return new ResponseInfo
            {
                IsSuccess = i > 0
            };
        }
    }
}
