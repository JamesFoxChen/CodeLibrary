using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.User.Response
{
    public class GetRightInfoResponse
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string RightName { get; set; }
        public string URL { get; set; }
        public int? OrderIndex { get; set; }

        /// <summary>
        /// 对应的子栏目
        /// </summary>
        public List<GetRightInfoResponse> rightInfoFrist { get; set; }
    }
}
