$(function () {
    initTable();
    $("#addDialogDiv").css("display", "none");
    $("#editDialogDiv").css("display", "none");
    $("#btn").click(function () {
       var data= { schName: $("#txtSchName").val(), schNickName: $("#txtSchNickName").val() }
       initTable(data);
    });
});
//初始化表格
function initTable(data) {
    $('#tt').datagrid({
        url: '/ActionInfo/GetAllActionInfos',
        title: '用户信息列表',
        //iconCls: 'icon-save',
        width: 800,
        height: 400,
        fitColumns: true,
        idField: 'ID',
        loadMsg: '正在加载用户的信息....',
        pagination: true,
        singleSelect: false,
        pageSize: 10,
        pageNumber: 1,
        pageList: [10, 20, 30],
        queryParams: data,
        columns: [[
            { field: 'ck', checkbox: true, align: 'left', width: 50 },
            { field: 'ID', title: '主键', width: 80 },
            { field: 'ActionName', title: '权限名', width: 120 },
            { field: 'Url', title: 'URL', width: 200 },
            { field: 'HttpMethd', title: 'Http类型', align: 'center', width: 90 },
            { field: 'MenuIcon', title: '菜单图标', align: 'center', width: 80, formatter: function (value, row, index) { return "<img src='" + value + "' width='20px'height='20px' />"; } },
            { field: 'IsMenu', title: '是否菜单', align: 'center', width: 80, formatter: function (value, row, index) { return value ? "是" : "否"; } },
            { field: 'Sort', title: '排序', align: 'center', width: 40 },
            { field: 'RegTime', title: '时间', width: 180, align: 'center', formatter: function (value, row, index) { return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s"); } }
        , {
            field: 'ModfiedOn', title: '操作 ', width: 120, formatter: function (value, row, index) {
                var str = "";
                str += "<a href='javascript:void(0)' class='editLink' uid='" + row.ID + "'>修改</a> &nbsp;&nbsp;";
                str += "<a href='javascript:void(0)' class='deleteLink' uid='" + row.ID + "'>删除</a> ";
                return str;
            }
        }
        ]],
        toolbar: [{
            id: 'btnadd',
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {
                addClickEvent();
            }
        }, {
            id: 'btndelete',
            text: '删除',
            iconCls: 'icon-cancel',
            handler: function () {
                var seleteRows = $("#tt").datagrid("getSelections");
                if (seleteRows.length <= 0) {
                    $.messager.alert("错误提醒", "请选中删除数据！", "question");
                    return;
                }
                var ids = "";
                for (var key in seleteRows) {
                    ids = ids + seleteRows[key].ID + ",";
                }
                ids = ids.substr(0, ids.length - 1);
                deleteEvent(ids);
            }
        }, {
            id: 'btnedit',
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var seleteRows = $("#tt").datagrid("getSelections");
                if (seleteRows.length != 1) {
                    $.messager.alert("错误提醒", "请选中一行修改数据！", "question");
                    return;
                }
                editEvent(seleteRows[0].ID);
            }
        }, {
            id: 'btnsetrole',
            text: '设置角色',
            iconCls: 'icon-edit',
            handler: function () {
                var seleteRows = $("#tt").datagrid("getSelections");
                if (seleteRows.length != 1) {
                    $.messager.alert("错误提醒", "请选中一行修改数据！", "question");
                    return;
                }
                SetRole(seleteRows[0].ID);
            }
        }],
        onLoadSuccess: function (data) {
            $(".editLink").click(function () {
                editEvent($(this).attr("uid"));
                return false;
            });
            $(".deleteLink").click(function () {
                deleteEvent($(this).attr("uid"));
                return false;
            });
        }
    });
}

function SetRole(id) {

    $("#setRoleframe").attr("src", "/ActionInfo/SetRole/" + id);
    $("#setRoleDialogDiv").css("display", "block");
    $("#setRoleDialogDiv").dialog({
        title: "设置权限",
        modal: true,
        width: 500,
        height: 400,
        collapsible: true,
        minimizable: true,
        maximizable: true,
        resizable: true,
        buttons: [{
            id: 'btnOk',
            text: '设置',
            iconCls: 'icon-ok',
            handler: function () {
                $("#setRoleframe")[0].contentWindow.submitForm();
            }
        },
        {
            id: 'btnCancel',
            text: '取消',
            iconCls: 'icon-cancel',
            handler: function () {
                $("#setRoleDialogDiv").dialog("close");
            }
        }]
    });
}
//修改
function editEvent(id) {

    $("#editframe").attr("src", "/ActionInfo/Edit/" + id);
    $("#editDialogDiv").css("display", "block");
    $("#editDialogDiv").dialog({
        title: "修改用户",
        modal: true,
        width: 500,
        height: 400,
        collapsible: true,
        minimizable: true,
        maximizable: true,
        resizable: true,
        buttons: [{
            id: 'btnOk',
            text: '修改',
            iconCls: 'icon-ok',
            handler: function () {
                $("#editframe")[0].contentWindow.submitForm();
            }
        },
        {
            id: 'btnCancel',
            text: '取消',
            iconCls: 'icon-cancel',
            handler: function () {

                $("#editDialogDiv").dialog("close");
            }
        }]
    });
}
//批量删除
function deleteEvent(ids) {
    //alert(ids);
    $.post("/ActionInfo/Delete", { ids: ids }, function (data) {
        if (data == "ok") {
            initTable();
        } else {
            $.messager.alert("提醒消息", "出错了", "error");
        }
    });
}
//添加
function addClickEvent() {
    $("#addframe").attr("src", "/ActionInfo/Add");
    $("#addDialogDiv").css("display", "block");
    $("#addDialogDiv").dialog({
        title: "添加用户",
        modal: true,
        width: 500,
        height: 400,
        collapsible: true,
        minimizable: true,
        maximizable: true,
        resizable: true,
        buttons: [{
            id: 'btnOk',
            text: '添加',
            iconCls: 'icon-ok',
            handler: function () {
                $("#addframe")[0].contentWindow.submitForm();
            }
        },
        {
            id: 'btnCancel',
            text: '取消',
            iconCls: 'icon-cancel',
            handler: function () {

                $("#addDialogDiv").dialog("close");
            }
        }]
    });
}



function afterAdd(data) {
    if (data == "ok") {
        $("#addDialogDiv").dialog("close");
        $('#tt').datagrid("reload");
    }
}
function afterEditSuccess() {
    $("#editDialogDiv").dialog("close");
    $('#tt').datagrid("reload");
}
function afterAddSuccess() {
    $("#addDialogDiv").dialog("close");
    $('#tt').datagrid("reload");
}
function afterSetRoleSuccess() {
    $("#setRoleDialogDiv").dialog("close");
}