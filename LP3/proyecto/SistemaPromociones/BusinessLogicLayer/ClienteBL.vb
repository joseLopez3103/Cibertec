Imports DataAccessLayer
Imports BE = BusinessEntities

Public Class ClienteBL

    Dim cliente As New ClienteDAO

    Public Function ListarClientes() As DataSet

        Return cliente.ListarClientes

    End Function

    Public Function ListarEmpleados() As DataSet

        Return cliente.ListarEmpleados

    End Function

    Public Function Filtrar_Facturas(ByVal objeto As BE.ClienteBE) As DataSet

        Return cliente.Filtrar_Facturas(objeto)
    End Function

    Public Function InsertarCliente(ByVal objeto As BE.ClienteBE) As Boolean

        Return cliente.InsertarCliente(objeto)

    End Function

    Public Function DatosCliente(ByVal objeto As BE.ClienteBE) As DataSet

        Return cliente.DatosCliente(objeto)

    End Function

    Public Function ActualizarCliente(ByVal objeto As BE.ClienteBE) As Boolean

        Return cliente.ActualizarCliente(objeto)

    End Function

    Public Function EliminarCliente(ByVal objeto As BE.ClienteBE) As Boolean

        Return cliente.EliminarCliente(objeto)

    End Function

    Public Function CapturaError() As String

        Return cliente.CapturaError

    End Function

End Class
