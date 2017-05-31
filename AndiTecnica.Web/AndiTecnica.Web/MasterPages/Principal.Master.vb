
Imports System.Data.SqlClient
Imports AndiTecnica.Model.SeguridadFacade
Imports AndiTecnica.Model.Session

Public Class Principal
    Inherits System.Web.UI.MasterPage

    Dim Facade As New SeguridadFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim modulos = Facade.ConsultarModulosxUsuarioId(SessionManager.UserId)
        Dim menus = Facade.ConsultarMenusxUsuarioId(SessionManager.UserId)

        If Not Page.IsPostBack Then
            If SessionManager.UserId = 0 Then
                Response.Redirect("Login.aspx", True)
            Else
                Dim usuario = Facade.ConsultarUsuarioxId(SessionManager.UserId)
                Dim menusautorizados As String = ""
                lkb_cerrarsesion.ToolTip = String.Concat("Cerrar sesion de ", usuario.Empleados.Nombre)

                For i As Integer = 0 To modulos.Count - 1 'MODULOS
                    menusautorizados = String.Concat(menusautorizados, "<li Class='dropdown'>")
                    menusautorizados = String.Concat(menusautorizados, "<a href = '#' Class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>", modulos.Item(i).Nombre, " <span Class='caret'></span></a> <ul Class='dropdown-menu'> ")
                    For j As Integer = 0 To menus.Count - 1 'FORMULARIOS
                        menusautorizados = String.Concat(menusautorizados, "<li id='", "Nombre", i, j, "' class='scroll-link'><a href='/", menus.Item(j).Ruta, "'><strong>", menus.Item(j).Nombre, "</strong></a></li>")
                    Next
                    menusautorizados = String.Concat(menusautorizados, "</ul></li>")
                Next
                mainNav.InnerHtml = menusautorizados
            End If
        End If

        Dim nombrepagina = Me.Page.ToString.Split(".")
        Dim paginactual = nombrepagina(1).Replace("_", ".").ToLower.Trim
        If paginactual <> "index.aspx" Then
            If SessionManager.UserId = 0 Then
                Response.Redirect("Login.aspx", True)
            Else
                Dim autorizado = False
                For i As Integer = 0 To menus.Count - 1
                    If (paginactual) = (menus.Item(i).Ruta).Replace("/", ".").ToLower.Trim Then
                        autorizado = True
                        Exit For
                    End If
                Next

                If autorizado = False Then
                    Response.Redirect("Index.aspx", True)
                End If
            End If
        End If

    End Sub

    Public WriteOnly Property mensajes() As String
        Set(value As String)
            If Not value Is Nothing Then
                Dim valor = value.Split(";")
                Dim tipo = valor(0)
                Dim texto = valor(1)
                Dim titulo As String = ""
                If tipo = "success" Then
                    titulo = "Listo ! "
                ElseIf tipo = "warning" Then
                    titulo = "Advertencia ! "
                ElseIf tipo = "danger" Then
                    titulo = "Error ! "
                End If
                div_mensajes.InnerHtml = String.Concat("<div class='alert alert-", tipo, " text-center' role='alert'></button><strong>", titulo, "</strong>", texto, " </div>")
            Else
                div_mensajes.InnerHtml = ""
            End If
        End Set
    End Property

    Public Property AjaxManager() As ScriptManager
        Get
            Return ScriptManager1
        End Get
        Set(ByVal value As ScriptManager)

        End Set
    End Property

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles lkb_cerrarsesion.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx")
    End Sub
End Class