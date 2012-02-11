Imports System.Data
Imports System.Data.SqlClient
Public Class VendedorDAO

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

    Public Function ListarVendedores() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter("pr_listarvendedores", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Vendedores")

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
