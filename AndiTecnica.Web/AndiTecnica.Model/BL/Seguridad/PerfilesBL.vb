Imports AndiTecnica.Model

Namespace BL.Perfiles

    Friend Class PerfilesBL
        Public Function ListarPerfiles() As List(Of Model.Perfiles)
            Try
                Dim dao As New PerfilesDao
                Return dao.ListarPerfiles
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarPerfiles(ByVal Nombre As String) As List(Of Model.Perfiles)
            Try
                Dim dao As New PerfilesDao
                Return dao.BuscarPerfiles(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarPerfilxId(ByVal Perfilid As Integer) As Model.Perfiles
            Try
                Dim dao As New PerfilesDao
                Return dao.ConsultarPerfilxId(Perfilid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarPerfil(ByVal Perfil As Model.Perfiles)
            Try
                Dim dao As New PerfilesDao
                Perfil.Creado = Date.Now
                Perfil.Modificado = Date.Now
                dao.GuardarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarPerfil(ByVal Perfil As Model.Perfiles)
            Try
                Dim dao As New PerfilesDao
                Dim p = ConsultarPerfilxId(Perfil.PerfilId)
                Perfil.Creado = p.Creado
                Perfil.Modificado = Date.Now
                dao.ActualizarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarPerfil(ByVal PerfilId As Integer)
            Try
                Dim dao As New PerfilesDao
                Dim Perfil = ConsultarPerfilxId(PerfilId)
                dao.EliminarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
