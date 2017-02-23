/**
 * Created by Administrator on 2016/12/14.
 */

$(".myTalk").on("click",function () {
    $("#myTalk-learn").show();

})

talk();
function talk() {
    var talk = [
        ["../../../img/but1.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but5.jpg","两学一做"],["../../../img/but7.jpg","我是评论内容"],["../../../img/but6.jpg","我是评论内容"],["../../../img/but5.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but8.jpg","我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容我是评论内容"],["../../../img/but1.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but4.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but5.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but6.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but1.jpg","我是评论内容我是评论内容我是评论"],["../../../img/but6.jpg","我是评论内容我是评论内容我是评论"]
    ];
    for(var i = 0; i<talk.length ; i++){
        var myTalk = '';
        myTalk = '<div id="other-talk"><img src="'+talk[i][0]+'" alt=""> <div class="talk-content-bottom"> <p class="talk-one"></p> <div class="talk-content">'+talk[i][1]+'</div> </div></div>';
        document.getElementById("other-talking").innerHTML += myTalk;
    }
}
