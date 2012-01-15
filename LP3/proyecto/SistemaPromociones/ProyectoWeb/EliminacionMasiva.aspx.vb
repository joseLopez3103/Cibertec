Imports BusinessLogicLayer
Imports BE = BusinessEntities
Partial Class EliminacionMasiva
    Inherits System.Web.UI.Page
    Dim str_error As String

    Dim itemgridview As GridViewRow
    Dim casilla As System.Web.UI.WebControls.CheckBox
    Dim etiqueta As System.Web.UI.WebControls.Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            CargarClientes()

        End If
    End Sub

    Sub CargarClientes()
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

    Protected Sub btnmarcados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmarcados.Click

        'Instanciamos las clase
        Dim capanegocios As New ClienteBL
        Dim objeto As New BE.ClienteBE

        'Recorremos la grilla
        For Each Me.itemgridview In gvdatos.Rows

            casilla = itemgridview.FindControl("chkseleccionar")

            If casilla.Checked = True Then

                etiqueta = itemgridview.FindControl("lblcliente")
                'Llenamos la propiedad que nos interesa
                objeto.strcodigo = etiqueta.Text

                capanegocios.EliminarCliente(objeto)


            End If

        Next

        'Refrescamos la grilla
        CargarClientes()
        'Liberamos recursos
        capanegocios = Nothing
        objeto = Nothing

    End Sub
End Class
