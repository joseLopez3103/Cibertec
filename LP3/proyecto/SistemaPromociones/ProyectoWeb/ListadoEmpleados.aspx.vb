
Imports BusinessLogicLayer
Partial Class ListadoEmpleados
    Inherits System.Web.UI.Page

    Dim str_error As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim capanegocios As New ClienteBL

        Try
            'Establece el origen de datos
            GridView1.DataSource = capanegocios.ListarEmpleados

            'Renderiza o pega la data al control 
            GridView1.DataBind()
        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)

        Finally
            capanegocios = Nothing
        End Try


    End Sub
End Class
