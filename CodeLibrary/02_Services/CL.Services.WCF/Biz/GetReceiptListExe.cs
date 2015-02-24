using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using CL.CrossDomain.DomainModel;
using CL.CrossDomain.Common;

namespace CL.Services.WCF
{
    /// <summary>
    /// 获取收货信息列表接口 -业务逻辑
    /// </summary>
    public class GetReceiptListExe : ExeBase
    {
        #region 通用逻辑
        /// <summary>
        /// 执行业务逻辑
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public override string Execute(RequestEntityBase ent)
        {
            //输入数据转换对应实体类失败
            if (ent == null)
            {
                return ResponseEntityToData(Enum_ResultId.ExceptionOrNoData, ConstantBLLUtil.Error_RequestEntityBaseNull);
            }

            try
            {
                var request = ent as GetReceiptListRequest; //获取请求参数实体类
                //request.CID = ConstantBLLUtil.CID;

                if (IsRequestDataEmpty(request.UserStateId, request.AppType, request.PhoneType, request.IsGetAll))
                {
                    return ResponseEntityToData(Enum_ResultId.ExceptionOrNoData, ConstantBLLUtil.Error_RequestDataRequired);
                }

                UrlDecode(request);

                //验证用户串
                UserInfoCache userInfoCache = UserCacheBase.VerifyUserInfo(request.UserStateId);
                if (userInfoCache == null)
                {
                    return ResponseEntityToData(Enum_ResultId.TimeOutOrVerifyFailure, ConstantBLLUtil.Error_TimeOutOrVerifyFailure);
                }

                return ResponseEntityToData(Enum_ResultId.Success, "", getResponseEntity(request, userInfoCache.CustomerId));
            }
            catch (Exception ex)
            {
                return ResponseEntityToData(Enum_ResultId.ExceptionOrNoData, ex.Message);
            }
        }

        public override RequestEntityBase RequestDataToEntity(string requestData)
        {
            var requestEntity = JsonConvert.DeserializeObject<GetReceiptListRequest>(requestData);

            //请求值进行过滤

            return requestEntity;
        }

        public override string ResponseEntityToData(Enum_ResultId resultId, string resultMsg = "", ResponseEntityBase resposeBase = null)
        {
            GetReceiptListResponse response = null;
            if (resposeBase == null)
            {
                response = new GetReceiptListResponse();
            }
            else
            {
                response = resposeBase as GetReceiptListResponse;
            }

            response.ResultId = resultId.GetHashCode().ToString();
            response.ResultMsg = resultMsg.UrlEncoding();

            LogMsg(resultId, resultMsg, ConstantBLLUtil.LogTypeMain, Enum_ServiceType.GetReceiptList);

            return ToJson<GetReceiptListResponse>(response);
        }
        #endregion

        #region 业务逻辑
        /// <summary>
        /// 将逻辑处理结果转换为响应实体类
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private GetReceiptListResponse getResponseEntity(GetReceiptListRequest request, int? customerId)
        {
            //var model = new 
            //{
            //    CID = request.CID,
            //    CustomerId = customerId
            //};
            //var list = new Pan_CustLinkInfoDb().GetModelList(model).OrderByDescending(p => p.IsFlag).ToList();

            var listResponseData = new List<GetReceiptListDataResponse>();

            //if (list.Count() > 0)  //有收获地址信息
            //{
            //    if (request.IsGetAll == "1")  //获取所有地址信息，并按默认-->非默认排序
            //    {
            //        foreach (var item in list)
            //        {
            //            listResponseData.Add(getResonseData(item));
            //        }
            //    }
            //    else   //只显示默认信息或无默认地址时则按【信息编号】升序获取第一条地址
            //    {
            //        var item = list.First<>();
            //        listResponseData.Add(getResonseData(item));
            //    }
            //}

            return new GetReceiptListResponse
            {
                Data = listResponseData
            };
        }

        private GetReceiptListDataResponse getResonseData(object item)
        {
            //return new GetReceiptListDataResponse
            //                           {
            //                               LinkId = item.LinkId,
            //                               ProvinceId = item.ProvinceId,
            //                               LinkTel = item.LinkTel
            //                           };

            return null;

        }
        #endregion
    }
}
