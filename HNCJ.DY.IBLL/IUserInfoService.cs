using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.IBLL
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        
        bool SetRole(int userId,List<int> roleIds);
        UserInfo GetModel(string name, string pwd, bool is_encrypt);
        bool Exits(string name);
        void AddPaityMember(int userId);
        bool Restore(List<int> list);
        bool SetGuanZhu(int userId, int Tid);
    }
}
