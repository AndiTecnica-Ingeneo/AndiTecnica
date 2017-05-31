Imports AndiTecnica.Model

Namespace BL.Estados

    Friend Class EstadosBL
        Public Function ListarEstados() As List(Of Model.Estados)
            Try
                Dim dao As New EstadosDao
                Return dao.ListarEstados
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarEstados(ByVal Nombre As String) As List(Of Model.Estados)
            Try
                Dim dao As New EstadosDao
                Return dao.BuscarEstados(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarEstadoxId(ByVal Estadoid As Integer) As Model.Estados
            Try
                Dim dao As New EstadosDao
                Return dao.ConsultarEstadoxId(Estadoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarEstado(ByVal Estado As Model.Estados)
            Try
                Dim dao As New EstadosDao
                dao.GuardarEstado(Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarEstado(ByVal Estado As Model.Estados)
            Try
                Dim dao As New EstadosDao
                dao.ActualizarEstado(Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarEstado(ByVal EstadoId As Integer)
            Try
                Dim dao As New EstadosDao
                Dim Estado = ConsultarEstadoxId(EstadoId)
                dao.EliminarEstado(Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Function ConsultarEstadoxModulo(ByVal Modulo As Integer, ByVal Estado As String) As Model.Estados
            Try
                Dim dao As New EstadosDao
                Return dao.ConsultarEstadoxModulo(Modulo, Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

    End Class
End Namespace
