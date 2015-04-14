<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleMinutas.aspx.cs" Inherits="GUI_Modulo8_DetalleMinutas" %>
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
            <label id="fechaReunion" class="col-xs-9 col-md-4 control-label label-control">10-05-2013</label>

            <div class="col-xs-12 visible-sm visible-xs form-group"></div>

            <label for="horaReunion" class="col-xs-3 col-md-1 control-label">Hora:</label> 
            <label id="horaReunion" class="col-xs-9 col-md-1 control-label label-control">15:03</label> 

            <div class="col-xs-12 form-group"></div>

            <label class="col-xs-12 control-label">Motivo de la Reunión:</label> 
            <p class="col-xs-12">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sint voluptate vitae asperiores harum eaque id quisquam tempore suscipit deleniti! Eum, impedit debitis autem tempora quaerat unde voluptatem molestias possimus delectus eius sapiente dolorem minima blanditiis aspernatur veniam, porro illo nam vel pariatur. Nesciunt delectus, labore quasi neque corporis nostrum recusandae numquam non, enim dolore porro, illo quia! Quasi, tenetur, excepturi!
            </p>

            <div class="col-xs-12 form-group"></div>

            <label class="col-xs-12 col-md-2 control-label">Participantes:</label>            
            <div class="list-group col-xs-12 col-md-12">
                <div id="1_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Daniel Sam</p>
                            <p class="participante-rol"><small>Líder de Proyecto</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="2_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Eloise Chávez</p>
                            <p class="participante-rol"><small>Product Owner</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="3_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                    <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">César Contreras</p>
                            <p class="participante-rol"><small>Desarrollador</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="4_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Jonathan González</p>
                            <p class="participante-rol"><small>Desarrollador</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="5_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Gabriel Sarmiento</p>
                            <p class="participante-rol"><small>Desarrollador</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="5_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Henry Velásquez</p>
                            <p class="participante-rol"><small>Analísta de Sistemas</small></p>
                        </div>                        
                    </div>
                </div>
                <div id="5_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                    <div class="panel-boddy participante">                                                
                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                        <div class="col-xs-10 col-sm-8 nombre-participante">
                            <p class="participante-nombre">Nancy Aguila</p>
                            <p class="participante-rol"><small>Stakeholder</small></p>
                        </div>                        
                    </div>
                </div>
            </div>
            
            <label class="col-xs-12 control-label">Puntos Tratados:</label>
            
            <div class="col-xs-12">                   
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default" id="panel1">
                        <div class="panel-heading">
                             <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#punto1" 
                                   href="#collapseOne">
                                  Punto 1: Este es el nombre de un Punto
                                </a>
                              </h4>
                        </div>
                        <div id="punto1" class="panel-collapse collapse">
                            <div class="panel-body">Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.</div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="panel2">
                        <div class="panel-heading">
                             <h4 class="panel-title">
                        <a data-toggle="collapse" data-target="#collapseTwo" 
                           href="#collapseTwo" class="collapsed">
                          Punto 2: Este es el nombre de un Punto
                        </a>
                      </h4>

                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.</div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="panel3">
                        <div class="panel-heading">
                             <h4 class="panel-title">
                        <a data-toggle="collapse" data-target="#collapseThree"
                           href="#collapseThree" class="collapsed">
                          Punto 3: Este es el nombre de un Punto
                        </a>
                      </h4>

                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.</div>
                        </div>
                    </div>
                </div>
            </div>  
            
            <label class="col-xs-12 control-label">Observaciones:</label> 
            <p class="col-xs-12">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sint voluptate vitae asperiores harum eaque id quisquam tempore suscipit deleniti! Eum, impedit debitis autem tempora quaerat unde voluptatem molestias possimus delectus eius sapiente dolorem minima blanditiis aspernatur veniam, porro illo nam vel pariatur. Nesciunt delectus, labore quasi neque corporis nostrum recusandae numquam non, enim dolore porro, illo quia! Quasi, tenetur, excepturi!
            </p>
            
            <label class="col-xs-12 control-label">Acuerdos y Compromisos:</label> 

            <div class="col-xs-12"> 
                <div class="panel-group" id="acordion">               
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#collapsePrimero" 
                                   href="#collapseOne">
                                   Conferencia de Skype control de avances.
                                </a>
                            </h4>                                   
                        </div>
                        <div id="collapsePrimero" class="panel-collapse collapse">
                            <div class="panel-body">

                                <label class="col-xs-3 control-label">Fecha:</label>
                                <label class="col-xs-9 control-label">10-05-2015</label> 
                                             
                                <label for="observacionesReunion" class="control-label col-xs-12">Involucrados:</label> 
                                
                                <div id="1_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">Daniel Sam</p>
                                            <p class="participante-rol"><small>Líder de Proyecto</small></p>
                                        </div>                        
                                    </div>
                                </div>               
                                <div id="3_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">César Contreras</p>
                                            <p class="participante-rol"><small>Desarrollador</small></p>
                                        </div>                        
                                    </div>
                                </div>
                                <div id="4_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">Jonathan González</p>
                                            <p class="participante-rol"><small>Desarrollador</small></p>
                                        </div>                        
                                    </div>
                                </div>
                                <div id="5_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">Gabriel Sarmiento</p>
                                            <p class="participante-rol"><small>Desarrollador</small></p>
                                        </div>                        
                                    </div>
                                </div> 
                            </div>
                        </div>                    
                    </div> 
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-target="#collapse2" 
                                   href="#collapseOne">
                                   Este es otro compromiso.
                                </a>
                            </h4>                                   
                        </div>
                        <div id="collapse2" class="panel-collapse collapse">
                            <div class="panel-body">

                                <label class="col-xs-3 control-label">Fecha:</label>
                                <label class="col-xs-9 control-label">10-05-2015</label> 
                                             
                                <label for="observacionesReunion" class="control-label col-xs-12">Involucrados:</label> 
                                <div id="1_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">Daniel Sam</p>
                                            <p class="participante-rol"><small>Líder de Proyecto</small></p>
                                        </div>                        
                                    </div>
                                </div>
                                <div id="2_par" class="panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3">
                                    <div class="panel-boddy participante">                                                
                                        <div class="col-xs-2 img-participante-contenedor"><img class="img-participante" src="img/user.png" alt="Participante" /></div>
                                        <div class="col-xs-10 col-sm-8 nombre-participante">
                                            <p class="participante-nombre">Eloise Chávez</p>
                                            <p class="participante-rol"><small>Product Owner</small></p>
                                        </div>                        
                                    </div>
                                </div>
                            </div>
                        </div>                    
                    </div> 
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

<script type="text/javascript">
    $('.panel-participante').on("click", function ()
    {
        $("#modalPersona").modal('show');
    });
    
</script>
</asp:Content>

