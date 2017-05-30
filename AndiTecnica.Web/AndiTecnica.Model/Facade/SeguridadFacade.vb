Imports AndiTecnica.Model.BL

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


    End Class
End Namespace