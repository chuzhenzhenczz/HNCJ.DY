using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService
    {
        public IQueryable<RoleInfo> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.RoleInfoDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key)) {
                switch (queryParam.ItemId)
                {
                    case 1: temp = temp.Where(u => u.RoleName.Contains(queryParam.Key)).AsQueryable(); break;                    
                    case 2: bool dd = "正常".Contains(queryParam.Key); short b = dd ? (short)1 : (short)0; temp = temp.Where(u => u.Status == b).AsQueryable(); break;
                    default: temp = temp.Where(u => u.RoleName.Contains(queryParam.Key)).AsQueryable(); break;
                }
            }
            
            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }
        #region 设置权限
        public bool SetAction(int roleId, List<int> actionIds)
        {
            var role = DbSession.RoleInfoDal.GetEntity(u => u.ID == roleId).FirstOrDefault();
            role.ActionInfo.Clear();
            var allRoles = DbSession.ActionInfoDal.GetEntity(r => actionIds.Contains(r.ID));
            foreach (var roleInfo in allRoles)
            {
                role.ActionInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();
            return true;
        }
        #endregion
    }
}
