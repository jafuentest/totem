<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="CrearActor.aspx.cs" Inherits="Vista.Modulo6.CrearActor" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Actores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar Actor
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div id="alert" runat="server">
                </div>
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<form runat="server" class="form-horizontal" method="POST">
            <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                    ControlToValidate="nombre_actor"
                    class="alert alert-danger alert-dismissible"
                    Text="Nombre de Actor requerido"
                    ErrorMessage="Se requiere la Dirección"
                    >
                </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                        runat="server" 
                        ControlToValidate="nombre_actor"
                        class="alert alert-danger alert-dismissible"
                        ErrorMessage="Solo se admiten caracteres alfabéticos"  
                        Text="El nombre del actor debe ser alfabético" 
                       ValidationExpression="^[a-zA-Z ]*$">
                </asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="descripcion_actor"
                    Text="Descripción requerida"
                    class="alert alert-danger alert-dismissible"
                    ErrorMessage="Se requiere la Dirección"
                    >
                </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" 
                        ControlToValidate="descripcion_actor"
                        ErrorMessage="Solo se admiten caracteres alfabéticos"
                        class="alert alert-danger alert-dismissible"  
                        Text="La descripción solo permite , - . : como caracteres especiales" 
                       ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.:\-\ ]+)$">
                </asp:RegularExpressionValidator>


			<div class="form-group">
				<div id="div-nombre" class="col-sm-10 col-md-10 col-lg-10">
					<input id="nombre_actor" type="text" runat="server" name="nombre" placeholder="Nombre" class="form-control" maxlength="30" />
				</div>
			</div>
			<div class="form-group">
				<div id="div-descripcion" class="col-sm-10 col-md-10 col-lg-10">
					<input id="descripcion_actor" runat="server" type="text" name="descripcion" placeholder="Descripcion" class="form-control" maxlength="100" />
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-6">
                    <asp:Label ID="label" runat="server" ></asp:Label>
					<button runat="server" class="btn btn-primary" type="submit" onserverclick="AgregarActorClick">Agregar</button>
					<a class="btn btn-default" href="ListarActores.aspx">Cancelar</a>
				</div>
			</div>
		</form>
	</div>

</asp:Content>
