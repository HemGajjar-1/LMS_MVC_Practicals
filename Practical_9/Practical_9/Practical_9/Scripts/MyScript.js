$("#button1").click(function () {
    $("#mylabel").text("Hello World");
})
$("#button2").click(function () {
    $("#mylabel").css("font-weight", "bold");
})
$("#button3").click(function () {
    $("#mylabel").css("font-style", "italic");
})
$("#button4").click(function () {
    $("#mylabel").css("text-decoration", "underline");
})
$("#button5").click(function () {
    $("#mylabel").css("text-decoration", "none");
    $("#mylabel").css("font-style", "normal");
    $("#mylabel").css("font-weight", "normal");
})
