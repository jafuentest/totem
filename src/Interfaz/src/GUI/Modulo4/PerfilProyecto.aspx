<%@ Page Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilProyecto.aspx.cs" Inherits="GUI_Modulo4_PerfilProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
	<link href="bootstrap-toggle-master/css/bootstrap-toggle.css" rel="stylesheet">
    <style>
        .bootstrapBlue {
            color: #337ab7;
        }
        .sameLine {
            display: inline;
        }
        .desc {
            font-style: italic;
        }
        .link{
            font-size: 20px;
            font-style: normal;
        }
        .link:hover{
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Perfil</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">

        <!--ALERTAS-->
        <!--Alertas de modificacion y eliminacion de requerimientos en la lista de requerimientos en el 1er acordeon-->
        <div class="form-group">
            <div id="div_alertas" class="col-sm-12 col-md-12 col-lg-12">
                <div id="alerts" runat="server"></div>
            </div>
        </div>

        <form runat="server" class="form-horizontal" method="POST">
            <!--Jumbotron con informacion general sobre el proyecto-->
            <div class="form-group">
                <div runat="server" id="div_proyecto" class="col-sm-12 col-md-12 col-lg-12">
                
                </div>
            </div>
        
            <!--1ER ACORDEON: REQUERIMIENTOS-->
            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordionRequerimientos" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="requerimientos">
                        <h3 class="panel-title">
                            <a class="link" href="#collapseRequerimientos" data-toggle="collapse" data-parent="#accordionRequerimientos">
                                Requerimientos
                            </a>
                        </h3>
                    </div>
                    <div id="collapseRequerimientos" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="table-responsive">
	    		                <table id="tabla-requerimientos" class="table table-striped table-hover">
			                        <thead>
				                        <tr>
					                        <th>ID</th>
					                        <th>Requerimiento</th>
					                        <th>Tipo</th>
					                        <th>Prioridad</th>
					                        <th>Acciones</th>
				                        </tr>
			                        </thead>
			                        <tbody>
				                        <tr>
					                        <td class="id">TOT_RF_1</td>
					                        <td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>TOT_RF_2</td>
					                        <td>El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
				                        </tr><tr>
                                            <td>TOT_RF_3</td>
					                        <td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>TOT_RF_4</td>
					                        <td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
                                        </tr>
                                        <tr>
                                        <td>TOT_RF_5</td>
					                        <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>TOT_RF_6</td>
					                        <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					                        <td>Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                            </td>
                                        </tr><tr>
                                            <td>TOT_RNF_1</td>
					                        <td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					                        <td>No Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>TOT_RNF_2</td>
					                        <td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					                        <td>No Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                                </td>
                                        </tr>
                                        <tr>
                                        <td>TOT_RNF_3</td>
					                        <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					                        <td>No Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>TOT_RNF_4</td>
					                        <td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					                        <td>No Funcional</td>
					                        <td>Alta</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update-requerimiento" href="#"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-requerimiento" href="#"></a>
                                            </td>
                                        </tr>
			                        </tbody>
		                        </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--2DO ACORDEON: CASOS DE USO-->
            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordionCasosDeUso" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="casosDeUso">
                        <h3 class="panel-title">
                            <a class="link" href="#collapseCasosDeUso" data-toggle="collapse" data-parent="#accordionCasosDeUso">
                                Casos de Uso
                            </a>
                        </h3>
                    </div>
                    <div id="collapseCasosDeUso" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="table-responsive">
			                        <table id="table-cu" class="table table-striped table-hover">
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
						                        <td>TOT_CU_6_1_1</td>
						                        <td>Crear caso de uso</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_1</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=1") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_5_2</td>
						                        <td>Consultar caso de uso clasificado por actor</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_5</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=2") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_6_3</td>
						                        <td>Consultar caso de uso Clasificado por ID</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_6</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=3") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_7_4</td>
						                        <td>Consultar Listado de actores</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_7</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=4") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_2_5</td>
						                        <td>Actualizar datos Caso de Uso</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_2</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=5") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_3_6</td>
						                        <td>Eliminar Caso de uso</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_3</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=6") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_8_7</td>
						                        <td>Crear actor</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_8</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=7") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_9_8</td>
						                        <td>Actualizar datos del actor</td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_9</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=8") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
						                        </td>
					                        </tr>
					                        <tr>
						                        <td>TOT_CU_6_10_9</td>
						                        <td>Eliminar Actor </td>
						                        <td>Usuario, Administrador</td>
						                        <td>TOT_RF_6_1</td>
						                        <td>
							                        <a class="btn btn-primary glyphicon glyphicon-info-sign" data-toggle="modal" data-target="#modal-info-cu" href="#"></a>
							                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=9") %>"></a>
							                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-cu" href="#"></a>
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
            <!--3ER ACORDEON: MINUTAS-->
            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordionMinutas" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="minutas">
                        <h3 class="panel-title">
                            <a class="link" href="#collapseMinutas" data-toggle="collapse" data-parent="#accordionMinutas">Minutas
                            </a>
                        </h3>
                    </div>
                    <div id="collapseMinutas" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="table-minutas" class="table table-striped table-hover">
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
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_02</td>
                                            <td>Totem</td>
                                            <td>10-06-15</td>
                                            <td>Segundo Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_03</td>
                                            <td>Word OnLine</td>
                                            <td>10-07-15</td>
                                            <td>Segundo Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_04</td>
                                            <td>Totem</td>
                                            <td>15-08-15</td>
                                            <td>Tercer Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_05</td>
                                            <td>Google</td>
                                            <td>10-09-15</td>
                                            <td>Último Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Min_06</td>
                                            <td>Comapañia CEL</td>
                                            <td>19-07-15</td>
                                            <td>Primer Encuentro</td>
                                            <td>Activo</td>
                                            <td>
                                                <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                                                <a class="btn btn-success glyphicon glyphicon-print" href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--4TO ACORDEON: INVOLUCRADOS-->
            <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordionInvolucrados" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="involucrados">
                        <h3 class="panel-title">
                            <a class="link" href="#collapseInvolucrados" data-toggle="collapse" data-parent="#accordionInvolucrados">
                                Involucrados
                            </a>
                        </h3>
                    </div>
                    <div id="collapseInvolucrados" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="table-responsive">
		                        <table id="table-users" class="table table-striped table-hover">
			                        <thead>
				                        <tr>
					                        <th>Usuario</th>
					                        <th>Nombre</th>
					                        <th>Apellido</th>
					                        <th>Cargo</th>
					                        <th>Acciones</th>
				                        </tr>
			                        </thead>
			                        <tbody>
				                        <tr>
					                        <td class="username">totkin</td>
					                        <td>Pedro</td>
					                        <td>Perez</td>
					                        <td>Gerente de Proyecto</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">amet</td>
                                            <td>Fulana</td>
                                            <td>Rodriguez</td>
                                            <td>Dise&ntilde;ador</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>

                                            </td>
				                        </tr><tr>
                                            <td class="username">Integer</td>
                                            <td>Nestor</td>
                                            <td>Osorio</td>
                                            <td>Administrador Base de Datos</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">libero</td>
                                            <td>Seth</td>
                                            <td>Cursus</td>
                                            <td>Desarrollador</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">dapibus</td>
                                            <td>Liam</td>
                                            <td>Nisi</td>
                                            <td>Desarrollador</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">Nulla</td>
                                            <td>Maria</td>
                                            <td>Aguila</td>
                                            <td>Gerente de Proyectos</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">nibh</td>
                                            <td>Elena</td>
                                            <td>Stone</td>
                                            <td>Desarrollador</td>
                                            <td>
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">sagittis</td>
                                            <td>Pietro</td>
                                            <td>Santini</td>
                                            <td>Desarrollador</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/ DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">Fusce</td>
                                            <td>Armando</td>
                                            <td>Reveron</td>
                                            <td>Dise&ntilde;ador</td>
                                            <td>
                          
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">augue</td>
                                            <td>Juan</td>
                                            <td>Porta</td>
                                            <td>Gerente de Proyecto</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">lacinia</td>
                                            <td>Marcos</td>
                                            <td>Macia</td>
                                            <td>Administrador Base de Datos</td>
                                            <td>
                        
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">eget</td>
                                            <td>Ana</td>
                                            <td>Clase</td>
                                            <td>Desarrollador</td>
                                            <td>
                         
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="username">aaciti</td>
                                            <td>Luis</td>
                                            <td>Perez</td>
                                            <td>Desarrollador</td>
                                            <td>
      
                                                <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                                                <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete-involucrado" href="#"></a>
                                            </td>
                                        </tr>
			                        </tbody>
		                        </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br>

        <!--BOTONES AL FINAL DE LA PAGINA DEL PERFIL DEL PROYECTO: MODIFICAR, ELIMINAR, GENERAR ERS, GENERAR FACTURA-->
        <div class="form-group">
            <div class="col-sm-2 col-md-2 col-lg-2">
                 <form method="POST" runat="server">
			        <button class="btn btn-default" runat="server" onserverclick="Ers">Generar ERS</button>
                </form>
		    </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
                <form method="get" action="docs/Factura.pdf">
			        <button class="btn btn-default">Generar Factura</button>
                </form>
		    </div>
            <div class="col-md-offset-10">
                <div class="col-sm-1 col-md-1 col-lg-1">
			        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo4/ModificarProyecto.aspx?id=1") %>">Modificar</a>
		        </div>
                <div class="col-sm-2 col-md-2 col-lg-2">
                    <form method="get" action="docs/Factura.pdf">
			            <button class="btn btn-default">Generar Factura</button>
                    </form>
		        </div>
                <div class="col-md-offset-10">
                    <div class="col-sm-1 col-md-1 col-lg-1">
                        <asp:Literal runat="server" id="modifyButton"></asp:Literal>
		            </div>
                </div>
	        </div>
        </form>


        <!--Modal de eliminacion de requerimiento en 1er acordeon-->
        <div id="modal-delete-requerimiento" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" >Eliminaci&oacute;n de Requerimiento</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <p>Seguro que desea eliminar el requerimiento:</p>
                                <p id="req"></p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <a id="btn-eliminar-requerimiento" type="button" class="btn btn-primary" onclick="EliminarRequerimiento()" href="PerfilProyecto.aspx?success=2">Eliminar</a>
                    </div>
                </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
        </div>
        <!--Modal de modificacion de requerimiento en 1er acordeon-->
        <div id="modal-update-requerimiento" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <form id="modificar_requerimientos" class="form-horizontal" method="post" action="PerfilProyecto.aspx?success=1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Modificaci&oacute;n de Requerimiento</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="form-group">
                                    <div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
                                        <input type="text" name="id" id="id" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_5_2" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-10 col-md-10 col-lg-10">
                                        <p><b>Tipo de Requerimiento:</b></p>
                                        <label class="radio-inline noSwitch">
                                            <input type="radio" name="radioTipo" checked="checked"/> Funcional</label>
                                        <label class="radio-inline noSwitch">
                                            <input type="radio" name="radioTipo"/> No Funcional</label>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="col-sm-10 col-md-10 col-lg-10">
                                        <div class="input-group">
                                            <span class="input-group-addon">El sistema deberá </span>
                                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify; resize: vertical;" name="requerimiento"></textarea>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="col-sm-10 col-md-10 col-lg-10">
                                        <p><b>Prioridad:</b></p>
                                        <label class="radio-inline">
                                            <input type="radio" name="radioPrioridad"/> Baja</label>
                                        <label class="radio-inline">
                                            <input type="radio" name="radioPrioridad" checked="checked"/> Media</label>
                                        <label class="radio-inline">
                                            <input type="radio" name="radioPrioridad"/> Alta</label>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="col-sm-10 col-md-10 col-lg-10">
                                        <p><b>Status:</b></p>
                                        <label class="radio-inline">
                                            <input type="radio" name="radioStatus" checked="checked"/> No Finalizado</label>
                                        <label class="radio-inline">
                                            <input type="radio" name="radioStatus"/> Finalizado</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button id="btn-modificarReq" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </form>
        </div>
        <!--Modal de eliminacion de un involucrado en 4to acordeon-->
        <div id="modal-delete-involucrado" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" >Eliminaci&oacute;n de Usuario</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <p>Seguro que desea eliminar el usuario:</p>
                                <p id="user-name"></p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
                    </div>
                </div>
            </div>
        </div>
        <!--Modal de eliminacion del proyecto-->
        <div id="modal-delete-project" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" >Eliminaci&oacute;n de Proyecto</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                    <div class="row">
                        <p>¿Seguro que desea eliminar el proyecto? Una vez confirmado no hay vuelta atras...</p>
                        <p id="project-name"></p>
                    </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <a id="btn-eliminar-proyecto" type="button" class="btn btn-primary" onclick="EliminarRequerimiento()" href="../Modulo1/Default.aspx?success=1">Eliminar</a>
                </div>
                </div>
            </div>
        </div>

        <!--Modal de eliminacion de Casos de Uso en 2do acordeon-->
        <div id="modal-delete-cu" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Eliminación de Caso de Uso</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid">
							<div class="row">
								<p>Seguro que desea eliminar el caso de uso:</p>
								<p id="caso_de_uso"></p>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
						<a id="btn-eliminar-cu" type="button" class="btn btn-primary" onclick="EliminarCasoDeUso()" href="PerfilProyecto.aspx?success=4">Eliminar</a>
					</div>
				</div>
			</div>
		</div>
        <!--Modal de informacion de Caso de Uso en 2do acordeon-->
		<div id="modal-info-cu" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title">Información detallada del Caso de Uso</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid" id="info">
							<div class="row">
								<h3>Precondiciones</h3>
									<ul>
										<li>Usuario registrado</li>
										<li>Usuario logeado</li>
										<li>Proyecto creado</li>
									</ul>
								<h3>Condición Final de Éxito</h3>
								<p>
									Caso de uso creado
								</p>
								<h3>Condición Final de Fallo</h3>
								<p>
									El caso de uso no pudo ser creado
								</p>
								<h3>Disparador</h3>
								<p>
									Seleccionar opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú
								</p>
								<h3>Escenario Principal de Éxito</h3>
									<ol>
										<li>El usuario o admin selecciona la opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú.</li>
										<li>El sistema despliega la pantalla de obtener los datos del caso de uso.</li>
										<li>El usuario o admin ingresa los números de los requerimientos asociados.</li>
										<li>El sistema verifica la existencia de esos requerimientos.</li>
										<li>El usuario o admin introduce los datos del caso de uso.</li>
										<li>El sistema registra el caso de uso. Volver paso 2. El CU termina.</li>
    								</ol>
								<h3>Extensiones</h3>
								<p>
									4-A. El o los requerimientos no existen.
								</p>
								<p style="text-indent: 5em;">
									A1. Desplegar mensaje de error.
								</p>
								<p style="text-indent: 5em;">
									A2. Volver al paso 2. 
								</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>


        <!--MODALES SIN ORDENAR AUN-->

        <div id="modal_selected_project" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" >Cambiar de Proyecto</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                    <div class="row">
                        <p id="new-project-name"></p>
                    </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button id="btn-cambiar" type="button" class="btn btn-primary">Cambiar</button>
                </div>
                </div>
            </div>
        </div><!-- /.modal -->

    </div>

    <!--JAVASCRIPT-->
    <!--Script que maneja la eliminacion y modificacion de requerimientos en la lista de requerimientos en el 1er acordeon-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabla-requerimientos').DataTable();
            var table = $('#tabla-requerimientos').DataTable();
            var req;
            var tr;

            $('#tabla-requerimientos tbody').on('click', 'a', function () {
                if ($(this).parent().hasClass('selected')) {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    $(this).parent().removeClass('selected');

                }
                else {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });
            $('#modal-delete-requerimiento').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Eliminar requerimiento: ' + req)
                modal.find('#req').text(req)
            })
            $('#btn-eliminar-requerimiento').on('click', function () {
                table.row(tr).remove().draw();//se elimina la fila de la tabla
                $('#modal-delete-requerimiento').modal('hide');//se esconde el modal
            });
            $('#modal-update-requerimiento').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Modificar requerimiento')
            });
        });
	</script>
    <!--Script que maneja la eliminacion e informacion de los casos de uso en la lista de casos de uso en el 2do acordeon-->
    <script type="text/javascript">
        //Data tables init
        $(document).ready(function () {
            $('#table-cu').DataTable();
            var table = $('#table-cu').DataTable();
            var caso_de_uso, tr;
            $('#table-cu tbody').on('click', 'a', function () {
                if ($(this).parent().hasClass('selected')) {
                    caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr'); //Se guarda la fila seleccionada
                    $(this).parent().removeClass('selected');
                }
                else {
                    caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr'); //Se guarda la fila seleccionada
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });
            $('#modal-delete-cu').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Eliminar caso de uso: ' + caso_de_uso)
                modal.find('#caso_de_uso').text(caso_de_uso)
            })
            //Para eliminar la fila
            $('#btn-eliminar-cu').on('click', function () {
                table.row(tr).remove().draw(); //Se elimina la fila de la tabla
                $('#modal-delete-cu').modal('hide'); //Se esconde el modal
            });
            $('#modal-info-cu').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Modificar caso de uso')
            });
        });
	</script>
    <!--Script que maneja la eliminacion de involucrados en la lista de involucrados en el 4to acordeon-->
    <script type="text/javascript">
            $(document).ready(function () {
                $('#table-users').DataTable();
                var table = $('#table-users').DataTable();
                var user;
                var tr;

                $('#table-users tbody').on('click', 'a', function () {
                    if ($(this).parent().hasClass('selected')) {
                        user = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        $(this).parent().removeClass('selected');

                    }
                    else {
                        user = $(this).parent().prev().prev().prev().prev().text();
                        tr = $(this).parents('tr');//se guarda la fila seleccionada
                        table.$('tr.selected').removeClass('selected');
                        $(this).parent().addClass('selected');
                    }
                });
                $('#modal-delete-involucrado').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Eliminar usuario:  ' + user)
                    modal.find('#user-name').text(user)
                })
                //para eliminar la fila
                $('#btn-eliminar').on('click', function () {
                    table.row(tr).remove().draw();//se elimina la fila de la tabla
                    $('#modal-delete-involucrado').modal('hide');//se esconde el modal
                    $('#alerts').addClass("alert alert-success alert-dismissible");
                    $('#alerts').text("Se ha eliminado con éxito");
                });
            });
    </script>
    

    <!--VALIDACIONES-->
    <!--Validaciones de campos en modal de modificar requerimiento en lista de requerimientos, 1er acorderon-->
    <script src="<%= Page.ResolveUrl("~/GUI/Modulo5/js/Validacion.js")%>"></script>

    <!--REFERENCIAS A LOS SCRIPTS DEL BOOTSTRAP TOGGLE-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/8.3/highlight.min.js"></script>
	<script src="bootstrap-toggle-master/doc/script.js"></script>
	<script src="bootstrap-toggle-master/js/bootstrap-toggle.js"></script>
	<script>
	    (function (i, s, o, g, r, a, m) {
	        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
	            (i[r].q = i[r].q || []).push(arguments)
	        }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
	    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
	    ga('create', 'UA-55669452-1', 'auto');
	    ga('send', 'pageview');
	</script>


    <!--COSAS SIN ORDENAR AUN-->
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            $('#table-requerimientos').DataTable();
        });
    
        jQuery(function ($) {
            $('#table-casosDeUso').DataTable();
        });

        jQuery(function ($) {
            $('#table-minutas').DataTable();
        });

        jQuery(function ($) {
            $('#table-involucrados').DataTable();
        });

        $(document).ready(function () {
            $("[rel=tooltip]").tooltip({ placement: 'top' });
        });
    </script>

    <script type="text/javascript">
        function openModal() {
            $('#modal_selected_project').modal('show');
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            /*$('#modal-delete-project').on('show.bs.modal', function () {
                var projectName = $("nombreProyecto").text();
                modal.find('#project-name').text(projectName);
            })*/
            $('#btn-eliminar2').on('click', function () {
                $('#modal-delete-project').modal('hide');

            });
        });
	</script>
</asp:Content>
