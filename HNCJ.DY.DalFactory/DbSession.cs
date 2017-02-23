


using HNCJ.DY.DAL;
using HNCJ.DY.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;



namespace HNCJ.DY.DalFactory
{
    public class DbSession:IDbSession
    {
		
		public IActionInfoDal ActionInfoDal 
        { 
            get{
                return StaticDalFactory.GetActionInfoDal();
            } 
        }
        
 
	
		
		public ICategoryDal CategoryDal 
        { 
            get{
                return StaticDalFactory.GetCategoryDal();
            } 
        }
        
 
	
		
		public IContentInfoDal ContentInfoDal 
        { 
            get{
                return StaticDalFactory.GetContentInfoDal();
            } 
        }
        
 
	
		
		public IFilesInfoDal FilesInfoDal 
        { 
            get{
                return StaticDalFactory.GetFilesInfoDal();
            } 
        }
        
 
	
		
		public IFriendDal FriendDal 
        { 
            get{
                return StaticDalFactory.GetFriendDal();
            } 
        }
        
 
	
		
		public IMessageDal MessageDal 
        { 
            get{
                return StaticDalFactory.GetMessageDal();
            } 
        }
        
 
	
		
		public INewInfoDal NewInfoDal 
        { 
            get{
                return StaticDalFactory.GetNewInfoDal();
            } 
        }
        
 
	
		
		public IPaityMemberDal PaityMemberDal 
        { 
            get{
                return StaticDalFactory.GetPaityMemberDal();
            } 
        }
        
 
	
		
		public IRoleInfoDal RoleInfoDal 
        { 
            get{
                return StaticDalFactory.GetRoleInfoDal();
            } 
        }
        
 
	
		
		public IStudyItemDal StudyItemDal 
        { 
            get{
                return StaticDalFactory.GetStudyItemDal();
            } 
        }
        
 
	
		
		public IStudyOnlineDal StudyOnlineDal 
        { 
            get{
                return StaticDalFactory.GetStudyOnlineDal();
            } 
        }
        
 
	
		
		public ITemplateDal TemplateDal 
        { 
            get{
                return StaticDalFactory.GetTemplateDal();
            } 
        }
        
 
	
		
		public ITopicInfoDal TopicInfoDal 
        { 
            get{
                return StaticDalFactory.GetTopicInfoDal();
            } 
        }
        
 
	
		
		public IUserActionInfoDal UserActionInfoDal 
        { 
            get{
                return StaticDalFactory.GetUserActionInfoDal();
            } 
        }
        
 
	
		
		public IUserInfoDal UserInfoDal 
        { 
            get{
                return StaticDalFactory.GetUserInfoDal();
            } 
        }
        
 
	
		
		public IVisitorRecordDal VisitorRecordDal 
        { 
            get{
                return StaticDalFactory.GetVisitorRecordDal();
            } 
        }
        
 
	
		/// <summary>
        /// 向数据库提交的方法
        /// </summary>
        /// <returns></returns>
        public int SaveChanges(){
          return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
	}

}