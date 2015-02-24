
namespace CL.Services.WCF
{
    /// <summary>
    /// 实体类工具类
    /// </summary>
    public class ConstantBLLUtil
    {
        /// <summary>
        /// 输入Xml无效
        /// </summary>
        public const string Error_InputXml = "输入值无效，请稍后再试！";

        /// <summary>
        /// 系统发生异常，请联系管理员！
        /// </summary>
        public const string Error_System = "系统繁忙，请稍后再试！";


        /// <summary>
        /// 请求实体类(RequestEntityBase)为空！
        /// </summary>
        public const string Error_RequestEntityBaseNull = "请求实体类(RequestEntityBase)为空！";

        /// <summary>
        /// 请求参数中必填选择不能为空！
        /// </summary>
        public const string Error_RequestDataRequired = "请求参数中必填选择不能为空！";

        /// <summary>
        /// 用户验证串超时或验证失败！
        /// </summary>
        public const string Error_TimeOutOrVerifyFailure = "用户验证串超时或验证失败！";


        /// <summary>
        /// 查看30天以内的可用到期积分
        /// </summary>
        public const int InDays = 30;

        /// <summary>
        /// 存放企业图片
        /// </summary>
        public const string ImgDir_Enterprise = "EntLog/";

        public const string CID = "9999";

        public const string ResetPwd = "111111";

        public const int LogTypeMain = 1;
    }
}
