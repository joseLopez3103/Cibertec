
Partial Class Errorres
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmensaje.Text = "Se generó el error: " + Request.QueryString("parametro")
    End Sub
End Class
