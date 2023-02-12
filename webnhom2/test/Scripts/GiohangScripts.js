
$("#btn_add_cart").click((e) => {
    var number1 = document.getElementById("btn_SoLuong").value;
    var a = $("#item_malk").text();
    var b = a.trim();
    $.ajax({
        url: "/GioHang1/addGioHang",
        data: {
            MaLK: b,
            SoLuong: number1 
        },
        type:"POST"
    }).then((res) => {
        if (res == "oke") {
            $("#info").text("SẢN PHẨM CỦA BẠN ĐÃ ĐƯỢC THÊM VÀO GIỎ HÀNG");
            $("#yes").text("MUA SẮM TIẾP NÀO !!!!");
            $("#yes").click(() => { window.location.href = "/ITNEXT/Index"; });
           
        }
        else if (res == "vui lòng đăng nhập") {
            $("#yes").click(() => { window.location.href = "/Login/Index"; })  
        }
        else  {
            window.alert("Đã sảy ra lỗi vui lòng thêm lại");
        }
    });
})