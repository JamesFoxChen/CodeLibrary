namespace CL.Plugin.KuaiDi.Common
{
    public interface IClient
    {
        /// <summary>
        /// 调用请求，获取响应
        /// </summary>
        /// <param name="ebillRequest"></param>
        /// <returns></returns>

        IResponse DoExecute(IRequest ebillRequest);
    }
}
