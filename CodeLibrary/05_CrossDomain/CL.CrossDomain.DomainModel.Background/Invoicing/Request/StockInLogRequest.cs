using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Invoicing.Request
{
    public class StockInLogRequest
    {

        public string DisplayID { get; set; }

        public string ProductID { get; set; }

        public string BarCode { get; set; }

        public DateTime? StockInStart { get; set; }

        public DateTime? StockInEnd { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
