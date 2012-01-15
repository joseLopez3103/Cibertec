Imports System.Data
Imports System.Data.SqlClient
Imports BE = BusinessEntities

Public Class ClienteDAO
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim str_error As String
    'Instanciamos la clase Conexion
    Dim cn As New Conexion

    Dim bool_resultado As Boolean
    Dim cmd As SqlCommand

    Public Function ListarClientes() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar

            da = New SqlDataAdapter("pr_listar_clientes", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Clientes")

        Catch ex As Exception

            str_error = ex.Message

        Finally

            'Liberamos recursos

            If conexion.State = ConnectionState.Open Then conexion.Close()

            da.Dispose()
            ds.Dispose()
            conexion.Dispose()

        End Try

        Return ds


    End Function

    'Public Function Filtrar_Facturas(ByVal codigo As String) As DataSet
    Public Function Filtrar_Facturas(ByVal objeto As BE.ClienteBE) As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar

            da = New SqlDataAdapter("pr_buscar_facturas", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            'Definimos el parámetro
            da.SelectCommand.Parameters.Add(New SqlParameter("@vc_codigo", SqlDbType.VarChar, 4))
            da.SelectCommand.Parameters("@vc_codigo").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@vc_codigo").Value = objeto.strcodigo

            da.Fill(ds, "Facturas")

        Catch ex As Exception

            str_error = ex.Message
        Finally

            'Liberamos recursos

            If conexion.State = ConnectionState.Open Then conexion.Close()

            da.Dispose()
            ds.Dispose()
            conexion.Dispose()

        End Try

        Return ds


    End Function

    Public Function InsertarCliente(ByVal objeto As BE.ClienteBE) As Boolean

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Try
            conexion = cn.Conectar

            cmd = New SqlCommand("pr_insertar_cliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada
            cmd.Parameters.Add(New SqlParameter("@vc_RAZON", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_RAZON").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_RAZON").Value = objeto.strrazon

            cmd.Parameters.Add(New SqlParameter("@vc_DIRECCION", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_DIRECCION").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_DIRECCION").Value = objeto.strdireccion()

            cmd.Parameters.Add(New SqlParameter("@vc_TELEFONO", SqlDbType.VarChar, 7))
            cmd.Parameters("@vc_TELEFONO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_TELEFONO").Value = objeto.strtelefono

            cmd.Parameters.Add(New SqlParameter("@vc_RUC", SqlDbType.Char, 11))
            cmd.Parameters("@vc_RUC").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_RUC").Value = objeto.strruc

            cmd.Parameters.Add(New SqlParameter("@vc_DISTRITO", SqlDbType.Char, 3))
            cmd.Parameters("@vc_DISTRITO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_DISTRITO").Value = objeto.strdistrito

            cmd.Parameters.Add(New SqlParameter("@vc_TIPO", SqlDbType.VarChar, 2))
            cmd.Parameters("@vc_TIPO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_TIPO").Value = objeto.strtipo

            cmd.Parameters.Add(New SqlParameter("@vc_CONTACTO", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_CONTACTO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_CONTACTO").Value = objeto.strcontacto

            conexion.Open()

            cmd.ExecuteNonQuery()
            bool_resultado = True

        Catch ex As Exception
            bool_resultado = False
            str_error = ex.Message
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function


    Public Function DatosCliente(ByVal objeto As BE.ClienteBE) As DataSet

        Dim ds As New DataSet

        Try

            conexion = cn.Conectar
            da = New SqlDataAdapter("pr_datos_cliente", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.SelectCommand.Parameters.Add _
            (New SqlParameter("@vc_codigo", SqlDbType.VarChar, 4))

            da.SelectCommand.Parameters("@vc_codigo").Direction = _
            ParameterDirection.Input

            da.SelectCommand.Parameters("@vc_codigo").Value = objeto.strcodigo()

            'Llenamos el dataset
            da.Fill(ds, "DatosCliente")

        Catch ex As Exception
            str_error = ex.Message
        Finally
            'Destruimos los objetos
            conexion.Dispose()
            da.Dispose()
            ds.Dispose()
        End Try

        Return ds

    End Function

    Public Function ActualizarCliente(ByVal objeto As BE.ClienteBE) As Boolean

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Try
            conexion = cn.Conectar

            cmd = New SqlCommand("pr_actualizar_cliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada

            cmd.Parameters.Add(New SqlParameter("@vc_CODIGO", SqlDbType.VarChar, 4))
            cmd.Parameters("@vc_CODIGO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_CODIGO").Value = objeto.strcodigo

            cmd.Parameters.Add(New SqlParameter("@vc_RAZON", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_RAZON").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_RAZON").Value = objeto.strrazon

            cmd.Parameters.Add(New SqlParameter("@vc_DIRECCION", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_DIRECCION").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_DIRECCION").Value = objeto.strdireccion()

            cmd.Parameters.Add(New SqlParameter("@vc_TELEFONO", SqlDbType.VarChar, 8))
            cmd.Parameters("@vc_TELEFONO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_TELEFONO").Value = objeto.strtelefono

            cmd.Parameters.Add(New SqlParameter("@vc_RUC", SqlDbType.Char, 11))
            cmd.Parameters("@vc_RUC").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_RUC").Value = objeto.strruc

            cmd.Parameters.Add(New SqlParameter("@vc_DISTRITO", SqlDbType.Char, 3))
            cmd.Parameters("@vc_DISTRITO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_DISTRITO").Value = objeto.strdistrito

            cmd.Parameters.Add(New SqlParameter("@vc_TIPO", SqlDbType.VarChar, 2))
            cmd.Parameters("@vc_TIPO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_TIPO").Value = objeto.strtipo

            cmd.Parameters.Add(New SqlParameter("@vc_CONTACTO", SqlDbType.VarChar, 100))
            cmd.Parameters("@vc_CONTACTO").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_CONTACTO").Value = objeto.strcontacto

            conexion.Open()

            cmd.ExecuteNonQuery()
            bool_resultado = True

        Catch ex As Exception
            bool_resultado = False
            str_error = ex.Message
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function

    Public Function EliminarCliente(ByVal objeto As BE.ClienteBE) As Boolean
        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Try

            conexion = cn.Conectar

            cmd = New SqlCommand("pr_eliminar_cliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure

            'Definimos el parámetro de entrada
            cmd.Parameters.Add(New SqlParameter("@vc_codigo", SqlDbType.VarChar, 4))
            cmd.Parameters("@vc_codigo").Direction = ParameterDirection.Input
            cmd.Parameters("@vc_codigo").Value = objeto.strcodigo

            conexion.Open()

            cmd.ExecuteNonQuery()
            bool_resultado = True


        Catch ex As Exception

            bool_resultado = False
            str_error = ex.Message

        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function


    Public Function CapturaError() As String

        Return str_error

    End Function

End Class
