
$(".guoce").css({"background-color":"#b4b3b1"});

policy();
function  policy() {
    var  MyPolicy = [
        ["effect-2","../../../image/imgs/ce2.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce3.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-2","../../../image/imgs/ce1.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce5.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-2","../../../image/imgs/ce2.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce3.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-2","../../../image/imgs/ce8.png","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce9.jpeg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-2","../../../image/imgs/ce10.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce11.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-2","../../../image/imgs/ce12.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"],["effect-3","../../../image/imgs/ce11.jpg","工信部拟对新能源车企业实行积分管理","我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略我是内容缩略"]
    ];
    for(var i = 0; i<MyPolicy.length ; i++){
        var myPolicy = '';
        myPolicy = '<div class="single-member '+MyPolicy[i][0]+'"> <div class="member-image"> <img src="'+MyPolicy[i][1]+'" alt="Member"> </div> <div class="member-info"> <h4>'+MyPolicy[i][2]+'</h4> <p>'+MyPolicy[i][3]+'</p> <div class="social-touch"> <a class="fb-touch" href="#">点击进入详情</a> </div> </div> </div>';
        document.getElementById("myPolicy").innerHTML += myPolicy;
    }
}