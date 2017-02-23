using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.IBLL
{
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        
        bool SetRole(int userId, List<int> roleIds);
        ActionInfo Add(string url, string http);
    }
}
