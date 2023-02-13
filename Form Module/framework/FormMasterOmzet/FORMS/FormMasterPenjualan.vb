Public Class FormMasterPenjualan

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
    Private arrDefValues(8) As String
    Private tableName(1) As String

    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    Private myDataTableCboCariSales As New DataTable
    Private myBindingCariSales As New BindingSource
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterPenjualan Error")
        End Try
    End Sub

    Private Sub FormMasterPenjualan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormMasterPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            'arrCbo = {"NAMA CUSTOMER", "NO NOTA", "PERIODE"}
            'cboKriteria.Items.AddRange(arrCbo)
            'cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT kodesales,namasales,area FROM " & CONN_.schemaKomisi & ".mssales ORDER BY namasales;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariSales, myBindingCariSales, cboCariSales, "T_" & cboCariSales.Name, "kodesales", "namasales", isCboPrepared)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            rbCariPenjualanPerOutlet.Checked = True
            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'trpenjualanperoutlet' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

            tableName(0) = CONN_.schemaKomisi & ".trpenjualanperoutlet"
            tableName(1) = CONN_.schemaKomisi & ".trpenjualanperitem"
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterPenjualan_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub FormMasterPenjualan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterPenjualan_Activated Error")
        End Try
    End Sub

    Private Sub FormMasterPenjualan_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                'If (sender Is tbNominal) Then
                'Call btnSimpan_Click(btnSimpan, e)
                'End If
                If (sender Is tbCari) Then
                    'Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
            If (TypeOf sender Is ComboBox) Then
                sender.DroppedDown = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterPenjualan_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing
            Dim mWhereString

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            If (cboCariSales.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl.periode='" & myCStringManipulation.SafeSqlLiteral(cboCariSales.SelectedValue) & "')"
            End If

            If (mSelectedCriteria = "NAMA CUSTOMER" Or mSelectedCriteria = "NO NOTA" Or mSelectedCriteria = "NAMA ITEM") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
            ElseIf (mSelectedCriteria = "TGL NOTA") Then
                mWhereString = "(tbl." & mSelectedCriteria & ">='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and tbl." & mSelectedCriteria & "<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') "
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                If (rbCariPenjualanPerOutlet.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl WHERE " & mWhereString & " " & mGroupCriteria & ";"
                ElseIf (rbCariPenjualanPerItem.Checked) Then
                    stSQL = ""
                End If
                mJumlah = Integer.Parse(myCDBOperation.GetDataIndividual(myConn, myComm, myReader, stSQL))

                If (mJumlah > 10) Then
                    banyakPages = mJumlah / 10
                Else
                    banyakPages = 1
                End If
                tempSisa = mJumlah Mod 10
                If (tempSisa < 5 And tempSisa > 0 And mJumlah > 10) Then
                    'karena 5 ke atas dibulatkan ke atas
                    'misal 15/10 hasilnya adalah 2
                    'sedangkan kalau 14/10 hasilnya adalah 1
                    'jadi kalau sisanya kurang dari 5, maka halaman ditambah 1
                    banyakPages = banyakPages + 1
                End If
                gantiKriteria = False
            End If
            lblOfPages.Text = "Of: " & banyakPages & " Pages"

            If (mJumlah - offSet < 0) Then
                If (mJumlah <> 0) Then
                    batas = mJumlah Mod 10
                Else
                    Call myCShowMessage.ShowWarning("Belum ada data tersedia", "Perhatian")
                    batas = 10
                End If
            Else
                batas = 10
            End If

            If (rbCariPenjualanPerOutlet.Checked) Then
                stSQL = "SELECT rid,kodesales as kode_sales,namasales as nama_sales,nonota as no_nota,tglnota as tgl_nota,kodecustomer as kode_customer,namacustomer as nama_customer,tgljatuhtempo as tgl_jatuh_tempo,nilai,pot1,pot2,dpp,ppn,pph,jumlah,lunas,jmlharilunas as jml_hari_lunas,overdue,topkhusus as top_khusus,ignoreoverdue as ignore_overdue,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodesales,sub.namasales,sub.kodecustomer,sub.namacustomer,sub.tglnota,sub.tgljatuhtempo,sub.nonota,sub.nilai,sub.pot1,sub.pot2,sub.dpp,sub.ppn,sub.pph,sub.jumlah,sub.lunas,sub.jmlharilunas,sub.overdue,sub.topkhusus,sub.ignoreoverdue,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodesales,tbl.namasales,tbl.kodecustomer,tbl.namacustomer,tbl.tglnota,tbl.tgljatuhtempo,tbl.nonota,tbl.nilai,tbl.pot1,tbl.pot2,tbl.dpp,tbl.ppn,tbl.pph,tbl.jumlah,tbl.lunas,tbl.jmlharilunas,tbl.overdue,tbl.topkhusus,tbl.ignoreoverdue,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName(0) & " as tbl " &
                            "WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & " " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                            "LIMIT " & offSet &
                            ") sub " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                        "LIMIT " & batas &
                    ") subOrdered " &
                    "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"
            ElseIf (rbCariPenjualanPerItem.Checked) Then
                stSQL = ""
            End If
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False

                .Columns("rid").Frozen = True
                .Columns("kode_sales").Frozen = True
                .Columns("nama_sales").Frozen = True
                .Columns("no_nota").Frozen = True
                .Columns("tgl_nota").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("kode_sales").Width = 70
                .Columns("nama_sales").Width = 100

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("tgl_nota").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("tgl_jatuh_tempo").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("lunas").DefaultCellStyle.Format = "dd-MMM-yyyy"
                .Columns("nilai").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("pot1").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("pot2").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("dpp").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("ppn").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("pph").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("jumlah").DefaultCellStyle.Format = "#,##0;(#,##0)"

                .Columns("nilai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("pot1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("pot2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("dpp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("ppn").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("pph").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("jumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With

            With cmbDgvEditButton
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "EDIT"
                    .Name = "edit"
                    .Text = "Edit"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvView.Columns("nama_item").Index + 1
                    dgvView.Columns.Add(cmbDgvEditButton)
                    dgvView.Columns("edit").Width = 70
                    cekTambahButton(0) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                    .Frozen = True
                End If
                .HeaderCell.Style.BackColor = Color.Lime
            End With

            With cmbDgvHapusButton
                If Not (cekTambahButton(1)) Then
                    .HeaderText = "HAPUS"
                    .Name = "delete"
                    .Text = "Hapus Record"
                    .UseColumnTextForButtonValue = True
                    .DisplayIndex = dgvView.ColumnCount
                    dgvView.Columns.Add(cmbDgvHapusButton)
                    dgvView.Columns("delete").Width = 100
                    cekTambahButton(1) = True
                    .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                End If
                .HeaderCell.Style.BackColor = Color.LightSalmon
            End With

            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
            dgvView.RowHeadersWidth = 70

            'atur warna selang seling datagrid
            Call myCDataGridViewManipulation.SetDGVColour(dgvView)

            'ATUR PANEL NAVIGASI
            If (tbRecordPage.Text = 1) Then
                'di awal sendiri
                btnFFBack.Enabled = False
                btnBack.Enabled = False
                If (banyakPages > 1) Then
                    btnFFForward.Enabled = True
                    btnForward.Enabled = True
                Else
                    btnFFForward.Enabled = False
                    btnForward.Enabled = False
                End If
            ElseIf (tbRecordPage.Text > 1) Then
                'di tengah2 halaman record
                btnBack.Enabled = True
                If (tbRecordPage.Text < banyakPages) Then
                    btnFFBack.Enabled = True
                    btnFFForward.Enabled = True
                    btnForward.Enabled = True
                Else
                    btnFFBack.Enabled = True
                    btnFFForward.Enabled = False
                    btnForward.Enabled = False
                End If
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rbCariDGV_CheckedChanged(sender As Object, e As EventArgs) Handles rbCariPenjualanPerOutlet.CheckedChanged, rbCariPenjualanPerItem.CheckedChanged
        Try
            cboKriteria.Items.Clear()
            Dim arrCbo() As String
            If (rbCariPenjualanPerOutlet.Checked) Then
                arrCbo = {"NAMA CUSTOMER", "NO NOTA", "TGL NOTA"}
            ElseIf (rbCariPenjualanPerItem.Checked) Then
                arrCbo = {"NAMA ITEM"}
            End If
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbCariDGV_CheckedChanged Error")
        End Try
    End Sub

    Private Sub cboKriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKriteria.SelectedIndexChanged
        Try
            If (cboKriteria.SelectedItem = "TGL NOTA") Then
                pnlTanggal.Visible = True
                tbCari.Visible = False
            Else
                pnlTanggal.Visible = False
                tbCari.Visible = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKriteria_SelectedIndexChanged Error")
        End Try
    End Sub
End Class
