$("#btlogin").click(() => {
    $.ajax({
        url: "/Login/Signin",
        data: {
            Email: $("#username").val(),//user cua model
            PassWord: $("#password").val()
        },
        type: "POST"
    }).then((res) => {
        if (res == "TÀI KHOẢN HOẶC MẬT KHẨU SAI !!!") {
            $("#resutl").text(res);
        }
        else {
            window.location.href = "/ITNEXT/Index";
        }
    });
})