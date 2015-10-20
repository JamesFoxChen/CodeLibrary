using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.User.Request
{
    public class UserMoneyInfoRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string UserName { get; set; }

        public string Mobile { get; set; }
    }
}
