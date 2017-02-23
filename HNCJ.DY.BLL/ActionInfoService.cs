using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public IQueryable<ActionInfo> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.ActionInfoDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key)) {
                switch (queryParam.ItemId)
                {
                    case 1: temp = temp.Where(u => u.ActionName.Contains(queryParam.Key)).AsQueryable(); break;
                    case 2: temp = temp.Where(u => u.Url.Contains(queryParam.Key)).AsQueryable(); break;
                    case 3: temp = temp.Where(u => u.HttpMethd.Contains(queryParam.Key)).AsQueryable(); break;
                    case 4: bool ddf = "是".Contains(queryParam.Key); var ff = ddf ? true : false; temp = temp.Where(u => u.IsMenu==ff).AsQueryable(); break;
                    case 5: bool dd = "正常".Contains(queryParam.Key); short b = dd ? (short)1 : (short)0; temp = temp.Where(u => u.Status == b).AsQueryable(); break;
                    default: temp = temp.Where(u => u.ActionName.Contains(queryParam.Key)).AsQueryable(); break;
                }
               
            }
            
            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }


        public bool SetRole(int userId, List<int> roleIds)
        {
            var action = DbSession.ActionInfoDal.GetEntity(u => u.ID == userId).FirstOrDefault();
            action.RoleInfo.Clear();
            var allRoles = DbSession.RoleInfoDal.GetEntity(r => roleIds.Contains(r.ID));
            foreach (var roleInfo in allRoles)
            {
                action.RoleInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();
            return true;
        }
        public ActionInfo Add(string url, string http) {
           ActionInfo actio=DbSession.ActionInfoDal.GetEntity(u => u.Url==url && u.HttpMethd == http).FirstOrDefault();
           ActionInfo action = new ActionInfo();
            if (actio == null) {
               
               action.Url = url;
               action.HttpMethd = http;
               action.DelFlag = true;
               action.RegTime = DateTime.Now;

               action.IsMenu = false;
               action.ActionName = "修改";
               DbSession.ActionInfoDal.Add(action);
               DbSession.SaveChanges();
           }
            return action;
        }
    }
}
