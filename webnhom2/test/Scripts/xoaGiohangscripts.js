function fun(cardID) {
        var a = cardID; 
        var b = a.trim();
        $.ajax({
            url: "/GioHang1/xoaGioHang",
            data: {
                cardID: b
            },
            type: "POST"
        }).then((res) => {
            if (res == "oke") { window.location.href = "/GioHang1/ViewGioHang" }
            else { window.alert("Xóa không thành công"); }
        })
}
