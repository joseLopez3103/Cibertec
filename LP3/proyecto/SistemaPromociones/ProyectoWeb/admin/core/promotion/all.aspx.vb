
Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Diagnostics
Imports DataAccessLayer
Imports System.Data

Partial Class admin_core_promotion_all
    Inherits System.Web.UI.Page

    Dim str_error As String
    Dim str_mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each s As String In Request.Form.AllKeys
            ' Response.Write(s & ": " & Request.Form(s) & "<br />")
            Debug.WriteLine(">> " + Request.Form(s))
        Next

        Dim capanegocios As New PromotionBL
        Dim dataset As New DataSet

        Try
            dataset = capanegocios.ListPromotion
            str_mensaje = "Listado Correcto ... "

            'DataTable  dt = dataset.Tables[0]

            'List<Employee> emp = new List<Employee>();
            'foreach (DataRow dr in dt.Rows)
            '{
            '    Employee em = new Employee();
            '    em.Name = dr["Name"].ToString();
            '    em.age = Convert.ToInt32(dr["Age"]);
            '    em.Salary = Convert.ToInt32(dr["Salary"]);
            '    emp.Add(em);
            '}


            Debug.WriteLine("Listado promotion " + str_mensaje)

            ' If capanegocios.InsertPromotion(be) = True Then

            'str_mensaje = "Promoción registrada con éxito"
            'Debug.WriteLine(str_mensaje)

            'Dim script As String = "<script language=Javascript>"
            'script += "alert('" & str_mensaje & "');"
            'script += "</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)
            '  Else
            '  str_mensaje = "No se registró la promoción"
            ' Debug.WriteLine(str_mensaje)
            'Dim script As String = "<script language=Javascript>"
            'script += "alert('" & str_mensaje & "');"
            'script += "</script>"
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", script)

            'End If
        Catch ex As Exception
            str_error = capanegocios.CapturaError

            Debug.WriteLine(str_error)
        End Try

        Response.Write(Utils.DataSetToJSON(dataset))

    End Sub


End Class
