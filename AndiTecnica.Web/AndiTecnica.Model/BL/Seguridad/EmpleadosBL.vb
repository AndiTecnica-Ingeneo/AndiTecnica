Imports AndiTecnica.Model

Namespace BL.Empleados

    Friend Class EmpleadosBL
        Public Function ListarEmpleados() As List(Of Model.Empleados)
            Try
                Dim dao As New EmpleadosDao
                Return dao.ListarEmpleados
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarEmpleados(ByVal Nombre As String) As List(Of Model.Empleados)
            Try
                Dim dao As New EmpleadosDao
                Return dao.BuscarEmpleados(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarEmpleadoxId(ByVal Empleadoid As Integer) As Model.Empleados
            Try
                Dim dao As New EmpleadosDao
                Return dao.ConsultarEmpleadoxId(Empleadoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarEmpleado(ByVal Empleado As Model.Empleados)
            Try
                Dim dao As New EmpleadosDao
                Empleado.Creado = Date.Now
                Empleado.Modificado = Date.Now
                dao.GuardarEmpleado(Empleado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarEmpleado(ByVal Empleado As Model.Empleados)
            Try
                Dim dao As New EmpleadosDao
                Dim e = ConsultarEmpleadoxId(Empleado.EmpleadoId)
                Empleado.Creado = e.Creado
                Empleado.Modificado = Date.Now
                dao.ActualizarEmpleado(Empleado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarEmpleado(ByVal EmpleadoId As Integer)
            Try
                Dim dao As New EmpleadosDao
                Dim Empleado = ConsultarEmpleadoxId(EmpleadoId)
                dao.EliminarEmpleado(Empleado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
