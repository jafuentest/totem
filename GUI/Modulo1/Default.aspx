<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/GUI/Modulo1/Modulo1.master"%>

<asp:Content ContentPlaceHolderID="subtitulo" runat="server">titulo sub master</asp:Content>

<asp:Content ContentPlaceHolderID="contenidoCentral" runat="server">
    
    <div class="row placeholders">
	    <div class="col-xs-6 col-sm-3 placeholder">
		    <img src="holder.js/200x200/auto/sky" class="img-responsive" alt="Generic placeholder thumbnail"/>
		    <h4>Título</h4>
		    <span class="text-muted">Descripción</span>
	    </div>
	    <div class="col-xs-6 col-sm-3 placeholder">
		    <img src="holder.js/200x200/auto/vine" class="img-responsive" alt="Generic placeholder thumbnail"/>
		    <h4>Título</h4>
		    <span class="text-muted">Descripción</span>
	    </div>
	    <div class="col-xs-6 col-sm-3 placeholder">
		    <img src="holder.js/200x200/auto/sky" class="img-responsive" alt="Generic placeholder thumbnail"/>
		    <h4>Título</h4>
		    <span class="text-muted">Descripción</span>
	    </div>
	    <div class="col-xs-6 col-sm-3 placeholder">
		    <img src="holder.js/200x200/auto/vine" class="img-responsive" alt="Generic placeholder thumbnail"/>
		    <h4>Título</h4>
		    <span class="text-muted">Descripción</span>
	    </div>
    </div>

    <h2 class="sub-header">Título de sección <small>tabla ejemplo</small></h2>
    <div class="table-responsive">
	    <table class="table table-striped">
		    <thead>
			    <tr>
				    <th>Número</th>
				    <th>Título</th>
				    <th>Título</th>
				    <th>Título</th>
				    <th>Título</th>
			    </tr>
		    </thead>
		    <tbody>
			    <tr>
				    <td>01</td>
				    <td>Lorem</td>
				    <td>ipsum</td>
				    <td>dolor</td>
				    <td>sit</td>
			    </tr>
			    <tr>
				    <td>02</td>
				    <td>amet</td>
				    <td>consectetur</td>
				    <td>adipiscing</td>
				    <td>elit</td>
			    </tr>
		    </tbody>
	    </table>
    </div>
</asp:Content>