$(document).ready(function () {
    $.post("/UserDoAction/Check_login", function (data) {
        if (data.status != 1) {
            window.location.href = "/Content/bigdatalogin/bigdatalogin.html";
        } 
    });
});
GetUserInfo();
function GetUserInfo() {
    $.post("/talkdata/GetUserInfo", function (data) {
        $("#getuser").empty();
        $("#getuser").append(data.user);
        if (data.Icon != "") {
            $("#userimg").attr('src',data.Icon)
        }
    });

}
