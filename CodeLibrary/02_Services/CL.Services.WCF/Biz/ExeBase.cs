
using Newtonsoft.Json;
using System;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Common;

namespace CL.Services.WCF
{
    /// <summary>
    /// 业务逻辑基础类
    /// </summary>
    public abstract class ExeBase
    {
        /// <summary>
        /// 请求数据转换为请求实体类
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public abstract RequestEntityBase RequestDataToEntity(string requestData);

        /// <summary>
        /// 执行业务逻辑公共方法
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public abstract string Execute(RequestEntityBase ent);

        /// <summary>
        /// 返回实体类转换为字符串
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public abstract string ResponseEntityToData(EnumResultId resultId, string resultMsg, ResponseEntityBase responseEntity);

        /// <summary>
        /// 将响应实体类值转化为Json字符串
        /// </summary>
        /// <param name="responseEntity"></param>
        /// <returns></returns>
        public string ToJson<T>(T responseEntity) where T : ResponseEntityBase, new()
        {
            try
            {
                //if (ConfigUtil.IsResponseFormatJson)
                if(true)
                {
                    return JsonConvert.SerializeObject(responseEntity, Formatting.Indented);
                }
                return JsonConvert.SerializeObject(responseEntity);
            }
            catch (Exception ex)
            {
                var stackFrame = new System.Diagnostics.StackFrame();
                var methodBase = stackFrame.GetMethod();
                //LogUtil.LogException("方法：" + methodBase + "\t异常信息：" + ex.Message);
                return null;
            }
        }

        protected void LogMsg(EnumResultId resultId, string msg, int logTypeMain)
        {
            if (resultId != EnumResultId.Success)
            {
                //if (ConfigUtil.IsLog)
                //{
                //    LogCommonDb.LogMsgNoThrow(logTypeMain, logType.GetHashCode(), msg);
                //}
            }

        }

        ///// <summary>
        ///// 对响应数据进行预处理
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //private T executeResponseData<T>(T entity)
        //{
        //    //Type type = typeof(T);
        //    //PropertyInfo[] pInfos = type.GetProperties();

        //    //for (int j = 0; j < pInfos.Length; j++)
        //    //{
        //    //    PropertyInfo pInfo = type.GetProperty(pInfos[j].Name);
        //    //    object beanValue = pInfo.GetValue(entity, null);
        //    //    pInfo.SetValue(entity, beanValue.ToString().Trim(), null);  //去除请求数据中两边的空格
        //    //}

        //    //return entity;
        //    return entity;
        //}

        ///// <summary>
        ///// 返回接口执行异常或失败的响应实体类值
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="resultId"></param>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //protected ResponseEntityBase ReponseNonSuccess<T>(EnumResultId resultId, string msg = "")
        //                                                    where T : ResponseEntityBase, new()
        //{
        //    T response = new T();
        //    response.ResultId = resultId.GetHashCode().ToString();

        //    #region 写入错误日志
        //    msg = string.IsNullOrWhiteSpace(msg) ? ConstantBLLUtil.Error_System : msg;
        //    StringBuilder sbLog = new StringBuilder("接口提示：");
        //    sbLog.Append(response.GetType().Name).Append("  ").Append(msg);
        //    LogUtil.LogException(sbLog.ToString());
        //    #endregion

        //    return response;
        //}


        ///// <summary>
        ///// 只返回ResultId为成功的信息
        ///// </summary>
        ///// <returns></returns>
        //protected ResponseEntityBase ResponseSuccessEntity()
        //{
        //    return new ResponseEntityBase
        //    {
        //        ResultId = EnumResultId.Success.GetHashCode().ToString()
        //    };
        //}

        /// <summary>
        /// 判断请求数据中必填字段是否有空值
        /// 有：返回true 没有：返回false
        /// </summary>
        /// <param name="data">请求字段</param>
        /// <returns></returns>
        protected bool IsRequestDataEmpty(params string[] data)
        {
            foreach (var item in data)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  请求参数Url解码
        /// </summary>
        /// <param name="ent"></param>
        protected virtual void UrlDecode(RequestEntityBase ent)
        {
            if (!string.IsNullOrWhiteSpace(ent.Position))
            {
                ent.Position = ent.Position.UrlDecoding();
            }
        }

        ///// <summary>
        ///// 执行业务逻辑公共方法
        ///// </summary>
        ///// <param name="ent"></param>
        ///// <returns></returns>
        //public abstract ResponseEntityBase Execute(RequestEntityBase ent);



    }
}