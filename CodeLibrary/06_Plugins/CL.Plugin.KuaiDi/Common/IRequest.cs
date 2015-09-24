using System;
using System.Collections.Generic;

namespace CL.Plugin.KuaiDi.Common
{
    public interface IRequest
    {

        string ApiServiceType { get; }

        bool Check();

        IDictionary<string, string> Params { get; }

        Type ResponseType{ get; }

        Type BizDataType { get; }

        void SetBizDataObject(object bizData);
    }
}
