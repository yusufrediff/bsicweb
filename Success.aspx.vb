Imports Con
Partial Class Success
    Inherits System.Web.UI.Page
    Dim cnn As New Conn
    Public iRefNo, iName, iMobile As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.RouteData.Values("RefNo") = "" Or Page.RouteData.Values("Name") = "" Or Page.RouteData.Values("Number") = "" Then
            Response.Redirect("/Default")
        End If

        iName = cnn.Decrypt("111", Page.RouteData.Values("Name")) : iRefNo = cnn.Decrypt("111", Page.RouteData.Values("RefNo"))
        iMobile = cnn.Decrypt("111", Page.RouteData.Values("Number"))
    End Sub
End Class
