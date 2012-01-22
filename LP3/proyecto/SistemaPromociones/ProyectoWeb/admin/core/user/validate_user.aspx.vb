Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class admin_core_user_validate_user
    Inherits System.Web.UI.Page


    Dim str_error As String
    Dim str_mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Debug.WriteLine(">> " + s + " " + Request.Form(s))
        Next

        Dim capanegocios As New UserBL
        Dim be As UserBE
        be = New UserBE
        'be.cod = 100
        be.name_user = Request.Form("name_user")
        be.id_facebook = Request.Form("id_facebook")
        be.email = Request.Form("email")
        be.sexo = Request.Form("sexo")

        Try
            capanegocios.ValidateUser(be)
            Debug.WriteLine("validate user ")

        Catch ex As Exception
            str_error = capanegocios.CapturaError

            Debug.WriteLine(str_error)
        End Try



        Response.Write(be.TO_JSON())

    End Sub

End Class
