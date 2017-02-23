using HNCJ.DY.Common;
using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        #region 多条件查询加分页
        public IQueryable<UserInfo> LoagPageData(BaseParam queryParam)
        {
            var temp = DbSession.UserInfoDal.GetEntity(u => u.DelFlag == true);
            if (!string.IsNullOrEmpty(queryParam.Key))
            {
                switch (queryParam.ItemId) {
                    case 1: temp = temp.Where(u => u.UserName.Contains(queryParam.Key)).AsQueryable(); break;
                    case 2: bool dd = "正常".Contains(queryParam.Key); short b = dd ? (short)1 : (short)0; temp = temp.Where(u => u.Status == b).AsQueryable(); break;
                    default: temp = temp.Where(u => u.UserName.Contains(queryParam.Key)).AsQueryable(); break;
                }
                
            }
            
            queryParam.Total = temp.Count();

            return temp.OrderBy(u => u.ID).Skip(queryParam.PageSize * (queryParam.PageIndex - 1)).Take(queryParam.PageSize).AsQueryable();
        } 
        #endregion

        #region 设置角色
        public bool SetRole(int userId, List<int> roleIds)
        {
            var user = DbSession.UserInfoDal.GetEntity(u => u.ID == userId).FirstOrDefault();
            user.RoleInfo.Clear();
            var allRoles = DbSession.RoleInfoDal.GetEntity(r => roleIds.Contains(r.ID));
            foreach (var roleInfo in allRoles)
            {
                user.RoleInfo.Add(roleInfo);
            }
            DbSession.SaveChanges();
            return true;
        } 
        #endregion

        #region 关注
        public bool SetGuanZhu(int userId, int Tid) {
            var user = DbSession.UserInfoDal.GetEntity(u => u.ID == userId).FirstOrDefault();
            var model = DbSession.TopicInfoDal.GetEntity(t => t.ID == Tid).FirstOrDefault();
            user.TopicInfo1.Add(model);
            DbSession.SaveChanges();
            return true;
        }
        #endregion

        #region 登录验证
        public UserInfo GetModel(string name, string pwd, bool is_encrypt)
        {
            //检查一下是否需要加密
            if (is_encrypt)
            {
                //先取得该用户的随机密钥
                string salt=GetSalt(name);
                if(string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                pwd = DESEncrypt.Encrypt(pwd,salt);

            }
            return GetModel(name, pwd);
        }
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        private UserInfo GetModel(string name, string pwd) {
            return DbSession.UserInfoDal.GetEntity(u=>u.DelFlag==true&&u.UserName==name&&u.Userpwd==pwd).FirstOrDefault();
        }
        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        private string GetSalt(string name) {
            UserInfo user = DbSession.UserInfoDal.GetEntity(u => u.DelFlag == true && u.UserName == name.Trim()).FirstOrDefault();
            if (user == null && string.IsNullOrEmpty(user.UserKey))
            {
                return null;
            }
            return user.UserKey;
        }
        #endregion

        #region 判断用户名是否存在
        public bool Exits(string name) {
            UserInfo user = DbSession.UserInfoDal.GetEntity(u => u.DelFlag == true && u.UserName == name).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region  添加党员资料
        public void AddPaityMember(int userId)
        {
            PaityMember user = new PaityMember();
            user.RegTime = DateTime.Now;
            user.ModfiedTime = DateTime.Now;
            user.UserInfoID = userId;
            DbSession.PaityMemberDal.Add(user);
            DbSession.SaveChanges();
        }
        #endregion

        #region 重置密码
        public bool Restore(List<int> list) {
            foreach (var item in list) {
                var entity=DbSession.UserInfoDal.GetEntity(u => u.ID == item).FirstOrDefault();
                entity.UserKey = Utils.GetCheckCode(6); //获得6位的salt加密字符串
                entity.Userpwd = DESEncrypt.Encrypt("123456", entity.UserKey);
                entity.Status = 1;
                entity.ModfiedTime = DateTime.Now;
                DbSession.UserInfoDal.Update(entity);
            }
            DbSession.SaveChanges();
            return true;
        
        }
        #endregion
    }
}
