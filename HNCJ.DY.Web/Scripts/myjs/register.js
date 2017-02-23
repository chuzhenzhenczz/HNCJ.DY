

$(function () {
    $("#regrules").css('display', 'none');
    
    $("#ids").click(function () {
        $("#regrules").css('display', 'block');
        $("#regrules").dialog({
            title: "注册协议",
            modal: true,
            width: 500,
            height: 400,
            collapsible: true,
            minimizable: true,
            maximizable: true,
            resizable: true,
            buttons: [{
                text: '确定',
                
                handler: function () {
                    $("#regrules").dialog("close");
                }
            }]
        });
        
    });
    jQuery.validator.addMethod("stringCheck", function (value, element) {
        var length = value.length;
        var your_tel = /[^\a-zA-Z\u4E00-\u9FA5]/g;
        var your_tel2 = /^[A-Za-z]*$/;
        return this.optional(element) || (length <= 20 && !your_tel.test(value));
    });
    $("#signupForm").validate({
        rules: {
            UserName: {
                required: true,
                stringCheck:true,
                minlength:4
            },
            email: {
                required: true,
                email: true
            },
            UserPwd: {
                required: true,
                minlength: 6,
                maxlength:32
            },
            confirm_password: {
                required: true,
                minlength: 6,
                equalTo: "#UserPwd"
            },
            chkAgree: {
                required: true
            }
        },
        messages: {
            UserName: {
                required: "请输入用户名",
                minlength: "用户名不能小于4个字符",
                stringCheck: "请输入中文或英文名称"
            },
            email: {
                required: "请输入Email地址",
                email: "请输入正确的email地址"
            },
            UserPwd: {
                required: "请输入密码",
                minlength: jQuery.format("密码不能小于{0}个字 符"),
                maxlength: jQuery.format("密码不能大于{0}个字 符")
            },
            confirm_password: {
                required: "请输入确认密码",
                minlength: "确认密码不能小于6个字符",
                equalTo: "两次输入密码不一致"
            },
            chkAgree: {
                required:""
            }
        }
    });
    });


//切换验证码
function changeCheckCode() {
    $("#img").attr("src", $("#img").attr("src") + 1);
}


//判断输入密码的类型  
function CharMode(iN) {
    if (iN >= 48 && iN <= 57) //数字  
        return 1;
    if (iN >= 65 && iN <= 90) //大写  
        return 2;
    if (iN >= 97 && iN <= 122) //小写  
        return 4;
    else
        return 8;
}
//bitTotal函数  
//计算密码模式  
function bitTotal(num) {
    modes = 0;
    for (i = 0; i < 4; i++) {
        if (num & 1) modes++;
        num >>>= 1;
    }
    return modes;
}
//返回强度级别  
function checkStrong(sPW) {
    if (sPW.length <= 4)
        return 0; //密码太短  
    Modes = 0;
    for (i = 0; i < sPW.length; i++) {
        //密码模式  
        Modes |= CharMode(sPW.charCodeAt(i));
    }
    return bitTotal(Modes);
}

//显示颜色  
function pwStrength(pwd) {
    O_color = "#eeeeee";
    L_color = "#F00000";
    M_color = "#FF9900";
    H_color = "#33CC00";
    if (pwd == null || pwd == '') {
        Lcolor = Mcolor = Hcolor = O_color;
    }
    else {
        S_level = checkStrong(pwd);
        switch (S_level) {
            case 0:
                Lcolor = Mcolor = Hcolor = O_color;
            case 1:
                Lcolor = L_color;
                Mcolor = Hcolor = O_color;
                break;
            case 2:
                Lcolor = Mcolor = M_color;
                Hcolor = O_color;
                break;
            default:
                Lcolor = Mcolor = Hcolor = H_color;
        }
    }
    $("#strength_L").css('background', Lcolor);
    $("#strength_M").css('background', Mcolor);
    $("#strength_H").css('background ', Hcolor);
    return;
}
//表单的回调函数
function afterRegisterSuccess(data) {
    if (data == "ok") {
        alert("注册成功！");
    } else {
        alert("出错了！");

    }
}