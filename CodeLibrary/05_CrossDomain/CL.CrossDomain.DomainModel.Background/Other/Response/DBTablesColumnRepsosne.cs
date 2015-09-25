using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Other.Response
{
    public class DBTablesColumnRepsosne
    {
        public string Column_Name { get; set; }
        public string DATA_TYPE { get; set; }
        public string DATA_LENGTH { get; set; }
        public string DATA_PRECISION { get; set; }
        public string DATA_SCALE { get; set; }
        public string Nullable { get; set; }
        public string DefaultValue { get; set; }
        public string Comments { get; set; }
        public string PascalName { get; set; }
    }
}
