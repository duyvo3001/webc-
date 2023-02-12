
$("#LK").click(() => {

    $.ajax({
        url: "/ITNEXT/Details",
        data: {
            malk: $("#malk").text(),//user cua model
        },
        type: "GET"
    }).then((res) => {
        console.log(res);

    });
})