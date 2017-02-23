
//私信
$(".myFriend li").on("click",function () {
    var index = $(this).attr("value");
    $(".all-myFriend").hide();
    $(".select-myFriend1").hide();
    $(".select-myFriend1").eq(index-1).show();
    $(".all-myFriend").eq(index-1).show();
})

myAdd();
function myAdd() {
    $.post("/Friend/GetFriends", { id: 1 }, function (data) {
        var myArr = data.list;
        $("#myFriend-bottom").empty();
        for (var i = 0; i < myArr.length; i++) {
            
            var myFrds = '';
            myFrds = '<a href="#" onclick="ClickUser(' + myArr[i].ID + ')"><div class="myFriend-one">' +
                '<img src="' + myArr[i].Icon+ '">' +
                '<div class="myFriend-name"><div class="Friend-name">' +
                '<p>' + myArr[i].UserName + '</p></div><div class="name">' +
                '<div class="time">' + datetimeDate(myArr[i].ModfiedTime) + '</div></div>' +
                '</div></div></a>';
            $("#myFriend-bottom").append(myFrds);
        }
    });
}

function ClickUser(id) {
    $.post("/Friend/GetUsers", { id: id }, function (data) {

        $("#users").empty();
        $("#users").append(data.user);
        $("#other-talking").empty();
        $("#other-talking").append(data.message);
    });
}

function Message() {
    var msg = $("#searchkey").val();
    var id = $("#user").val();
    if (msg == "") return;
    $.post("/friend/AddMessage", { Msg: msg, RecipientID: id }, function (data) {
        if (data.status == 1) {
            $("#searchkey").val('');
            ClickUser(id);
        } else {
            alert("成功");
        }
    });
}
function datetimeDate(value) {
    if (value == null) return null;
    return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("M-d H:m:s");
}
$(function () {
    setInterval("myAll()", 3000);
    setInterval(function () {
        var id = $("#user").val();
        if (id == "") id = 0;
        $.post("/Friend/GetUsers", { id: id }, function (data) {


            $("#Meassage").empty();
            $("#Meassage").append(data.message);
        });
    }, 2000);
});
myAll();
function myAll() {


    $.post("/friend/GeTNoReadMessage", function (data) {
        $("#myFriend-bottom2").empty();
        $("#myFriend-bottom2").append(data);
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

