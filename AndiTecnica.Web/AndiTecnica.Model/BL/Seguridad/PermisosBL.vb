
Imports AndiTecnica.Model.Dao.Permisos

Namespace BL.Permisos
    Friend Class PermisosBL

        Public Function AutorizarBotones(ByVal Menu As String) As List(Of AutorizarBotones_Result)
            Dim dao As New PermisosDao
            Return dao.AutorizarBotones(Menu)
        End Function


    End Class
End Namespace