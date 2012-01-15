Public Class FacturaBE

    Private str_factura As String
    Private str_fecha As String
    Private str_cod_cli As String
    Private str_fecha_can As String
    Private str_estado As String
    Private str_cod_ven As String
    Private dc_igv As Decimal
    Private int_mes As Integer
    Private str_año As String

    Public Property strfactura() As String

        Get
            Return str_factura
        End Get
        Set(ByVal value As String)
            str_factura = value
        End Set

    End Property

    Public Property strfecha() As String

        Get
            Return str_fecha
        End Get
        Set(ByVal value As String)
            str_fecha = value
        End Set

    End Property


    Public Property strcodcli() As String

        Get
            Return str_cod_cli
        End Get
        Set(ByVal value As String)
            str_cod_cli = value
        End Set

    End Property

    Public Property strfechacan() As String
        Get
            Return str_fecha_can
        End Get
        Set(ByVal value As String)
            str_fecha_can = value
        End Set

    End Property


    Public Property strestado() As String
        Get
            Return str_estado
        End Get
        Set(ByVal value As String)
            str_estado = value
        End Set

    End Property

    Public Property strcodven() As String

        Get
            Return str_cod_ven
        End Get
        Set(ByVal value As String)
            str_cod_ven = value
        End Set

    End Property

    Public Property dcigv() As Decimal

        Get
            Return dc_igv
        End Get
        Set(ByVal value As Decimal)
            dc_igv = value
        End Set

    End Property

    Public Property intmes() As Integer

        Get
            Return int_mes
        End Get
        Set(ByVal value As Integer)
            int_mes = value
        End Set

    End Property

    Public Property straño() As String

        Get
            Return str_año
        End Get
        Set(ByVal value As String)
            str_año = value
        End Set

    End Property

End Class
