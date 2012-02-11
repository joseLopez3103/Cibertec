Imports BusinessEntities

Partial Class TestJson
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim be As TestBE
        be = New TestBE
        be.id = "100"
        be.name = "edu"

        Response.Write(be.TO_JSON())

    End Sub
End Class
