

$(".dangzhang").css({"background-color":"#b4b3b1"});
/**
 * 党章党纪切换
 */
$(".party-button-bottom .button-one").click(function () {
    $(".button-top").replaceWith('<button class="button-top"><a href="#top-one">回到顶端⬆  </a></button>');
    $(".button-two").css({"background-color":"#a8a7a5","border-radius":"5px","width":"100px","height":"30px","color":"#3c3c3c","scroll-snap-type:":"mandatory","border":"1px solid #adacaa","position":"relative","top":"10px","margin-top":"30px","font-weight":"600","font-size":"20px"});
    $(".button-one").css({"background-color":"#a8a7a5","border-radius":"5px","width":"100px","height":"30px","color":"white","scroll-snap-type:":"mandatory","border":"1px solid #adacaa","position":"relative","top":"10px","margin-top":"30px","font-weight":"600","font-size":"20px"});
    $("#constitution-dangji").hide();
    $("#constitution-content1").show();


})
$(".party-button-bottom .button-two").click(function () {
    $(".button-top").replaceWith('<button class="button-top"><a href="#top-two">回到顶端⬆  </a></button>');
    $(".button-two").css({"background-color":"#a8a7a5","border-radius":"5px","width":"100px","height":"30px","color":"white","scroll-snap-type:":"mandatory","border":"1px solid #adacaa","position":"relative","top":"10px","margin-top":"30px","font-weight":"600","font-size":"20px"});
    $(".button-one").css({"background-color":"#a8a7a5","border-radius":"5px","width":"100px","height":"30px","color":"#3c3c3c","scroll-snap-type:":"mandatory","border":"1px solid #adacaa","position":"relative","top":"10px","margin-top":"30px","font-weight":"600","font-size":"20px"});
    $("#constitution-dangji").show();
    $("#constitution-content1").hide();

})
//页内滚动

$("div").scroll(function () {

    var this_scrollTop = $(this).scrollTop();
    if (this_scrollTop >= $("#dang1").offset().top) {
        $(".constitution-box").css({"background":"#eff2c7","padding":"10px","width":"95%","height":"90%","overflow-x":"hidden","overflow-y":"auto","scroll-snap-type:":"mandatory","line-height":"20px","margin-top":"0px","z-index":"-1"});
        $(".button-top").show();
    } else {
        $(".constitution-box").css({"background":"#eff2c7","padding":"10px","width":"95%","height":"90%","overflow-x":"hidden","overflow-y":"auto","scroll-snap-type:":"mandatory","line-height":"20px","margin-top":"20px","z-index":"-1"});
        $(".button-top").hide();
    }

})


