﻿using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.IBLL
{
    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {
       
        bool SetAction(int roleId, List<int> actionIds);
    }
}