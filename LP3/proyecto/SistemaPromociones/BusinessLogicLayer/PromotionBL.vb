Imports DataAccessLayer
Imports BE = BusinessEntities

Public Class PromotionBL

    Dim promotion As New PromotionDAO

    'Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Boolean
    Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Integer

        Return promotion.InsertPromotion(objeto)

    End Function

    Public Function saveUrlPromotion(ByVal url As String, ByVal file As String, ByVal cod As Integer) As Boolean

        Return promotion.saveUrlPromotion(url, file, cod)

    End Function

    Public Function getPromotionbyCod(ByVal be As BE.PromotionBE) As BE.PromotionBE

        Return promotion.GetPromotionByCod(be)

    End Function

    Public Function CapturaError() As String

        Return promotion.CapturaError

    End Function

    Public Function ListPromotion() As DataSet

        Return promotion.ListPromotion
    End Function

End Class
