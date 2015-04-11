<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="CrearMinuta.aspx.cs" Inherits="GUI_Modulo8_CrearMinuta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Agregar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1" runat="server">
   
    <link rel="stylesheet" type="text/css" href="css/bootstrap-multiselect.css"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap-datetimepicker.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/Minutas.css"/>

    <div class="col-xs-12">
        <form id="crearMinuta_form" class="form-horizontal" action="#">
        
            <div class="form-group">
                <label for="fechaReunion" class="col-xs-3 col-sm-12 col-md-3 control-label">Fecha:</label> 
                <div id="div_fechaReunion" class="col-xs-9 col-sm-12 col-md-8 col-lg-3 date">
				    <input type="text" class="form-control" name="fechaReunion" id="fechaReunion" />
	            </div>
            </div>

            <div class="form-group">
                <label for="motivo" class="col-xs-12 col-md-3 control-label">Motivo:</label> 
			    <div id="div_motivo" class="col-xs-12 col-md-8 col-lg-6">
                    <textarea name="motivo" placeholder="Exponga brevemente el motivo de la reunión" class="form-control" rows=4></textarea>			
			    </div>
            </div>

            <div class="form-group">
                <label for="participantes" class="col-xs-12 col-md-3 control-label">Participantes:</label>
                <div class="list-group col-xs-12 col-md-8 col-lg-6">
                    <div id="1_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onClick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" id="1_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">César Contreras</div>
                        </div>
                    </div>
                    <div id="2_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onClick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" id="2_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">Ana Pérez</div>
                        </div>
                    </div>
                    <div id="3_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onClick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" id="3_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">Daniel Sam</div>
                        </div>
                    </div>
                    <div id="4_par" class="panel panel-default panel-participante col-xs-12 col-sm-6" onClick="seleccionado(this)">
                        <div class="panel-boddy participante">
                            <div class="col-xs-1 check-contenedor"><input type="checkbox" id="4_par_check"/></div>
                            <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                            <div class="col-xs-8 nombre-participante">Ramón Quintero</div>
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
                            <div class="col-xs-12"><textarea name="desarrollo" placeholder="Desarrollo del Punto" class="form-control" rows=3></textarea></div>
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
                    <textarea name="observaciones" placeholder="Observaciones" class="form-control" rows=4></textarea>			
			    </div>
            </div>
        
           <div class="form-group">
               <div class="col-xs-12 col-md-9 botones">
				    <button class="btn btn-primary btn-right" onclick="return CrearMinuta()">Crear Minuta</button>
               </div>    
	       </div>
        </form> 
    </div>
</div>
<script type="text/javascript" src="js/bootstrap-multiselect.js"></script>
<script type="text/javascript" src="js/moment-with-locales.min.js"></script>
<script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/d004434a5ff76e7b97c8b07c01f34ca69e635d97/src/js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" src="js/crearMinuta.js"></script>
</asp:Content>

