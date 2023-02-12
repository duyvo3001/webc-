$("#dang").click(() => {
    $.ajax({
        url: "/ITNEXT/Details1",
        data: {
            malk: $("#malk").text(),//user cua model
            name: $("#name").val(),
            commentkh: $("#new-review").val(),
        },
        type: "POST"
    }).then((res) => {
        console.log(res);
        if (res == "ok") {
            window.location.reload();
            alert("BẠN ĐÃ ĐĂNG BÌNH LUẬN THÀNH CÔNG");

        }
        else {
            alert("BẠN ĐÃ ĐĂNG BÌNH LUẬN THẤT BẠI");
        }

    });
})