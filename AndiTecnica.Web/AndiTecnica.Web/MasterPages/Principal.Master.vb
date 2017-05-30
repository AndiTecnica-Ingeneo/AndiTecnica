
Imports System.Data.SqlClient


Public Class Principal
    Inherits System.Web.UI.MasterPage

    'Dim Facade As New ProgramINFacades

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim menus = Facade.AutorizacionMenu(SessionManager.UserId)

        'If Not Page.IsPostBack Then
        '    If SessionManager.UserId = 0 Then
        '        Dim menusautorizados = String.Concat("<li id='", "li_pacientes", "' class='scroll-link'><a href='", "", "'><strong>", "Pacientes", "</strong></a></li>")
        '        mainNav.InnerHtml = menusautorizados
        '    Else
        '        Dim usuario = Facade.ConsultarUsuarioxId(SessionManager.UserId)
        '        lkb_cerrarsesion.ToolTip = String.Concat("Cerrar sesion de ", usuario.Nombre, " ", usuario.Apellido)

        '        Dim menusautorizados As String = ""
        '        For i As Integer = 0 To menus.Count - 1
        '            menusautorizados = String.Concat(menusautorizados, "<li id='", menus.Item(i).Menus.Nombre, "' class='scroll-link'><a href='", menus.Item(i).Menus.Ruta, "'><strong>", menus.Item(i).Menus.Texto, "</strong></a></li>")
        '        Next
        '        mainNav.InnerHtml = menusautorizados
        '    End If
        'End If



        '<li Class="dropdown">
        '<a href = "#" Class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span Class="caret"></span></a>
        '<ul Class="dropdown-menu">
        '<li> <a href = "#" > Action</a></li>
        '</ul>
        '</li>





        Dim menusautorizados As String = ""

        For i As Integer = 0 To 4 'MODULOS
            menusautorizados = String.Concat(menusautorizados, "<li Class='dropdown'>")
            menusautorizados = String.Concat(menusautorizados, "<a href = '#' Class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>", "Modulo ", i, " <span Class='caret'></span></a> <ul Class='dropdown-menu'> ")
            For j As Integer = 0 To 3 'FORMULARIOS
                menusautorizados = String.Concat(menusautorizados, "<li id='", "Nombre", i, j, "' class='scroll-link'><a href='", "Ruta ", i, "'><strong>", "Formulario ", i, "</strong></a></li>")
            Next
            menusautorizados = String.Concat(menusautorizados, "</ul></li>")
        Next
        mainNav.InnerHtml = menusautorizados


        'Dim nombrepagina = Me.Page.ToString.Split(".")
        'Dim paginactual = nombrepagina(1).Replace("_", ".").ToLower.Trim
        'If paginactual = "hojadevidaform.aspx" Then
        '    paginactual = "hojadevidasview.aspx"
        'End If
        'If paginactual <> "indexview.aspx" Then

        '    If SessionManager.UserId = 0 Then

        '    Else
        '        Dim autorizado = False
        '        For i As Integer = 0 To menus.Count - 1
        '            If paginactual = menus.Item(i).Menus.Ruta.ToLower.Trim Then
        '                autorizado = True
        '                Exit For
        '            End If
        '        Next

        '        If paginactual = "pacientesview.aspx" Then
        '            Dim Usuario = Facade.ConsultarUsuarioxId(SessionManager.UserId)
        '            If Usuario.Administrador = True Then
        '                autorizado = True
        '            End If
        '        End If


        '        If autorizado = False Then
        '            Response.Redirect("IndexView.aspx?a=no", True)
        '        End If
        '    End If
        'End If

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

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles lkb_cerrarsesion.Click
    '    Session.Abandon()
    '    FormsAuthentication.SignOut()
    '    Response.Redirect("login.aspx")
    'End Sub
End Class