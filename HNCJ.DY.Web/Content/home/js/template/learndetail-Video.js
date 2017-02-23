/**
 * Created by Administrator on 2016/12/14.
 */
videoRight();
function videoRight() {
    var video = ["三严三实学习资料","两学一做","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题","我是推荐标题"];

    for(var j = 0; j<video.length ; j++){
        var myvideo = '';
        myvideo = '<div class="right-title"><a href="learndetail-Video.html">'+video[j]+' </a></div>';
        document.getElementById("right-content-Video").innerHTML += myvideo;
    }
}
