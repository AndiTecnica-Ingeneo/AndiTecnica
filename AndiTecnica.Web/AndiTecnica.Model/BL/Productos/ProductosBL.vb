Imports AndiTecnica.Model

Namespace BL.Productos

    Friend Class ProductosBL
        Public Function ListarProductos() As List(Of Model.Productos)
            Try
                Dim dao As New ProductosDao
                Return dao.ListarProductos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarProductos(ByVal Nombre As String) As List(Of Model.Productos)
            Try
                Dim dao As New ProductosDao
                Return dao.BuscarProductos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarProductoxId(ByVal Productoid As Integer) As Model.Productos
            Try
                Dim dao As New ProductosDao
                Return dao.ConsultarProductoxId(Productoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarProducto(ByVal Producto As Model.Productos)
            Try
                Dim dao As New ProductosDao
                Producto.Creado = Date.Now
                Producto.Modificado = Date.Now
                dao.GuardarProducto(Producto)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarProducto(ByVal Producto As Model.Productos)
            Try
                Dim dao As New ProductosDao
                Dim p = ConsultarProductoxId(Producto.ProductoId)
                Producto.Creado = p.Creado
                Producto.Modificado = Date.Now
                dao.ActualizarProducto(Producto)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarProducto(ByVal ProductoId As Integer)
            Try
                Dim dao As New ProductosDao
                Dim Producto = ConsultarProductoxId(ProductoId)
                dao.EliminarProducto(Producto)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
