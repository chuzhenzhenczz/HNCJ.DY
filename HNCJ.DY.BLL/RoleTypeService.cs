using HNCJ.OA.IBLL;
using HNCJ.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.OA.BLL
{
    public class RoleTypeService : BaseService<RoleType>, IRoleTypeService
    {
        public override void SetCurrentDal()
        {
            CurretDal = DbSession.RoleTypeDal;
        }
    }
}
