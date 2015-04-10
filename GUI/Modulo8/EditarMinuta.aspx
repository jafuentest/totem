<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="EditarMinuta.aspx.cs" Inherits="GUI_Modulo8_EditarMinuta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Modificar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
     <form id="crearMinuta_form" class="form-horizontal" action="#">
       <div class="form-group">
           <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Fecha y Hora:</label>  
           </div> 
           <div id="div_fechaReunion" class="col-sm-4 col-md-4 col-lg-4">
				<input type="datetime-local" class="form-control" name="fechaReunion"/>
		   </div>
       </div>
        <div class="form-group">
			<div id="div_motivo" class="col-sm-10 col-md-10 col-lg-10">
                <textarea name="motivo" placeholder="Motivo de la Reunión" class="form-control" rows=1></textarea>			
			</div>
         </div>
         </form>
      <form id="AgregarParticipantes" class="form-horizontal" action="#"> 
          <div class="form-group">  
          <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Participantes</label>  
           </div>
          </div>   
          <div class="form-group">
            <div class="col-sm-3 col-md-3 col-lg-3" > 
                    <select name="listaParti" id="id_participa" class="btn btn-default dropdown-toggle" multiple="multiple" data-toggle="dropdown">
                       <option class="dropdown-header" role="presentation">PARTICIPANTES:</option> 
                       <option>Cesar Contreras</option> 
                       <option>Ana Pérez</option>
                       <option>Daniel Sam</option> 
                       <option>Ramón Quintero</option>
                    </select>
                </div>
              <div class="col-sm-3 col-md-3 col-lg-3" > 
                 <div class="btn-group">
                    <select name="asistetes" id="id_asisentes" class="btn btn-default dropdown-toggle" multiple="multiple" data-toggle="dropdown">
                       <option class="dropdown-header" role="presentation">ASISTENTES:</option> 
                       
                    </select>
                </div> 
                    <a id="A3"></a>           
              </div>
                <div class="col-sm-3 col-md-3 col-lg-3" >  
                 <div class="btn-group">
                    <select name="id_ausentes" class="btn btn-default dropdown-toggle" multiple="multiple" data-toggle="dropdown">
                       <option class="dropdown-header" role="presentation">AUSENTES:</option> 
                       
                    </select>
                </div> 
                    <a id="A4"></a>          
              </div>
            </div>
            <div class="form-group">          
               <div class="col-sm-5 col-md-5 col-lg-5">
                 <button type="submit" class="btn btn-primary" onclick="return agregar()">Asistentes</button>
                 <button type="submit" class="btn btn-primary" >Ausentes</button>
                 <button class="btn btn-primary" onclick="Agregar()">Quitar</button>
                </div> 
             </div>        
     </form>
     <form id="Información Minuta" class="form-horizontal" action="#">
        <div class="form-group">
			<div id="div_puntos" class="col-sm-10 col-md-10 col-lg-10">
				<textarea placeholder="Puntos Tratados" class="form-control" name="puntos" rows=1></textarea>
			</div>
         </div>
          <div class="form-group">
			<div id="div_desarrollo" class="col-sm-10 col-md-10 col-lg-10">
				<textarea placeholder="Desarrollo de Puntos Tratados" class="form-control" name="desarrollo" rows=1></textarea>
			</div>
         </div>
         <div class="form-group">
			<div id="div_observaciones" class="col-sm-10 col-md-10 col-lg-10">
				<textarea placeholder="Observaciones" class="form-control" name="observaciones" rows=1></textarea>
			</div>
         </div>
        </form>
    
    <form id="AcuerdosComp" class="form-horizontal" action="#">
          <div class="form-group">  
          <div class="col-sm-3 col-md-3 col-lg-3">
             <label>Acuerdos y Compromisos</label>  
           </div>
          </div> 
        <div class="form-group">
          <div class="col-sm-3 col-md-3 col-lg-3">
		    <input type="text" placeholder="Acuerdos y compromisos" class="form-control" name="compromisos"/>
        </div>
         <div class="col-sm-3 col-md-3 col-lg-3" > 
                 <div class="btn-group">
                    <button id="id_responsables" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                         Responsables...<span class="caret"></span>
                    </button>
                      <ul id="resp" class="dropdown-menu" role="menu">
                           <li><a href="#">María Vargas</a></li>
                           <li><a href="#">Cesar Contreras</a></li>
                           <li><a href="#">Ana Perez</a></li>
                           <li><a href="#">Daniel Sam</a></li>
                      </ul>
                     </div> 
                        <a id="A2"></a>           
                    </div>
         <div class="col-sm-3 col-md-3 col-lg-3">
		    <input type="date" class="form-control" name="Fecha"/>
        </div>
       </div>
        <div class="form-group">
            <div class="col-sm-5 col-md-5 col-lg-5">
                 <button class="btn btn-primary" onclick="Agregar()">Agregar</button>
           </div>   
	    </div>
        <div class="table-responsive">
		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th>Acuerdos y Compromisos</th>
					<th>Responsable</th>
					<th>Fecha</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Min_01</td>
					<td>Mandar Poryecto Completo</td>
					<td>María Vargas</td>
					<td>10-05-15</td>
                    <td>
                        <a class="btn btn-default" onclick="return modificar()">Modificar</a>
                        <a class="btn btn-danger " onclick="return eliminar()">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>Min_02</td>
                    <td>Casos de Uso</td>
                    <td>Ana Pérez</td>
                    <td>15-08-15</td>
                    <td>
                         <a class="btn btn-default" onclick="return modificar()">Modificar</a>
                        <a class="btn btn-danger " onclick="return eliminar()">Eliminar</a>

                    </td>
                </tr>
			</tbody>
		</table>
	</div>
       <div class="form-group">
            
		    <div class="col-sm-5 col-md-5 col-lg-5">
				<button class="btn btn-primary" onclick="return CrearMinuta()">Modificar Minuta</button>
			</div>    
	    </div>
    </form> 
</div>
<script type="text/javascript">
    jQuery(function ($) {
        $('#table-example').DataTable();
    });

    $("#asis li a").click(function () {

        $("#id_asistentes").html($(this).text() + ' <span class="caret"></span>');

    });

    $("#aus li a").click(function () {

        $("#id_ausentes").html($(this).text() + ' <span class="caret"></span>');

    });

    $("#resp li a").click(function () {

        $("#id_responsables").html($(this).text() + ' <span class="caret"></span>');

    });
 </script>
</asp:Content>

