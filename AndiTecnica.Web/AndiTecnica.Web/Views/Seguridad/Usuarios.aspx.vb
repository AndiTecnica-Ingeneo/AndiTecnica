Imports AndiTecnica.Model
Imports AndiTecnica.Model.SeguridadFacade

Public Class Usuario
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaUsuarios As EnumModoPagina
        Get
            Return ViewState("ModoPaginaUsuarios")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaUsuarios") = value
        End Set
    End Property

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
                ods_Usuarios.SelectParameters.Clear()
                ods_Usuarios.SelectMethod = "BuscarUsuarios"
                ods_Usuarios.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
                ods_Usuarios.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaUsuarios = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarUsuario()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Usuarios.SelectedIndexChanged
        ModoPaginaUsuarios = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarUsuario()
        hdf_id.Value = grd_Usuarios.SelectedValue
        ObtenerUsuario()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaUsuarios = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Usuario = AsignarUsuario()
            If ModoPaginaUsuarios = EnumModoPagina.Insert Then
                SeguridadFacade.GuardarUsuario(Usuario)
                Master.mensajes = "success;Usuario creado con exito"
                OcultarBusqueda()
                ModoPaginaUsuarios = EnumModoPagina.Edit
            Else
                SeguridadFacade.ActualizarUsuario(Usuario)
                Master.mensajes = "success;Usuario modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            SeguridadFacade.EliminarUsuario(hdf_id.Value)
            Master.mensajes = "success;Usuario eliminado con exito"
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
        ods_Usuarios.SelectParameters.Clear()
        ods_Usuarios.SelectMethod = "ListarUsuarios"
        ods_Usuarios.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
        grd_Usuarios.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaUsuarios = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaUsuarios = EnumModoPagina.Insert Or ModoPaginaUsuarios = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerUsuario()
        Dim Usuario = SeguridadFacade.ConsultarUsuarioxId(hdf_id.Value)
        txt_Estado.Text = Usuario.Estados.Nombre
        txt_usuario.Text = Usuario.Usuario
        cbx_Empleados.SelectedValue = Usuario.EmpleadoFk
        cbx_Empleados.Text = Usuario.Empleados.Nombre
        cbx_Perfiles.SelectedValue = Usuario.PerfilFk
        cbx_Perfiles.Text = Usuario.Perfiles.Nombre
    End Sub

    Public Function AsignarUsuario() As Usuarios
        If txt_clave.Text <> txt_confirmaclave.Text Then
            Throw New Exception("Las claves ingresadas no coinciden")
        End If
        Dim usuario As New Usuarios
        Try
            usuario.UsuarioId = hdf_id.Value
        Catch ex As Exception

        End Try

        If cbx_Empleados.SelectedValue Is Nothing Or cbx_Empleados.SelectedValue = 0 Or cbx_Empleados.SelectedValue = "" Then
            Throw New Exception("Por favor ingrese un empleado")
        End If

        If cbx_Perfiles.SelectedValue Is Nothing Or cbx_Perfiles.SelectedValue = 0 Or cbx_Perfiles.SelectedValue = "" Then
            Throw New Exception("Por favor ingrese un perfil")
        End If

        If txt_usuario.Text = "" Then
            Throw New Exception("Por favor ingrese un usuario")
        Else
            usuario.Usuario = txt_usuario.Text
        End If

        If txt_clave.Text = "" Then
            Throw New Exception("Por favor ingrese una contraseña")
        Else
            usuario.Clave = FormsAuthentication.HashPasswordForStoringInConfigFile(txt_clave.Text, "md5")
        End If

        usuario.EmpleadoFk = cbx_Empleados.SelectedValue
        usuario.PerfilFk = cbx_Perfiles.SelectedValue


        Dim Modulo = SeguridadFacade.ConsultarModuloxNombre("Seguridad")
        usuario.Estado = SeguridadFacade.ConsultarEstadoxModulo(Modulo.ModuloId, "Activo").EstadoId

        Return usuario

    End Function

    Public Sub LimpiarUsuario()
        hdf_id.Value = Nothing
        txt_Estado.Text = Nothing
        txt_usuario.Text = Nothing
        cbx_Empleados.SelectedValue = Nothing
        cbx_Empleados.Text = Nothing
        cbx_Perfiles.SelectedValue = Nothing
        cbx_Perfiles.Text = Nothing
        Master.mensajes = Nothing
        txt_usuario.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("Usuarios")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub

End Class