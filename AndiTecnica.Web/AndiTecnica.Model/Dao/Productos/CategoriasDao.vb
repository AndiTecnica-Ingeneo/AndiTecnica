Friend Class CategoriasDao
    Public Function ListarCategoriasProductos() As List(Of CategoriasProductos)
        Using bd As New Entities
            Dim query = From tbl In bd.CategoriasProductos.Include("Estados")
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function BuscarCategoriasProductos(ByVal Nombre As String) As List(Of CategoriasProductos)
        Using bd As New Entities
            Dim query = From tbl In bd.CategoriasProductos.Include("Estados")
                        Where tbl.Nombre.Contains(Nombre)
                        Select tbl
            Return query.ToList
        End Using
    End Function

    Public Function ConsultarCategoriasxId(ByVal Categoriasid As Integer) As CategoriasProductos
        Using bd As New Entities
            Dim query = From tbl In bd.CategoriasProductos
                        Where tbl.CategoriasId = Categoriasid
                        Select tbl
            Return query.FirstOrDefault
        End Using
    End Function

    Public Sub GuardarCategorias(ByVal Categorias As CategoriasProductos)
        Using bd As New Entities
            bd.Entry(Categorias).State = EntityState.Added
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub ActualizarCategorias(ByVal Categorias As CategoriasProductos)
        Using bd As New Entities
            bd.Entry(Categorias).State = EntityState.Modified
            bd.SaveChanges()
        End Using
    End Sub

    Public Sub EliminarCategorias(ByVal Categorias As CategoriasProductos)
        Using bd As New Entities
            bd.Entry(Categorias).State = EntityState.Deleted
            bd.SaveChanges()
        End Using
    End Sub
End Class
