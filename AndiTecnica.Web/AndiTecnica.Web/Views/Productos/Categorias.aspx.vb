Imports AndiTecnica.Model
Imports AndiTecnica.Model.ProductosFacade
Imports AndiTecnica.Model.SeguridadFacade

Public Class Categorias
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaCategoriasProductos As EnumModoPagina
        Get
            Return ViewState("ModoPaginaCategoriasProductos")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaCategoriasProductos") = value
        End Set
    End Property

    Dim ProductosFacade As New ProductosFacade

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
                ods_CategoriasProductos.SelectParameters.Clear()
                ods_CategoriasProductos.SelectMethod = "BuscarCategoriasProductos"
                ods_CategoriasProductos.TypeName = "AndiTecnica.Model.ProductosFacade.ProductosFacade"
                ods_CategoriasProductos.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaCategoriasProductos = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarCategorias()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_CategoriasProductos.SelectedIndexChanged
        ModoPaginaCategoriasProductos = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarCategorias()
        hdf_id.Value = grd_CategoriasProductos.SelectedValue
        ObtenerCategorias()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaCategoriasProductos = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Categorias = AsignarCategorias()
            If ModoPaginaCategoriasProductos = EnumModoPagina.Insert Then
                ProductosFacade.GuardarCategorias(Categorias)
                Master.mensajes = "success;Categorias creado con exito"
                OcultarBusqueda()
                ModoPaginaCategoriasProductos = EnumModoPagina.Edit
            Else
                ProductosFacade.ActualizarCategorias(Categorias)
                Master.mensajes = "success;Categorias modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            ProductosFacade.EliminarCategorias(hdf_id.Value)
            Master.mensajes = "success;Categorias eliminado con exito"
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
        ods_CategoriasProductos.SelectParameters.Clear()
        ods_CategoriasProductos.SelectMethod = "ListarCategoriasProductos"
        ods_CategoriasProductos.TypeName = "AndiTecnica.Model.ProductosFacade.ProductosFacade"
        grd_CategoriasProductos.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaCategoriasProductos = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaCategoriasProductos = EnumModoPagina.Insert Or ModoPaginaCategoriasProductos = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerCategorias()
        Dim Categorias = ProductosFacade.ConsultarCategoriasxId(hdf_id.Value)
        txt_nombreCategorias.Text = Categorias.Nombre
        txt_DescripcionCategorias.Text = Categorias.Descripcion
    End Sub

    Public Function AsignarCategorias() As CategoriasProductos
        Dim Categorias As New CategoriasProductos
        Try
            Categorias.CategoriasId = hdf_id.Value
        Catch ex As Exception

        End Try
        If txt_nombreCategorias.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Categorias.Nombre = txt_nombreCategorias.Text
        End If
        Categorias.Descripcion = txt_DescripcionCategorias.Text
        Return Categorias
    End Function

    Public Sub LimpiarCategorias()
        hdf_id.Value = Nothing
        txt_nombreCategorias.Text = Nothing
        txt_DescripcionCategorias.Text = Nothing
        Master.mensajes = Nothing
        txt_nombreCategorias.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("CategoriasProductos")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub

End Class