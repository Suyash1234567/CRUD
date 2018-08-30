$('[data-attr="Delete_Movie"]').on('click', function () {
    $.ajax(
        {
            url: "/Movie/Delete",
            type: "POST",
            data: $('#DeleteMovie').serialize(),
            success: function (response) {
                window.location.href ='Index'
                //$('#PartialView').hide()
                //$('#PartialResultView').html(response)

            },
            error: function (err) {
                // console.log(err)
            }
        });
});