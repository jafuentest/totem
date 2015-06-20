<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarRequerimiento.aspx.cs" Inherits="Vista.Modulo5.AgregarRequerimiento" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar Requerimiento</asp:Content>
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
                    <input type="radio" name="radioTipo" checked="true" 
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
                        checked="true" id="inputPrioridadMedia" runat="server"/>Media</label>
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
                         checked="true" id="inputStatusNoFinalizado"/>No Finalizado</label>
                    <label class="radio-inline">
                    <input type="radio" name="radioStatus" disabled="disabled"
                         id="inputStatusFinalizado" runat="server"/>Finalizado</label>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button runat="server" id="btn_agregarReq" class="btn btn-primary" 
                        type="submit" onserverclick="AgregarRequerimiento_Click">Agregar</button>
                    <a class="btn btn-default" href="ListarRequerimientos.aspx">Cancelar</a>
                </div>
            </div>
        </form>
    </div>
    
</asp:Content>
