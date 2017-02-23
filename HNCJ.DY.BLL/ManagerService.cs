using HNCJ.OA.DalFactory;
using HNCJ.OA.IBLL;
using HNCJ.OA.IDAL;
using HNCJ.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.OA.BLL
{
    public class ManagerService:BaseService<Manager>,IManagerService
    {
        //IManagerDal managerDal = StaticDalFactory.GetManagerDal();
        //DbSession dbSession = new DbSession();
        //IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        //public Manager Add(Manager manager) {
        //    dbSession.ManagerDal.Add(manager);
        //    dbSession.SaveChanges();
        //    return manager;
        //}
        public override void SetCurrentDal()
        {
            CurretDal = DbSession.ManagerDal;
        }
    }
}
