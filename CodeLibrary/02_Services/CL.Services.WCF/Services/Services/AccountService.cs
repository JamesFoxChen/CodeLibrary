using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CL.Services.WCF;

namespace PT.Ayl.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AccountService : BaseService, IAccountServiceContract
    {
        #region 获取信息列表接口
        public Stream GetReceiptListPost(Stream request)
        {
            return Execute<GetReceiptListExe>(request);
        }
        #endregion


        #region 新增信息接口
        public Stream AddReceiptPost(Stream request)
        {
            return Execute<AddReceiptExe>(request);
        }
        #endregion
    }
}