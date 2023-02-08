Public Class CStartup
    Private pathFileSetting As String

    Public Sub StartUp(ByVal _segmen As String, ByRef _programName As String, ByRef _programType As String, ByRef _connMain As Object, ByRef _connLokal As Object, ByRef _dbType As String, ByRef _schemaTmp As String, ByRef _schemaKomisi As String)
        Try
            If (_segmen = "MAIN") Then
                'SEKARANG PAKAI INI DULU
                pathFileSetting = Application.StartupPath & "\SETTING.ini"
                _programName = myCFileIO.ReadIniFile("PROGRAM_INFO", "P_NAME", pathFileSetting)
                _programType = myCFileIO.ReadIniFile("PROGRAM_INFO", "P_TYPE", pathFileSetting)
                'backupType = myCFileIO.ReadIniFile("BACKUP", "B_TIPE", FilePathFileName)

                _dbType = myCFileIO.ReadIniFile("DATABASE", "DBTYPE", pathFileSetting)
                _schemaTmp = myCFileIO.ReadIniFile(_dbType, "SCHEMA_TMP", pathFileSetting)
                _schemaKomisi = myCFileIO.ReadIniFile(_dbType, "SCHEMA_KOMISI", pathFileSetting)
                Call myCDBConnection.SetDBParameter(_connMain, _dbType, "SERVER_NAME", "DB_NAME", "", pathFileSetting, "PORT", "postgres", "1234567", "")
            Else
                'INI GAK DIPAKAI
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "StartUp Error")
        End Try
    End Sub

End Class
