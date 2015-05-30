<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Personal Involucrado</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Involucrados</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

              <div class="col-sm-12 col-md-12 col-lg-12">
                 <div id="alertlocal" runat="server" >
                 </div>
              	  <form id="agregarpersonal" runat="server">
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione el tipo de empresa:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="dropdown" runat="server" id="divComboTipoEmpresa">
                                    <asp:DropDownList ID="comboTipoEmpresa"  class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="actualizarComboCargos" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>    
                            </div>
                            </br>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Listar Personal según el cargo:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="dropdown" runat="server" id="divComboCargo" >
                                    <asp:DropDownList ID="comboCargo"  class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged="actualizarComboPersonal" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>    
                            </div>
                            </br>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione Personal:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                               <div class="dropdown" runat="server" id="divComboPersonal">
                                    <asp:DropDownList ID="comboPersonal"  class="btn btn-default dropdown-toggle" runat="server" OnSelectedIndexChanged ="AgregarInvolucrados_Click" AutoPostBack="true">
                                    </asp:DropDownList>
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
                            <tbody id="tablebody" runat="server">
                                <asp:Literal runat="server" ID="laTabla"></asp:Literal>
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
                    <%--<asp:Button id="btn-enviar" class="btn btn-primary"  type="submit" runat="server" OnClick="btn_enviar_Click">Agregar</asp:Button>--%>
                    <a class="btn btn-default" href="ListarPersonalInvolucrado.aspx">Cancelar</a>
                </div>
            </div>
                  </form>
              </div>
        <script src="js/datos_estaticos.js"></script>
        <script type="text/javascript">
            var tabla_cont = 0;
            //selecciona el tipo de empresa al hacer click
            $("#dp1 li a").click(function () {

                $("#id_empresa").html($(this).text() + ' <span class="caret"></span>');

            });
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
                    //cargar personal
                    //cargarpersonal(empresa_seleccionado, cargo_seleccionado);
                    //document.getElementById("boton1").click();
                    $("#boton1").click();
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

