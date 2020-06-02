Imports Con
Partial Class Admin_Login
    Inherits System.Web.UI.Page
    Dim cnn As New Conn

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            lblError.Text = "" : lblError.Visible = False
            Dim _check As AdminLogin = cnn.CheckAdminLogin(txtUserName.Text, txtPassword.Text)
            If _check Is Nothing Then
                lblError.Text = "Invalid User Name or Password  !" : lblError.Visible = True
                txtUserName.Focus()
                Exit Sub
            Else
                Dim ckAdmin As New HttpCookie("AdminLogin")
                ckAdmin.Values("aID") = cnn.Encrypt("111", _check._ID)
                ckAdmin.Values("aUserName") = cnn.Encrypt("111", _check._UserName)
                ckAdmin.Values("aName") = cnn.Encrypt("111", _check._Name)
                ckAdmin.Values("aType") = cnn.Encrypt("111", _check._AccessType)
                ckAdmin.Values("aLoginSuccess") = cnn.Encrypt("111", "T")
                ckAdmin.Expires = DateTime.Now.AddDays(1)
                Response.Cookies.Add(ckAdmin)
                Response.Redirect("/Admin/Default")
            End If
        Catch ex As Exception
            'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "", "alert('" & ex.Message.ToString() & "')", True)
            lblError.Text = ex.Message.ToString() : lblError.Visible = True
        End Try
    End Sub
End Class
