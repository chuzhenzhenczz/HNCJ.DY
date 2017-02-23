using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.Model
{
    public class BaseParam
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Total { get; set; }
        public int ItemId { get; set; }
        public string Key { get; set; }

    }
}
