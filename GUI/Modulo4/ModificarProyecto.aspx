<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarProyecto.aspx.cs" Inherits="GUI_Modulo4_ModificarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="bootstrap-switch-master/docs/css/highlight.css" rel="stylesheet">
    <link href="bootstrap-switch-master/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
    <link href="bootstrap-switch-master/docs/css/main.css" rel="stylesheet">
    <style>
        textarea {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Modificar</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
    <form id="modify_form" class="form-horizontal" action="#">
        <div class="form-group">
                <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				    <input type="text" placeholder="Nombre" class="form-control" value="Twitter" name="nombre"/>
			    </div>
		        <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				    <input type="text" placeholder="Codigo" class="form-control" value="TWI" name="codigo"/>
			    </div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		        </div>
	        </div>

            <div class="form-group">
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                    <div class="input-group">
                      <input placeholder="Precio" type="text" class="form-control" value="2.000.000,00" aria-label="Amount (to the nearest dollar)">
                      <span class="input-group-addon">Bs</span>
                    </div>
                </div>
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3 col-md-offset-4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="switch-onColor" type="checkbox" checked data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" data-off-color="warning">
                </div>
	        </div>
            <div class="form-group">
		        <div class="col-sm-2 col-md-2 col-lg-2">
				    <button class="btn btn-primary" onclick="return checkform()">Modificar</button>
			    </div>
                <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-default" onclick="return checkform()">Cancelar</button>
			    </div>
	        </div>
    </form>
        </div>
    <script src="js/Validacion.js"></script>
    <script src="bootstrap-switch-master/docs/js/bootstrap.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/highlight.js"></script>
    <script src="bootstrap-switch-master/dist/js/bootstrap-switch.js"></script>
    <script src="bootstrap-switch-master/docs/js/main.js"></script>

</asp:Content>