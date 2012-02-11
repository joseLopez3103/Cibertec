Imports BusinessLogicLayer
Imports BE = BusinessEntities
Imports System.Data
Imports System.Data.SqlClient
Partial Class Transacciones
    Inherits System.Web.UI.Page
    Dim str_error As String
    Dim tabla As DataTable
    Dim fila As DataRow
    Dim dc_total As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            CargarClientes()
            CargarVendedores()
            CargarProductos()

            'Cargamos fechas por defecto en los calendarios
            cal_emision.SelectedDate = Today
            cal_cancelacion.SelectedDate = Today
        End If
    End Sub

    Sub CargarClientes()

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


    End Sub

    Sub CargarVendedores()

        Dim capanegocios As New VendedorBL

        Try
            'Establece el origen de datos
            ddlvendedor.DataSource = capanegocios.ListarVendedores
            'El campo oculto
            ddlvendedor.DataValueField = "COD_VEN"
            'El campo que se ve
            ddlvendedor.DataTextField = "NOMBRECOMPLETO"
            'Renderiza o pega la data al control 
            ddlvendedor.DataBind()
        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)

        Finally
            capanegocios = Nothing
        End Try
    End Sub

    Sub CargarProductos()
        Dim capanegocios As New ProductoBL
        'Instanciamos la entidad ProductoBE
        Dim objeto As New BE.ProductoBE

        Try
            'Establece el origen de datos
            ddlproducto.DataSource = capanegocios.ListarProductos
            'El campo oculto
            ddlproducto.DataValueField = "COD_PRO"
            'El campo que se ve
            ddlproducto.DataTextField = "DES_PRO"
            'Renderiza o pega la data al control 
            ddlproducto.DataBind()

            

            objeto.strcodigo = ddlproducto.SelectedValue

            txtprecio.Text = capanegocios.DatosProducto(objeto).Tables("Producto").Rows(0).Item(2)

            objeto = Nothing
        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)

        Finally
            capanegocios = Nothing
            objeto = Nothing
        End Try
    End Sub

    Sub CargarPrecio()
        'Instanciamos la clase ProductoBL
        Dim capanegocios As New ProductoBL
        'Instanciamos la entidad ProductoBE
        Dim objeto As New BE.ProductoBE

        Try
            objeto.strcodigo = ddlproducto.SelectedValue

            txtprecio.Text = capanegocios.DatosProducto(objeto).Tables("Producto").Rows(0).Item(2)
        Catch ex As Exception
            'Mandaré el error a una página de errores
            str_error = capanegocios.CapturaError

            Response.Redirect("Errores.aspx?parametro=" & str_error)
        Finally
            capanegocios = Nothing
            objeto = Nothing
        End Try

    End Sub


    Protected Sub ddlproducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlproducto.SelectedIndexChanged
        CargarPrecio()
    End Sub

    Protected Sub btnagregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        'Si no se indica la cantidad no hacemos nada
        If txtcantidad.Text = String.Empty Then
            Exit Sub
        End If

        'Si la sesión ha expirado creamos un datatable
        If Session("latabla") Is Nothing Then
            'Exit Sub
            Dim tabla As New Data.DataTable

            With tabla.Columns

                .Add("Codigo", Type.GetType("System.String"))
                .Add("Descripcion", Type.GetType("System.String"))
                .Add("Precio", Type.GetType("System.Double"))
                .Add("Cantidad", Type.GetType("System.Int32"))
                .Add("SubTotal", Type.GetType("System.Double"), "Precio * Cantidad")
            End With

            Session("latabla") = tabla

        End If


        tabla = CType(Session("latabla"), DataTable)

        'Validamos que el producto solo se agregue una vez
        For Each row As DataRow In tabla.Rows

            If row(0) = ddlproducto.SelectedValue Then

                MsgBox("Producto " + ddlproducto.SelectedItem.Text + " ya fue agregado")
                Exit Sub

            End If

        Next

        'Creamos una nueva fila en el Datatable
        fila = tabla.NewRow

        'Llenamos las columnas de la fila
        fila(0) = ddlproducto.SelectedValue 'Codigo
        fila(1) = ddlproducto.SelectedItem.Text 'Descripcion
        fila(2) = Convert.ToDecimal(txtprecio.Text) 'Precio
        fila(3) = Convert.ToInt32(txtcantidad.Text) 'Cantidad

        'Agregamos la fila al datatable
        tabla.Rows.Add(fila)

        'Finalmente fijamos el origen de datos de la grilla el datatable
        gvdatos.DataSource = tabla
        gvdatos.DataBind()

        'Procedimiento para mostrar el subtotal

        dc_total = 0

        For Each row As DataRow In tabla.Rows
            dc_total += row(4) 'SubTotal
        Next
        txtsubtotal.Text = Convert.ToString(dc_total)

        txttotal.Text = Convert.ToString(1.1799999999999999 * Convert.ToDecimal(txtsubtotal.Text))

    End Sub

    Sub Eliminar(ByVal src As Object, ByVal args As CommandEventArgs)

        'Si la sesión ha expirado no hacemos nada
        If Session("latabla") Is Nothing Then
            Exit Sub
        End If


        tabla = CType(Session("latabla"), DataTable)

        'Recorremos las filas del datatable para encontrar al registro con código igual al producto que
        'queremos eliminar, el cual se indica en args.CommandName
        For Each row As DataRow In tabla.Rows
            'MsgBox(row(0))
            If row(0) = args.CommandName Then
                row.Delete()
                Exit For
            End If
        Next

        'Refrescamos la grilla
        gvdatos.DataSource = tabla
        gvdatos.DataBind()


    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        'Validamos las fechas de la factura

        If cal_emision.SelectedDate > cal_cancelacion.SelectedDate Then
            MsgBox("Verifique las fechas")
            Exit Sub
        End If


        'Si la sesión ha expirado no hacemos nada
        If Session("latabla") Is Nothing Then
            Exit Sub
        End If

        tabla = CType(Session("latabla"), DataTable)

        'Solo si la tabla tiene registros
        If tabla.Rows.Count > 0 Then

            Dim capanegocios As New FacturaBL
            Dim objeto As New BE.FacturaBE

            Try
                objeto.strfecha = cal_emision.SelectedDate
                objeto.strfechacan = cal_cancelacion.SelectedDate
                objeto.strcodcli = ddlcliente.SelectedItem.Value
                objeto.strcodven = ddlvendedor.SelectedItem.Value

                MsgBox(capanegocios.GrabarFactura(objeto, tabla))

                txtfactura.Text = capanegocios.MostrarFactura.Tables("Factura").Rows(0).Item(0)

            Catch ex As Exception
                'Mandaré el error a una página de errores
                str_error = ex.Message

                Response.Redirect("Errores.aspx?parametro=" & str_error)
            Finally
                capanegocios = Nothing
                objeto = Nothing
            End Try
        End If

       

    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        If Session("latabla") Is Nothing Then
            Exit Sub
        End If

        tabla = CType(Session("latabla"), DataTable)

        If tabla.Rows.Count > 0 Then

            gvdatos.DataSource = Nothing
            gvdatos.DataBind()

            Session("latabla") = Nothing

        End If

        'Limpiamos las cajas de texto
        txtfactura.Text = ""
        txtsubtotal.Text = ""
        txttotal.Text = ""


    End Sub
End Class
