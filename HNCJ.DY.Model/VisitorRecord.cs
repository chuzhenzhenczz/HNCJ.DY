//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HNCJ.DY.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VisitorRecord
    {
        public VisitorRecord()
        {
            this.DelFlag = true;
        }
    
        public int ID { get; set; }
        public int VisitorID { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public string VisitorName { get; set; }
        public string VisitorIcon { get; set; }
        public int UserInfoID { get; set; }
    }
}