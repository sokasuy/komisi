﻿Public Class CDtSetPrintOutJadwalPresensi
    Inherits DataSet
    Private dt As DataTable
    Public Sub New()
        dt = New DataTable("dtSetPrintOutJadwalPresensi")
        dt.Columns.Add("lokasi", GetType(String))
        dt.Columns.Add("tanggalawal", GetType(Date))
        dt.Columns.Add("tanggalakhir", GetType(Date))
        dt.Columns.Add("tanggal", GetType(Date))
        dt.Columns.Add("nip", GetType(String))
        dt.Columns.Add("fpid", GetType(Integer))
        dt.Columns.Add("nama", GetType(String))
        dt.Columns.Add("perusahaan", GetType(String))
        dt.Columns.Add("departemen", GetType(String))
        dt.Columns.Add("divisi", GetType(String))
        dt.Columns.Add("bagian", GetType(String))
        dt.Columns.Add("kelompok", GetType(String))
        dt.Columns.Add("katpenggajian", GetType(String))
        dt.Columns.Add("ijin", GetType(String))
        dt.Columns.Add("absen", GetType(String))
        dt.Columns.Add("jadwalmasuk", GetType(TimeSpan))
        dt.Columns.Add("jadwalkeluar", GetType(TimeSpan))
        dt.Columns.Add("masuk", GetType(TimeSpan))
        dt.Columns.Add("keluar", GetType(TimeSpan))
        dt.Columns.Add("jamkerja", GetType(TimeSpan))
        dt.Columns.Add("jamkerjanyata", GetType(TimeSpan))
        dt.Columns.Add("banyakjamkerja", GetType(Double))
        dt.Columns.Add("banyakjamkerjanyata", GetType(Double))
        dt.Columns.Add("shift", GetType(Integer))
        dt.Columns.Add("terlambat", GetType(TimeSpan))
        dt.Columns.Add("pulangcepat", GetType(TimeSpan))
        dt.Columns.Add("jamlembur", GetType(TimeSpan))
        dt.Columns.Add("mulailembur", GetType(TimeSpan))
        dt.Columns.Add("selesailembur", GetType(TimeSpan))
        dt.Columns.Add("spkmulai", GetType(TimeSpan))
        dt.Columns.Add("spkselesai", GetType(TimeSpan))
        dt.AcceptChanges()
        Tables.Add(dt)
    End Sub
End Class