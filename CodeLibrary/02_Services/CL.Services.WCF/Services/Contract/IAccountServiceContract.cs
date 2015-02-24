
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace PT.Ayl.Services
{
    [ServiceContract]
    public interface IAccountServiceContract
    {
        #region 获取信息列表接口
        /// <summary>
        /// 获取信息列表接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "GetReceiptList", Method = "POST",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream GetReceiptListPost(Stream request);
        #endregion


        #region 新增信息接口
        /// <summary>
        /// 新增信息接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "AddReceipt", Method = "POST",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream AddReceiptPost(Stream request);
        #endregion
    }
}