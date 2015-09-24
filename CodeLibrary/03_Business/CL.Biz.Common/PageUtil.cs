using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Biz.Common
{
    public static class PageUtil
    {
        /// <summary>
        /// 获取分页html
        /// </summary>
        /// <param name="iPageIndex"></param>
        /// <param name="iRecordCount"></param>
        /// <param name="iPageSize"></param>
        /// <param name="strHref"></param>
        /// <param name="strCurrentIndexCss"></param>
        /// <param name="isURLTransfor"></param>
        /// <returns></returns>
        public static String GetPaginationHTML(Int32 iPageIndex, Int32 iRecordCount, Int32 iPageSize,
                                        String strHref, String strCurrentIndexCss, bool isURLTransfor)
        {

            //String strJSNone = "###";
            Int32 length = iRecordCount % iPageSize > 0 ? iRecordCount / iPageSize + 1 : iRecordCount / iPageSize;

            StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("<span><a class=\"{0}\" href=\"{1}?PageIndex={2}&PageSize={3}\"><span>首页</span></a></span>", strCurrentIndexCss, strHref, 1,iPageSize);
            ////sb.AppendFormat("<span><a class=\"{0}\" href=\"{1}?PageIndex={2}&PageSize={3}\"><span>上一页</span></a></span>", strCurrentIndexCss, strHref, iPageIndex - 1 == 0 ? 1 : iPageIndex - 1, iPageSize);
            ////sb.AppendFormat("<span><a class=\"{0}\" href=\"{1}?PageIndex={2}&PageSize={3}\"><span>下一页</span></a></span>", strCurrentIndexCss, strHref, iPageIndex == length - 1 ? length - 1 : iPageIndex + 1, iPageSize);
            ////sb.AppendFormat("<span><a class=\"{0}\" href=\"{1}?PageIndex={2}&PageSize={3}\"><span>尾页</span></a></span>", strCurrentIndexCss, strHref, length - 1, iPageSize);

            //if (strHref.Contains('?'))
            //{
            //    strHref = strHref + "&&";
            //}
            //else
            //{
            //    strHref = strHref + "?";
            //}

            //if (length == 0 || iPageIndex == 0)
            //    return "";

            //var pageMax = 0;
            //var pageMin = 0;
            //if (iPageIndex > 0 && iPageIndex <= 5)
            //{
            //    pageMax = 5; pageMin = 1;
            //}
            //else if (iPageIndex > 5 && iPageIndex < length - 2)
            //{
            //    pageMax = 1 * (iPageIndex) + 2; pageMin = 1 * (iPageIndex) - 2;
            //}
            //else
            //{
            //    pageMax = length;
            //    pageMin = length - 5;
            //}

            //if (length < 5 && iPageIndex < 5)
            //{
            //    pageMax = length; pageMin = 1;
            //}
            //if (length > 2 && iPageIndex != 1)
            //{
            //    sb.AppendFormat("<span><a href=\"{0}\" name='1'>首页</a></span>",
            //                    isURLTransfor ? String.Format("{0}pageindex={1}", strHref, 1) : strJSNone,
            //                        1);
            //}
            //if (length >= 2 && iPageIndex > 1)
            //{
            //    sb.AppendFormat("<span><a href=\"{0}\" name=\"{1}\">上一页</a></span>",
            //        isURLTransfor ? String.Format("{0}pageindex={1}", strHref, iPageIndex - 1) : strJSNone,
            //        iPageIndex - 1);
            //}

            //for (var i = pageMin; i <= pageMax; i++)
            //{
            //    if (iPageIndex == i)
            //    {
            //        sb.AppendFormat("<span><a class=\"{2}\" name=\"{1}\" href=\"javascript:void(0);\"><span>{1}</span></a></span>", strHref, i, strCurrentIndexCss);
            //    }
            //    else
            //    {
            //        sb.AppendFormat("<span><a href=\"{0}\" name=\"{1}\">{1}</a></span>",
            //                                isURLTransfor ? String.Format("{0}pageindex={1}", strHref, i) : strJSNone,
            //                                i);
            //    }
            //}
            //if (pageMax < length && length != 1 && length >= 2)
            //{
            //    sb.AppendFormat("<span><a href=\"{0}\" name=\'{1}\'>下一页</a></span>", isURLTransfor ? String.Format("{0}pageindex={1}", strHref, iPageIndex + 1) : strJSNone, iPageIndex + 1);

            //    sb.AppendFormat("<span><a href=\"{0}\" name=\'{1}\'>尾页</a></span>", isURLTransfor ? String.Format("{0}pageindex={1}", strHref, length) : strJSNone, length);
            //}


            String strText = String.Format("<span>共有&nbsp;{0}&nbsp;条记录,</span><span>每页&nbsp;{1}&nbsp;条,</span><span>共&nbsp;{2}&nbsp;页</span><span>当前第&nbsp;{3}&nbsp;页</span>",
                            iRecordCount, iPageSize, length, iPageIndex);

            return String.Format(@"<div id='pagination'><div id='left'>{1}</div>
                                <div id='right' >{0}</div>
                            </div>", sb, strText);
        }


        public static int DefaultPageSize = 10;

        public static int MaxPageSize = int.MaxValue;
    }
}
