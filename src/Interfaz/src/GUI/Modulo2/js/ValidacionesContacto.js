var nroContactos = 1;


function agregarContacto() {
    nroContactos++;

    idContacto = nroContactos.toString() + "-contacto-div";
    idBoton = nroContactos.toString() + "-contacto";

    if (nroContactos < 4) {
        $('#contactoEmpresa').append(
            "<div id='" + idContacto + "' class='panel panel-default panel-punto'>"
            + "  <div class='panel-body panel-minuta'>"
            + "     <div class='col-xs-12'>"
            + "         <div class='form-group'> "
            + "          <div class='col-xs-12'> "
            + "         <button type='button' id=" + idBoton + " class='close col-md-15' data-dismiss='alert' aria-label='Close' onClick='borrarContacto(this);' ><span aria-hidden='true'>&times;</span></button>"
            + "     </div>"
            + "     </div>"
            + "     <div class='form-group'> "
            + "         <div class='col-xs-10'> "
            + "             <input class='form-control' placeholder='Nombres del Contacto' type='text'/> "
            + "             </div> "
            + "         </div>"
            + "    <div class='col-xs-10 form-group'></div>  "
            + "  <div class='form-group'> "
            + "  <div class='col-xs-10'>"
            + "  <input class='form-control' placeholder='Apellidos del Contacto' type='text'/>"
            + "  </div>"
            + "  </div>"
            + " <div class='col-xs-12 form-group'></div> "
            + "<div class='form-group'>"
            + "<div class='btn-group col-sm-10 col-md-10 col-lg-10'>"
            + "<button type='button' class='btn btn-default col-sm-10 col-md-10 col-lg-10'>Seleccione un cargo..</button>"
            + "<button type='button' class='btn btn-default dropdown-toggle col-md-2' data-toggle='dropdown' aria-expanded='false'>"
            + "<span class='caret'></span>"
            + "<span class='sr-only'>Toggle Dropdown</span>"
            + "</button>"
            + "<ul class='dropdown-menu' role='menu'>"
            + "<li><a href='#'>Gerente General</a></li>"
            + "<li><a href='#'>Gerente de Proyectos</a></li>"
            + "<li><a href='#'>Líder de Proyectos</a></li>"
            + "</ul>"
            + " </div>"
            + " <div class='col-sm-1 col-md-1 col-lg-1'>"
            + "<button type='button' class='btn btn-default btn-circle glyphicon glyphicon-plus' onclick='agregarContacto()'></button>"
            + " </div>"
            + " </div>"
            + "<div class='col-xs-10 form-group'></div>"
            + "<div class='form-group'>"
            + "<div class='col-xs-10'>"
            + "<input class='form-control' placeholder='Teléfono celular' type='text' />"
            + "</div>"
            + "</div>"
            + "<div class='col-xs-10 form-group'></div>"
            + "<div class='form-group'>"
            + "<div class='col-xs-10'>"
            + "<input class='form-control' placeholder='Teléfono celular alternativo' type='text' />"
            + "</div>"
            + "</div>"
            + "</div>"
            + "</div>"
            + "</div>"
        );
    }
}


function borrarContacto(obj) {
    if ($('#contactoEmpresa').find('.panel-punto').length > 1) {
        idDiv = obj.id + "-div";
        $('#' + idDiv).remove();
        nroContactos = nroContactos - 1;
    }
}