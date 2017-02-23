using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class StudyOnlineService : BaseService<StudyOnline>, IStudyOnlineService
    {
        public IQueryable<StudyOnline> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.StudyOnlineDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key))
            {
                switch (queryParam.ItemId)
                {
                    case 1: temp = temp.Where(u => u.Name.Contains(queryParam.Key)).AsQueryable(); break;
                    case 2: bool dd = "正常".Contains(queryParam.Key); short b = dd ? (short)1 : (short)0; temp = temp.Where(u => u.Status == b).AsQueryable(); break;
                    default: temp = temp.Where(u => u.Name.Contains(queryParam.Key)).AsQueryable(); break;
                }
            }

            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }

    }
}
