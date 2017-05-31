﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Partial Public Class AndiTecnicaEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=AndiTecnicaEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Property Autorizaciones() As DbSet(Of Autorizaciones)
    Public Property Botones() As DbSet(Of Botones)
    Public Property Empleados() As DbSet(Of Empleados)
    Public Property Estados() As DbSet(Of Estados)
    Public Property Menus() As DbSet(Of Menus)
    Public Property Modulos() As DbSet(Of Modulos)
    Public Property Opciones() As DbSet(Of Opciones)
    Public Property Perfiles() As DbSet(Of Perfiles)
    Public Property Permisos() As DbSet(Of Permisos)
    Public Property Usuarios() As DbSet(Of Usuarios)

    Public Overridable Function ConsultarModulosxUsuarioId(usuarioId As Nullable(Of Integer)) As ObjectResult(Of ConsultarModulosxUsuarioId_Result)
        Dim usuarioIdParameter As ObjectParameter = If(usuarioId.HasValue, New ObjectParameter("UsuarioId", usuarioId), New ObjectParameter("UsuarioId", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ConsultarModulosxUsuarioId_Result)("ConsultarModulosxUsuarioId", usuarioIdParameter)
    End Function

    Public Overridable Function ConsultarMenusxUsuarioId(usuarioId As Nullable(Of Integer)) As ObjectResult(Of ConsultarMenusxUsuarioId_Result)
        Dim usuarioIdParameter As ObjectParameter = If(usuarioId.HasValue, New ObjectParameter("UsuarioId", usuarioId), New ObjectParameter("UsuarioId", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ConsultarMenusxUsuarioId_Result)("ConsultarMenusxUsuarioId", usuarioIdParameter)
    End Function

    Public Overridable Function AutorizarBotones(usuarioId As Nullable(Of Integer), menu As Nullable(Of Integer)) As ObjectResult(Of AutorizarBotones_Result)
        Dim usuarioIdParameter As ObjectParameter = If(usuarioId.HasValue, New ObjectParameter("UsuarioId", usuarioId), New ObjectParameter("UsuarioId", GetType(Integer)))

        Dim menuParameter As ObjectParameter = If(menu.HasValue, New ObjectParameter("Menu", menu), New ObjectParameter("Menu", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of AutorizarBotones_Result)("AutorizarBotones", usuarioIdParameter, menuParameter)
    End Function

End Class
