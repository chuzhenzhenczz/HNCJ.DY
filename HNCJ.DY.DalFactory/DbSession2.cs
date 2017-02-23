using HNCJ.OA.DAL;
using HNCJ.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;



namespace HNCJ.OA.DalFactory
{
    public class DbSession2:IDbSession
    {
        #region 简单工厂或抽象工厂
		public IManagerDal ManagerDal 
        { 
            get{
                return StaticDalFactory.GetManagerDal();
            } 
        }
        public IRoleDal RoleDal { get { return StaticDalFactory.GetRoleDal(); } }
        public IRoleValueDal RoleValueDal { get { return StaticDalFactory.GetRoleValueDal(); } }
        public IRoleTypeDal RoleTypeDal { get { return StaticDalFactory.GetRoleTypeDal(); } }
 
	#endregion   
        /// <summary>
        /// 向数据库提交的方法
        /// </summary>
        /// <returns></returns>
        public int SaveChanges(){
          return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
