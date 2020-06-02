
Partial Class Admin_Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ckAdmin As New HttpCookie("AdminLogin")
        ckAdmin.Values("aID") = 0
        ckAdmin.Values("aUserName") = ""
        ckAdmin.Values("aName") = ""
        ckAdmin.Values("aType") = ""
        ckAdmin.Values("aLoginSuccess") = "F"
        ckAdmin.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(ckAdmin)
        Response.Redirect("~/Admin/Login")
    End Sub
End Class
