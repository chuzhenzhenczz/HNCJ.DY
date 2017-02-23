$(".benbu").css({ "background-color": "#b4b3b1" });
function fun(url, data, fund) {
    $.post(url, data, function (data) {
        fund(data);
    });
}
//阅读资料
fun("/learndata/GetAllLearns", { type: 3, size: 16 }, read);
function read(data) {
    //myread = [
    //    ["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","党章学习资料"],["../../img/资料.png","两学一做学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","党章学习资料"],["../../img/资料.png","两学一做学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"]
    //];
    //myread1 = [
    //    ["../../img/资料.png","党章学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","党章学习资料"],["../../img/资料.png","两学一做学习资料"],["../../img/资料.png","党章学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","党章学习资料"],["../../img/资料.png","两学一做学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"],["../../img/资料.png","三严三实学习资料"]
    //];
    var myread = data;
    for(var i = 0 ; i < myread.length; i++){
        var myRead = "";
        myRead = ' <div id="left-title-bottom3"><div class="files-left-title">' +
            '<div class="files-title">' +
            '<img src="../../../img/资料.png" alt="">' +
            '<p><a href="learndetail.html?id=' + myread[i].ID + '">' + myread[i].Name + '</a></p>' +
            '</div></div>' +
            '<div class="files-right-title"> ' +
            '<div class="files-title">' +
            '<img src="../../../img/资料.png" alt=""> ' +
            '<p><a href="learndetail.html?id=' + myread[i].ID + '">' + myread[++i].Name + '</a></p> ' +
            '</div> </div></div>';
        document.getElementById("online-files-left3").innerHTML += myRead;
    }
}
fun("/learndata/GetAllLearns", { type: 4, size: 8 }, study);
function study(data) {
   
    var myStudy = data;
    for(var i = 0 ; i <myStudy.length; i++){
        var Study = "";
        Study = '<div class="vital-study-title">' +
            '<img src="../../../img/资料%20(3).png" alt="">' +
            '<a href="learndetail.html?id=' + myStudy[i].ID + '">' + myStudy[i].Name + '</a>' +
            '</div>';
        document.getElementById("vital-study-bottom3").innerHTML += Study;
    }
}
//视频
fun("/learndata/GetAllVedios", { type: 3, size: 16 }, video);
function video(data) {
    
    var myread = data;
    for(var i = 0 ; i < myread.length; i++){
        var myRead = "";
        myRead = ' <div id="left-title-bottom4"><div class="files-left-title">' +
            '<div class="files-title">' +
            '<img src="../../../img/资料.png" alt="">' +
            '<p><a href="learndetail-Video.html?id=' + myread[i].ID + '">' + myread[i].Name + '</a></p>' +
            '</div></div>' +
            '<div class="files-right-title"> ' +
            '<div class="files-title">' +
            '<img src="../../../img/资料.png" alt=""> ' +
            '<p><a href="learndetail-Video.html?id=' + myread[i].ID + '">' + myread[i].Name + '</a></p> ' +
            '</div> </div></div>';
        document.getElementById("online-files-left4").innerHTML += myRead;
    }



}
fun("/learndata/GetAllVedios", { type: 4, size: 8 }, study2);
function study2(data) {
    
    var myStudy = data;
    for(var i = 0 ; i <myStudy.length; i++){
        var Study = "";
        Study = '<div class="vital-study-title">' +
            '<img src="../../../img/资料%20(3).png" alt="">' +
            '<a href="learndetail-Video.html?id=' + myStudy[i].ID + '">' + myStudy[i].Name + '</a>' +
            '</div>';
        document.getElementById("vital-study-bottom4").innerHTML += Study;
    }
}
