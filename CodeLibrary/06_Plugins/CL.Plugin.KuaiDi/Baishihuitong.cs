using System;
using System.Collections.Generic;
using System.Linq;
using CL.Plugin.KuaiDi.Common;
using Sdk.BizData.Response;

namespace CL.Plugin.KuaiDi
{
    public class Baishihuitong
    {
        /// <summary>
        /// 百世汇通账号
        /// </summary>
        private static readonly string bs_partnerID = "";
        /// <summary>
        /// 百世汇通账号
        /// </summary>
        private static readonly string bs_partnerKey = "";

        /// <summary>
        /// 获取百世汇通物流信息
        /// </summary>
        /// <param name="mailNo"></param>
        /// <returns></returns>
        public static List<KuaidiResponse> GetWuliu(string mailNo)
        {
            var retList = new List<KuaidiResponse>();

            if (string.IsNullOrWhiteSpace(mailNo))
            {
                return retList;
            }

            DefaultClient client = new DefaultClient("http://edi-q9.ns.800best.com/ems/api/process", bs_partnerID, bs_partnerKey);
            TraceLogsListType result = client.queryBillStatus(mailNo);
            List<TraceLogsType> tlts = result.traceLogs;
            foreach (TraceLogsType tlt in tlts)
            {
                Console.WriteLine(tlt.mailNo);
                List<TracesType> tts = tlt.traces;
                foreach (TracesType track in tts)
                {

                    var m = new KuaidiResponse();
                    m.Address = track.acceptAddress;
                    m.Time = track.acceptTime;
                    m.MailNo = mailNo;
                    //m.opcode = "";
                    //m.orderId = "";
                    m.Remark = track.remark;
                    retList.Add(m);
                }
            }

            return retList.OrderByDescending(p => p.Time).ToList();
        }
    }
}
