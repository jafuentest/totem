<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="EditarPerfil.aspx.cs" Inherits="GUI_Modulo7_EditarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Editar Perfil
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
           <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">

          <div id="alert_nombre" runat="server">
         </div>
         <div id="alert_apellido" runat="server">
          </div>
          <div id="alert_username" runat="server">
          </div>
          <div id="alert_correo" runat="server">
          </div>
          <div id="alert_pregunta" runat="server">
          </div>
          <div id="alert_respuesta" runat="server">
           </div>
           <div id="alert_password" runat="server">
           </div>

                <div class="col-sm-10 col-md-10 col-lg-10" id="alertlocal" >
                </div>
            <form id="detalle_form" class="form-horizontal" action="#" runat="server">
            <div class="form-group">
		        <div  class="col-sm-10 col-md-10 col-lg-10">
                    <label>Nombre de Usuario: </label>
                    <input id="input_usuario" type="text" class="form-control" name="usuario" runat="server"/>
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Nombre:</label>
                    <input id="input_nombre" type="text"  class="form-control" name="nombre" runat="server"/>
			    </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Apellido: </label>
                    <input id="input_apellido" type="text"  class="form-control" name="apellido" runat="server"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Correo: </label>
                    <input id="input_correo" type="text"  class="form-control" name="correo" runat="server"/>
		        </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Pregunta de Seguridad:</label>
                    <input id="input_pregunta" type="text" class="form-control" name="pregunta" runat="server"/>
			    </div>
            </div>
            <div class="form-group">
			    <div class="col-sm-10 col-md-10 col-lg-10">
				    <label>Respuesta: </label>
                    <input id="input_respuesta" type="text" class="form-control" name="respuesta" runat="server" />
			    </div>
            </div>
            <div class="form-group">
                &nbsp; &nbsp;
                <button runat="server" class="btn btn-info" data-toggle="modal" data-target="#modal-change-pswd" onserverclick="Unnamed1_Click1">Cambiar Contrase&ntilde;a</button>
            </div>
                <div class="form-group">
                         &nbsp; &nbsp;
				            <button runat="server" class="btn btn-primary" type="submit" onserverclick="btn_editar_Click">Editar</button>
                        &nbsp;
				            <a id="btn_cancel" href="../Modulo4/PerfilProyecto.aspx" class="btn btn-default">Cancelar</a>
		        </div>
            </form>
        </div>
            <div id="modal_change_pswd" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true" runat="server">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button  class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title" >Cambiar Contrase&ntilde;a</h4>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
                <form id ="pswd-form">
              <div class="form-group">
                <label for="pswd-viejo" class="control-label">Contrase&ntilde;a Actual:</label>
                <input type="password" class="form-control" id="pswd_viejo"  name="pswdviejo" runat="server"/>
              </div>
              <div class="form-group">
                <label for="pswd-nuevo" class="control-label">Contrase&ntilde;a Nueva:</label>
                <input class="form-control" type="password" id="pswd_nuevo" name="pswdnuevo" runat="server"/>
              </div>
              <div class="form-group">
                <label for="pswd-nuevo-conf" class="control-label">Confirmar Contrase&ntilde;a Nueva:</label>
                <input class="form-control" type="password" id="pswd_nuevo_conf" name="pswdnuevoconf" runat="server"/>
              </div>
        </form>
            </div>
          </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" type="submit"  runat="server">Confirmar</button>
          <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
        </div>
      </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
  </div><!-- /.modal -->
    <script src="js/Validacion.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#modal-change-pswd').on('shown.bs.modal', function () {
                $('#pswd-form').formValidation('resetForm', true);
            });
            $('#btn-confirm').on('click', function () {
                $('#modal-change-pswd').modal('hide');//se esconde el modal
                $('#alertlocal').addClass("alert alert-success alert-dismissible");
                $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha cambiado exitosamente</div>");
            });
        });
    </script>
</asp:Content>

