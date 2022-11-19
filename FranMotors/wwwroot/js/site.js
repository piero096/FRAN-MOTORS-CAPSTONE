function meca(id) {
    var request = $.ajax({
        url: '/admin/EditMecanico?id=' + id
    });
    request.done(function (resp) {
        console.log(resp);
        $("#edit").html(resp);
    });
};

//$('.regmec').click(function () {
//    var request = $.ajax({
//        url: '/admin/registrar'
//    });
//    request.done(function (resp) {
//        console.log(resp);
//        $("#regisMeca").html(resp);
//    });
//});
$(document).on('change', '#Tipo', function (event) {
    var TipoCambio = $('#Tipo').val();
    if (TipoCambio == "Cliente") {
        $('#precio').attr('hidden', 'hidden');
        $('#precio').removeAttr('required', 'required');
    } else {
        $('#precio').removeAttr('hidden', 'hidden');
        $('#precio').attr('required', 'required');
    }
});

function clien(id) {
    var request = $.ajax({
        url: '/mecanico/EditCliente?id=' + id
    });
    request.done(function (resp) {
        console.log(resp);
        $("#editClie").html(resp);
    });
};

var $reques = $.ajax({
    url: '/admin/listmeca',
    type: 'GET'
});
$reques.done(function (e) {
    $('.listMeca').html(e);
});

function hist(id, idmoto, idcliente) {
    var request = $.ajax({
        url: '/mecanico/EditHistoria?id=' + id + '&idmoto=' + idmoto + '&idcliente=' + idcliente
    });
    request.done(function (resp) {
        console.log(resp);
        $("#edithistoria").html(resp);
    });
};

var $btnBuscar = $('.btnBuscar');
$btnBuscar.click(function (es) {

    es.preventDefault();

    var buscar = $.ajax({
        url: '/admin/listmeca?buscarmeca=' + $('#search').val(),
        type: 'GET'
    });
    buscar.done(function (response) {
        $('.listMeca').html(response);
    });

    $('#search').val(null);
});


/*MOSTRAR LISTA DE LOS CLIENTES*/
var $reques = $.ajax({
    url: '/mecanico/allclientes',
    type: 'GET'
});
$reques.done(function (e) {
    $('.allcliente').html(e);
});

/*BUSCAR CLIENTES*/
var $btnBuscar = $('.btnBuscarCli');
$btnBuscar.click(function (es) {

    es.preventDefault();

    var buscar = $.ajax({
        url: '/mecanico/allclientes?buscarclientes=' + $('#search').val(),
        type: 'GET'
    });
    buscar.done(function (response) {
        $('.allcliente').html(response);
    });

    $('#search').val(null);
});
/*PRE VISUALIZAR FOTO DNI Y FOTO DE MOTO*/
$(document).on("change", "#add-new-photo", function () {
    console.log(this.files);
    var files = this.files;
    var element;
    var supportedImages = ["image/jpg", "image/png", "image/gif"];
    var seEncontraronElementoNoValidos = false;

    for (var i = 0; i < files.length; i++) {
        element = files[i];

        if (supportedImages.indexOf(element.type) != -1) {
            createPreview(element);
        }
        else {
            seEncontraronElementoNoValidos = true;
        }
    }

    if (seEncontraronElementoNoValidos) {
        console.log("Se encontraron archivos no validos");
    }
    else {
        console.log("Todos los archivos se subieron correctamente");
    }
});
function createPreview(file) {
    var imgCodified = URL.createObjectURL(file);
    var img = $('<div><div class="image-container"> <figure> <img src="' + imgCodified + '" alt="Foto del usuario"> <figcaption> <i class="icon-cross"></i> </figcaption> </figure> </div></div>');
    $(img).insertBefore("#add-photo-container");
}
$(document).on("click", "#Images .image-container", function (e) {
    $(this).parent().remove();
    $('#add-new-photo').val('');
});
/*validad carga de imagen*/
$("#add-new-photo").change(function () {
    $(".btn").prop("disabled", this.files.length == 0);
});
/*PRE VISUALIZAR FOTO TARJETA*/
$(document).on("change", "#add-photo-tarjeta", function () {
    console.log(this.files);
    var filesT = this.files;
    var elementT;
    var supportedImagesT = ["image/jpg", "image/png", "image/gif"];
    var seEncontraronElementoNoValidosT = false;

    for (var i = 0; i < filesT.length; i++) {
        elementT = filesT[i];

        if (supportedImagesT.indexOf(elementT.type) != -1) {
            createPreviewT(elementT);
        }
        else {
            seEncontraronElementoNoValidosT = true;
        }
    }

    if (seEncontraronElementoNoValidosT) {
        console.log("Se encontraron archivos no validos");
    }
    else {
        console.log("Todos los archivos se subieron correctamente");
    }
});
function createPreviewT(file) {
    var imgCodifiedTarjeta = URL.createObjectURL(file);
    var imgt = $('<div><div class="image-container-tarjeta"> <figure> <img src="' + imgCodifiedTarjeta + '" alt="Foto del usuario"> <figcaption> <i class="icon-cross"></i> </figcaption> </figure> </div></div>');
    $(imgt).insertBefore("#add-photo-container-tarjeta");
}
$(document).on("click", "#Images-tarjeta .image-container-tarjeta", function (e) {
    $(this).parent().remove();
    $('#add-photo-tarjeta').val('');
});