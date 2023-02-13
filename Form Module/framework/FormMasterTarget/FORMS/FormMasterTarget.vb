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
    Private arrDefValues(8) As String
    Private tableName(1) As String

    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    Private myDataTableCboSales As New DataTable
    Private myBindingSales As New BindingSource
    Private myDataTableCboItem As New DataTable
    Private myBindingItem As New BindingSource
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
            arrCbo = {"NAMA SALES", "NAMA ITEM"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            stSQL = "SELECT kodesales,namasales,area FROM " & CONN_.schemaKomisi & ".mssales ORDER BY namasales;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboSales, myBindingSales, cboSales, "T_" & cboSales.Name, "kodesales", "namasales", isCboPrepared)

            stSQL = "SELECT kodeitem,namaitem FROM " & CONN_.schemaKomisi & ".mstargetsales GROUP BY kodeitem,namaitem ORDER BY namaitem;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboItem, myBindingItem, cboItem, "T_" & cboItem.Name, "kodeitem", "namaitem", isCboPrepared)

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaKomisi & ".msgeneral WHERE kategori='periode' ORDER BY kode;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriode, myBindingPeriode, cboPeriode, "T_" & cboPeriode.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariPeriode, myBindingCariPeriode, cboCariPeriode, "T_" & cboCariPeriode.Name, "keterangan", "keterangan", isCboPrepared, True)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriodeImport, myBindingPeriodeImport, cboPeriodeImport, "T_" & cboPeriodeImport.Name, "keterangan", "keterangan", isCboPrepared, True)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'mstargetsales' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

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

    Private Sub FormMasterTarget_KeyDown(sender As Object, e As KeyEventArgs) Handles cboSales.KeyDown, cboItem.KeyDown, tbSatuan.KeyDown, cboPeriode.KeyDown, tbQty.KeyDown, tbNominal.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbNominal) Then
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormMasterTarget_KeyDown Error")
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
            If (cboCariPeriode.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl.periode='" & myCStringManipulation.SafeSqlLiteral(cboCariPeriode.SelectedValue) & "')"
            End If

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

            stSQL = "SELECT rid,kodesales as kode_sales,namasales as nama_sales,kodeitem as kode_item,namaitem as nama_item,satuan,periode,qty,nominal,grup,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodesales,sub.namasales,sub.kodeitem,sub.namaitem,sub.satuan,sub.periode,sub.qty,sub.nominal,sub.grup,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodesales,tbl.namasales,tbl.kodeitem,tbl.namaitem,tbl.satuan,tbl.periode,tbl.qty,tbl.nominal,tbl.grup,tbl.created_at,tbl.updated_at " &
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
                .Columns("kode_sales").Frozen = True
                .Columns("nama_sales").Frozen = True
                .Columns("kode_item").Frozen = True
                .Columns("nama_item").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                .Columns("kode_sales").Width = 70
                .Columns("nama_sales").Width = 100
                .Columns("kode_item").Width = 70
                .Columns("nama_item").Width = 150
                .Columns("satuan").Width = 70
                .Columns("periode").Width = 95
                .Columns("qty").Width = 70
                .Columns("nominal").Width = 100
                .Columns("grup").Width = 40

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                .Columns("nominal").DefaultCellStyle.Format = "#,##0;(#,##0)"
                .Columns("qty").DefaultCellStyle.Format = "#,##0;(#,##0)"

                .Columns("nominal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
            cboSales.Enabled = True
            cboItem.Enabled = True
            cboPeriode.Enabled = True
            isDataPrepared = True
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

                    Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data di master target sales " & dgvView.CurrentRow.Cells("kode_sales").Value & " - " & dgvView.CurrentRow.Cells("nama_sales").Value & " untuk item " & dgvView.CurrentRow.Cells("nama_item").Value & " untuk periode " & dgvView.CurrentRow.Cells("periode").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                    If (isConfirm = DialogResult.Yes) Then
                        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                        Call myCShowMessage.ShowDeletedMsg("Data di master target sales " & dgvView.CurrentRow.Cells("kode_sales").Value & " - " & dgvView.CurrentRow.Cells("nama_sales").Value & " untuk item " & dgvView.CurrentRow.Cells("nama_item").Value & " untuk periode " & dgvView.CurrentRow.Cells("periode").Value)
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                    Else
                        Call myCShowMessage.ShowInfo("Penghapusan data di master target sales " & dgvView.CurrentRow.Cells("kode_sales").Value & " - " & dgvView.CurrentRow.Cells("nama_sales").Value & " untuk item " & dgvView.CurrentRow.Cells("nama_item").Value & " untuk periode " & dgvView.CurrentRow.Cells("periode").Value & " dibatalkan oleh user")
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
                    'Sales
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kode_sales").Value) Then
                        For i As Integer = 0 To cboSales.Items.Count - 1
                            If (DirectCast(cboSales.Items(i), DataRowView).Item("kodesales") = dgvView.CurrentRow.Cells("kode_sales").Value) Then
                                cboSales.SelectedIndex = i
                                arrDefValues(1) = dgvView.CurrentRow.Cells("kode_sales").Value
                                arrDefValues(2) = dgvView.CurrentRow.Cells("nama_sales").Value
                                cboSales.Enabled = False
                            End If
                        Next
                    End If
                    'Item
                    If Not IsDBNull(dgvView.CurrentRow.Cells("kode_item").Value) Then
                        For i As Integer = 0 To cboItem.Items.Count - 1
                            If (DirectCast(cboItem.Items(i), DataRowView).Item("kodeitem") = dgvView.CurrentRow.Cells("kode_item").Value) Then
                                cboItem.SelectedIndex = i
                                arrDefValues(3) = dgvView.CurrentRow.Cells("kode_item").Value
                                arrDefValues(4) = dgvView.CurrentRow.Cells("nama_item").Value
                                cboItem.Enabled = False
                            End If
                        Next
                    End If
                    'Satuan
                    If Not IsDBNull(dgvView.CurrentRow.Cells("satuan").Value) Then
                        tbSatuan.Text = dgvView.CurrentRow.Cells("satuan").Value
                        arrDefValues(5) = dgvView.CurrentRow.Cells("satuan").Value
                    End If
                    'Periode
                    If Not IsDBNull(dgvView.CurrentRow.Cells("periode").Value) Then
                        For i As Integer = 0 To cboPeriode.Items.Count - 1
                            If (DirectCast(cboPeriode.Items(i), DataRowView).Item("keterangan") = dgvView.CurrentRow.Cells("periode").Value) Then
                                cboPeriode.SelectedIndex = i
                                arrDefValues(6) = dgvView.CurrentRow.Cells("periode").Value
                                cboItem.Enabled = False
                            End If
                        Next
                    End If
                    'Qty
                    If Not IsDBNull(dgvView.CurrentRow.Cells("qty").Value) Then
                        tbQty.Text = dgvView.CurrentRow.Cells("qty").Value
                        arrDefValues(7) = dgvView.CurrentRow.Cells("qty").Value
                        Call myCStringManipulation.ValidateTextBox(tbQty, "Qty", "#,##0;(#,##0)")
                    End If
                    'Nominal
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nominal").Value) Then
                        tbNominal.Text = dgvView.CurrentRow.Cells("nominal").Value
                        arrDefValues(8) = dgvView.CurrentRow.Cells("nominal").Value
                        Call myCStringManipulation.ValidateTextBox(tbNominal, "Nominal", "#,##0;(#,##0)")
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
                        Dim myDataListPeriode As New DataTable
                        myDataTableExcel.Clear()

                        stSQL = "SELECT KODE_SALES,NAMA_SALES,KODE_ITEM,NAMA_ITEM,SATUAN,GRUP,'" & cboPeriodeImport.SelectedValue & "' as PERIODE,QTY_" & cboPeriodeImport.SelectedValue & ",NOMINAL_" & cboPeriodeImport.SelectedValue & ", '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KODE_ITEM is not null ORDER BY NAMA_SALES,GRUP,NO;"
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

                            stSQL = "SELECT KODE_SALES,'" & cboPeriodeImport.SelectedValue & "' as PERIODE FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KODE_ITEM is not null GROUP BY KODE_SALES,'" & cboPeriodeImport.SelectedValue & "';"
                            myDataListPeriode = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_ListExcel")
                            For i As UShort = 0 To myDataListPeriode.Rows.Count - 1
                                Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "kodesales='" & myDataListPeriode.Rows(i).Item("kode_sales") & "' AND periode='" & myDataListPeriode.Rows(i).Item("periode") & "'", CONN_.dbType)
                            Next
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

    Private Sub tbNumeric_Validated(sender As Object, e As EventArgs) Handles tbQty.Validated, tbNominal.Validated
        Try
            Call myCStringManipulation.CleanInputDouble(sender.Text)
            Call myCStringManipulation.ValidateTextBox(sender, "Numeric", "#,##0;(#,##0)")
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbNumeric_Validated Error")
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        End Try
    End Sub
End Class
