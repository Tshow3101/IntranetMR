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
                    document.getElementById("doblereal").value = Math.round(doble - dobleporcentaje)
                }
                else {
                    var doble = (document.getElementById("doble").value)
                    document.getElementById("doblereal").value = Math.round(doble - descadu);
                }
            })
            /*Triple*/
            $("#triple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var triple = (document.getElementById("triple").value);
                    var tripleporcentaje = (document.getElementById("triple").value) * (porcentajes / 100);
                    document.getElementById("triplereal").value = Math.round(triple - tripleporcentaje)
                }
                else {
                    var triple = (document.getElementById("triple").value)
                    document.getElementById("triplereal").value = Math.round(triple - descadu);
                }
            })
            /*Cuadruple*/
            $("#cuadruple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var cuadruple = (document.getElementById("cuadruple").value);
                    var cuadrupleporcentaje = (document.getElementById("cuadruple").value) * (porcentajes / 100);
                    document.getElementById("cuadruplereal").value = Math.round(cuadruple - cuadrupleporcentaje);
                }
                else {
                    var cuadruple = (document.getElementById("cuadruple").value)
                    document.getElementById("cuadruplereal").value = Math.round(cuadruple - descadu);
                }
            })
            /*Simple*/
            $("#simple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var simple = (document.getElementById("simple").value);
                    var simpleporcentaje = (document.getElementById("simple").value) * (porcentajes / 100);
                    document.getElementById("simplereal").value = Math.round(simple - simpleporcentaje);
                }
                else {
                    var simple = (document.getElementById("simple").value)
                    document.getElementById("simplereal").value = Math.round(simple - descadu);
                }
            })
            /*Quintuple*/
            $("#quintuple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var quintuple = (document.getElementById("quintuple").value);
                    var quintupleporcentaje = (document.getElementById("quintuple").value) * (porcentajes / 100);
                    document.getElementById("quintuplereal").value = Math.round(quintuple - quintupleporcentaje);
                }
                else {
                    var quintuple = (document.getElementById("quintuple").value)
                    document.getElementById("quintuplereal").value = Math.round(quintuple - descadu);
                }
            })
            /*Sextuple*/
            $("#sextuple").on("change", function () {
                var descadu = document.getElementById("montoadulto").value;
                var porcentajes = document.getElementById("porcentaje").value;

                if (porcentajes > 0) {
                    var sextuple = (document.getElementById("sextuple").value);
                    var sextupleporcentaje = (document.getElementById("sextuple").value) * (porcentajes / 100);
                    document.getElementById("sextuplereal").value = Math.round(sextuple - sextupleporcentaje);
                }
                else {
                    var sextuple = (document.getElementById("sextuple").value)
                    document.getElementById("sextuplereal").value = Math.round(sextuple - descadu);
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
                    document.getElementById("child1real").value = Math.round(child1 - child1porcentaje)
                }
                else if (descnino > 0) {
                    var child1 = (document.getElementById("child1").value);
                    document.getElementById("child1real").value = Math.round(child1 - descnino);
                }
                else {
                    var child1 = (document.getElementById("child1").value)
                    document.getElementById("child1real").value = Math.round(child1 - descadu);
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
                    document.getElementById("child2real").value = Math.round(child2 - child2porcentaje);
                }
                else if (descnino > 0) {
                    var child2 = (document.getElementById("child2").value);
                    document.getElementById("child2real").value = Math.round(child2 - descnino);
                }
                else {
                    var child2 = (document.getElementById("child2").value)
                    document.getElementById("child2real").value = Math.round(child2 - descadu);
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
                    document.getElementById("child3real").value = Math.round(child3 - child3porcentaje);
                }
                else if (descnino > 0) {
                    var child3 = (document.getElementById("child3").value);
                    document.getElementById("child3real").value = Math.round(child3 - descnino);
                }
                else {
                    var child3 = (document.getElementById("child3").value)
                    document.getElementById("child3real").value = Math.round(child3 - descadu);
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
})

