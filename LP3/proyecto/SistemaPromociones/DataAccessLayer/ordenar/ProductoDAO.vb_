Imports System.Data
Imports System.Data.SqlClient

Imports BE = BusinessEntities 'El alias BE es opcional
Public Class ProductoDAO

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

    Public Function ListarProductos() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter("pr_listarproductos", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Productos")

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

    Public Function ProductosxProveedor() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter("SP_PRODUCTOSXPROVEEDOR", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Productos")

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


    Public Function DatosProducto(ByVal objeto As BE.ProductoBE) As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter("pr_datosproducto", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            'Definimos el parámetro
            da.SelectCommand.Parameters.Add(New SqlParameter("@vc_codigo", SqlDbType.VarChar, 8))
            da.SelectCommand.Parameters("@vc_codigo").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@vc_codigo").Value = objeto.strcodigo

            da.Fill(ds, "Producto")

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

    Public Function CapturaError() As String

        Return str_error

    End Function

End Class
