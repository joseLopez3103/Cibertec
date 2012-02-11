Imports BusinessLogicLayer
Imports BE = BusinessEntities
Partial Class Mantenimiento
    Inherits System.Web.UI.Page
    Dim str_error As String
    Dim str_mensaje As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarClientes()
    End Sub

    Sub CargarClientes()
        'Instanciamos a la clase ClienteBL
        Dim capanegocios As New ClienteBL
        Try
            'Establece el origen de datos del gridview
            gvdatos.DataSource = capanegocios.ListarClientes
            'El campo oculto
            '"Pega" los datos al gridview
            gvdatos.DataBind()

        Catch ex As Exception
            str_error = capanegocios.CapturaError
            'Mandamos el error a la página de errores
            Response.Redirect("Errores.aspx?par=" & str_error)
        Finally
            'Liberamos recursos
            capanegocios = Nothing
        End Try
    End Sub

    Protected Sub lbnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbnuevo.Click
        Dim str_modo As String = "N"
        'MANDAMOS EL PARÁMETRO modo CON EL VALOR N
        Response.Redirect("DataEntryCliente.aspx?modo=" & str_modo)

    End Sub

    Sub Editar(ByVal src As Object, ByVal args As CommandEventArgs)

        Dim str_modo As String = "E"
        'capturamos al cliente al cual se quiere editar
        Dim str_cliente As String = args.CommandName

        'Mandamos dos parámetros: modo de edición y el cliente a editar
        Response.Redirect("DataEntryCliente.aspx?modo=" & str_modo & _
                           "&cliente=" & str_cliente)


    End Sub

    Sub Eliminar(ByVal src As Object, ByVal args As CommandEventArgs)

        Dim str_cliente As String
        str_cliente = args.CommandName
        Dim capanegocios As New ClienteBL
        Dim objeto As New BE.ClienteBE


        Try
            'Llenamos la propiedad que nos interesa 
            objeto.strcodigo = str_cliente

            If capanegocios.EliminarCliente(objeto) = True Then
                str_mensaje = "Se eliminó al cliente"

                'Mostramos el resultado en una ventana emergente 
                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

                'Volvemos a listar los datos
                CargarClientes()
                'MsgBox("Exito")
            Else
                'MsgBox("Error")
                str_mensaje = "No se puede eliminar al cliente"
                Dim script As String = "<script language=Javascript>"
                script += "alert('" & str_mensaje & "');"
                script += "</script>"
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)
            End If

        Catch ex As Exception

            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?id=" & str_error)
        Finally

            capanegocios = Nothing
            objeto = Nothing


        End Try


    End Sub

   
    

   
End Class
