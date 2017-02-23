avatar();
function avatar() {
    $.post("/material/Avatar",{path:""}, function (data) {
        $("#avatar").empty();
        $("#avatar").append("<img src="+data.path+" style='height:170px;width:150px;' />");
    });
}
function UploadAvatar() {
    var path = $("#avatar").attr('src');
    // 上传方法
    $.upload({
        // 上传地址
        url: '/UserDoAction/UploadImage',
        // 文件域名字
        fileName: 'Filedata',
        // 其他表单数据
        params: { name: path },
        // 上传完成后, 返回json, text
        dataType: 'json',
        // 上传之前回调,return true表示可继续上传
        onSend: function () {
            return true;
        },
        // 上传之后回调
        onComplate: function (data) {
            $.post("/material/Avatar", { path: data.path }, function (datas) {
                avatar();
            });
        }
    });
}