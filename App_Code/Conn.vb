Imports Microsoft.VisualBasic

Imports System
Imports System.Data

Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports nsComm
Namespace Con
    Public Class ApplicationItem
        Public m_application_id As String
        Public m_application_package As String
    End Class
    Public Class Conn
        Inherits System.Web.UI.Page
        'Public _connString As String = "server=.;Trusted_Connection=true;database=MarvyROI;Pooling=true;Connection Reset=true;"
        'Public _connString As String = "Server=184.168.47.17; Initial Catalog=DB_Proglanic; uid=dbUser_Prog; pwd=Prog@@lanic123##;Connection Timeout=0; Pooling=true; max pool size=10000"
        Public _connString As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString.ToString()
        '================
        Dim ObjCart As New Cart
        Public cnn As Data.SqlClient.SqlConnection = New SqlClient.SqlConnection(_connString)
        Public cnn2 As Data.SqlClient.SqlConnection = New SqlClient.SqlConnection(_connString)
        Public SRVRDate, SRVRTIME
        Public hEmailID As String = "noreplyyusuf@gmail.com"
        Public hPort As String = "25"
        Public hHost As String = "smtp.gmail.com"
        Public hPassword As String = "VNS@12345"
        Public cnn_SRText As String = "SUPER_DISTRIBUTOR"
        Public cnn_DRText As String = "DISTRIBUTOR"
        Public cnn_RRText As String = "RETAILER"

        Dim strSQL As String
        Dim cmd As New Data.SqlClient.SqlCommand
        Dim dr As Data.SqlClient.SqlDataReader
