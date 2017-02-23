$(document).ready(function () {
    $.post("/UserDoAction/Check_login", function (data) {
        if (data.status != 1) {
            window.location.href = "/Content/bigdatalogin/bigdatalogin.html";
        } 
    });
});

