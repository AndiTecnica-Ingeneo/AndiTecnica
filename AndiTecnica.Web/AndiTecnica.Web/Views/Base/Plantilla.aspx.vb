Public Class Plantilla
    Inherits System.Web.UI.Page

    Public Enum EnumModoPagina
        Insert
        Edit
    End Enum

    Public Property ModoPaginaPlantillas As EnumModoPagina
        Get
            Return ViewState("ModoPaginaPlantillas")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaPlantillas") = value
        End Set
    End Property

    Dim PlantillaFacade As New Facades

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MostrarLista()
            pnl_buscar.Visible = False
        End If
    End Sub

    Protected Sub Buscar(sender As Object, e As EventArgs) Handles lkb_buscar.Click
        pnl_buscar.Visible = True
        Master.mensajes = Nothing
    End Sub

    Protected Sub Filtrar(sender As Object, e As EventArgs) Handles btn_filtrar.ServerClick
        If ddl_buscar.SelectedValue = 0 Then
            Master.mensajes = "warning;Por favor seleccione el campo a buscar"
        ElseIf txt_bucar.Text = "" Then
            Master.mensajes = "warning;Por favor ingrese la informacion a buscar"
        Else
            Try
                sds_Plantillas.SelectParameters.Clear()
                sds_Plantillas.SelectParameters.Add("campo", ddl_buscar.SelectedValue)
                sds_Plantillas.SelectParameters.Add("texto", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaPlantillas = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarPlantilla()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Plantillas.SelectedIndexChanged
        ModoPaginaPlantillas = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarPlantilla()
        hdf_id.Value = grd_Plantillas.SelectedValue
        ObtenerPlantilla()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Plantilla = AsignarPlantilla()
            If ModoPaginaPlantillas = EnumModoPagina.Insert Then
                PlantillaFacade.GuardarPlantilla(Plantilla)
                Master.mensajes = "success;Plantilla creada con exito"
                OcultarBusqueda()
                ModoPaginaPlantillas = EnumModoPagina.Edit
            Else
                PlantillaFacade.ActualizarPlantilla(Plantilla)
                Master.mensajes = "success;Plantilla modificada con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            PlantillaFacade.EliminarPlantilla(hdf_id.Value)
            Master.mensajes = "success;Plantilla eliminada con exito"
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
        lkb_eliminar.Visible = False
        lkb_salir.Visible = False
        grd_Plantillas.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_guardar.Visible = True
        lkb_eliminar.Visible = True
        lkb_salir.Visible = True
    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        ddl_buscar.SelectedValue = 0
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerPlantilla()
        Dim Plantilla = PlantillaFacade.ConsultarPlantillaxId(hdf_id.Value)
        txt_nombres.Text = Plantilla.Nombre
        txt_codigo.Text = Plantilla.Codigo
    End Sub

    Public Function AsignarPlantilla() As Plantillas
        Dim Plantilla As New Plantillas
        Try
            Plantilla.PlantillaId = hdf_id.Value
        Catch ex As Exception

        End Try
        If txt_nombres.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Plantilla.Nombre = txt_nombres.Text
        End If
        Plantilla.Codigo = txt_codigo.Text
        Return Plantilla
    End Function

    Public Sub LimpiarPlantilla()
        hdf_id.Value = Nothing
        txt_nombres.Text = Nothing
        txt_codigo.Text = Nothing
        Master.mensajes = Nothing
        txt_nombres.Focus()
    End Sub

End Class