
using HNCJ.OA.DAL;
using HNCJ.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HNCJ.OA.DalFactory
{
    public class StaticDalFactory2
    {
       public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        public static IManagerDal GetManagerDal()
        {
            //return new ManagerDal();
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".ManagerDal") as IManagerDal;
        }
        public static IRoleDal GetRoleDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleDal") as IRoleDal;
        }
        public static IRoleValueDal GetRoleValueDal()
        {
            
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleValueDal") as IRoleValueDal;
        }

        public static IRoleTypeDal GetRoleTypeDal() {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleTypeDal") as IRoleTypeDal;
        }

    }
}
