using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class FriendService : BaseService<Friend>, IFriendService
    {
        public IQueryable<Friend> LoagPageData(BaseParam queryParam)
        {
            return null;
        }

    }
}
