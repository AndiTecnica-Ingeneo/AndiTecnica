

Imports AndiTecnica.Model.Session

Namespace Dao.Permisos

    Friend Class PermisosDao

        Public Function AutorizarBotones(ByVal Menu As String) As List(Of AutorizarBotones_Result)
            Using bd As New AndiTecnicaEntities
                Dim sp = From tbl In bd.AutorizarBotones(SessionManager.UserId, Menu)
                         Select tbl
                Return sp.ToList()
            End Using
        End Function


    End Class
End Namespace
