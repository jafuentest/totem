<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleMinutas.aspx.cs" Inherits="GUI_Modulo8_DetalleMinutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Detalle
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
       <div id="alert" runat="server">
           </div>    
             <div id="alertlocal">
        </div>
     <form id="crearMinuta_form" class="form-horizontal" action="#">
        <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Min_01</label>  
           </div> 
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Proyecto:</label>  
           </div> 
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>TOTEM</label>  
           </div>
        </div>
       <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Fecha y Hora:</label>  
           </div> 
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>15-04-2015 12:45 p.m.</label>  
           </div>
        </div>
        <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Motivo de la Reunión:</label>  
           </div>
        </div>
         <div class="form-group">
           <div class="col-sm-10 col-md-10 col-lg-10">
             <label style="text-align:justify">La reunión fue planteada para discutir la interfaz elaborada por Santiago y planificar 
                 la organización en el wiki, para la elaboración e integración del documento ERS.</label>  
           </div>
        </div>
          <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Participantes:</label>  
           </div>
        </div>
        <div class="table-responsive">
		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>Asistentes</th>
					<th>Correo</th>
					<th>Compañia</th>
					<th>Ausentes</th>
					<th>Correo</th>
                    <th>Compañia</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Ana Pérez</td>
					<td>ana@gmail.com</td>
					<td>Facebook</td>
					<td>Cesar Contreras</td>
                    <td>cesar@gmail.com</td>
					<td>Facebook</td>
                </tr>
                <tr>
                    <td>José Morgado</td>
					<td>jose@gmail.com</td>
					<td>Facebook</td>
					<td>-----</td>
                    <td>-----</td>
					<td>-----</td>
                </tr>
			</tbody>
		</table>
	</div>
      <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Puntos Tratados:</label>  
           </div>
        </div>
         <div class="form-group">
           <div class="col-sm-10 col-md-10 col-lg-10">
             <label>1. Organización de las carpetas en wiki para la elaboracion del documento ERS por grupos.<br/>
                    2. Definir la organización de las paginas por modulo.<br/>
                    3. Uso de playsgolden en todos los modulos.</label>  
         </div>
        </div>
           <div class="form-group">
           <div class="col-sm-5 col-md-5 col-lg-5">
             <label>Desarrollo de Puntos Tratados:</label>  
           </div>
        </div>
         <div class="form-group">
           <div class="col-sm-10 col-md-10 col-lg-10">
             <label style="text-align:justify">Punto 1: En el wiki se dividiran carpetas por cada grupo y cada una contendrá Cuatro (4) paginas, 
                 la primera sera para los requerimientos funcionales, la segunda para los requerimientos no funcionales, 
                 la tercera para los casos de uso y la cuarta una descripción detallada del modulo.<br/><br/> 
                 Punto 2: Cada pagina por modulo debera llamarse por ejemplo: M1_casodeuso, 
                 M1_requerimientosfuncionales… etc.<br/><br/>
                 Punto 3: Cada modulo hara uso de los playsgolden, el cual consiste en mostrar el texto (Nombre, Apellido..) 
                 dentro de cada TextField y así ahorrar espacio en la página, en vez de tener un label para indicar el 
                 campo (Nombre, Apellido..) seguido del TextField.</label>  
         </div>
        </div>
        <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Observaciones:</label>  
           </div>
        </div>
         <div class="form-group">
           <div class="col-sm-10 col-md-10 col-lg-10">
             <label>Para este proyecto se trabajara con Visual Studio 2013.</label>  
         </div>
        </div>
        <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Acuerdos y Compromisos:</label>  
           </div>
        </div>
        <div class="table-responsive">
		<table id="table-example1" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>Acuerdos y Compromisos</th>
					<th>Responsable</th>
					<th>Fecha</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>1.- Conferencia de Skype control de avances.</td>
					<td>Delegados de cada módulo</td>
					<td>06-04-2015</td>
                </tr>
                <tr>
                    <td>2.- Definir Estandares de la Interfaz</td>
					<td>Delegados de cada módulo</td>
					<td>06-04-2015</td>
                </tr>
			</tbody>
		</table>
	</div>
     </form>
           <div class="form-group">
                        &nbsp;
				            <a class="btn btn-primary"  href="EditarMinuta.aspx?min=1">Editar</a>
                         &nbsp;
                            <a class="btn btn-primary">Imprimir</a>
		        </div>
  </div>
<script type="text/javascript">

    jQuery(function ($) {
        $('#table-example').DataTable();
    });
    jQuery(function ($) {
        $('#table-example1').DataTable();
    });
</script>
</asp:Content>



