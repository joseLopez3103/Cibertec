Imports BusinessLogicLayer
Partial Class SeleccionMasiva
    Inherits System.Web.UI.Page
    Dim str_error As String

    Dim itemgridview As GridViewRow
    Dim casilla As System.Web.UI.WebControls.CheckBox
    Dim etiqueta As System.Web.UI.WebControls.Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

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

        End If
    End Sub

    Protected Sub btnmarcados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmarcados.Click
        lblmensaje.Text = ""


        'Recorremos la grilla
        For Each Me.itemgridview In gvdatos.Rows

            casilla = itemgridview.FindControl("chkseleccionar")

            If casilla.Checked = True Then

                etiqueta = itemgridview.FindControl("lblcliente")

                lblmensaje.Text += "Seleccionaste los siguientes elementos " + etiqueta.Text + "<BR>"

            End If

        Next

    End Sub

    Protected Sub btntodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntodos.Click
        lblmensaje.Text = ""
        'Recorremos la grilla
        For Each Me.itemgridview In gvdatos.Rows
            casilla = itemgridview.FindControl("chkseleccionar")
            'Forzamos la selección
            casilla.Checked = True
            etiqueta = itemgridview.FindControl("lblcliente")
            lblmensaje.Text += "Seleccionaste los siguientes elementos " + etiqueta.Text + "<BR>"
        Next
    End Sub
    Protected Sub btndeseleccionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndeseleccionar.Click
        'Recorremos la grilla
        For Each Me.itemgridview In gvdatos.Rows
            casilla = itemgridview.FindControl("chkseleccionar")
            'Forzamos la selección
            casilla.Checked = False
            etiqueta = itemgridview.FindControl("lblcliente")
            lblmensaje.Text = "No seleccionó nada"
        Next
    End Sub
End Class
