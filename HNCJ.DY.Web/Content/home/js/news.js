/**
 * Created by Administrator on 2016/12/12.
 */

mynews();
function DataNews(url, dataType, strName) {
    $.post(url, { id: dataType }, function (data) {
       var News1 = data;
        for (var i = 0; i < News1.length; i++) {
            var myNews1 = '';
            myNews1 = '<li><a href="template/newsDetail.html?id=' + News1[i].ID + '">' + News1[i].Title + '</a></li>';
            document.getElementById(strName).innerHTML += myNews1;
        }
    });

}

function mynews() {
    DataNews("/NewsData/NewsDatas", 1, "zuzhi");  
    DataNews("/NewsData/NewsDatas", 2, "fanfu");
    DataNews("/NewsData/NewsDatas", 3, "yaoyan");
    DataNews("/NewsData/NewsDatas", 4, "lilun");
    DataNews("/NewsData/NewsDatas", 5, "jiceng");
    DataNews("/NewsData/NewsDatas", 6, "dangshi");
    DataNews("/NewsData/NewsDatas", 7, "dangjian");

}
