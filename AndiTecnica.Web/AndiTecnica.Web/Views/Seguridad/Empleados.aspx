<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Empleados.aspx.vb" Inherits="AndiTecnica.Web.Empleados" %>

<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_botones" runat="server">
    <asp:LinkButton CssClass="link_button" ID="lkb_buscar" runat="server" ToolTip="Buscar"><span class="fa fa-search"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_agregar" runat="server" ToolTip="Agregar"><span class="fa fa-plus"></span></asp:LinkButton>
    <asp:linkbutton cssclass="link_button" id="lkb_editar" runat="server" tooltip="Editar"><span class="fa fa-pencil"></span></asp:linkbutton>
    <asp:LinkButton CssClass="link_button" ID="lkb_guardar" runat="server" ToolTip="Guardar"><span class="fa fa-floppy-o"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_eliminar" runat="server" ToolTip="Eliminar"><span class="fa fa-trash-o"></span></asp:LinkButton>
    <asp:LinkButton CssClass="link_button" ID="lkb_salir" runat="server" ToolTip="Volver"><span class="fa fa-undo"></span></asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <asp:Panel ID="pnl_form" runat="server">
        <table class="nav-justified">
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="lbl_Nombre" runat="server" Text="Nombre : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_nombreEmpleado" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="veinticuatro alinear_der">
                    <asp:Label ID="lbl_descripcion" runat="server" Text="Cedula :"></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_CedulaEmpleado" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="Label1" runat="server" Text="Telefono : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Telefono" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="veinticuatro alinear_der">
                    <asp:Label ID="Label2" runat="server" Text="Ext : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Ext" runat="server" class="form-control"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
            <tr>
                <td class="quince alinear_der">
                    <asp:Label ID="Label3" runat="server" Text="Celular : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Celular" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="dos">&nbsp;</td>
                <td class="veinticuatro alinear_der">
                    <asp:Label ID="Label4" runat="server" Text="E-mail : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:TextBox ID="txt_Email" runat="server" class="form-control"></asp:TextBox>
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
                    &nbsp;</td>
                <td class="veinticuatro">
                    &nbsp;</td>
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
                    <asp:Label ID="Label6" runat="server" Text="Firma Digital : "></asp:Label>
                </td>
                <td class="veinticuatro">
                    <asp:FileUpload ID="upl_FotoDigital" runat="server" Height="26px" Width="253px" />
                </td>
                <td class="dos">&nbsp;</td>
                <td class="nueve">&nbsp;</td>
            </tr>
        </table>
        <br />
    </asp:Panel>

    <asp:Panel ID="pnl_list" runat="server">
        <asp:Panel ID="pnl_buscar" runat="server">
            <table class="cien">
                <tr>
                    <td class="veinte"></td>
                    <td class="quince alinear_der" align="center">
                        <asp:Label ID="lbl_buscar" runat="server" Text="Buscar Empleado por Nombre : "></asp:Label>
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
        <asp:GridView ID="grd_Empleados" runat="server" DataKeyNames="EmpleadoId" AutoGenerateColumns="False" DataSourceID="ods_Empleados" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText=""><ControlStyle CssClass="fa fa-pencil link_button_select"/></asp:CommandField>
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" SortExpression="Cedula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
                <asp:BoundField DataField="Modificado" HeaderText="Modificado" SortExpression="Modificado" />
                <asp:BoundField DataField="Estados.Nombre" HeaderText="Estado" SortExpression="Estado" />
             </Columns>
            <HeaderStyle ForeColor="White" BackColor="#0f2612" />
        </asp:GridView>
    </asp:Panel>

    <asp:HiddenField ID="hdf_id" runat="server" />

    <asp:ObjectDataSource ID="ods_Empleados" runat="server" SelectMethod="ListarEmpleados" TypeName="AndiTecnica.Model.SeguridadFacade.SeguridadFacade"></asp:ObjectDataSource>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
