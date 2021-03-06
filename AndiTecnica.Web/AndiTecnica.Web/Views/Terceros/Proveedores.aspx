﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Principal.Master" CodeBehind="Proveedores.aspx.vb" Inherits="AndiTecnica.Web.Proveedores" %>
<%@ MasterType VirtualPath="~/MasterPages/Principal.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
   <asp:Panel id="pnl_head" runat="server">
   <table class="cien">
            <tr>                
                <td class="cien text-center">Proveedores</td>
            </tr>           
        </table>
   </asp:Panel>
   <br />
   <asp:panel id="pnl_form" runat="server">
   <table class="nav-justified">
      <tr>
        <td class="quince alinear_der">
          &nbsp;
        </td>
        <td class="veinticuatro">
          &nbsp;
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_Estado" runat="server" Text="Estado"></asp:Label>
        </td>
        <td class="veinticuatro">
            <asp:Label ID="txt_Estado" runat="server"></asp:Label>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
       <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_nombre" class="form-control" runat="server"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_identificacion" runat="server" Text="Identificacion"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_identificacion" runat="server" class="form-control"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
       <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_Direccion" runat="server" Text="Direccion"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_direccion" class="form-control" runat="server"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_Pais" runat="server" Text="Pais"></asp:Label>
        </td>
        <td class="veinticuatro">
          <telerik:RadComboBox ID="cbx_Paises" runat="server" Class="dropdownlist" AutoPostBack="True" CausesValidation="False" Culture="es-ES"
               EnableLoadOnDemand="True" EnableAutomaticLoadOnDemand="True" Filter="Contains" Height="45px" Width="270px">
              <Items>
                  <telerik:RadComboBoxItem runat="server" Text="Colombia" Value="1" />
                  <telerik:RadComboBoxItem runat="server" Text="Estados Unidos" Value="2" />
                  <telerik:RadComboBoxItem runat="server" Text="Inglaterra" Value="3" />
              </Items>
            </telerik:RadComboBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
       <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_correo" runat="server" Text="Correo"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_correo" class="form-control" runat="server"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_Telefono" runat="server" Text="Telefono"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_telefono" runat="server" class="form-control"></asp:TextBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="nueve">&nbsp;</td>
      </tr>
      <tr>
        <td class="quince alinear_der">
          <asp:Label ID="lbl_plazo" runat="server" Text="Plazo"></asp:Label>
        </td>
        <td class="veinticuatro">
           <telerik:RadComboBox ID="cbx_plazos" runat="server" Class="dropdownlist" AutoPostBack="True" CausesValidation="False" Culture="es-ES"
               EnableLoadOnDemand="True" EnableAutomaticLoadOnDemand="True" Filter="Contains" Height="45px" Width="270px">
              <Items>
                  <telerik:RadComboBoxItem runat="server" Text="15 Dias" Value="1" />
                  <telerik:RadComboBoxItem runat="server" Text="30 Dias" Value="2" />
                  <telerik:RadComboBoxItem runat="server" Text="60 Dias" Value="3" />
              </Items>
            </telerik:RadComboBox>
        </td>
        <td class="dos">&nbsp;</td>
        <td class="veinticuatro alinear_der">
          <asp:Label ID="lbl_notas" runat="server" Text="Notas"></asp:Label>
        </td>
        <td class="veinticuatro">
          <asp:TextBox ID="txt_Notas" runat="server" class="form-control"></asp:TextBox>
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
              <asp:Label ID="lbl_buscar" runat="server" Text="Buscar Proveedor : "></asp:Label>
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
    <asp:GridView ID="grd_Proveedores" runat="server" AutoGenerateColumns="False" DataSourceID="ods_Proveedores" DataKeyNames="ProveedorId" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
      <AlternatingRowStyle BackColor="White" />
      <Columns>
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-pencil" ItemStyle-HorizontalAlign="Center" SelectText=""><ControlStyle CssClass="fa fa-pencil link_button_select"/></asp:CommandField>
        <asp:BoundField DataField="ProveedorId" HeaderText="ProveedorId" SortExpression="ProveedorId" visible ="false"/>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
        <asp:BoundField DataField="Notas" HeaderText="Notas" SortExpression="Notas" />
        <asp:BoundField DataField="Creado" HeaderText="Creado" SortExpression="Creado" />
        <asp:BoundField DataField="Modificado" HeaderText="Modificado" SortExpression="Modificado" />
        <asp:BoundField DataField="Estados.Nombre" HeaderText="Estado" SortExpression="Estado" />
      </Columns>
      <HeaderStyle ForeColor="White" BackColor="#0f2612" />
    </asp:GridView>
  </asp:panel>

    <asp:hiddenfield id="hdf_id" runat="server" />

    <asp:ObjectDataSource ID="ods_Proveedores" runat="server" SelectMethod="ListarProveedores" TypeName="AndiTecnica.Model.TercerosFacade.TercerosFacade"></asp:ObjectDataSource>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#mainNav li").removeAttr("class");
            $("#mainNav li").attr("class scroll-link");
            $("#li_Plantillas").attr("class", "active");
        });

    </script>

</asp:Content>
