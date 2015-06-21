<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarRequerimiento.aspx.cs" Inherits="Vista.Modulo5.ModificarRequerimiento" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="formularioAgregar" class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">      
        <div id="alert" runat="server">
                </div>
        <form id="agregar_requerimientos" class="form-horizontal" method="post" runat="server">
            <div class="form-group">
				<div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
					<input type="text" name="idreq" id="inputIdRequerimiento" runat="server" 
                        placeholder="ID" class="form-control" disabled="disabled" />
				</div>
			</div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Tipo de Requerimiento:</b></p>

                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" 
                        id="inputFuncional" runat="server" />Funcional</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" id="inputNoFuncional"  
                        runat="server"/>No Funcional</label>
                </div>
            </div>
            <br/>                
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <div class="input-group">
                        <span class="input-group-addon">El sistema deberá </span>
                        <textarea class="form-control" rows="3"
                             placeholder="Funcionalidad del requerimiento" 
                            style="text-align: justify;resize:vertical;" name="requerimiento" 
                            id="inputRequerimiento" runat="server"></textarea>
                    </div>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Prioridad:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" 
                        id="inputPrioridadBaja" runat="server"/>Baja</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" 
                         id="inputPrioridadMedia" runat="server"/>Media</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" 
                        id="inputPrioridadAlta" runat="server"/>Alta</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Status:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled" runat="server"
                          id="inputStatusNoFinalizado"/>No Finalizado</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled"
                         id="inputStatusFinalizado" runat="server"/>Finalizado</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button id="btn_modRequerimiento" class="btn btn-primary" 
                        type="submit" runat="server" onserverclick="ModificarRequerimiento_Click">
                        Modificar</button>
                    <a class="btn btn-default" href="ListarRequerimientos.aspx">Cancelar</a>
                    <div class="pull-right">
                    <button id="btn_eliminarReq" class="btn btn-danger" runat="server"
                         onserverclick="EliminarRequerimiento_Click">Eliminar</button>
                    </div>
                </div>
            </div>
            
            
        </form>
    </div>
    <!--
    <script src="js/Validacion.js"></script>
    <script>
        function fillCodigoTextField() {
            var idTextField = document.getElementById("idreq_input");
            var funcionalRadio = document.getElementById("input_tipo_funcional");
            var nofuncionalRadio = document.getElementById("input_tipo_no_funcional");

            if (funcionalRadio.checked) {
                idTextField.value ="TOT_RF_5_1";
            }else
                if (nofuncionalRadio.checked) {
                    idTextField.value = "TOT_RNF_5_1";
                }
        }
    </script>
    -->
</asp:Content>
