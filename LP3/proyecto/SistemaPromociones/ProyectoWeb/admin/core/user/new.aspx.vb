Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class admin_core_user_new
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
            If capanegocios.InsertUser(be) = True Then

                str_mensaje = "Usuario Registrado "
                Debug.WriteLine(str_mensaje)

                ' Dim script As String = "<script language=Javascript>"
                'script += "alert('" & str_mensaje & "');"
                'script += "</script>"
                ' Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

            Else

                str_mensaje = "No se registró Usuario"
                Debug.WriteLine(str_mensaje)
                'Dim script As String = "<script language=Javascript>"
                'script += "alert('" & str_mensaje & "');"
                'script += "</script>"
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

            End If
        Catch ex As Exception
            str_error = capanegocios.CapturaError

            Debug.WriteLine(str_error)
        End Try



        Response.Write(be.TO_JSON())

    End Sub

End Class
