Imports System.Data
Imports System.Data.SqlClient

Imports BE = BusinessEntities 'El alias BE es opcional
Public Class FacturaDAO

    'Instanciamos la clase Conexion
    Dim cn As New Conexion
    'Bloque general de declaración de variables
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim str_resultado As String
    Dim bool_resultado As Boolean
    Dim str_error As String
    Dim int_total As Integer
    Dim int_i As Integer
    Dim str_mensaje As String

    Public Function MostrarFactura() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter("pr_lee_ultima_factura", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Factura")

        Catch ex As Exception
            str_error = ex.Message
        Finally
            'Si la conexión quedó abierta, cerrarla
            If conexion.State = ConnectionState.Open Then conexion.Close()
            'Liberamos recursos
            ds.Dispose()
            da.Dispose()
            conexion.Dispose()
        End Try

        Return ds

    End Function

    Public Function GrabarFactura(ByVal objeto As BE.FacturaBE, ByVal dt As DataTable) As String

        Try

            conexion = cn.Conectar

            'Abrir la conexión antes de iniciar la transacción
            conexion.Open()
            Dim tr As SqlTransaction = conexion.BeginTransaction

            Dim cmd As New SqlCommand("pr_generaNumero", conexion, tr)
            cmd.CommandType = CommandType.StoredProcedure

            'Generamos el código de la factura
            Dim str_codigo As String = cmd.ExecuteScalar

            'Grabamos la cabecera de la factura
            cmd.CommandText = "pr_graba_CabeceraFactura"

            'Agregar los parámetros
            cmd.Parameters.Add(New SqlParameter("@num", SqlDbType.VarChar, 5))
            cmd.Parameters("@num").Direction = ParameterDirection.Input
            cmd.Parameters("@num").Value = str_codigo

            cmd.Parameters.Add(New SqlParameter("@fecfac", SqlDbType.VarChar, 10))
            cmd.Parameters("@fecfac").Direction = ParameterDirection.Input
            cmd.Parameters("@fecfac").Value = objeto.strfecha

            cmd.Parameters.Add(New SqlParameter("@vc_cli", SqlDbType.VarChar, 8))
            cmd.Parameters("@vc_cli").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_cli").Value = objeto.strcodcli

            cmd.Parameters.Add(New SqlParameter("@feccan", SqlDbType.VarChar, 10))
            cmd.Parameters("@feccan").Direction = ParameterDirection.Input
            cmd.Parameters("@feccan").Value = objeto.strfechacan

            cmd.Parameters.Add(New SqlParameter("@vc_ven", SqlDbType.VarChar, 6))
            cmd.Parameters("@vc_ven").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_ven").Value = objeto.strcodven

            'Ejecutamos el comando     
            int_i = cmd.ExecuteNonQuery

            If int_i = 0 Then
                str_mensaje = "Error en grabar la factura"
                'Deshacer la transacción     
                tr.Rollback()
            Else

                'Grabar los detalles de la factura

                cmd.CommandText = "pr_graba_DetalleDetalle"

                For Each fila As DataRow In dt.Rows

                    'En cada fila limpiamos los parámetros
                    cmd.Parameters.Clear()

                    cmd.Parameters.Add(New SqlParameter _
                   ("@num", SqlDbType.VarChar, 5))
                    cmd.Parameters("@num").Direction = ParameterDirection.Input
                    cmd.Parameters("@num").Value = str_codigo

                    cmd.Parameters.Add(New SqlParameter("@vc_pro", SqlDbType.VarChar, 8))
                    cmd.Parameters("@vc_pro").Direction = ParameterDirection.Input
                    cmd.Parameters("@vc_pro").Value = fila(0)

                    cmd.Parameters.Add(New SqlParameter("@int_can", SqlDbType.Int))
                    cmd.Parameters("@int_can").Direction = ParameterDirection.Input
                    cmd.Parameters("@int_can").Value = fila(3)

                    cmd.Parameters.Add(New SqlParameter("@dc_pre", SqlDbType.Decimal))
                    cmd.Parameters("@dc_pre").Direction = ParameterDirection.Input
                    cmd.Parameters("@dc_pre").Value = fila(2)


                    'Ejecutamos el comando fila a fila     
                    int_i = cmd.ExecuteNonQuery
                    If int_i = 0 Then
                        str_mensaje = "Error en grabar los detalles"
                        'Deshacer la transacción 
                        tr.Rollback()
                    End If
                Next

                'Si no hay errores confirmamos la transacción
                tr.Commit()
                str_mensaje = "Factura Grabada con éxito"
            End If

        Catch ex As Exception

            str_error = ex.Message
        Finally
            conexion.Close()
        End Try

        Return str_mensaje

    End Function



End Class
