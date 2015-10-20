using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.DAL.DataAccess;

namespace CL.Test.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new CLDbContext();
            var blog = db.ProductInfo.FirstOrDefault(p => p.ID == "123");
        }
    }
}
