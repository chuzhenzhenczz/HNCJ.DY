/** 
 * JQuery扩展方法，用户对JQuery EasyUI的DataGrid控件进行操作。 
 */
$.fn.extend({
    resizeDataGrid: function (heightMargin, widthMargin, minHeight, minWidth) {
        var height = $(document.body).height() - heightMargin;
        var width = $(document.body).width() - widthMargin;

        height = height < minHeight ? minHeight : height;
        width = width < minWidth ? minWidth : width;

        $(this).datagrid('resize', {
            height: height,
            width: width
        });
    }
});

$(function () {
    //datagrid数据表格ID 
    var datagridId = 'tt';

    // 第一次加载时自动变化大小  
    $('#' + datagridId).resizeDataGrid(20, 60, 500, 700);

    // 当窗口大小发生变化时，调整DataGrid的大小  
    $(window).resize(function () {
        $('#' + datagridId).resizeDataGrid(20, 60, 600, 800);
    });
});