Imports AndiTecnica.Model
Imports AndiTecnica.Model.ProductosFacade
Imports AndiTecnica.Model.SeguridadFacade

Public Class Productos
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
        Update
    End Enum

    Public Property ModoPaginaProductos As EnumModoPagina
        Get
            Return ViewState("ModoPaginaProductos")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaProductos") = value
        End Set
    End Property

    Dim ProductosFacade As New ProductosFacade
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
                ods_Productos.SelectParameters.Clear()
                ods_Productos.SelectMethod = "BuscarProductos"
                ods_Productos.TypeName = "AndiTecnica.Model.ProductosFacade.ProductosFacade"
                ods_Productos.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaProductos = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarProducto()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Productos.SelectedIndexChanged
        ModoPaginaProductos = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarProducto()
        hdf_id.Value = grd_Productos.SelectedValue
        ObtenerProducto()
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaProductos = EnumModoPagina.Update
        MostrarFormulario()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Producto = AsignarProducto()
            If ModoPaginaProductos = EnumModoPagina.Insert Then
                ProductosFacade.GuardarProducto(Producto)
                Master.mensajes = "success;Producto creado con exito"
                OcultarBusqueda()
                ModoPaginaProductos = EnumModoPagina.Edit
            Else
                ProductosFacade.ActualizarProducto(Producto)
                Master.mensajes = "success;Producto modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            ProductosFacade.EliminarProducto(hdf_id.Value)
            Master.mensajes = "success;Producto eliminado con exito"
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
        ods_Productos.SelectParameters.Clear()
        ods_Productos.SelectMethod = "ListarProductos"
        ods_Productos.TypeName = "AndiTecnica.Model.ProductosFacade.ProductosFacade"
        grd_Productos.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaProductos = EnumModoPagina.Edit Then
            pnl_form.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False
        ElseIf ModoPaginaProductos = EnumModoPagina.Insert Or ModoPaginaProductos = EnumModoPagina.Update Then
            pnl_form.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerProducto()
        Dim Producto = ProductosFacade.ConsultarProductoxId(hdf_id.Value)
        txt_nombreProducto.Text = Producto.Nombre
        txt_Codigo.Text = Producto.Descripcion
        cbx_Categorias.SelectedValue = Producto.CategoriaFk
        cbx_Categorias.Text = Producto.CategoriasProductos.Nombre

        If Producto.Costo IsNot Nothing Then
            txt_costo.Text = FormatNumber(Producto.Costo, 0)
        End If

        If Producto.Descripcion IsNot Nothing Then
            txt_DescripcionProducto.Text = Producto.Descripcion
        End If

        If Producto.Stock IsNot Nothing Then
            txt_Stock.Text = Producto.Stock
        End If

    End Sub

    Public Function AsignarProducto() As Model.Productos
        Dim Producto As New Model.Productos
        Try
            Producto.ProductoId = hdf_id.Value
        Catch ex As Exception
        End Try

        If txt_nombreProducto.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Producto.Nombre = txt_nombreProducto.Text
        End If

        If txt_Codigo.Text = "" Then
            Throw New Exception("Por favor ingrese el Codigo")
        Else
            Producto.Codigo = txt_Codigo.Text
        End If

        If cbx_Categorias.SelectedValue = Nothing Then
            Throw New Exception("Por favor Seleccione una Categoria")
        Else
            Producto.CategoriaFk = cbx_Categorias.SelectedValue
        End If

        Producto.Costo = txt_costo.Text
        Producto.Descripcion = txt_Codigo.Text
        Producto.Stock = txt_Stock.Text

        Dim Modulo = SeguridadFacade.ConsultarModuloxNombre("Productos")
        Producto.Estado = SeguridadFacade.ConsultarEstadoxModulo(Modulo.ModuloId, "Activo").EstadoId

        Return Producto
    End Function

    Public Sub LimpiarProducto()
        hdf_id.Value = Nothing
        txt_nombreProducto.Text = Nothing
        txt_Codigo.Text = Nothing
        cbx_Categorias.SelectedValue = Nothing
        cbx_Categorias.Text = Nothing
        txt_costo.Text = Nothing
        txt_DescripcionProducto.Text = Nothing
        txt_Stock.Text = Nothing
        Master.mensajes = Nothing
        txt_nombreProducto.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("Productos")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub

End Class