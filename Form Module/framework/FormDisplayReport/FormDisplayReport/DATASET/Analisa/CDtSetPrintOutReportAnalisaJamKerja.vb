Public Class CDtSetPrintOutReportAnalisaJamKerja
    Inherits DataSet
    Private dt As DataTable

    Public Sub New()
        dt = New DataTable("dtSetPrintOutReportAnalisaJamKerja")
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("kelompok", GetType(String))
        dt.Columns.Add("fpid", GetType(Integer))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("masuk", GetType(TimeSpan))
        dt.Columns.Add("keluar", GetType(TimeSpan))
        dt.Columns.Add("jamkerja", GetType(TimeSpan))
        dt.Columns.Add("banyakjamkerja", GetType(TimeSpan))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class
