Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Imports BusinessLogicLayer
Partial Class Reporte1
    Inherits System.Web.UI.Page
    Dim str_error As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim reporte As New ReportDocument

        reporte.Load(Server.MapPath("rep1.rpt"))

        Dim capanegocios As New ClienteBL

        Try

            reporte.SetDataSource(capanegocios.ListarClientes.Tables("Clientes"))

            CRV.ReportSource = reporte
            CRV.RefreshReport()

        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)

        Finally
            capanegocios = Nothing
        End Try


    End Sub
End Class
