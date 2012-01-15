Imports BusinessLogicLayer
Imports BE = BusinessEntities
Partial Class DataEntryCliente
    Inherits System.Web.UI.Page

    Dim str_error As String
    Dim str_mensaje As String
    Public Shared str_modo As String
    Public Shared str_cliente As String
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            'Recuperamos los parámetros enviados por la página Mantenimiento.aspx
            str_modo = Request.QueryString("modo")
            str_cliente = Request.QueryString("cliente")

            'Cargamos el DropDownList de distritos
            CargarDistritos()

            If str_modo = "E" Then
                '    'Pintamos la data actual
                Dim capanegocios As New ClienteBL
                Dim objeto As New BE.ClienteBE

                Try
                    '        'Llenamos la propiedad de la entidad ClienteBE 
                    objeto.strcodigo = str_cliente

                    lblencabezado.Text = "Edición del cliente " + str_cliente

                    '        'Pintamos la data original del cliente


                    txtrazon.Text = Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                     Tables("DatosCliente").Rows(0).Item(1))

                    txtdireccion.Text = Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(2))

                    txttelefono.Text = IIf(IsDBNull(Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(3))), "", Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(3)))

                    txtruc.Text = Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(4))

                    ddldistrito.Items.FindByValue(Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(5))).Selected = True


                    ddltipo.Items.FindByValue(Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                    Tables("DatosCliente").Rows(0).Item(7))).Selected = True

                    txtcontacto.Text = Convert.ToString(capanegocios.DatosCliente(objeto). _
                                                   Tables("DatosCliente").Rows(0).Item(8))

                Catch ex As Exception
                    str_error = ex.Message
                    Response.Redirect("Errores.aspx?id=" & str_error)
                Finally
                    capanegocios = Nothing
                    objeto = Nothing
                End Try

            Else

                lblencabezado.Text = "Registro de un nuevo cliente"

            End If

        End If


    End Sub

    Sub CargarDistritos()
        Dim capanegocios As New DistritoBL
        Try

            ddldistrito.DataSource = capanegocios.ListarDistritos
            ddldistrito.DataValueField = "COD_DIS"
            ddldistrito.DataTextField = "NOM_DIS"
            ddldistrito.DataBind()
        Catch ex As Exception
            str_error = ex.Message
            Response.Redirect("Errores.aspx?id=" & str_error)
        Finally
            capanegocios = Nothing
        End Try
    End Sub

    Protected Sub btnprocesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprocesar.Click
        If str_modo = "N" Then
            'Nuevo registro

            Dim capanegocios As New ClienteBL
            Dim objeto As New BE.ClienteBE

            Try
                'Llenamos las propiedades de la entidad ClienteBE
                objeto.strcontacto = txtcontacto.Text
                objeto.strdireccion = txtdireccion.Text
                objeto.strdistrito = ddldistrito.SelectedItem.Value
                objeto.strrazon = txtrazon.Text
                objeto.strruc = txtruc.Text
                objeto.strtelefono = txttelefono.Text
                objeto.strtipo = ddltipo.SelectedItem.Value

                If capanegocios.InsertarCliente(objeto) = True Then

                    str_mensaje = "Cliente registrado con éxito"
                    Dim script As String = "<script language=Javascript>"
                    script += "alert('" & str_mensaje & "');"
                    script += "</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

                Else

                    str_mensaje = "No se registró al cliente"
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


        Else
            'Edición de un registro
            Dim capanegocios As New ClienteBL
            Dim objeto As New BE.ClienteBE

            Try
                'Llenamos las propiedades de la entidad ClienteBE
                objeto.strcodigo = str_cliente
                objeto.strcontacto = txtcontacto.Text
                objeto.strdireccion = txtdireccion.Text
                objeto.strdistrito = ddldistrito.SelectedItem.Value
                objeto.strrazon = txtrazon.Text
                objeto.strruc = txtruc.Text
                objeto.strtelefono = txttelefono.Text
                objeto.strtipo = ddltipo.SelectedItem.Value

                If capanegocios.ActualizarCliente(objeto) = True Then
                    str_mensaje = "Cliente actualizado con éxito"
                    Dim script As String = "<script language=Javascript>"
                    script += "alert('" & str_mensaje & "');"
                    script += "</script>"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

                Else
                    str_mensaje = "No se actualizó los datos del cliente"
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

        End If
    End Sub

End Class
