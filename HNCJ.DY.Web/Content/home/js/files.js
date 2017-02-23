
//左侧导航

(function () {
    $(window).scroll(function () {
        var m = document.body.clientWidth;
            if($(window).scrollTop() >= 300 &&m>=980){

            $(".content-left").css({"width":"250px" ,"background-color":"#fffbe6" ,"height":"600px" ,"position":"fixed" ,"margin":"-300px auto" });
        }else {
            $(".content-left").css({"width":"250px" ,"background-color":"#fffbe6" ,"height":"600px" ,"position":"absolute" ,"margin":"30px auto" });        }

    })

}());
fun();
function fun() {
    $.post("/Material/Getuser", function (data) {
        $("#dd").empty();
        $("#dd").append(data.user);
        $("#tt").empty();
        $("#tt").append(data.user1);
    });
}

//防止按钮频繁点击；
xiugai();
function xiugai() {

    var clicktag = 0;

    $('.actions').click(function () {
        $('.my-message2').show();
        $('.my-message1').hide();
        if (clicktag == 0) {
            clicktag = 1;
            $(this).addClass("action");
            $(".actions").replaceWith(' <input class="actions" value="点击返回" type="button">');
            $('.actions').click(function () {
                $('.my-message1').show();
                $('.my-message2').hide();
                if (clicktag == 0) {
                    clicktag = 1;
                    $(this).addClass("action");
                    $(".actions").replaceWith(' <input class="actions" value="点击修改" type="button">');

                    xiugai();
                    setTimeout(function () { clicktag = 0 }, 500);
                }
            });
            setTimeout(function () { clicktag = 0 }, 500);
        }
    });


}