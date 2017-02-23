using HNCJ.OA.DalFactory;
using HNCJ.OA.IDAL;
using HNCJ.OA.IBLL;
using HNCJ.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.OA.BLL
{
    public class RoleValueService : BaseService<RoleValue>,IRoleValueService
    {
        public override void SetCurrentDal()
        {
            CurretDal = DbSession.RoleValueDal;
        }
    }
}
