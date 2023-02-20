Public Class CDtSetPrintOutRekapKomisi
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutRekapKomisi")
        dt.Columns.Add("kodesales", GetType(String))
        dt.Columns.Add("namasales", GetType(String))
        dt.Columns.Add("periode", GetType(String))
        dt.Columns.Add("cakupan", GetType(String))
        dt.Columns.Add("target", GetType(Double))
        dt.Columns.Add("omzet", GetType(Double))
        dt.Columns.Add("omzetlm", GetType(Double))
        dt.Columns.Add("omzetbr", GetType(Double))
        dt.Columns.Add("persenpencapaiansales", GetType(Double))
        dt.Columns.Add("sppending", GetType(Double))
        dt.Columns.Add("persensppending", GetType(Double))
        dt.Columns.Add("overdue", GetType(Double))
        dt.Columns.Add("hitomzet", GetType(Double))
        dt.Columns.Add("totalpersen", GetType(Double))
        dt.Columns.Add("komisireg", GetType(Double))
        dt.Columns.Add("targetpimt", GetType(Double))
        dt.Columns.Add("realpimt", GetType(Double))
        dt.Columns.Add("persenpimt", GetType(Double))
        dt.Columns.Add("kmspimt", GetType(Double))
        dt.Columns.Add("totalkms", GetType(Double))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
