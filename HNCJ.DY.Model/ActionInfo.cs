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
    
    public partial class ActionInfo
    {
        public ActionInfo()
        {
            this.IsMenu = false;
            this.Status = 1;
            this.DelFlag = true;
            this.UserActionInfo = new HashSet<UserActionInfo>();
            this.RoleInfo = new HashSet<RoleInfo>();
        }
    
        public int ID { get; set; }
        public string ActionName { get; set; }
        public string Url { get; set; }
        public string HttpMethd { get; set; }
        public Nullable<bool> IsMenu { get; set; }
        public string MenuIcon { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<short> Status { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<System.DateTime> ModfiedTime { get; set; }
    
        public virtual ICollection<UserActionInfo> UserActionInfo { get; set; }
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}