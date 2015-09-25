using System;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Common;


namespace CL.Services.WCF
{
    /// <summary>
    /// 新增收货信息接口 -业务逻辑
    /// </summary>
    public class AddReceiptExe : ExeBase
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
                return ResponseEntityToData(EnumResultId.ExceptionOrNoData, ConstantBLLUtil.Error_RequestEntityBaseNull);
            }

            try
            {
                var request = ent as AddReceiptRequest; //获取请求参数实体类
                request.CID = ConstantBLLUtil.CID;

                if (IsRequestDataEmpty(request.UserStateId, request.AppType, request.PhoneType
                    , request.IsFlag, request.ProvinceId, request.CityId, request.RegionId, request.LinkAddress, request.LinkMan, request.LinkMobile))
                {
                    return ResponseEntityToData(EnumResultId.ExceptionOrNoData, ConstantBLLUtil.Error_RequestDataRequired);
                }

                UrlDecode(request);

                //验证用户串
                UserInfoCache userInfoCache = UserCacheBase.VerifyUserInfo(request.UserStateId);
                if (userInfoCache == null)
                {
                    return ResponseEntityToData(EnumResultId.TimeOutOrVerifyFailure,ConstantBLLUtil.Error_TimeOutOrVerifyFailure);
                }

                if (!Regex.IsMatch(request.LinkMobile, @"^(13[0-9]|145|147|15[0-3]|15[5-9]|18[0-9])[0-9]{8}$"))
                {
                    return ResponseEntityToData(EnumResultId.D4, "手机号码格式不符合要求");
                }

                if (!Regex.IsMatch(request.ProvinceId, @"^\d{2}$"))
                {
                    return ResponseEntityToData(EnumResultId.D4, "省份编号不符合要求");
                }

                if (!Regex.IsMatch(request.CityId, @"^\d{3}$"))
                {
                    return ResponseEntityToData(EnumResultId.D4, "城市编号不符合要求");
                }

                if (!checkLength(request.LinkAddress, 100))
                {
                    return ResponseEntityToData(EnumResultId.D4, "收货地址超长");
                }

                if (!checkLength(request.LinkMan, 50))
                {
                    return ResponseEntityToData(EnumResultId.D4, "收货联系人超长");
                }

                if (!string.IsNullOrWhiteSpace(request.LinkPost) && !Regex.IsMatch(request.LinkPost, @"^[0-9]{6}$"))
                {
                    return ResponseEntityToData(EnumResultId.D4, "邮编不符合要求");
                }

                if (!string.IsNullOrWhiteSpace(request.LinkTel) && !checkLength(request.LinkTel, 20))
                {
                    return ResponseEntityToData(EnumResultId.D4, "联系电话不符合要求");
                }

                //var model = null;

                //model.CID = request.CID;
                //model.CustomerId = userInfoCache.CustomerId;

                DataTable dt = new DataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count >= 20)
                    {
                        return ResponseEntityToData(EnumResultId.D5, "最多保存20个有效地址");
                    }
                    else
                    {
                        //model.LinkId = (Convert.ToInt32(dt.Rows[0]["LinkId"].ToString()) + 1).ToString();
                    }
                }
                else
                {
                    //model.LinkId = userInfoCache.CustomerId + "01";
                }
                //model.LinkType = 0;
                //model.IsFlag = request.IsFlag.ToInt32OrNull();

                int? i = 0;

                //1、如果IsFlag为1（默认），则调用修改其它收货地址为非默认的方法（企业编号+会员编号）
                //2、如果IsFlag为0（非默认），则直接新增
                if (request.IsFlag == "1")
                {
                    //var upModel = new ();
                    //upModel.CID = request.CID;
                    //upModel.CustomerId = userInfoCache.CustomerId;
                    //upModel.IsFlag = 0;
                    //i = db.AddReceiptWithDefault(upModel, model);
                }
                else
                {
                    //i = db.Insert(model);
                }

                if (i > 0)
                {
                    var responseEnt = getResponseEntity("");
                    return ResponseEntityToData(EnumResultId.Success, "成功", responseEnt);
                }
                else
                {
                    return ResponseEntityToData(EnumResultId.ExceptionOrNoData, "添加失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseEntityToData(EnumResultId.ExceptionOrNoData, ex.Message);
            }
        }

        public override RequestEntityBase RequestDataToEntity(string requestData)
        {
            var requestEntity = JsonConvert.DeserializeObject<AddReceiptRequest>(requestData);

            //请求值进行过滤

            return requestEntity;
        }

        public override string ResponseEntityToData(EnumResultId resultId, string resultMsg = "", ResponseEntityBase resposeBase = null)
        {
            AddReceiptResponse response = null;
            if (resposeBase == null)
            {
                response = new AddReceiptResponse();
            }
            else
            {
                response = resposeBase as AddReceiptResponse;
            }

            response.ResultId = resultId.GetHashCode().ToString();
            response.ResultMsg = resultMsg.UrlEncoding();

            LogMsg(resultId, resultMsg, ConstantBLLUtil.LogTypeMain);

            return ToJson<AddReceiptResponse>(response);
        }
        #endregion

        #region 业务逻辑
        /// <summary>
        /// 将逻辑处理结果转换为响应实体类
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private AddReceiptResponse getResponseEntity(string linkId)
        {
            var response = new AddReceiptResponse
            {
                ResultId = EnumResultId.Success.GetHashCode().ToString(),
                LinkId = linkId
            };

            return response;
        }

        // 校验字符串最大长度
        private bool checkLength(string value, int maxLength)
        {
            int length = Encoding.Default.GetByteCount(value);
            if (length > maxLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="ent"></param>
        protected override void UrlDecode(RequestEntityBase ent)
        {
            var request = ent as AddReceiptRequest;

            request.LinkAddress = request.LinkAddress.UrlDecoding();
            request.LinkMan = request.LinkMan.UrlDecoding();
        }
        #endregion
    }
}
