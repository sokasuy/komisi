Public Class CDtSetPrintOutDetailPerItem
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutDetailPerItem")
        dt.Columns.Add("periode", GetType(String))
        dt.Columns.Add("kodesales", GetType(String))
        dt.Columns.Add("namasales", GetType(String))
        dt.Columns.Add("wilayah", GetType(String))
        dt.Columns.Add("kodeitem", GetType(String))
        dt.Columns.Add("namaitem", GetType(String))
        dt.Columns.Add("satuanub", GetType(String))
        dt.Columns.Add("targetjual", GetType(Integer))
        dt.Columns.Add("nettjual", GetType(Integer))
        dt.Columns.Add("persenjual", GetType(Double))
        dt.Columns.Add("grup", GetType(Byte))
        dt.Columns.Add("minimumtarget", GetType(Double))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