#Region "GENERAL"


        Public Function SQLquote(ByVal s)
            If IsNothing(s) Then
                SQLquote = "NULL"
            Else
                SQLquote = "'" & Replace(s, "'", "''") & "'"
            End If
        End Function
        Public Function SQLSearch(ByVal s)
            If IsNothing(s) Then
                SQLSearch = "NULL"
            Else
                SQLSearch = "'%" & Replace(s, "'", "''") & "%'"
            End If
        End Function
        Public Function GetDate(ByVal DateTxt As String)
            If DateTxt <> "" Then
                GetDate = Year(DateTxt) & "-" & Format(Month(DateTxt), "00") & "-" & Day(DateTxt)
            End If
        End Function
        Public Function GetCurrentPageName() As String
            Dim sPath As String = Request.Url.AbsolutePath
            Dim oInfo As System.IO.FileInfo = New System.IO.FileInfo(sPath)
            Dim sRet As String = oInfo.Name
            Return sRet
        End Function
        Public Function GetSRVRDate() As Date
            Dim tDate As Date
            Dim strSQL As String = "SELECT CONVERT(DATETIME, CONVERT(VARCHAR(10), DATEADD(minute,330,GETUTCDATE()), 111)) AS dDate"
            Dim cmd As New Data.SqlClient.SqlCommand
            Dim dr As Data.SqlClient.SqlDataReader
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            If dr.Read Then
                If Not IsDBNull(dr.Item("dDate")) Then
                    tDate = dr.Item("dDate")
                End If
            End If
            dr.Close() : cmd.Connection.Close()
            Return tDate
        End Function
        Public Sub OpenConn()
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
        End Sub
        Public Sub CloseConn()
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Sub
        Public Function executeSQL(ByVal cmdtext As String) As Integer
            Try
                OpenConn()
                Dim cmd As New Data.SqlClient.SqlCommand(cmdtext, cnn)
                Return cmd.ExecuteNonQuery()
                CloseConn()
            Catch e As Exception
                Throw e
            End Try
        End Function
        Public Function CheckDuplicate(ByVal sSQL As String) As Boolean
            Dim cmd As Data.SqlClient.SqlCommand
            Dim dr As Data.SqlClient.SqlDataReader
            cmd = New Data.SqlClient.SqlCommand(sSQL, cnn)
            If cmd.Connection.State = 1 Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                dr.Close()
                cmd.Connection.Close()
                Return True
            Else
                dr.Close()
                cmd.Connection.Close()
                Return False
            End If
        End Function
        Public Function Encrypt(ByVal strKey As String, ByVal strData As String) As String
            Dim strValue As String = ""
            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("XXXXXXXXXXXXXXXX", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select
                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))
                ' convert data to byte array
                Dim byteData() As Byte = Encoding.UTF8.GetBytes(strData)
                System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(byteData))
                ' encrypt 
                Dim objDES As New DESCryptoServiceProvider
                Dim objMemoryStream As New MemoryStream
                Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write)
                objCryptoStream.Write(byteData, 0, byteData.Length)
                objCryptoStream.FlushFinalBlock()
                ' convert to string and Base64 encode
                strValue = GetAsString(objMemoryStream.ToArray())
            Else
                strValue = strData
            End If
            Return strValue
        End Function
        Public Function Decrypt(ByVal strKey As String, ByVal strData As String) As String
            Dim strValue As String = ""
            'If strData = "" Then
            '    HttpContext.Current.Response.Redirect("Login.aspx")
            'End If
            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("XXXXXXXXXXXXXXXX", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select
                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))
                ' convert data to byte array and Base64 decode

                Dim byteData(strData.Length) As Byte
                Try
                    byteData = GetAsBytes(strData)
                Catch ex As Exception ' invalid length
                    strValue = strData
                End Try
                If strValue = "" Then
                    Try
                        ' decrypt
                        System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(byteData))
                        Dim objDES As New DESCryptoServiceProvider
                        Dim objMemoryStream As New MemoryStream
                        Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write)
                        objCryptoStream.Write(byteData, 0, byteData.Length)
                        objCryptoStream.FlushFinalBlock()
                        System.Diagnostics.Debug.WriteLine(byteData)
                        ' convert to string
                        Dim objEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
                        strValue = objEncoding.GetString(objMemoryStream.ToArray())
                    Catch ex As Exception ' decryption error
                        strValue = ""
                    End Try
                End If
            Else
                strValue = strData
            End If
            Return strValue
        End Function
        Private Function GetAsString(ByVal arrInput() As Byte) As String
            Dim i As Integer
            Dim sOutput As New StringBuilder(arrInput.Length)
            System.Diagnostics.Debug.WriteLine("Hex - Start")
            For i = 0 To arrInput.Length - 1
                System.Diagnostics.Debug.WriteLine(arrInput(i).ToString("X2") & " // " & arrInput(i).ToString())
                sOutput.Append(arrInput(i).ToString("X2"))
            Next
            System.Diagnostics.Debug.WriteLine("Hex - End")
            Return sOutput.ToString()
        End Function
        Private Function GetAsBytes(ByVal strInput As String) As Byte()
            Dim length As Integer = (strInput.Length / 2)
            Dim bytes(length - 1) As Byte
            System.Diagnostics.Debug.WriteLine("Hex - Start")
            For intCounter As Integer = 0 To (length - 1)
                System.Diagnostics.Debug.WriteLine(strInput.Substring((intCounter * 2), 2) & " // " & Short.Parse(strInput.Substring((intCounter * 2), 2), System.Globalization.NumberStyles.HexNumber).ToString())
                bytes(intCounter) = Short.Parse(strInput.Substring((intCounter * 2), 2), System.Globalization.NumberStyles.HexNumber)
            Next
            System.Diagnostics.Debug.WriteLine("Hex - End")
            Return bytes
        End Function
        Public Sub GetServerDateTime()
            Dim CN As Data.SqlClient.SqlConnection = New Data.SqlClient.SqlConnection(_connString)
            Dim cmdDate As Data.SqlClient.SqlCommand
            Dim drDate As Data.SqlClient.SqlDataReader
            Dim sSQL As String
            sSQL = "Select CONVERT(DATE,DATEADD(MINUTE, 330, GETUTCDATE())) AS SRVRDATE, CAST(CONVERT(CHAR(8),DATEADD(MINUTE, 330, GETUTCDATE()),114) AS DATETIME) AS SRVRTIME"
            cmdDate = New Data.SqlClient.SqlCommand(sSQL, CN)
            If cmdDate.Connection.State = 1 Then cmdDate.Connection.Close()
            cmdDate.Connection.Open()
            drDate = cmdDate.ExecuteReader
            If drDate.Read Then
                SRVRDate = drDate.Item("SRVRDATE")
                SRVRTIME = drDate.Item("SRVRTIME")
            End If
            drDate.Close()
            cmdDate.Connection.Close()
        End Sub
        Function RandomPW(ByVal myLength As Integer) As String
            'These constant are the minimum and maximum length for random
            'length passwords.  Adjust these values to your needs.
            Const minLength = 6
            Const maxLength = 20

            Dim X, Y, strPW

            If myLength = 0 Then
                Randomize()
                myLength = Int((maxLength * Rnd()) + minLength)
            End If


            For X = 1 To myLength
                'Randomize the type of this character
                Y = Int((3 * Rnd()) + 1) '(1) Numeric, (2) Uppercase, (3) Lowercase

                Select Case Y
                    Case 1
                        'Numeric character
                        Randomize()
                        strPW = strPW & Chr(Int((9 * Rnd()) + 48))
                    Case 2
                        'Uppercase character
                        Randomize()
                        strPW = strPW & Chr(Int((25 * Rnd()) + 65))
                    Case 3
                        'Lowercase character
                        Randomize()
                        strPW = strPW & Chr(Int((25 * Rnd()) + 97))

                End Select
            Next

            RandomPW = strPW

        End Function
        Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
            Dim generator As System.Random = New System.Random()
            Return generator.Next(Min, Max)
        End Function
