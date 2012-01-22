Imports BE = BusinessEntities
Imports System.Data
Imports System.Data.SqlClient


Public Class PromotionDAO
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim str_error As String
    'Instanciamos la clase Conexion
    Dim cn As New Conexion

    Dim bool_resultado As Boolean
    Dim cmd As SqlCommand


    Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Boolean

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Try
            Conexion = cn.Conectar

            ' cmd = New SqlCommand("sp_new_promotion", conexion)
            cmd = New SqlCommand(Config.newPromotion, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada
            cmd.Parameters.Add(New SqlParameter("@name", SqlDbType.VarChar, 20))
            cmd.Parameters("@name").Direction = ParameterDirection.Input
            cmd.Parameters("@name").Value = objeto.nombre

            cmd.Parameters.Add(New SqlParameter("@state", SqlDbType.VarChar, 20))
            cmd.Parameters("@state").Direction = ParameterDirection.Input
            cmd.Parameters("@state").Value = objeto.estado

            cmd.Parameters.Add(New SqlParameter("@date_init", SqlDbType.DateTime))
            cmd.Parameters("@date_init").Direction = ParameterDirection.Input
            cmd.Parameters("@date_init").Value = objeto.data_init

            cmd.Parameters.Add(New SqlParameter("@date_end", SqlDbType.DateTime))
            cmd.Parameters("@date_end").Direction = ParameterDirection.Input
            cmd.Parameters("@date_end").Value = objeto.data_end

            cmd.Parameters.Add(New SqlParameter("@description", SqlDbType.VarChar, 255))
            cmd.Parameters("@description").Direction = ParameterDirection.Input
            cmd.Parameters("@description").Value = objeto.description


            Conexion.Open()

            cmd.ExecuteNonQuery()
            bool_resultado = True

        Catch ex As Exception
            bool_resultado = False
            str_error = ex.Message
            Debug.WriteLine("error "+str_error)
        Finally

            If Conexion.State = ConnectionState.Open Then Conexion.Close()
            Conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function

    Public Function ListPromotion() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter(Config.allPromotion, conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Promotions")

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
