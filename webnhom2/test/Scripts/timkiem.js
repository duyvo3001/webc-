$("#btnSearch").click((e) => {
    $.ajax({
        url: "/TimKiem/timkiem",
        data: {
            TenLK: $("#inputSearchAuto").val()
        },
        type: "POST"
    }).then((res) => {
        if ((res) == "oke") {
            window.location.href = "/TimKiem/Ttimkiem";
        }
        else { window.alert((res)) }
    })
})
