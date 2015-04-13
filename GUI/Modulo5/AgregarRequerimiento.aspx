<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarRequerimiento.aspx.cs" Inherits="GUI_Modulo5_AgregarRequerimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="formularioAgregar" class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">      
        <form id="agregar_requerimientos" class="form-horizontal" method="post" action="ListarRequerimientos.aspx?success=1">
            <div class="form-group">
				<div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
					<input type="text" name="id" id="id" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_5_2"/>
				</div>
			</div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Tipo de Requerimiento:</b></p>
                    <label class="radio-inline"><input type="radio" name="radioTipo" checked="checked"/>Funcional</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioTipo"/>No Funcional</label>
                </div>
            </div>
            <br/>                
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <div class="input-group">
                        <span class="input-group-addon">El sistema deberá </span>
                        <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento" ></textarea>
                    </div>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Prioridad:</b></p>
                    <label class="radio-inline"><input type="radio" name="radioPrioridad"/>Baja</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad" checked="checked"/>Media</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioPrioridad"/>Alta</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <p><b>Status:</b></p>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled" checked="checked"/>No Finalizado</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled"/>Finalizado</label>
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
</asp:Content>

