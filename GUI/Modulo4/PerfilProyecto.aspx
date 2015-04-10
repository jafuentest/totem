<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilProyecto.aspx.cs" Inherits="GUI_Modulo4_PerfilProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="set-cookie" content="selectedProject=Twitter;">
    <style>
        .sameLine {
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Perfil</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <form id="register_form" class="form-horizontal" action="#">
            <div class="form-group">
                <div id="div_precio" class="col-sm-12 col-md-12 col-lg-12">
                    <div class="jumbotron">
                        <h2 class="sameLine"><a href="#">Twitter</a></h2> <h5 class="sameLine">COD: TWI</h5>
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
                            <div class="table-responsive">
	    		                <table id="table-example" class="table table-striped table-hover">
			                    <thead>
				                    <tr>
					                    <th>ID</th>
					                    <th style="width: 530px">Requerimiento</th>
					                    <th>Tipo</th>
					                    <th style="width: 50px">Prioridad</th>
					                    <th>Acciones</th>
				                    </tr>
			                    </thead>
			                    <tbody>
				                    <tr>
					                    <td>TOT_RF_5_1</td>
					                    <td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=1") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=1") %>"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>TOT_RF_5_2</td>
					                    <td>El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=2") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=2") %>"></a>
                                        </td>
				                    </tr><tr>
                                        <td>TOT_RF_5_3</td>
					                    <td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=3") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=3") %>"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>TOT_RF_5_4</td>
					                    <td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=4") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=4") %>"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>TOT_RF_5_5</td>
					                    <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=5") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=5") %>"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>TOT_RF_5_6</td>
					                    <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					                    <td>Funcional</td>
					                    <td>Alta</td>
                                        <td>
                                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=6") %>"></a>
                                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=6") %>"></a>
                                        </td>
                                    </tr>
			                    </tbody>
		                    </table>
                        </div>
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
                                <div class="table-responsive">
		                            <table id="table-example" class="table table-striped table-hover">
			                            <thead>
				                            <tr>
					                            <th>ID</th>
					                            <th>Nombre</th>
					                            <th>Actor Primario</th>
					                            <th>Requerimiento Asociado</th>
					                            <th>Acciones</th>
				                            </tr>
			                            </thead>
			                            <tbody>
				                            <tr>
					                            <td>Lorem</td>
					                            <td>ipsum</td>
					                            <td>dolor</td>
					                            <td>sit</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=1") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=1") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=1") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>amet</td>
                                                <td>consectetur</td>
                                                <td>adipiscing</td>
                                                <td>elit</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=2") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=2") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=2") %>"></a>
                                                </td>
				                            </tr><tr>
                                                <td>Integer</td>
                                                <td>nec</td>
                                                <td>odio</td>
                                                <td>Praesent</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=3") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=3") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=3") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>libero</td>
                                                <td>Sed</td>
                                                <td>cursus</td>
                                                <td>ante</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=4") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=4") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=4") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>dapibus</td>
                                                <td>diam</td>
                                                <td>Sed</td>
                                                <td>nisi</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=5") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=5") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=5") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Nulla</td>
                                                <td>quis</td>
                                                <td>sem</td>
                                                <td>at</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=6") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=6") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=6") %>"></a>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>nibh</td>
                                                <td>elementum</td>
                                                <td>imperdiet</td>
                                                <td>Duis</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=7") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=7") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=7") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>sagittis</td>
                                                <td>ipsum</td>
                                                <td>Praesent</td>
                                                <td>mauris</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=8") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=8") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=8") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fusce</td>
                                                <td>nec</td>
                                                <td>tellus</td>
                                                <td>sed</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=9") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=9") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=9") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>augue</td>
                                                <td>semper</td>
                                                <td>porta</td>
                                                <td>Mauris</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=10") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=10") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=10") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>massa</td>
                                                <td>Vestibulum</td>
                                                <td>lacinia</td>
                                                <td>arcu</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=11") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=11") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=11") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>eget</td>
                                                <td>nulla</td>
                                                <td>Class</td>
                                                <td>aptent</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=12") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=12") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=12") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>taciti</td>
                                                <td>sociosqu</td>
                                                <td>ad</td>
                                                <td>litora</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=13") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=13") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=13") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>torquent</td>
                                                <td>per</td>
                                                <td>conubia</td>
                                                <td>nostra</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=14") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=14") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=14") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>per</td>
                                                <td>inceptos</td>
                                                <td>himenaeos</td>
                                                <td>Curabitur</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=15") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=15") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=15") %>"></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>sodales</td>
                                                <td>ligula</td>
                                                <td>in</td>
                                                <td>libero</td>
                                                <td>
                                                    <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=16") %>"></a>
                                                    <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=16") %>"></a>
                                                    <a class="btn btn-danger glyphicon glyphicon-remove-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=16") %>"></a>
                                                </td>
                                            </tr>
			                            </tbody>
		                            </table>
	                            </div>
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
                            <div class="table-responsive">
		                        <table id="table-example" class="table table-striped table-hover">
			                        <thead>
				                        <tr>
					                        <th>ID</th>
					                        <th>Proyecto</th>
					                        <th>Fecha</th>
					                        <th>Motivo</th>
                                            <th>Estado Proyecto</th>
					                        <th>Acciones</th>
				                        </tr>
			                        </thead>
			                        <tbody>
				                        <tr>
					                        <td>Min_01</td>
					                        <td>Facebook</td>
					                        <td>10-05-15</td>
					                        <td>Primer Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_02</td>
                                            <td>sjkdnfsnd</td>
                                            <td>sdnsnd</td>
                                            <td>akfsjdf</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_03</td>
                                            <td>sjkdn</td>
                                            <td>sdnjjdfsnd</td>
                                            <td>akfznx</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
                                               <tr>
                                            <td>Min_04</td>
                                            <td>sadddn</td>
                                            <td>aaaa</td>
                                            <td>mmmd</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_05</td>
                                            <td>shhhhn</td>
                                            <td>124233gdf</td>
                                            <td>jsdhhhdd</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_06</td>
                                            <td>sjkdn</td>
                                            <td>ssnd</td>
                                            <td>aznx</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinuta.aspx?id=1") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>"></a>
                                            </td>
                                        </tr>
			                        </tbody>
		                        </table>
	                        </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="btn-group"> 
		            <div class="col-sm-2 col-md-2 col-lg-2">
			            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo4/ModificarProyecto.aspx?id=1") %>">Modificar</a>
		            </div>
                    <div class="col-sm-2 col-md-2 col-lg-2">
			            <button class="btn btn-danger" onclick="return checkform()">Eliminar</button>
		            </div>
                <div class="col-md-offset-8">
                        <div class="col-sm-2 col-md-2 col-lg-2">
			                <button class="btn btn-default" onclick="return checkform()">Generar ERS</button>
		                </div>
                        <div class="col-sm-2 col-md-2 col-lg-2 col-md-offset-3">
			                <button class="btn btn-default" onclick="return checkform()">Generar Factura</button>
		                </div>
                    </div>
                </div>
	        </div>

            <div class="form-group">
		        
	        </div>
        </form>
    </div>

    <script type="text/javascript">
    jQuery(function ($) {
        $('#table-example').DataTable();
    });

    /*function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1);
            if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
        }
        return "";
    }

    function checkCookie() {
        var projectName = getCookie("selectedProject");
        //alert("Proyecto Seleccionado " + projectName);
    }*/
	</script>

</asp:Content>