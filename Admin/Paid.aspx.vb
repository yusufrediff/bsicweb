Imports System.Data
Imports Con
Partial Class Admin_Paid
    Inherits System.Web.UI.Page
    Dim cnn As New Conn
    Dim ds As New DataSet()

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
        Session.LCID = 2057
        If Not Page.IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        grd.DataSource = Nothing
        grd.DataBind()
        ds = cnn.BindStudents(6) '5=REGISTERED, 6=PAID, 7=ENROLLED
        'If ds.Tables(0).Rows.Count > 0 Then
        grd.DataSource = ds
        grd.DataBind()
        'grd.UseAccessibleHeader = True
        'grd.HeaderRow.TableSection = TableRowSection.TableHeader
        'Dim cells As TableCellCollection
        'cells = grd.HeaderRow.Cells
        'cells(0).Attributes.Add("data-class", "expand")
        'cells(1).Attributes.Add("data-class", "expand")
        'cells(2).Attributes.Add("data-class", "expand")
        'cells(3).Attributes.Add("data-class", "expand")
        'Else
        'grd.EmptyDataText = "No Record found"
        'End If
    End Sub
End Class
