<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master"  AutoEventWireup="true" CodeFile="CrearProyecto.aspx.cs" Inherits="GUI_Modulo4_CrearProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        textarea {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Crear</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
    <form id="register_form" class="form-horizontal" action="#">
        <div class="form-group">
		    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				<input type="text" placeholder="Codigo" class="form-control" name="codigo"/>
			</div>
            &nbsp;
			<div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				<input type="text" placeholder="Nombre" class="form-control" name="nombre"/>
			</div>
		</div>
        <div class="form-group">
	        <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		        <textarea placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
		        <input placeholder="Precio" class="form-control" name="descripcion"/>
		    </div>
	    </div>
        <div class="form-group">
		    <div class="col-sm-5 col-md-5 col-lg-5">
				<button class="btn btn-primary" onclick="return checkform()">Crear</button>
			</div>
	    </div>
        <div class="form-group">
            
        </div>
    </form>
        </div>
    <script src="js/Validacion.js"></script>
</asp:Content>

