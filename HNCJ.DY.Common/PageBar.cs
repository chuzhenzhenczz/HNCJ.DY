using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.Common
{
    public class PageBar
    {
        public static string GetPageBars(int pageIndex, int pageCount, string Func)
        {
            if (pageCount == 1 || pageCount == 0)
            {
                return string.Empty;
            }
            var index = pageIndex;
            int start = pageIndex - 5;//起始位置要求显示10个数字页码
            start = start < 1 ? 1 : start;
            int end = start + 5; //终止位置
            end = end > pageCount ? pageCount : end;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<ul class='pagination pagination-sm'>"));

            if (1 == index)
            {
                sb.Append(string.Format("<li class='disabled'><a >&lt;</a></li>"));
            }
            else
            {
                --pageIndex;
                var strs = Func + "(" + pageIndex + ")";
                sb.Append(string.Format("<li ><a href='#' onclick='{0}'>&lt;</a></li>", strs));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == index)
                {
                    sb.Append(string.Format("<li class='active'><a >{0}</a></li>", i));
                }
                else
                {
                    var strs = Func + "(" + i + ")";
                    sb.Append(string.Format("<li><a href='#' onclick='{0}'>{1}</a></li>", strs, i));
                }



            }
            if (pageCount == index)
            {
                sb.Append(string.Format("<li class='disabled' ><a >&gt;</a></li>"));
            }
            else
            {
                ++pageIndex;
                var strs = Func + "(" + pageIndex + ")";
                sb.Append(string.Format("<li ><a href='#' onclick='{0}'>&gt;</a></li>", strs));
            }

            sb.Append(string.Format("</ul>"));
            return sb.ToString();
        }
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1 || pageCount == 0)
            {
                return string.Empty;
            }
            var index = pageIndex;
            int start = pageIndex - 5;//起始位置要求显示10个数字页码
            start = start < 1 ? 1 : start;
            int end = start + 5; //终止位置
            end = end > pageCount ? pageCount : end;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<ul class='pagination pagination-sm'>"));

            if (1 == index)
            {
                sb.Append(string.Format("<li class='disabled'><a href='?pageIndex={0}'>&lt;</a></li>", 1));
            }
            else
            {
                sb.Append(string.Format("<li ><a href='?pageIndex={0}'>&lt;</a></li>", --pageIndex));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == index)
                {
                    sb.Append(string.Format("<li class='active'><a >{0}</a></li>", i));
                }
                else
                {
                    sb.Append(string.Format("<li><a href='?pageIndex={0}'>{1}</a></li>", i, i));
                }



            }
            if (pageCount == index)
            {
                sb.Append(string.Format("<li class='disabled' ><a href=''>&gt;</a></li>"));
            }
            else
            {
                sb.Append(string.Format("<li ><a href='?pageIndex={0}'>&gt;</a></li>", ++pageIndex));
            }

            sb.Append(string.Format("</ul>"));
            return sb.ToString();
        }
        public static string GetPageBars(int pageIndex, int pageCount,string FuncStr,string keyString)
        {
            if (pageCount == 1 || pageCount == 0)
            {
                return string.Empty;
            }
            var key = "''";
            if (!string.IsNullOrEmpty(keyString)) {
                key = "'"+keyString+"'";
            }
            var index = pageIndex;
            int start = pageIndex - 5;//起始位置要求显示10个数字页码
            start = start < 1 ? 1 : start;
            int end = start + 5; //终止位置
            end = end > pageCount ? pageCount : end;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<ul class='pagination pagination-sm'>"));

            if (1 == index)
            {
                sb.Append(string.Format("<li class='disabled'><a >&lt;</a></li>"));
            }
            else
            {
                --pageIndex;
                var str = FuncStr + "(" + pageIndex + "," + key + ")";
                sb.Append(string.Format("<li ><a href='#' onclick={0}>&lt;</a></li>", str));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == index)
                {
                    sb.Append(string.Format("<li class='active'><a >{0}</a></li>", i));
                }
                else
                {
                    var str = FuncStr + "(" + i + "," + key + ")";
                    sb.Append(string.Format("<li><a href='#' onclick={0}>{1}</a></li>", str, i));
                }



            }
            if (pageCount == index)
            {
                sb.Append(string.Format("<li class='disabled' ><a >&gt;</a></li>"));
            }
            else
            {
                ++pageIndex;
                var str = FuncStr + "(" + pageIndex + "," + key + ")";
                sb.Append(string.Format("<li ><a href='#' onclick={0}>&gt;</a></li>", str));
            }

            sb.Append(string.Format("</ul>"));
            return sb.ToString();
        }
        public static string GetPageBar(int pageIndex, int pageCount,string str,int id)
        {
            if (pageCount == 1 || pageCount == 0)
            {
                return string.Empty;
            }
            var index = pageIndex;
            int start = pageIndex - 5;//起始位置要求显示10个数字页码
            start = start < 1 ? 1 : start;
            int end = start + 5; //终止位置
            end = end > pageCount ? pageCount : end;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<ul class='pagination pagination-sm'>"));

            if (1 == index)
            {
                sb.Append(string.Format("<li class='disabled'><a '>&lt;</a></li>"));
            }
            else
            {
                --pageIndex;
                var strs=str+"("+pageIndex+","+id+")";
                sb.Append(string.Format("<li ><a href='#' onclick='{0}'>&lt;</a></li>", strs));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == index)
                {
                    sb.Append(string.Format("<li class='active'><a >{0}</a></li>", i));
                }
                else
                {
                    var strs = str + "(" + i + "," + id + ")";
                    sb.Append(string.Format("<li><a href='#' onclick='{0}'>{1}</a></li>", strs, i));
                }



            }
            if (pageCount == index)
            {
                sb.Append(string.Format("<li class='disabled' ><a >&gt;</a></li>"));
            }
            else
            {
                ++pageIndex;
                var strs = str + "(" + pageIndex + "," + id + ")";
                sb.Append(string.Format("<li ><a href='#' onclick='{0}'>&gt;</a></li>", strs));
            }

            sb.Append(string.Format("</ul>"));
            return sb.ToString();
        }

        
    }
}
