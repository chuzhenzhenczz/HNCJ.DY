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
    
    public partial class ContentInfo
    {
        public ContentInfo()
        {
            this.DelFlag = true;
        }
    
        public int ID { get; set; }
        public string dContent { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<System.DateTime> ModfiedTime { get; set; }
        public int CategoryID { get; set; }
        public Nullable<int> UserInfoID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
