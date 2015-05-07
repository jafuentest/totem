<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="CrearMinuta.aspx.cs" Inherits="GUI_Modulo8_CrearMinuta" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Agregar</asp:Content>
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
                <div class="list-group col-xs-12 col-md-8 col-lg-6">
                    <div id="1_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onclick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" class="participante-check" id="1_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">
                                <p class="participante-nombre">César Contreras</p>
                                <p class="participante-rol"><small>Líder de Proyecto</small></p>
                            </div>
                        </div>
                    </div>
                    <div id="2_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onclick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" class="participante-check" id="2_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">
                                <p class="participante-nombre">Daniel Sam</p>
                                <p class="participante-rol"><small>Product Owner</small></p>
                            </div>
                        </div>
                    </div>
                    <div id="3_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onclick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" class="participante-check" id="3_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">
                                <p class="participante-nombre">Ramón Quintero</p>
                                <p class="participante-rol"><small>Desarrollador</small></p>
                            </div>
                        </div>
                    </div>
                    <div id="4_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onclick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" class="participante-check" id="4_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">
                                <p class="participante-nombre">Ana Pérez</p>
                                <p class="participante-rol"><small>Stakeholder</small></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xs-12 form-group"></div>
            <div class="form-group">
                <label for="puntosMinuta" class="col-xs-12 col-md-3 control-label">Puntos Tratados:</label>
                <div id="puntosMinuta" class="list-group col-xs-12 col-md-8 col-lg-6">
                    <div id="1-pun-div" class="panel panel-default panel-punto">
                        <div class="panel-body panel-minuta">
                            <div class="col-xs-12">
                                <button type="button" id="1-pun"class="close" data-dismiss="alert" aria-label="Close" onClick='borrarPunto(this);'><span aria-hidden="true">&times;</span></button>
                                <input class="form-control" placeholder="Título del Punto" type="text"/>
                            </div>
                            <div class="col-xs-12 form-group"></div>
                            <div class="col-xs-12"><textarea name="desarrollo" placeholder="Desarrollo del Punto" class="form-control"  style="text-align: justify;resize:none;" rows=3></textarea></div>
                        </div>
                    </div>
                </div>
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
                    <div id="1-acuerdo-div" class="panel panel-default panel-punto">
                        <div class="panel-body panel-minuta">
                            <div class="col-xs-12">
                                <button type="button" id="1-acuerdo"class="close" data-dismiss="alert" aria-label="Close" onClick='borrarAcuerdo(this);'><span aria-hidden="true">&times;</span></button>
                                <input class="form-control" placeholder="Acuerdo o Compromiso" type="text"/>
                            </div>
                            <div class="col-xs-12 form-group"></div>
                            <div class="col-xs-12 col-md-4 date">
				                <input type="text" class="form-control fechaAcuerdo" placeholder="Fecha de Entrega" name="1fechaAcuerdo" id="1fechaAcuerdo"/>
                            </div>
                            <div class="col-xs-12 visible-xs form-group"></div>
                            <div class="col-xs-12 col-md-8">
                                <select class="seleccionMultiple" multiple="multiple">
                                    <option value="1">César Contreras</option>
                                    <option value="2">Ana Pérez</option>
                                    <option value="3">Daniel Sam</option>
                                    <option value="4">Ramón Quintero</option>
                                </select>
                            </div>
                        </div>
                    </div>
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
				    <button type="button"  class="btn btn-primary" onclick="validar();">Agregar</button>
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
                    <h4 class="modal-title" >¿Desea agregar la minuta?</h4>
                </div>
                <div class="modal-footer">
                    <a id="btn-confirmar" type="button" class="btn btn-primary" href="ConsultarMinuta.aspx?success=1">Aceptar</a>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>


<script type="text/javascript" src="js/bootstrap-multiselect.js"></script>
<script type="text/javascript" src="js/moment-with-locales.min.js"></script>
<script type="text/javascript" src="js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" src="js/crearMinuta.js"></script>
<script type="text/javascript" src="js/validacionesCrearMinuta.js"></script>
</asp:Content>

