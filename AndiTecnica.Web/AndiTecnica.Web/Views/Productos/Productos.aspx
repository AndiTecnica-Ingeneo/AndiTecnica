<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Productos.aspx.vb" Inherits="AndiTecnica.Web.Productos" %>

<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_botones" runat="server">
    <asp:LinkButton CssClass="link_button" ID="lkb_buscar" runat="server" ToolTip="Buscar"><span class="fa fa-search"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_agregar" runat="server" ToolTip="Agregar"><span class="fa fa-plus"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_editar" runat="server" ToolTip="Editar"><span class="fa fa-pencil"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_guardar" runat="server" ToolTip="Guardar"><span class="fa fa-floppy-o"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_eliminar" runat="server" ToolTip="Eliminar"><span class="fa fa-trash-o"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_salir" runat="server" ToolTip="Volver"><span class="fa fa-undo"></span></asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <asp:Panel ID="pnl_head" runat="server">
        <table class="cien">
            <tr>
                <td class="cien text-center">Productos</td>
            </tr>
        </table>
    </asp:Panel>
    <hr />
    <br />
    <asp:Panel ID="pnl_form" runat="server">
        <table class="nav-justified">
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="lbl_Nombre" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_nombreProducto" class="form-control" runat="server" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
                    <asp:Label ID="lbl_descripcion" runat="server" Text="Codigo"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Codigo" runat="server" class="form-control" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="Label1" runat="server" Text="Categoria"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <telerik:RadComboBox ID="cbx_Categorias" runat="server" AutoPostBack="True" CausesValidation="False" Class="dropdownlist" Culture="es-ES" DataSourceID="ods_Categorias" DataTextField="Nombre" DataValueField="CategoriasId" EnableAutomaticLoadOnDemand="True" EnableLoadOnDemand="True" Filter="Contains" Height="22px" Width="315px">
                    </telerik:RadComboBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
                    <asp:Label ID="Label2" runat="server" Text="Costo"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_costo" runat="server" class="form-control" TextMode="Number" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_DescripcionProducto" class="form-control" runat="server" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
                    <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Stock" runat="server" class="form-control" TextMode="Number" Height="22px" Width="315px" ></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">&nbsp;</td>
            </tr>
            <tr>
                <td class="quince alinear_der">&nbsp;</td>
                <td class="veinticuatro">&nbsp;</td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
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
        <hr />
        <table class="nav-justified">
            <tr>
                <td colspan="9" class="text-center">
                    <asp:Label ID="Label5" runat="server" Text="Dimensiones del Producto"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="9">&nbsp;</td>
            </tr>
            <tr>
                <td class="nueve alinear_der">
                    <asp:Label ID="Label7" runat="server" Text="Largo"></asp:Label>
                </td>
                <td class="quince">
                    <asp:TextBox ID="txt_Largo" class="form-control" runat="server" TextMode="Number" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
                    <asp:Label ID="Label8" runat="server" Text="Ancho"></asp:Label>
                </td>
                <td class="quince">
                    <asp:TextBox ID="txt_Ancho" class="form-control" runat="server" TextMode="Number" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="quince alinear_der">
                    <asp:Label ID="labelAlto" runat="server" Text="Alto"></asp:Label>
                </td>
                <td class="quince">
                    <asp:TextBox ID="txt_Alto" class="form-control" runat="server" TextMode="Number" Height="22px" Width="315px"></asp:TextBox>
                </td>
                <td class="nueve">&nbsp;</td>

            </tr>
        </table>
        <br />
        <br />
    </asp:Panel>

    <asp:Panel ID="pnl_list" runat="server">
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
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText="">
                    <ControlStyle CssClass="fa fa-pencil link_button_select" />
                </asp:CommandField>
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
    </asp:Panel>

    <asp:HiddenField ID="hdf_id" runat="server" />

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
