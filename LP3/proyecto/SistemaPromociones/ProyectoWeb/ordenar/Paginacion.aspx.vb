Imports BusinessLogicLayer
Partial Class Paginacion
    Inherits System.Web.UI.Page
    Dim str_error As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            CargarDatos()

        End If
    End Sub

    Sub CargarDatos()
        Dim capanegocios As New ClienteBL

        Try
            'Establece el origen de datos
            gvdatos.DataSource = capanegocios.ListarClientes
            'Renderiza o pega la data al control 
            gvdatos.DataBind()
        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)

        Finally
            capanegocios = Nothing
        End Try
    End Sub

    Sub Paginar(ByVal source As Object, ByVal e As GridViewPageEventArgs)
        'Capturamos el índice de la nueva página
        gvdatos.PageIndex = e.NewPageIndex
        'Refrescamos los datos de la nueva página
        CargarDatos()

    End Sub
End Class
