<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Perfiles.aspx.vb" Inherits="AndiTecnica.Web.Perfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_botones" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <form class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-offset-2 col-sm-2" for="email">Nombre</label>
            <div class="col-sm-4">
                <input type="email" class="form-control" id="email" tabindex ="Enter email"/>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-offset-2 col-sm-2" for="pwd">Descripción:</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" id="pwd" placeholder="Enter password"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="submit" class="btn btn-default">Guardar</button>
            </div>
        </div>
    </form>
</asp:Content>
