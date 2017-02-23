using HNCJ.DY.IBLL;
using HNCJ.DY.Model;
using HNCJ.DY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HNCJ.DY.Web.Controllers.User
{
    [MyActionFilter(IsRoleAction=false,IsAdmin=false)]
    public class MaterialController : BaseController
    {
        //
        // GET: /Material/
        public IUserInfoService UserInfoService { get; set; }
        public IPaityMemberService PaityMemberService { get; set; }
        public IFilesInfoService FilesInfoService { get; set; }
        #region 党员信息
        public ActionResult GetUser()
        {
            int UserID = this.LoginUser.ID;
            var entity = PaityMemberService.GetEntity(u => u.UserInfoID == UserID).FirstOrDefault();
            if (entity == null) {
                entity = new PaityMember();
                entity.RegTime = DateTime.Now;
                entity.ModfiedTime = DateTime.Now;
                entity.UserInfoID = LoginUser.ID;
                PaityMemberService.Add(entity);
            }
            var user =GetHTML(entity);
            var clickdata = GetHTMLdata(entity);
            return Json(new {user=user,user1=clickdata });
        }

        private string GetHTML(PaityMember entity)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(string.Format("<table>"));
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span class='name'>{1}</span></td></tr>", "姓名：", entity.Name));
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span>{1}</span></td></tr>", "性别：", entity.Sex));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span></td></tr>", "出生日期：",entity.Brithday!=null? entity.Brithday.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span>{1}</span></td></tr>", "班号：", entity.ClassNO));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span></td></tr>", "班级职务：", entity.ClassPosition));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span></td></tr>", "入团时间：", entity.StartTime!=null?entity.StartTime.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name8'>{0}</span></td><td><span>{1}</span></td></tr>", "提交申请入党时间：", entity.SubmitTime!=null?entity.SubmitTime.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name8'>{0}</span></td><td><span>{1}</span></td></tr>", "成为预备党员时间：",entity.JoinYLTime!=null?entity.JoinYLTime.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name6'>{0}</span></td><td><span>{1}</span></td></tr>", "党课结业时间：", entity.EndTime!=null?entity.EndTime.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span></td></tr>", "转正时间：", entity.RegularTime!=null?entity.RegularTime.Value.ToString("yyyy年MM月dd日"):""));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span></td></tr>", "联系方式：", entity.Telphone));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span>{1}</span><br><br></td></tr>", "身份证号：", entity.IDCard));
            sb.Append(string.Format(" <tr><td><span class='name4 my-allname'>{0}</span></td><td><p>{1}</p><br><br></td></tr>", "在校奖励：", entity.RewardPunishment));
            sb.Append(string.Format(" <tr><td><span class='name7 my-allname' >{0}</span></td><td><p style='word-break: break-all'>{1}</p><br><br></td></tr>", "挂科科目及原因：", entity.FailedSubject));
            sb.Append(string.Format(" <tr><td><span class='name my-allname'>{0}</span></td><td><p>{1}</p><br><br></td></tr>", "备注：", entity.Remark));
            
            
            sb.Append(string.Format("</table>"));
            return sb.ToString();
        }
        private string GetHTMLdata(PaityMember entity)
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span class='name'><input name='Name' type='text' value={1}></span></td></tr>", "姓名：", entity.Name));
            string str1="",str2="";
            if(!string.IsNullOrEmpty(entity.Sex)){
                str1 = entity.Sex == "女" ? "checked='checked'" : "";
                str2 = entity.Sex == "男" ? "checked='checked'" : "";
            }
            
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span><input style='width: 20px;height: 20px;'  type='radio' value='女' {1} name='Sex'>女"+
                                "<input style='width: 20px;height: 20px;margin-left: 100px' type='radio' value='男' {2} name='Sex'>男</span></td></tr>", "性别：",str1,str2));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='date' value={1} name='Brithday'></span></td></tr>", "出生日期：", entity.Brithday!=null? entity.Brithday.Value.ToString("yyyy-MM-dd"):""));
            sb.Append(string.Format(" <tr><td><span class='name'>{0}</span></td><td><span><input type='text' name='ClassNO' value={1} ></span></td></tr>", "班号：", entity.ClassNO));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='text' name='ClassPosition' value={1} ></span></td></tr>", "班级职务：", entity.ClassPosition));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='date' value={1} name='StartTime'></span></td></tr>", "入团时间：", entity.StartTime!=null? entity.StartTime.Value.ToString("yyyy-MM-dd"):""));
            sb.Append(string.Format(" <tr><td><span class='name8'>{0}</span></td><td><span><input type='date' value={1} name='SubmitTime'></span></td></tr>", "提交申请入党时间：", entity.SubmitTime!=null? entity.SubmitTime.Value.ToString("yyyy-MM-dd"):""));
            sb.Append(string.Format(" <tr><td><span class='name8'>{0}</span></td><td><span><input type='date' value={1} name='JoinYLTime'></span></td></tr>", "成为预备党员时间：", entity.JoinYLTime != null ? entity.JoinYLTime.Value.ToString("yyyy-MM-dd") : ""));
            sb.Append(string.Format(" <tr><td><span class='name6'>{0}</span></td><td><span><input type='date' value={1} name='EndTime'></span></td></tr>", "党课结业时间：", entity.EndTime != null ? entity.EndTime.Value.ToString("yyyy-MM-dd") : ""));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='date' value={1} name='RegularTime'></span></td></tr>", "转正时间：", entity.RegularTime != null ? entity.RegularTime.Value.ToString("yyyy-MM-dd") : ""));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='number' name='Telphone'value={1} ></span></td></tr>", "联系方式：", entity.Telphone));
            sb.Append(string.Format(" <tr><td><span class='name4'>{0}</span></td><td><span><input type='number'name='IDCard'value={1} ></span><br><br></td></tr>", "身份证号：", entity.IDCard));
            sb.Append(string.Format(" <tr><td><span class='name4 my-allname'>{0}</span></td><td><p><textarea class='short' name='RewardPunishment'>{1}</textarea></p><br><br></td></tr>", "在校奖励：", entity.RewardPunishment));
            sb.Append(string.Format(" <tr><td><span class='name7 my-allname' >{0}</span></td><td><p style='word-break: break-all'><textarea class='short' name='FailedSubject'>{1}</textarea></p><br><br></td></tr>", "挂科科目及原因：", entity.FailedSubject));
            sb.Append(string.Format(" <tr><td><span class='name my-allname'>{0}</span></td><td><p><textarea class='short' name='Remark'>{1}</textarea></p><br><br></td></tr>", "备注：", entity.Remark));

            return sb.ToString();
        }
        #endregion

        #region  党员材料
        public ActionResult GetData() {
            var UserID = LoginUser.ID;
            var entity=PaityMemberService.GetEntity(u => u.UserInfoID == UserID).FirstOrDefault();
            if (entity == null)
            {
                entity = new PaityMember();
                entity.RegTime = DateTime.Now;
                entity.ModfiedTime = DateTime.Now;
                entity.UserInfoID = LoginUser.ID;
                PaityMemberService.Add(entity);
            }
            var list = entity.FilesInfo.Where(u => u.DelFlag == true && u.Type == 1).ToList();
            if (list.Count==0) {
                AddFiles(entity.ID);
                list=FilesInfoService.GetEntity(u => u.DelFlag == true && u.Type == 1 && u.PaityMemberID == entity.ID).ToList();
            }
            string html = GetDataHtml(list);
            return Json(html);
        }
        
        private string GetDataHtml(List<FilesInfo> list) {
           
            StringBuilder sb=new StringBuilder();
            sb.Append(string.Format("<table>"));
            sb.Append(string.Format("<tr><th>材料名称</th><th>上传时间</th><th>材料状态</th><th>操作</th><th>操作</th></tr>"));
            foreach (var entity in list) {
                sb.Append(string.Format("<tr>"));
                sb.Append(string.Format("<td>{0}</td>", entity.FileName));
                sb.Append(string.Format("<td align='center'>{0}</td>", entity.Status==1?"":entity.ModfiedTime.Value.ToString("yyyy/MM/dd hh:mm")));
                sb.Append(string.Format("<td align='center'>{0}</td>", IntToString(entity.Status)));
                string func=entity.Status==3?"":"doUpload("+entity.ID+",'"+entity.FilePath+"')";
                string tt = entity.Status == 1 ? "上传" : "重传";
                sb.Append(string.Format("<td align='center'><input type='button' onclick={0} value={1}></td>", func,tt));
                string str = entity.Status == 1 ? "" : "/UserDoAction/DownLoad?path=" + entity.FilePath;
                sb.Append(string.Format("<td align='center'><a href={0} >下载</a></td>", str));
                sb.Append(string.Format("</tr>"));
            }
            sb.Append(string.Format("</table>"));
            return sb.ToString();
        }
        private bool Flag(FilesInfo entity) {
            if (string.IsNullOrEmpty(entity.FilePath)) {
                return false;
            }
            return true;
        }
        private string IntToString(short? i) {
            string str="";
            switch(i){
                case 1: str = "未上传"; break;
                case 2: str = "待审核"; break;
                case 3: str = "审核通过"; break;
                default: str = "未上传"; break;
            }
            return str;
        }
        private void AddFiles(int id) {
            FilesInfo entity = new FilesInfo();
            entity.DelFlag = true;
            entity.FileName = "入党申请书";
            entity.ModfiedTime = DateTime.Now;
            entity.RegTime = DateTime.Now;
            entity.Type = 1;
            entity.Status = 1;
            entity.PaityMemberID = id;
            FilesInfoService.Add(entity);
            entity.FileName = "团员入党推荐表";
            FilesInfoService.Add(entity);
            entity.FileName = "党校结业鉴定表";
            FilesInfoService.Add(entity);
            entity.FileName = "政审材料";
            FilesInfoService.Add(entity);
        }
        #endregion

        #region 思想报告和学习总结
        public ActionResult GetReport() {
            int UserID = LoginUser.ID;
            var entity = PaityMemberService.GetEntity(u => u.UserInfoID == UserID).FirstOrDefault();
            int type = int.Parse(Request["type"] ?? "2");
            var list = entity.FilesInfo.Where(u => u.DelFlag == true && u.Type == type).ToList();
            string html = GetReport(list);
            return Json(html);
        }
        private string GetReport(List<FilesInfo> list) { 
            StringBuilder sb=new StringBuilder();
           
            sb.Append(string.Format("<tr><th style='width:30%'>材料名称</th>"));
            sb.Append(string.Format("<th style='width:25%'>上传时间</th>"));
            sb.Append(string.Format("<th style='width:15%'>材料状态</th>"));
            sb.Append(string.Format("<th style='width:15%'>操作</th>"));
            sb.Append(string.Format("<th style='width:15%'>操作</th></tr>"));
            foreach (var entity in list) {
                sb.Append(string.Format("<tr class='my-report'><td style='width:30%'>{0}</td>", entity.FileName));
                sb.Append(string.Format("<td style='width:25%' align='center'>{0}</td>",entity.ModfiedTime.Value.ToString("yyyy/MM/dd HH:mm")));
                string flag=entity.Status==1?"待审核":"审核通过";
                sb.Append(string.Format("<td style='width:15%'>{0}</td>", flag));
                string del=entity.Status==1?"deleterecord(this,'"+entity.ID+"')":"";
                sb.Append(string.Format("<td style='width:15%'><input type='button' value='删除' onclick={0}></td>",del));
                string str ="/UserDoAction/DownLoad?path=" + entity.FilePath;
                sb.Append(string.Format("<td style='width:15%'><a href={0}>下载</a></td></tr>",str));
            }
            
            return sb.ToString();
        }
        #endregion

        #region 上传图片
        public ActionResult Avatar(string path="") {
            var userinfo=UserInfoService.GetEntity(u => u.ID == LoginUser.ID).FirstOrDefault();
            if (!string.IsNullOrEmpty(path)) {
                userinfo.Icon = path;
                UserInfoService.Update(userinfo);
                userinfo.ModfiedTime = DateTime.Now;
            }
            
            return Json(new { status=1,msg="ok",path=userinfo.Icon});
        }
        #endregion
    }
}
