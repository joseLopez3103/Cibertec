Public Class AccessBE
    Inherits BaseBE

    Private _cod As Integer
    Private _name_user As String
    Private _password_user As String

    Public Property cod() As Integer
        Get
            Return _cod
        End Get
        Set(ByVal value As Integer)
            _cod = value
        End Set
    End Property

    Public Property name_user() As String
        Get
            Return _name_user
        End Get
        Set(ByVal value As String)
            _name_user = value
        End Set
    End Property

    Public Property password_user() As String
        Get
            Return _password_user
        End Get
        Set(ByVal value As String)
            _password_user = value
        End Set
    End Property


End Class
