Imports Con
Imports System.Data
Partial Class Admin_ChangePassword
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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If cnn.CheckMemberPass(txtID.Text, txtOLDPass.Text) = False Then
        '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "", "alert('Wrong Password, Please check  !');", True)
        '    txtOLDPass.Focus()
        '    Exit Sub
        'End If
        ''------------------------------------

        'Dim bBool As Boolean = False
        'Try
        '    bBool = cnn.UpdateMemberPass(txtID.Text, txtNewPass.Text, "L")
        '    If bBool = True Then
        '        Dim SMS_Result As String = ""
        '        SMS_Result = sSMS.CallAPI(lblMobileNo.Value, sSMS.SendMessage("CHANGE", txtName.Text, txtID.Text))
        '    End If
        '    Response.Redirect("/Home")
        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "", "alert('Something went Wrong  !');", True)
        'End Try
    End Sub
End Class
