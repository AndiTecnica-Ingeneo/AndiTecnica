Imports AndiTecnica.Model.BL.Proveedores
Imports AndiTecnica.Model.BL.Clientes


Namespace TercerosFacade
    Public Class TercerosFacade


#Region "Proveedores"

        Public Function ListarProveedores() As List(Of Proveedores)
            Try
                Dim bl As New ProveedoresBL
                Return bl.ListarProveedores
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarProveedores(ByVal Nombre As String) As List(Of Proveedores)
            Try
                Dim bl As New ProveedoresBL
                Return bl.BuscarProveedores(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarProveedorxId(ByVal Proveedorid As Integer) As Proveedores
            Try
                Dim bl As New ProveedoresBL
                Return bl.ConsultarProveedorxId(Proveedorid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarProveedor(ByVal Proveedor As Proveedores)
            Try
                Dim bl As New ProveedoresBL
                bl.GuardarProveedor(Proveedor)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarProveedor(ByVal Proveedor As Proveedores)
            Try
                Dim bl As New ProveedoresBL
                bl.ActualizarProveedor(Proveedor)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarProveedor(ByVal ProveedorId As Integer)
            Try
                Dim bl As New ProveedoresBL
                bl.EliminarProveedor(ProveedorId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region


#Region "Clientes"

        Public Function ListarClientes() As List(Of Clientes)
            Try
                Dim bl As New ClientesBL
                Return bl.ListarClientes
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarClientes(ByVal Nombre As String) As List(Of Clientes)
            Try
                Dim bl As New ClientesBL
                Return bl.BuscarClientes(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarClientexId(ByVal Clienteid As Integer) As Clientes
            Try
                Dim bl As New ClientesBL
                Return bl.ConsultarClientexId(Clienteid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarCliente(ByVal Cliente As Clientes)
            Try
                Dim bl As New ClientesBL
                bl.GuardarCliente(Cliente)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarCliente(ByVal Cliente As Clientes)
            Try
                Dim bl As New ClientesBL
                bl.ActualizarCliente(Cliente)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarCliente(ByVal ClienteId As Integer)
            Try
                Dim bl As New ClientesBL
                bl.EliminarCliente(ClienteId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region


    End Class
End Namespace