
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics
Imports System.IO


Partial Class admin_core_promotion_new
    Inherits System.Web.UI.Page

    Dim str_error As String
    Dim str_mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Debug.WriteLine(">> " + s + " " + Request.Form(s))
        Next
        'files enviados ---
        Dim hfc As HttpFileCollection = Request.Files
        Dim hpf1 As HttpPostedFile = hfc(0)
        Debug.WriteLine("hpf1 >>> " & hpf1.FileName)

        'If hpf.ContentLength > 0 Then
        '    hpf.SaveAs(Server.MapPath("MyFiles") & "\" & System.IO.Path.GetFileName(hpf.FileName))
        '    Response.Write("<b>File: </b>" & hpf.FileName & " <b>Size:</b> " & hpf.ContentLength & " <b>Type:</b> " & hpf.ContentType & " Uploaded Successfully <br/>")
        'End If

        'files enviados -----

        Dim capanegocios As New PromotionBL
        Dim be As PromotionBE
        be = New PromotionBE

        Dim nbe As PromotionBE = New PromotionBE()

        ' be.cod = 100
        be.nombre = Request.Form("name")
        be.estado = Request.Form("state")
        'Dim finit As String = String.Format("{0:dd/MM/yyyy}", Request.Form("date_init"))
        'Dim fend As String = String.Format("{0:dd/MM/yyyy}", Request.Form("date_end"))

        be.data_init = Request.Form("date_init")
        be.data_end = Request.Form("date_end")
        be.description = Request.Form("description")

        Try
            Dim codGenerate As Integer = capanegocios.InsertPromotion(be)

            ' If capanegocios.InsertPromotion(be) <> -1 Then
            If codGenerate <> -1 Then

                str_mensaje = "Promoción registrada con éxito " & codGenerate
                Debug.WriteLine(str_mensaje)

                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

                Dim nfolder As String = MapPath(".") & "\..\..\promotions\" & codGenerate.ToString()
                Directory.CreateDirectory(nfolder)
                Dim nfile As String = nfolder & "\" & System.IO.Path.GetFileName(hpf1.FileName)
                hpf1.SaveAs(nfile)

                Dim sfolder As String = "/promotions/" & codGenerate.ToString()
                Dim sfile As String = sfolder & "/" & System.IO.Path.GetFileName(hpf1.FileName)

                saveUrl(sfolder, sfile, codGenerate)
                ' nbe = New PromotionBE()
                Dim aux As PromotionBE = New PromotionBE()
                aux.cod = codGenerate

                nbe = capanegocios.getPromotionbyCod(aux)
                Debug.WriteLine("new promotion complete " & nbe.cod)
            Else

                str_mensaje = "No se registró la promoción"
                Debug.WriteLine(str_mensaje)
                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)
                nbe = New PromotionBE()

            End If
        Catch ex As Exception
            str_error = capanegocios.CapturaError
            nbe = New PromotionBE()
            Debug.WriteLine(str_error)
        End Try

        'Response.Write(be.TO_JSON())
        If IsNothing(nbe.cod) Then
            Response.Write(be.TO_JSON())
        Else
            Response.Write(nbe.TO_JSON())
        End If

    End Sub

    Private Sub saveUrl(ByVal nfolder As String, ByVal nfile As String, ByVal code As Integer)
        'Throw New NotImplementedException
        Debug.WriteLine("save URL ok")

        Dim capanegocios As New PromotionBL

        Try
            If capanegocios.saveUrlPromotion(nfolder, nfile, code) = True Then

            End If

        Catch ex As Exception

        End Try
    End Sub

End Class
