Imports AndiTecnica.Model

Namespace BL.CategoriasProductos

    Friend Class CategoriasProductosBL
        Public Function ListarCategoriasProductos() As List(Of Model.CategoriasProductos)
            Try
                Dim dao As New CategoriasDao
                Return dao.ListarCategoriasProductos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarCategoriasProductos(ByVal Nombre As String) As List(Of Model.CategoriasProductos)
            Try
                Dim dao As New CategoriasDao
                Return dao.BuscarCategoriasProductos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarCategoriasxId(ByVal Categoriasid As Integer) As Model.CategoriasProductos
            Try
                Dim dao As New CategoriasDao
                Return dao.ConsultarCategoriasxId(Categoriasid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarCategorias(ByVal Categorias As Model.CategoriasProductos)
            Try
                Dim dao As New CategoriasDao
                Categorias.Creado = Date.Now
                Categorias.Modificado = Date.Now
                dao.GuardarCategorias(Categorias)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarCategorias(ByVal Categorias As Model.CategoriasProductos)
            Try
                Dim dao As New CategoriasDao
                Dim p = ConsultarCategoriasxId(Categorias.CategoriasId)
                Categorias.Creado = p.Creado
                Categorias.Modificado = Date.Now
                dao.ActualizarCategorias(Categorias)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarCategorias(ByVal CategoriasId As Integer)
            Try
                Dim dao As New CategoriasDao
                Dim Categorias = ConsultarCategoriasxId(CategoriasId)
                dao.EliminarCategorias(Categorias)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
