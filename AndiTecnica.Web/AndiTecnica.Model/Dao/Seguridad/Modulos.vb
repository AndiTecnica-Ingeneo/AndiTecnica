Friend Class ModulosDao
    Public Sub New()

    End Sub

    Public Function ListarModulos() As List(Of Modulos)
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Modulos
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function BuscarModulos(ByVal Nombre As String) As List(Of Modulos)
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Modulos
                        Where tbl.Nombre.Contains(Nombre)
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function ConsultarModuloxId(ByVal Moduloid As Integer) As Modulos
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Modulos
                        Where tbl.ModuloId = Moduloid
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function


    Public Function ConsultarModuloxNombre(ByVal Nombre As String) As Modulos
        Using bd As New AndiTecnicaEntities
            Dim query = From tbl In bd.Modulos
                        Where tbl.Nombre = Nombre
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function


    Public Sub GuardarModulo(ByVal Modulo As Modulos)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Modulo).State = EntityState.Added
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub ActualizarModulo(ByVal Modulo As Modulos)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Modulo).State = EntityState.Modified
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub EliminarModulo(ByVal Modulo As Modulos)
        Using bd As New AndiTecnicaEntities
            bd.Entry(Modulo).State = EntityState.Deleted
            bd.SaveChanges()
        End Using
    End Sub

End Class
