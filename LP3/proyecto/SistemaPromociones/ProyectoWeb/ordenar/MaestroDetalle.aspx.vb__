Imports BusinessLogicLayer
'Como hay parámetros
Imports BE = BusinessEntities
Partial Class MaestroDetalle
    Inherits System.Web.UI.Page
    Dim str_error As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Controlamos que el dropdownlist se cargue una sola vez
        'La primera VEZ  que aparece la página

        If Not Page.IsPostBack Then

            Dim capanegocios As New ClienteBL

            Try
                'Establece el origen de datos
                ddlcliente.DataSource = capanegocios.ListarClientes
                'El campo oculto
                ddlcliente.DataValueField = "COD_CLI"
                'El campo que se ve
                ddlcliente.DataTextField = "RAZ_SOC_CLI"
                'Renderiza o pega la data al control 
                ddlcliente.DataBind()
            Catch ex As Exception
                'Mandaré el error a una página de errores
                str_error = capanegocios.CapturaError

                Response.Redirect("Errores.aspx?parametro=" & str_error)

            Finally
                capanegocios = Nothing
            End Try


        End If

    End Sub

    Protected Sub ddlcliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcliente.SelectedIndexChanged
        'Instanciamos las clases
        Dim capanegocios As New ClienteBL
        Dim objeto As New BE.ClienteBE

        Try
            'Llenamos la propiedad que nos interesa
            objeto.strcodigo = ddlcliente.SelectedItem.Value 'COD_CLI

            gvdatos.DataSource = capanegocios.Filtrar_Facturas(objeto)
            gvdatos.DataBind()
        Catch ex As Exception

        Finally
            capanegocios = Nothing
            objeto = Nothing
        End Try
    End Sub
End Class
