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

Partial Public Class Empleados
    Public Property EmpleadoId As Integer
    Public Property Cedula As String
    Public Property Nombre As String
    Public Property Telefono As String
    Public Property Extencion As String
    Public Property Movil As String
    Public Property Correo As String
    Public Property Creado As Date
    Public Property Modificado As Date
    Public Property Estado As Nullable(Of Integer)
    Public Property RutaFirma As String

    Public Overridable Property Estados As Estados
    Public Overridable Property Usuarios As ICollection(Of Usuarios) = New HashSet(Of Usuarios)

End Class
