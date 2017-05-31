
Imports AndiTecnica.Model.Dao

Namespace BL.Usuarios

    Friend Class UsuariosBL

        Public Function ListarUsuarios() As List(Of Model.Usuarios)
            Try
                Dim dao As New UsuariosDao
                Return dao.ListarUsuarios
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarUsuarioxId(ByVal usuarioid As Integer) As Model.Usuarios
            Try
                Dim dao As New UsuariosDao
                Return dao.ConsultarUsuarioxId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarUsuario(ByVal usuario As Model.Usuarios)
            Try
                Dim dao As New UsuariosDao
                dao.GuardarUsuario(usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarUsuario(ByVal usuario As Model.Usuarios)
            Try
                Dim dao As New UsuariosDao
                dao.ActualizarUsuario(usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarUsuario(ByVal usuarioId As Integer)
            Try
                Dim dao As New UsuariosDao
                Dim usuario = ConsultarUsuarioxId(usuarioId)
                dao.EliminarUsuario(usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Function IniciarSesion(ByVal usuario As String, ByVal clave As String) As Model.Usuarios
            Try
                Dim dao As New UsuariosDao
                Return dao.IniciarSesion(usuario, clave)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Function ConsultarModulosxUsuarioId(ByVal usuarioid As Integer) As List(Of ConsultarModulosxUsuarioId_Result)
            Try
                Dim dao As New UsuariosDao
                Return dao.ConsultarModulosxUsuarioId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarMenusxUsuarioId(ByVal usuarioid As Integer) As List(Of ConsultarMenusxUsuarioId_Result)
            Try
                Dim dao As New UsuariosDao
                Return dao.ConsultarMenusxUsuarioId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

    End Class

End Namespace

