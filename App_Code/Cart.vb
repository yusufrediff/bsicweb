Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.IO
Imports System.Web.Mail
Imports System.Data.SqlClient
Imports System.Collections

Namespace nsComm
    Public Structure CommCart
        Public cPackageID As Integer
        Public cServiceID As Integer
        Public cProviderID As Integer
        Public cCommPercentage As Decimal
    End Structure
    Public Class Cart
        Private _ItemsinCart As ArrayList
        Private dtRate As DataTable
        Public Sub New()
            ' TODO: Add constructor logic here
            _ItemsinCart = New ArrayList()
            dtRate = New DataTable("cartComm")
            dtRate.Columns.Add("cPackageID")
            dtRate.Columns.Add("cServiceID")
            dtRate.Columns.Add("cProviderID")
            dtRate.Columns.Add("cCommPercentage")
        End Sub
        Public Sub addCartItem(ByVal item As CommCart)
            'If Not isItemExists(item, 1) Then
            _ItemsinCart.Add(item)
            'End If
        End Sub
        Public ReadOnly Property ItemsinRateCart() As Long
            Get
                Return _ItemsinCart.Count
            End Get
        End Property
        Public Function getRateCart() As DataTable

            Dim objItemArray As [Object]() = New [Object](3) {}
            Dim objcartitem As CommCart
            Dim i As Integer
            dtRate.Rows.Clear()
            For i = 0 To _ItemsinCart.Count - 1

                objcartitem = DirectCast(_ItemsinCart(i), CommCart)
                objItemArray(0) = objcartitem.cPackageID
                objItemArray(1) = objcartitem.cServiceID
                objItemArray(2) = objcartitem.cProviderID
                objItemArray(3) = objcartitem.cCommPercentage
                dtRate.Rows.Add(objItemArray)
            Next
            Return dtRate
        End Function
    End Class
End Namespace