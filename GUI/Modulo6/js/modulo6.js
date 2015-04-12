function agregarActor() {
	agregarObjeto(document.form_casodeuso.actores1, document.form_casodeuso.actores2);
}

function agregarRequerimiento() {
	agregarObjeto(document.form_casodeuso.requerimientos1, document.form_casodeuso.requerimientos2);
}

function agregarObjeto(m1, m2) {
	m1len = m1.length;
	for (i = 0; i < m1len ; i++) {
		if (m1.options[i].selected === true) {
			m2len = m2.length;
			m2.options[m2len] = new Option(m1.options[i].text);
		}
	}

	for (i = (m1len - 1) ; i >= 0; i--) {
		if (m1.options[i].selected === true) {
			m1.options[i] = null;
		}
	}
}

function eliminarActor() {
	eliminarObjeto(document.form_casodeuso.actores1, document.form_casodeuso.actores2);
}

function eliminarRequerimiento() {
	eliminarObjeto(document.form_casodeuso.requerimientos1, document.form_casodeuso.requerimientos2);
}

function eliminarObjeto(m1, m2) {
	m2len = m2.length;
	for (i = 0; i < m2len ; i++) {
		if (m2.options[i].selected === true) {
			m1len = m1.length;
			m1.options[m1len] = new Option(m2.options[i].text);
		}
	}
	for (i = (m2len - 1) ; i >= 0; i--) {
		if (m2.options[i].selected === true) {
			m2.options[i] = null;
		}
	}
}

function agregarPrecondicion() {
	precondiciones = document.getElementById("div-precondiciones");
	child = precondiciones.lastElementChild.lastElementChild;
	child.innerHTML = '<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>';
	codigo = '<div class="form-group"">'
			 + '	<div class="col-sm-11 col-md-11 col-lg-11">'
			 + '		<input type="text" placeholder="Precondición" class="form-control" id="precondicion_n"/>'
			 + '	</div>'
			 + '	<div class="col-sm-1 col-md-1 col-lg-1">'
			 + '		<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarPrecondicion()"></button>'
			 + '	</div>'
			 + '</div>';
	precondiciones.innerHTML += codigo;
	actualizarIdPrecondiciones();
}

function agregarEscenario() {
	escenarios = document.getElementById("div-escenarios");
	child = escenarios.lastElementChild.lastElementChild;
	child.innerHTML = '<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>';
	codigo = '<div class="form-group"">'
			 + '	<div class="col-sm-11 col-md-11 col-lg-11">'
			 + '		<input type="text" placeholder="Paso" class="form-control" id="escenario_n"/>'
			 + '	</div>'
			 + '	<div class="col-sm-1 col-md-1 col-lg-1">'
			 + '		<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarEscenario()"></button>'
			 + '	</div>'
			 + '</div>';
	escenarios.innerHTML += codigo;
	actualizarIdEscenarios();
}

function agregarExtension() {
	extensiones = document.getElementById("div-extensiones");
	child = extensiones.lastElementChild.lastElementChild;
	child.innerHTML = '<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>';
	codigo = '<div class="form-group"">'
			 + '	<div class="col-sm-11 col-md-11 col-lg-11">'
			 + '		<textarea placeholder="Extensión" class="form-control" id="extension_0" name="extension_n"></textarea>'
			 + '	</div>'
			 + '	<div class="col-sm-1 col-md-1 col-lg-1">'
			 + '		<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarExtension()"></button>'
			 + '	</div>'
			 + '</div>';
	extensiones.innerHTML += codigo;
	actualizarIdExtensiones();
}

function actualizarIdPrecondiciones() {
	escenarios = $('[id^=precondicion_]');
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = 'precondicion_' + i;
		escenario.name = 'precondicion_' + i;
	}
}

function actualizarIdEscenarios() {
	escenarios = $('[id^=escenario_]');
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = 'escenario_' + i;
		escenario.name = 'escenario_' + i;
	}
}

function actualizarIdExtensiones() {
	escenarios = $('[id^=extension_]');
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = 'extension_' + i;
		escenario.name = 'extension_' + i;
	}
}

function eliminarCampo(caller) {
	parent = caller.parentElement.parentElement;
	parent.parentElement.removeChild(parent);
}
