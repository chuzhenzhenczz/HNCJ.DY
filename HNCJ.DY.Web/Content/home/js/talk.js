
$(".menu-files li").on("click",function () {
    var index = $(this).attr("value");
    $(".div5").hide();
    $(".div5").eq(index-1).show();
})
//热帖

myLove();
function myLove() {
    //var myArr = [
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"],
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"],
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"],
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"],
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"],
    //    ["../../img/爱心.png", "我是帖子标题我是帖子标题我是帖子标题"]
    //]

    //for (var i = 0; i < myArr.length; i++) {
    //    var myPost = '';
    //    myPost = '<div class="ad-post"> <img src="'+myArr[i][0]+'" alt=""> <span class="add">'+myArr[i][1]+' </span> </div>';
    //    document.getElementById("post-title").innerHTML += myPost;
    //}
    $.post("/talkdata/index", function (data) {
        $("#post-title").empty();
        $("#icon").attr('src', data.icon);
        $("#year").append(data.year);
        $("#count").append(data.count);
        $("#name").append(data.name);
        var myArr = data.tip;
        for (var i = 0; i < myArr.length; i++) {
            var myPost = '';
            myPost = '<a href="template/talkdetail.html?id='+myArr[i].ID+'"><div class="ad-post"> <img src="../../img/爱心.png" alt=""> <span class="add">' + myArr[i].Title + ' </span> </div></a>';
            $("#post-title").append(myPost);
        }

    });

}

