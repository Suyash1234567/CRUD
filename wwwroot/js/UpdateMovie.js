$('[data-attr="Update_Movie"]').on('click', function () {
    $.ajax(
        {
            url: "/Movie/Update",
            type: "POST",
            data: $('#UpdateMovie').serialize(),
            success: function (response) {
                // console.log(response)
                window.location.href = 'Index'


            },
            Error: function (err) {
                // console.log(err)
            }
        });
});