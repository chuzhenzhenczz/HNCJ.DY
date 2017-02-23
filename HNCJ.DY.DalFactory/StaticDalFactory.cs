


using HNCJ.DY.DAL;
using HNCJ.DY.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HNCJ.DY.DalFactory
{
    public class StaticDalFactory
    {
       public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
      
		 public static IActionInfoDal GetActionInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".ActionInfoDal") as IActionInfoDal;
        }
	
	
		 public static ICategoryDal GetCategoryDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".CategoryDal") as ICategoryDal;
        }
	
	
		 public static IContentInfoDal GetContentInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".ContentInfoDal") as IContentInfoDal;
        }
	
	
		 public static IFilesInfoDal GetFilesInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".FilesInfoDal") as IFilesInfoDal;
        }
	
	
		 public static IFriendDal GetFriendDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".FriendDal") as IFriendDal;
        }
	
	
		 public static IMessageDal GetMessageDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".MessageDal") as IMessageDal;
        }
	
	
		 public static INewInfoDal GetNewInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".NewInfoDal") as INewInfoDal;
        }
	
	
		 public static IPaityMemberDal GetPaityMemberDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".PaityMemberDal") as IPaityMemberDal;
        }
	
	
		 public static IRoleInfoDal GetRoleInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".RoleInfoDal") as IRoleInfoDal;
        }
	
	
		 public static IStudyItemDal GetStudyItemDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".StudyItemDal") as IStudyItemDal;
        }
	
	
		 public static IStudyOnlineDal GetStudyOnlineDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".StudyOnlineDal") as IStudyOnlineDal;
        }
	
	
		 public static ITemplateDal GetTemplateDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".TemplateDal") as ITemplateDal;
        }
	
	
		 public static ITopicInfoDal GetTopicInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".TopicInfoDal") as ITopicInfoDal;
        }
	
	
		 public static IUserActionInfoDal GetUserActionInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserActionInfoDal") as IUserActionInfoDal;
        }
	
	
		 public static IUserInfoDal GetUserInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
        }
	
	
		 public static IVisitorRecordDal GetVisitorRecordDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".VisitorRecordDal") as IVisitorRecordDal;
        }
	
	
		
	}

}