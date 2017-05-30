<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Plantilla.aspx.vb" Inherits="AndiTecnica.Web.Plantilla" %>
<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_botones" runat="server">
    <asp:linkbutton cssclass="link_button" id="lkb_buscar" runat="server" tooltip="Buscar"><span class="fa fa-search"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_agregar" runat="server" tooltip="Agregar"><span class="fa fa-plus"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_guardar" runat="server" tooltip="Guardar"><span class="fa fa-floppy-o"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_eliminar" runat="server" tooltip="Eliminar"><span class="fa fa-trash-o"></span></asp:linkbutton>
    <asp:linkbutton cssclass="link_button" id="lkb_salir" runat="server" tooltip="Volver"><span class="fa fa-undo"></span></asp:linkbutton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <asp:panel id="pnl_form" runat="server">
   <table class="nav-justified">
      <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_Plantilla" runat="server" Text="Plantilla"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_nombres" class="form-control" runat="server"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_codigo" runat="server" Text="Codigo"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_codigo" runat="server" class="form-control"></asp:TextBox>
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
          <td class="veinte" align="center">
            <asp:DropDownList ID="ddl_buscar" runat="server" CssClass="dropdown btn btn-default dropdown-toggle text-center ochenta">
              <asp:ListItem Value="0">Buscar por</asp:ListItem>
              <asp:ListItem Value="1">Plantilla</asp:ListItem>
              <asp:ListItem Value="2">Codigo</asp:ListItem>
            </asp:DropDownList>
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
    <asp:GridView ID="grd_Plantillas" runat="server" AutoGenerateColumns="False" DataKeyNames="PlantillaId" DataSourceID="sds_Plantillas" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
      <AlternatingRowStyle BackColor="White" />
      <Columns>
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText="">
          <ControlStyle CssClass="fa fa-pencil link_button_select" />
        </asp:CommandField>
        <asp:BoundField DataField="PlantillaId" HeaderText="PlantillaId" InsertVisible="False" ReadOnly="True" SortExpression="PlantillaId" Visible="False" />
        <asp:BoundField DataField="Nombre" HeaderText="Plantilla" SortExpression="Nombre" />
        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
      </Columns>
      <HeaderStyle ForeColor="White" BackColor="#005490" />
    </asp:GridView>
    <asp:SqlDataSource ID="sds_Plantillas" runat="server" ConnectionString="<%$ ConnectionStrings:CVConnectionString %>" SelectCommand="PlantillasListar" SelectCommandType="StoredProcedure">
      <SelectParameters>
        <asp:Parameter DefaultValue="  " Name="campo" Type="String" />
        <asp:Parameter DefaultValue="  " Name="texto" Type="String" />
      </SelectParameters>
    </asp:SqlDataSource>
  </asp:panel>

    <asp:hiddenfield id="hdf_id" runat="server" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
