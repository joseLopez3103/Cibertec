Imports Newtonsoft.Json

Public Class BaseBE

    Public Function TO_JSON() As String
        Dim _s As String
        _s = JsonConvert.SerializeObject(Me)
        Return _s
    End Function

End Class
