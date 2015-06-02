<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleUsuario.aspx.cs" Inherits="GUI_Modulo7_DetalleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Detalle de Usuario
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
           <div id="alert_eliminar" runat="server">
           </div>
           <div id="alert" runat="server">
           </div>
            <form id="detalle_form" class="form-horizontal" action="#" runat="server">
            <div class="form-group">
		        <div  class="col-sm-10 col-md-10 col-lg-10">
                    <label>Nombre de Usuario: </label>
                    <input runat="server" id="input_usuario" type="text" class="form-control" name="usuario" readonly="true"/>
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-5 col-md-5 col-lg-10">
				    <label>Nombre:</label>
                    <input runat="server" id="input_nombre" type="text" class="form-control" name="nombre"/>
			    </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Apellido: </label>
                    <input runat="server" id="input_apelido" type="text" value="Perez" class="form-control" name="apellido"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Correo: </label>
                    <input runat="server" id="input_correo" type="text" class="form-control" name="correo"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Contrase&ntilde;a: </label>
                    <input runat="server" id="pswd_nuevo" type="password" value="1234567" class="form-control" name="pswd"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Confirmar Contrase&ntilde;a: </label>
                    <input runat="server" id="pswd_nuevo_conf" type="password" class="form-control" name="confirm-pswd"/>
		        </div>
            </div>
                <div class="form-group">
            <div class="col-sm-10 col-md-10 col-lg-10">
                <label>Rol: </label>
        <div class="form-group">
            <div class="col-sm-10 col-md-10 col-lg-10">
                 <div class="dropdown" runat="server" id="divComboTipoRol">
                 <asp:DropDownList ID="comboTipoRol"  class="btn btn-default dropdown-toggle" runat="server" >
               </asp:DropDownList>
             </div> 
            </div>
        </div>
            </div>
        </div>
        <label>Cargo: </label>
        <div class="form-group">  
            <div class="col-sm-10 col-md-10 col-lg-10" > 
             <div class="dropdown" runat="server" id="divComboCargo">
              <asp:DropDownList ID="comboCargo"  class="btn btn-default dropdown-toggle" runat="server" >
                 </asp:DropDownList>
                    </div>    
                 </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Pregunta de Seguridad:</label>
                    <input runat="server" id="input_pregunta" type="text" class="form-control" name="pregunta"/>
			    </div>
            </div>
            <div class="form-group">
			    <div class="col-sm-10 col-md-10 col-lg-10">
				    <label>Respuesta: </label>
                    <input runat="server" id="input_respuesta" type="text" class="form-control" name="respuesta" />
			    </div>
            </div>
                <br />
                <div class="form-group col-lg-10" id="accordion2" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="casosDeUso">
                        <h3 class="panel-title">
                            <a href="#collapseCasosDeUso" data-toggle="collapse" data-parent="#accordion">
                                Proyectos
                            </a>
                        </h3>
                    </div>
                    <div id="collapseCasosDeUso" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="">
                                <div class="table-responsive">
		                            <table id="table-projects" class="table table-striped table-hover">
			                            <thead>
				                            <tr>
					                            <th>Código</th>
					                            <th>Nombre</th>
					                            <th>Descripción</th>
					                            <th>Precio</th>
					                            <th>Acciones</th>
				                            </tr>
			                            </thead>
			                           <tbody id="tablebody" runat="server">
                                         <asp:Literal runat="server" ID="laTabla"></asp:Literal>
                                      </tbody>
		                            </table>
                             </div>
                        </div>
                    </div>
                </div>
                    </div>
                    </div>
                    &nbsp;&nbsp;<br />
                    <br />
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         &nbsp; &nbsp;
				            <button runat="server" type="submit" class="btn btn-primary" onserverclick="Unnamed1_Click">Modificar</button>
                        &nbsp;
				            <a class="btn btn-default" href="ListarUsuarios.aspx">Cancelar</a>
                         &nbsp;
                            <button runat="server" type="submit" class="btn btn-danger col-md-offset-6"  onserverclick="Unnamed1_Click1">Eliminar</button>
		        </div>
            </form>
        </div>
    <script src="js/Validacion.js"></script>
    <script>
        $(document).ready(function () {
            $('#table-projects').DataTable();
            $("#dprol li a").click(function () {

                $("#id-rol").html($(this).text() + ' <span class="caret"></span>');

            });
        });
    </script>
</asp:Content>

