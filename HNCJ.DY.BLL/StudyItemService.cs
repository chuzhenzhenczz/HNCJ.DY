using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class StudyItemService : BaseService<StudyItem>, IStudyItemService
    {
        public IQueryable<StudyItem> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.StudyItemDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key))
            {
                switch (queryParam.ItemId)
                {
                    case 2: temp = temp.Where(u => u.Context.Contains(queryParam.Key)).AsQueryable(); break;
                    case 3: temp = temp.Where(u => u.StudyOnline.Name.Contains(queryParam.Key)).AsQueryable(); break;                   
                    default: temp = temp.Where(u => u.Context.Contains(queryParam.Key)).AsQueryable(); break;
                }
            }

            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }

    }
}
