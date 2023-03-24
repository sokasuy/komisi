Public Class FormMasterTOPKhusus
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
    Private arrDefValues(5) As String
    Private tableName(1) As String

    Private myDataTableCboCustomer As New DataTable
    Private myBindingCustomer As New BindingSource
    Private myDataTableCboPeriodeMulai As New DataTable
    Private myBindingPeriodeMulai As New BindingSource
    Private myDataTableCboPeriodeSelesai As New DataTable
    Private myBindingPeriodeSelesai As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaKomisi As String, _ConnMain As Object, _connSQL As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _ConnMain
                .dbSQL = _connSQL
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormMasterTOPKhusus Error")
        End Try
    End Sub

    Private Sub FormMasterTOPKhusus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub
    Private Sub FormMasterTOPKhusus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"KODE CUSTOMER", "NAMA CUSTOMER"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)
            Call myCDBConnection.OpenConn(CONN_.dbSQL)

            stSQL = "SELECT KodeCust as kodecustomer,NamaCust as namacustomer, (NamaCust + ' - ' + KodeCust) as customer FROM MCust GROUP BY KodeCust,NamaCust ORDER BY customer;"
            Call myCDBOperation.SetCbo_(CONN_.dbSQL, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCustomer, myBindingCustomer, cboCustomer, "T_" & cboCustomer.Name, "kodecustomer", "customer", isCboPrepared)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaKomisi & ".msgeneral where kategori='periode' order by kode;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriodeMulai, myBindingPeriodeMulai, cboPeriodeMulaiBerlaku, "T_" & cboPeriodeMulaiBerlaku.Name, "kode", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriodeSelesai, myBindingPeriodeSelesai, cboPeriodeSelesaiBerlaku, "T_" & cboPeriodeSelesaiBerlaku.Name, "kode", "keterangan", isCboPrepared, True)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'mstopkhusus' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

            tableName(0) = CONN_.schemaKomisi & ".mstopkhusus"

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTOPKhusus_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Call myCDBConnection.CloseConn(CONN_.dbSQL, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormMasterTOPKhusus_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.RowCount)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTOPKhusus_Activated Error")
        End Try
    End Sub

    Private Sub FormMasterTOPKhusus_KeyDown(sender As Object, e As KeyEventArgs) Handles cboCustomer.KeyDown, tbTOPKhusus.KeyDown, cboPeriodeMulaiBerlaku.KeyDown, cboPeriodeSelesaiBerlaku.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is cboPeriodeSelesaiBerlaku) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
            If (TypeOf sender Is ComboBox) Then
                sender.DroppedDown = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTOPKhusus_KeyDown Error")
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

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            'If (cboCariPeriode.SelectedIndex <> -1) Then
            '    mGroupCriteria = " AND (tbl.periode='" & myCStringManipulation.SafeSqlLiteral(cboCariPeriode.SelectedValue) & "')"
            'End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                banyakPages = 0
                mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & ";"
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

            stSQL = "SELECT rid,kodecustomer as kode_customer,namacustomer as nama_customer,topkhusus as top_khusus,periodemulaiberlaku as periode_mulai_berlaku,periodeselesaiberlaku as periode_selesai_berlaku,discontinue,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodecustomer,sub.namacustomer,sub.topkhusus,sub.periodemulaiberlaku,sub.periodeselesaiberlaku,sub.discontinue,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodecustomer,tbl.namacustomer,tbl.topkhusus,tbl.periodemulaiberlaku,tbl.periodeselesaiberlaku,tbl.discontinue,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName(0) & " as tbl " &
                            "WHERE ((upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & " " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                            "LIMIT " & offSet &
                            ") sub " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                        "LIMIT " & batas &
                    ") subOrdered " &
                    "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("rid").Visible = False

                .Columns("rid").Frozen = True
                .Columns("kode_customer").Frozen = True
                .Columns("nama_customer").Frozen = True
                .Columns("top_khusus").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("kode_customer").Width = 70
                .Columns("nama_customer").Width = 120
                .Columns("top_khusus").Width = 70
                .Columns("periode_mulai_berlaku").Width = 80
                .Columns("periode_selesai_berlaku").Width = 80

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                '.Columns("nominal").DefaultCellStyle.Format = "#,##0;(#,##0)"
                '.Columns("qty").DefaultCellStyle.Format = "#,##0;(#,##0)"

                .Columns("top_khusus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                    .DisplayIndex = dgvView.Columns("top_khusus").Index + 1
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

    Private Sub dgvView_Sorted(sender As Object, e As EventArgs) Handles dgvView.Sorted
        Try
            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_Sorted Error")
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            tbRecordPage.Text = 1
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            lblEntryType.Text = "INSERT NEW"
            isDataPrepared = True
            cboCustomer.Enabled = True
            cboPeriodeMulaiBerlaku.Enabled = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) + 1 <= banyakPages) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) + 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFBack_Click(sender As Object, e As EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As Object, e As EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub tbRecordPage_GotFocus(sender As Object, e As EventArgs) Handles tbRecordPage.GotFocus
        Try
            logRecordPage = tbRecordPage.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_GotFocus Error")
        End Try
    End Sub

    Private Sub tbRecordPage_Validated(sender As Object, e As EventArgs) Handles tbRecordPage.Validated
        Try
            If (IsNumeric(tbRecordPage.Text)) Then
                Dim temp As Integer
                temp = Integer.Parse(tbRecordPage.Text)
                If (temp > 0 And temp <= banyakPages) Then
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                    logRecordPage = tbRecordPage.Text
                Else
                    Call myCShowMessage.ShowWarning("Tidak ada record pada halaman tersebut!", "Perhatian")
                    tbRecordPage.Text = logRecordPage
                End If
            Else
                Call myCShowMessage.ShowWarning("Inputan harus berupa angka saja", "Perhatian")
                tbRecordPage.Text = logRecordPage
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_Validated Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub dgvView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (dgvView.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = MouseButtons.Right Then
                    If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                        'kondisi ini untuk kalau user meng-klik kanan dalam area dgv bukan di header2nya
                        dgvView.ClearSelection()
                        dgvView.CurrentCell = dgvView.Item(e.ColumnIndex, e.RowIndex)
                        dgvView.Rows(e.RowIndex).Selected = True
                    Else
                        'kondisi ini untuk kalau user mengklik di header dgv nya
                        'selected cell sebelumnya di clear dulu
                        dgvView.ClearSelection()
                        'untuk mindah pointer
                        dgvView.CurrentCell = dgvView.Item(1, e.RowIndex)
                        'untuk select 1 baris penuh
                        dgvView.Rows(e.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellMouseDown Error")
        End Try
    End Sub

    Private Sub dgvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellContentClick
        Try
            If (dgvView.RowCount > 0) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data TOP Khusus untuk " & dgvView.CurrentRow.Cells("kode_customer").Value & " - " & dgvView.CurrentRow.Cells("nama_customer").Value & " yang berlaku dari periode " & dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Data TOP Khusus untuk " & dgvView.CurrentRow.Cells("kode_customer").Value & " - " & dgvView.CurrentRow.Cells("nama_customer").Value & " yang berlaku dari periode " & dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan data TOP Khusus untuk " & dgvView.CurrentRow.Cells("kode_customer").Value & " - " & dgvView.CurrentRow.Cells("nama_customer").Value & " yang berlaku dari periode " & dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value & " dibatalkan oleh user")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    isNew = False
                    lblEntryType.Text = "EDIT"
                    isDataPrepared = False
                    Call myCFormManipulation.ResetForm(gbDataEntry)
                    Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "edit")

                    For i As Integer = 0 To arrDefValues.Count - 1
                        arrDefValues(i) = Nothing
                    Next

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'Customer
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kode_customer").Value) Then
                        For i As Integer = 0 To cboCustomer.Items.Count - 1
                            If (DirectCast(cboCustomer.Items(i), DataRowView).Item("kodecustomer") = dgvView.CurrentRow.Cells("kode_customer").Value) Then
                                cboCustomer.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("kode_customer").Value
                                cboCustomer.Enabled = False
                            End If
                        Next
                    End If
                    'TOP Khusus
                    If Not IsDBNull(dgvView.CurrentRow.Cells("top_khusus").Value) Then
                        tbTOPKhusus.Text = dgvView.CurrentRow.Cells("top_khusus").Value
                        arrDefValues(2) = Double.Parse(dgvView.CurrentRow.Cells("top_khusus").Value)
                        Call myCStringManipulation.ValidateTextBoxNumber(tbTOPKhusus, tbTOPKhusus.Name)
                    End If
                    'Periode Mulai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value) Then
                        For i As Integer = 0 To cboPeriodeMulaiBerlaku.Items.Count - 1
                            If (DirectCast(cboPeriodeMulaiBerlaku.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value) Then
                                cboPeriodeMulaiBerlaku.SelectedIndex = i
                                arrDefValues(3) = dgvView.CurrentRow.Cells("periode_mulai_berlaku").Value
                                'cboPeriodeMulaiBerlaku.Enabled = False
                            End If
                        Next
                    End If
                    'Periode Selesai
                    If Not IsDBNull(dgvView.CurrentRow.Cells("periode_selesai_berlaku").Value) Then
                        For i As Integer = 0 To cboPeriodeSelesaiBerlaku.Items.Count - 1
                            If (DirectCast(cboPeriodeSelesaiBerlaku.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("periode_selesai_berlaku").Value) Then
                                cboPeriodeSelesaiBerlaku.SelectedIndex = i
                                arrDefValues(4) = dgvView.CurrentRow.Cells("periode_selesai_berlaku").Value
                                'cboPeriodeSelesaiBerlaku.Enabled = False
                            End If
                        Next
                    End If
                    'Discontinue
                    If Not IsDBNull(dgvView.CurrentRow.Cells("discontinue").Value) Then
                        cbDiscontinue.Checked = dgvView.CurrentRow.Cells("discontinue").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("discontinue").Value
                    End If
                    isDataPrepared = True
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (cboCustomer.SelectedIndex <> -1 And Trim(tbTOPKhusus.Text).Length > 0 And cboPeriodeMulaiBerlaku.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kodecustomer='" & myCStringManipulation.SafeSqlLiteral(cboCustomer.SelectedValue) & "' and periodemulaiberlaku='" & myCStringManipulation.SafeSqlLiteral(cboPeriodeMulaiBerlaku.SelectedValue) & "'")
                    If Not isExist Then
                        'CREATE NEW
                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(cboCustomer.SelectedValue) & "','" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer")) & "'," & Double.Parse(tbTOPKhusus.Text) & ",'" & myCStringManipulation.SafeSqlLiteral(cboPeriodeMulaiBerlaku.SelectedValue) & "','" & cbDiscontinue.Checked & "'," & ADD_INFO_.newValues
                        newFields = "kodecustomer,namacustomer,topkhusus,periodemulaiberlaku,discontinue," & ADD_INFO_.newFields
                        If (cboPeriodeSelesaiBerlaku.SelectedIndex <> -1) Then
                            newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(cboPeriodeSelesaiBerlaku.SelectedValue) & "'"
                            newFields &= ",periodeselesaiberlaku"
                        End If
                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)
                        Call myCShowMessage.ShowSavedMsg("Data di master TOP Khusus untuk " & cboCustomer.SelectedValue & " - " & DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer") & " yang berlaku dari periode " & cboPeriodeMulaiBerlaku.SelectedValue)
                        Call btnTampilkan_Click(sender, e)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowWarning("Sudah ada data di master TOP Khusus untuk " & cboCustomer.SelectedValue & " - " & DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer") & " yang berlaku dari periode " & cboPeriodeMulaiBerlaku.SelectedValue & " !!")
                    End If
                Else
                    'UDPATE
                    Dim foundRows() As DataRow
                    updateString = Nothing
                    foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    If (arrDefValues(1) <> Trim(cboCustomer.SelectedValue)) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kodecustomer='" & myCStringManipulation.SafeSqlLiteral(cboCustomer.SelectedValue) & "' and periodemulaiberlaku='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboPeriodeMulaiBerlaku.SelectedItem, DataRowView).Item("keterangan")) & "'")
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "kodecustomer=" & IIf(cboCustomer.SelectedIndex <> -1, "Null", "'" & myCStringManipulation.SafeSqlLiteral(cboCustomer.SelectedValue) & "'") & ",namacustomer=" & IIf(cboCustomer.SelectedIndex <> -1, "Null", "'" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer")) & "'")
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kode_customer") = Trim(cboCustomer.SelectedValue)
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nama_customer") = Trim(DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer"))
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Customer " & DirectCast(cboCustomer.SelectedItem, DataRowView).Item("customer") & " sudah terdaftar di periode yang sama!" & ControlChars.NewLine & "Customer tidak boleh kembar untuk 1 periode yang sama!!")
                        End If
                    End If
                    If (arrDefValues(2) <> Double.Parse(tbTOPKhusus.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "topkhusus=" & Double.Parse(tbTOPKhusus.Text)
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("top_khusus") = Double.Parse(tbTOPKhusus.Text)
                        End If
                    End If
                    If (arrDefValues(3) <> Trim(DirectCast(cboPeriodeMulaiBerlaku.SelectedItem, DataRowView).Item("keterangan"))) Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "kodecustomer='" & myCStringManipulation.SafeSqlLiteral(cboCustomer.SelectedValue) & "' and periodemulaiberlaku='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboPeriodeMulaiBerlaku.SelectedItem, DataRowView).Item("keterangan")) & "'")
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "periodemulaiberlaku='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboPeriodeMulaiBerlaku.SelectedItem, DataRowView).Item("keterangan")) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("periode_mulai_berlaku") = Trim(DirectCast(cboPeriodeMulaiBerlaku.SelectedItem, DataRowView).Item("keterangan"))
                            End If
                        Else
                            Call myCShowMessage.ShowWarning("Customer " & DirectCast(cboCustomer.SelectedItem, DataRowView).Item("customer") & " sudah terdaftar di periode yang sama!" & ControlChars.NewLine & "Customer tidak boleh kembar untuk 1 periode yang sama!!")
                        End If
                    End If
                    If (cboPeriodeSelesaiBerlaku.SelectedIndex <> -1) Then
                        If (arrDefValues(4) <> Trim(DirectCast(cboPeriodeSelesaiBerlaku.SelectedItem, DataRowView).Item("keterangan"))) Then
                            updateString = IIf(IsNothing(updateString), "", ",") & "periodeselesaiberlaku='" & myCStringManipulation.SafeSqlLiteral(DirectCast(cboPeriodeSelesaiBerlaku.SelectedItem, DataRowView).Item("keterangan")) & "'"
                            If (foundRows.Length > 0) Then
                                myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("periode_selesai_berlaku") = Trim(DirectCast(cboPeriodeSelesaiBerlaku.SelectedItem, DataRowView).Item("keterangan"))
                            End If
                        End If
                    Else
                        updateString = IIf(IsNothing(updateString), "", ",") & "periodeselesaiberlaku=Null"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("periode_selesai_berlaku") = DBNull.Value
                        End If
                    End If
                    If (arrDefValues(5) <> cbDiscontinue.Checked) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "discontinue='" & cbDiscontinue.Checked & "'"
                        If (foundRows.Length > 0) Then
                            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("discontinue") = cbDiscontinue.Checked
                        End If
                    End If
                    If Not IsNothing(updateString) Then
                        updateString &= "," & ADD_INFO_.updateString
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), updateString, "rid=" & arrDefValues(0))
                        Call myCShowMessage.ShowUpdatedMsg("Data di master TOP Khusus untuk " & cboCustomer.SelectedValue & " - " & DirectCast(cboCustomer.SelectedItem, DataRowView).Item("namacustomer") & " yang berlaku dari periode " & cboPeriodeMulaiBerlaku.SelectedValue)

                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                cboCustomer.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub tbTOPKhusus_Validated(sender As Object, e As EventArgs) Handles tbTOPKhusus.Validated
        Try
            Call myCStringManipulation.CleanInputDouble(sender.Text)
            Call myCStringManipulation.ValidateTextBoxNumber(sender, sender.Name)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbTOPKhusus_Validated Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboCustomer.Validated, cboPeriodeMulaiBerlaku.Validated, cboPeriodeSelesaiBerlaku.Validated
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
