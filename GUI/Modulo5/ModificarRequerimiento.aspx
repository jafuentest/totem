<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarRequerimiento.aspx.cs" Inherits="GUI_Modulo5_ModificarRequerimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
     <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
      <form id="agregar_requerimientos" class="form-horizontal" action="PrincipalProyecto.aspx">
            <div class="form-group">
                <p>&nbsp;&nbsp;&nbsp;&nbsp;Tipo de Requerimiento:</p>
                &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio1" checked="checked"/>Funcional</label>
                <label class="radio-inline">
                <input type="radio" name="optradio1"/>No Funcional</label>
            </div>
            <br/>
            <div class="row">
                <div class="col-lg-9">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">El sistema deberá </span>
                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento" ></textarea>
                        </div>
                    </div>
                </div>
            </div>
            <br/>
                <div class="form-group">
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;Prioridad:</p>
                    &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio"/>Baja</label>
                    <label class="radio-inline">
                    <input type="radio" name="optradio" checked="checked"/>Media</label>
                    <label class="radio-inline">
                    <input type="radio" name="optradio"/>Alta</label>
                </div>
            <br/>
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <button class="btn btn-primary" type="submit" onclick="return checkform()">Agregar</button>
                </div>
            </div>
        </form>
    </div>
    <script src="js/Validacion.js"></script>"
</asp:Content>
