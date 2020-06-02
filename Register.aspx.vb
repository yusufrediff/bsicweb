Imports Con
Imports System.Data
Partial Class Register
    Inherits System.Web.UI.Page
    Dim cnn As New Conn
    Dim ds As New DataSet()
    Dim STRFileName As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session.LCID = 2057
        If Not Page.IsPostBack Then
            '========== STATE
            cmbState.DataSource = cnn.BindState()
            cmbState.DataValueField = "ID"
            cmbState.DataTextField = "StateName"
            cmbState.DataBind()
            cmbState.Items.Insert(0, "Select")
            '========== CATEGORY
            cmbCast.DataSource = cnn.BindCategory()
            cmbCast.DataValueField = "ID"
            cmbCast.DataTextField = "fldName"
            cmbCast.DataBind()
            cmbCast.Items.Insert(0, "Select")
            '========== RELIGION
            cmbReligion.DataSource = cnn.BindReligion()
            cmbReligion.DataValueField = "ID"
            cmbReligion.DataTextField = "fldName"
            cmbReligion.DataBind()
            cmbReligion.Items.Insert(0, "Select")
            '========== CLASS
            cmbClass.DataSource = cnn.BindClass()
            cmbClass.DataValueField = "ID"
            cmbClass.DataTextField = "fldName"
            cmbClass.DataBind()
            cmbClass.Items.Insert(0, "Select")
            '========== PREV CLASS
            cmbPrevClass.DataSource = cnn.BindClass()
            cmbPrevClass.DataValueField = "ID"
            cmbPrevClass.DataTextField = "fldName"
            cmbPrevClass.DataBind()
            cmbPrevClass.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtAadhar.Text <> "" Then
            If Len(txtAadhar.Text) <> 12 Then
                lblError.Text = "Please Enter valid Aadhaar No !"
                lblError.Visible = True
                txtAadhar.Focus()
                Exit Sub
            End If
        End If
        If Not IsDate(txtDOB.Text) Then
            lblError.Text = "Please Enter valid DOB !"
            lblError.Visible = True
            txtDOB.Focus()
            Exit Sub
        End If


        Try
            Dim savePath As String = Server.MapPath("/Upload/")
            If (FileUpload1.HasFile) Then
                Dim fileName As String = FileUpload1.FileName
                STRFileName = Left(fileName, 4) & "_" & cnn.RandomPW(5) & Right(fileName, 5)
                If Len(STRFileName) > 200 Then
                    lblError.Visible = True
                    lblError.Text = "Invalid name of File...!"
                    Exit Sub
                End If
                savePath += STRFileName
                FileUpload1.SaveAs(savePath)
            End If

            Dim ival As DBValue = cnn.InsertStudents(Val(cmbClass.SelectedValue), cmbClass.SelectedItem.Text, txtName.Text, cnn.GetDate(txtDOB.Text), cmbSex.SelectedValue, txtMobile.Text, txtAadhar.Text,
            txtMotherName.Text, txtFatherName.Text, txtFatherMobile.Text, txtOccupation.Text, Val(cmbReligion.SelectedValue), cmbReligion.SelectedItem.Text, Val(cmbCast.SelectedValue), cmbCast.SelectedItem.Text,
            txtResidentialAddress.Text, txtCity.Text, txtVillage.Text, Val(cmbState.SelectedValue), txtPinCode.Text,
            txtPermanentAddress.Text, txtCity.Text, txtVillage.Text, Val(cmbState.SelectedValue), txtPinCode.Text, txtPrevSchool.Text, Val(cmbPrevClass.SelectedValue), cmbPrevClass.SelectedItem.Text,
            Val(txtPassingYear.Text), Val(txtObMarks.Text), STRFileName)

            If ival.Value = 0 Then
                Response.Redirect("/Success/" & cnn.Encrypt("111", ival.ErrPass) & "/" & cnn.Encrypt("111", txtName.Text) & "/" _
                                  & cnn.Encrypt("111", txtFatherMobile.Text))
            ElseIf ival.Value = -1 Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "", "alert('Duplicate Record  !')", True)
                txtName.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
