/**
 * Created by Administrator on 2016/11/22.
 */
/**
 * 导航实现
 */
(function () {
    $(window).scroll(function () {
        if($(window).scrollTop() >= 10){
            $(".nav_bottom").css({"background":"rgba(255,255,255,0.8)" });
        }else {
            $(".nav_bottom").css({"background-color":""});
        }

    })

}());
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

Add(1,0);
function Add(pageIndex, sort) {
    //var Arr = [
    //    ["忧伤的豆豆", "../../../img/but1.jpg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "1楼", "../../../img/talk.png"],
    //    ["上树的小猪", "../../../img/but4.jpg", "lv7", "二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？二楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "2楼", "../../../img/talk.png"],
    //    ["噜啦啦。。", "../../../img/but6.jpg", "lv17", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "3楼", "../../../img/talk.png"],
    //    ["尊尊czz", "../../../img/but8.jpg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "4楼", "../../../img/talk.png"],
    //    ["小奶包", "../../../img/but3.jpeg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "5楼", "../../../img/talk.png"],
    //    ["陈斌", "../../../img/but5.jpg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "6楼", "../../../img/talk.png"],
    //    ["周大牛", "../../../img/but2.jpeg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "7楼", "../../../img/talk.png"],
    //    ["阳光", "../../../img/but7.jpg", "lv7", "一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？一楼说的啥？", "8楼", "../../../img/talk.png"]
    //]
    var id=Request("id");
    $.post("/TalkData/TalkData1", { pageIndex: pageIndex, sort: sort, TopID: id }, function (data) {
        var Arr = data.list;
        $("#com-talkDetail-bottom").empty();
        for (var i = 0,j=1; i < Arr.length; i++,j++) {
            
            var myCom = '';
            myCom = '<div class="com-talkDetail">' +
                '<div class="com-talkDetail-title">' +
                '<div class="com-talkDetail-a">' +
                '<a href=" ">' +
                '<img src="' + Arr[i].Icon + '">' +
                '</a>' +
                '<a href=" ">' +
                '<div class="name-lv-talkDetail">' +
                '<h3>' + Arr[i].UserName + '</h3>' +
                '<p>lv1</p>' +
                '</div></a></div>' +
                '<div class="number-com-talkDetail">' +
                '<img src="../../../img/talk.png">' +
                '<p>' + j + '楼</p>' +
                '</div></div>' +
                '<div class="talkDetail-left-com">' +
                '<p>' + Arr[i].Content + '</p></div></div>';
            $("#com-talkDetail-bottom").append(myCom);
        }
        $("#pag").empty();
        $("#pag").append(data.str);
    });
}

function huitie() {
    var id = Request("id");
    var content = $("#cache").val();
    if (content == "") return;
    $.post("/TalkData/talkhuitie", { id: id, content: content }, function (data) {
        if (data.status == 1) {
            Add(1, 0);
        } else {
            alert("出错了");
        }
    })
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
    $.focusblur("#cache");
});
//回到顶部
 $(".talkDetail-up").click(function () {
     //速度
     var speed = 200;
     $('body').animate({scrollTop:0},speed);
     return false;
 });
$(document).ready(function () {
    $(".talkDetail-up p").hide();

$(".talkDetail-up").hover(function () {
    $(".talkDetail-up p").show();
    $(".talkDetail-up p").css({"width": "100px","font-size": "20px","margin-left": "30px","color": "#ff9f26","font-weight": "600"})
},function () {
    $(".talkDetail-up p").css({"width": "100px","font-size": "20px","margin-left": "30px","color": "#ff9f26","font-weight": "600"}).hide();
})
})