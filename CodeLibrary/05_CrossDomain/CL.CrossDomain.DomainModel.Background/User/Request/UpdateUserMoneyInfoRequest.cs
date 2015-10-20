using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.CrossDomain.DomainModel.Background.User.Request
{
    /// <summary>
    /// 更新用户余额
    /// </summary>
    public class UpdateUserMoneyInfoRequest
    {
        public string ID { get; set; }

        public decimal Value { get; set; }

        public int? Type { get; set; }

        public string OperateID { get; set; }
    }
}
