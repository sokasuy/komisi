Public Class CDtSetPrintOutReportAnalisaSuratDokter
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetPrintOutReportAnalisaSuratDokter")
        dt.Columns.Add("bulan", GetType(Integer))
        dt.Columns.Add("tahun", GetType(Integer))
        dt.Columns.Add("periode", GetType(String))
        dt.Columns.Add("kelompok", GetType(String))
        dt.Columns.Add("jumlah", GetType(Integer))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
