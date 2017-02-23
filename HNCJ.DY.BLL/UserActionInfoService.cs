using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class UserActionInfoService : BaseService<UserActionInfo>, IUserActionInfoService
    {
        public IQueryable<UserActionInfo> LoagPageData(BaseParam queryParam)
        {
            return null;
        }

    }
}
