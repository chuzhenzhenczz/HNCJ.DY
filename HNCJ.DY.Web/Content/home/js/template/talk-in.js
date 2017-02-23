
//焦点
$(document).ready(function(){
//focusblur
    jQuery.focusblur = function(focusid) {
        var focusblurid = $(focusid);
        var defval = focusblurid.val();
        focusblurid.focus(function(){
            var thisval = $(this).val();
            if(thisval==defval){
                $(this).val("");
            }
        });
        focusblurid.blur(function(){
            var thisval = $(this).val();
            if(thisval==""){
                $(this).val(defval);
            }
        });
    };
    /*下面是调用方法*/
    $.focusblur("#searchkey");
});

//访客
vister(1);
function vister(value) {
   
    $.post("/VisitorRecord/GetAccess", { value: value }, function (data) {
        $("#myVisitor-new-bottom").empty();
        $("#myVisitor-new-bottom").append(data.html);
        $("#count").empty();
        $("#count").append(data.count);
        $("#datecount").empty();
        $("#datecount").append(data.datecount);

    });
}

