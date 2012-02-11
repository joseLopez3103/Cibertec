Imports BusinessLogicLayer
'Como hay parámetros
Imports BE = BusinessEntities
Partial Class DetalleFacturas
    Inherits System.Web.UI.Page
    Dim str_error As String
    Protected Sub btnregresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnregresar.Click
        Response.Redirect("VarianteMaestroDetalle.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instanciamos las clases
        Dim capanegocios As New ClienteBL
        Dim objeto As New BE.ClienteBE

        Try
            lblcliente.Text = "Facturas del cliente " + Request.QueryString("parametro")

            'Llenamos la propiedad que nos interesa
            objeto.strcodigo = Request.QueryString("parametro")

            gvdatos.DataSource = capanegocios.Filtrar_Facturas(objeto)
            gvdatos.DataBind()
        Catch ex As Exception

        Finally
            capanegocios = Nothing
            objeto = Nothing
        End Try
    End Sub
End Class
