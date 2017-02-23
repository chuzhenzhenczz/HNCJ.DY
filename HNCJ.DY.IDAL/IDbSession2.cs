
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.OA.IDAL
{
    public interface IDbSession2
    {
        IManagerDal ManagerDal { get; }
        IRoleDal RoleDal { get; }
        IRoleValueDal RoleValueDal { get; }
        IRoleTypeDal RoleTypeDal { get; }
        int SaveChanges();
    }
}
