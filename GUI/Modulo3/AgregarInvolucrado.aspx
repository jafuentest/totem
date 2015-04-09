<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Agregar Personal Involucrado</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
              <div class="col-sm-10 col-md-10 col-lg-10 col">
              	 <form class="form-horizontal" action="" method="POST" role="form" runat="server">
                        <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3 col-sm-offset-4">
                                    <label>Seleccione el tipo de empresa:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_empresa" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp1" class="dropdown-menu" role="menu">
                                    <li value="1"><a href="#">Cliente</a></li>
                                    <li value="2"><a href="#">Compañia de Software</a></li>
                                  </ol>
                                </div>  
                                <a id="error1"></a>          
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3 col-sm-offset-4">
                                    <label>Seleccione Cargo:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_cargo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" >
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp3" class="dropdown-menu" role="menu" onclick="cargarpersonal();">
                                    <li value="1"><a href="#">Lider de Proyecto</a></li>
                                    <li value="2"><a href="#">Analista</a></li>
                                    <li value="3"><a href="#">Tecnico</a></li>
                                  </ol>
                                </div> 
                                <a id="error3"></a>           
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3 col-sm-offset-4">
                                    <label>Seleccione Personal:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_personal" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ol id="dp2" class="dropdown-menu" role="menu" onclick="insertarfila();">
                                    <li value="1"><a href="#">Argenis Rodriguez</a></li>
                                    <li value="2"><a href="#">Scheryl Palencia</a></li>
                                    <li value="3"><a href="#">Rosa Rodriguez</a></li>
                                    <li value="4"><a href="#">Akira Toriyama</a></li>
                                  </ol>
                                </div> 
                                <a id="error2"></a>           
                              </div>
                        </div>
                       <br />
                       <div class="col-sm-11 col-md-11 col-lg-11 col-sm-offset-1">
                       <div  id="table-responsive">
                           <table id="table-example" class=" table table-striped table-hover display" data-toggle="tooltip" data-placement="left" title="Click para eliminar">
                             <thead>
                               <tr>
                                 <th>Nombre</th>
                                 <th>Apellido</th>
                                 <th>Rol</th>
                                 <th>Compañia</th>
                                 <th>Eliminar</th>
                               </tr>
                             </thead>
                            <tbody>
                            <tr>
                              <td>Argenis</td>
                              <td>Rodriguez</td>
                              <td>Lider del proyecto</td>
                              <td>Cliente</td>
                              <td><a class="btn btn-danger " onclick="quitar();">Eliminar</a></td>  
                            </tr>
                            <tr>
                              <td>Argenis2</td>
                              <td>Rodriguez2</td>
                              <td>Lider del proyecto</td>
                              <td>Compañia de Software</td>
                              <td><a class="btn btn-danger ">Eliminar</a></td>     
                            </tr>
                            <tr>
                              <td>Argenis3</td>
                              <td>Rodriguez3</td>
                              <td>Lider del proyecto</td>
                              <td>Cliente</td>
                              <td><a class="btn btn-danger ">Eliminar</a></td>  
                            </tr>
                           </tbody>
                         </table>
                    </div>
                   </div> 
                    <div class="form-group" >     
                           <div class="col-sm-3 col-md-2 col-lg-2 col-sm-offset-4">
                              <button type="submit" class="btn btn-primary" onclick="return validar();">Agregar</button>
                            </div>
                                &nbsp;
                            <div class="col-sm-3 col-md-2 col-lg-2">
                              <button type="submit" class="btn btn-primary">Cancelar</button>
                           </div>
                    </div>
                 </form>
              </div>
        <script type="text/javascript">
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

            function insertarfila() {
                var empresa_seleccionado = $("#id_empresa").text().trim();
                var personal_seleccionado = $("#id_personal").text().trim();
                var cargo_seleccionado = $("#id_cargo").text().trim();

                var split_personal = personal_seleccionado.split(' ');
                var nombre_personal = split_personal[0];
                var apellido_personal = split_personal[1];

                table.row.add({
                    "Nombre": ombre_personal,
                    "Apellido": apellido_personal,
                    "Rol": cargo_seleccionado,
                    "Compañia": empresa_seleccionado,
                    "Eliminar": "Edinburgh",
                }).draw();
            }

            function validar() {
                var empresa_seleccionado = $("#id_empresa").text().trim();
                var personal_seleccionado = $("#id_personal").text().trim();
                var cargo_seleccionado = $("#id_cargo").text().trim();

                $("#error1").text("");
                $("#error2").text("");
                $("#error3").text("");
                if ((empresa_seleccionado == "Selecionar...") || (personal_seleccionado == "Selecionar...") || (cargo_seleccionado == "Selecionar...")) {
                    if (empresa_seleccionado == "Selecionar...")
                        $("#error1").text("No seleccionastes la empresa");
                    if (personal_seleccionado == "Selecionar...")
                        $("#error2").text("No seleccionastes el personal");
                    if (cargo_seleccionado == "Selecionar...")
                        $("#error3").text("No seleccionastes el cargo");
                    return false;
                } else {
                    return confirm('Seguro de que deseas asignar a este empleado');
                }
            }


            function cargarpersonal() {
                var cargo_seleccionado = $("#id_cargo").text().trim();
                var empresa_seleccionado = $("#id_empresa").text().trim();
                $("#dp2").remove();

                if (empresa_seleccionado == "Cliente") {
                    if (cargo_seleccionado == "Lider de Proyecto") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Argenis Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">Carlos Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="3"><a href="#">Nelson Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Analista") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Hero Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">Jesus Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="3"><a href="#">Sofia Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Tecnico") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Leonardo Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">Fabian Rodriguez</a></li>');
                    }
                }
                if (empresa_seleccionado == "Compañia de Software") {
                    if (cargo_seleccionado == "Lider de Proyecto") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Khaterine Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">James Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Analista") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Rosa Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">Susan Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Tecnico") {
                        $("#dp2 ol").append('<li value="1"><a href="#">Estefania Rodriguez</a></li>');
                        $("#dp2 ol").append('<li value="2"><a href="#">Laura Rodriguez</a></li>');
                    }
                }
            }
            
       </script>
        <script type="text/javascript">
            $(document).ready(function () {
                var table = $('#table-example').DataTable();

                $('#table-example tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        $(this).parent().removeClass('selected');
                    }
                    else {
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                    if (confirm('Seguro de que deseas deseleccionar a esta persona') == true) {
                        table.row($(this).parents('tr')).remove().draw();
                    } else {
                        $(this).parent().removeClass('selected');
                    }
                });

            });

       </script>
</asp:Content>

