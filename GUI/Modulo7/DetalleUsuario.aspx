<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleUsuario.aspx.cs" Inherits="GUI_Modulo7_DetalleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Detalle de Usuario
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
        <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
            <form id="detalle-form" class="form-horizontal" action="#">
            <div class="form-group">
		        <div  class="col-sm-10 col-md-10 col-lg-10">
                    <label>Nombre de Usuario: </label>
                    <input type="text" value="aaciti" class="form-control" name="usuario" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-5 col-md-5 col-lg-10">
				    <label>Nombre:</label>
                    <input type="text" value="Luis" class="form-control" name="nombre"/>
			    </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Apellido: </label>
                    <input type="text" value="Perez" class="form-control" name="apellido"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Correo: </label>
                    <input type="text" value="aaciti@totem.com" class="form-control" name="correo"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Contrase&ntilde;a: </label>
                    <input type="password" value="1234567" class="form-control" name="pswd"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Confirmar Contrase&ntilde;a: </label>
                    <input type="password" value="1234567" class="form-control" name="confirm-pswd"/>
		        </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-5 col-lg-5">
				    <label>Cargo:</label>
                    <input type="text" value="Desarrollador" class="form-control" name="cargo" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Pregunta de Seguridad:</label>
                    <input type="text" value="Cual es el apellido de soltera de tu mama?" class="form-control" name="pregunta"/>
			    </div>
            </div>
            <div class="form-group">
			    <div class="col-sm-10 col-md-10 col-lg-10">
				    <label>Respuesta: </label>
                    <input type="text" value="Jimenez" class="form-control" name="respuesta" />
			    </div>
            </div>
                <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary">Editar</button>
                        &nbsp;
				            <a class="btn btn-default" href="ListarUsuarios.aspx">Cancelar</a>
                         &nbsp;
                            <a class="btn btn-danger" href="ListarUsuarios.aspx?success=1">Eliminar</a>
		        </div>
            </form>
        </div>
    <script src="js/Validacion.js"></script>
</asp:Content>

