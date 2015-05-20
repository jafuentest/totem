function agregarActor() {
	agregarObjeto(document.form_casodeuso.actores1, document.form_casodeuso.actores2);
}

function agregarRequerimiento() {
	agregarObjeto(document.form_casodeuso.requerimientos1, document.form_casodeuso.requerimientos2);
}

function agregarObjeto(m1, m2) {
	for (var i = 0; i < m1.length ; i++)
		if (m1.options[i].selected === true)
			m2.options[m2.length] = new Option(m1.options[i].text);

	for (i = (m1.length - 1) ; i >= 0; i--)
		if (m1.options[i].selected === true)
			m1.options[i] = null;
}

function eliminarActor() {
	eliminarObjeto(document.form_casodeuso.actores1, document.form_casodeuso.actores2);
}

function eliminarRequerimiento() {
	eliminarObjeto(document.form_casodeuso.requerimientos1, document.form_casodeuso.requerimientos2);
}

function eliminarObjeto(m1, m2) {
	for (var i = 0; i < m2.length ; i++)
		if (m2.options[i].selected === true)
			m1.options[m1.length] = new Option(m2.options[i].text);

	for (var i = (m2.length - 1) ; i >= 0; i--)
		if (m2.options[i].selected === true)
			m2.options[i] = null;
}

function agregarPrecondicion() {
	child = document.getElementById("div-precondiciones").lastElementChild.lastElementChild;
	child.innerHTML = "<button type=\"button\" class=\"btn btn-danger btn-circle glyphicon glyphicon-remove\" onclick=\"eliminarCampo(this)\"></button>";
	codigo = "<div class=\"form-group\">" +
			"    <div class=\"col-sm-11 col-md-11 col-lg-11\">" +
			"        <input type=\"text\" placeholder=\"Precondición\" class=\"form-control\" id=\"precondicion_n\" name=\"precondicion_n\"/>" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\">" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarPrecondicion()\"></button>" +
			"    </div>" +
			"</div>";
	$("#div-precondiciones").append(codigo);
	actualizarIdPrecondiciones();
}

function agregarEscenario() {
	child = document.getElementById("div-escenarios").lastElementChild.lastElementChild;
	child.innerHTML = "<button type=\"button\" class=\"btn btn-danger btn-circle glyphicon glyphicon-remove\" onclick=\"eliminarCampo(this)\"></button>";
	codigo = "<div class=\"form-group\"\">" +
			"    <div class=\"col-sm-11 col-md-11 col-lg-11\">" +
			"        <input type=\"text\" placeholder=\"Paso\" class=\"form-control\" id=\"escenario_n\"/>" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\">" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarEscenario()\"></button>" +
			"    </div>" +
			"</div>";
	$("#div-escenarios").append(codigo);
	actualizarIdEscenarios();
}

function agregarExtension() {
	child = document.getElementById("div-extensiones").lastElementChild.lastElementChild;
	child.innerHTML = "<button type=\"button\" class=\"btn btn-danger btn-circle glyphicon glyphicon-remove\" onclick=\"eliminarCampo(this)\"></button>";
	codigo = "<div class=\"form-group\"\">" +
			"    <div class=\"col-sm-11 col-md-11 col-lg-11\">" +
			"        <textarea placeholder=\"Extensión\" class=\"form-control\" id=\"extension_0\" name=\"extension_n\"></textarea>" +
			"    </div>" +
			"    <div class=\"col-sm-1 col-md-1 col-lg-1\">" +
			"        <button type=\"button\" class=\"btn btn-default btn-circle glyphicon glyphicon-plus\" onclick=\"agregarExtension()\"></button>" +
			"    </div>" +
			"</div>";
	$("#div-extensiones").append(codigo);
	actualizarIdExtensiones();
}

function actualizarIdPrecondiciones() {
	escenarios = $("[id^=precondicion_]");
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = "precondicion_" + i;
		escenario.name = "precondicion_" + i;
	}
}

function actualizarIdEscenarios() {
	escenarios = $("[id^=escenario_]");
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = "escenario_" + i;
		escenario.name = "escenario_" + i;
	}
}

function actualizarIdExtensiones() {
	escenarios = $("[id^=extension_]");
	for (i = 0; i < escenarios.length; i++) {
		escenario = escenarios[i];
		escenario.id = "extension_" + i;
		escenario.name = "extension_" + i;
	}
}

function eliminarCampo(caller) {
	var parent = caller.parentElement.parentElement;
	parent.parentElement.removeChild(parent);
}
