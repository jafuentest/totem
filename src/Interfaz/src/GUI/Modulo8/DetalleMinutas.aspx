<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleMinutas.aspx.cs" Inherits="GUI_Modulo8_DetalleMinutas" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><link rel="stylesheet" type="text/css" href="css/Minutas.css"/></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Detalle</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    
    <div class="col-xs-12">   
        
        
        <div class="form-group">
            <label for="nombreProyecto" class="col-xs-3 col-md-1 control-label">Proyecto:</label>             
            <label id="nombreProyecto" class="col-xs-9 col-md-4 control-label label-control">TOTEM</label>   

            <div class="col-xs-12 visible-sm visible-xs form-group"></div>

            <label for="fechaReunion" class="col-xs-3 col-md-1 control-label">Fecha:</label> 
            <label id="fechaReunion" name="fechaReunion" class="col-xs-9 col-md-4 control-label label-control">10-05-2013</label>

            <div class="col-xs-12 visible-sm visible-xs form-group"></div>

            <label for="horaReunion" class="col-xs-3 col-md-1 control-label">Hora:</label> 
            <label id="horaReunion" class="col-xs-9 col-md-1 control-label label-control">15:03</label> 

            <div class="col-xs-12 form-group"></div>

            <label class="col-xs-12 control-label">Motivo de la Reunión:</label> 
            <p id="motivo"class="col-xs-12">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sint voluptate vitae asperiores harum eaque id quisquam tempore suscipit deleniti! Eum, impedit debitis autem tempora quaerat unde voluptatem molestias possimus delectus eius sapiente dolorem minima blanditiis aspernatur veniam, porro illo nam vel pariatur. Nesciunt delectus, labore quasi neque corporis nostrum recusandae numquam non, enim dolore porro, illo quia! Quasi, tenetur, excepturi!
            </p>

            <div class="col-xs-12 form-group"></div>

            <label class="col-xs-12 col-md-2 control-label">Participantes:</label>            
            <div id="listaParticipante" class="list-group col-xs-12 col-md-12">
                
            </div>
            
            <label class="col-xs-12 control-label">Puntos Tratados:</label>
            
            <div class="col-xs-12">                   
                <div class="panel-group" id="listaPunto">
                    
                </div>
            </div>  
            
            <label class="col-xs-12 control-label">Observaciones:</label> 
            <p id="observaciones" class="col-xs-12">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sint voluptate vitae asperiores harum eaque id quisquam tempore suscipit deleniti! Eum, impedit debitis autem tempora quaerat unde voluptatem molestias possimus delectus eius sapiente dolorem minima blanditiis aspernatur veniam, porro illo nam vel pariatur. Nesciunt delectus, labore quasi neque corporis nostrum recusandae numquam non, enim dolore porro, illo quia! Quasi, tenetur, excepturi!
            </p>
            
            <label class="col-xs-12 control-label">Acuerdos y Compromisos:</label> 

            <div class="col-xs-12"> 
                <div class="panel-group" id="listaAcuerdo">               
                </div>
             </div>
            <div class="col-xs-12">             
                
             </div>
       </div>                                    
    </div>
               
    <div id="modalPersona" class="modal fade modalPersona">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>                
                <h4 class="modal-title">Detalle Persona</h4>
            </div>
            <div class="modal-body">                
                <div class="col-xs-12 col-md-3 img-participante-contenedor"><img class="img-responsive img-person" src="img/user.png" alt="Participante" /></div>
                <div class="col-xs-12 col-md-9">
                    <div class="form-group">
                        <div class="col-xs-12 form-group"></div>
                        
                        <label class="col-xs-4 control-label">Nombre:</label> 
                        <label class="col-xs-8 control-label label-control">Daniel Gregorio.</label>                         
                        
                        <label class="col-xs-4 control-label">Apellidos:</label> 
                        <label class="col-xs-8 control-label label-control">Sam Colina.</label>         
                        
                        <label class="col-xs-4 visible-sm visible-md visible-lg control-label">Identificación:</label> 
                        <label class="col-xs-4 visible-xs control-label">ID:</label> 
                        <label class="col-xs-8 control-label label-control">20563214.</label>  
                        
                        <label class="col-xs-4 control-label">Compañía:</label> 
                        <label class="col-xs-8 control-label label-control">Compañia de Software.</label>   
                        
                        <label class="col-xs-4 control-label">Nombre Proyecto:</label> 
                        <label class="col-xs-8 control-label label-control">TOTEM.</label>                           
                        
                        <div class="col-xs-12 visible-xs temp-form form-group"></div>

                        <label class="col-xs-4 control-label">Rol:</label> 
                        <label class="col-xs-8 control-label label-control">Lider de Proyecto.</label>       
                    </div>
                </div>                
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                
            </div>
        </div>
    </div>
</div>

<script type="text/javascript" src="js/detalleMinuta.js"></script>
<script type="text/javascript">
    $('.panel-participante').on("click", function ()
    {
        $("#modalPersona").modal('show');
    });
    
</script>
</asp:Content>

