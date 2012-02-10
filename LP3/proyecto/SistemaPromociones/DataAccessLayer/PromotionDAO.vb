Imports BE = BusinessEntities
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader



Public Class PromotionDAO
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim str_error As String
    'Instanciamos la clase Conexion
    Dim cn As New Conexion

    Dim bool_resultado As Boolean
    Dim cod_generate As Integer
    Dim cmd As SqlCommand


    'Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Boolean
    Public Function InsertPromotion(ByVal objeto As BE.PromotionBE) As Integer

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Dim dr As SqlDataReader

        Try
            conexion = cn.Conectar

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

            conexion.Open()

            'cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader
            ' cod_generate = Integer.Parse(dr(0).ToString())
            While dr.Read
                'Debug.WriteLine("read " + dr(0).ToString())
                cod_generate = Integer.Parse(dr(0))
            End While

            Debug.WriteLine("promotioDAO  " & cod_generate)

            dr.Close()
            bool_resultado = True

        Catch ex As Exception
            bool_resultado = False
            cod_generate = -1
            str_error = ex.Message
            Debug.WriteLine("error " + str_error)
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        ' Return bool_resultado
        Return cod_generate

    End Function

    Public Function saveUrlPromotion(ByVal url As String, ByVal file As String, ByVal cod As Integer) As Boolean
        Dim b As Boolean = False

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Dim dr As SqlDataReader

        Try
            conexion = cn.Conectar

            cmd = New SqlCommand(Config.saveUrlPromotion, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada
            cmd.Parameters.Add(New SqlParameter("@cod", SqlDbType.Int, 10))
            cmd.Parameters("@cod").Direction = ParameterDirection.Input
            cmd.Parameters("@cod").Value = cod

            cmd.Parameters.Add(New SqlParameter("@nfolder", SqlDbType.VarChar, 100))
            cmd.Parameters("@nfolder").Direction = ParameterDirection.Input
            cmd.Parameters("@nfolder").Value = file

            cmd.Parameters.Add(New SqlParameter("@file", SqlDbType.VarChar, 100))
            cmd.Parameters("@file").Direction = ParameterDirection.Input
            cmd.Parameters("@file").Value = url

            conexion.Open()
            cmd.ExecuteNonQuery()

            Debug.WriteLine("save url OK")
            b = True

        Catch ex As Exception
            b = False
            str_error = ex.Message
            Debug.WriteLine("error " + str_error)
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try
        Return b
    End Function

    Public Function GetPromotionByCod(ByVal objeto As BE.PromotionBE) As BE.PromotionBE

        Dim ds As New DataSet
        Dim be As BE.PromotionBE = Nothing

        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter(Config.getPromotionByCod, conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            'Definimos el parámetro
            da.SelectCommand.Parameters.Add(New SqlParameter("@cod", SqlDbType.Int, 10))
            da.SelectCommand.Parameters("@cod").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@cod").Value = objeto.cod

            da.Fill(ds, "PromotionCod")

            be = New BE.PromotionBE()
            be = Utils.DataSetToPromotionBE(ds)
            Debug.WriteLine("PromotionDAO BE >>> " & be.cod & " " & be.path & " " & be.url_img)

        Catch ex As Exception
            str_error = ex.Message
        Finally

            'Liberamos recursos
            If conexion.State = ConnectionState.Open Then conexion.Close()

            da.Dispose()
            ds.Dispose()
            conexion.Dispose()
            '  be = Nothing

        End Try
        Return be

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
