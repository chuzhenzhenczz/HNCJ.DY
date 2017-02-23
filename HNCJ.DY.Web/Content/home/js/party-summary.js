/***
 * 上传思想汇报，添加文件
 */
//删除文件

function deleterecord(oj,id){
    oj.parentElement.parentElement.remove();
    $.post("/filesinfo/delete", { id: id }, function (data) { });
}
summary();
function summary() {
    $.post("/material/GetReport", { type: 3 }, function (data) {
        $("#my-party-summary").empty();
        $("#my-party-summary").append(data);

    });
}
//防止按钮频繁点击；
xiugai();
function xiugai() {

    var clicktag = 0;

    $('.reports').click(function () {
        if (clicktag == 0) {
            clicktag = 1;
            $(this).addClass("action");
            setTimeout(function () { clicktag = 0 }, 500);
        }
    });
    setTimeout(function () { clicktag = 0 }, 500);
}


