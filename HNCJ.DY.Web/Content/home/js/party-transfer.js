$('#sub').click(function () {
    $('#transfer').replaceWith('<button class="btn btn-primary btn-lg disabled" id="transfer" data-target="#myModal">申请成功 </button>');
    $('.progress').show();
    setTimeout(function () {
        $('.zj1').show();
    },2000);
    setTimeout(function () {
        $('.zj2').show();
    },4000);
    setTimeout(function () {
        $('.zj3').show();

        $('#transfer').replaceWith('<button class="btn btn-primary btn-lg disabled" id="transfer" data-target="#myModal">转接成功 </button>');
    },6000);
});