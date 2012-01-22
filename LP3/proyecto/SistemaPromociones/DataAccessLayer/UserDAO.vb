Imports BE = BusinessEntities
Imports System.Data
Imports System.Data.SqlClient

Public Class UserDAO

    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim str_error As String
    'Instanciamos la clase Conexion
    Dim cn As New Conexion

    Dim bool_resultado As Boolean
    Dim cmd As SqlCommand


    Public Function InsertUser(ByVal objeto As BE.UserBE) As Boolean

        'Instanciamos la clase conexion
        Dim cn As New Conexion
        Try
            conexion = cn.Conectar

            ' cmd = New SqlCommand("sp_new_promotion", conexion)
            cmd = New SqlCommand(Config.newUser, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada

            cmd.Parameters.Add(New SqlParameter("@name_user", SqlDbType.NVarChar, 20))
            cmd.Parameters("@name_user").Direction = ParameterDirection.Input
            cmd.Parameters("@name_user").Value = objeto.name_user

            cmd.Parameters.Add(New SqlParameter("@id_facebook", SqlDbType.NVarChar, 50))
            cmd.Parameters("@id_facebook").Direction = ParameterDirection.Input
            cmd.Parameters("@id_facebook").Value = objeto.id_facebook

            cmd.Parameters.Add(New SqlParameter("@sexo", SqlDbType.Char, 1))
            cmd.Parameters("@sexo").Direction = ParameterDirection.Input
            cmd.Parameters("@sexo").Value = objeto.sexo

            cmd.Parameters.Add(New SqlParameter("@email", SqlDbType.NVarChar, 50))
            cmd.Parameters("@email").Direction = ParameterDirection.Input
            cmd.Parameters("@email").Value = objeto.email

            conexion.Open()

            cmd.ExecuteNonQuery()
            bool_resultado = True
            Debug.WriteLine("Insert User complete ")

        Catch ex As Exception
            bool_resultado = False
            str_error = ex.Message
            Debug.WriteLine("error " + str_error)
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function

    Public Function validateUser(ByVal objeto As BE.UserBE) As Boolean

        'Instanciamos la clase conexion
        ' http://msdn.microsoft.com/en-us/library/haa3afyz(v=vs.71).aspx

        Dim reader As SqlDataReader
        Dim cn As New Conexion
        Try
            conexion = cn.Conectar

            ' cmd = New SqlCommand("sp_new_promotion", conexion)
            cmd = New SqlCommand(Config.validateUser, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada

            cmd.Parameters.Add(New SqlParameter("@id_facebook", SqlDbType.NVarChar, 50))
            cmd.Parameters("@id_facebook").Direction = ParameterDirection.Input
            cmd.Parameters("@id_facebook").Value = objeto.id_facebook

            conexion.Open()

            ' cmd.ExecuteNonQuery()
            reader = cmd.ExecuteReader()
            Debug.WriteLine("read size >>>" & " " & reader.HasRows)

            If reader.HasRows Then

                While reader.Read()
                    'MsgBox(reader.Item(0) & "  -  " & reader.Item(1) & "  -  " & reader.Item(2))
                    Debug.WriteLine("read >>>" & reader.Item(0) & " " & reader.Item(1) & " " & reader.Item(2) & " " & reader.Item(3) & " " & reader.Item(4))
                End While

            Else
                InsertUser(objeto)

            End If

            reader.Close()
            bool_resultado = True

        Catch ex As Exception
            bool_resultado = False
            str_error = ex.Message
            Debug.WriteLine("error " + str_error)
        Finally

            If conexion.State = ConnectionState.Open Then conexion.Close()
            conexion.Dispose()
            cmd.Dispose()
            cn = Nothing

        End Try

        Return bool_resultado

    End Function


    Public Function ListUser() As DataSet
        Dim ds As New DataSet
        Try
            conexion = cn.Conectar
            da = New SqlDataAdapter(Config.allUser, conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.Fill(ds, "Users")

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
