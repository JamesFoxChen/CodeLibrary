using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Other.Request
{
    public class DBEntityGenerateRequest
    {
        public string DbTableName { get; set; }

        public string DbPascalTableName { get; set; }

        public string DbTableComments { get; set; }

        public string PrefixNameSpace { get; set; }

        public string PrefixClass { get; set; }
    }
}
