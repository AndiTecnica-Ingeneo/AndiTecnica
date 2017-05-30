Imports AndiTecnica.Model.BL.Usuarios
Imports AndiTecnica.Model.BL.Perfiles

Namespace SeguridadFacade
    Public Class SeguridadFacade


#Region "Login"
        Public Function IniciarSesion(ByVal usuario As String, ByVal clave As String) As Usuarios
            Try
                Dim bl As New UsuariosBL
                Return bl.IniciarSesion(usuario, clave)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
#End Region

#Region "Usuario"
        Public Function ConsultarUsuarioxId(ByVal usuarioid As Integer) As Usuarios
            Try
                Dim bl As New UsuariosBL
                Return bl.ConsultarUsuarioxId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
#End Region




#Region "Perfiles"

        Public Function ListarPerfiles() As List(Of Perfiles)
            Try
                Dim bl As New PerfilesBL
                Return bl.ListarPerfiles
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarPerfiles(ByVal Nombre As String) As List(Of Perfiles)
            Try
                Dim bl As New PerfilesBL
                Return bl.BuscarPerfiles(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarPerfilxId(ByVal Perfilid As Integer) As Perfiles
            Try
                Dim bl As New PerfilesBL
                Return bl.ConsultarPerfilxId(Perfilid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarPerfil(ByVal Perfil As Perfiles)
            Try
                Dim bl As New PerfilesBL
                Perfil.Creado = Date.Now
                Perfil.Modificado = Date.Now
                bl.GuardarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarPerfil(ByVal Perfil As Perfiles)
            Try
                Dim bl As New PerfilesBL
                bl.ActualizarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarPerfil(ByVal PerfilId As Integer)
            Try
                Dim bl As New PerfilesBL
                bl.EliminarPerfil(PerfilId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region



    End Class
End Namespace