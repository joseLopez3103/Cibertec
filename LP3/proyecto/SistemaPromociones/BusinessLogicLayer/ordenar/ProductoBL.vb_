Imports DataAccessLayer
Imports BE = BusinessEntities
Public Class ProductoBL

    Dim producto As New ProductoDAO

    Public Function ListarProductos() As DataSet

        Return producto.ListarProductos

    End Function

    Public Function ProductosxProveedor() As DataSet

        Return producto.ProductosxProveedor

    End Function


    Public Function DatosProducto(ByVal objeto As BE.ProductoBE) As DataSet

        Return producto.DatosProducto(objeto)

    End Function

    Public Function CapturaError() As String

        Return producto.CapturaError

    End Function



End Class
