<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarMinuta.aspx.cs" Inherits="GUI_Modulo8_ModificarMinuta" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <link rel="stylesheet" type="text/css" href="css/bootstrap-multiselect.css"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap-datetimepicker.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/Minutas.css"/>

    <div class="col-xs-12">
        
        <form id="crearMinuta_form" class="form-horizontal">
            <div class="row" id="alertas"></div>
            <div class="form-group">
                <label for="fechaReunion" class="col-xs-3 col-sm-12 col-md-3 control-label">Fecha:</label> 
                <div id="div_fechaReunion" class="col-xs-9 col-sm-12 col-md-8 col-lg-3 date">
				    <input type="text" class="form-control" name="fechaReunion" id="fechaReunion" />
	            </div>
            </div>

            <div class="form-group">
                <label for="motivo" class="col-xs-12 col-md-3 control-label">Motivo:</label> 
			    <div id="div_motivo" class="col-xs-12 col-md-8 col-lg-6">
                    <textarea name="motivo" id="motivo" placeholder="Exponga brevemente el motivo de la reunión" class="form-control" style="text-align: justify;resize:none;" rows=4></textarea>			
			    </div>
            </div>

            <div class="form-group">
                <label for="participantes" class="col-xs-12 col-md-3 control-label">Participantes:</label>
                <div id="listaParticipante" class="list-group col-xs-12 col-md-8 col-lg-6"></div>
            </div>


            <div class="col-xs-12 form-group"></div>
            <div class="form-group">
                <label for="puntosMinuta" class="col-xs-12 col-md-3 control-label">Puntos Tratados:</label>
                <div id="puntosMinuta" class="list-group col-xs-12 col-md-8 col-lg-6"></div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-md-9 botones">
                    <button type="button" id="BotonAgregarPunto" class="btn btn-default btn-circle" autocomplete="off" onClick="agregarPunto();">
		  		        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
				    </button>
                </div>
            </div>



            <div class="form-group">
                <label for="acuerdosMinuta" class="col-xs-12 col-md-3 control-label">Acuerdos y Compromisos:</label>
                <div id="acuerdosMinuta" class="list-group col-xs-12 col-md-8 col-lg-6">
                   
                </div>
            </div>

             <div class="form-group">
                <div class="col-xs-12 col-md-9 botones">
                    <button type="button" id="BotonAgregarAcuerdo" class="btn btn-default btn-circle" autocomplete="off" onClick="agregarAcuerdo();">
		  		        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
				    </button>
                </div>
            </div>

            <div class="form-group">
                <label for="observaciones" class="col-xs-12 col-md-3 control-label">Observaciones:</label> 
			    <div id="div_observaciones" class="col-xs-12 col-md-8 col-lg-6">
                    <textarea name="observaciones" id="observaciones" placeholder="Observaciones" class="form-control" style="text-align: justify;resize:none;" rows=4></textarea>			
			    </div>
            </div>
        
           <div class="form-group">
               <div class="col-xs-12 col-md-9 botones" style="position:absolute; left:120px">
				    <button type="button"  class="btn btn-primary navbar-center" onclick="validar();">Modificar</button>
                    <a type="button"  class="btn btn-default" href="ConsultarMinuta.aspx" >Cancelar</a>
               </div>    
	       </div>
        </form> 
        <br/> <br/>
    </div>

    <div id="confirmacion" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" >¿Desea guardar los cambios?</h4>
                </div>
                <div class="modal-footer">
                    <a id="btn-confirmar" type="button" class="btn btn-primary" onClick="aceptarConfirmacion();">Aceptar</a>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript" src="js/bootstrap-multiselect.js"></script>
    <script type="text/javascript" src="js/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript" src="js/ModificarMinuta.js"></script>
    <script type="text/javascript" src="js/validacionesGuardarMinuta.js"></script>




</asp:Content>




