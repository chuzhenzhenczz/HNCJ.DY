
fun1();
function fun1() {
    $.post("/material/GetData", function (data) {
        $("#data").empty();
        $("#data").append(data);
    });
}