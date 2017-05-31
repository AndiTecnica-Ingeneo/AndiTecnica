<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Perfiles.aspx.vb" Inherits="AndiTecnica.Web.Perfil" %>
<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_botones" runat="server">
    <asp:linkbutton cssclass="link_button" id="lkb_buscar" runat="server" tooltip="Buscar"><span class="fa fa-search"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_agregar" runat="server" tooltip="Agregar"><span class="fa fa-plus"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_editar" runat="server" tooltip="Editar"><span class="fa fa-pencil"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_guardar" runat="server" tooltip="Guardar"><span class="fa fa-floppy-o"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_eliminar" runat="server" tooltip="Eliminar"><span class="fa fa-trash-o"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_salir" runat="server" tooltip="Volver"><span class="fa fa-undo"></span></asp:linkbutton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <asp:panel id="pnl_form" runat="server">
   <table class="nav-justified">
      <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_Nombre" runat="server" Text="Perfil : "></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_nombrePerfil" class="form-control" runat="server"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_descripcion" runat="server" Text="Descripcion"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_DescripcionPerfil" runat="server" class="form-control"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
    </table>
    <br />
  </asp:panel>

    <asp:panel id="pnl_list" runat="server">
    <asp:Panel ID="pnl_buscar" runat="server">
      <table class="cien">
        <tr>
          <td class="veinte"></td>
          <td class="quince alinear_der" align="center">
              <asp:Label ID="lbl_buscar" runat="server" Text="Buscar Perfil : "></asp:Label>
          </td>
          <td class="veinte">
            <asp:TextBox ID="txt_bucar" class="form-control" runat="server"></asp:TextBox>
          </td>
          <td class="veinte" align="center">
            <button type="button" id="btn_filtrar" class="btn btn-default ochenta" runat="server">Filtrar</button>

          </td>
          <td class="veinte"></td>
        </tr>
      </table>
      <br />
    </asp:Panel>
    <asp:GridView ID="grd_Perfiles" runat="server" AutoGenerateColumns="False" DataSourceID="ods_Perfiles" DataKeyNames="PerfilId" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
      <AlternatingRowStyle BackColor="White" />
      <Columns>
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText=""><ControlStyle CssClass="fa fa-pencil link_button_select"/></asp:CommandField>
        <asp:BoundField DataField="PerfilId" HeaderText="PerfilId" SortExpression="PerfilId" visible ="false"/>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Describe" HeaderText="Describe" SortExpression="Describe" />
        <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
        <asp:BoundField DataField="Modificado" HeaderText="Modificado" SortExpression="Modificado" />
        <asp:BoundField DataField="Nombre" HeaderText="Estado" SortExpression="Nombre" />
      </Columns>
      <HeaderStyle ForeColor="White" BackColor="#0f2612" />
    </asp:GridView>
  </asp:panel>

    <asp:hiddenfield id="hdf_id" runat="server" />

    <asp:ObjectDataSource ID="ods_Perfiles" runat="server" SelectMethod="ListarPerfiles" TypeName="AndiTecnica.Model.SeguridadFacade.SeguridadFacade"></asp:ObjectDataSource>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
