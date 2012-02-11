
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics

Partial Class promotion_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dim id As String = Request.QueryString("id")
        Dim cod As Integer = Integer.Parse(Request.QueryString("cod"))
        ' lblNombre.Text = cod.ToString()

        Dim capanegocios As New PromotionBL
        Dim be As PromotionBE
        be = New PromotionBE
        be.cod = cod

        Try
            Dim aux As PromotionBE = capanegocios.getPromotionbyCod(be)
            Debug.WriteLine("details promotion user " & aux.nombre & " " & aux.description)
            lblNombre.Text = aux.nombre
            lblDescripcion.Text = aux.description
            lblFechaInicio.Text = aux.data_init.Day & "/" & aux.data_init.Month & "/" & aux.data_init.Year
            lblFechaFin.Text = aux.data_end.Day & "/" & aux.data_end.Month & "/" & aux.data_end.Year
            imgPromocion.ImageUrl = "http://localhost:51823/test1/admin" & aux.url_img


        Catch ex As Exception
            'str_error = capanegocios.CapturaError

            'Debug.WriteLine(str_error)
        End Try

    End Sub
End Class
