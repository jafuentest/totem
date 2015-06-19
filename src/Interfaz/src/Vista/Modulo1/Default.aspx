<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Modulo1.Default" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Inicio de Sesión
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">


        <!--ALERTAS-->
        <!--Alertas de modificacion y eliminacion de requerimientos en la lista de requerimientos en el 1er acordeon-->
        <div class="form-group">
            <div id="div_alertas" class="col-sm-12 col-md-12 col-lg-12">
                <div id="alert_requerimiento" runat="server">
                </div>
            </div>
        </div>
        <div id="div_adminIcons" runat="server">
            
            <div class='row jumbotron'>
                <div class='col-sm-6'>
                    <div>
                         <a href='../Modulo5/ListarRequerimientos.aspx'>
                            <div class='col-sm-offset-5'>
                                <img src='../../../img/Icons/modulo5.png' />
                           </div>
                            <p class='text-center'>Gestión de requerimientos</p>
                        </a>
                    </div>
                    <div>
                        <a href='../Modulo6/Listar.aspx'>
                            <br />
                            <br />
                            <br />
                            <div class='col-sm-offset-5'>
                                <img  src='../../../img/Icons/modulo6.png' />
                            </div>
                            <p class='text-center'>Gestión de casos de uso</p>
                         </a>
                   </div>
                    </div>
                     <div class='col-sm-4'>
                        <div>
                            <a href='../Modulo4/ListaProyectos.aspx'>
                            <div class='col-sm-offset-5'>
                                <img  src='../../../img/Icons/modulo4.png' />
                            </div>
                            <p class='text-center'>Gestión de proyectos</p>
                            </a>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div>
                            <a href='../Modulo7/ListarUsuarios.aspx'>
                            <div class='col-sm-offset-5'>
                                <img  src='../../../img/Icons/modulo7.png' />
                            </div>
                            <p class='text-center'>Gestión de roles y usuarios</p>
                        </a>
                        </div>
                      </div>
            </div>
            </div>
</asp:Content>