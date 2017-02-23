/**
 * Created by Administrator on 2016/11/27.
 */

$(".myTalk").on("click",function () {
    $("#myTalk-learn").show();

})
function Request(strName) {
    var strHref = window.document.location.href;
    var intPos = strHref.indexOf("?");
    var strRight = strHref.substr(intPos + 1);

    var arrTmp = strRight.split("&");
    for (var i = 0; i < arrTmp.length; i++) {
        var arrTemp = arrTmp[i].split("=");

        if (arrTemp[0].toUpperCase() == strName.toUpperCase()) {
            var s = arrTemp[1];
            var ff = s.split("#");
            return ff[0];
        }
    }
    return "";
}

learnRight();
function learnRight() {
    //var learn = ["三严三实学习资料","两学一做","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题"];
    $.post("/LearnData/GetAllLearns", {type:1 }, function (data) {
        var learn = data;
        for (var i = 0; i < learn.length ; i++) {
            var myLearn = '';
            myLearn = '<div class="right-title"><a href="learndetail.html?id='+learn[i].ID+'">' + learn[i].Name + ' </a></div>';
            document.getElementById("right-content").innerHTML += myLearn;
        }
    });
    
}

talk("",0);
function talk(page,id) {
    //var talk = [
    //    ["../../../img/but1.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but5.jpg","两学一做"],["../../../img/but7.jpg","我是评论内容"],["../../../img/but6.jpg","我是评论内容"],["../../../img/but5.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but8.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but1.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but4.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but5.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but6.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but1.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but6.jpg","我是评论内容我是评论内容我是评论"]
    //];
    if(id==0) id = Request("id");
    if (page == "") page=1;
    $.post("/LearnData/GetStudyItems", { key: id, page: page, rows: 10 }, function (data) {
        var talk = data.datas;
        $("#other-talking").empty();
        
        for (var i = 0; i < talk.length ; i++) {
            var myTalk = '';
            myTalk = '<div id="other-talk"><img src="' + talk[i].Icon + '" alt=""> <div class="talk-content-bottom"> <p class="talk-one"></p> <div class="talk-content">' + talk[i].Context + '</div> </div></div>';
            $("#other-talking").append(myTalk);
        }
        $("#pag").empty();
        $("#pag").append(data.str);
        $("#title").empty();
        $("#title").append(data.Title);
        $("#contentdata").empty();
        $("#contentdata").append(data.Content);
    });
}

function Click() {
    var id=Request("id");
    var content=$("#content").val();
    if(content=="")return;
    $.post("/LearnData/Add", { id: id, content: content }, function (data) {
        if (data.status == 1) {
            talk("", id);
        } else {
            alert("出错了");
        }
    });
}

function OnClick() {
    var id = Request("id");
    $.post("/LearnData/ClickZan1", { id: id }, function (data) {
        if (data.status == 1) {
            $("#zan").empty();
            $("#zan").append("<span style='color:#0ff;' >已赞</span>");
        } else {
            alert("出错了");
        }
    });
}