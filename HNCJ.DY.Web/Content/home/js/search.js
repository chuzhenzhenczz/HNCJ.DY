/**
 * Created by Administrator on 2016/11/27.
 */
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
        _html += "<b>" + value + "</b>";
    }

    $(obj).find('.result-container-upFiles').html('<span>' + _html + '</span>');
    $(obj).find('.result-container-upFiles').fadeIn(100);

    evt.preventDefault();
}