
Imports AndiTecnica.Model.BL.CategoriasProductos
Imports AndiTecnica.Model.BL.Productos


Namespace ProductosFacade
    Public Class ProductosFacade

#Region "CategoriasProductos"

        Public Function ListarCategoriasProductos() As List(Of CategoriasProductos)
            Try
                Dim bl As New CategoriasProductosBL
                Return bl.ListarCategoriasProductos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarCategoriasProductos(ByVal Nombre As String) As List(Of CategoriasProductos)
            Try
                Dim bl As New CategoriasProductosBL
                Return bl.BuscarCategoriasProductos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarCategoriasxId(ByVal Categoriasid As Integer) As CategoriasProductos
            Try
                Dim bl As New CategoriasProductosBL
                Return bl.ConsultarCategoriasxId(Categoriasid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarCategorias(ByVal Categorias As CategoriasProductos)
            Try
                Dim bl As New CategoriasProductosBL
                bl.GuardarCategorias(Categorias)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarCategorias(ByVal Categorias As CategoriasProductos)
            Try
                Dim bl As New CategoriasProductosBL
                bl.ActualizarCategorias(Categorias)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarCategorias(ByVal CategoriasId As Integer)
            Try
                Dim bl As New CategoriasProductosBL
                bl.EliminarCategorias(CategoriasId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region

#Region "Productos"

        Public Function ListarProductos() As List(Of Productos)
            Try
                Dim bl As New ProductosBL
                Return bl.ListarProductos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarProductos(ByVal Nombre As String) As List(Of Productos)
            Try
                Dim bl As New ProductosBL
                Return bl.BuscarProductos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarProductoxId(ByVal Productoid As Integer) As Productos
            Try
                Dim bl As New ProductosBL
                Return bl.ConsultarProductoxId(Productoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarProducto(ByVal Producto As Productos)
            Try
                Dim bl As New ProductosBL
                bl.GuardarProducto(Producto)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarProducto(ByVal Producto As Productos)
            Try
                Dim bl As New ProductosBL
                bl.ActualizarProducto(Producto)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarProducto(ByVal ProductoId As Integer)
            Try
                Dim bl As New ProductosBL
                bl.EliminarProducto(ProductoId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region





    End Class
End Namespace