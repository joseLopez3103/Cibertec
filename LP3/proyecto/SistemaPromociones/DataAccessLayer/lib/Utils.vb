Imports System.Web
Imports BusinessEntities
Imports Newtonsoft.Json

Public Class Utils

    Public Shared Function DataSetToJSON(ByVal ds As DataSet) As String
        Dim dict As New Dictionary(Of String, Object)
        Dim lstPromotion As New List(Of PromotionBE)

        For Each dt As DataTable In ds.Tables
            Dim arr(dt.Rows.Count) As Object

            For i As Integer = 0 To dt.Rows.Count - 1
                arr(i) = dt.Rows(i).ItemArray

                Dim be As New PromotionBE
                be.cod = dt.Rows(i)("cod").ToString
                be.nombre = dt.Rows(i)("name").ToString
                be.estado = dt.Rows(i)("state").ToString
                be.data_init = Convert.ToDateTime(dt.Rows(i)("date_init"))
                be.data_end = Convert.ToDateTime(dt.Rows(i)("date_end"))
                be.description = dt.Rows(i)("description").ToString
                be.path = dt.Rows(i)("path").ToString
                be.url_img = dt.Rows(i)("url_img").ToString

                ' Debug.WriteLine("DataSetToJson " + dt.Rows(i)("cod").ToString + " " + _
                '   dt.Rows(i)("name").ToString + " " + _
                '   dt.Rows(i)("state").ToString + " " + _
                '   dt.Rows(i)("date_init").ToString + " " + _
                '  dt.Rows(i)("date_end").ToString + " " + _
                '  dt.Rows(i)("description").ToString)

                lstPromotion.Add(be)

                '  For Each dc As DataColumn In  dt.Rows)

                'result.Add(dc.ColumnName, dr[dc].ToString());

                'Debug.WriteLine("col " + dc.ColumnName)
                'Next
            Next

            '   dict.Add(dt.TableName, arr)
            '  Debug.WriteLine("table " + dt.TableName + " ")
            Next

        Dim _s As String
        _s = JsonConvert.SerializeObject(lstPromotion)

        Return _s
    End Function

    'get PromotionBE ----
    Public Shared Function DataSetToPromotionBE(ByVal ds As DataSet) As PromotionBE

        Dim dict As New Dictionary(Of String, Object)
        ' Dim lstPromotion As New List(Of PromotionBE)
        Dim be As New PromotionBE

        For Each dt As DataTable In ds.Tables
            Dim arr(dt.Rows.Count) As Object

            'For i As Integer = 0 To dt.Rows.Count - 1
            For i As Integer = 0 To dt.Rows.Count - 1
                arr(i) = dt.Rows(i).ItemArray

                ' Dim be As New PromotionBE
                be.cod = dt.Rows(i)("cod").ToString
                be.nombre = dt.Rows(i)("name").ToString
                be.estado = dt.Rows(i)("state").ToString
                be.data_init = Convert.ToDateTime(dt.Rows(i)("date_init"))
                be.data_end = Convert.ToDateTime(dt.Rows(i)("date_end"))
                be.description = dt.Rows(i)("description").ToString
                be.path = dt.Rows(i)("path").ToString
                be.url_img = dt.Rows(i)("url_img").ToString

                ' Debug.WriteLine("Utils DataSetToPromotionBE " + dt.Rows(i)("cod").ToString + " " + _
                'dt.Rows(i)("name").ToString(+" " + _
                'dt.Rows(i)("state").ToString + " " + _
                ' dt.Rows(i)("date_init").ToString + " " + _
                ' dt.Rows(i)("date_end").ToString + " " + _
                'dt.Rows(i)("description").ToString + " " + _
                'dt.Rows(i)("url_img").ToString + " " + _
                'dt.Rows(i)("path").ToString + " ")
                '    )

                If i = 0 Then
                    Return be
                End If

                ' lstPromotion.Add(be)
            Next
        Next

        'Dim _s As String
        '_s = JsonConvert.SerializeObject(lstPromotion)

        Return be
    End Function

End Class
