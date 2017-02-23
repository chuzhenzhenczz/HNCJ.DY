$(function () {
    initTable();
    $("#addDialogDiv").css("display", "none");
    $("#setRoleDialogDiv").css("display", "none");
    $("#editDialogDiv").css("display", "none");
    $("#btn").click(function () {
       var data= { schName: $("#txtSchName").val(), schNickName: $("#txtSchNickName").val() }
       initTable(data);
    });
});
//初始化表格
function initTable(data) {
    $('#tt').datagrid({
        url: '/UserInfo/GetAllUserInfos',
        title: '用户信息列表',
        //iconCls: 'icon-save',
        width: 700,
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
            { field: 'ID', title: '主键', width: 60 },
            { field: 'Avatar', title: '头像', width: 60, formatter: function (value, row, index) { return "<img src='" + value + "' width='30px'height='30px' />"; } },
            { field: 'UserName', title: '用户名', width: 120 },
            { field: 'UserPwd', title: '密码', width: 120 },
            { field: 'NickName', title: '昵称', width: 120 },
            { field: 'RegTime', title: '时间', width: 160, align: 'right', formatter: function (value, row, index) { return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s"); } }
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
        }, {
            id: 'btnaction',
            text: '设置特殊权限',
            iconCls: 'icon-edit',
            handler: function () {
                var seleteRows = $("#tt").datagrid("getSelections");
                if (seleteRows.length != 1) {
                    $.messager.alert("错误提醒", "请选中一行修改数据！", "question");
                    return;
                }
                SetAction(seleteRows[0].ID);
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
function SetAction(id) {

    $("#setActionframe").attr("src", "/UserInfo/SetAction/" + id);
    $("#setActionDialogDiv").css("display", "block");
    $("#setActionDialogDiv").dialog({
        title: "设置权限",
        modal: true,
        width: 600,
        height: 400,
        collapsible: true,
        minimizable: true,
        maximizable: true,
        resizable: true
    });
}
function SetRole(id) {

    $("#setRoleframe").attr("src", "/UserInfo/SetRole/" + id);
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

    $("#editframe").attr("src", "/UserInfo/Edit/" + id);
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
    $.post("/UserInfo/Delete", { ids: ids }, function (data) {
        if (data == "ok") {
            initTable();
        } else {
            $.messager.alert("提醒消息", "对不起,权限不足!", "error");
        }
    });
}
//添加
function addClickEvent() {
    $("#addframe").attr("src", "/UserInfo/Add");
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
function afterSetActionSuccess() {
    $("#setActionDialogDiv").dialog("close");
}

