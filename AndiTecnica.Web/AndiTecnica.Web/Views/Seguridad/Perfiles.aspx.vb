Imports AndiTecnica.Model
Imports AndiTecnica.Model.SeguridadFacade

Public Class Perfil
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaPerfiles As EnumModoPagina
        Get
            Return ViewState("ModoPaginaPerfiles")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaPerfiles") = value
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
                ods_Perfiles.SelectParameters.Clear()
                ods_Perfiles.SelectMethod = "BuscarPerfiles"
                ods_Perfiles.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
                ods_Perfiles.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaPerfiles = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarPerfil()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Perfiles.SelectedIndexChanged
        ModoPaginaPerfiles = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarPerfil()
        hdf_id.Value = grd_Perfiles.SelectedValue
        ObtenerPerfil()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaPerfiles = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Perfil = AsignarPerfil()
            If ModoPaginaPerfiles = EnumModoPagina.Insert Then
                SeguridadFacade.GuardarPerfil(Perfil)
                Master.mensajes = "success;Perfil creado con exito"
                OcultarBusqueda()
                ModoPaginaPerfiles = EnumModoPagina.Edit
            Else
                SeguridadFacade.ActualizarPerfil(Perfil)
                Master.mensajes = "success;Perfil modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            SeguridadFacade.EliminarPerfil(hdf_id.Value)
            Master.mensajes = "success;Perfil eliminado con exito"
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
        ods_Perfiles.SelectParameters.Clear()
        ods_Perfiles.SelectMethod = "ListarPerfiles"
        ods_Perfiles.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
        grd_Perfiles.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaPerfiles = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaPerfiles = EnumModoPagina.Insert Or ModoPaginaPerfiles = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerPerfil()
        Dim Perfil = SeguridadFacade.ConsultarPerfilxId(hdf_id.Value)
        txt_nombrePerfil.Text = Perfil.Nombre
        txt_DescripcionPerfil.Text = Perfil.Describe
    End Sub

    Public Function AsignarPerfil() As Perfiles
        Dim Perfil As New Perfiles
        Try
            Perfil.PerfilId = hdf_id.Value
        Catch ex As Exception

        End Try
        If txt_nombrePerfil.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Perfil.Nombre = txt_nombrePerfil.Text
        End If
        Perfil.Describe = txt_DescripcionPerfil.Text
        Return Perfil
    End Function

    Public Sub LimpiarPerfil()
        hdf_id.Value = Nothing
        txt_nombrePerfil.Text = Nothing
        txt_DescripcionPerfil.Text = Nothing
        Master.mensajes = Nothing
        txt_nombrePerfil.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("Perfiles")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub

End Class