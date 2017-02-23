using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.IBLL
{
		public partial interface IActionInfoService:IBaseService<ActionInfo>
		{
		IQueryable<ActionInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface ICategoryService:IBaseService<Category>
		{
		IQueryable<Category> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IContentInfoService:IBaseService<ContentInfo>
		{
		IQueryable<ContentInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IFilesInfoService:IBaseService<FilesInfo>
		{
		IQueryable<FilesInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IFriendService:IBaseService<Friend>
		{
		IQueryable<Friend> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IMessageService:IBaseService<Message>
		{
		IQueryable<Message> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface INewInfoService:IBaseService<NewInfo>
		{
		IQueryable<NewInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IPaityMemberService:IBaseService<PaityMember>
		{
		IQueryable<PaityMember> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IRoleInfoService:IBaseService<RoleInfo>
		{
		IQueryable<RoleInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IStudyItemService:IBaseService<StudyItem>
		{
		IQueryable<StudyItem> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IStudyOnlineService:IBaseService<StudyOnline>
		{
		IQueryable<StudyOnline> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface ITemplateService:IBaseService<Template>
		{
		IQueryable<Template> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface ITopicInfoService:IBaseService<TopicInfo>
		{
		IQueryable<TopicInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IUserActionInfoService:IBaseService<UserActionInfo>
		{
		IQueryable<UserActionInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IUserInfoService:IBaseService<UserInfo>
		{
		IQueryable<UserInfo> LoagPageData(BaseParam queryParam);

		}
		

		public partial interface IVisitorRecordService:IBaseService<VisitorRecord>
		{
		IQueryable<VisitorRecord> LoagPageData(BaseParam queryParam);

		}
		

	
}