#End Region
#Region "BIND"
        Public Function BindState() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 0)
                Dim da As New Data.SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New System.Data.DataSet()
                da.Fill(ds, "Table1")
                cnn.Close()
                If ds IsNot Nothing Then
                    Return ds
                Else
                    Return Nothing
                End If
                da = Nothing : ds = Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function BindReligion() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 1)
                Dim da As New Data.SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New System.Data.DataSet()
                da.Fill(ds, "Table1")
                cnn.Close()
                If ds IsNot Nothing Then
                    Return ds
                Else
                    Return Nothing
                End If
                da = Nothing : ds = Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function BindCategory() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 2)
                Dim da As New Data.SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New System.Data.DataSet()
                da.Fill(ds, "Table1")
                cnn.Close()
                If ds IsNot Nothing Then
                    Return ds
                Else
                    Return Nothing
                End If
                da = Nothing : ds = Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function BindClass() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 3)
                Dim da As New Data.SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New System.Data.DataSet()
                da.Fill(ds, "Table1")
                cnn.Close()
                If ds IsNot Nothing Then
                    Return ds
                Else
                    Return Nothing
                End If
                da = Nothing : ds = Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function BindStudents(iType As Integer) As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", iType)
                Dim da As New Data.SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                Dim ds As New System.Data.DataSet()
                da.Fill(ds, "Table1")
                cnn.Close()
                If ds IsNot Nothing Then
                    Return ds
                Else
                    Return Nothing
                End If
                da = Nothing : ds = Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
       
#End Region

