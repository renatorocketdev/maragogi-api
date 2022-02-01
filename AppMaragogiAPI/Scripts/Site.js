$('#sidebarCollapse').on('click', function () {
    $('#sidebar').toggleClass('active');
});

$(document).ready(function () {
    $("#sobreEmpresa").fadeOut(1000);
    $("#CarServ").fadeOut(1000);
    $("#token").fadeOut(1000);

    $("#Contatos").fadeOut(2000);
    $("#Carac").fadeOut(2000);
    $("#Serv").fadeOut(2000);
});

$("#nomeEmpresa").keyup(function () {
    if ($("#nomeEmpresa").val() != "") {
        $("#Endereco").prop('disabled', false);
    } else {
        $("#Endereco").prop('disabled', true);
    }
});

$("#Endereco").keyup(function () {
    if ($("#nomeEmpresa").val() != "") {
        $("#Endereco").prop('disabled', false);

        if ($("#Endereco").val() != "") {
            $("#Telef1").prop('disabled', false);
        } else {
            $("#Telef1").prop('disabled', true);
        }
    } else {
        $("#Endereco").prop('disabled', true);
    }
});

$("#Telef1").keyup(function () {
    if ($("#Telef1").val() != "") {
        $("#sobreEmpresa").fadeIn(1000);
    } else {
        $("#sobreEmpresa").fadeOut(1000);
    }
});

$("#sobreEmpresa").keyup(function () {
    if ($("#sobreEmpresa").text() != "") {
        $("#CarServ").fadeIn(1000);
    } else {
        $("#CarServ").fadeOut(1000);
    }
});

$("#sobreEmpresa").keyup(function () {
    if ($("#sobreEmpresa").text() != "") {
        $("#CarServ").fadeIn(1000);
    } else {
        $("#CarServ").fadeIn(1000);
    }
});

$("#Serv1").keyup(function () {
    if ($("#Serv1").val() != "") {
        $("#token").fadeIn(1000);
    } else {
        $("#token").fadeIn(1000);
    }
});

$("#maisItens").on("click", function () {
    if ($("#Carac").is(":visible")) {
        $("#Contatos").fadeOut(1000);
        $("#Carac").fadeOut(1000);
        $("#Serv").fadeOut(1000);
    } else {
        $("#Contatos").fadeIn(1000);
        $("#Carac").fadeIn(1000);
        $("#Serv").fadeIn(1000);
    }
});