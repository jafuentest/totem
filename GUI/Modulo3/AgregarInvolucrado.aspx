<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Agregar Personal Involucrado</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
              <div class="col-sm-12 col-md-12 col-lg-12">
                 <div id="alertlocal" >
                 </div>
              	 <form id="agregarpersonal" class="form-horizontal" action="ListarPersonalInvolucrado.aspx" method="POST" role="form" runat="server">
                        <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione el tipo de empresa:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_empresa" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp1" class="dropdown-menu" role="menu"  onclick="cargarcargo();">
                                    <li value="1"><a href="#">Cliente</a></li>
                                    <li value="2"><a href="#">Compañia de Software</a></li>
                                  </ol>
                                </div>  
                                      
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Listar Personal según el cargo:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_cargo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" >
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp3" class="dropdown-menu" role="menu" onclick="cargarpersonal();">
                                                                                                         
                                  </ol>
                                </div> 
                                        
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione Personal:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_personal" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp2" class="dropdown-menu" role="menu">
                                  </ol>
                                </div> 
                                  
                              </div>
                        </div>
                       <br />
                       <div class="col-sm-12 col-md-12 col-lg-12">
                       <div  id="table-responsive">
                           <table id="table-example" class=" table table-striped table-hover display">
                             <thead>
                               <tr>
                                 <th>Nombre</th>
                                 <th>Apellido</th>
                                 <th>Cargo</th>
                                 <th>Compañia</th>
                                 <th>Eliminar</th>
                               </tr>
                             </thead>
                            <tbody>
                           </tbody>
                         </table>
                    </div>
                   <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
                   <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                           <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                           <h4 class="modal-title" >Confirmaci&oacute;n</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="row">
                                  <p>Seguro de que deseas quitar a esta persona de la selección?</p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                           <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                           <button id="btn-eliminar" type="button" class="btn btn-primary">Eliminar</button>
                       </div>
                      </div><!-- /.modal-content -->
                   </div><!-- /.modal-dialog -->
                   </div><!-- /.modal -->   
                   <div id="modal-confirmacion" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
                   <div class="modal-dialog">
                      <div class="modal-content">
                        <div class="modal-header">
                           <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                           <h4 class="modal-title" >Confirmaci&oacute;n</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="row">
                                  <p>Seguro de que deseas agregar el personal seleccionado al proyecto?</p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                           <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                           <button id="btn-confirmar" type="button" class="btn btn-primary">Aceptar</button>
                       </div>
                      </div><!-- /.modal-content -->
                   </div><!-- /.modal-dialog -->
                   </div><!-- /.modal -->                                                    
                   </div> 
                      <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button id="btn-enviar" class="btn btn-primary"  type="submit" onclick="return false;">Agregar</button>
                    <a class="btn btn-default" href="AgregarInvolucrado.aspx">Cancelar</a>
                </div>
            </div>
                 </form>
              </div>
        <script type="text/javascript">

            var tabla_cont = 0;

            $(function () {
                $('[data-toggle="tooltip"]').tooltip()
            })
            $("#dp1 li a").click(function () {

                $("#id_empresa").html($(this).text() + ' <span class="caret"></span>');

            });
            $("#dp2 li a").click(function () {

                $("#id_personal").html($(this).text() + ' <span class="caret"></span>');

            });
            $("#dp3 li a").click(function () {

                $("#id_cargo").html($(this).text() + ' <span class="caret"></span>');

            });

            function cargarcargo() {
               
                var empresa_seleccionado = $("#id_empresa").text().trim();
                $("#dp3").empty();

                if (empresa_seleccionado == "Cliente") {
                    $("#dp3").append('<li value="1"><a href="#">Director General</a></li>');
                    $("#dp3").append('<li value="1"><a href="#">Director Ejecutivo</a></li>');
                    $("#dp3").append('<li value="1"><a href="#">Gerente Departamental</a></li>');
                }
                    
                   


                if (empresa_seleccionado == "Compañia de Software") {
                    $("#dp3").append('<li value="1"><a href="#">Gerente</a></li>');
                    $("#dp3").append('<li value="2"><a href="#">Desarrollador</a></li>');
                    $("#dp3").append('<li value="3"><a href="#">Diseñador</a></li>');
                    $("#dp3").append('<li value="4"><a href="#">Lider de Proyecto</a></li>');
                    $("#dp3").append('<li value="5"><a href="#">Arquitecto de Solución</a></li>');
                    $("#dp3").append('<li value="6"><a href="#">Arquitecto de Base de Datos</a></li>');
                    
                }
            }

            function cargarpersonal() {
                var cargo_seleccionado = $("#id_cargo").text().trim();
                var empresa_seleccionado = $("#id_empresa").text().trim();
                $("#dp2").empty();

                if (empresa_seleccionado == "Cliente") {
                    if (cargo_seleccionado == "Director General") {
                        $("#dp2").append('<li value="1"><a href="#">Argenis Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Carlos Rodriguez</a></li>');
                        $("#dp2").append('<li value="3"><a href="#">Nelson Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Director Ejecutivo") {
                        $("#dp2").append('<li value="4"><a href="#">Hero Rodriguez</a></li>');
                        $("#dp2").append('<li value="5"><a href="#">Jesus Rodriguez</a></li>');
                        $("#dp2").append('<li value="6"><a href="#">Sofia Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Gerente Departamental") {
                        $("#dp2").append('<li value="7"><a href="#">Leonardo Rodriguez</a></li>');
                        $("#dp2").append('<li value="8"><a href="#">Fabian Rodriguez</a></li>');
                    }
                   
                }
            }
            

       </script>
        <script type="text/javascript">
            $(document).ready(function () {
                var table = $('#table-example').DataTable();
                var tr;
                $('#table-example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        $(this).parent().removeClass('selected');
                    }
                    else {
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                    }
                });

                $('#dp2').on('click', 'a', function () {

                    var empresa_seleccionado = $("#id_empresa").text().trim();
                    var personal_seleccionado = $(this).text().trim();
                    var cargo_seleccionado = $("#id_cargo").text().trim();
                    var split_personal = personal_seleccionado.split(' ');
                    var nombre_personal = split_personal[0];
                    var apellido_personal = split_personal[1];

                    var table = $('#table-example').DataTable();
                    tabla_cont = tabla_cont + 1;
                    $('#alertlocal').removeClass("alert alert-success alert-dismissible");
                    $('#alertlocal').text("");
                    table.row.add([
                        nombre_personal,
                        apellido_personal,
                        cargo_seleccionado,
                        empresa_seleccionado,
                        '<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete"></a>'
                    
                    ]).draw();
                });
                //para eliminar la fila
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                    tabla_cont = tabla_cont - 1;
                });
                $('#btn-confirmar').on('click', function () {
                    document.getElementById("agregarpersonal").submit();
                });
                //para confirmar
                $('#btn-enviar').on('click', function () {
                 
                    if (tabla_cont == 0) {
                        $('#alertlocal').addClass("alert alert-danger alert-dismissible");
                       
                        $('#alertlocal').append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>');
                        $('#alertlocal').text("No has seleccionado ningun personal");
                    } else {
                        $('#modal-confirmacion').modal("show");
                    }
                    
                });

            });

       </script>
</asp:Content>

