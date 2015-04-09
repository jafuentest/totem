<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilProyecto.aspx.cs" Inherits="GUI_Modulo4_PerfilProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Perfil</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <form id="register_form" class="form-horizontal" action="#">
            <div class="form-group">
                <div id="div_precio" class="col-sm-12 col-md-12 col-lg-12">
                    <div class="jumbotron">
                        <h2><a href="#">Twitter</a></h2>
                        <p>Twitter (NYSE: TWTR) es un servicio de microblogging, con sede en San Francisco, California, con filiales en San Antonio (Texas) y Boston (Massachusetts) en Estados Unidos. Twitter, Inc. fue creado originalmente en California, pero está bajo la jurisdicción de Delaware desde 2007.8 Desde que Jack Dorsey lo creó en marzo de 2006, y lo lanzó en julio del mismo año, la red ha ganado popularidad mundialmente y se estima que tiene más de 500 millones de usuarios, generando 65 millones de tuits al día y maneja más de 800 000 peticiones de búsqueda diarias.1 Ha sido apodado como el "SMS de Internet".9</p>
                        <p>Cliente: <a href="#">Dick Costolo</a></p>
                        <p>Desarroladora: <a href="#">Los Andes Coding</a></p>
                    </div>
                </div>
            </div>

            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordion1" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="requerimientos">
                        <h3 class="panel-title">
                            <a href="#collapseRequerimientos" data-toggle="collapse" data-parent="#accordion">
                                Requerimientos
                            </a>
                        </h3>
                    </div>
                    <div id="collapseRequerimientos" class="panel-collpase collapse">
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam rhoncus ut velit sit amet ullamcorper. Fusce magna quam, viverra ut erat ut, laoreet maximus mauris. Proin gravida nibh sit amet mi egestas iaculis. Aliquam eu sagittis lacus, sit amet gravida sapien. Cras sed ante quis tellus molestie volutpat sed quis nulla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vitae eros arcu. Phasellus viverra nulla nibh. Donec quis volutpat leo, vel varius velit. Proin eget euismod nunc, at auctor lorem. Maecenas eu varius sapien, in cursus urna. Sed ultrices leo a risus cursus, interdum vehicula ex molestie. Donec vehicula massa orci, a finibus leo porttitor quis. Nullam molestie gravida malesuada. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordion2" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="casosDeUso">
                        <h3 class="panel-title">
                            <a href="#collapseCasosDeUso" data-toggle="collapse" data-parent="#accordion">
                                Casos de Uso
                            </a>
                        </h3>
                    </div>
                    <div id="collapseCasosDeUso" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam rhoncus ut velit sit amet ullamcorper. Fusce magna quam, viverra ut erat ut, laoreet maximus mauris. Proin gravida nibh sit amet mi egestas iaculis. Aliquam eu sagittis lacus, sit amet gravida sapien. Cras sed ante quis tellus molestie volutpat sed quis nulla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vitae eros arcu. Phasellus viverra nulla nibh. Donec quis volutpat leo, vel varius velit. Proin eget euismod nunc, at auctor lorem. Maecenas eu varius sapien, in cursus urna. Sed ultrices leo a risus cursus, interdum vehicula ex molestie. Donec vehicula massa orci, a finibus leo porttitor quis. Nullam molestie gravida malesuada. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.
		                    </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
			                    <button class="btn btn-primary" onclick="return checkform()">Ver Casos de Uso</button>
		                    </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordion3" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="minutas">
                        <h3 class="panel-title">
                            <a href="#collapseMinutas" data-toggle="collapse" data-parent="#accordion">
                                Minutas
                            </a>
                        </h3>
                    </div>
                    <div id="collapseMinutas" class="panel-collpase collapse">
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam rhoncus ut velit sit amet ullamcorper. Fusce magna quam, viverra ut erat ut, laoreet maximus mauris. Proin gravida nibh sit amet mi egestas iaculis. Aliquam eu sagittis lacus, sit amet gravida sapien. Cras sed ante quis tellus molestie volutpat sed quis nulla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vitae eros arcu. Phasellus viverra nulla nibh. Donec quis volutpat leo, vel varius velit. Proin eget euismod nunc, at auctor lorem. Maecenas eu varius sapien, in cursus urna. Sed ultrices leo a risus cursus, interdum vehicula ex molestie. Donec vehicula massa orci, a finibus leo porttitor quis. Nullam molestie gravida malesuada. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
		        <div class="col-sm-2 col-md-2 col-lg-2">
			        <button class="btn btn-warning" onclick="return checkform()"><a href="ModificarProyecto.aspx">Modificar</a></button>
		        </div>
                <div class="col-sm-2 col-md-2 col-lg-2">
			        <button class="btn btn-danger" onclick="return checkform()">Eliminar</button>
		        </div>
                <div class="col-sm-2 col-md-2 col-lg-2">
			        <button class="btn btn-primary" onclick="return checkform()">Generar ERS</button>
		        </div>
                <div class="col-sm-2 col-md-2 col-lg-2">
			        <button class="btn btn-primary" onclick="return checkform()">Generar Factura</button>
		        </div>
	        </div>

            <div class="form-group">
		        
	        </div>
        </form>
    </div>
</asp:Content>