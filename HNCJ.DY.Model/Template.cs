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
    
    public partial class Template
    {
        public Template()
        {
            this.DelFlag = true;
            this.Status = 1;
        }
    
        public int ID { get; set; }
        public string Context { get; set; }
        public string Path { get; set; }
        public Nullable<bool> DelFlag { get; set; }
        public Nullable<short> Status { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<System.DateTime> ModfiedTime { get; set; }
    }
}
