Public Class UserBE
    Inherits BaseBE

    Private _cod As Integer
    Private _name_user As String
    Private _id_facebook As String
    Private _sexo As String
    Private _email As String

    Public Property cod() As Integer
        Get
            Return _cod
        End Get
        Set(ByVal value As Integer)
            _cod = _cod
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

    Public Property id_facebook() As String
        Get
            Return _id_facebook
        End Get
        Set(ByVal value As String)
            _id_facebook = value
        End Set
    End Property

    Public Property sexo() As String
        Get
            Return _sexo
        End Get
        Set(ByVal value As String)
            _sexo = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

End Class
