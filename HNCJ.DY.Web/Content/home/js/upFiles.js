/**
 * Created by Administrator on 2016/11/21.
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
/***
 * 搜索框
 * @param obj
 * @param evt
 */
function searchToggle(obj, evt){
    var container = $(obj).closest('.search-wrapper-upFiles');

    if(!container.hasClass('active')){
        container.addClass('active');
        evt.preventDefault();
    }
    else if(container.hasClass('active') && $(obj).closest('.input-holder-upFiles').length == 0){
        container.removeClass('active');
        // clear input
        container.find('.search-input-upFiles').val('');
        // clear and hide result container when we press close
        container.find('.result-container-upFiles').fadeOut(100, function(){$(this).empty();});
    }
}

function submitFn(obj, evt){
    value = $(obj).find('.search-input-upFiles').val().trim();

    _html = "您搜索的关键词： ";
    if(!value.length){
        _html = "关键词不能为空。";
    }
    else{
       // window.location.href="template/searchDetail-upFiles.html";
        // _html += "<b>" + value + "</b>";
        upFiles(1,value);
    }

    $(obj).find('.result-container-upFiles').html('<span>' + _html + '</span>');
    $(obj).find('.result-container-upFiles').fadeIn(100);

    evt.preventDefault();
}

upFiles(1,'');
function datetimes(value) {
    if (value == null) return null;
    return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d");
}
function upFiles(pageIndex,str) {

    $("#table-upFiles").empty();
    $.post("/templatefile/GetAllFiles", { key: str, pageIndex: pageIndex }, function (data) {
        var myUpFiles = data.data;
        var obj = $("#table-upFiles");
        for (i = 0; i < myUpFiles.length; i++) {
            var link = myUpFiles[i];
            var mydiv = '';
            mydiv = '<tr> <td><a href="">' + link.Context + '</a></td> <td>' + datetimes(link.RegTime) + '</td> <td><a href="/UserDoAction/DownLoad?path=' + link.Path + '">下载</a></td> </tr>';
            obj.append(mydiv);
        }
        $("#pag").empty();
        $("#pag").append(data.str);

    });
    
}

