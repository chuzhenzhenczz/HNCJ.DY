using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class FilesInfoService : BaseService<FilesInfo>, IFilesInfoService
    {
        public IQueryable<FilesInfo> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.FilesInfoDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key))
            {
                switch (queryParam.ItemId)
                {
                    case 1: temp = temp.Where(u => u.FileName.Contains(queryParam.Key)).AsQueryable(); break;

                    case 2: var ff = StringToShort(queryParam.Key); temp = temp.Where(u => u.Type == ff).AsQueryable(); break;
                    case 3: bool dd = "正常".Contains(queryParam.Key); short b = dd ? (short)1 : (short)0; temp = temp.Where(u => u.Status == b).AsQueryable(); break;
                    default: temp = temp.Where(u => u.FileName.Contains(queryParam.Key)).AsQueryable(); break;
                }
            }

            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        }
        private short StringToShort(string str)
        {
            if ("党员发展材料".Contains(str)) { return 1; }
            else if ("季度思想报告".Contains(str)) { return 2; }
            else if ("学习总结心得".Contains(str)) { return 3; }
            else { return 4; }
        }
    }
     

}
