Imports AndiTecnica.Model.BL.Proveedores


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


    End Class
End Namespace