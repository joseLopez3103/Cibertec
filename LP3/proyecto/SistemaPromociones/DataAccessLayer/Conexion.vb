Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conexion
    Dim conexion As SqlConnection

    Public Function Conectar() As SqlConnection

        conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("Conexion").ConnectionString)

        Return conexion


    End Function

End Class
