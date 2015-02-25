using System.IO;
using System.ServiceModel.Web;
using System;
using System.Reflection;
using System.Web;
using CL.CrossDomain.DomainModel;
using CL.Framework.Utils;


namespace CL.Services.WCF
{
    public class BaseService
    {
        /// 获取请求参数-->处理逻辑-->返回响应流
        /// </summary>
        /// <typeparam name="R">请求参数实体类</typeparam>
        /// <typeparam name="E">执行业务逻辑类</typeparam>
        /// <param name="data">请求数据</param>
        /// <param name="request">请求流</param>
        /// <returns></returns>
        protected Stream Execute<E>(Stream request, string data = "")
            where E : ExeBase, new()
        {
            try
            {
                var requestEnt = requestExecuteCommon<E>(request, data);

                #region 处理逻辑
                var exe = new E();
                string responseData = exe.Execute(requestEnt);
                #endregion

                #region 输出数据流
                return new ParseUtil().StringToStream(responseData);
                #endregion
            }
            catch (System.Exception ex)
            {
                //LogUtil.LogException("方法：BaseService-->Execute\t异常信息：" + ex.Message);
                return new ParseUtil().StringToStream(@"{ ""ResultId"" ： ""-1"" }");
            }
        }

        /// <summary>
        /// 将请求流转换为对应的请求实体类，并记录日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private RequestEntityBase requestExecuteCommon<E>(Stream request, string data = "")
                        where E : ExeBase, new()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/json";

            string header = LogUtil.LogRequestHeader();                    //日志头

            string requestData = new ParseUtil().StreamToString(request);  //以字符串表示的流数据

            LogUtil.LogRequestBody(header, data, requestData);  //日志体

            requestData = PrepareRequestDataString(requestData); //预处理requestData字符串

            var exe = new E();
            var entity = exe.RequestDataToEntity(requestData);
            return executeRequestData(entity);
        }

        /// <summary>
        /// 对请求数据进行预处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private T executeRequestData<T>(T entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] pInfos = type.GetProperties();

            for (int j = 0; j < pInfos.Length; j++)
            {
                PropertyInfo pInfo = type.GetProperty(pInfos[j].Name);
                object beanValue = pInfo.GetValue(entity, null);
                string newValue = beanValue.ToString().FilterCommon();
                //对请求参数进行过滤处理
                pInfo.SetValue(entity, newValue, null);
            }

            return entity;
        }

        /// <summary>
        /// 预处理 Request Body 中提交的数据，对内容urlDecode，同时去掉json串前面的 message= 前缀。
        /// </summary>
        /// <param name="requestDataString"></param>
        /// <returns></returns>
        private string PrepareRequestDataString(string requestDataString)
        {
            if (string.IsNullOrEmpty(requestDataString))
                return "{}";

            string dataString = string.Empty;

            requestDataString = requestDataString.Trim();
            string rawUrlParam = HttpUtility.UrlDecode(requestDataString);
            //string rawUrlParam = requestDataString;

            string startString = "message=";
            if (rawUrlParam.StartsWith(startString))
                dataString = rawUrlParam.Substring(startString.Length);
            else
                dataString = rawUrlParam;

            return dataString;
        }
    }
}