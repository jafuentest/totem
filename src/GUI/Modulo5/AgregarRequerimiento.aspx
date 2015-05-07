<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarRequerimiento.aspx.cs" Inherits="GUI_Modulo5_AgregarRequerimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="formularioAgregar" class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">      
        <form id="agregar_requerimientos" class="form-horizontal" method="post" action="ListarRequerimientos.aspx?success=1">
            <div class="form-group">
				<div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
					<input type="text" name="idreq" id="idreq_input" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_5_1"/>
				</div>
			</div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Tipo de Requerimiento:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" checked="checked" id="input_tipo_funcional" onclick="return fillCodigoTextField();" />Funcional</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo" id="input_tipo_no_funcional"  onclick="return fillCodigoTextField();"/>No Funcional</label>
                </div>
            </div>
            <br/>                
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <div class="input-group">
                        <span class="input-group-addon">El sistema deberá </span>
                        <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento" id="input_requerimiento"></textarea>
                    </div>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Prioridad:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" id="input_prioridad_baja"/>Baja</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" checked="checked" id="input_prioridad_media"/>Media</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" id="input_prioridad_alta"/>Alta</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Status:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled" checked="checked" id="input_status_nofinalizado"/>No Finalizado</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled" id="input_status_finalizado"/>Finalizado</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button id="btn-agregarReq" disabled="disabled" class="btn btn-primary" type="submit" onclick="return checkform();">Agregar</button>
                    <a class="btn btn-default" href="ListarRequerimientos.aspx">Cancelar</a>
                </div>
            </div>
        </form>
    </div>
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
</asp:Content>

