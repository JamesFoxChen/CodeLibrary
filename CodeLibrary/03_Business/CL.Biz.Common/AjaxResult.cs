using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CL.Biz.Common
{
    /// <summary>
    /// ajax处理返回信息
    /// </summary>
    /// <typeparam name="T">返回值中包含的数据的类型</typeparam>
    public class AjaxResult<T> : IActionResult
    {
        #region 属性
        /// <summary>
        /// 状态字符串
        /// </summary>
        public AjaxStatus Status { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// </summary>
        internal AjaxResult()
        {
            Value = default(T);
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        public AjaxResult(AjaxStatus status)
            : this()
        {
            Status = status;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        /// <param name="message">返回信息</param>
        public AjaxResult(AjaxStatus status, string message)
            : this(status)
        {
            Message = message;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        /// <param name="val">记录</param>
        public AjaxResult(AjaxStatus status, T val)
            : this(status)
        {
            Value = val;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        /// <param name="message">返回信息</param>
        /// <param name="val">记录</param>
        public AjaxResult(AjaxStatus status, string message, T val)
            : this(status, message)
        {
            Value = val;
        }
        #endregion

        #region 方法

        /// <summary>
        /// 返回实体Json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (new JavaScriptSerializer()).Serialize(new
            {
                // string.Join(",", Enum.GetNames(typeof(ResultStatus))) //获取所有名称
                // Status = Enum.GetName(typeof(ResultStatus), this.Status),
                Status = this.Status.ToString(),
                Message = this.Message,
                Value = this.Value
            });
        }
        #endregion
    }

    /// <summary>
    /// ajax处理返回信息
    /// </summary>
    public class AjaxResult : AjaxResult<string>
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public AjaxResult()
        {
            Value = string.Empty;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        public AjaxResult(AjaxStatus status)
            : this()
        {
            Status = status;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        /// <param name="message">返回信息</param>
        public AjaxResult(AjaxStatus status, string message)
            : this(status)
        {
            Message = message;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status">返回状态</param>
        /// <param name="message">返回信息</param>
        /// <param name="val">返回值</param>
        public AjaxResult(AjaxStatus status, string message, string val)
            : this(status, message)
        {
            Value = val;
        }
        #endregion
    }

    /// <summary>
    /// 返回结果状态
    /// </summary>
    public enum AjaxStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        OK = 1,
        /// <summary>
        /// 失败
        /// </summary>
        NO = 2
    }

    public interface IActionResult
    {
    }
}
