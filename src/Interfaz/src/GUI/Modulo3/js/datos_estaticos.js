//carga los cargos de forma dinamica en el combobox, esta funcion debe ser modificada a la hora de traerse los cargos de la base de datos
function cargarcargo() {

    var empresa_seleccionado = $("#id_empresa").text().trim();
    $("#dp3").empty();

    if (empresa_seleccionado == "Cliente") {
        $("#dp3").append('<li value="1"><a href="#">Director General</a></li>');
        $("#dp3").append('<li value="2"><a href="#">Director Ejecutivo</a></li>');
        $("#dp3").append('<li value="3"><a href="#">Gerente Departamental</a></li>');
    }

    if (empresa_seleccionado == "Compañia de Software") {
        $("#dp3").append('<li value="4"><a href="#">Gerente</a></li>');
        $("#dp3").append('<li value="5"><a href="#">Desarrollador</a></li>');
        $("#dp3").append('<li value="6"><a href="#">Diseñador</a></li>');
        $("#dp3").append('<li value="7"><a href="#">Lider de Proyecto</a></li>');
        $("#dp3").append('<li value="8"><a href="#">Arquitecto de Solución</a></li>');
        $("#dp3").append('<li value="9"><a href="#">Arquitecto de Base de Datos</a></li>');

    }
}

function cargarpersonal(empresa_seleccionado, cargo_seleccionado) {
    //carga al personal al seleccionar un cargo, esta parte debe ser cambiada a la hora de extraer al personal de la base de datos
    //son datos estaticos
    if (empresa_seleccionado == "Cliente") {
        if (cargo_seleccionado == "Director General") {

            $("#dp2").append('<li value="1"><a href="#">Argenis Rodriguez</a></li>');
            $("#dp2").append('<li value="2"><a href="#">Carlos Rodriguez</a></li>');
            $("#dp2").append('<li value="3"><a href="#">Nelson Rodriguez</a></li>');
        }
        if (cargo_seleccionado == "Director Ejecutivo") {
            $("#dp2").append('<li value="4"><a href="#">Hero Rodriguez</a></li>');
            $("#dp2").append('<li value="5"><a href="#">Jesus Rodriguez</a></li>');
            $("#dp2").append('<li value="6"><a href="#">Sofia Rodriguez</a></li>');
        }
        if (cargo_seleccionado == "Gerente Departamental") {
            $("#dp2").append('<li value="7"><a href="#">Leonardo Rodriguez</a></li>');
            $("#dp2").append('<li value="8"><a href="#">Fabian Rodriguez</a></li>');
        }

    }
    if (empresa_seleccionado == "Compañia de Software") {
        if (cargo_seleccionado == "Gerente") {
            $("#dp2").append('<li value="16"><a href="#">Khaterine Rodriguez</a></li>');
            $("#dp2").append('<li value="17"><a href="#">James Rodriguez</a></li>');
        }
        if (cargo_seleccionado == "Desarrollador") {
            $("#dp2").append('<li value="18"><a href="#">Rosa Rodriguez</a></li>');
            $("#dp2").append('<li value="19"><a href="#">Susan Rodriguez</a></li>');
        }
        if (cargo_seleccionado == "Diseñador") {
            $("#dp2").append('<li value="20"><a href="#">Estefania Rodriguez</a></li>');
            $("#dp2").append('<li value="21"><a href="#">Laura Rodriguez</a></li>');
        }
        if (cargo_seleccionado == "Lider de Proyecto") {
            $("#dp2").append('<li value="22"><a href="#">José Boggio</a></li>');
            $("#dp2").append('<li value="23"><a href="#">Julio Pino</a></li>');
        }
        if (cargo_seleccionado == "Arquitecto de Solución") {
            $("#dp2").append('<li value="24"><a href="#">Maria Padrón</a></li>');
            $("#dp2").append('<li value="25"><a href="#">Adalberto Gerdel</a></li>');
        }
        if (cargo_seleccionado == "Arquitecto de Base de Datos") {
            $("#dp2").append('<li value="26"><a href="#">Susan Calvin</a></li>');
        }
    }
}