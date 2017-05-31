Imports AndiTecnica.Model.BL.Usuarios
Imports AndiTecnica.Model.BL.Perfiles
Imports AndiTecnica.Model.BL.Empleados
Imports AndiTecnica.Model.BL.Permisos
Imports AndiTecnica.Model.BL.Estados
Imports AndiTecnica.Model.BL.Modulos

Namespace SeguridadFacade
    Public Class SeguridadFacade


#Region "Login"
        Public Function IniciarSesion(ByVal usuario As String, ByVal clave As String) As Usuarios
            Try
                Dim bl As New UsuariosBL
                Return bl.IniciarSesion(usuario, clave)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
#End Region

#Region "Empleados"

        Public Function ListarEmpleados() As List(Of Empleados)
            Try
                Dim bl As New EmpleadosBL
                Return bl.ListarEmpleados
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarEmpleados(ByVal Nombre As String) As List(Of Empleados)
            Try
                Dim bl As New EmpleadosBL
                Return bl.BuscarEmpleados(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarEmpleadoxId(ByVal Empleadoid As Integer) As Empleados
            Try
                Dim bl As New EmpleadosBL
                Return bl.ConsultarEmpleadoxId(Empleadoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarEmpleado(ByVal Empleado As Empleados)
            Try
                Dim bl As New EmpleadosBL
                bl.GuardarEmpleado(Empleado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarEmpleado(ByVal Empleado As Empleados)
            Try
                Dim bl As New EmpleadosBL
                bl.ActualizarEmpleado(Empleado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarEmpleado(ByVal EmpleadoId As Integer)
            Try
                Dim bl As New EmpleadosBL
                bl.EliminarEmpleado(EmpleadoId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region

#Region "Usuario"
        Public Function ConsultarUsuarioxId(ByVal usuarioid As Integer) As Usuarios
            Try
                Dim bl As New UsuariosBL
                Return bl.ConsultarUsuarioxId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarModulosxUsuarioId(ByVal usuarioid As Integer) As List(Of ConsultarModulosxUsuarioId_Result)
            Try
                Dim bl As New UsuariosBL
                Return bl.ConsultarModulosxUsuarioId(usuarioid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarMenusxUsuarioId(ByVal usuarioid As Integer, ByVal moduloid As Integer) As List(Of ConsultarMenusxUsuarioId_Result)
            Try
                Dim bl As New UsuariosBL
                Return bl.ConsultarMenusxUsuarioId(usuarioid, moduloid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Sub GuardarUsuario(ByVal usuario As Usuarios)
            Try
                Dim bl As New UsuariosBL
                bl.GuardarUsuario(usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub


        Public Sub ActualizarUsuario(ByVal usuario As Usuarios)
            Try
                Dim bl As New UsuariosBL
                bl.ActualizarUsuario(usuario)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarUsuario(ByVal usuarioId As Integer)
            Try
                Dim bl As New UsuariosBL
                bl.EliminarUsuario(usuarioId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Function ListarUsuarios() As List(Of Usuarios)
            Try
                Dim bl As New UsuariosBL
                Return bl.ListarUsuarios
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


#End Region

#Region "Perfiles"

        Public Function ListarPerfiles() As List(Of Perfiles)
            Try
                Dim bl As New PerfilesBL
                Return bl.ListarPerfiles
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarPerfiles(ByVal Nombre As String) As List(Of Perfiles)
            Try
                Dim bl As New PerfilesBL
                Return bl.BuscarPerfiles(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarPerfilxId(ByVal Perfilid As Integer) As Perfiles
            Try
                Dim bl As New PerfilesBL
                Return bl.ConsultarPerfilxId(Perfilid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarPerfil(ByVal Perfil As Perfiles)
            Try
                Dim bl As New PerfilesBL
                bl.GuardarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarPerfil(ByVal Perfil As Perfiles)
            Try
                Dim bl As New PerfilesBL
                bl.ActualizarPerfil(Perfil)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarPerfil(ByVal PerfilId As Integer)
            Try
                Dim bl As New PerfilesBL
                bl.EliminarPerfil(PerfilId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region

#Region "Permisos"

        Public Function AutorizarBotones(ByVal Menu As String) As List(Of AutorizarBotones_Result)
            Dim bl As New PermisosBL
            Return bl.AutorizarBotones(Menu)
        End Function

#End Region

#Region "Estados"
        Public Function ConsultarEstadoxModulo(ByVal Modulo As Integer, ByVal Estado As String) As Estados
            Try
                Dim bl As New EstadosBL
                Return bl.ConsultarEstadoxModulo(Modulo, Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function



        Public Function ListarEstados() As List(Of Estados)
            Try
                Dim bl As New EstadosBL
                Return bl.ListarEstados
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarEstados(ByVal Nombre As String) As List(Of Estados)
            Try
                Dim bl As New EstadosBL
                Return bl.BuscarEstados(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarEstadoxId(ByVal Estadoid As Integer) As Estados
            Try
                Dim bl As New EstadosBL
                Return bl.ConsultarEstadoxId(Estadoid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Sub GuardarEstado(ByVal Estado As Estados)
            Try
                Dim bl As New EstadosBL
                bl.GuardarEstado(Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarEstado(ByVal Estado As Estados)
            Try
                Dim bl As New EstadosBL
                bl.ActualizarEstado(Estado)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarEstado(ByVal EstadoId As Integer)
            Try
                Dim bl As New EstadosBL
                bl.EliminarEstado(EstadoId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub


#End Region

#Region "Modulos"

        Public Function ListarModulos() As List(Of Modulos)
            Try
                Dim bl As New ModulosBL
                Return bl.ListarModulos
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function BuscarModulos(ByVal Nombre As String) As List(Of Modulos)
            Try
                Dim bl As New ModulosBL
                Return bl.BuscarModulos(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function ConsultarModuloxId(ByVal Moduloid As Integer) As Modulos
            Try
                Dim bl As New ModulosBL
                Return bl.ConsultarModuloxId(Moduloid)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Function ConsultarModuloxNombre(ByVal Nombre As String) As Modulos
            Try
                Dim bl As New ModulosBL
                Return bl.ConsultarModuloxNombre(Nombre)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function


        Public Sub GuardarModulo(ByVal Modulo As Modulos)
            Try
                Dim bl As New ModulosBL
                bl.GuardarModulo(Modulo)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub ActualizarModulo(ByVal Modulo As Modulos)
            Try
                Dim bl As New ModulosBL
                bl.ActualizarModulo(Modulo)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub EliminarModulo(ByVal ModuloId As Integer)
            Try
                Dim bl As New ModulosBL
                bl.EliminarModulo(ModuloId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub


#End Region

    End Class
End Namespace