#Region "INSERT"
        Public Function InsertStudents(ClassID As Integer, ClassText As String, StudentName As String, DOB As String, Sex As String, MobileNo As String, AadhaarNo As String, MotherName As String,
        FatherName As String, FatherMobileNo As String, FatherProfession As String, ReligionID As Integer, ReligionText As String, CategoryID As Integer, CategoryText As String, LocalAddress As String, LocalCity As String, LocalVillage As String, LocalStateID As Integer, LocalZip As String,
        PermanentAddress As String, PermanentCity As String, PermanentVillage As String, PermanentStateID As Integer, PermanentZip As String, PrevSchool As String, PrevClassID As Integer, PrevClassText As String, PrevPassingYear As Integer, PrevObMarks As Integer,
        ImageFileName As String) As DBValue
            Dim iRes As New DBValue
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("BSIC_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 4)
                cmd.Parameters.AddWithValue("@ClassID", ClassID)
                cmd.Parameters.AddWithValue("@ClassText", ClassText)
                cmd.Parameters.AddWithValue("@StudentName", StudentName)
                cmd.Parameters.AddWithValue("@DOB", DOB)
                cmd.Parameters.AddWithValue("@Sex", Sex)
                cmd.Parameters.AddWithValue("@MobileNo", MobileNo)
                cmd.Parameters.AddWithValue("@AadhaarNo", AadhaarNo)
                cmd.Parameters.AddWithValue("@MotherName", MotherName)
                cmd.Parameters.AddWithValue("@FatherName", FatherName)
                cmd.Parameters.AddWithValue("@FatherMobileNo", FatherMobileNo)
                cmd.Parameters.AddWithValue("@FatherProfession", FatherProfession)
                cmd.Parameters.AddWithValue("@ReligionID", ReligionID)
                cmd.Parameters.AddWithValue("@ReligionText", ReligionText)
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID)
                cmd.Parameters.AddWithValue("@CategoryText", CategoryText)
                cmd.Parameters.AddWithValue("@LocalAddress", LocalAddress)
                cmd.Parameters.AddWithValue("@LocalCity", LocalCity)
                cmd.Parameters.AddWithValue("@LocalVillage", LocalVillage)
                cmd.Parameters.AddWithValue("@LocalStateID", LocalStateID)
                cmd.Parameters.AddWithValue("@LocalZip", LocalZip)
                cmd.Parameters.AddWithValue("@PermanentAddress", PermanentAddress)
                cmd.Parameters.AddWithValue("@PermanentCity", PermanentCity)
                cmd.Parameters.AddWithValue("@PermanentVillage", PermanentVillage)
                cmd.Parameters.AddWithValue("@PermanentStateID", PermanentStateID)
                cmd.Parameters.AddWithValue("@PermanentZip", PermanentZip)
                cmd.Parameters.AddWithValue("@PrevSchool", PrevSchool)
                cmd.Parameters.AddWithValue("@PrevClassID", PrevClassID)
                cmd.Parameters.AddWithValue("@PrevClassText", PrevClassText)
                cmd.Parameters.AddWithValue("@PrevPassingYear", PrevPassingYear)
                cmd.Parameters.AddWithValue("@PrevObMarks", PrevObMarks)
                cmd.Parameters.AddWithValue("@ImageFileName", ImageFileName)


                cmd.Parameters.Add("@ParamValue", SqlDbType.Int)
                cmd.Parameters("@ParamValue").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@ParamErrorNO", SqlDbType.VarChar, 1000)
                cmd.Parameters("@ParamErrorNO").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@ParamPass", SqlDbType.VarChar, 10)
                cmd.Parameters("@ParamPass").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                iRes.Value = cmd.Parameters("@ParamValue").Value
                iRes.ErrNo = cmd.Parameters("@ParamErrorNO").Value
                iRes.ErrPass = cmd.Parameters("@ParamPass").Value
                cmd.Parameters.Clear()
                cmd.Connection.Close()

                Return iRes
            Catch ex As Exception
                Return iRes
            End Try
        End Function
