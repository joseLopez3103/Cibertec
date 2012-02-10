Imports DataAccessLayer
Imports BE = BusinessEntities

Public Class PromotionBL

    Dim promotion As New PromotionDAO

    'Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Boolean
    Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Integer

        Return promotion.InsertPromotion(objeto)

    End Function

    Public Function CapturaError() As String

        Return promotion.CapturaError

    End Function

    Public Function ListPromotion() As DataSet

        Return promotion.ListPromotion
    End Function

End Class
