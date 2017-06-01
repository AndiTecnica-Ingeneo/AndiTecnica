Namespace Dao

  Friend Class UsuariosDao

    Public Function ListarUsuarios() As List(Of Usuarios)
            Using bd As New Entities
                Dim query = From tbl In bd.Usuarios.Include("Empleados").Include("Perfiles").Include("Estados")
                            Select tbl
                Return query.ToList
            End Using
        End Function

        Public Function ConsultarUsuarioxId(ByVal usuarioid As Integer) As Usuarios
            Using bd As New Entities
                Dim query = From tbl In bd.Usuarios.Include("Empleados").Include("Perfiles").Include("Estados")
                            Where tbl.UsuarioId = usuarioid
                            Select tbl
                Return query.FirstOrDefault
            End Using
        End Function

        Public Sub GuardarUsuario(ByVal usuario As Usuarios)
            Using bd As New Entities
                bd.Entry(usuario).State = EntityState.Added
                bd.SaveChanges()
            End Using
        End Sub

        Public Sub ActualizarUsuario(ByVal usuario As Usuarios)
            Using bd As New Entities
                bd.Entry(usuario).State = EntityState.Modified
                bd.SaveChanges()
            End Using
        End Sub

        Public Sub EliminarUsuario(ByVal usuario As Usuarios)
            Using bd As New Entities
                bd.Entry(usuario).State = EntityState.Deleted
                bd.SaveChanges()
            End Using
        End Sub

        Public Function IniciarSesion(ByVal usuario As String, ByVal clave As String) As Usuarios
            Using bd As New Entities
                Dim query = From tbl In bd.Usuarios
                            Where tbl.Usuario = usuario And tbl.Clave = clave
                            Select tbl
                Return query.FirstOrDefault
            End Using
        End Function


        Public Function ConsultarModulosxUsuarioId(ByVal usuarioid As Integer) As List(Of ConsultarModulosxUsuarioId_Result)
            Using bd As New Entities
                Dim query = From tbl In bd.ConsultarModulosxUsuarioId(usuarioid)
                            Select tbl
                Return query.ToList()
            End Using
        End Function

        Public Function ConsultarMenusxUsuarioId(ByVal usuarioid As Integer, ByVal moduloid As Integer) As List(Of ConsultarMenusxUsuarioId_Result)
            Using bd As New Entities
                Dim query = From tbl In bd.ConsultarMenusxUsuarioId(usuarioid, moduloid)
                            Select tbl
                Return query.ToList()
            End Using
        End Function

    End Class

End Namespace
