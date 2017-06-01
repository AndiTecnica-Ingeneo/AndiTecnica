Imports AndiTecnica.Model
Imports AndiTecnica.Model.TercerosFacade
Imports AndiTecnica.Model.SeguridadFacade
Imports AndiTecnica.Web

Public Class Proveedores
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaProveedores As EnumModoPagina
        Get
            Return ViewState("ModoPaginaProveedores")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaProveedores") = value
        End Set
    End Property

    Dim TercerosFacade As New TercerosFacade
    Dim SeguridadFacade As New SeguridadFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MostrarLista()
            pnl_buscar.Visible = False
            CargarPermisos()
        End If
    End Sub

    Protected Sub Buscar(sender As Object, e As EventArgs) Handles lkb_buscar.Click
        pnl_buscar.Visible = True
        Master.mensajes = Nothing
    End Sub

    Protected Sub Filtrar(sender As Object, e As EventArgs) Handles btn_filtrar.ServerClick
        If txt_bucar.Text = "" Then
            Master.mensajes = "warning;Por favor ingrese la informacion a buscar"
        Else
            Try
                ods_Proveedores.SelectParameters.Clear()
                ods_Proveedores.SelectMethod = "BuscarProveedores"
                ods_Proveedores.TypeName = "AndiTecnica.Model.TercerosFacade.TercerosFacade"
                ods_Proveedores.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaProveedores = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarProveedor()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Proveedores.SelectedIndexChanged
        ModoPaginaProveedores = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarProveedor()
        hdf_id.Value = grd_Proveedores.SelectedValue
        ObtenerProveedor()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaProveedores = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Proveedor = AsignarProveedor()
            If ModoPaginaProveedores = EnumModoPagina.Insert Then
                TercerosFacade.GuardarProveedor(Proveedor)
                Master.mensajes = "success;Proveedor creado con exito"
                OcultarBusqueda()
                ModoPaginaProveedores = EnumModoPagina.Edit
            Else
                TercerosFacade.ActualizarProveedor(Proveedor)
                Master.mensajes = "success;Proveedor modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            TercerosFacade.EliminarProveedor(hdf_id.Value)
            Master.mensajes = "success;Proveedor eliminado con exito"
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Salir(sender As Object, e As EventArgs) Handles lkb_salir.Click
        MostrarLista()
        Master.mensajes = Nothing
    End Sub

    Public Sub MostrarLista()
        pnl_form.Visible = False
        pnl_list.Visible = True
        lkb_buscar.Visible = True
        lkb_agregar.Visible = True
        lkb_guardar.Visible = False
        lkb_editar.Visible = False
        lkb_eliminar.Visible = False
        lkb_salir.Visible = False
        ods_Proveedores.SelectParameters.Clear()
        ods_Proveedores.SelectMethod = "ListarProveedores"
        ods_Proveedores.TypeName = "AndiTecnica.Model.TercerosFacade.TercerosFacade"
        grd_Proveedores.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaProveedores = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaProveedores = EnumModoPagina.Insert Or ModoPaginaProveedores = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerProveedor()
        Dim Proveedor = TercerosFacade.ConsultarProveedorxId(hdf_id.Value)
        txt_Estado.Text = Proveedor.Estados.Nombre
        txt_nombre.Text = Proveedor.Nombre
        txt_identificacion.Text = Proveedor.Identificacion
        txt_direccion.Text = Proveedor.Direccion
        cbx_Paises.SelectedValue = Proveedor.PaisFk
        txt_correo.Text = Proveedor.Correo
        txt_telefono.Text = Proveedor.Telefono
        cbx_plazos.SelectedValue = Proveedor.PlazoFk
        txt_Notas.Text = Proveedor.Notas
    End Sub

    Public Function AsignarProveedor() As Model.Proveedores
        Dim Proveedor As New Model.Proveedores
        Try
            Proveedor.ProveedorId = hdf_id.Value
        Catch ex As Exception

        End Try
        If txt_nombre.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Proveedor.Nombre = txt_nombre.Text
        End If
        Proveedor.Identificacion = txt_identificacion.Text
        Proveedor.Direccion = txt_direccion.Text
        Proveedor.PaisFk = cbx_Paises.SelectedValue
        Proveedor.Correo = txt_correo.Text
        Proveedor.Telefono = txt_telefono.Text
        Proveedor.PlazoFk = cbx_plazos.SelectedValue
        Proveedor.Notas = txt_Notas.Text

        Dim Modulo = SeguridadFacade.ConsultarModuloxNombre("Terceros")
        Proveedor.EstadoFk = SeguridadFacade.ConsultarEstadoxModulo(Modulo.ModuloId, "Activo").EstadoId

        Return Proveedor
    End Function

    Public Sub LimpiarProveedor()
        hdf_id.Value = Nothing
        txt_nombre.Text = Nothing
        txt_identificacion.Text = Nothing
        txt_direccion.Text = Nothing
        cbx_Paises.SelectedValue = Nothing
        txt_correo.Text = Nothing
        txt_telefono.Text = Nothing
        cbx_plazos.SelectedValue = Nothing
        txt_Notas.Text = Nothing
        txt_nombre.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("Proveedores")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class