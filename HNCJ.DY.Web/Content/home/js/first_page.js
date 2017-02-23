/**
 * Created by qingyun on 16/10/16.
 */
(function () {
    $(window).scroll(function () {

        if($(window).scrollTop() >= 10){
            $(".nav_bottom").css({"background":"rgba(255,255,255,0.8)" });
        }else {
            $(".nav_bottom").css({"background-color":""});
        }

    })

}());

$(document).ready(function () {

    $(".title_one_word").hover(function () {
        $(".title_one_word p").show();
        $(".title_one_word p").css({"line-height":"300px","font-size":"30px","font-family":"PingFang SC","color":"white"})
    },function () {
        $(".title_one_word p").css({"line-height":"300px","font-size":"30px","font-family":"PingFang SC","color":"white"}).hide();
    })
})

$(document).ready(function () {

    $(".title_one_means").hover(function () {
        $(".title_one_means p").show();
        $(".title_one_means p").css({"line-height":"600px","font-size":"30px","font-family":"PingFang SC","color":"white"})
    },function () {
        $(".title_one_means p").css({"line-height":"600px","font-size":"30px","font-family":"PingFang SC","color":"white"}).hide();
    })
})
$(document).ready(function () {

    $(".title_one_study").hover(function () {
        $(".title_one_study p").show();
        $(".title_one_study p").css({"line-height":"200px","font-size":"30px","font-family":"PingFang SC","color":"white"})
    },function () {
        $(".title_one_study p").css({"line-height":"200px","font-size":"30px","font-family":"PingFang SC","color":"white"}).hide();

    })
})