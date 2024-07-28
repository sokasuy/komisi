Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class ReportItem
    Public _description As String
    Public _price As Decimal
    Public _qty As Decimal

    Public Property Description() As String
        Get
            Return _description
        End Get
        Private Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Private Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property

    Public Property Qty() As Integer
        Get
            Return _qty
        End Get
        Private Set(ByVal value As Integer)
            _qty = value
        End Set
    End Property

    Public ReadOnly Property Total As Decimal
        Get
            Return Price * Qty
        End Get
    End Property

End Class