#End Region
#Region "UPDATE"
        Public Function UpdateDownTeam() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("KBR_sp_UpdateDownTeam", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function GenerateROI() As DataSet
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("KBR_sp_GenerateROI", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function UpdateMemberPass(ByVal iMemberID As String, ByVal iPass As String, tType As String) As Boolean
            If tType = "L" Then
                strSQL = "UPDATE KBR_tblMembers SET fldPasswordN = " & SQLquote(iPass) & " WHERE MemberID=" & SQLquote(iMemberID)
            End If
            If tType = "T" Then
                strSQL = "UPDATE KBR_tblMembers SET TransactionalPassword = " & SQLquote(iPass) & " WHERE MemberID=" & SQLquote(iMemberID)
            End If
            executeSQL(strSQL)
            Return True
        End Function
        Public Function UpdateMember(iID As String, fldName As String, Mobile_No As String, Address As String, City As String, State As String, PINCode As String, _
        EmailID As String, BankName As String, ByVal BranchName As String, AcNo As String, IFSC As String, PAN As String
        ) As Double
            Try


                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("KBR_sp_Member", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                'cmd.CommandTimeout = 100000
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()

                cmd.Parameters.AddWithValue("@SpType", 2)
                cmd.Parameters.AddWithValue("@MemberID", iID)
                cmd.Parameters.AddWithValue("@MobileNo", Mobile_No)
                cmd.Parameters.AddWithValue("@EmailID", EmailID)
                cmd.Parameters.AddWithValue("@Address", Address)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@State", State)
                cmd.Parameters.AddWithValue("@PINCode", PINCode)
                cmd.Parameters.AddWithValue("@BankName", BankName)
                cmd.Parameters.AddWithValue("@BranchName", BranchName)
                cmd.Parameters.AddWithValue("@AcNo", AcNo)
                cmd.Parameters.AddWithValue("@IFSC", IFSC)
                cmd.Parameters.AddWithValue("@PAN", PAN)


                cmd.Parameters.Add("@ParamValue", SqlDbType.Int)
                cmd.Parameters("@ParamValue").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@ParamErrorNO", SqlDbType.VarChar, 1000)
                cmd.Parameters("@ParamErrorNO").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@ParamPass", SqlDbType.VarChar, 10)
                cmd.Parameters("@ParamPass").Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()
                Dim iVal = cmd.Parameters("@ParamValue").Value
                Dim iError = cmd.Parameters("@ParamErrorNO").Value
                cmd.Parameters.Clear()
                cmd.Connection.Close()
                Return iVal
            Catch ex As Exception
                Return -1
            End Try
        End Function

#End Region
#Region "GET"
        Public Function GetMemberNameByID(MemberID As String) As String
            strSQL = "Select fldName from KBR_tblMembers Where MemberID=" & SQLquote(MemberID)
            If cnn.State = ConnectionState.Open Then cnn.Close()
            cnn.Open()
            Dim iResult As String = ""
            Dim da As New Data.SqlClient.SqlDataAdapter(strSQL, cnn)
            Dim ds As New System.Data.DataSet()
            da.Fill(ds, "Table1")
            cnn.Close()
            If ds IsNot Nothing Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    iResult = ds.Tables(0).Rows(i)(0).ToString()
                Next
            End If
            da = Nothing : ds = Nothing
            Return iResult

        End Function
        Public Function GetMemberNameNumberByID(MemberID As String) As DataSet
            strSQL = "Select fldName, MobileNo from KBR_tblMembers Where MemberID=" & SQLquote(MemberID)
            If cnn.State = ConnectionState.Open Then cnn.Close()
            cnn.Open()
            Dim iResult As String = ""
            Dim da As New Data.SqlClient.SqlDataAdapter(strSQL, cnn)
            Dim ds As New System.Data.DataSet()
            da.Fill(ds, "Table1")
            cnn.Close()
            If ds IsNot Nothing Then
                Return ds
            Else
                Return Nothing
            End If
            da = Nothing : ds = Nothing
        End Function
        Public Function GetPendingTimeByID(MemberID As String, Num As Integer) As String
            strSQL = "Select CONVERT(varchar, DATEADD(hh, 100, eDateTime), 120) AS eDateTime from KBR_tblROIPending Where MemberID=" & SQLquote(MemberID) & " AND TeamNum=" & Val(Num)
            If cnn.State = ConnectionState.Open Then cnn.Close()
            cnn.Open()
            Dim iResult As String = ""
            Dim da As New Data.SqlClient.SqlDataAdapter(strSQL, cnn)
            Dim ds As New System.Data.DataSet()
            da.Fill(ds, "Table1")
            cnn.Close()
            If ds IsNot Nothing Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    iResult = ds.Tables(0).Rows(i)(0).ToString()
                Next
            End If
            da = Nothing : ds = Nothing
            Return iResult

        End Function
#End Region
#Region "CHECK"
        Public Function CheckAdminLogin(ByVal iUserName As String, ByVal iPassword As String) As AdminLogin
            strSQL = "Select ID, fldName, fldUserName, fldPassword, tType, Active From BSIC_tblLogin Where fldUserName=" & SQLquote(iUserName) & " AND fldPassword=" & SQLquote(iPassword) _
            & " AND Active='Y'"
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            Dim _check As New AdminLogin
            If dr.Read Then
                _check._ID = dr.Item("ID")
                _check._Name = dr.Item("fldName")
                _check._UserName = dr.Item("fldUserName")
                _check._Password = dr.Item("fldPassword")
                _check._AccessType = dr.Item("tType")
                _check._Active = dr.Item("Active")
            Else
                _check._ID = 0 : _check._Name = "" : _check._UserName = "" : _check._Password = ""
                _check._AccessType = "" : _check._Active = ""
                dr.Close() : cmd.Connection.Close()
                Return Nothing
            End If
            dr.Close() : cmd.Connection.Close()
            Return _check
        End Function
        Public Function CheckMemberLogin(ByVal iUserName As String, ByVal iPassword As String) As MemberLogin
            'Try


            strSQL = "Select ID, fldName, MemberID, fldPasswordN, MobileNo, mStatus From KBR_tblMembers Where MemberID=" & SQLquote(iUserName) _
                & " AND fldPasswordN=" & SQLquote(iPassword)
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
            cnn.Open()
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            Dim _check As New MemberLogin
            If dr.Read Then
                _check._ID = dr.Item("ID")
                _check._Name = dr.Item("fldName")
                _check._MemberID = dr.Item("MemberID")
                _check._Password = dr.Item("fldPasswordN")
                _check._Status = dr.Item("mStatus") : _check._MobileNo = dr.Item("MobileNo")
            Else
                _check._ID = 0 : _check._Name = "" : _check._MemberID = "" : _check._Password = "" : _check._MobileNo = ""
                _check._Status = ""
                dr.Close() : cmd.Connection.Close()
                Return Nothing
            End If
            dr.Close() : cmd.Connection.Close()
            Return _check
            'Catch ex As Exception
            '    Return Nothing
            'End Try
        End Function
        Public Function CheckDuplicateMemberID(ByVal iID As String) As Boolean
            strSQL = "Select MemberID From KBR_tblMembers Where MemberID=" & SQLquote(iID)
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            Dim bBool As Boolean = False
            If dr.Read Then
                bBool = True
            Else
                bBool = False
            End If
            dr.Close() : cmd.Connection.Close()
            Return bBool
        End Function
        Public Function CheckDupKey(ByVal iKey As String) As Boolean
            Dim IsKey As Boolean = False
            '------------------
            strSQL = "Select ePin from KBR_tblPin Where ePin=" & SQLquote(iKey)
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = 1 Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader
            If dr.Read() Then
                IsKey = True
            Else
                IsKey = False
            End If
            dr.Close()
            cmd.Connection.Close()
            Return IsKey
        End Function
        Public Function CheckMemberPass(ByVal iEmailID As String, ByVal iPass As String) As Boolean
            strSQL = "Select ID From KBR_tblMembers Where MemberID=" & SQLquote(iEmailID) & " AND fldPasswordN = " & SQLquote(iPass)
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            Dim bBool As Boolean = False
            If dr.Read Then
                bBool = True
            Else
                bBool = False
            End If
            dr.Close() : cmd.Connection.Close()
            Return bBool
        End Function
        Public Function CheckMemberIDMobile(MemberID As String, MobileNo As String) As _Members
            strSQL = "Select fldName, MemberID, fldPasswordN, MobileNo From KBR_tblMembers Where MemberID=" & SQLquote(MemberID) & " AND MobileNo  = " & SQLquote(MobileNo)
            cmd = New Data.SqlClient.SqlCommand(strSQL, cnn)
            If cmd.Connection.State = Data.ConnectionState.Open Then cmd.Connection.Close()
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
            Dim _check As New _Members
            If dr.Read Then
                If Not IsDBNull(dr.Item("fldName")) Then _check._fldName = dr.Item("fldName") Else _check._fldName = ""
                If Not IsDBNull(dr.Item("MemberID")) Then _check._MemberID = dr.Item("MemberID") Else _check._MemberID = ""
                If Not IsDBNull(dr.Item("fldPasswordN")) Then _check._fldPassword = dr.Item("fldPasswordN") Else _check._fldPassword = ""
                If Not IsDBNull(dr.Item("MobileNo")) Then _check._MobileNo = dr.Item("MobileNo") Else _check._MobileNo = ""
            Else
                _check._ID = 0
                _check._fldName = ""
                _check._MemberID = 0
                _check._fldPassword = "" : _check._MobileNo = ""
                dr.Close() : cmd.Connection.Close()
                Return Nothing
            End If
            dr.Close() : cmd.Connection.Close()
            Return _check
        End Function
#End Region
#Region "DELETE"
        Public Function DeletePin(ByVal ePin As String) As Boolean
            Try
                Dim cmd As Data.SqlClient.SqlCommand
                cmd = New SqlClient.SqlCommand("KBR_sp_Masters", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Connection.Open()
                cmd.Parameters.AddWithValue("@SpType", 4)
                cmd.Parameters.AddWithValue("@ePin", ePin)
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cmd.Connection.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region
    End Class
    Public Class GridDecorator
        Public Shared Sub MergeRows(gridView As GridView)
            For rowIndex As Integer = gridView.Rows.Count - 2 To 0 Step -1
                Dim row As GridViewRow = gridView.Rows(rowIndex)
                Dim previousRow As GridViewRow = gridView.Rows(rowIndex + 1)

                For i As Integer = 0 To 2
                    If row.Cells(i).Text = previousRow.Cells(i).Text Then
                        row.Cells(i).RowSpan = If(previousRow.Cells(i).RowSpan < 2, 2, previousRow.Cells(i).RowSpan + 1)
                        previousRow.Cells(i).Visible = False
                    End If
                Next
            Next
        End Sub
    End Class
End Namespace

