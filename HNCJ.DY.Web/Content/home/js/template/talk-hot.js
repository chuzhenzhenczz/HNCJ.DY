
//热帖
//热帖
add(1, 0);
function add(pageIndex, sort) {
    if (pageIndex == "") pageIndex = 1;
    $.post("/talkdata/talkdata1", { pageIndex: pageIndex, sort: sort }, function (data) {
        $("#pag").empty();
        $("#pag").append(data.str);
        $("#user-talk-content").empty();
        $("#user-talk-content").append(data.str1);

    });
}
function good(obj, id) {
    $.post("/TalkData/Onclick", { Tid: id }, function (data) {
        obj.replaceWith('<img class="user-img2" src="../../../img/zan2.png">');

    });
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

