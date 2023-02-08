Public Class FormMasterTarget
    Private isDataPrepared As Boolean
    Private stSQL As String
    Private isNew As Boolean
    Private isExist As Boolean
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cekTambahButton(1) As Boolean
    Private arrDefValues(3) As String
    Private tableName(1) As String

    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    Private myDataTableCboCariPeriode As New DataTable
    Private myBindingCariPeriode As New BindingSource
    Private myDataTableCboPeriodeImport As New DataTable
    Private myBindingPeriodeImport As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaKomisi As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _ConnMain
                .schemaTmp = _schemaTmp
                .schemaKomisi = _schemaKomisi
            End With
            With USER_
                .username = _username
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterTarget Error")
        End Try
    End Sub

    Private Sub FormMasterTarget_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterTarget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"NAMA_SALES", "NAMA_ITEM"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaKomisi & ".msgeneral WHERE kategori='periode' ORDER BY kode;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriode, myBindingPeriode, cboPeriode, "T_" & cboPeriode.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariPeriode, myBindingCariPeriode, cboCariPeriode, "T_" & cboCariPeriode.Name, "keterangan", "keterangan", isCboPrepared, True)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriodeImport, myBindingPeriodeImport, cboPeriodeImport, "T_" & cboPeriodeImport.Name, "keterangan", "keterangan", isCboPrepared, True)

            tableName(0) = CONN_.schemaKomisi & ".mstargetsales"
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTarget_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterTarget_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTarget_Activated Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'OK
        Try
            ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub tbNamaFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNamaFile.Click
        'OK
        Try
            ofd1.Filter = "Excel file (*.xls,*.xlsx)|*.xls;*.xlsx"
            ofd1.FilterIndex = 1
            ofd1.ShowDialog()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNamaFile_Click Error")
        End Try
    End Sub

    Private Sub ofd1_FileOk(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles ofd1.FileOk
        Try
            isDataPrepared = False

            fileAttachment.path = ofd1.FileName
            fileAttachment.name = ofd1.SafeFileName
            fileAttachment.extension = ofd1.SafeFileName.Substring(ofd1.SafeFileName.LastIndexOf("."))

            tbNamaFile.Text = fileAttachment.name

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "ofd1_FileOk Error")
        Finally

        End Try
    End Sub

    Private Sub btnProsesImport_Click(sender As Object, e As EventArgs) Handles btnProsesImport.Click
        Try
            If (Trim(tbNamaSheet.Text).Length > 0) And (Trim(tbNamaFile.Text).Length > 0 And cboPeriodeImport.SelectedIndex <> -1) Then
                If (isDataPrepared) Then
                    If (myCFileIO.SheetExists(tbNamaSheet.Text, fileAttachment.path)) Then
                        CONN_.excelPrvdrType = myCFileIO.ReadIniFile("EXCEL", "PRVDRTYPE", Application.StartupPath & "\SETTING.ini")

                        Call myCDBConnection.SetAndOpenConnForExcel(CONN_.dbExcel, fileAttachment.path, fileAttachment.extension.Replace(".", ""), CONN_.excelPrvdrType)

                        Call myCDBConnection.OpenConn(CONN_.dbMain)

                        Dim myDataTableExcel As New DataTable
                        myDataTableExcel.Clear()

                        stSQL = "SELECT KODE_SALES,NAMA_SALES,KODE_ITEM,NAMA_ITEM,SATUAN,GRUP,'" & cboPeriodeImport.SelectedValue & "' as PERIODE,QTY_" & cboPeriodeImport.SelectedValue & ",NOMINAL_" & cboPeriodeImport.SelectedValue & ", '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KODE_ITEM is not null ORDER BY GRUP,NO;"
                        myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_target_" & cboPeriodeImport.SelectedValue)

                        If (myDataTableExcel.Rows.Count > 0) Then
                            myDataTableExcel.Columns("KODE_SALES").ColumnName = myDataTableExcel.Columns("KODE_SALES").ColumnName.Replace("_", "")
                            myDataTableExcel.Columns("NAMA_SALES").ColumnName = myDataTableExcel.Columns("NAMA_SALES").ColumnName.Replace("_", "")
                            myDataTableExcel.Columns("KODE_ITEM").ColumnName = myDataTableExcel.Columns("KODE_ITEM").ColumnName.Replace("_", "")
                            myDataTableExcel.Columns("NAMA_ITEM").ColumnName = myDataTableExcel.Columns("NAMA_ITEM").ColumnName.Replace("_", "")

                            myDataTableExcel.Columns("QTY_" & cboPeriodeImport.SelectedValue).ColumnName = "QTY"
                            myDataTableExcel.Columns("QTY").Namespace = "QTY"
                            myDataTableExcel.Columns("NOMINAL_" & cboPeriodeImport.SelectedValue).ColumnName = "NOMINAL"
                            myDataTableExcel.Columns("NOMINAL").Namespace = "NOMINAL"

                            Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(0))

                            Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                        Else
                            Call myCShowMessage.ShowWarning("Tidak ada data target sales untuk periode " & cboPeriodeImport.SelectedValue & " pada excel yang diimport tersebut")
                        End If
                        Call myCDBConnection.CloseConn(CONN_.dbExcel, -1)
                    Else
                        Call myCShowMessage.ShowWarning("Sheet " & tbNamaSheet.Text & " tidak ada di file excel " & fileAttachment.path & "!")
                    End If
                End If
            Else
                Call myCShowMessage.ShowWarning("Pilih dulu file excelnya dan pastikan periodenya dipilih!!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesImport_Click Error")
        Finally
            GC.Collect()
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboPeriode.Validated, cboPeriodeImport.Validated
        Try
            If (isDataPrepared) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub
End Class
