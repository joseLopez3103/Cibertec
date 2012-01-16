
Imports BusinessEntities
Partial Class admin_core_promotion_new
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Console.Write(">> " + Request.Form(s))
        Next

        Dim be As PromotionBE
        be = New PromotionBE
        be.cod = 100
        be.nombre = Request.Form("name")
        be.estado = Request.Form("state")
        be.data_init = Request.Form("date_init")
        be.data_end = Request.Form("date_end")
        be.description = Request.Form("description")

        Response.Write(be.TO_JSON())

    End Sub

End Class
