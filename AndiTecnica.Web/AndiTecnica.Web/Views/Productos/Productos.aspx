<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Productos.aspx.vb" Inherits="AndiTecnica.Web.Productos" %>
<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
               <asp:Label ID="lbl_Nombre" runat="server" Text="Nombre"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:TextBox ID="txt_nombreProducto" class="form-control" runat="server"></asp:TextBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="veinticuatro alinear_der">
               <asp:Label ID="lbl_descripcion" runat="server" Text="Codigo"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:TextBox ID="txt_Codigo" runat="server" class="form-control"></asp:TextBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="nueve">&nbsp;</td>
       </tr>
       <tr>
           <td></td>
           <td></td>
           <td></td>
           <td></td>
           <td></td>
           <td></td>
           <td></td>
       </tr>
       <tr>
           <td class="quince alinear_der">
               <asp:Label ID="Label1" runat="server" Text="Categoria"></asp:Label>
           </td>
           <td class="veinticuatro">
               <telerik:RadComboBox ID="cbx_Categorias" runat="server" AutoPostBack="True" CausesValidation="False" Class="dropdownlist" Culture="es-ES" DataSourceID="ods_Categorias" DataTextField="Nombre" DataValueField="CategoriasId" EnableAutomaticLoadOnDemand="True" EnableLoadOnDemand="True" Filter="Contains" Height="65px" Width="340px">
               </telerik:RadComboBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="veinticuatro alinear_der">
               <asp:Label ID="Label2" runat="server" Text="Costo"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:TextBox ID="txt_costo" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="nueve">&nbsp;</td>
       </tr>
       <tr>
           <td class="quince alinear_der">
               <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:TextBox ID="txt_DescripcionProducto" class="form-control" runat="server"></asp:TextBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="veinticuatro alinear_der">
               <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:TextBox ID="txt_Stock" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
           </td>
           <td class="dos">&nbsp;</td>
           <td class="nueve">&nbsp;</td>
       </tr>
              <tr>
           <td class="quince alinear_der">
               &nbsp;</td>
           <td class="veinticuatro">
               &nbsp;</td>
           <td class="dos">&nbsp;</td>
           <td class="veinticuatro alinear_der">
               <asp:Label ID="Label6" runat="server" Text="Foto"></asp:Label>
           </td>
           <td class="veinticuatro">
               <asp:FileUpload ID="upl_FotoProducto" runat="server" />
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
              <asp:Label ID="lbl_buscar" runat="server" Text="Buscar Producto : "></asp:Label>
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
    <asp:GridView ID="grd_Productos" runat="server" DataKeyNames="ProductoId" AutoGenerateColumns="False" DataSourceID="ods_Productos" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
      <AlternatingRowStyle BackColor="White" />
      <Columns>
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText=""><ControlStyle CssClass="fa fa-pencil link_button_select"/></asp:CommandField>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
        <asp:BoundField DataField="CategoriasProductos.Nombre" HeaderText="Categoria" SortExpression="CategoriaFk" />
        <asp:BoundField DataField="Estados.Nombre" HeaderText="Estado" SortExpression="Estado" />
        <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
        <asp:BoundField DataField="Modificado" HeaderText="Modificado" SortExpression="Modificado" />
      </Columns>
      <HeaderStyle ForeColor="White" BackColor="#0f2612" />
    </asp:GridView>
  </asp:panel>

    <asp:hiddenfield id="hdf_id" runat="server" />

    <asp:ObjectDataSource ID="ods_Productos" runat="server" SelectMethod="ListarProductos" TypeName="AndiTecnica.Model.ProductosFacade.ProductosFacade"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ods_Categorias" runat="server" SelectMethod="ListarCategoriasProductos" TypeName="AndiTecnica.Model.ProductosFacade.ProductosFacade"></asp:ObjectDataSource>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
