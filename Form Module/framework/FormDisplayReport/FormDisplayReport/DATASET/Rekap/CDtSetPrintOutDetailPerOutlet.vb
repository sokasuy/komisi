Public Class CDtSetPrintOutDetailPerOutlet
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutDetailPerOutlet")
        dt.Columns.Add("periode", GetType(String))
        dt.Columns.Add("kodesales", GetType(String))
        dt.Columns.Add("namasales", GetType(String))
        dt.Columns.Add("kodecustomer", GetType(String))
        dt.Columns.Add("namacustomer", GetType(String))
        dt.Columns.Add("nonota", GetType(String))
        dt.Columns.Add("tglnota", GetType(Date))
        dt.Columns.Add("tgljatuhtempo", GetType(Date))
        dt.Columns.Add("jumlah", GetType(Double))
        dt.Columns.Add("top", GetType(Short))
        dt.Columns.Add("lunas", GetType(Date))
        dt.Columns.Add("jmlharilunas", GetType(Short))
        dt.Columns.Add("overdue", GetType(Short))
        dt.Columns.Add("ignoreoverdue", GetType(Boolean))
        dt.Columns.Add("topkhusus", GetType(Short))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
