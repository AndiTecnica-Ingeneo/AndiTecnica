Friend Class EstadosDao
    Public Function ListarEstados() As List(Of Estados)
        Using bd As New Entities
            Dim query = From tbl In bd.Estados
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function BuscarEstados(ByVal Nombre As String) As List(Of Estados)
        Using bd As New Entities
            Dim query = From tbl In bd.Estados
                        Where tbl.Nombre.Contains(Nombre)
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function ConsultarEstadoxId(ByVal Estadoid As Integer) As Estados
        Using bd As New Entities
            Dim query = From tbl In bd.Estados
                        Where tbl.EstadoId = Estadoid
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function

    Public Sub GuardarEstado(ByVal Estado As Estados)
        Using bd As New Entities
            bd.Entry(Estado).State = EntityState.Added
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub ActualizarEstado(ByVal Estado As Estados)
        Using bd As New Entities
            bd.Entry(Estado).State = EntityState.Modified
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub EliminarEstado(ByVal Estado As Estados)
        Using bd As New Entities
            bd.Entry(Estado).State = EntityState.Deleted
            bd.SaveChanges()
        End Using
    End Sub


    Public Function ConsultarEstadoxModulo(ByVal Modulo As Integer, ByVal Estado As String) As Estados
        Using bd As New Entities
            Dim query = From tbl In bd.Estados
                        Where tbl.ModuloFk = Modulo And tbl.Nombre.Contains(Estado)
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function



End Class
