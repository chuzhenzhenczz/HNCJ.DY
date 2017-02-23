access();
function access() {
    var id=Request("id");
    $.post("/VisitorRecord/Add", { UserID: id }, function (data) {
        
    });
}
function addfriend() {
    var id = Request("id");
    $.post("/friend/addfriend", { FriendID: id }, function (data) {
        if (data.status == 0) {
            alert(data.msg);
            closeit();
           
        }
    });
}

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
//他人主页的帖子
add(1);
function add(index) {
    var id = Request("id");
    $.post("/talkdata/OtherIndex", { id: id,index:index}, function (data) {
        var arr = data.tip;
        $("#icon").attr('src', data.icon);
        $("#year").empty();
        $("#year").append(data.year);
        $("#length").empty();
        $("#length").append(data.length);
        $("#count").empty();
        $("#count").append(data.count);
        $("#count1").empty();
        $("#count1").append(data.count);
        $("#name").empty();
        $("#name").append(data.name);
        $("#name1").empty();
        $("#name1").append(data.name);
        $("#post-other").empty();
        $("#page").empty();
        $("#page").append(data.html);
        for (var i = 0; i < arr.length; i++) {
            var Div = "";
            Div = '<div class="myPosts-div"> <div class="myPosts"> <h3>' + arr[i].Title + '</h3> <p>' + arr[i].Content.substring(0, 30) + '</p> </div> <div class="myPosts-com"> <img src="../../img/talk.png" alt=""> <p class="myPosts-time">' + arr[i].time + '</p> <p class="myPosts-newCom">最新回复</p> <p class="myPosts-number">' + arr[i].count + '楼</p> <p class="newCom-name">赞</p> </div> </div>';
            $("#post-other").append(Div);

        }
    });

   
}