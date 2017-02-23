


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.IDAL
{
    public interface IDbSession
    {
		IActionInfoDal ActionInfoDal { get; }
	

		ICategoryDal CategoryDal { get; }
	

		IContentInfoDal ContentInfoDal { get; }
	

		IFilesInfoDal FilesInfoDal { get; }
	

		IFriendDal FriendDal { get; }
	

		IMessageDal MessageDal { get; }
	

		INewInfoDal NewInfoDal { get; }
	

		IPaityMemberDal PaityMemberDal { get; }
	

		IRoleInfoDal RoleInfoDal { get; }
	

		IStudyItemDal StudyItemDal { get; }
	

		IStudyOnlineDal StudyOnlineDal { get; }
	

		ITemplateDal TemplateDal { get; }
	

		ITopicInfoDal TopicInfoDal { get; }
	

		IUserActionInfoDal UserActionInfoDal { get; }
	

		IUserInfoDal UserInfoDal { get; }
	

		IVisitorRecordDal VisitorRecordDal { get; }
	

		int SaveChanges();
	}
}