using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Test.DapperNet.Entities;
using Dapper.Contrib.Extensions;

namespace CL.Test.DapperNet.OperateDemo
{
    public class CRDDemo
    {
        public static long InsertAdminInfo(AdminInfo request)
        {
            using (var conn = DapperConnection.GetConnection())
            {
                return conn.Insert(request);
            }
        }

        public static bool InsertTransaction()
        {
            using (var conn = DapperConnection.GetConnection())
            {
                var tran = conn.BeginTransaction();
                if (conn.Insert<Test1>(new Test1 { Created = DateTime.Now }, tran) <= 0)
                {
                    tran.Rollback();
                    return false;
                }
                if (conn.Insert<Test2>(new Test2 { Created = DateTime.Now }, tran) <= 0)
                {
                    tran.Rollback();
                    return false;
                }
                tran.Commit();
                return true;
            }
        }

        public static long InsertTest()
        {
            var t = new Test1();
            t.Created = DateTime.Now;
            using (var conn = DapperConnection.GetConnection())
            {
                return conn.Insert(t);
            }
        }

        public static bool UpdateTest1()
        {
            var t = new Test1
            {
                ID = 3,
                Created = DateTime.Now.AddDays(1)
            };

            using (var conn = DapperConnection.GetConnection())
            {
                return conn.Update<Test1>(t);
            }
        }

        public static bool DeleteTest1()
        {
            var t = new Test1
            {
                ID = 3,
            };

            using (var conn = DapperConnection.GetConnection())
            {
                return conn.Delete<Test1>(t);
            }
        }
    }
}
