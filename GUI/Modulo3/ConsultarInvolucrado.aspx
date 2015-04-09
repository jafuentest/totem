<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarInvolucrado.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Consultar Personal Involucrado</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
           
                       <div class="col-sm-11 col-md-11 col-lg-11 col-sm-offset-1">
                       <div  id="table-responsive">
                           <table id="table-example" class=" table table-striped table-hover display">
                             <thead>
                               <tr>
                                 <th>Nombre</th>
                                 <th>Apellido</th>
                                 <th>Rol</th>
                                 <th>Compañia</th>
                               <%-- <th>Consultar</th>--%>
                               </tr>
                             </thead>
                            <tbody>
                            <tr>
                              <td>Argenis</td>
                              <td>Rodriguez</td>
                              <td>Lider del proyecto</td>
                              <td>Cliente</td>
                         <%--    <td><a class="btn btn-primary ">Consultar</a></td>  --%>
                            </tr>
                            <tr>
                              <td>Scheryl</td>
                              <td>Palencia</td>
                              <td>Analista</td>
                              <td>Compañia de Software</td>
                             <%-- <td><a class="btn btn-primary ">Consultar</a></td>  --%>   
                            </tr>
                            <tr>
                              <td>Alberto</td>
                              <td>Da Silva</td>
                              <td>Lider del proyecto</td>
                              <td>Compañia de Software</td>
                             <%-- <td><a class="btn btn-primary ">Consultar</a></td>  --%>
                            </tr>
                           </tbody>
                         </table>
                    </div>
                   </div> 
                    <div class="form-group" >     
                           <div class="col-sm-3 col-md-2 col-lg-2 col-sm-offset-5">
                              <button type="submit" class="btn btn-primary" onclick="return validar();">Aceptar</button>
                            </div>
                                &nbsp;
                            
                    </div>
     <script type="text/javascript">
         $(document).ready(function () {
             var table = $('#table-example').DataTable();
         });

       </script>

</asp:Content>

