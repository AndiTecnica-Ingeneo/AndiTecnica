
Imports AndiTecnica.Model.BL.CategoriasProductos


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








    End Class
End Namespace