
myPost();
function myPost(index) {
    if (index == "") index = 1;
    $.post("/TalkData/GuanZhu", { pageIndex: index }, function (data) {
        var Post = data.list;
        $("#myPosts-table").empty();
        for (var i = 0; i < Post.length; i++) {

            var myPosts = '';
            myPosts = '<tr class="myPosts-tr">' + '<td><div><a href="template/talkdetail.html?id=' + Post[i].ID + '">' + Post[i].Title + '</a></div></td>' + '<td><a href="template/talkdetail.html">' + datetimes(Post[i].RegTime) + '</a></td>' + '<td><div><a href="template/talkdetail.html">' + Post[i].Content + '</a></div></td>' + '</tr>';
            $("#myPosts-table").append(myPosts);
        }
        $("#pag").empty();
        $("#pag").append(data.str);
    });

}
function datetimes(value) {
    if (value == null) return null;
    return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d");
}
