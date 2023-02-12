
$("#btn_pay").click((e) => {
    var text = document.getElementById("diachi").value;
    $.ajax({
        url: "/ThanhToan/Addthanhtoan",
        data: {
            HoTen: $("#HoTen").val(),
            DiaChi: text ,
            SDT: $("#sdt").val(),
            Email: $("#email").val()
        },
        type: "POST"
    }).then((res) => {
        if (res == "eror") {
            $("#btn_pay").hide();
            $("#tb").text("MUA HÀNG THẤT BẠI ");
        }
        else if (res == "vui lòng đăng nhập") {
            window.location.href = "/Login/Index";
        }
        else {
            window.location.href = "/ThanhToan/Checkout_done";
        }
    })
})