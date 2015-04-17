<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Personal Involucrado</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Involucrados</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
              <div class="col-sm-12 col-md-12 col-lg-12">
                 <div id="alertlocal" >
                 </div>
              	 <form id="agregarpersonal" class="form-horizontal" action="ListarPersonalInvolucrado.aspx?success=1" method="POST" role="form" runat="server">
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
                                  <ol id="dp3" class="dropdown-menu" role="menu">                                                                                                 
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
                           <button id="btn-eliminar" type="button" class="btn btn-primary">Eliminar</button>
                           <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
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
                           <button id="btn-confirmar" type="button" class="btn btn-primary">Aceptar</button>
                           <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar
                           </button>
                        </div>
                      </div><!-- /.modal-content -->
                   </div><!-- /.modal-dialog -->
                   </div><!-- /.modal -->                                                    
                   </div> 
                      <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button id="btn-enviar" class="btn btn-primary"  type="submit" onclick="return false;">Agregar</button>
                    <a class="btn btn-default" href="ListarPersonalInvolucrado.aspx">Cancelar</a>
                </div>
            </div>
                 </form>
              </div>
        <script type="text/javascript">

            var tabla_cont = 0;
            //selecciona el tipo de empresa al hacer click
            $("#dp1 li a").click(function () {

                $("#id_empresa").html($(this).text() + ' <span class="caret"></span>');

            });
            //carga los cargos de forma dinamica en el combobox, esta funcion debe ser modificada a la hora de traerse los cargos de la base de datos
            function cargarcargo() {
               
                var empresa_seleccionado = $("#id_empresa").text().trim();
                 $("#dp3").empty();

                if (empresa_seleccionado == "Cliente") {
                    $("#dp3").append('<li value="1"><a href="#">Director General</a></li>');
                    $("#dp3").append('<li value="2"><a href="#">Director Ejecutivo</a></li>');
                    $("#dp3").append('<li value="3"><a href="#">Gerente Departamental</a></li>');
                }
                                   
                if (empresa_seleccionado == "Compañia de Software") {
                    $("#dp3").append('<li value="4"><a href="#">Gerente</a></li>');
                    $("#dp3").append('<li value="5"><a href="#">Desarrollador</a></li>');
                    $("#dp3").append('<li value="6"><a href="#">Diseñador</a></li>');
                    $("#dp3").append('<li value="7"><a href="#">Lider de Proyecto</a></li>');
                    $("#dp3").append('<li value="8"><a href="#">Arquitecto de Solución</a></li>');
                    $("#dp3").append('<li value="9"><a href="#">Arquitecto de Base de Datos</a></li>');
                    
                }
            }           
       </script>
        <script type="text/javascript">
            //captura los eventos al hacer click con el raton
            $(document).ready(function () {
                //se selecciona la fila al hacer click sobre el boton.
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
                    //este contador sirve para saber cuando a tabla esta vacia o llena, se le suma 1 cada vez que se selecciona un personal
                    //y se resta 1 cada vez que se elimina a un personal de la selección
                    tabla_cont = tabla_cont + 1;
                    //quita la alerta
                    $('#alertlocal').removeClass("alert alert-success alert-dismissible");
                    $('#alertlocal').text("");
                    //inserta al personal seleccionado en la tabla
                    table.row.add([
                        nombre_personal,
                        apellido_personal,
                        cargo_seleccionado,
                        empresa_seleccionado,
                        '<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete"></a>'
                    
                    ]).draw();
                });
                //evento que se produce al seleccionar el cargo.
                $('#dp3').on('click', 'a', function () {
                    var cargo_seleccionado = $(this).text().trim();
                    $("#id_cargo").html(cargo_seleccionado + ' <span class="caret"></span>');
                    var empresa_seleccionado = $("#id_empresa").text().trim();
                    $("#dp2").empty();
                    //carga al personal al seleccionar un cargo, esta parte debe ser cambiada a la hora de extraer al personal de la base de datos
                    //son datos estaticos
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
                    if (empresa_seleccionado == "Compañia de Software") {
                        if (cargo_seleccionado == "Gerente") {
                            $("#dp2").append('<li value="16"><a href="#">Khaterine Rodriguez</a></li>');
                            $("#dp2").append('<li value="17"><a href="#">James Rodriguez</a></li>');
                        }
                        if (cargo_seleccionado == "Desarrollador") {
                            $("#dp2").append('<li value="18"><a href="#">Rosa Rodriguez</a></li>');
                            $("#dp2").append('<li value="19"><a href="#">Susan Rodriguez</a></li>');
                        }
                        if (cargo_seleccionado == "Diseñador") {
                            $("#dp2").append('<li value="20"><a href="#">Estefania Rodriguez</a></li>');
                            $("#dp2").append('<li value="21"><a href="#">Laura Rodriguez</a></li>');
                        }
                        if (cargo_seleccionado == "Lider de Proyecto") {
                            $("#dp2").append('<li value="22"><a href="#">José Boggio</a></li>');
                            $("#dp2").append('<li value="23"><a href="#">Julio Pino</a></li>');
                        }
                        if (cargo_seleccionado == "Arquitecto de Solución") {
                            $("#dp2").append('<li value="24"><a href="#">Maria Padrón</a></li>');
                            $("#dp2").append('<li value="25"><a href="#">Adalberto Gerdel</a></li>');
                        }
                        if (cargo_seleccionado == "Arquitecto de Base de Datos") {
                            $("#dp2").append('<li value="26"><a href="#">Susan Calvin</a></li>');
                        }
                    }

                });
                //para eliminar la fila
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete').modal('hide');//se esconde el modal
                    //como se elimina una fila a tabla_cont se le resta 1, tabla_cnt nunca es negativo
                    tabla_cont = tabla_cont - 1;
                });
                //evento para confirmar y enviar el formulario, al precionar el boton del modal
                $('#btn-confirmar').on('click', function () {
                    document.getElementById("agregarpersonal").submit();
                });
                //Muestra una alerta en caso de que el usuario haga click en cargo sin antes haber seleccionado el tipo de empresa
                $('#id_cargo').on('click', function () {
                    if ($('#id_empresa').text().trim() == "Selecionar...") {
                        $('#alertlocal').addClass("alert alert-danger alert-dismissible");
                        $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado el tipo de empresa</div>");
                    }
                });
                //
                $('#id_personal').on('click', function () {
                    if ($('#id_empresa').text().trim() == "Selecionar...") {
                        $('#alertlocal').addClass("alert alert-danger alert-dismissible");
                        $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado el tipo de empresa</div>");
                    }
                    if ($('#id_cargo').text().trim() == "Selecionar...") {
                        $('#alertlocal').addClass("alert alert-danger alert-dismissible");
                        $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado el cargo</div>");
                    }

                });
                //evento producido al presionar el boton del formulario para enviar
                $('#btn-enviar').on('click', function () {
                 //tabla_cont es para saber si la tabla esta llena o vacia
                    if (tabla_cont == 0) {
                        $('#alertlocal').addClass("alert alert-danger alert-dismissible");
                        $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado ningun personal</div>");
                    } else {
                        $('#modal-confirmacion').modal("show");
                    }
                    
                });

            });

       </script>
</asp:Content>

