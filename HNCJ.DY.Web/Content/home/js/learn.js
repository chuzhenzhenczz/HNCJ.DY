/**
 * Created by Administrator on 2016/11/21.
 */


$(".zongbu").css({ "background-color": "#b4b3b1" });
//资料切换
//$(".menu-upFiles li").on("click",function () {
//    var index = $(this).attr("value");
//    $(".study-upFiles").hide();
//    $(".study-upFiles").eq(index-1).show();
//})

//阅读资料
read();
function read() {
    
    $.post("/learndata/GetAllLearns", { type: 1, size: 16 }, function (data) {
        var myread = data;
        for (var i = 0 ; i < myread.length; i++) {
            var myRead = "";
            myRead = ' <div id="left-title-bottom"><div class="files-left-title">' +
                '<div class="files-title">' +
                '<img src="../../img/资料.png" alt="">' +
                '<p><a href="template/learndetail.html?id=' + myread[i].ID + '">' + myread[i].Name + '</a></p>' +
                '</div></div>' +
                '<div class="files-right-title"> ' +
                '<div class="files-title">' +
                '<img src="../../img/资料.png" alt=""> ' +
                '<p><a href="template/learndetail.html?id=' + myread[i].ID + '">' + myread[++i].Name + '</a></p> ' +
                '</div> </div>';
            document.getElementById("online-files-left").innerHTML += myRead;
        }
    });
}

study();
function study() {
    
    $.post("/learndata/GetAllLearns",{type: 2,size:8},function(data){
        var myStudy = data;
        for(var i = 0 ; i <myStudy.length; i++){
            var Study = "";
            Study = '<div class="vital-study-title">' +
                '<img src="../../img/资料%20(3).png" alt="">' +
                '<a href="template/learndetail.html?id='+myStudy[i].ID+'">'+myStudy[i].Name+'</a>' +
                '</div>';
            document.getElementById("vital-study-bottom").innerHTML += Study;
        }
    
    })
    
}


//视频
video();
function video() {
   
    $.post("/learndata/GetAllVedios", { type: 1, size: 16 }, function (data) {
        var myread = data;
        for (var i = 0 ; i < myread.length; i++) {
            var myRead = "";
            myRead = ' <div id="left-title-bottom2"><div class="files-left-title">' +
                '<div class="files-title">' +
                '<img src="../../img/资料.png" alt="">' +
                '<p><a href="template/learndetail-Video.html?id=' + myread[i].ID + '">' + myread[i].Name + '</a></p>' +
                '</div></div>' +
                '<div class="files-right-title"> ' +
                '<div class="files-title">' +
                '<img src="../../img/资料.png" alt=""> ' +
                '<p><a href="template/learndetail-Video.html?id=' + myread[i].ID + '">' + myread[++i].Name + '</a></p> ' +
                '</div> </div>';
            document.getElementById("online-files-left2").innerHTML += myRead;
        }
    });


}
study2();
//function fun(url, data, fund) {
//    $.post(url, data, function (data) {
//        fund(data);
//    });
//}
//fun("/learndata/GetAllVedios", { type: 2, size: 8 }, study2);
function study2() {
    
    $.post("/learndata/GetAllVedios", { type: 2, size: 8 }, function (data) {
        var myStudy = data;
        for (var i = 0 ; i < myStudy.length; i++) {
            var Study = "";
            Study = '<div class="vital-study-title">' +
                '<img src="../../img/资料%20(3).png" alt="">' +
                '<a href="template/learndetail-Video.html?id=' + myStudy[i].ID + '">' + myStudy[i].Name + '</a>' +
                '</div>';
            document.getElementById("vital-study-bottom2").innerHTML += Study;
        }

    })
    
}
swiper();
function swiper() {

var swiper = new Swiper('.swiper-container', {
    autoplay:2000,
    pagination: '.swiper-pagination',
    effect: 'coverflow',
    grabCursor: true,
    centeredSlides: true,
    slidesPerView: 'auto',
    coverflow: {
        rotate: 50,
        stretch: 0,
        depth: 100,
        modifier: 1,
        slideShadows : true
    }
});

}
