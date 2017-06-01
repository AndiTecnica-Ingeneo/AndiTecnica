Friend Class ClientesDao
    Public Function ListarClientes() As List(Of Clientes)
        Using bd As New Entities
            Dim query = From tbl In bd.Clientes.Include("Estados")
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function BuscarClientes(ByVal Nombre As String) As List(Of Clientes)
        Using bd As New Entities
            Dim query = From tbl In bd.Clientes.Include("Estados")
                        Where tbl.Nombre.Contains(Nombre)
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function ConsultarClientexId(ByVal Clienteid As Integer) As Clientes
        Using bd As New Entities
            Dim query = From tbl In bd.Clientes.Include("Estados")
                        Where tbl.ClienteId = Clienteid
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function

    Public Sub GuardarCliente(ByVal Cliente As Clientes)
        Using bd As New Entities
            bd.Entry(Cliente).State = EntityState.Added
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub ActualizarCliente(ByVal Cliente As Clientes)
        Using bd As New Entities
            bd.Entry(Cliente).State = EntityState.Modified
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub EliminarCliente(ByVal Cliente As Clientes)
        Using bd As New Entities
            bd.Entry(Cliente).State = EntityState.Deleted
            bd.SaveChanges()
        End Using
    End Sub
End Class
