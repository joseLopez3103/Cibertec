
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class admin_core_admin_validate_admin
    Inherits System.Web.UI.Page

    Dim str_error As String
    Dim str_mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            ' Debug.WriteLine(">> " + s + " " + Request.Form(s))
        Next

        Dim capanegocios As New AccessBL
        Dim be As AccessBE
        be = New AccessBE
        'be.cod = 100
        be.name_user = Request.Form("usuario")
        be.password_user = Request.Form("password")

        Dim aux As AccessBE = New AccessBE

        Try
            If capanegocios.ValidateUser(be) = True Then
                Debug.WriteLine("validate admin ")
                aux = be

            Else
                Debug.WriteLine("error  admin ")
                aux.cod = -1

            End If
        Catch ex As Exception
            str_error = capanegocios.CapturaError

            Debug.WriteLine(str_error)
        End Try

        Response.Write(aux.TO_JSON())

    End Sub

End Class
