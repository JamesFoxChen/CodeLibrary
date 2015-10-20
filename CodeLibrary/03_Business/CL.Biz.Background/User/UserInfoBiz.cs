using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.CrossDomain.DomainModel.Background.User.Request;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using AutoMapper;
using CL.Biz.Common;
using CL.Framework.Utils;

namespace CL.Biz.Background.User
{
    public class UserInfoBiz
    {
        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <returns></returns>
        public GetUserInfoListResponse GetUserInfoList(GetUserInfoListRequest request)
        {
            try
            {
                var response = new GetUserInfoListResponse();

                var db = new CLDbContext();

                var userInfo = db.UserInfo.AsQueryable();
                if (!string.IsNullOrWhiteSpace(request.UserName))
                {
                    userInfo = userInfo.Where(p => p.UserName.Contains(request.UserName));
                }
                if (!string.IsNullOrWhiteSpace(request.Mobile))
                {
                    userInfo = userInfo.Where(p => p.Mobile.Contains(request.Mobile));
                }
                if (!string.IsNullOrWhiteSpace(request.TrueName))
                {
                    userInfo = userInfo.Where(p => p.TrueName.Contains(request.TrueName));
                }
                if (request.AccountStatus != null)
                {
                    userInfo = userInfo.Where(p => p.AccountStatus == request.AccountStatus);
                }
                if (request.UserType != null)
                {
                    userInfo = userInfo.Where(p => p.UserType == request.UserType);
                }
                if (request.DataSource != null)
                {
                    userInfo = userInfo.Where(p => p.DataSource == request.DataSource);
                }
                if (request.RegDateStart != null)
                {
                    userInfo = userInfo.Where(p => p.Created >= request.RegDateStart);
                }
                if (request.RegDateEnd != null)
                {
                    userInfo = userInfo.Where(p => p.Created <= request.RegDateEnd);
                }

                response.TotalCount = userInfo.Count();
                List<UserInfo> lstUserInfo = userInfo
                                            .OrderByDescending(p => p.Created)
                                            .Skip((request.PageIndex - 1) * request.PageSize)
                                            .Take(request.PageSize)
                                            .ToList();

                response.DataList = Mapper.DynamicMap<List<UserInfo>, List<GetUserInfoResponse>>(lstUserInfo);

                foreach (var item in response.DataList)
                {
                    item.UserTypeDesc = CodeValueUtil.GetUserType(item.UserType);
                    item.AccountStatusDesc = CodeValueUtil.GetUserAccountStatusDesc(item.AccountStatus);
                    item.DataSourceDesc = CodeValueUtil.GetDataSourceTypeDesc(item.DataSource);
                }

                return response;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取用户列表信息(GetUserInfoList)", ex);
                return null;
            }
        }
    }
}
