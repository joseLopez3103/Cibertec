Imports BE = BusinessEntities
Imports System.Data
Imports System.Data.SqlClient

Public Class AccessDAO

    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Dim str_error As String
    'Instanciamos la clase Conexion
    Dim cn As New Conexion

    Dim bool_resultado As Boolean
    Dim cmd As SqlCommand

    Public Function validateUser(ByVal objeto As BE.AccessBE) As Boolean

        'Instanciamos la clase conexion
        ' http://msdn.microsoft.com/en-us/library/haa3afyz(v=vs.71).aspx

        Dim reader As SqlDataReader
        Dim cn As New Conexion
        Try
            conexion = cn.Conectar

            ' cmd = New SqlCommand("sp_new_promotion", conexion)
            cmd = New SqlCommand(Config.sp_validate_admin, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            'Definimos los parámetros de entrada

            cmd.Parameters.Add(New SqlParameter("@usr", SqlDbType.NVarChar, 50))
            cmd.Parameters("@usr").Direction = ParameterDirection.Input
            cmd.Parameters("@usr").Value = objeto.name_user

            cmd.Parameters.Add(New SqlParameter("@password", SqlDbType.NVarChar, 50))
            cmd.Parameters("@password").Direction = ParameterDirection.Input
            cmd.Parameters("@password").Value = objeto.password_user

            conexion.Open()

            ' cmd.ExecuteNonQuery()
            reader = cmd.ExecuteReader()
            Debug.WriteLine("read size >>>" & " " & reader.HasRows)

            If reader.HasRows Then

                '  While reader.Read()
                'MsgBox(reader.Item(0) & "  -  " & reader.Item(1) & "  -  " & reader.Item(2))
                'Debug.WriteLine("accessDAO read >>>" & reader.Item(0) & " " & reader.Item(1) & " " & reader.Item(2) & " " & reader.Item(3) & " " & reader.Item(4))
                'End While
                bool_resultado = True
            Else
                ' InsertUser(objeto)
                bool_resultado = False
            End If

            reader.Close()
            ' bool_resultado = True

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

    Public Function CapturaError() As String

        Return str_error

    End Function

End Class
