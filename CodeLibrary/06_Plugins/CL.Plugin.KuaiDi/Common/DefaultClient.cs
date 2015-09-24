using System;
using System.Collections.Generic;
using CL.Framework.Utils.Http;
using CL.Framework.Utils.Security;

namespace CL.Plugin.KuaiDi.Common
{
    /// <summary>
    /// 电子面单标准客户端
    /// </summary>

    public class DefaultClient : IClient
    {
        private string endpoint;

        private string partnerID;

        private string partnerKey;

        private static string PARTNER_ID = "parternID";
        private static string BIZ_DATA = "bizData";
        private static string DIGEST = "digest";

        #region Constructor
        public DefaultClient(string endpoint, string partnerID, string partnerKey) 
        {
            this.endpoint = endpoint;
            this.partnerID = partnerID;
            this.partnerKey = partnerKey;
        }
        #endregion

        public IResponse DoExecute(IRequest ebillRequest)
        {
            PrepareSign(ebillRequest);
            if (ebillRequest.Check())
            {
                string responseContent = HttpPostUtil.DoPost(endpoint, ebillRequest.Params);
                IResponse response = (IResponse)ebillRequest.ResponseType.GetConstructor(new Type[] { typeof(string) }).Invoke(new Object[] { responseContent });
                return response;
            }
            else
            {
                throw new Exception("\u53c2\u6570\u4e0d\u5b8c\u6574");
            }
        }

        private void PrepareSign(IRequest ebillRequest)
        {
            ebillRequest.Params.Add(PARTNER_ID, partnerID);
            ebillRequest.Params.Add(DIGEST, MD5Util.GetMd5(ebillRequest.Params[BIZ_DATA] + partnerKey));
        }

        public Sdk.BizData.Response.TraceLogsListType queryBillStatus(string mailNos)
        {
            IDictionary<string, string> requestParams = new Dictionary<string, string>();
            requestParams.Add("serviceType", "RequestQuery");
            requestParams.Add("parternID", partnerID);
            requestParams.Add(DIGEST, MD5Util.GetMd5(mailNos + partnerKey));
            requestParams.Add("mailNo", mailNos);

            string responseContent = HttpPostUtil.DoPost(endpoint, requestParams);
            Sdk.BizData.Response.TraceLogsListType result = Sdk.BizData.Response.TraceLogsListType.Deserialize(responseContent);
            
            return result;
        }

    }
}
