
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

        'Public Sub GuardarUsuario(ByVal usuario As Usuarios, ByVal menuseleccionados As List(Of Menu))
        '    Try
        '        Dim dao As New UsuariosDao
        '        Dim menusbl As New MenusBL
        '        Dim menuxUsuarioBl As New MenusxUsuarioBL
        '        dao.GuardarUsuario(usuario)
        '        For i As Integer = 0 To menuseleccionados.Count - 1
        '            Dim men = menusbl.ConsultarMenuxNombre(menuseleccionados.Item(i).Nombre.ToString)
        '            Dim menuxusuario As New MenusxUsuario
        '            menuxusuario.UsuarioFk = usuario.UsuarioId
        '            menuxusuario.MenuFk = men.MenuId
        '            menuxusuario.Valor = menuseleccionados.Item(i).Valor
        '            menuxUsuarioBl.GuardarMenuxUsuario(menuxusuario)
        '        Next
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Sub

        'Public Sub ActualizarUsuario(ByVal usuario As Usuarios, ByVal menuseleccionados As List(Of Menu))
        '    Try
        '        Dim dao As New UsuariosDao
        '        Dim menusbl As New MenusBL
        '        Dim menuxUsuarioBl As New MenusxUsuarioBL
        '        dao.ActualizarUsuario(usuario)

        '        Dim menusxusuario = menuxUsuarioBl.ListarMenusxUsuarioXUsuarioId(usuario.UsuarioId)
        '        For i As Integer = 0 To menusxusuario.Count - 1
        '            menuxUsuarioBl.EliminarMenuxUsuario(menusxusuario.Item(i).MenuxUsuarioId)
        '        Next

        '        For i As Integer = 0 To menuseleccionados.Count - 1
        '            Dim men = menusbl.ConsultarMenuxNombre(menuseleccionados.Item(i).Nombre.ToString)
        '            Dim menuxusuario As New MenusxUsuario
        '            menuxusuario.UsuarioFk = usuario.UsuarioId
        '            menuxusuario.MenuFk = men.MenuId
        '            menuxusuario.Valor = menuseleccionados.Item(i).Valor
        '            menuxUsuarioBl.GuardarMenuxUsuario(menuxusuario)
        '        Next

        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Sub

        'Public Sub EliminarUsuario(ByVal usuarioId As Integer)
        '    Try
        '        Dim dao As New UsuariosDao
        '        Dim menuxUsuarioBl As New MenusxUsuarioBL
        '        Dim usuario = ConsultarUsuarioxId(usuarioId)
        '        Dim menusxusuario = menuxUsuarioBl.ListarMenusxUsuarioXUsuarioId(usuario.UsuarioId)
        '        For i As Integer = 0 To menusxusuario.Count - 1
        '            menuxUsuarioBl.EliminarMenuxUsuario(menusxusuario.Item(i).MenuxUsuarioId)
        '        Next
        '        dao.EliminarUsuario(usuario)
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Sub

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

