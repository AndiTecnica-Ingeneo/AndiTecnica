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

Partial Public Class Productos
    Public Property ProductoId As Integer
    Public Property Nombre As String
    Public Property Codigo As String
    Public Property Descripcion As String
    Public Property Costo As Nullable(Of Decimal)
    Public Property Stock As Nullable(Of Integer)
    Public Property CategoriaFk As Integer
    Public Property RutaFoto As String
    Public Property Estado As Nullable(Of Integer)
    Public Property Creado As Nullable(Of Date)
    Public Property Modificado As Nullable(Of Date)

    Public Overridable Property CategoriasProductos As CategoriasProductos
    Public Overridable Property Estados As Estados

End Class