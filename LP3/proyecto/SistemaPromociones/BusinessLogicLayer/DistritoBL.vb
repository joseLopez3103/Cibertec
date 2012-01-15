Imports DataAccessLayer
Public Class DistritoBL
    'Referenciamos a la clase ClienteDAO
    Dim distrito As New DistritoDAO

    Public Function ListarDistritos() As DataSet

        Return distrito.ListarDistritos

    End Function

End Class
