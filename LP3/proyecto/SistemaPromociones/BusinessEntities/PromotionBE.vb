Public Class PromotionBE
    Inherits BaseBE

    Private _cod As Integer
    Private _nombre As String
    Private _estado As String
    Private _date_init As Date
    Private _date_end As Date
    Private _description As String

    Public Property cod() As Integer
        Get
            Return _cod
        End Get
        Set(ByVal value As Integer)
            _cod = value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property data_init() As Date
        Get
            Return _date_init
        End Get
        Set(ByVal value As Date)
            _date_init = value
        End Set
    End Property

    Public Property data_end() As Date
        Get
            Return _date_end
        End Get
        Set(ByVal value As Date)
            _date_end = value
        End Set
    End Property

    Public Property description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property


End Class
