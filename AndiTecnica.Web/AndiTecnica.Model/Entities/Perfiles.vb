'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Perfiles
    Public Property PerfilId As Integer
    Public Property Nombre As String
    Public Property Describe As String
    Public Property Creado As Date
    Public Property Modificado As Date
    Public Property Estado As Nullable(Of Integer)

    Public Overridable Property Autorizaciones As ICollection(Of Autorizaciones) = New HashSet(Of Autorizaciones)
    Public Overridable Property Permisos As ICollection(Of Permisos) = New HashSet(Of Permisos)
    Public Overridable Property Usuarios As ICollection(Of Usuarios) = New HashSet(Of Usuarios)
    Public Overridable Property Estados As Estados

End Class
