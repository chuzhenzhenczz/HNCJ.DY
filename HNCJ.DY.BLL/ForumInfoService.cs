using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class ForumInfoService : BaseService<ForumInfo>, IForumInfoService
    {
        public IQueryable<ForumInfo> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.ForumInfoDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key))
            {
                temp = temp.Where(u => u.Name.Contains(queryParam.Key)).AsQueryable();
            }

            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }

    }
}
