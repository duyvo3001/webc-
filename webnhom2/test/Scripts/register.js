$("#btadd").click(() => {
    $.ajax({
        url: "/Register/register",
        data: {
            name: $("#name").val(),//user cua model
            Email: $("#gmail").val(),
            PassWord: $("#password").val(),
            sdt: $("#sdt").val(),
            diachi: $("#diachi").val(),
        },
        type: "POST"
    }).then((res) => {
        console.log(res);
        if (res == "ok") {
            window.location.href = "/Register/Register_done";

        }
        else {
            alert("TẠO TÀI KHOẢN THẤT BẠI");
        }

    });
})