
//发帖
function talkadd() {
    var content = $("#talkcontent").val();
    var title = $("#talktitle").val();
    if (content == "" && title == "") return;
    $.post("/TalkData/talkadd", { title: title, content: content }, function (data) {
        if (data.status == 1) {
            mytalk(1);
            $("#talkcontent").val('');
            $("#talktitle").val('');
        } else {
            alert("出错了");
        }
    });
}
//我的帖子
mytalk(1);
function mytalk(index) {
    $.post("/TalkData/MyTalk", { pageIndex: index }, function (data) {
        $("#talk").empty();
        var link = data.list;

        for (var i = 0; i < link.length; i++) {
            var str = '<div class="myPosts-div"><a href="talkdetail.html?id=' + link[i].ID + '"><div class="myPosts">' + '<h3>' + link[i].Title + '</h3>'
            + '<p>' + link[i].Content + '</p></div></a> <div class="myPosts-com"><img src="../../../img/talk.png" alt="">' +
            '<p class="myPosts-time">' + datetimes(link[i].RegTime) + '</p><p class="myPosts-newCom">最新回复</p>' +
            '<p class="myPosts-number">' + link[i].Count + '楼</p><p class="newCom-name"><a href="#"  onclick="deleteTalk(' + link[i].ID + ')">删除</a></p></div></div>';
            $("#talk").append(str);
        }
        $("#pag").empty();
        $("#pag").append(data.str);
    });
}

function deleteTalk(id) {
    $.post("/TalkData/DeleteTalk", { id: id }, function (data) {
        if (data.status == 1) {
            mytalk(1);

        } else {
            alert("出错了");
        }
    });
}
function datetimes(value) {
    if (value == null) return null;
    return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d");
}

//焦点
$(document).ready(function(){
//focusblur
    jQuery.focusblur = function(focusid) {
        var focusblurid = $(focusid);
        var defval = focusblurid.val();
        focusblurid.focus(function(){
            var thisval = $(this).val();
            if(thisval==defval){
                $(this).val("");
            }
        });
        focusblurid.blur(function(){
            var thisval = $(this).val();
            if(thisval==""){
                $(this).val(defval);
            }
        });
    };
    /*下面是调用方法*/
    $.focusblur("#searchkey");
});



