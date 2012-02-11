Imports System.Diagnostics

Partial Class promotion_promotion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim id As String = Request.QueryString("id")
        Dim cod As Integer = Integer.Parse(Request.QueryString("cod"))

        Debug.WriteLine("cod >> " + cod.ToString)

        If id = "Activo" Then
            ' Response.WriteFile("login.inc")
            Response.Redirect("login.aspx")
        Else
            Dim aux As String = "details.aspx?cod=" + cod.ToString()
            Response.Redirect(aux)
            '  Response.WriteFile("detail_promotion.inc")

            ' lblNombre.Text = cod.ToString

        End If

    End Sub
End Class
