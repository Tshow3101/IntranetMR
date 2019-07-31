$(document).ready(function () {
    /*Agregando Funcion al btn Add*/
    $('#add').click(function () {
        var isValid = true;
        if (isValid) {

            /*Se inicia la variable que contendra la nueva fila*/
            var $newRow = $('#mainrow').clone().removeAttr('id');

            /*Se agregan todos los cbo que estaran dentro del manteniento detalle*/
            $('.idTipoHabitacion', $newRow).val($('#idTipoHabitacion').val());
            $('.serviciohabitacion1', $newRow).val($('#serviciohabitacion1').val());
            $('.serviciohabitacion2', $newRow).val($('#serviciohabitacion2').val());

            //Remplaza la clase del btn add por elimnar
            $('#add', $newRow).addClass('remove').val('Eliminar').removeClass('btn-success').addClass('btn-danger');

            //Se remueve el id de los atributos ya copiados a la linea nueva
            //Se ponen todos los campos del detalle
            $('#idTipoHabitacion,#doble,#doblereal,#triple,#triplereal,#cuadruple,#cuadruplereal,#simple,#simplereal,#quintuple,#quituplereal,#sextuple,#sextuplereal,#child1,#child1real,#edad1child1,#edad2child1,#child2,#child2real,#edad1child2,#edad2child2,#child3,#child3real,#edad1child3,#edad2child3,#infante,#infantereal,#edadinfante1,#edadinfante2,#capmaximaadu,#capmaximanin,#supmontodoble,#supporcentajedoble,#supmontotriple,#supporcentajetriple,#tercerpaxmonto,#tercerpaxporcentaje,#supmontocuadruple,#supporcentajecuadruple,#cuartopaxmonto,#cuartopaxporcentaje,#supmontosimple,#supporcentajesimple,#supmontoquintuple,#supporcentajequintuple,#quintopaxmonto,#quintopaxporcentaje,#supmontosextuple,#supporcentajesextuple,#sextopaxmonto,#sextopaxporcentaje,#supmontochild1,#supporcentajechild1,#supmontochild2,#supporcentajechild2,#supmontochild3,#supporcentajechild3,#supmontoinfante,#supporcentajeinfante,#serviciohabitacion1,#serviciomonto1doble,#serviciomonto1triple,#serviciomonto1cuadruple,#serviciomonto1simple,#serviciomonto1quintuple,#serviciomonto1sextuple,#servicioporcentaje1doble,#servicioporcentaje1triple,#servicioporcentaje1cuadruple,#servicioporcentaje1simple,#servicioporcentaje1quintuple,#servicioporcentaje1sextuple,#serviciohabitacion2,#serviciomonto2doble,#serviciomonto2triple,#serviciomonto2cuadruple,#serviciomonto2simple,#serviciomonto2quintuple,#serviciomonto2sextuple,#servicioporcentaje2doble,#servicioporcentaje2triple,#servicioporcentaje2cuadruple,#servicioporcentaje2simple,#servicioporcentaje2quintuple,#servicioporcentaje2sextuple,#preciserviciodoble1,#preciserviciotriple1,#preciserviciocuadruple1,#preciserviciosimple1,#preciservicioquintuple1,#preciserviciosextuple1,#preciserviciodoble2,#preciserviciotriple2,#preciserviciocuadruple2,#preciserviciosimple2,#preciservicioquintuple2,#preciserviciosextuple2,#add', $newRow).removeAttr('id');


            //Se agrega la linea nueva a la lista para copiar 
            $('#orderdetailsItems').append($newRow);

            //Se limpia los campos
            $('#idTipoHabitacion,#serviciohabitacion1,#serviciohabitacion2').val('0');
            $('#doble,#doblereal,#triple,#triplereal,#cuadruple,#cuadruplereal,#simple,#simplereal,#quintuple,#quituplereal,#sextuple,#sextuplereal,#child1,#child1real,#edad1child1,#edad2child1,#child2,#child2real,#edad1child2,#edad2child2,#child3,#child3real,#edad1child3,#edad2child3,#infante,#infantereal,#edadinfante1,#edadinfante2,#capmaximaadu,#capmaximanin,#supmontodoble,#supporcentajedoble,#supmontotriple,#supporcentajetriple,#tercerpaxmonto,#tercerpaxporcentaje,#supmontocuadruple,#supporcentajecuadruple,#cuartopaxmonto,#cuartopaxporcentaje,#supmontosimple,#supporcentajesimple,#supmontoquintuple,#supporcentajequintuple,#quintopaxmonto,#quintopaxporcentaje,#supmontosextuple,#supporcentajesextuple,#sextopaxmonto,#sextopaxporcentaje,#supmontochild1,#supporcentajechild1,#supmontochild2,#supporcentajechild2,#supmontochild3,#supporcentajechild3,#supmontoinfante,#supporcentajeinfante,#serviciomonto1doble,#serviciomonto1triple,#serviciomonto1cuadruple,#serviciomonto1simple,#serviciomonto1quintuple,#serviciomonto1sextuple,#servicioporcentaje1doble,#servicioporcentaje1triple,#servicioporcentaje1cuadruple,#servicioporcentaje1simple,#servicioporcentaje1quintuple,#servicioporcentaje1sextuple,#serviciomonto2doble,#serviciomonto2triple,#serviciomonto2cuadruple,#serviciomonto2simple,#serviciomonto2quintuple,#serviciomonto2sextuple,#servicioporcentaje2doble,#servicioporcentaje2triple,#servicioporcentaje2cuadruple,#servicioporcentaje2simple,#servicioporcentaje2quintuple,#servicioporcentaje2sextuple,#preciserviciodoble1,#preciserviciotriple1,#preciserviciocuadruple1,#preciserviciosimple1,#preciservicioquintuple1,#preciserviciosextuple1,#preciserviciodoble2,#preciserviciotriple2,#preciserviciocuadruple2,#preciserviciosimple2,#preciservicioquintuple2,#preciserviciosextuple2').val('');
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
                idTipoHabitacion: $('select.idTipoHabitacion', this).val(),
                doble: $('.doble', this).val(),
                doblereal: $('.doblereal', this).val(),
                triple: $('.triple', this).val(),
                triplereal: $('.triplereal', this).val(),
                cuadruple: $('.cuadruple', this).val(),
                cuadruplereal: $('.cuadruplereal', this).val(),
                simple: $('.simple', this).val(),
                simplereal: $('.simplereal', this).val(),
                quintuple: $('.quintuple', this).val(),
                quituplereal: $('.quituplereal', this).val(),
                sextuple: $('.sextuple', this).val(),
                sextuplereal: $('.sextuplereal', this).val(),
                child1: $('.child1', this).val(),
                child1real: $('.child1real', this).val(),
                edad1child1: $('.edad1child1', this).val(),
                edad2child1: $('.edad2child1', this).val(),
                child2: $('.child2', this).val(),
                child2real: $('.child2real', this).val(),
                edad1child2: $('.edad1child2', this).val(),
                edad2child2: $('.edad2child2', this).val(),
                child3: $('.child3', this).val(),
                child3real: $('.child3real', this).val(),
                edad1child3: $('.edad1child3', this).val(),
                edad2child3: $('.edad2child3', this).val(),
                infante: $('.infante', this).val(),
                infantereal: $('.infantereal', this).val(),
                edadinfante1: $('.edadinfante1', this).val(),
                edadinfante2: $('.edadinfante2', this).val(),
                capmaximaadu: $('.capmaximaadu', this).val(),
                capmaximanin: $('.capmaximanin', this).val(),
                supmontodoble: $('.supmontodoble', this).val(),
                supporcentajedoble: $('.supporcentajedoble', this).val(),
                supmontotriple: $('.supmontotriple', this).val(),
                supporcentajetriple: $('.supporcentajetriple', this).val(),
                tercerpaxmonto: $('.tercerpaxmonto', this).val(),
                tercerpaxporcentaje: $('.tercerpaxporcentaje', this).val(),
                supmontocuadruple: $('.supmontocuadruple', this).val(),
                supporcentajecuadruple: $('.supporcentajecuadruple', this).val(),
                cuartopaxmonto: $('.cuartopaxmonto', this).val(),
                cuartopaxporcentaje: $('.cuartopaxporcentaje', this).val(),
                supmontosimple: $('.supmontosimple', this).val(),
                supporcentajesimple: $('.supporcentajesimple', this).val(),
                supmontoquintuple: $('.supmontoquintuple', this).val(),
                supporcentajequintuple: $('.supporcentajequintuple', this).val(),
                quintopaxmonto: $('.quintopaxmonto', this).val(),
                quintopaxporcentaje: $('.quintopaxporcentaje', this).val(),
                supmontosextuple: $('.supmontosextuple', this).val(),
                supporcentajesextuple: $('.supporcentajesextuple', this).val(),
                sextopaxmonto: $('.sextopaxmonto', this).val(),
                sextopaxporcentaje: $('.sextopaxporcentaje', this).val(),
                supmontochild1: $('.supmontochild1', this).val(),
                supporcentajechild1: $('.supporcentajechild1', this).val(),
                supmontochild2: $('.supmontochild2', this).val(),
                supporcentajechild2: $('.supporcentajechild2', this).val(),
                supmontochild3: $('.supmontochild3', this).val(),
                supporcentajechild3: $('.supporcentajechild3', this).val(),
                supmontoinfante: $('.supmontoinfante', this).val(),
                supporcentajeinfante: $('.supporcentajeinfante', this).val(),
                serviciohabitacion1: $('select.serviciohabitacion1', this).val(),
                serviciomonto1doble: $('.serviciomonto1doble', this).val(),
                serviciomonto1triple: $('.serviciomonto1triple', this).val(),
                serviciomonto1cuadruple: $('.serviciomonto1cuadruple', this).val(),
                serviciomonto1simple: $('.serviciomonto1simple', this).val(),
                serviciomonto1quintuple: $('.serviciomonto1quintuple', this).val(),
                serviciomonto1sextuple: $('.serviciomonto1sextuple', this).val(),
                servicioporcentaje1doble: $('.servicioporcentaje1doble', this).val(),
                servicioporcentaje1triple: $('.servicioporcentaje1triple', this).val(),
                servicioporcentaje1cuadruple: $('.servicioporcentaje1cuadruple', this).val(),
                servicioporcentaje1simple: $('.servicioporcentaje1simple', this).val(),
                servicioporcentaje1quintuple: $('.servicioporcentaje1quintuple', this).val(),
                servicioporcentaje1sextuple: $('.servicioporcentaje1sextuple', this).val(),
                serviciohabitacion2: $('select.serviciohabitacion2', this).val(),
                serviciomonto2doble: $('.serviciomonto2doble', this).val(),
                serviciomonto2triple: $('.serviciomonto2triple', this).val(),
                serviciomonto2cuadruple: $('.serviciomonto2cuadruple', this).val(),
                serviciomonto2simple: $('.serviciomonto2simple', this).val(),
                serviciomonto2quintuple: $('.serviciomonto2quintuple', this).val(),
                serviciomonto2sextuple: $('.serviciomonto2sextuple', this).val(),
                servicioporcentaje2doble: $('.servicioporcentaje2doble', this).val(),
                servicioporcentaje2triple: $('.servicioporcentaje2triple', this).val(),
                servicioporcentaje2cuadruple: $('.servicioporcentaje2cuadruple', this).val(),
                servicioporcentaje2simple: $('.servicioporcentaje2simple', this).val(),
                servicioporcentaje2quintuple: $('.servicioporcentaje2quintuple', this).val(),
                servicioporcentaje2sextuple: $('.servicioporcentaje2sextuple', this).val(),
                preciserviciodoble1: $('.preciserviciodoble1', this).val(),
                preciserviciotriple1: $('.preciserviciotriple1', this).val(),
                preciserviciocuadruple1: $('.preciserviciocuadruple1', this).val(),
                preciserviciosimple1: $('.preciserviciosimple1', this).val(),
                preciservicioquintuple1: $('.preciservicioquintuple1', this).val(),
                preciserviciosextuple1: $('.preciserviciosextuple1', this).val(),
                preciserviciodoble2: $('.preciserviciodoble2', this).val(),
                preciserviciotriple2: $('.preciserviciotriple2', this).val(),
                preciserviciocuadruple2: $('.preciserviciocuadruple2', this).val(),
                preciserviciosimple2: $('.preciserviciosimple2', this).val(),
                preciservicioquintuple2: $('.preciservicioquintuple2', this).val(),
                preciserviciosextuple2: $('.preciserviciosextuple2', this).val(),
            }
            /*Se cargan los datos de la variable orderitem a la variable lista en forma de cadena*/
            list.push(orderItem);

        })

        if (isAllValid) {
            var data = {
                /*Se agregan todos los campos del maestro*/
                fecviajeini: $('#fecviajeini').val(),
                fecviajefin: $('#fecviajefin').val(),
                feccompraini: $('#feccompraini').val(),
                feccomprafin: $('#feccomprafin').val(),
                tarifa: $('#tarifa').val(),
                codprom: $('#codprom').val(),
                idCadena: $('#idCadena').val(),
                idHotel: $('#idHotel').val(),
                montoadulto: $('#montoadulto').val(),
                montoniño: $('#montoniño').val(),
                montoinfante: $('#montoinfante').val(),
                porcentaje: $('#porcentaje').val(),
                preciodoble: $('#preciodoble').val(),
                tb_detalleingresohotel: list,
            }
            console.log(data);
            $.ajax({
                /*Tipo de metodo*/
                type: 'POST',
                /*Se invoca el metodo*/
                url: '/IngresosHotel/SaveIngresoHotel',
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

    $('#edit').click(function () {
        var isAllValid = true;

        $('#orderItemError').text('');
        /*Crear una variable lista en blanco */
        var list = [];
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            /*Se crea una variable donde se almacenaran los datos de la linea*/
            var orderItem = {
                /*Se agregan los campos del detalle*/
                idIngresoHotel: $('#idIngresoHotel').val(),
                idTipoHabitacion: $('select.idTipoHabitacion', this).val(),
                doble: $('.doble', this).val(),
                doblereal: $('.doblereal', this).val(),
                triple: $('.triple', this).val(),
                triplereal: $('.triplereal', this).val(),
                cuadruple: $('.cuadruple', this).val(),
                cuadruplereal: $('.cuadruplereal', this).val(),
                simple: $('.simple', this).val(),
                simplereal: $('.simplereal', this).val(),
                quintuple: $('.quintuple', this).val(),
                quituplereal: $('.quituplereal', this).val(),
                sextuple: $('.sextuple', this).val(),
                sextuplereal: $('.sextuplereal', this).val(),
                child1: $('.child1', this).val(),
                child1real: $('.child1real', this).val(),
                edad1child1: $('.edad1child1', this).val(),
                edad2child1: $('.edad2child1', this).val(),
                child2: $('.child2', this).val(),
                child2real: $('.child2real', this).val(),
                edad1child2: $('.edad1child2', this).val(),
                edad2child2: $('.edad2child2', this).val(),
                child3: $('.child3', this).val(),
                child3real: $('.child3real', this).val(),
                edad1child3: $('.edad1child3', this).val(),
                edad2child3: $('.edad2child3', this).val(),
                infante: $('.infante', this).val(),
                infantereal: $('.infantereal', this).val(),
                edadinfante1: $('.edadinfante1', this).val(),
                edadinfante2: $('.edadinfante2', this).val(),
                capmaximaadu: $('.capmaximaadu', this).val(),
                capmaximanin: $('.capmaximanin', this).val(),
                supmontodoble: $('.supmontodoble', this).val(),
                supporcentajedoble: $('.supporcentajedoble', this).val(),
                supmontotriple: $('.supmontotriple', this).val(),
                supporcentajetriple: $('.supporcentajetriple', this).val(),
                tercerpaxmonto: $('.tercerpaxmonto', this).val(),
                tercerpaxporcentaje: $('.tercerpaxporcentaje', this).val(),
                supmontocuadruple: $('.supmontocuadruple', this).val(),
                supporcentajecuadruple: $('.supporcentajecuadruple', this).val(),
                cuartopaxmonto: $('.cuartopaxmonto', this).val(),
                cuartopaxporcentaje: $('.cuartopaxporcentaje', this).val(),
                supmontosimple: $('.supmontosimple', this).val(),
                supporcentajesimple: $('.supporcentajesimple', this).val(),
                supmontoquintuple: $('.supmontoquintuple', this).val(),
                supporcentajequintuple: $('.supporcentajequintuple', this).val(),
                quintopaxmonto: $('.quintopaxmonto', this).val(),
                quintopaxporcentaje: $('.quintopaxporcentaje', this).val(),
                supmontosextuple: $('.supmontosextuple', this).val(),
                supporcentajesextuple: $('.supporcentajesextuple', this).val(),
                sextopaxmonto: $('.sextopaxmonto', this).val(),
                sextopaxporcentaje: $('.sextopaxporcentaje', this).val(),
                supmontochild1: $('.supmontochild1', this).val(),
                supporcentajechild1: $('.supporcentajechild1', this).val(),
                supmontochild2: $('.supmontochild2', this).val(),
                supporcentajechild2: $('.supporcentajechild2', this).val(),
                supmontochild3: $('.supmontochild3', this).val(),
                supporcentajechild3: $('.supporcentajechild3', this).val(),
                supmontoinfante: $('.supmontoinfante', this).val(),
                supporcentajeinfante: $('.supporcentajeinfante', this).val(),
                serviciohabitacion1: $('select.serviciohabitacion1', this).val(),
                serviciomonto1doble: $('.serviciomonto1doble', this).val(),
                serviciomonto1triple: $('.serviciomonto1triple', this).val(),
                serviciomonto1cuadruple: $('.serviciomonto1cuadruple', this).val(),
                serviciomonto1simple: $('.serviciomonto1simple', this).val(),
                serviciomonto1quintuple: $('.serviciomonto1quintuple', this).val(),
                serviciomonto1sextuple: $('.serviciomonto1sextuple', this).val(),
                servicioporcentaje1doble: $('.servicioporcentaje1doble', this).val(),
                servicioporcentaje1triple: $('.servicioporcentaje1triple', this).val(),
                servicioporcentaje1cuadruple: $('.servicioporcentaje1cuadruple', this).val(),
                servicioporcentaje1simple: $('.servicioporcentaje1simple', this).val(),
                servicioporcentaje1quintuple: $('.servicioporcentaje1quintuple', this).val(),
                servicioporcentaje1sextuple: $('.servicioporcentaje1sextuple', this).val(),
                serviciohabitacion2: $('select.serviciohabitacion2', this).val(),
                serviciomonto2doble: $('.serviciomonto2doble', this).val(),
                serviciomonto2triple: $('.serviciomonto2triple', this).val(),
                serviciomonto2cuadruple: $('.serviciomonto2cuadruple', this).val(),
                serviciomonto2simple: $('.serviciomonto2simple', this).val(),
                serviciomonto2quintuple: $('.serviciomonto2quintuple', this).val(),
                serviciomonto2sextuple: $('.serviciomonto2sextuple', this).val(),
                servicioporcentaje2doble: $('.servicioporcentaje2doble', this).val(),
                servicioporcentaje2triple: $('.servicioporcentaje2triple', this).val(),
                servicioporcentaje2cuadruple: $('.servicioporcentaje2cuadruple', this).val(),
                servicioporcentaje2simple: $('.servicioporcentaje2simple', this).val(),
                servicioporcentaje2quintuple: $('.servicioporcentaje2quintuple', this).val(),
                servicioporcentaje2sextuple: $('.servicioporcentaje2sextuple', this).val(),
                preciserviciodoble1: $('.preciserviciodoble1', this).val(),
                preciserviciotriple1: $('.preciserviciotriple1', this).val(),
                preciserviciocuadruple1: $('.preciserviciocuadruple1', this).val(),
                preciserviciosimple1: $('.preciserviciosimple1', this).val(),
                preciservicioquintuple1: $('.preciservicioquintuple1', this).val(),
                preciserviciosextuple1: $('.preciserviciosextuple1', this).val(),
                preciserviciodoble2: $('.preciserviciodoble2', this).val(),
                preciserviciotriple2: $('.preciserviciotriple2', this).val(),
                preciserviciocuadruple2: $('.preciserviciocuadruple2', this).val(),
                preciserviciosimple2: $('.preciserviciosimple2', this).val(),
                preciservicioquintuple2: $('.preciservicioquintuple2', this).val(),
                preciserviciosextuple2: $('.preciserviciosextuple2', this).val(),
            }
            /*Se cargan los datos de la variable orderitem a la variable lista en forma de cadena*/
            list.push(orderItem);

        })

        var detalle = {            
            tb_detalleingresohotel: list,
            id: $('#idIngresoHotel').val(),
        }
        var data = {
            /*Se agregan todos los campos del maestro*/
            idIngresoHotel: $('#idIngresoHotel').val(),
            fecviajeini: $('#fecviajeini').val(),
            fecviajefin: $('#fecviajefin').val(),
            feccompraini: $('#feccompraini').val(),
            feccomprafin: $('#feccomprafin').val(),
            tarifa: $('#tarifa').val(),
            codprom: $('#codprom').val(),
            idCadena: $('#idCadena').val(),
            idHotel: $('#idHotel').val(),
            montoadulto: $('#montoadulto').val(),
            montoniño: $('#montoniño').val(),
            montoinfante: $('#montoinfante').val(),
            porcentaje: $('#porcentaje').val(),
            preciodoble: $('#preciodoble').val()
        }
        console.log(data);
        console.log(detalle);

        var id = $('#idIngresoHotel').val();

        $.ajax({

            type: 'POST',
            url: '/IngresosHotel/EditarIngreso',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                if (data.status) {
                    $.ajax({

                        type: 'POST',
                        url: '/IngresosHotel/eliminaDetalles',
                        data: JSON.stringify(detalle),
                        contentType: 'application/json',
                        success: function (data) {
                            if (data.status) {
                                sweetAlert({
                                    title: 'Correcto',
                                    text: 'Tarifa ha sido registrado correctamente.',
                                    type: 'success'
                                }).then(function () {
                                    window.location.reload();
                                });
                            }

                            else {
                                sweetAlert({
                                    title: 'Error',
                                    text: 'Tarifa no ha podido ser registrada.',
                                    type: 'error'
                                }).then(function () {
                                    window.location.reload();

                                });
                            }
                            $('#submit').text('Save');
                        },
                        error: function (error) {
                            console.log(error);
                            $('#submit').text('Save');
                        }
                    });
                }

                else {
                    sweetAlert({
                        title: 'Error',
                        text: 'Tarifa no ha podido ser registrada',
                        type: 'error'
                    }).then(function () {
                        window.location.reload();

                    });
                }
                $('#submit').text('Save');
            },
            error: function (error) {
                console.log(error);
                $('#submit').text('Save');
            }
        });

    });
});

