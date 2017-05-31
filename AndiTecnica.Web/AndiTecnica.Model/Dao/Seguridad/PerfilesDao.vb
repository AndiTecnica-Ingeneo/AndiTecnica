Friend Class PerfilesDao
    Public Function ListarPerfiles() As List(Of Perfiles)
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Perfiles.Include("Estados")
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function BuscarPerfiles(ByVal Nombre As String) As List(Of Perfiles)
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Perfiles
                        Where tbl.Nombre.Contains(Nombre)
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function ConsultarPerfilxId(ByVal Perfilid As Integer) As Perfiles
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Perfiles
                        Where tbl.PerfilId = Perfilid
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function

    Public Sub GuardarPerfil(ByVal Perfil As Perfiles)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Perfil).State = EntityState.Added
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub ActualizarPerfil(ByVal Perfil As Perfiles)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Perfil).State = EntityState.Modified
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub EliminarPerfil(ByVal Perfil As Perfiles)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Perfil).State = EntityState.Deleted
            bd.SaveChanges()
        End Using
    End Sub
End Class
