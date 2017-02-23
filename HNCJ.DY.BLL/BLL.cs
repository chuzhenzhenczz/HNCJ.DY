using HNCJ.DY.DalFactory;
using HNCJ.DY.IBLL;
using HNCJ.DY.IDAL;
using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.BLL
{
		
	public partial class ActionInfoService:BaseService<ActionInfo>,IActionInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.ActionInfoDal;
			}
	}

		
	public partial class CategoryService:BaseService<Category>,ICategoryService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.CategoryDal;
			}
	}

		
	public partial class ContentInfoService:BaseService<ContentInfo>,IContentInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.ContentInfoDal;
			}
	}

		
	public partial class FilesInfoService:BaseService<FilesInfo>,IFilesInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.FilesInfoDal;
			}
	}

		
	public partial class FriendService:BaseService<Friend>,IFriendService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.FriendDal;
			}
	}

		
	public partial class MessageService:BaseService<Message>,IMessageService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.MessageDal;
			}
	}

		
	public partial class NewInfoService:BaseService<NewInfo>,INewInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.NewInfoDal;
			}
	}

		
	public partial class PaityMemberService:BaseService<PaityMember>,IPaityMemberService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.PaityMemberDal;
			}
	}

		
	public partial class RoleInfoService:BaseService<RoleInfo>,IRoleInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.RoleInfoDal;
			}
	}

		
	public partial class StudyItemService:BaseService<StudyItem>,IStudyItemService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.StudyItemDal;
			}
	}

		
	public partial class StudyOnlineService:BaseService<StudyOnline>,IStudyOnlineService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.StudyOnlineDal;
			}
	}

		
	public partial class TemplateService:BaseService<Template>,ITemplateService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.TemplateDal;
			}
	}

		
	public partial class TopicInfoService:BaseService<TopicInfo>,ITopicInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.TopicInfoDal;
			}
	}

		
	public partial class UserActionInfoService:BaseService<UserActionInfo>,IUserActionInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.UserActionInfoDal;
			}
	}

		
	public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.UserInfoDal;
			}
	}

		
	public partial class VisitorRecordService:BaseService<VisitorRecord>,IVisitorRecordService
	{
		public override void SetCurrentDal()
			{
				CurretDal = DbSession.VisitorRecordDal;
			}
	}

	
}