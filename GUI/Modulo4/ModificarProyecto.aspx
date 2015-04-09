<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarProyecto.aspx.cs" Inherits="GUI_Modulo4_ModificarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                    <div class="input-group">
                      <input placeholder="Precio" type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                      <span class="input-group-addon">Bs</span>
                    </div>
                </div>
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3">
                    <button type="button" class="btn btn-primary closer" data-toggle="button" aria-pressed="true" autocomplete="off">Activo</button>
                    <button type="button" class="btn btn-primary closer" data-toggle="button" aria-pressed="false" autocomplete="off">Inactivo</button>
                </div>
	        </div>
            <div class="form-group">
		        <div class="col-sm-5 col-md-5 col-lg-5">
				    <button class="btn btn-primary" onclick="return checkform()">Modificar</button>
			    </div>
	        </div>
    </form>
        </div>
    <script src="js/Validacion.js"></script>

</asp:Content>