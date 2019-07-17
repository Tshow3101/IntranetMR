$(document).ready(function () {

    /*Agregando Funcion al btn Add*/
    $('#add').click(function () {
        var isValid = true;
        if (isValid) {

            $('#orderItemError').empty();
            /*Se inicia la variable que contendra la nueva fila*/
            var $newRow = $('#mainrow').clone().removeAttr('id');

            /*Se agregan todos los cbo que estaran dentro del manteniento detalle*/
            $('.idCategoria1', $newRow).val($('#idCategoria1').val());

            //Remplaza la clase del btn add por elimnar
            $('#add', $newRow).addClass('remove').val('Eliminar').removeClass('btn-success').addClass('btn-danger');

            //Se remueve el id de los atributos ya copiados a la linea nueva
            //Se ponen todos los campos del detalle
            $('#idCategoria1,#nombreContactoHotel,#correoContactoHotel,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            //Se agrega la linea nueva a la lista para copiar 
            $('#orderdetailsItems').append($newRow);

            //Se limpia los campos
            $('#idCategoria1').val('0');
            $('#nombreContactoHotel,#correoContactoHotel').val('');            
        }
    })

    /*Se da Funcionalidad al bton remover*/
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    /*Se activa las funciones del btn guardar*/
    $('#submit').click(function () {
        var isAllValid = true;

        $('#orderItemError').text('');
        /*Crear una variable lista en blanco */
        var list = [];
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            /*Se crea una variable donde se almacenaran los datos de la linea*/
            var orderItem = {
                /*Se agregan los campos del detalle*/
                idCategoria1: $('select.idCategoria1', this).val(),                
                nombreContactoHotel: $('.nombreContactoHotel', this).val(),
                correoContactoHotel: $('.correoContactoHotel', this).val(),
            }
            /*Se cargan los datos de la variable orderitem a la variable lista en forma de cadena*/
            list.push(orderItem);

        })

        if (isAllValid) {
            var data = {
                /*Se agregan todos los campos del maestro*/

                idCadenaHotelera:$('#idCadenaHotelera').val(),
                idCategoria:$('#idCategoria').val(),
                idZona:$('#idZona').val(),
                idPais:$('#idPais').val(),
                idCiudad:$('#idCiudad').val(),
                nombrehotel:$('#nombrehotel').val(),
                telefono1hotel:$('#telefono1hotel').val(),
                telefono2hotel:$('#telefono2hotel').val(),
                direccionhotel:$('#direccionhotel').val(),
                correohotel:$('#correohotel').val(),
                linkhotel:$('#linkhotel').val(),
                checkinhotel:$('#checkinhotel').val(),
                checkouthotel:$('#checkouthotel').val(),
                mapahotel:$('#mapahotel').val(),
                logohotel:$('#logohotel').val(),
                tb_contactohotel: list,
            }
            console.log(data);
            $.ajax({
                /*Tipo de metodo*/
                type: 'POST',
                /*Se invoca el metodo*/
                url: '/Hotel/SaveHotel',
                /*Tipo de Informacion recopilada*/
                data: JSON.stringify(data),
                /*Tipo contenido de informacion*/
                contentType: 'application/json',
                /**Si funciona*/
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                    }

                    else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }

    });
});