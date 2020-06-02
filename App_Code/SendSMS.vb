Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq
Imports System.Security
Imports System.Net.Security



Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Public Class SendSMS
    Private _Mobile As String
    Private _Message As String
    Public Property Mobile() As String
        Get
            Return _Mobile
        End Get
        Set(ByVal value As String)
            _Mobile = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property
    Public Function WelcomeMessage(ByVal iType As String, ByVal iName As String, ByVal iUserName As String, ByVal iPassword As String) As String
        Dim iMessage As String
        If iType = "WELCOME" Then
            iMessage = "Welcome to Kuber Marketing, Thank you Mr. " & iName & ". Your Member ID - " & iUserName & " and Password - " & iPassword & ". Thanks"
        Else
            iMessage = "Dear " & iName & ". Your Password is " & iPassword & ". Thanks"
        End If
        iMessage = Uri.EscapeDataString(iMessage)
        Return iMessage
    End Function
    Public Function SendMessage(ByVal iType As String, ByVal iName As String, ByVal iUserName As String) As String
        Dim iMessage As String
        If iType = "CHANGE" Then
            iMessage = "Dear " & iName & " ( " & iUserName & " ), Your Password has been changed"
        Else
            iMessage = "Thank you Mr. "
        End If
        iMessage = Uri.EscapeDataString(iMessage)
        Return iMessage
    End Function
    Public Function PaymentMessage(ByVal iName As String, ByVal iAmt As String, ByVal iUserName As String) As String
        Dim iMessage As String
        iMessage = "Dear " & iName & " , Member ID " & iUserName & ", Your Payment has been made with the Amount of Rs." & iAmt & ". Regards Kuber Marketing."
        iMessage = Uri.EscapeDataString(iMessage)
        Return iMessage
    End Function
    Public Function TopUpMessage(ByVal iName As String, ByVal iUserName As String) As String
        Dim iMessage As String
        iMessage = "Dear " & iName & " , Member ID " & iUserName & " has been Topup Successfully. Regards Kuber Marketing."
        iMessage = Uri.EscapeDataString(iMessage)
        Return iMessage
    End Function
    Public Function CallAPI(ByVal Mobile As String, ByVal Message As String) As String
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(Function(sender2 As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True)

        ' Login UserID : superdreams Pwd : super@123
        Dim API_URL As String
        API_URL = "http://sms.totaltechnologies.biz/api/sendhttp.php?authkey=5294ALZsSzxsmMBE5d716690&mobiles=" & Mobile & "&message=" & Message & "&sender=KBRMKT&route=6"
        Dim httpreq As HttpWebRequest = CType(WebRequest.Create(API_URL), HttpWebRequest)
        Try
            Dim httpres As HttpWebResponse = CType(httpreq.GetResponse(), HttpWebResponse)
            Dim sr As StreamReader = New StreamReader(httpres.GetResponseStream())
            Dim results As String = sr.ReadToEnd()
            sr.Close()
            Return results
        Catch
            Return "0"
        End Try
    End Function
    Public Function CallPostAPI(num As String, name As String) As String
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(Function(sender2 As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True)

        Try
            'Dim API_URL, dataString As String
            'Dim client As HttpWebResponse = New HttpWebResponse()
            'dataString = "{'api_key':'e216a0-e07877-fa624d-9550e3-22c290','number':'" + num + "','name':'" + name + "','surname':'a'}"
            'Dim API_Data As New APISender
            'API_Data._api_key = "e216a0-e07877-fa624d-9550e3-22c290" : API_Data._number = num
            'API_Data._name = name : API_Data._surname = "a"

            'Dim response As HttpWebResponse = cli
            'API_URL = "https://www.kwikapi.com/api/v2/dmt/add_customer"
            'Dim httpreq As HttpWebRequest = CType(WebRequest.Create(API_URL), HttpWebRequest)
            'httpreq.Method = "POST"
            'Dim postbytes As Byte() = Encoding.ASCII.GetBytes(dataString)
            'httpreq.ContentType = "application/json; charset=utf-8"
            'httpreq.ContentLength = postbytes.Length

            ''httpreq.Headers.Add("api_key", "e216a0-e07877-fa624d-9550e3-22c290")
            ''httpreq.Headers.Add("number", num)
            ''httpreq.Headers.Add("name", name)
            ''httpreq.Headers.Add("surname", "a")
            'httpreq.GetRequestStream().Write(postbytes, 0, postbytes.Length)
            'Dim httpres As HttpWebResponse = CType(httpreq.GetResponse(), HttpWebResponse)
            'Dim sr As StreamReader = New StreamReader(httpres.GetResponseStream())
            'Dim results As String = sr.ReadToEnd()
            'sr.Close()
            Return ""
        Catch ex As Exception
            Return "0"
        End Try
        'request.GetRequestStream().Write(postBytes, 0, postBytes.Length);
        'byte[] postBytes = Encoding.ASCII.GetBytes(data);
        'HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://api.serverapi.host/api/v1/apiv3/GetDistricts");
        '    request.Method = "POST";
        '    request.ContentType = "application/json; charset=utf-8";
        '    request.Headers.Add("token", "xxxxxxxxxxxxxxxxxx");

        '    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        '    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(0));

        '    string result = streamReader.ReadToEnd();
        '    Response.Write(result);
    End Function
End Class
Public Class APISender
    Public Property _api_key As String
    Public Property _number As String
    Public Property _name As String
    Public Property _surname As String
End Class
