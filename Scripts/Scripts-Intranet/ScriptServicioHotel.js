$(document).ready(function () {
    $("#tarifa").on("change", function () {
        var tarifav = document.getElementById("tarifa").value;

        if (tarifav == 53) {
            /*Doble*/
            $("#doble").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var doble = (document.getElementById("doble").value);
                    var dobleporcentaje = (document.getElementById("doble").value) * (porcentajes / 100);
                    document.getElementById("doblereal").value = doble - dobleporcentaje
                }
                else {
                    var doble = (document.getElementById("doble").value)
                    document.getElementById("doblereal").value = doble - descadu;
                }
            })
            /*Triple*/
            $("#triple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var triple = (document.getElementById("triple").value);
                    var tripleporcentaje = (document.getElementById("triple").value) * (porcentajes / 100);
                    document.getElementById("triplereal").value = triple - tripleporcentaje;
                }
                else {
                    var triple = (document.getElementById("triple").value)
                    document.getElementById("triplereal").value = triple - descadu;
                }
            })
            /*Cuadruple*/
            $("#cuadruple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var cuadruple = (document.getElementById("cuadruple").value);
                    var cuadrupleporcentaje = (document.getElementById("cuadruple").value) * (porcentajes / 100);
                    document.getElementById("cuadruplereal").value = cuadruple - cuadrupleporcentaje;
                }
                else {
                    var cuadruple = (document.getElementById("cuadruple").value)
                    document.getElementById("cuadruplereal").value = cuadruple - descadu;
                }
            })
            /*Simple*/
            $("#simple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var simple = (document.getElementById("simple").value);
                    var simpleporcentaje = (document.getElementById("simple").value) * (porcentajes / 100);
                    document.getElementById("simplereal").value = simple - simpleporcentaje;
                }
                else {
                    var simple = (document.getElementById("simple").value)
                    document.getElementById("simplereal").value = simple - descadu;
                }
            })
            /*Quintuple*/
            $("#quintuple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var quintuple = (document.getElementById("quintuple").value);
                    var quintupleporcentaje = (document.getElementById("quintuple").value) * (porcentajes / 100);
                    document.getElementById("quituplereal").value = quintuple - quintupleporcentaje;
                }
                else {
                    var quintuple = (document.getElementById("quintuple").value)
                    document.getElementById("quituplereal").value = quintuple - descadu;
                }
            })
            /*Sextuple*/
            $("#sextuple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var sextuple = (document.getElementById("sextuple").value);
                    var sextupleporcentaje = (document.getElementById("sextuple").value) * (porcentajes / 100);
                    document.getElementById("sextuplereal").value = sextuple - sextupleporcentaje;
                }
                else {
                    var sextuple = (document.getElementById("sextuple").value)
                    document.getElementById("sextuplereal").value = sextuple - descadu;
                }
            })
            /*Child1*/
            $("#child1").on("change", function () {
                var descnino = document.getElementById("montoni_o").value;
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var child1 = (document.getElementById("child1").value);
                    var child1porcentaje = (document.getElementById("child1").value) * (porcentajes / 100);
                    document.getElementById("child1real").value = child1 - child1porcentaje;
                }
                else if (descnino > 0) {
                    var child1 = (document.getElementById("child1").value);
                    document.getElementById("child1real").value = child1 - descnino;
                }
                else {
                    var child1 = (document.getElementById("child1").value)
                    document.getElementById("child1real").value = child1 - descadu;
                }
            })
            /*Child2*/
            $("#child2").on("change", function () {
                var descnino = document.getElementById("montoni_o").value;
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var child2 = (document.getElementById("child2").value);
                    var child2porcentaje = (document.getElementById("child2").value) * (porcentajes / 100);
                    document.getElementById("child2real").value = child2 - child2porcentaje;
                }
                else if (descnino > 0) {
                    var child2 = (document.getElementById("child2").value);
                    document.getElementById("child2real").value = child2 - descnino;
                }
                else {
                    var child2 = (document.getElementById("child2").value)
                    document.getElementById("child2real").value = child2 - descadu;
                }
            })
            /*Child3*/
            $("#child3").on("change", function () {
                var descnino = document.getElementById("montoni_o").value;
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var child3 = (document.getElementById("child3").value);
                    var child3porcentaje = (document.getElementById("child3").value) * (porcentajes / 100);
                    document.getElementById("child3real").value = child3 - child3porcentaje;
                }
                else if (descnino > 0) {
                    var child3 = (document.getElementById("child3").value);
                    document.getElementById("child3real").value = child3 - descnino;
                }
                else {
                    var child3 = (document.getElementById("child3").value)
                    document.getElementById("child3real").value = child3 - descadu;
                }
            })
            /*infantes*/
            $("#infante").on("change", function () {
                var descinfante = document.getElementById("montoinfante").value;
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var infante = (document.getElementById("infante").value);
                    var infanteporcentaje = (document.getElementById("infante").value) * (porcentajes / 100);
                    document.getElementById("infantereal").value = infante - infanteporcentaje;
                }
                else if (descinfante > 0) {
                    var infante = (document.getElementById("infante").value);
                    document.getElementById("infantereal").value = infante - descinfante;
                }
                else {
                    var infante = (document.getElementById("infante").value)
                    document.getElementById("infantereal").value = infante - descadu;
                }
            })

        } else {
            /*Doble*/
            $("#doble").on("change", function () {
                var doble = (document.getElementById("doble").value)
                document.getElementById("doblereal").value = doble;
            })
            /*Triple*/
            $("#triple").on("change", function () {
                var triple = (document.getElementById("triple").value)
                document.getElementById("triplereal").value = triple;
            })
            /*Cuadruple*/
            $("#cuadruple").on("change", function () {
                var cuadruple = (document.getElementById("cuadruple").value)
                document.getElementById("cuadruplereal").value = cuadruple;
            })
            /*Simple*/
            $("#simple").on("change", function () {
                var simple = (document.getElementById("simple").value)
                document.getElementById("simplereal").value = simple;
            })
            /*Quintuple*/
            $("#quintuple").on("change", function () {
                var quintuple = (document.getElementById("quintuple").value)
                document.getElementById("quintuplereal").value = quintuple;
            })
            /*Sextuple*/
            $("#sextuple").on("change", function () {
                var sextuple = (document.getElementById("sextuple").value)
                document.getElementById("sextuplereal").value = sextuple;
            })
            /*Child1*/
            $("#child1").on("change", function () {
                var child1 = (document.getElementById("child1").value)
                document.getElementById("child1real").value = child1;
            })
            /*Child2*/
            $("#child2").on("change", function () {
                var child2 = (document.getElementById("child2").value)
                document.getElementById("child2real").value = child2;
            })
            /*Child3*/
            $("#child3").on("change", function () {
                var child3 = (document.getElementById("child3").value)
                document.getElementById("child3real").value = child3;
            })
            /*Infante*/
            $("#infante").on("change", function () {
                var infante = (document.getElementById("infante").value)
                document.getElementById("infantereal").value = infante;
            })
        }
    })

    /*Agregando Funcion al btn Add*/
    $('#add').click(function () {
        var isValid = true;
        if (isValid) {

            $('#orderItemError').empty();
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
            $('#idTipoHabitacion,#doble,#doblereal,#triple,#triplereal,#cuadruple,#cuadruplereal,#simple,#simplereal,#quintuple,#quituplereal,#sextuple,#sextuplereal,#child1,#child1real,#edad1child1,#edad2child1,#child2,#child2real,#edad1child2,#edad2child2,#child3,#child3real,#edad1child3,#edad2child3,#infante,#infantereal,#edadinfante1,#edadinfante2,#capmaximaadu,#capmaximanin,#supmontodoble,#supporcentajedoble,#supmontotriple,#supporcentajetriple,#tercerpaxmonto,#tercerpaxporcentaje,#supmontocuadruple,#supporcentajecuadruple,#cuartopaxmonto,#cuartopaxporcentaje,#supmontosimple,#supporcentajesimple,#supmontoquintuple,#supporcentajequintuple,#quintopaxmonto,#quintopaxporcentaje,#supmontosextuple,#supporcentajesextuple,#sextopaxmonto,#sextopaxporcentaje,#supmontochild1,#supporcentajechild1,#supmontochild2,#supporcentajechild2,#supmontochild3,#supporcentajechild3,#supmontoinfante,#supporcentajeinfante,#serviciohabitacion1,#serviciomonto1doble,#serviciomonto1triple,#serviciomonto1cuadruple,#serviciomonto1simple,#serviciomonto1quintuple,#serviciomonto1sextuple,#servicioporcentaje1doble,#servicioporcentaje1triple,#servicioporcentaje1cuadruple,#servicioporcentaje1simple,#servicioporcentaje1quintuple,#servicioporcentaje1sextuple,#serviciohabitacion2,#serviciomonto2doble,#serviciomonto2triple,#serviciomonto2cuadruple,#serviciomonto2simple,#serviciomonto2quintuple,#serviciomonto2sextuple,#servicioporcentaje2doble,#servicioporcentaje2triple,#servicioporcentaje2cuadruple,#servicioporcentaje2simple,#servicioporcentaje2quintuple,#servicioporcentaje2sextuple,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            //Se agrega la linea nueva a la lista para copiar 
            $('#orderdetailsItems').append($newRow);

            //Se limpia los campos
            $('#idTipoHabitacion,#serviciohabitacion1,#serviciohabitacion2').val('0');
            $('#doble,#doblereal,#triple,#triplereal,#cuadruple,#cuadruplereal,#simple,#simplereal,#quintuple,#quituplereal,#sextuple,#sextuplereal,#child1,#child1real,#edad1child1,#edad2child1,#child2,#child2real,#edad1child2,#edad2child2,#child3,#child3real,#edad1child3,#edad2child3,#infante,#infantereal,#edadinfante1,#edadinfante2,#capmaximaadu,#capmaximanin,#supmontodoble,#supporcentajedoble,#supmontotriple,#supporcentajetriple,#tercerpaxmonto,#tercerpaxporcentaje,#supmontocuadruple,#supporcentajecuadruple,#cuartopaxmonto,#cuartopaxporcentaje,#supmontosimple,#supporcentajesimple,#supmontoquintuple,#supporcentajequintuple,#quintopaxmonto,#quintopaxporcentaje,#supmontosextuple,#supporcentajesextuple,#sextopaxmonto,#sextopaxporcentaje,#supmontochild1,#supporcentajechild1,#supmontochild2,#supporcentajechild2,#supmontochild3,#supporcentajechild3,#supmontoinfante,#supporcentajeinfante,#serviciomonto1doble,#serviciomonto1triple,#serviciomonto1cuadruple,#serviciomonto1simple,#serviciomonto1quintuple,#serviciomonto1sextuple,#servicioporcentaje1doble,#servicioporcentaje1triple,#servicioporcentaje1cuadruple,#servicioporcentaje1simple,#servicioporcentaje1quintuple,#servicioporcentaje1sextuple,#serviciomonto2doble,#serviciomonto2triple,#serviciomonto2cuadruple,#serviciomonto2simple,#serviciomonto2quintuple,#serviciomonto2sextuple,#servicioporcentaje2doble,#servicioporcentaje2triple,#servicioporcentaje2cuadruple,#servicioporcentaje2simple,#servicioporcentaje2quintuple,#servicioporcentaje2sextuple').val('');
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
});