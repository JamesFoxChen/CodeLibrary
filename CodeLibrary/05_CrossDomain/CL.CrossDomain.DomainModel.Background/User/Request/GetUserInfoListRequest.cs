using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.User.Request
{
    public class GetUserInfoListRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int? UserType { get; set; }

        public string UserName { get; set; }

        public string Mobile { get; set; }

        public string TrueName { get; set; }

        public int? AccountStatus { get; set; }

        public DateTime? RegDateStart { get; set; }

        public DateTime? RegDateEnd { get; set; }

        public int? DataSource { get; set; }
    }
}
