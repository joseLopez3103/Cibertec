Imports DataAccessLayer
Imports BE = BusinessEntities
Public Class FacturaBL

    Dim factura As New FacturaDAO

    Public Function MostrarFactura() As DataSet

        Return factura.MostrarFactura

    End Function

    Public Function GrabarFactura(ByVal objeto As BE.FacturaBE, ByVal dt As DataTable) As String

        Return factura.GrabarFactura(objeto, dt)

    End Function

End Class
