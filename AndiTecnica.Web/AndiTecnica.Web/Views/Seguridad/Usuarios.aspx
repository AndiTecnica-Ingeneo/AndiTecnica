<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Usuarios.aspx.vb" Inherits="AndiTecnica.Web.Usuario" %>
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
    <asp:Panel ID="pnl_form" runat="server">
    <table class="nav-justified">
      <tr>
          <td class="quince"></td>
          <td class="dos"></td>
          <td class="quince alinear_der">
            <asp:Label ID="Lbl_Estado" runat="server" Text="Estado"></asp:Label>
          </td>
          <td class="veinticuatro">
            <asp:Label ID="txt_Estado"  runat="server" ></asp:Label>
          </td>
          <td class="dos">
            &nbsp;</td>
          <td class="veinticuatro"></td>
        </tr>
        <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_usuario" runat="server" Text="Usuario"></asp:Label>
        </td>
        <td class="veinticuatro">
            <asp:TextBox ID="txt_usuario" runat="server" class="form-control"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_perfil" runat="server" Text="Perfil"></asp:Label>
        </td>
        <td class="veinticuatro">
            <asp:DropDownList ID="cbx_Perfiles" runat="server" DataSourceID="ods_Perfiles" DataTextField="Nombre" DataValueField="PerfilId" CssClass="dropdownlist">
            </asp:DropDownList>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
      <tr>
        <td class="alinear_der">
          <asp:Label ID="lbl_Empleado" runat="server" Text="Empleado"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cbx_Empleados" runat="server" DataSourceID="ods_Empleados" DataTextField="Nombre" DataValueField="EmpleadoId" CssClass="dropdownlist">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
        <td class="alinear_der">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td class="alinear_der">
          <asp:Label ID="lbl_clave" runat="server" Text="Contraseña"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txt_clave" runat="server" class="form-control" type="password"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td class="alinear_der">
          <asp:Label ID="lbl_confirmaclave" runat="server" Text="Confirmar Contraseña"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txt_confirmaclave" runat="server" class="form-control" type="password"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
    <br />
  </asp:Panel>

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
    <asp:GridView ID="grd_Perfiles" runat="server" AutoGenerateColumns="False" DataSourceID="ods_Usuarios" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
      <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UsuarioId" HeaderText="UsuarioId" SortExpression="UsuarioId" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
            <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" />
            <asp:BoundField DataField="PerfilFk" HeaderText="PerfilFk" SortExpression="PerfilFk" />
            <asp:BoundField DataField="EmpleadoFk" HeaderText="EmpleadoFk" SortExpression="EmpleadoFk" />
            <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
            <asp:BoundField DataField="Modificado" HeaderText="Modificado" SortExpression="Modificado" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
        </Columns>
      <HeaderStyle ForeColor="White" BackColor="#0f2612" />
    </asp:GridView>
  </asp:panel>

    <asp:hiddenfield id="hdf_id" runat="server" />

    <asp:ObjectDataSource ID="ods_Usuarios" runat="server" SelectMethod="ListarUsuarios" TypeName="AndiTecnica.Model.SeguridadFacade.SeguridadFacade"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ods_Perfiles" runat="server" SelectMethod="ListarPerfiles" TypeName="AndiTecnica.Model.SeguridadFacade.SeguridadFacade"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ods_Empleados" runat="server" SelectMethod="ListarEmpleados" TypeName="AndiTecnica.Model.SeguridadFacade.SeguridadFacade"></asp:ObjectDataSource>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
