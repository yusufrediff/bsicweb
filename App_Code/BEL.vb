Imports Microsoft.VisualBasic
Public Class DBValue
    Public Property Value As Integer
    Public Property ErrNo As String
    Public Property ErrPass As String
End Class
Public Class AdminLogin
    Public Property _ID As Integer
    Public Property _Name As String
    Public Property _UserName As String
    Public Property _Password As String
    Public Property _AccessType As String
    Public Property _Active As String
End Class
Public Class MemberLogin
    Public Property _ID As Integer
    Public Property _Name As String
    Public Property _MemberID As String
    Public Property _Password As String
    Public Property _Status As String
    Public Property _MobileNo As String
End Class
Public Class Masters
    Public Property _ID As Integer
    Public Property _Name As String
    Public Property _tType As String
End Class
Public Class _AdminCIP
    Public Property _ID As Integer
    Public Property _AllChild As Integer
    Public Property _ActiveChild As Integer
    Public Property _InActiveChild As Integer
    Public Property _TotalBusiness As Integer
    Public Property _TodayChild As Integer
    Public Property _TodayBusiness As Integer
End Class
Public Class _CIPDetails
    Public Property _ID As Integer
    Public Property _AllChild As Integer
    Public Property _ActiveChild As Integer
    Public Property _InActiveChild As Integer
    Public Property _DirectChild As Integer
    Public Property _TotalIncome As Integer
    Public Property _WalletBalance As Integer
    Public Property _ActiveID As String
    Public Property _AllCompChild As String
    Public Property _ActiveCompChild As String
End Class
Public Class _Members
    Public Property _ID As Integer
    Public Property _ePin As String
    Public Property _SponsorID As String
    Public Property _MemberID As String
    Public Property _fldPassword As String
    Public Property _TransactionalPassword As String
    Public Property _DOJ As Date
    Public Property _fldName As String
    Public Property _FatherName As String
    Public Property _MobileNo As String
    Public Property _Address As String
    Public Property _City As String
    Public Property _State As String
    Public Property _PINCode As String
    Public Property _Sex As String
    Public Property _DOB As Date
    Public Property _EmailID As String
    Public Property _NomineeName As String
    Public Property _Relation As String
    Public Property _BankName As String
    Public Property _BranchName As String
    Public Property _AcType As String
    Public Property _AcNo As String
    Public Property _IFSC As String
    Public Property _PAN As String
    Public Property _LastPayDate As Date
    Public Property _Status As String
End Class