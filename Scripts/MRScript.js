$(document).ready(function () {

    $('#add').click(function () {
        var isAllValid = true;

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.idCategoria1', $newRow).val($('#idCategoria1').val());


            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Eliminar').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#idCategoria1, #nombreContactoHotel, #correoContactoHotel, #add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#idCategoria1').val('0');
            $('#nombreContactoHotel, #correoContactoHotel').val('');
            $('#orderItemError').empty();
        }

    })

    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        var list = [];
        var errorItemCount = 0;

        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            var orderItem = {
                idCategoria: $('select.idCategoria1', this).val(),
                nombreContactoHotel: $('.nombreContactoHotel', this).val(),
                correoContactoHotel: $('.correoContactoHotel', this).val()
            }
            list.push(orderItem);

        })

        if (isAllValid) {
            var data = {
                nombrehotel: $('#nombrehotel').val(),
                idCadenaHotelera: $('#idCadenaHotelera').val(),
                idZona: $('#idZona').val(),
                idPais: $('#idPais').val(),
                idCiudad: $('#idCiudad').val(),
                idCategoria: $('#idCategoria').val(),
                direccionhotel: $('#direccionhotel').val(),
                correohotel: $('#correohotel').val(),
                telefono1hotel: $('#telefono1hotel').val(),
                telefono2hotel: $('#telefono2hotel').val(),
                idVigencia: $('#idVigencia').val(),
                linkhotel: $('#linkhotel').val(),
                checkinhotel: $('#checkinhotel').val(),
                checkouthotel: $('#checkouthotel').val(),
                mapahotel: $('#mapahotel').val(),
                logohotel: $('#logohotel').val(),
                fecharegistro: $('#fecharegistro').val(),
                usuarioregistro: $('#usuarioregistro').val(),
                fechamodificacion: $('#fechamodificacion').val(),
                usuariomodificacion: $('#usuariomodificacion').val(),                
                tb_contactohotel: list
        }
        console.log(data);
        $.ajax({

            type: 'POST',
            url: '/Hotel/SaveHotel',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (Data) {
                if (Data.status) {
                    alert('Guardado Satisfactoriamente');
                }

                else {
                    alert('Error');
                }
                $('#submitServicio').text('Save');
            },
            error: function (error) {
                console.log(error);
                $('#submitServicio').text('Save');
            }
        });
    }

    });
});