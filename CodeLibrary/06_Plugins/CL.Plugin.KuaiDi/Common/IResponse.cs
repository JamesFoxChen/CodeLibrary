using System;

namespace CL.Plugin.KuaiDi.Common
{
    public interface IResponse
    {
        /// <summary>
        /// 完整响应字符串
        /// </summary>
        string ResponseContent { get; }

        /// <summary>
        /// 协议是否成功标记
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 协议级错误码
        /// </summary>
        string ErrorCode { get; }

        /// <summary>
        /// 响应业务数据的对象格式
        /// </summary>
        object ResponseObject { get; }

        /// <summary>
        /// 响应业务数据类型
        /// </summary>
        Type BizDataType { get;}
    }
}
