Imports AndiTecnica.Model
Imports AndiTecnica.Model.TercerosFacade
Imports AndiTecnica.Model.SeguridadFacade
Imports AndiTecnica.Web

Public Class Clientes
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaClientes As EnumModoPagina
        Get
            Return ViewState("ModoPaginaClientes")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaClientes") = value
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
                ods_Clientes.SelectParameters.Clear()
                ods_Clientes.SelectMethod = "BuscarClientes"
                ods_Clientes.TypeName = "AndiTecnica.Model.TercerosFacade.TercerosFacade"
                ods_Clientes.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaClientes = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarCliente()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Clientes.SelectedIndexChanged
        ModoPaginaClientes = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarCliente()
        hdf_id.Value = grd_Clientes.SelectedValue
        ObtenerCliente()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaClientes = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Cliente = AsignarCliente()
            If ModoPaginaClientes = EnumModoPagina.Insert Then
                TercerosFacade.GuardarCliente(Cliente)
                Master.mensajes = "success;Cliente creado con exito"
                OcultarBusqueda()
                ModoPaginaClientes = EnumModoPagina.Edit
            Else
                TercerosFacade.ActualizarCliente(Cliente)
                Master.mensajes = "success;Cliente modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            TercerosFacade.EliminarCliente(hdf_id.Value)
            Master.mensajes = "success;Cliente eliminado con exito"
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
        ods_Clientes.SelectParameters.Clear()
        ods_Clientes.SelectMethod = "ListarClientes"
        ods_Clientes.TypeName = "AndiTecnica.Model.TercerosFacade.TercerosFacade"
        grd_Clientes.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaClientes = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaClientes = EnumModoPagina.Insert Or ModoPaginaClientes = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerCliente()
        Dim Cliente = TercerosFacade.ConsultarClientexId(hdf_id.Value)
        txt_Estado.Text = Cliente.Estados.Nombre
        txt_nombre.Text = Cliente.Nombre
        txt_identificacion.Text = Cliente.Identificacion
        txt_direccion.Text = Cliente.Direccion
        cbx_Paises.SelectedValue = Cliente.PaisFk
        txt_correo.Text = Cliente.Correo
        txt_telefono.Text = Cliente.Telefono
        cbx_plazos.SelectedValue = Cliente.PlazoFk
        txt_Notas.Text = Cliente.Notas
    End Sub

    Public Function AsignarCliente() As Model.Clientes
        Dim Cliente As New Model.Clientes
        Try
            Cliente.ClienteId = hdf_id.Value
        Catch ex As Exception

        End Try
        If txt_nombre.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Cliente.Nombre = txt_nombre.Text
        End If
        Cliente.Identificacion = txt_identificacion.Text
        Cliente.Direccion = txt_direccion.Text
        Cliente.PaisFk = cbx_Paises.SelectedValue
        Cliente.Correo = txt_correo.Text
        Cliente.Telefono = txt_telefono.Text
        Cliente.PlazoFk = cbx_plazos.SelectedValue
        Cliente.Notas = txt_Notas.Text

        Dim Modulo = SeguridadFacade.ConsultarModuloxNombre("Terceros")
        Cliente.EstadoFk = SeguridadFacade.ConsultarEstadoxModulo(Modulo.ModuloId, "Activo").EstadoId

        Return Cliente
    End Function

    Public Sub LimpiarCliente()
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
        prm = permisos.AutorizarBotones("Clientes")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class