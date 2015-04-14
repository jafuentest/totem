<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarPersonalInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Listar Personal Involucrado</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
           
                       <div class="col-sm-12 col-md-12 col-lg-12">
                       <div id="alert" runat="server">
                       </div>
                       <div id="alertlocal" >
                       </div>
                       <div  id="table-responsive">
                           <table id="table-example" class=" table table-striped table-hover display">
                             <thead>
                               <tr>
                                 <th>Nombre</th>
                                 <th>Apellido</th>
                                 <th>Rol</th>
                                 <th>Compañia</th>
                                 <th>Acciones</th>
                               </tr>
                             </thead>
                            <tbody>
                            <tr>
                              <td>Argenis</td>
                              <td>Rodriguez</td>
                              <td>Director General</td>
                              <td>Cliente</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/ListarClientes.aspx") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>
                            </tr>
                            <tr>
                              <td>Scheryl</td>
                              <td>Palencia</td>
                              <td>Diseñador</td>
                              <td>Compañia de Software</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>   
                            </tr>
                                 <tr>
                              <td>Rodolfo</td>
                              <td>Graziano</td>
                              <td>Analista</td>
                              <td>Compañia de Software</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>   
                            </tr>
                                   <tr>
                              <td>Pedro</td>
                              <td>Garcia</td>
                              <td>Lider De Proyecto</td>
                              <td>Compañia de Software</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>   
                            </tr>
                                <tr>
                              <td>Manuel</td>
                              <td>Da silva</td>
                              <td>Director General</td>
                              <td>Cliente</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil"  href="<%= Page.ResolveUrl("~/GUI/Modulo2/ListarClientes.aspx") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>   
                            </tr>
                                <tr>
                              <td>Ydalia</td>
                              <td>Restrepo</td>
                              <td>Director Ejecutivo</td>
                              <td>Cliente</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil"  href="<%= Page.ResolveUrl("~/GUI/Modulo2/ListarClientes.aspx") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>   
                            </tr>
                                    <tr>
                              <td>juan</td>
                              <td>santos</td>
                              <td>Arquitecto de Solucion</td>
                              <td>Compañia de Software</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>
                            </tr>
                            
                            <tr>
                              <td>Alberto</td>
                              <td>Da Silva</td>
                              <td>Lider del proyecto</td>
                              <td>Compañia de Software</td>
                              <td>
                                  <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                  <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                              </td>
                            </tr>
                           </tbody>
                         </table>
                    </div>
                   </div> 
                   <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                     <div class="modal-content">
                    <div class="modal-header">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <h4 class="modal-title" >Eliminaci&oacute;n de Usuario</h4>
                      </div>
                      <div class="modal-body">
                       <div class="container-fluid">
                        <div class="row">
                         <p>Seguro que desea eliminar a este involucrado del proyecto:</p>
                        </div>
                       </div>
                      </div>
                       <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
                       </div>
                      </div><!-- /.modal-content -->
                     </div><!-- /.modal-dialog -->
                   </div><!-- /.modal -->
                    <div class="form-group" >     
                            <div class="col-sm-5 col-md-5 col-lg-5">
                          <button id="btn-aceptar" class="btn btn-primary" type="submit" onclick="redireccion();">Aceptar</button>
                     
                        </div>  
                                &nbsp;
                            
                    </div>
     <script type="text/javascript">
         function redireccion() {
             window.location = "/GUI/Modulo4/ListaProyectos.aspx";
             
         }
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

             $('#btn-eliminar').on('click', function () {
                 table.row(tr).remove().draw();//se elimina la fila de la tabla
                 $('#modal-delete').modal('hide');//se esconde el modal
                 $('#alertlocal').addClass("alert alert-success alert-dismissible");
                 $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha eliminado Exitosamente.</div>");

             });
         });

       </script>

</asp:Content>

