Imports DataAccessLayer
Imports BE = BusinessEntities

Public Class AccessBL

    Dim user As New AccessDAO


    Public Function ValidateUser(ByVal objeto As BE.AccessBE) As Boolean

        Return user.validateUser(objeto)

    End Function

    Public Function CapturaError() As String

        Return user.CapturaError

    End Function


End Class
