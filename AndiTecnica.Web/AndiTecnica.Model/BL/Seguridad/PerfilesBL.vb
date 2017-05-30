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
                dao.GuardarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarPerfil(ByVal Perfil As Model.Perfiles)
            Try
                Dim dao As New PerfilesDao
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
