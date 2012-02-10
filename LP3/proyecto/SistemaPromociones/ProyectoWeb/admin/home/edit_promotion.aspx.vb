
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class promotion_edit_promotion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Debug.WriteLine("edit promotion >> " + s + " " + Request.Form(s))
        Next

        Dim cod As String = Page.Request.QueryString.Get("cod")

        Debug.WriteLine("edit promotion >> " + cod)


    End Sub

End Class
