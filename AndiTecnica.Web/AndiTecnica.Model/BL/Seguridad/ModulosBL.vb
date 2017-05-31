Imports AndiTecnica.Model

Namespace BL.Modulos

    Friend Class ModulosBL
        Public Function ListarModulos() As List(Of Model.Modulos)
            Try
                Dim dao As New ModulosDao
                Return dao.ListarModulos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarModulos(ByVal Nombre As String) As List(Of Model.Modulos)
            Try
                Dim dao As New ModulosDao
                Return dao.BuscarModulos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarModuloxId(ByVal Moduloid As Integer) As Model.Modulos
            Try
                Dim dao As New ModulosDao
                Return dao.ConsultarModuloxId(Moduloid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Function ConsultarModuloxNombre(ByVal Nombre As String) As Model.Modulos
            Try
                Dim dao As New ModulosDao
                Return dao.ConsultarModuloxNombre(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Sub GuardarModulo(ByVal Modulo As Model.Modulos)
            Try
                Dim dao As New ModulosDao
                dao.GuardarModulo(Modulo)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarModulo(ByVal Modulo As Model.Modulos)
            Try
                Dim dao As New ModulosDao
                dao.ActualizarModulo(Modulo)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarModulo(ByVal ModuloId As Integer)
            Try
                Dim dao As New ModulosDao
                Dim Modulo = ConsultarModuloxId(ModuloId)
                dao.EliminarModulo(Modulo)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub


    End Class
End Namespace
