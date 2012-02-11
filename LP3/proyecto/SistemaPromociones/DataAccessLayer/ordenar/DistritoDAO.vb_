Imports System.Data
Imports System.Data.SqlClient
Public Class DistritoDAO
    'Declaramos variables
    Dim conexion As SqlConnection
    Dim comando As SqlDataAdapter
    Dim cmd As SqlCommand
    Public Shared errores As String

    'Instanciamos la clase Conexion.vb
    Dim cn As New Conexion

    Public Function ListarDistritos() As DataSet
        Dim ds As New DataSet
        Try

            conexion = cn.Conectar
            comando = New SqlDataAdapter("pr_listar_distritos", conexion)
            comando.SelectCommand.CommandType = CommandType.StoredProcedure

            'Llenamos el dataset
            comando.Fill(ds, "Distritos")

        Catch ex As Exception
            errores = ex.Message
        Finally
            'Destruimos los objetos
            conexion.Dispose()
            comando.Dispose()
            ds.Dispose()
        End Try
        Return ds
    End Function


    Public Function CapturaError() As String
        Return errores
    End Function


End Class
