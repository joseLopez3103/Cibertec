Imports DataAccessLayer
Imports BE = BusinessEntities

Public Class UserBL

    Dim user As New UserDAO

    Public Function InsertUser(ByVal objeto As BE.UserBE) As Boolean

        Return user.InsertUser(objeto)

    End Function

    Public Function ValidateUser(ByVal objeto As BE.UserBE) As Boolean

        Return user.validateUser(objeto)

    End Function

    Public Function CapturaError() As String

        Return user.CapturaError

    End Function

    Public Function ListPromotion() As DataSet

        Return user.ListUser()
    End Function

End Class
