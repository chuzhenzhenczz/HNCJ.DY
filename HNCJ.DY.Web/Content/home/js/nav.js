/**
 * Created by Administrator on 2016/11/27.
 */
/**
 * 导航实现
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
