Imports AndiTecnica.Model

Namespace BL.Clientes

    Friend Class ClientesBL
        Public Function ListarClientes() As List(Of Model.Clientes)
            Try
                Dim dao As New ClientesDao
                Return dao.ListarClientes
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarClientes(ByVal Nombre As String) As List(Of Model.Clientes)
            Try
                Dim dao As New ClientesDao
                Return dao.BuscarClientes(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarClientexId(ByVal Clienteid As Integer) As Model.Clientes
            Try
                Dim dao As New ClientesDao
                Return dao.ConsultarClientexId(Clienteid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarCliente(ByVal Cliente As Model.Clientes)
            Try
                Dim dao As New ClientesDao
                Cliente.Creado = Date.Now
                Cliente.Modificado = Date.Now
                dao.GuardarCliente(Cliente)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarCliente(ByVal Cliente As Model.Clientes)
            Try
                Dim dao As New ClientesDao
                Dim p = ConsultarClientexId(Cliente.ClienteId)
                Cliente.Creado = p.Creado
                Cliente.Modificado = Date.Now
                dao.ActualizarCliente(Cliente)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarCliente(ByVal ClienteId As Integer)
            Try
                Dim dao As New ClientesDao
                Dim Cliente = ConsultarClientexId(ClienteId)
                dao.EliminarCliente(Cliente)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
