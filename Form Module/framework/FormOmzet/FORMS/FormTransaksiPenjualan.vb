Public Class FormTransaksiPenjualan

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

    Private myDataTableCboCariPeriode As New DataTable
    Private myBindingCariPeriode As New BindingSource
    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    Private myDataTableCboCariSales As New DataTable
    Private myBindingCariSales As New BindingSource
    Private myDataTableCboPeriodeImport As New DataTable
    Private myBindingPeriodeImport As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean
    Private mViewData As String

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private fileAttachment As fileTempel

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaKomisi As String, _connMain As Object, _connSQL As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _connMain
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

            stSQL = "SELECT kode,keterangan FROM " & CONN_.schemaKomisi & ".msgeneral WHERE kategori='periode' ORDER BY kode;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriode, myBindingPeriode, cboPeriodeImport, "T_" & cboPeriodeImport.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariPeriode, myBindingCariPeriode, cboCariPeriode, "T_" & cboCariPeriode.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT kodesales,namasales,area FROM " & CONN_.schemaKomisi & ".mssales ORDER BY namasales;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariSales, myBindingCariSales, cboCariSales, "T_" & cboCariSales.Name, "kodesales", "namasales", isCboPrepared)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            'Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")

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

    Private Sub FormMasterPenjualan_KeyDown(sender As Object, e As KeyEventArgs) Handles btnKeluar.KeyDown, btnAddNew.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
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
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)
            If (cboCariSales.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl.kodesales='" & myCStringManipulation.SafeSqlLiteral(cboCariSales.SelectedValue) & "')"
            End If

            If (mSelectedCriteria = "NAMACUSTOMER" Or mSelectedCriteria = "NONOTA" Or mSelectedCriteria = "NAMABARANG" Or mSelectedCriteria = "KODEBARANG") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
            ElseIf (mSelectedCriteria = "PERIODE") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") = '" & myCStringManipulation.SafeSqlLiteral(cboCariPeriode.SelectedValue) & "') "
            ElseIf (mSelectedCriteria = "TGLNOTA") Then
                mWhereString = "(tbl." & mSelectedCriteria & ">='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and tbl." & mSelectedCriteria & "<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') "
            End If

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                banyakPages = 0

                If (rbCariPenjualanPerOutlet.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl WHERE " & mWhereString & " " & mGroupCriteria & ";"
                ElseIf (rbCariPenjualanPerItem.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(1) & " as tbl WHERE " & mWhereString & " " & mGroupCriteria & ";"
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
                mViewData = "PENJUALAN PER OUTLET"
                stSQL = "SELECT rid,kodesales as kode_sales,namasales as nama_sales,periode,nonota as no_nota,tglnota as tgl_nota,kodecustomer as kode_customer,namacustomer as nama_customer,tgljatuhtempo as tgl_jatuh_tempo,nilai,pot1,pot2,dpp,ppn,pph,jumlah,lunas,jmlharilunas as jml_hari_lunas,top,overdue,topkhusus as top_khusus,ignoreoverdue as ignore_overdue,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodesales,sub.namasales,sub.periode,sub.kodecustomer,sub.namacustomer,sub.tglnota,sub.tgljatuhtempo,sub.nonota,sub.nilai,sub.pot1,sub.pot2,sub.dpp,sub.ppn,sub.pph,sub.jumlah,sub.lunas,sub.jmlharilunas,sub.top,sub.overdue,sub.topkhusus,sub.ignoreoverdue,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodesales,tbl.namasales,tbl.periode,tbl.kodecustomer,tbl.namacustomer,tbl.tglnota,tbl.tgljatuhtempo,tbl.nonota,tbl.nilai,tbl.pot1,tbl.pot2,tbl.dpp,tbl.ppn,tbl.pph,tbl.jumlah,tbl.lunas,tbl.jmlharilunas,tbl.top,tbl.overdue,tbl.topkhusus,tbl.ignoreoverdue,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName(0) & " as tbl " &
                            "WHERE (" & mWhereString & " ) " & mGroupCriteria & " " &
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
            ElseIf (rbCariPenjualanPerItem.Checked) Then
                mViewData = "PENJUALAN PER ITEM"
                stSQL = "SELECT rid,kodesales as kode_sales,namasales as nama_sales,kodebarang as kode_barang,namabarang as nama_barang,qtyub as qty_ub,qtyuk as qty_uk,bonus,discount,netto,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodesales,sub.namasales,sub.kodebarang,sub.namabarang,sub.qtyub,sub.qtyuk,sub.bonus,sub.discount,sub.netto,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodesales,tbl.namasales,tbl.kodebarang,tbl.namabarang,tbl.qtyub,tbl.qtyuk,tbl.bonus,tbl.discount,tbl.netto,tbl.created_at,tbl.updated_at " &
                            "FROM " & tableName(1) & " as tbl " &
                            "WHERE (" & mWhereString & " ) " & mGroupCriteria & " " &
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
                    .Columns("kode_barang").Frozen = True
                    .Columns("nama_barang").Frozen = True

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
                    .Columns("qty_ub").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("qty_uk").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("bonus").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("discount").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("netto").DefaultCellStyle.Format = "#,##0;(#,##0)"

                    .Columns("qty_ub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("qty_uk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("bonus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("netto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    .Font = New Font("Arial", 8, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With
            End If

            For i As Byte = 0 To cekTambahButton.Length - 1
                cekTambahButton(i) = False
            Next

            With cmbDgvEditButton
                If Not (cekTambahButton(0)) Then
                    .HeaderText = "EDIT"
                    .Name = "edit"
                    .Text = "Edit"
                    .UseColumnTextForButtonValue = True
                    If (rbCariPenjualanPerOutlet.Checked) Then
                        .DisplayIndex = dgvView.Columns("tgl_nota").Index + 1
                    ElseIf (rbcaripenjualanperitem.Checked) Then
                        .DisplayIndex = dgvView.Columns("nama_barang").Index + 1
                    End If
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

    'Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
    '    Try
    '        isNew = True
    '        lblEntryType.Text = "INSERT NEW"
    '        isDataPrepared = True
    '    Catch ex As Exception
    '        Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
    '    End Try
    'End Sub

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

                    If (mViewData = "PENJUALAN PER OUTLET") Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                        If (isConfirm = DialogResult.Yes) Then
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            Call myCShowMessage.ShowDeletedMsg("Data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                        Else
                            Call myCShowMessage.ShowInfo("Penghapusan data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value & " dibatalkan oleh user")
                        End If
                    ElseIf (mViewData = "PENJUALAN PER ITEM") Then

                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
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
                    Me.Cursor = Cursors.WaitCursor
                    If (myCFileIO.SheetExists(tbNamaSheet.Text, fileAttachment.path)) Then
                        CONN_.excelPrvdrType = myCFileIO.ReadIniFile("EXCEL", "PRVDRTYPE", Application.StartupPath & "\SETTING.ini")
                        Call myCDBConnection.SetAndOpenConnForExcel(CONN_.dbExcel, fileAttachment.path, fileAttachment.extension.Replace(".", ""), CONN_.excelPrvdrType)
                        Call myCDBConnection.OpenConn(CONN_.dbMain)
                        Call myCDBConnection.OpenConn(CONN_.dbSQL)

                        Dim myDataTableExcel As New DataTable
                        Dim myDataListPeriode As New DataTable
                        myDataTableExcel.Clear()

                        If (rbPenjualanPerOutlet.Checked) Then
                            'Dim kodeCust As String
                            Dim tblName As String
                            Dim myDataTableInfoNota As New DataTable
                            stSQL = "SELECT KodeSales,NamaSales,'' as KodeCustomer,NamaCust as namacustomer,Tanggal as tglnota,NoNota,Nilai,Pot1,Pot2,DPP,PPN,PPH,JUMLAH,'" & cboPeriodeImport.SelectedValue & "' as PERIODE, '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE NoNota is not null ORDER BY NamaSales,NoNota;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_omzet_" & cboPeriodeImport.SelectedValue)
                            myDataTableExcel.Columns("KodeCustomer").ReadOnly = False
                            myDataTableExcel.Columns.Add("tgljatuhtempo", GetType(Date))
                            myDataTableExcel.Columns.Add("top", GetType(Short))

                            If (myDataTableExcel.Rows.Count > 0) Then
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    If (myDataTableExcel.Rows(i).Item("NoNota").ToString.Substring(0, 1) = "X") Then
                                        tblName = "TReturJual"
                                        'kodeCust = myCDBOperation.GetSpecificRecord(CONN_.dbSQL, CONN_.comm, CONN_.reader, "KodeCust", "TReturJual",, "NoNota='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NoNota")) & "'", "SQLSrv")
                                    Else
                                        tblName = "TJual"
                                        'kodeCust = myCDBOperation.GetSpecificRecord(CONN_.dbSQL, CONN_.comm, CONN_.reader, "KodeCust", "TJual",, "NoNota='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NoNota")) & "'", "SQLSrv")
                                    End If
                                    stSQL = "SELECT KodeCust,TglJTempo FROM " & tblName & " WHERE NoNota='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NoNota")) & "';"
                                    myDataTableInfoNota = myCDBOperation.GetDataTableUsingReader(CONN_.dbSQL, CONN_.comm, CONN_.reader, stSQL, "Tbl_ReturJual")
                                    myDataTableExcel.Rows(i).Item("KodeCustomer") = myDataTableInfoNota.Rows(0).Item("KodeCust")
                                    myDataTableExcel.Rows(i).Item("tgljatuhtempo") = myDataTableInfoNota.Rows(0).Item("TglJTempo")
                                    myDataTableExcel.Rows(i).Item("top") = (myDataTableExcel.Rows(i).Item("tgljatuhtempo") - myDataTableExcel.Rows(i).Item("tglnota")).totalDays

                                    If (i Mod 200 = 0) Then
                                        GC.Collect()
                                    End If
                                Next
                                stSQL = "SELECT KodeSales,'" & cboPeriodeImport.SelectedValue & "' as PERIODE FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeSales is not null GROUP BY KodeSales,'" & cboPeriodeImport.SelectedValue & "';"
                                myDataListPeriode = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_ListExcel")
                                For i As UShort = 0 To myDataListPeriode.Rows.Count - 1
                                    Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "kodesales='" & myDataListPeriode.Rows(i).Item("kodesales") & "' AND periode='" & myDataListPeriode.Rows(i).Item("periode") & "'", CONN_.dbType)
                                Next
                                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(0))

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data target penjualan per outlet untuk periode " & cboPeriodeImport.SelectedValue & " pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbPenjualanPerItem.Checked) Then
                            Dim kodeSales As String = Nothing
                            Dim namaSales As String = Nothing
                            stSQL = "SELECT '' as KodeSales,NamaSales,KodeBrg as kodebarang,NamaBrg as namabarang,QtyUB,QtyUK,Bonus,Discount,Netto, '" & cboPeriodeImport.SelectedValue & "' as PERIODE, '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeBrg is not null ORDER BY NamaSales,NamaBrg;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_omzet_" & cboPeriodeImport.SelectedValue)
                            myDataTableExcel.Columns("KodeSales").ReadOnly = False
                            If (myDataTableExcel.Rows.Count > 0) Then
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    If (namaSales <> myDataTableExcel.Rows(i).Item("NamaSales")) Then
                                        namaSales = myDataTableExcel.Rows(i).Item("NamaSales")
                                        kodeSales = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kodesales", CONN_.schemaKomisi & ".mssales",, "namasales='" & myCStringManipulation.SafeSqlLiteral(namaSales) & "'", CONN_.dbType)
                                    End If
                                    myDataTableExcel.Rows(i).Item("KodeSales") = kodeSales

                                    If (i Mod 200 = 0) Then
                                        GC.Collect()
                                    End If
                                Next
                                stSQL = "SELECT '' as KodeSales,NamaSales,'" & cboPeriodeImport.SelectedValue & "' as PERIODE FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE NamaSales is not null GROUP BY '',NamaSales,'" & cboPeriodeImport.SelectedValue & "';"
                                myDataListPeriode = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_ListExcel")
                                myDataListPeriode.Columns("KodeSales").ReadOnly = False
                                For i As UShort = 0 To myDataListPeriode.Rows.Count - 1
                                    namaSales = myDataListPeriode.Rows(i).Item("NamaSales")
                                    kodeSales = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kodesales", CONN_.schemaKomisi & ".mssales",, "namasales='" & myCStringManipulation.SafeSqlLiteral(namaSales) & "'", CONN_.dbType)
                                    Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(1), "kodesales='" & myDataListPeriode.Rows(i).Item("kodesales") & "' AND periode='" & myDataListPeriode.Rows(i).Item("periode") & "'", CONN_.dbType)
                                Next
                                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(1))

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data target penjualan per item untuk periode " & cboPeriodeImport.SelectedValue & " pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbPiutang.Checked) Then
                        ElseIf (rbTOPKhususDalamKota.Checked) Or (rbTOPKhususLuarKota.Checked) Then
                            stSQL = "SELECT KodeCust,NamaCust,[JT Tempo Khusus] as TopKhusus FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeCust is not null and [JT Tempo Khusus] is not null GROUP BY KodeCust,NamaCust,[JT Tempo Khusus];"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_top_" & cboPeriodeImport.SelectedValue)
                            If (myDataTableExcel.Rows.Count > 0) Then
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    myDataTableExcel.Rows(i).Item("TopKhusus") = myCStringManipulation.CleanInputInteger(myDataTableExcel.Rows(i).Item("TopKhusus"))
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "topkhusus=" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("TopKhusus")), "periode='" & cboPeriodeImport.SelectedValue & "' and kodecustomer='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("KodeCust")) & "'")
                                Next
                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data TOP Khusus pada excel yang diimport tersebut")
                            End If
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
            Call myCDBConnection.CloseConn(CONN_.dbSQL, -1)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rbCariDGV_CheckedChanged(sender As Object, e As EventArgs) Handles rbCariPenjualanPerOutlet.CheckedChanged, rbCariPenjualanPerItem.CheckedChanged
        Try
            cboKriteria.Items.Clear()
            Dim arrCbo() As String
            If (rbCariPenjualanPerOutlet.Checked) Then
                arrCbo = {"NAMA CUSTOMER", "NO NOTA", "TGL NOTA", "PERIODE"}
            ElseIf (rbCariPenjualanPerItem.Checked) Then
                arrCbo = {"KODE BARANG", "NAMA BARANG"}
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
                tbCari.Clear()
                cboCariPeriode.Visible = False
            ElseIf (cboKriteria.SelectedItem = "PERIODE") Then
                pnlTanggal.Visible = False
                tbCari.Visible = False
                tbCari.Clear()
                cboCariPeriode.Visible = True
            Else
                pnlTanggal.Visible = False
                tbCari.Visible = True
                cboCariPeriode.Visible = False
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboKriteria_SelectedIndexChanged Error")
        End Try
    End Sub
End Class
