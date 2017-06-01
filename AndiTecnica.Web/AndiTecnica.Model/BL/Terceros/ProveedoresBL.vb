Imports AndiTecnica.Model

Namespace BL.Proveedores

    Friend Class ProveedoresBL
        Public Function ListarProveedores() As List(Of Model.Proveedores)
            Try
                Dim dao As New ProveedoresDao
                Return dao.ListarProveedores
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarProveedores(ByVal Nombre As String) As List(Of Model.Proveedores)
            Try
                Dim dao As New ProveedoresDao
                Return dao.BuscarProveedores(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarProveedorxId(ByVal Proveedorid As Integer) As Model.Proveedores
            Try
                Dim dao As New ProveedoresDao
                Return dao.ConsultarProveedorxId(Proveedorid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarProveedor(ByVal Proveedor As Model.Proveedores)
            Try
                Dim dao As New ProveedoresDao
                Proveedor.Creado = Date.Now
                Proveedor.Modificado = Date.Now
                dao.GuardarProveedor(Proveedor)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarProveedor(ByVal Proveedor As Model.Proveedores)
            Try
                Dim dao As New ProveedoresDao
                Dim p = ConsultarProveedorxId(Proveedor.ProveedorId)
                Proveedor.Creado = p.Creado
                Proveedor.Modificado = Date.Now
                dao.ActualizarProveedor(Proveedor)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarProveedor(ByVal ProveedorId As Integer)
            Try
                Dim dao As New ProveedoresDao
                Dim Proveedor = ConsultarProveedorxId(ProveedorId)
                dao.EliminarProveedor(Proveedor)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
