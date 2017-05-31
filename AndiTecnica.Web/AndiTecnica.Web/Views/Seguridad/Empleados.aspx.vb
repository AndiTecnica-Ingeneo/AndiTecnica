Imports AndiTecnica.Model
Imports AndiTecnica.Model.SeguridadFacade

Public Class Empleados
    Inherits System.Web.UI.Page

    Public Shared prm As List(Of AutorizarBotones_Result)

    Public Enum EnumModoPagina
        Insert
        Edit
    End Enum

    Public Property ModoPaginaEmpleados As EnumModoPagina
        Get
            Return ViewState("ModoPaginaEmpleados")
        End Get
        Set(ByVal value As EnumModoPagina)
            ViewState("ModoPaginaEmpleados") = value
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
                ods_Empleados.SelectParameters.Clear()
                ods_Empleados.SelectMethod = "BuscarEmpleados"
                ods_Empleados.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
                ods_Empleados.SelectParameters.Add("Nombre", txt_bucar.Text)
                Master.mensajes = Nothing
            Catch ex As Exception
                Master.mensajes = "danger;" & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Agregar(sender As Object, e As EventArgs) Handles lkb_agregar.Click
        ModoPaginaEmpleados = EnumModoPagina.Insert
        MostrarFormulario()
        LimpiarEmpleado()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles grd_Empleados.SelectedIndexChanged
        ModoPaginaEmpleados = EnumModoPagina.Edit
        MostrarFormulario()
        LimpiarEmpleado()
        hdf_id.Value = grd_Empleados.SelectedValue
        ObtenerEmpleado()
    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles lkb_guardar.Click
        Try
            Dim Empleado = AsignarEmpleado()
            If ModoPaginaEmpleados = EnumModoPagina.Insert Then
                SeguridadFacade.GuardarEmpleado(Empleado)
                Master.mensajes = "success;Empleado creado con exito"
                OcultarBusqueda()
                ModoPaginaEmpleados = EnumModoPagina.Edit
            Else
                SeguridadFacade.ActualizarEmpleado(Empleado)
                Master.mensajes = "success;Empleado modificado con exito"
            End If
            MostrarLista()
        Catch ex As Exception
            Master.mensajes = "danger;" & ex.Message
        End Try
    End Sub

    Private Sub lkb_editar_Click(sender As Object, e As EventArgs) Handles lkb_editar.Click
        ModoPaginaEmpleados = EnumModoPagina.Insert
        MostrarFormulario()
    End Sub

    Protected Sub Eliminar(sender As Object, e As EventArgs) Handles lkb_eliminar.Click
        Try
            SeguridadFacade.EliminarEmpleado(hdf_id.Value)
            Master.mensajes = "success;Empleado eliminado con exito"
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
        ods_Empleados.SelectParameters.Clear()
        ods_Empleados.SelectMethod = "ListarEmpleados"
        ods_Empleados.TypeName = "AndiTecnica.Model.SeguridadFacade.SeguridadFacade"
        grd_Empleados.DataBind()
    End Sub

    Public Sub MostrarFormulario()
        pnl_form.Visible = True
        pnl_list.Visible = False
        lkb_buscar.Visible = False
        lkb_agregar.Visible = False
        lkb_salir.Visible = True

        If ModoPaginaEmpleados = EnumModoPagina.Edit Then
            txt_nombreEmpleado.Enabled = False
            txt_CedulaEmpleado.Enabled = False
            txt_Telefono.Enabled = False
            txt_Ext.Enabled = False
            txt_Celular.Enabled = False
            txt_Email.Enabled = False
            lkb_eliminar.Visible = True
            lkb_editar.Visible = True
            lkb_guardar.Visible = False

        ElseIf ModoPaginaEmpleados = EnumModoPagina.Insert Then
            txt_nombreEmpleado.Enabled = True
            txt_CedulaEmpleado.Enabled = True
            txt_Telefono.Enabled = True
            txt_Ext.Enabled = True
            txt_Celular.Enabled = True
            txt_Email.Enabled = True
            lkb_guardar.Visible = True
            lkb_editar.Visible = False
        End If

    End Sub

    Public Sub OcultarBusqueda()
        pnl_buscar.Visible = False
        txt_bucar.Text = ""
    End Sub

    Public Sub ObtenerEmpleado()
        Dim Empleado = SeguridadFacade.ConsultarEmpleadoxId(hdf_id.Value)
        txt_nombreEmpleado.Text = Empleado.Nombre
        txt_CedulaEmpleado.Text = Empleado.Cedula
        txt_Telefono.Text = Empleado.Telefono
        txt_Ext.Text = Empleado.Extencion
        txt_Celular.Text = Empleado.Movil
        txt_Email.Text = Empleado.Correo
        'FOTO DIGITAL
    End Sub

    Public Function AsignarEmpleado() As Model.Empleados
        Dim Empleado As New Model.Empleados
        Try
            Empleado.EmpleadoId = hdf_id.Value
        Catch ex As Exception
        End Try

        If txt_nombreEmpleado.Text = "" Then
            Throw New Exception("Por favor ingrese un nombre")
        Else
            Empleado.Nombre = txt_nombreEmpleado.Text
        End If

        If txt_CedulaEmpleado.Text = "" Then
            Throw New Exception("Por favor ingrese la Cedula")
        Else
            Empleado.Cedula = txt_CedulaEmpleado.Text
        End If

        Empleado.Telefono = txt_Telefono.Text
        Empleado.Extencion = txt_Ext.Text
        Empleado.Movil = txt_Celular.Text
        Empleado.Correo = txt_Email.Text
        Dim Modulo = SeguridadFacade.ConsultarModuloxNombre("Seguridad")
        Empleado.Estado = SeguridadFacade.ConsultarEstadoxModulo(Modulo.ModuloId, "Activo").EstadoId
        Return Empleado

    End Function

    Public Sub LimpiarEmpleado()
        hdf_id.Value = Nothing
        txt_nombreEmpleado.Text = Nothing
        txt_CedulaEmpleado.Text = Nothing
        txt_Telefono.Text = Nothing
        txt_Ext.Text = Nothing
        txt_Celular.Text = Nothing
        txt_Email.Text = Nothing
        Master.mensajes = Nothing
        txt_nombreEmpleado.Focus()
    End Sub

    Protected Sub CargarPermisos()
        Dim permisos As New SeguridadFacade
        prm = permisos.AutorizarBotones("Empleados")
        For i As Integer = 0 To prm.Count
            Try
                Me.Master.FindControl("cph_botones").FindControl(prm.Item(i).Nombre).Visible = prm.Item(i).Valor
            Catch ex As Exception
            End Try
        Next
    End Sub

End Class