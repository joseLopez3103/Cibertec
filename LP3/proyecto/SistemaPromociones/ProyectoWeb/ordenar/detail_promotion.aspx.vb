
Partial Class promotion_detail_promotion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dim id As String = Request.QueryString("id")
        Dim cod As Integer = Integer.Parse(Request.QueryString("cod"))
        lblNombre.Text = cod.ToString()

    End Sub

End Class
