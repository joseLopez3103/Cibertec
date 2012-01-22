
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class admin_core_promotion_new
    Inherits System.Web.UI.Page

    Dim str_error As String
    Dim str_mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Debug.WriteLine(">> " + s + " " + Request.Form(s))
        Next

        Dim capanegocios As New PromotionBL
        Dim be As PromotionBE
        be = New PromotionBE
        be.cod = 100
        be.nombre = Request.Form("name")
        be.estado = Request.Form("state")
        'Dim finit As String = String.Format("{0:dd/MM/yyyy}", Request.Form("date_init"))
        'Dim fend As String = String.Format("{0:dd/MM/yyyy}", Request.Form("date_end"))

        be.data_init = Request.Form("date_init")
        be.data_end = Request.Form("date_end")
        be.description = Request.Form("description")

        Try
            If capanegocios.InsertPromotion(be) = True Then

                str_mensaje = "Promoción registrada con éxito"
                Debug.WriteLine(str_mensaje)

                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

            Else

                str_mensaje = "No se registró la promoción"
                Debug.WriteLine(str_mensaje)
                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

            End If
        Catch ex As Exception
            str_error = capanegocios.CapturaError

            Debug.WriteLine(str_error)
        End Try

        'Dim capanegocios As New ClienteBL
        'Dim objeto As New BE.ClienteBE

        'Try
        '    'Llenamos las propiedades de la entidad ClienteBE
        '    objeto.strcontacto = txtcontacto.Text
        '    objeto.strdireccion = txtdireccion.Text
        '    objeto.strdistrito = ddldistrito.SelectedItem.Value
        '    objeto.strrazon = txtrazon.Text
        '    objeto.strruc = txtruc.Text
        '    objeto.strtelefono = txttelefono.Text
        '    objeto.strtipo = ddltipo.SelectedItem.Value

        '    If capanegocios.InsertarCliente(objeto) = True Then

        '        str_mensaje = "Cliente registrado con éxito"
        '        Dim script As String = "<script language=Javascript>"
        '        script += "alert('" & str_mensaje & "');"
        '        script += "</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

        '    Else

        '        str_mensaje = "No se registró al cliente"
        '        Dim script As String = "<script language=Javascript>"
        '        script += "alert('" & str_mensaje & "');"
        '        script += "</script>"
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

        '    End If


        'Catch ex As Exception
        '    str_error = capanegocios.CapturaError

        '    Response.Redirect("Errores.aspx?id=" & str_error)
        'Finally
        '    capanegocios = Nothing
        '    objeto = Nothing
        'End Try


        Response.Write(be.TO_JSON())

    End Sub

End Class
