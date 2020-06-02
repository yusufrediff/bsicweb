Imports System.Data
Imports Con
Partial Class Admin_Default
    Inherits System.Web.UI.Page
    Dim cnn As New Conn
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.Cookies("AdminLogin") IsNot Nothing Then
            If cnn.Decrypt("111", Request.Cookies("AdminLogin")("aLoginSuccess")) <> "T" Then
                Response.Redirect("~/Admin/Login")
            End If
        Else
            Response.Redirect("~/Admin/Login")
        End If
        Session.LCID = 2057
        '--------------------------
    End Sub
End Class
