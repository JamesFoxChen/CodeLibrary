using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Framework.Utils;
using CL.Test.DapperNet.Entities;
using CL.Test.DapperNet.OperateDemo;

namespace CL.Test.DapperNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Select();
            //Insert();
            //Update();
            //Delete();
        }


        private static void Select()
        {
            //var result = SelectDemo.GetAdminInfoList("", "");

            var result = SelectDemo.GetCount();
        }


        private static void Insert()
        {
            //var request = new AdminInfo
            //{
            //    ID = StringUtil.GetGUID(),
            //    AdminName = "Admin",
            //    AccountStatus = 1,
            //    IsSystem = 1,
            //    Password = "1",
            //    Created = DateTime.Now,
            //    Updated = DateTime.Now
            //};
            //var list = CRDDemo.InsertAdminInfo(request);

            var result = CRDDemo.InsertTransaction();

            //var result = CRDDemo.InsertTest();
        }

        private static void Update()
        {
            var result = CRDDemo.UpdateTest1();
        }

        private static void Delete()
        {
            var result = CRDDemo.DeleteTest1();
        }
    }
}
