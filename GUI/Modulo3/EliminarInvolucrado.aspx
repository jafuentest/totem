﻿<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="EliminarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Eliminar Personal Involucrado</asp:Content>
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
                                  <ol id="dp2" class="dropdown-menu" role="menu">
                                    <li value="1"><a href="#">Argenis Rodriguez</a></li>
                                    <li value="2"><a href="#">Scheryl Palencia</a></li>
                                    <li value="3"><a href="#">Rosa Rodriguez</a></li>
                                    <li value="4"><a href="#">Akira Toriyama</a></li>
                                  </ol>
                                </div> 
                                  
                              </div>
                        </div>
                       <br />
                       <div class="col-sm-11 col-md-11 col-lg-11 col-sm-offset-1">
                       <div  id="table-responsive">
                           <table id="table-example" class=" table table-striped table-hover display">
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
                           </tbody>
                         </table>
                    </div>
                   </div> 
                    <div class="form-group" >     
                           <div class="col-sm-3 col-md-2 col-lg-2 col-sm-offset-4">
                              <button type="submit" class="btn btn-primary" onclick="return validar();">Eliminar</button>
                            </div>
                                &nbsp;
                            <div class="col-sm-3 col-md-2 col-lg-2">
                              <button type="submit" class="btn btn-primary">Cancelar</button>
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


            function validar() {
                if (tabla_cont == 0) {
                    alert("No has seleccionado ningun personal");
                    return false;
                } else {
                    return confirm('Seguro de que deseas agregar esta selección de persoal al proyecto?')
                }
            }

            function cargarpersonal() {
                var cargo_seleccionado = $("#id_cargo").text().trim();
                var empresa_seleccionado = $("#id_empresa").text().trim();
                $("#dp2").empty();

                if (empresa_seleccionado == "Cliente") {
                    if (cargo_seleccionado == "Lider de Proyecto") {
                        $("#dp2").append('<li value="1"><a href="#">Argenis Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Carlos Rodriguez</a></li>');
                        $("#dp2").append('<li value="3"><a href="#">Nelson Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Analista") {
                        $("#dp2").append('<li value="1"><a href="#">Hero Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Jesus Rodriguez</a></li>');
                        $("#dp2").append('<li value="3"><a href="#">Sofia Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Tecnico") {
                        $("#dp2").append('<li value="1"><a href="#">Leonardo Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Fabian Rodriguez</a></li>');
                    }
                }
                if (empresa_seleccionado == "Compañia de Software") {
                    if (cargo_seleccionado == "Lider de Proyecto") {
                        $("#dp2").append('<li value="1"><a href="#">Khaterine Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">James Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Analista") {
                        $("#dp2").append('<li value="1"><a href="#">Rosa Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Susan Rodriguez</a></li>');
                    }
                    if (cargo_seleccionado == "Tecnico") {
                        $("#dp2").append('<li value="1"><a href="#">Estefania Rodriguez</a></li>');
                        $("#dp2").append('<li value="2"><a href="#">Laura Rodriguez</a></li>');
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
                    if (confirm('Seguro de que deseas quitar a esta persona de la selección?') == true) {
                        table.row($(this).parents('tr')).remove().draw();
                        tabla_cont = tabla_cont - 1;
                    } else {
                        $(this).parent().removeClass('selected');
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
                    table.row.add([
                        nombre_personal,
                        apellido_personal,
                        cargo_seleccionado,
                        empresa_seleccionado,
                        '<a class="btn btn-danger glyphicon glyphicon-remove-sign"></a>'

                    ]).draw();
                });

            });

       </script>
</asp:Content>