function UpdateInput() {
    var tarifav = document.getElementById("tarifa").value;
    var descadu = document.getElementById("montoadulto").value;
    var porcentajes = document.getElementById("porcentaje").value;
    var descnino = document.getElementById("montoni_o").value;
    var descinfante = document.getElementById("montoinfante").value;
    var preciodoble = document.getElementById("preciodoble").value;
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio Doble*/
    if (document.getElementById("supmontodoble").value > 0) {
        document.getElementById("doble").value = parseInt(preciodoble) + parseInt(document.getElementById("supmontodoble").value);
    }
    else if (document.getElementById("supporcentajedoble").value > 0) {
        document.getElementById("doble").value = parseInt(preciodoble) + parseFloat((document.getElementById("supporcentajedoble").value) / 100 * parseInt(preciodoble));
    }
    else {
        document.getElementById("doble").value = preciodoble;
    }

    if (tarifav == 53) {
        if (porcentajes > 0) {
            var doble = (document.getElementById("doble").value);
            var dobleporcentaje = (document.getElementById("doble").value) * (porcentajes / 100);
            document.getElementById("doblereal").value = doble - dobleporcentaje
        }

        else {
            var doble = (document.getElementById("doble").value)
            document.getElementById("doblereal").value = doble - descadu;
        }
    }
    else {
        var doble = (document.getElementById("doble").value)
        document.getElementById("doblereal").value = doble;
    }
    /* Inicio Servicios Adicionales doble*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1doble").value != 0) {
        var montodoble = document.getElementById("serviciomonto1doble").value;
        document.getElementById("preciserviciodoble1").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montodoble);
    }
    else if (document.getElementById("servicioporcentaje1doble").value != 0) {
        var montodoble = document.getElementById("servicioporcentaje1doble").value;
        document.getElementById("preciserviciodoble1").value = parseFloat(document.getElementById("doblereal").value) + (montodoble / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2doble").value != 0) {
        var montodoble = document.getElementById("serviciomonto2doble").value;
        document.getElementById("preciserviciodoble2").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montodoble);
    }
    else if (document.getElementById("servicioporcentaje2doble").value != 0) {
        var montodoble = document.getElementById("servicioporcentaje2doble").value;
        document.getElementById("preciserviciodoble2").value = parseFloat(document.getElementById("doblereal").value) + (montodoble / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Fin Servicios Adicionales Doble*/
    /*Fin Doble*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio Triple*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontotriple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montotriple = document.getElementById("supmontotriple").value;
        document.getElementById("triple").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montotriple);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajetriple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montotriple = document.getElementById("supporcentajetriple").value;
        document.getElementById("triple").value = parseFloat(document.getElementById("doblereal").value) + (montotriple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Si el 3 pax monto es diferente a 0*/
    if (document.getElementById("tercerpaxmonto").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montotriple = document.getElementById("tercerpaxmonto").value;
        document.getElementById("triple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + parseInt(montotriple);
    }
    /*Si el 3 pax procentaje es diferente a 0*/
    else if (document.getElementById("tercerpaxporcentaje").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montotriple = document.getElementById("tercerpaxporcentaje").value;
        document.getElementById("triple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + (montotriple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var triple = (document.getElementById("triple").value)
        document.getElementById("triplereal").value = triple;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var triple = (document.getElementById("triple").value);
            var tripleporcentaje = document.getElementById("triple").value * (porcentajes / 100);
            document.getElementById("triplereal").value = triple - tripleporcentaje;
        } else {
            var triple = (document.getElementById("triple").value)
            document.getElementById("triplereal").value = triple - descadu;
        }
    }
    else {
        var triple = (document.getElementById("triple").value)
        document.getElementById("triplereal").value = triple;
    }
    /* Inicio Servicios Adicionales Triple*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1triple").value != 0) {
        var montotriple = document.getElementById("serviciomonto1triple").value;
        document.getElementById("preciserviciotriple1").value = parseFloat(document.getElementById("triplereal").value) + parseInt(montotriple);
    }
    else if (document.getElementById("servicioporcentaje1triple").value != 0) {
        var montotriple = document.getElementById("servicioporcentaje1triple").value;
        document.getElementById("preciserviciotriple1").value = parseFloat(document.getElementById("triplereal").value) + (montotriple / 100 * parseFloat(document.getElementById("triplereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2triple").value != 0) {
        var montotriple = document.getElementById("serviciomonto2triple").value;
        document.getElementById("preciserviciotriple2").value = parseFloat(document.getElementById("triplereal").value) + parseInt(montotriple);
    }
    else if (document.getElementById("servicioporcentaje2triple").value != 0) {
        var montotriple = document.getElementById("servicioporcentaje2triple").value;
        document.getElementById("preciserviciotriple2").value = parseFloat(document.getElementById("triplereal").value) + (montotriple / 100 * parseFloat(document.getElementById("triplereal").value));
    }
    /*Fin Servicios Adicionales Triple*/
    /*Fin Triple*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio cuadruple*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontocuadruple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montocuadruple = document.getElementById("supmontocuadruple").value;
        document.getElementById("cuadruple").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montocuadruple);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajecuadruple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montocuadruple = document.getElementById("supporcentajecuadruple").value;
        document.getElementById("cuadruple").value = parseFloat(document.getElementById("doblereal").value) + (montocuadruple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Si el 3 pax monto es diferente a 0*/
    if (document.getElementById("cuartopaxmonto").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montocuadruple = document.getElementById("cuartopaxmonto").value;
        document.getElementById("cuadruple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + parseInt(montocuadruple) + parseInt(montocuadruple);
    }
    /*Si el 4 pax procentaje es diferente a 0*/
    else if (document.getElementById("cuartopaxporcentaje").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montocuadruple = document.getElementById("cuartopaxporcentaje").value;
        document.getElementById("cuadruple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + (montocuadruple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montocuadruple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var cuadruple = (document.getElementById("cuadruple").value)
        document.getElementById("cuadruplereal").value = cuadruple;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var cuadruple = (document.getElementById("cuadruple").value);
            var cuadrupleporcentaje = document.getElementById("cuadruple").value * (porcentajes / 100);
            document.getElementById("cuadruplereal").value = cuadruple - cuadrupleporcentaje;
        } else {
            var cuadruple = (document.getElementById("cuadruple").value)
            document.getElementById("cuadruplereal").value = cuadruple - descadu;
        }
    }
    else {
        var cuadruple = (document.getElementById("cuadruple").value)
        document.getElementById("cuadruplereal").value = cuadruple;
    }
    /* Inicio Servicios Adicionales cuadruple*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1cuadruple").value != 0) {
        var montocuadruple = document.getElementById("serviciomonto1cuadruple").value;
        document.getElementById("preciserviciocuadruple1").value = parseFloat(document.getElementById("cuadruplereal").value) + parseInt(montocuadruple);
    }
    else if (document.getElementById("servicioporcentaje1cuadruple").value != 0) {
        var montocuadruple = document.getElementById("servicioporcentaje1cuadruple").value;
        document.getElementById("preciserviciocuadruple1").value = parseFloat(document.getElementById("cuadruplereal").value) + (montocuadruple / 100 * parseFloat(document.getElementById("cuadruplereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2cuadruple").value != 0) {
        var montocuadruple = document.getElementById("serviciomonto2cuadruple").value;
        document.getElementById("preciserviciocuadruple2").value = parseFloat(document.getElementById("cuadruplereal").value) + parseInt(montocuadruple);
    }
    else if (document.getElementById("servicioporcentaje2cuadruple").value != 0) {
        var montocuadruple = document.getElementById("servicioporcentaje2cuadruple").value;
        document.getElementById("preciserviciocuadruple2").value = parseFloat(document.getElementById("cuadruplereal").value) + (montocuadruple / 100 * parseFloat(document.getElementById("cuadruplereal").value));
    }
    /*Fin Servicios Adicionales cuadruple*/
    /*Fin cuadruple*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio simple*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontosimple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosimple = document.getElementById("supmontosimple").value;
        document.getElementById("simple").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montosimple);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajesimple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosimple = document.getElementById("supporcentajesimple").value;
        document.getElementById("simple").value = parseFloat(document.getElementById("doblereal").value) + (montosimple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var simple = (document.getElementById("simple").value)
        document.getElementById("simplereal").value = simple;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var simple = (document.getElementById("simple").value);
            var simpleporcentaje = document.getElementById("simple").value * (porcentajes / 100);
            document.getElementById("simplereal").value = simple - simpleporcentaje;
        } else {
            var simple = (document.getElementById("simple").value)
            document.getElementById("simplereal").value = simple - descadu;
        }
    }
    else {
        var simple = (document.getElementById("simple").value)
        document.getElementById("simplereal").value = simple;
    }
    /* Inicio Servicios Adicionales simple*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1simple").value != 0) {
        var montosimple = document.getElementById("serviciomonto1simple").value;
        document.getElementById("preciserviciosimple1").value = parseFloat(document.getElementById("simplereal").value) + parseInt(montosimple);
    }
    else if (document.getElementById("servicioporcentaje1simple").value != 0) {
        var montosimple = document.getElementById("servicioporcentaje1simple").value;
        document.getElementById("preciserviciosimple1").value = parseFloat(document.getElementById("simplereal").value) + (montosimple / 100 * parseFloat(document.getElementById("simplereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2simple").value != 0) {
        var montosimple = document.getElementById("serviciomonto2simple").value;
        document.getElementById("preciserviciosimple2").value = parseFloat(document.getElementById("simplereal").value) + parseInt(montosimple);
    }
    else if (document.getElementById("servicioporcentaje2simple").value != 0) {
        var montosimple = document.getElementById("servicioporcentaje2simple").value;
        document.getElementById("preciserviciosimple2").value = parseFloat(document.getElementById("simplereal").value) + (montosimple / 100 * parseFloat(document.getElementById("simplereal").value));
    }
    /*Fin Servicios Adicionales simple*/
    /*Fin simple*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio quintuple*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontoquintuple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoquintuple = document.getElementById("supmontoquintuple").value;
        document.getElementById("quintuple").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montoquintuple);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajequintuple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoquintuple = document.getElementById("supporcentajequintuple").value;
        document.getElementById("quintuple").value = parseFloat(document.getElementById("doblereal").value) + (montoquintuple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Si el 3 pax monto es diferente a 0*/
    if (document.getElementById("quintopaxmonto").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoquintuple = document.getElementById("quintopaxmonto").value;
        document.getElementById("quintuple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + parseInt(montoquintuple) + parseInt(montoquintuple) + parseInt(montoquintuple);
    }
    /*Si el 4 pax procentaje es diferente a 0*/
    else if (document.getElementById("quintopaxporcentaje").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoquintuple = document.getElementById("quintopaxporcentaje").value;
        document.getElementById("quintuple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + (montoquintuple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montoquintuple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montoquintuple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var quintuple = (document.getElementById("quintuple").value)
        document.getElementById("quituplereal").value = quintuple;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var quintuple = (document.getElementById("quintuple").value);
            var quintupleporcentaje = document.getElementById("quintuple").value * (porcentajes / 100);
            document.getElementById("quituplereal").value = quintuple - quintupleporcentaje;
        } else {
            var quintuple = (document.getElementById("quintuple").value)
            document.getElementById("quituplereal").value = quintuple - descadu;
        }
    }
    else {
        var quintuple = (document.getElementById("quintuple").value)
        document.getElementById("quituplereal").value = quintuple;
    }
    /* Inicio Servicios Adicionales quintuple*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1quintuple").value != 0) {
        var montoquintuple = document.getElementById("serviciomonto1quintuple").value;
        document.getElementById("preciservicioquintuple1").value = parseFloat(document.getElementById("quituplereal").value) + parseInt(montoquintuple);
    }
    else if (document.getElementById("servicioporcentaje1quintuple").value != 0) {
        var montoquintuple = document.getElementById("servicioporcentaje1quintuple").value;
        document.getElementById("preciservicioquintuple1").value = parseFloat(document.getElementById("quituplereal").value) + (montoquintuple / 100 * parseFloat(document.getElementById("quituplereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2quintuple").value != 0) {
        var montoquintuple = document.getElementById("serviciomonto2quintuple").value;
        document.getElementById("preciservicioquintuple2").value = parseFloat(document.getElementById("quituplereal").value) + parseInt(montoquintuple);
    }
    else if (document.getElementById("servicioporcentaje2quintuple").value != 0) {
        var montoquintuple = document.getElementById("servicioporcentaje2quintuple").value;
        document.getElementById("preciservicioquintuple2").value = parseFloat(document.getElementById("quituplereal").value) + (montoquintuple / 100 * parseFloat(document.getElementById("quituplereal").value));
    }
    /*Fin Servicios Adicionales quintuple*/
    /*Fin quintuple*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio sextuple*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontosextuple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosextuple = document.getElementById("supmontosextuple").value;
        document.getElementById("sextuple").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montosextuple);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajesextuple").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosextuple = document.getElementById("supporcentajesextuple").value;
        document.getElementById("sextuple").value = parseFloat(document.getElementById("doblereal").value) + (montosextuple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    /*Si el 3 pax monto es diferente a 0*/
    if (document.getElementById("sextopaxmonto").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosextuple = document.getElementById("sextopaxmonto").value;
        document.getElementById("sextuple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + parseInt(montosextuple) + parseInt(montosextuple) + parseInt(montosextuple) + parseInt(montosextuple);
    }
    /*Si el 4 pax procentaje es diferente a 0*/
    else if (document.getElementById("sextopaxporcentaje").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montosextuple = document.getElementById("sextopaxporcentaje").value;
        document.getElementById("sextuple").value = parseFloat(document.getElementById("doblereal").value) + parseFloat(document.getElementById("doblereal").value) + (montosextuple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montosextuple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montosextuple / 100 * parseFloat(document.getElementById("doblereal").value)) + (montosextuple / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var sextuple = (document.getElementById("sextuple").value)
        document.getElementById("sextuplereal").value = sextuple;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var sextuple = (document.getElementById("sextuple").value);
            var sextupleporcentaje = document.getElementById("sextuple").value * (porcentajes / 100);
            document.getElementById("sextuplereal").value = sextuple - sextupleporcentaje;
        } else {
            var sextuple = (document.getElementById("sextuple").value)
            document.getElementById("sextuplereal").value = sextuple - descadu;
        }
    }
    else {
        var sextuple = (document.getElementById("sextuple").value)
        document.getElementById("sextuplereal").value = sextuple;
    }
    /* Inicio Servicios Adicionales sextuple*/
    /*Servicio Adicional 1*/
    if (document.getElementById("serviciomonto1sextuple").value != 0) {
        var montosextuple = document.getElementById("serviciomonto1sextuple").value;
        document.getElementById("preciserviciosextuple1").value = parseFloat(document.getElementById("sextuplereal").value) + parseInt(montosextuple);
    }
    else if (document.getElementById("servicioporcentaje1sextuple").value != 0) {
        var montosextuple = document.getElementById("servicioporcentaje1sextuple").value;
        document.getElementById("preciserviciosextuple1").value = parseFloat(document.getElementById("sextuplereal").value) + (montosextuple / 100 * parseFloat(document.getElementById("sextuplereal").value));
    }
    /*Servicio Adicional 2*/
    if (document.getElementById("serviciomonto2sextuple").value != 0) {
        var montosextuple = document.getElementById("serviciomonto2sextuple").value;
        document.getElementById("preciserviciosextuple2").value = parseFloat(document.getElementById("sextuplereal").value) + parseInt(montosextuple);
    }
    else if (document.getElementById("servicioporcentaje2sextuple").value != 0) {
        var montosextuple = document.getElementById("servicioporcentaje2sextuple").value;
        document.getElementById("preciserviciosextuple2").value = parseFloat(document.getElementById("sextuplereal").value) + (montosextuple / 100 * parseFloat(document.getElementById("sextuplereal").value));
    }
    /*Fin Servicios Adicionales sextuple*/
    /*Fin sextuple*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio child1*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontochild1").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild1 = document.getElementById("supmontochild1").value;
        document.getElementById("child1").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montochild1);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajechild1").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild1 = document.getElementById("supporcentajechild1").value;
        document.getElementById("child1").value = parseFloat(document.getElementById("doblereal").value) + (montochild1 / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var child1 = (document.getElementById("child1").value)
        document.getElementById("child1real").value = child1;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var child1 = (document.getElementById("child1").value);
            var child1porcentaje = document.getElementById("child1").value * (porcentajes / 100);
            document.getElementById("child1real").value = child1 - child1porcentaje;
        }
        else if (descnino > 0) {
            var child1 = (document.getElementById("child1").value)
            document.getElementById("child1real").value = child1 - descnino;
        }
        else {
            var child1 = (document.getElementById("child1").value)
            document.getElementById("child1real").value = child1 - descadu;
        }
    }
    else {
        var child1 = (document.getElementById("child1").value)
        document.getElementById("child1real").value = child1;
    }
    /*Fin Child1*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio child2*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontochild2").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild2 = document.getElementById("supmontochild2").value;
        document.getElementById("child2").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montochild2);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajechild2").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild2 = document.getElementById("supporcentajechild2").value;
        document.getElementById("child2").value = parseFloat(document.getElementById("doblereal").value) + (montochild2 / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var child2 = (document.getElementById("child2").value)
        document.getElementById("child2real").value = child2;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var child2 = (document.getElementById("child2").value);
            var child2porcentaje = document.getElementById("child2").value * (porcentajes / 100);
            document.getElementById("child2real").value = child2 - child2porcentaje;
        }
        else if (descnino > 0) {
            var child2 = (document.getElementById("child2").value)
            document.getElementById("child2real").value = child2 - descnino;
        }
        else {
            var child2 = (document.getElementById("child2").value)
            document.getElementById("child2real").value = child2 - descadu;
        }
    }
    else {
        var child2 = (document.getElementById("child2").value)
        document.getElementById("child2real").value = child2;
    }
    /*Fin child2*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio child3*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontochild3").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild3 = document.getElementById("supmontochild3").value;
        document.getElementById("child3").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montochild3);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajechild3").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montochild3 = document.getElementById("supporcentajechild3").value;
        document.getElementById("child3").value = parseFloat(document.getElementById("doblereal").value) + (montochild3 / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var child3 = (document.getElementById("child3").value)
        document.getElementById("child3real").value = child3;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var child3 = (document.getElementById("child3").value);
            var child3porcentaje = document.getElementById("child3").value * (porcentajes / 100);
            document.getElementById("child3real").value = child3 - child3porcentaje;
        }
        else if (descnino > 0) {
            var child3 = (document.getElementById("child3").value)
            document.getElementById("child3real").value = child3 - descnino;
        }
        else {
            var child3 = (document.getElementById("child3").value)
            document.getElementById("child3real").value = child3 - descadu;
        }
    } else {
        var child3 = (document.getElementById("child3").value)
        document.getElementById("child3real").value = child3;
    }
    /*Fin child3*/
    /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
    /*Inicio infante*/
    /*Si suplemento monto es diferente de 0*/
    if (document.getElementById("supmontoinfante").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoinfante = document.getElementById("supmontoinfante").value;
        document.getElementById("infante").value = parseFloat(document.getElementById("doblereal").value) + parseInt(montoinfante);
    }
    /*si suplemento % es diferente de 0*/
    else if (document.getElementById("supporcentajeinfante").value != 0) {
        /*Suplemento a partir del precio doble*/
        var montoinfante = document.getElementById("supporcentajeinfante").value;
        document.getElementById("infante").value = parseFloat(document.getElementById("doblereal").value) + (montoinfante / 100 * parseFloat(document.getElementById("doblereal").value));
    }
    else {
        var infante = (document.getElementById("infante").value)
        document.getElementById("infantereal").value = infante;
    }
    /*Tipo tarifario*/
    if (tarifav == 53) {
        if (porcentajes > 0) {
            var infante = (document.getElementById("infante").value);
            var infanteporcentaje = document.getElementById("infante").value * (porcentajes / 100);
            document.getElementById("infantereal").value = infante - infanteporcentaje;
        }
        else if (descnino > 0) {
            var infante = (document.getElementById("infante").value)
            document.getElementById("infantereal").value = infante - descnino;
        }
        else {
            var infante = (document.getElementById("infante").value)
            document.getElementById("infantereal").value = infante - descadu;
        }
    }
    else {
        var infante = (document.getElementById("infante").value)
        document.getElementById("infantereal").value = infante;
    }
    /*Fin infante*/
}