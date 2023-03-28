
$(function () {
    $("#btn-cat").click(function () {
        $.ajax({
            url: "/Pet/PartialGetImage?type=Cat",
            type: "GET",
            data: {  },
            success: function (result) {
                $("#icone-cat").html(result);
            },
            error: function () {
                alert("Ocorreu um erro ao atualizar o conteúdo.");
            }
        });
    });
});

$(function () {
    $("#btn-dog").click(function () {
        $.ajax({
            url: "/Pet/PartialGetImage?type=Dog",
            type: "GET",
            data: {},
            success: function (result) {
                $("#icone-dog").html(result);
            },
            error: function () {
                alert("Ocorreu um erro ao atualizar o conteúdo.");
            }
        });
    });
});


