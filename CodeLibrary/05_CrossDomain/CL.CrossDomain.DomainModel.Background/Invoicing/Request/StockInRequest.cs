using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.Invoicing.Request
{
    public class StockInRequest
    {
        public string ID { get; set; }

        public string ProductID { get; set; }

        public string BarCode { get; set; }

        public string SpecID { get; set; }

        public Int32? StockInCount { get; set; }

        public String UserID { get; set; }

        public DateTime? Created { get; set; }
    }
}
