Public Class FormTransaksiPenjualan

    Private isDataPrepared As Boolean
    Private stSQL As String
    Private isNew As Boolean
    Private isExist As Boolean
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    'Private myDataTableDGVPerOutlet As New DataTable
    'Private myBindingTableDGVPerOutlet As New BindingSource
    'Private myDataTableDGVPerItem As New DataTable
    'Private myBindingTableDGVPerItem As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private arrDefValues(8) As String
    Private tableName(1) As String

    Private myDataTableCboCariPeriode As New DataTable
    Private myBindingCariPeriode As New BindingSource
    Private myDataTableCboPeriode As New DataTable
    Private myBindingPeriode As New BindingSource
    Private myDataTableCboCariSales As New DataTable
    Private myBindingCariSales As New BindingSource
    Private myDataTableCboSalesCetak As New DataTable
    Private myBindingSalesCetak As New BindingSource
    Private myDataTableCboPeriodeImport As New DataTable
    Private myBindingPeriodeImport As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean
    Private contentView As String
    Private mySumJumlah As Double
    Private initialValue As String
    Private isPartialChanged As Boolean
    Private isValueChanged As Boolean

    Private Structure fileTempel
        Dim name As String
        Dim path As String
        Dim extension As String
    End Structure

    Private Structure rekapSales
        Dim target As String
        Dim omzetbruto As String
        Dim omzet As String
        Dim omzetlm As String
        Dim omzetbr As String
        Dim retur As String
        Dim persenpencapaiansales As String
        Dim sppending As String
        Dim persensppending As String
        Dim overdue As String
        Dim hitomzet As String
        Dim totalpersen As String
        Dim komisireg As String
        Dim targetpimt As String
        Dim realpimt As String
        Dim persenpimt As String
        Dim kmspimt As String
        Dim totalkms As String
    End Structure

    Private Structure perhitunganKomisi
        Dim targetomzet As String
        Dim omzetbruto As String
        Dim retur As String
        Dim omzetnett As String
        Dim persenpencapaianomzet As String
        Dim targetpimtrakol As String
        Dim pencapaianpimtrakol As String
        Dim persenpencapaianpimtrakol As String
        Dim hitomzet As String
        Dim ppn As String
        Dim perseninsentifpenjualan As String
        Dim perhitunganinsentifpenjualan As String
        Dim ec As String
        Dim eo As String
        Dim x As String
        Dim y As String
        Dim z As String
        Dim perhitungansetelaheceo As String
        Dim perseninsentifpimtrakol As String
        Dim perhitungansetelahpimtrakol As String
        Dim persenpencapaiantargetitem As String
        Dim persenklaiminsentif As String
        Dim perhitunganinsentifakhir As String
        Dim omzetnett90 As String
        Dim omzetnett10 As String
        Dim perseninsentifpenjualan90 As String
        Dim perhitunganinsentifpenjualan90 As String
        Dim totalperhitunganinsentifpenjualan As String
        Dim persenklaimperhitunganinsentifpenjualan As String
        Dim overdue As String
        Dim persenoverdue As String
        Dim jtpalinglama As String
        Dim note As String
    End Structure

    Private fileAttachment As fileTempel
    Private T_rekapSales As rekapSales
    Private T_perhitunganKomisi As perhitunganKomisi

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaKomisi As String, _connMain As Object, _connSQL As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String, _company As String)
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
                .company = _company
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
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboPeriode, myBindingPeriode, cboPeriode, "T_" & cboPeriode.Name, "keterangan", "keterangan", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariPeriode, myBindingCariPeriode, cboCariPeriode, "T_" & cboCariPeriode.Name, "keterangan", "keterangan", isCboPrepared, True)

            stSQL = "SELECT kodesales,namasales,area FROM " & CONN_.schemaKomisi & ".mssales WHERE company='" & USER_.company & "' ORDER BY namasales;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariSales, myBindingCariSales, cboCariSales, "T_" & cboCariSales.Name, "kodesales", "namasales", isCboPrepared)
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboSalesCetak, myBindingSalesCetak, cboSalesCetak, "T_" & cboSalesCetak.Name, "kodesales", "namasales", isCboPrepared, True)

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
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
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
            Dim mWhereString As String
            Dim filterCompany As String

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            'myDataTable.Reset()
            'myDataTable = Nothing
            'myBindingTable = Nothing

            'myDataTable.Clear()
            'dgvView.Rows.Clear()
            'dgvView.DataSource = Nothing
            'dgvView.Refresh()

            isDataPrepared = False

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

            filterCompany = " (company='" & myCStringManipulation.SafeSqlLiteral(USER_.company) & "')"

            If (cboCariSales.SelectedIndex <> -1) Then
                mGroupCriteria = " AND (tbl.kodesales='" & myCStringManipulation.SafeSqlLiteral(cboCariSales.SelectedValue) & "')"
            End If

            If (mSelectedCriteria = "NAMACUSTOMER" Or mSelectedCriteria = "NONOTA" Or mSelectedCriteria = "NAMAITEM" Or mSelectedCriteria = "KODEITEM") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%') "
            ElseIf (mSelectedCriteria = "PERIODE") Then
                mWhereString = "(upper(tbl." & mSelectedCriteria & ") = '" & myCStringManipulation.SafeSqlLiteral(cboCariPeriode.SelectedValue) & "') "
            ElseIf (mSelectedCriteria = "TGLNOTA") Then
                mWhereString = "(tbl." & mSelectedCriteria & ">='" & Format(dtpAwal.Value.Date, "dd-MMM-yyyy") & "' and tbl." & mSelectedCriteria & "<='" & Format(dtpAkhir.Value.Date, "dd-MMM-yyyy") & "') "
            End If

            mWhereString &= " AND " & filterCompany

            If (gantiKriteria) Then
                Dim tempSisa As Integer
                banyakPages = 0

                If (rbCariPenjualanPerOutlet.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl WHERE " & mWhereString & " " & mGroupCriteria & ";"

                    mySumJumlah = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", tableName(0) & " as tbl", "Sum", mWhereString & " " & mGroupCriteria, CONN_.dbType)
                ElseIf (rbCariPenjualanPerItem.Checked) Then
                    stSQL = "SELECT count(*) FROM " & tableName(1) & " as tbl WHERE " & mWhereString & " " & mGroupCriteria & ";"

                    mySumJumlah = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "(qtyub-bonus)", tableName(1) & " as tbl", "Sum", mWhereString & " " & mGroupCriteria, CONN_.dbType)
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

            dgvView.Columns.Clear()

            If (rbCariPenjualanPerOutlet.Checked) Then
                contentView = "PENJUALAN PER OUTLET"
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
                    '.ReadOnly = True

                    .Columns("rid").Visible = False
                    .Columns("kode_sales").Visible = False
                    .Columns("kode_customer").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("kode_sales").Frozen = True
                    .Columns("nama_sales").Frozen = True
                    .Columns("periode").Frozen = True
                    .Columns("no_nota").Frozen = True
                    .Columns("tgl_nota").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        .Columns(i).ReadOnly = True
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next
                    .Columns("ignore_overdue").ReadOnly = False

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("nama_sales").HeaderText = "SALES"
                    .Columns("nama_customer").HeaderText = "CUSTOMER"
                    .Columns("tgl_jatuh_tempo").HeaderText = "JATUH TEMPO"

                    .Columns("nama_sales").Width = 120
                    .Columns("periode").Width = 100
                    .Columns("no_nota").Width = 110
                    .Columns("tgl_nota").Width = 80
                    .Columns("nama_customer").Width = 150
                    .Columns("tgl_jatuh_tempo").Width = 90
                    .Columns("nilai").Width = 70
                    .Columns("pot1").Width = 50
                    .Columns("pot2").Width = 50
                    .Columns("dpp").Width = 50
                    .Columns("dpp").Width = 50
                    .Columns("ppn").Width = 50
                    .Columns("pph").Width = 50
                    .Columns("jumlah").Width = 70
                    .Columns("lunas").Width = 80
                    .Columns("jml_hari_lunas").Width = 70
                    .Columns("top").Width = 50
                    .Columns("overdue").Width = 70
                    .Columns("ignore_overdue").Width = 90

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
                contentView = "PENJUALAN PER ITEM"
                stSQL = "SELECT rid,kodesales as kode_sales,namasales as nama_sales,periode,kodeitem as kode_item,namaitem as nama_item,qtyub as qty_ub,qtyuk as qty_uk,bonus,jumlah as nett_jual,targetjual as target_jual,persenjual as persen_jual,discount,netto,created_at,updated_at " &
                    "FROM ( " &
                        "SELECT sub.rid,sub.kodesales,sub.namasales,sub.periode,sub.kodeitem,sub.namaitem,sub.qtyub,sub.qtyuk,sub.bonus,sub.jumlah,targetjual,persenjual,sub.discount,sub.netto,sub.created_at,sub.updated_at " &
                        "FROM ( " &
                            "SELECT tbl.rid,tbl.kodesales,tbl.namasales,tbl.periode,tbl.kodeitem,tbl.namaitem,tbl.qtyub,tbl.qtyuk,tbl.bonus,(tbl.qtyub-tbl.bonus) as jumlah,tbl.targetjual,tbl.persenjual,tbl.discount,tbl.netto,tbl.created_at,tbl.updated_at " &
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
                    .Columns("kode_sales").Visible = False
                    .Columns("kode_item").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("kode_sales").Frozen = True
                    .Columns("nama_sales").Frozen = True
                    .Columns("periode").Frozen = True
                    .Columns("kode_item").Frozen = True
                    .Columns("nama_item").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    .Columns("kode_sales").Width = 70
                    .Columns("nama_sales").Width = 120
                    .Columns("periode").Width = 100
                    .Columns("nama_item").Width = 300
                    .Columns("qty_ub").Width = 60
                    .Columns("qty_uk").Width = 60
                    .Columns("bonus").Width = 60
                    .Columns("nett_jual").Width = 70
                    .Columns("target_jual").Width = 70
                    .Columns("persen_jual").Width = 70
                    .Columns("discount").Width = 70
                    .Columns("netto").Width = 70

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("qty_ub").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("qty_uk").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("bonus").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("nett_jual").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("target_jual").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("persen_jual").DefaultCellStyle.Format = "#,##0.00;(#,##0.00)"
                    .Columns("discount").DefaultCellStyle.Format = "#,##0;(#,##0)"
                    .Columns("netto").DefaultCellStyle.Format = "#,##0;(#,##0)"

                    .Columns("qty_ub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("qty_uk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("bonus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("nett_jual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("target_jual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("persen_jual").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("netto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    .Font = New Font("Arial", 8, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With
            End If

            tbSumJumlah.Text = mySumJumlah
            If (rbCariPenjualanPerOutlet.Checked) Then
                myCStringManipulation.ValidateTextBox(tbSumJumlah, tbSumJumlah.Name)
            ElseIf (rbCariPenjualanPerItem.Checked) Then
                myCStringManipulation.ValidateTextBoxNumber(tbSumJumlah, tbSumJumlah.Name)
            End If

            'With cmbDgvEditButton
            '    If Not (cekTambahButton(0)) Then
            '        .HeaderText = "EDIT"
            '        .Name = "edit"
            '        .Text = "Edit"
            '        .UseColumnTextForButtonValue = True
            '        If (rbCariPenjualanPerOutlet.Checked) Then
            '            .DisplayIndex = dgvView.Columns("tgl_nota").Index + 1
            '        ElseIf (rbCariPenjualanPerItem.Checked) Then
            '            .DisplayIndex = dgvView.Columns("nama_item").Index + 1
            '        End If
            '        dgvView.Columns.Add(cmbDgvEditButton)
            '        dgvView.Columns("edit").Width = 70
            '        cekTambahButton(0) = True
            '        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
            '        .Frozen = True
            '    End If
            '    .HeaderCell.Style.BackColor = Color.Lime
            'End With

            'With cmbDgvHapusButton
            '    If Not (cekTambahButton(1)) Then
            '        .HeaderText = "HAPUS"
            '        .Name = "delete"
            '        .Text = "Hapus Record"
            '        .UseColumnTextForButtonValue = True
            '        .DisplayIndex = dgvView.ColumnCount
            '        dgvView.Columns.Add(cmbDgvHapusButton)
            '        dgvView.Columns("delete").Width = 100
            '        cekTambahButton(1) = True
            '        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
            '    End If
            '    .HeaderCell.Style.BackColor = Color.LightSalmon
            'End With

            ''untuk menampilkan auto number pada rowHeaders


            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
            dgvView.RowHeadersWidth = 70

            'atur warna selang seling datagrid
            Call myCDataGridViewManipulation.SetDGVColour(dgvView)

            isDataPrepared = True

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
            'If (rbCariPenjualanPerOutlet.Checked) Then
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            'ElseIf (rbCariPenjualanPerItem.Checked) Then
            '    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGVPerItem, myBindingTableDGVPerItem, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            'End If
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

                'If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                '    Me.Cursor = Cursors.WaitCursor
                '    Call myCDBConnection.OpenConn(CONN_.dbMain)

                '    If (mViewData = "PENJUALAN PER OUTLET") Then
                '        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                '        If (isConfirm = DialogResult.Yes) Then
                '            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                '            Call myCShowMessage.ShowDeletedMsg("Data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value)
                '            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                '        Else
                '            Call myCShowMessage.ShowInfo("Penghapusan data di master penjualan " & dgvView.CurrentRow.Cells("nama_sales").Value & " - " & dgvView.CurrentRow.Cells("no_nota").Value & " untuk outlet " & dgvView.CurrentRow.Cells("nama_customer").Value & " dibatalkan oleh user")
                '        End If
                '    ElseIf (mViewData = "PENJUALAN PER ITEM") Then

                '    End If
                'ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                'End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub dgvView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvView.CellBeginEdit
        Try
            If (isDataPrepared) Then
                If (contentView = "PENJUALAN PER OUTLET") Then
                    If Not IsDBNull(dgvView.CurrentCell.Value) Then
                        initialValue = Trim(dgvView.CurrentCell.Value.ToString)
                    Else
                        initialValue = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellBeginEdit Error")
        End Try
    End Sub

    Private Sub dgvView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellValueChanged
        Try
            If (isDataPrepared) Then
                If (contentView = "PENJUALAN PER OUTLET") Then
                    If Not isPartialChanged Then
                        If Not IsDBNull(dgvView.CurrentCell.Value) Then
                            'kalau tidak null isinya
                            If (initialValue <> (dgvView.CurrentCell.Value.ToString)) Then
                                If (e.ColumnIndex = dgvView.Columns("ignore_overdue").Index) Then
                                    isPartialChanged = True
                                    isValueChanged = True
                                    isPartialChanged = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellValueChanged Error")
        End Try
    End Sub

    Private Sub dgvView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellValidated
        Try
            If (isValueChanged) And Not (isPartialChanged) Then
                If (contentView = "PENJUALAN PER OUTLET") Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)
                    Select Case dgvView.Columns(e.ColumnIndex).DataPropertyName
                        Case "ignore_overdue"
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "" & dgvView.Columns(e.ColumnIndex).DataPropertyName.Replace("_", "") & "='" & dgvView.CurrentCell.Value & "',userid='" & USER_.username & "',updated_at=clock_timestamp()", "rid='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("rid").Value) & "'")
                    End Select
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellValidated Error")
        Finally
            If (isValueChanged) And Not (isPartialChanged) Then
                If (contentView = "PENJUALAN PER OUTLET") Then
                    Me.Cursor = Cursors.Default
                    Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                    isValueChanged = False
                    isPartialChanged = False
                End If
            End If
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
            If (Trim(tbNamaSheet.Text).Length > 0) And (Trim(tbNamaFile.Text).Length > 0 And cboPeriode.SelectedIndex <> -1) Then
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
                            stSQL = "SELECT KodeSales,NamaSales,'' as KodeCustomer,NamaCust as namacustomer,Tanggal as tglnota,NoNota,Nilai,Pot1,Pot2,DPP,PPN,PPH,JUMLAH,'" & cboPeriode.SelectedValue & "' as PERIODE, '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE NoNota is not null ORDER BY NamaSales,NoNota;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_omzet_" & cboPeriode.SelectedValue)
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
                                stSQL = "SELECT KodeSales,'" & cboPeriode.SelectedValue & "' as PERIODE FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeSales is not null GROUP BY KodeSales,'" & cboPeriode.SelectedValue & "';"
                                myDataListPeriode = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_ListExcel")
                                For i As UShort = 0 To myDataListPeriode.Rows.Count - 1
                                    Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "kodesales='" & myDataListPeriode.Rows(i).Item("kodesales") & "' AND periode='" & myDataListPeriode.Rows(i).Item("periode") & "'", CONN_.dbType)
                                Next
                                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(0))

                                'Update company nya
                                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperoutlet as p set company=s.company from " & CONN_.schemaKomisi & ".mssales as s where p.kodesales=s.kodesales and p.periode='" & cboPeriode.SelectedValue & "';"
                                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data target penjualan per outlet untuk periode " & cboPeriode.SelectedValue & " pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbPenjualanPerItem.Checked) Then
                            Dim kodeSales As String = Nothing
                            Dim namaSales As String = Nothing
                            stSQL = "SELECT '' as KodeSales,NamaSales,KodeBrg as kodeitem,NamaBrg as namaitem,QtyUB,QtyUK,Bonus,Discount,Netto, '" & cboPeriode.SelectedValue & "' as PERIODE, '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeBrg is not null ORDER BY NamaSales,NamaBrg;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_omzet_" & cboPeriode.SelectedValue)
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
                                stSQL = "SELECT '' as KodeSales,NamaSales,'" & cboPeriode.SelectedValue & "' as PERIODE FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE NamaSales is not null GROUP BY '',NamaSales,'" & cboPeriode.SelectedValue & "';"
                                myDataListPeriode = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "T_ListExcel")
                                myDataListPeriode.Columns("KodeSales").ReadOnly = False
                                For i As UShort = 0 To myDataListPeriode.Rows.Count - 1
                                    namaSales = myDataListPeriode.Rows(i).Item("NamaSales")
                                    kodeSales = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kodesales", CONN_.schemaKomisi & ".mssales",, "namasales='" & myCStringManipulation.SafeSqlLiteral(namaSales) & "'", CONN_.dbType)
                                    Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(1), "kodesales='" & myDataListPeriode.Rows(i).Item("kodesales") & "' AND periode='" & myDataListPeriode.Rows(i).Item("periode") & "'", CONN_.dbType)
                                Next
                                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableExcel, tableName(1))

                                'Update company nya
                                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperitem as p set company=s.company from " & CONN_.schemaKomisi & ".mssales as s where p.kodesales=s.kodesales and p.periode='" & cboPeriode.SelectedValue & "';"
                                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data target penjualan per item untuk periode " & cboPeriode.SelectedValue & " pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbTOPKhususDalamKota.Checked) Or (rbTOPKhususLuarKota.Checked) Then
                            stSQL = "SELECT KodeCust,NamaCust,[JT Tempo Khusus] as TopKhusus, '" & USER_.username & "' as userid FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE KodeCust is not null and [JT Tempo Khusus] is not null GROUP BY KodeCust,NamaCust,[JT Tempo Khusus];"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_top_" & cboPeriode.SelectedValue)
                            If (myDataTableExcel.Rows.Count > 0) Then
                                Dim topKhusus As Short
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    myDataTableExcel.Rows(i).Item("TopKhusus") = myCStringManipulation.CleanInputInteger(myDataTableExcel.Rows(i).Item("TopKhusus"))
                                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".mstopkhusus", "kodecustomer='" & myDataTableExcel.Rows(i).Item("KodeCust") & "'")
                                    If (isExist) Then
                                        'Kalau sudah ada, maka akan dilakukan pengecekkan, apakah top nya berubah atau tidak, kalau tidak berubah, maka tidak dilakukan apa2
                                        topKhusus = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "topkhusus", CONN_.schemaKomisi & ".mstopkhusus",, "kodecustomer='" & myDataTableExcel.Rows(i).Item("KodeCust") & "'", CONN_.dbType)
                                        If (topKhusus <> myDataTableExcel.Rows(i).Item("TopKhusus")) Then
                                            'Kalau tidak sama baru diupdate
                                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaKomisi & ".mstopkhusus", "topkhusus=" & topKhusus & "," & ADD_INFO_.updateString, "kodecustomer='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("KodeCust")) & "'")
                                        End If
                                    Else
                                        'Kalau belum ada langsung ditambahkan ke tabel mstopkhusus
                                        newValues = "'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("KodeCust")) & "','" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NamaCust")) & "'," & myDataTableExcel.Rows(i).Item("TopKhusus") & ",'" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("userid")) & "'"
                                        newFields = "kodecustomer,namacustomer,topkhusus,userid"
                                        Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, CONN_.schemaKomisi & ".mstopkhusus", newValues, newFields)
                                    End If

                                    If (i Mod 200 = 0) Then
                                        GC.Collect()
                                    End If
                                    'Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "topkhusus=" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("TopKhusus")), "periode='" & cboPeriode.SelectedValue & "' and kodecustomer='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("KodeCust")) & "'")
                                Next
                                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperoutlet as penj set topkhusus=topk.topkhusus,updated_at=clock_timestamp() from " & CONN_.schemaKomisi & ".mstopkhusus as topk where penj.periode='" & cboPeriode.SelectedValue & "' and penj.kodecustomer=topk.kodecustomer;"
                                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data TOP Khusus pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbDataPelunasan.Checked) Then
                            stSQL = "SELECT NoNota,TglNota,TglJurnal,JtGiro FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$] WHERE [Sisa Piutang]=0 ORDER BY NoNota;"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_top_" & cboPeriode.SelectedValue)
                            If (myDataTableExcel.Rows.Count > 0) Then
                                Dim tglLunas As Date
                                Dim tglNota As Date
                                Dim jmlHariLunas As Short
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    If (IsDate(myDataTableExcel.Rows(i).Item("TglJurnal"))) Then
                                        If (myDataTableExcel.Rows(i).Item("TglJurnal") > DateSerial(Now.Year - 5, Now.Month, Now.Day)) Then
                                            tglLunas = myDataTableExcel.Rows(i).Item("TglJurnal")
                                        End If
                                    Else
                                        tglLunas = myDataTableExcel.Rows(i).Item("TglNota")
                                    End If
                                    If Not IsDBNull(myDataTableExcel.Rows(i).Item("JtGiro")) And Not IsNothing(myDataTableExcel.Rows(i).Item("JtGiro")) Then
                                        If (myDataTableExcel.Rows(i).Item("JtGiro") <> "") Then
                                            If (myDataTableExcel.Rows(i).Item("JtGiro") > tglLunas) Then
                                                tglLunas = myDataTableExcel.Rows(i).Item("JtGiro")
                                            End If
                                        End If
                                    End If
                                    If Not IsNothing(tglLunas) Then
                                        tglNota = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "tglnota", tableName(0),, "nonota='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NoNota")) & "'", CONN_.dbType)
                                        jmlHariLunas = (tglLunas - tglNota).TotalDays
                                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "lunas='" & Format(tglLunas, "dd-MMM-yyyy") & "',jmlharilunas=" & jmlHariLunas & ",updated_at=clock_timestamp()", "nonota='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NoNota")) & "'")
                                    End If

                                    If (i Mod 200 = 0) Then
                                        GC.Collect()
                                    End If
                                Next

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data pelunasan piutang pada excel yang diimport tersebut")
                            End If
                        ElseIf (rbTmpTopKhusus.Checked) Then
                            stSQL = "SELECT NamaCust,[TOP KHUSUS] as topkhusus FROM [" & myCStringManipulation.SafeSqlLiteral(tbNamaSheet.Text, 1) & "$];"
                            myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbExcel, CONN_.comm, CONN_.reader, stSQL, "tbl_top_" & cboPeriode.SelectedValue)
                            If (myDataTableExcel.Rows.Count > 0) Then
                                For i As Integer = 0 To myDataTableExcel.Rows.Count - 1
                                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), "topkhusus=" & myDataTableExcel.Rows(i).Item("topkhusus") & ",updated_at=clock_timestamp()", "namacustomer='" & myCStringManipulation.SafeSqlLiteral(myDataTableExcel.Rows(i).Item("NamaCust")) & "' and periode='" & cboPeriode.SelectedValue & "'")

                                    If (i Mod 200 = 0) Then
                                        GC.Collect()
                                    End If
                                Next

                                Call myCShowMessage.ShowInfo("IMPORT SELESAI!!")
                            Else
                                Call myCShowMessage.ShowWarning("Tidak ada data top khusus pada excel yang diimport tersebut")
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
                arrCbo = {"KODE ITEM", "NAMA ITEM"}
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

    Private Sub btnProsesTOPKhusus_Click(sender As Object, e As EventArgs) Handles btnProsesTOPKhusus.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperoutlet as penj set topkhusus=topk.topkhusus,updated_at=clock_timestamp() from " & CONN_.schemaKomisi & ".mstopkhusus as topk where penj.periode='" & cboPeriode.SelectedValue & "' and penj.kodecustomer=topk.kodecustomer and penj.company='" & USER_.company & "';"
                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                Call myCShowMessage.ShowInfo("DONE!!")
            Else
                Call myCShowMessage.ShowWarning("Silahkan tentukan periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesTOPKhusus_Click Error")
        Finally
            If (cboPeriode.SelectedIndex <> -1) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnProsesOverdue_Click(sender As Object, e As EventArgs) Handles btnProsesOverdue.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperoutlet set overdue=jmlharilunas-topkhusus,updated_at=clock_timestamp() where periode='" & cboPeriode.SelectedValue & "' and jmlharilunas is not null and topkhusus is not null and company='" & USER_.company & "';"
                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                Call myCShowMessage.ShowInfo("DONE!!")
            Else
                Call myCShowMessage.ShowWarning("Silahkan tentukan periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesOverdue_Click Error")
        Finally
            If (cboPeriode.SelectedIndex <> -1) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnProsesPencapaianTargetItem_Click(sender As Object, e As EventArgs) Handles btnProsesPencapaianTargetItem.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperitem as p set targetjual=t.qty,updated_at=clock_timestamp() from " & CONN_.schemaKomisi & ".mstargetsales as t where p.periode='" & cboPeriode.SelectedValue & "' and p.kodesales=t.kodesales and p.kodeitem=t.kodeitem and p.company='" & USER_.company & "';"
                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperitem set nettjual=(case when qtyub is null then 0 else qtyub end) - (case when bonus is null then 0 else bonus end) ,updated_at=clock_timestamp() where periode='" & cboPeriode.SelectedValue & "' and company='" & USER_.company & "';"
                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                stSQL = "UPDATE " & CONN_.schemaKomisi & ".trpenjualanperitem set persenjual=(nettjual/targetjual)*100, updated_at=clock_timestamp() where targetjual is not null and nettjual is not null and targetjual>0 and periode='" & cboPeriode.SelectedValue & "' and company='" & USER_.company & "';"
                Call myCDBOperation.ExecuteCmd(CONN_.dbMain, CONN_.comm, stSQL)

                Call myCShowMessage.ShowInfo("DONE!!")
            Else
                Call myCShowMessage.ShowWarning("Silahkan tentukan periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesOverdue_Click Error")
        Finally
            If (cboPeriode.SelectedIndex <> -1) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnProsesRekap_Click(sender As Object, e As EventArgs) Handles btnProsesRekap.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                'Dim lanjut As Boolean
                Dim myDataTableSales As New DataTable


                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                'isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".trrekapsales", "periode='" & cboPeriode.SelectedValue & "' and kodesales='" &  & "'")

                'If (isExist) Then
                '    Dim isConfirm = myCShowMessage.GetUserResponse("apakah mau memproses ulang data rekap sales untuk periode " & cboPeriode.SelectedValue & "?")
                '    If (isConfirm = DialogResult.Yes) Then
                '        Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, CONN_.schemaKomisi & ".trrekapsales", "periode='" & cboPeriode.SelectedValue & "'", CONN_.dbType)
                '        lanjut = True
                '    Else
                '        lanjut = False
                '    End If
                'Else
                '    lanjut = True
                'End If

                'If (lanjut) Then
                stSQL = "SELECT kodesales,namasales,dalamkota,luarkota,luarpulau,company,'" & cboPeriode.SelectedValue & "' as periode, '" & USER_.username & "' as userid FROM " & CONN_.schemaKomisi & ".mssales WHERE company='SRF' ORDER BY namasales;"
                myDataTableSales = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Sales")
                myDataTableSales.Columns.Add("target", GetType(Double))
                myDataTableSales.Columns.Add("omzetbruto", GetType(Double))
                myDataTableSales.Columns.Add("omzet", GetType(Double))
                myDataTableSales.Columns.Add("omzetlm", GetType(Double))
                myDataTableSales.Columns.Add("omzetbr", GetType(Double))
                myDataTableSales.Columns.Add("retur", GetType(Double))
                myDataTableSales.Columns.Add("persenpencapaiansales", GetType(Double))
                myDataTableSales.Columns.Add("sppending", GetType(Double))
                myDataTableSales.Columns.Add("persensppending", GetType(Double))
                myDataTableSales.Columns.Add("overdue", GetType(Double))
                myDataTableSales.Columns.Add("hitomzet", GetType(Double))
                myDataTableSales.Columns.Add("totalpersen", GetType(Double))
                myDataTableSales.Columns.Add("komisireg", GetType(Double))
                myDataTableSales.Columns.Add("targetpimt", GetType(Double))
                myDataTableSales.Columns.Add("realpimt", GetType(Double))
                myDataTableSales.Columns.Add("persenpimt", GetType(Double))
                myDataTableSales.Columns.Add("kmspimt", GetType(Double))
                myDataTableSales.Columns.Add("totalkms", GetType(Double))
                myDataTableSales.Columns.Add("isnew", GetType(Boolean))

                For i As Integer = 0 To myDataTableSales.Rows.Count - 1
                    T_rekapSales.target = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nominal", CONN_.schemaKomisi & ".mstargetsales", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "'")
                    T_rekapSales.omzetbruto = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", CONN_.schemaKomisi & ".trpenjualanperoutlet", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' AND nonota NOT LIKE 'X%'")
                    T_rekapSales.omzet = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", CONN_.schemaKomisi & ".trpenjualanperoutlet", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "'")
                    T_rekapSales.omzetlm = 0
                    T_rekapSales.omzetbr = IIf(IsNothing(T_rekapSales.omzet), 0, T_rekapSales.omzet) - T_rekapSales.omzetlm
                    T_rekapSales.retur = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", CONN_.schemaKomisi & ".trpenjualanperoutlet", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' AND nonota LIKE 'X%'")
                    If Not IsNothing(T_rekapSales.target) Then
                        T_rekapSales.persenpencapaiansales = (T_rekapSales.omzetbr / T_rekapSales.target) * 100
                    Else
                        T_rekapSales.persenpencapaiansales = -1
                    End If
                    T_rekapSales.sppending = 0
                    If Not IsNothing(T_rekapSales.target) Then
                        T_rekapSales.persensppending = (T_rekapSales.sppending / T_rekapSales.target) * 100
                    Else
                        T_rekapSales.persensppending = -1
                    End If
                    T_rekapSales.overdue = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", CONN_.schemaKomisi & ".trpenjualanperoutlet", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and overdue>3 and ignoreoverdue=False")
                    T_rekapSales.hitomzet = IIf(IsNothing(T_rekapSales.omzet), 0, T_rekapSales.omzet) - IIf(IsNothing(T_rekapSales.overdue), 0, T_rekapSales.overdue)
                    T_rekapSales.totalpersen = IIf(T_rekapSales.persenpencapaiansales = -1, 0, T_rekapSales.persenpencapaiansales) + IIf(T_rekapSales.persensppending = -1, 0, T_rekapSales.persensppending)
                    T_rekapSales.komisireg = 0
                    T_rekapSales.targetpimt = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "qty", CONN_.schemaKomisi & ".mstargetsales", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and kodeitem in('OJ0121','OJ0121A')")
                    T_rekapSales.realpimt = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "(qtyub-bonus)", CONN_.schemaKomisi & ".trpenjualanperitem", "Sum", "kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and kodeitem in('OJ0121','OJ0121A')")
                    If Not IsNothing(T_rekapSales.targetpimt) Then
                        T_rekapSales.persenpimt = (T_rekapSales.realpimt / T_rekapSales.targetpimt) * 100
                    Else
                        T_rekapSales.persenpimt = -1
                    End If

                    myDataTableSales.Rows(i).Item("target") = IIf(IsNothing(T_rekapSales.target), 0, T_rekapSales.target)
                    myDataTableSales.Rows(i).Item("omzetbruto") = IIf(IsNothing(T_rekapSales.omzetbruto), 0, T_rekapSales.omzetbruto)
                    myDataTableSales.Rows(i).Item("omzet") = IIf(IsNothing(T_rekapSales.omzet), 0, T_rekapSales.omzet)
                    myDataTableSales.Rows(i).Item("omzetlm") = T_rekapSales.omzetlm
                    myDataTableSales.Rows(i).Item("omzetbr") = T_rekapSales.omzetbr
                    myDataTableSales.Rows(i).Item("retur") = IIf(IsNothing(T_rekapSales.retur), 0, -(T_rekapSales.retur))
                    myDataTableSales.Rows(i).Item("persenpencapaiansales") = IIf(T_rekapSales.persenpencapaiansales = -1, 0, T_rekapSales.persenpencapaiansales)
                    myDataTableSales.Rows(i).Item("sppending") = T_rekapSales.sppending
                    myDataTableSales.Rows(i).Item("persensppending") = IIf(T_rekapSales.persensppending = -1, 0, T_rekapSales.persensppending)
                    myDataTableSales.Rows(i).Item("overdue") = IIf(IsNothing(T_rekapSales.overdue), 0, T_rekapSales.overdue)
                    myDataTableSales.Rows(i).Item("hitomzet") = T_rekapSales.hitomzet
                    myDataTableSales.Rows(i).Item("totalpersen") = T_rekapSales.totalpersen
                    myDataTableSales.Rows(i).Item("komisireg") = T_rekapSales.komisireg
                    myDataTableSales.Rows(i).Item("targetpimt") = IIf(IsNothing(T_rekapSales.targetpimt), 0, T_rekapSales.targetpimt)
                    myDataTableSales.Rows(i).Item("realpimt") = IIf(IsNothing(T_rekapSales.realpimt), 0, T_rekapSales.realpimt)
                    myDataTableSales.Rows(i).Item("persenpimt") = IIf(T_rekapSales.persenpimt = -1, 0, T_rekapSales.persenpimt)

                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".trrekapsales", "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'")
                    If Not isExist Then
                        'kalau masih belum ada
                        'Langsung add new
                        myDataTableSales.Rows(i).Item("isnew") = True
                    Else
                        'Kalau sudah ada, update saja
                        myDataTableSales.Rows(i).Item("isnew") = False
                        updateString = "target=" & myDataTableSales.Rows(i).Item("target") & ",omzetbruto=" & myDataTableSales.Rows(i).Item("omzetbruto") & ",omzet=" & myDataTableSales.Rows(i).Item("omzet") & ",omzetlm=" & myDataTableSales.Rows(i).Item("omzetlm") & ",omzetbr=" & myDataTableSales.Rows(i).Item("omzetbr") & ",retur=" & myDataTableSales.Rows(i).Item("retur") & ",persenpencapaiansales=" & myDataTableSales.Rows(i).Item("persenpencapaiansales") & ",sppending=" & myDataTableSales.Rows(i).Item("sppending") & ",persensppending=" & myDataTableSales.Rows(i).Item("persensppending")
                        updateString &= ",overdue=" & myDataTableSales.Rows(i).Item("overdue") & ",hitomzet=" & myDataTableSales.Rows(i).Item("hitomzet") & ",totalpersen=" & myDataTableSales.Rows(i).Item("totalpersen") & ",komisireg=" & myDataTableSales.Rows(i).Item("komisireg") & ",targetpimt=" & myDataTableSales.Rows(i).Item("targetpimt") & ",realpimt=" & myDataTableSales.Rows(i).Item("realpimt") & ",persenpimt=" & myDataTableSales.Rows(i).Item("persenpimt") & ",updated_at=clock_timestamp()"

                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaKomisi & ".trrekapsales", updateString, "kodesales='" & myDataTableSales.Rows(i).Item("kodesales") & "' and periode='" & cboPeriode.SelectedValue & "'")
                    End If
                Next

                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableSales, CONN_.schemaKomisi & ".trrekapsales", , "isnew")

                Call myCShowMessage.ShowInfo("DONE!!")
                'Else
                '    Call myCShowMessage.ShowInfo("Proses rekap sales dibatalkan!")
                'End If
            Else
                Call myCShowMessage.ShowWarning("Silahkan tentukan periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesRekap_Click Error")
        Finally
            If (cboPeriode.SelectedIndex <> -1) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnProsesPerhitunganKomisi_Click(sender As Object, e As EventArgs) Handles btnProsesPerhitunganKomisi.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                'Dim lanjut As Boolean
                Dim myDataTableSales As New DataTable
                Dim batasBawahGaguk As Byte
                Dim batasMinimalPersenTargetItem As Byte
                Dim targetItem As Short
                Dim itemMencapaiTarget As Byte
                Dim myDataTableNotaBelumLunas As New DataTable

                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                stSQL = "SELECT kodesales,namasales,dalamkota,luarkota,luarpulau,(case when wilayah like '%KEMBANG JEPUN%' then true else false end) as kembangjepun,company,'" & cboPeriode.SelectedValue & "' as periode, '" & USER_.username & "' as userid FROM " & CONN_.schemaKomisi & ".mssales WHERE company='" & USER_.company & "' ORDER BY namasales;"
                myDataTableSales = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_Sales")
                myDataTableSales.Columns.Add("targetomzet", GetType(Double))
                myDataTableSales.Columns.Add("omzetbruto", GetType(Double))
                myDataTableSales.Columns.Add("retur", GetType(Double))
                myDataTableSales.Columns.Add("omzetnett", GetType(Double))
                myDataTableSales.Columns.Add("persenpencapaianomzet", GetType(Double))
                myDataTableSales.Columns.Add("targetpimtrakol", GetType(Double))
                myDataTableSales.Columns.Add("pencapaianpimtrakol", GetType(Double))
                myDataTableSales.Columns.Add("persenpencapaianpimtrakol", GetType(Double))
                myDataTableSales.Columns.Add("hitomzet", GetType(Double))
                myDataTableSales.Columns.Add("ppn", GetType(Double))
                myDataTableSales.Columns.Add("perseninsentifpenjualan", GetType(Double))
                myDataTableSales.Columns.Add("perhitunganinsentifpenjualan", GetType(Double))
                myDataTableSales.Columns.Add("ec", GetType(Double))
                myDataTableSales.Columns.Add("eo", GetType(Double))
                myDataTableSales.Columns.Add("x", GetType(Double))
                myDataTableSales.Columns.Add("y", GetType(Double))
                myDataTableSales.Columns.Add("z", GetType(Double))
                myDataTableSales.Columns.Add("perhitungansetelaheceo", GetType(Double))
                myDataTableSales.Columns.Add("perseninsentifpimtrakol", GetType(Double))
                myDataTableSales.Columns.Add("perhitungansetelahpimtrakol", GetType(Double))
                myDataTableSales.Columns.Add("persenpencapaiantargetitem", GetType(Double))
                myDataTableSales.Columns.Add("persenklaiminsentif", GetType(Double))
                myDataTableSales.Columns.Add("perhitunganinsentifakhir", GetType(Double))
                myDataTableSales.Columns.Add("omzetnett90", GetType(Double))
                myDataTableSales.Columns.Add("omzetnett10", GetType(Double))
                myDataTableSales.Columns.Add("perseninsentifpenjualan90", GetType(Double))
                myDataTableSales.Columns.Add("perhitunganinsentifpenjualan90", GetType(Double))
                myDataTableSales.Columns.Add("totalperhitunganinsentifpenjualan", GetType(Double))
                myDataTableSales.Columns.Add("persenklaimperhitunganinsentifpenjualan", GetType(Double))
                myDataTableSales.Columns.Add("overdue", GetType(Double))
                myDataTableSales.Columns.Add("persenoverdue", GetType(Double))
                myDataTableSales.Columns.Add("jtpalinglama", GetType(String))
                myDataTableSales.Columns.Add("note", GetType(String))
                myDataTableSales.Columns.Add("isnew", GetType(Boolean))

                For i As Integer = 0 To myDataTableSales.Rows.Count - 1
                    'MsgBox(myDataTableSales.Rows(i).Item("namasales"))


                    'Dim boxed As ValueType = T_perhitunganKomisi
                    'For Each f In GetType(perhitunganKomisi).GetFields()
                    '    'myDataTableSales.Rows(i).Item(f.Name()) = f.GetValue()
                    '    'MsgBox(myDataTableSales.Rows(i).Item(f.Name()))
                    '    f.SetValue(boxed, Nothing)
                    'Next

                    'MsgBox(T_perhitunganKomisi.ec)

                    T_perhitunganKomisi.targetomzet = Nothing
                    T_perhitunganKomisi.omzetbruto = Nothing
                    T_perhitunganKomisi.retur = Nothing
                    T_perhitunganKomisi.omzetnett = Nothing
                    T_perhitunganKomisi.persenpencapaianomzet = Nothing
                    T_perhitunganKomisi.targetpimtrakol = Nothing
                    T_perhitunganKomisi.pencapaianpimtrakol = Nothing
                    T_perhitunganKomisi.persenpencapaianpimtrakol = Nothing
                    T_perhitunganKomisi.hitomzet = Nothing
                    T_perhitunganKomisi.ppn = Nothing
                    T_perhitunganKomisi.perseninsentifpenjualan = Nothing
                    T_perhitunganKomisi.perhitunganinsentifpenjualan = Nothing
                    T_perhitunganKomisi.ec = Nothing
                    T_perhitunganKomisi.eo = Nothing
                    T_perhitunganKomisi.x = Nothing
                    T_perhitunganKomisi.y = Nothing
                    T_perhitunganKomisi.z = Nothing
                    T_perhitunganKomisi.perhitungansetelaheceo = Nothing
                    T_perhitunganKomisi.perseninsentifpimtrakol = Nothing
                    T_perhitunganKomisi.perhitungansetelahpimtrakol = Nothing
                    T_perhitunganKomisi.persenpencapaiantargetitem = Nothing
                    T_perhitunganKomisi.persenklaiminsentif = Nothing
                    T_perhitunganKomisi.perhitunganinsentifakhir = Nothing
                    T_perhitunganKomisi.omzetnett90 = Nothing
                    T_perhitunganKomisi.omzetnett10 = Nothing
                    T_perhitunganKomisi.perseninsentifpenjualan90 = Nothing
                    T_perhitunganKomisi.perhitunganinsentifpenjualan90 = Nothing
                    T_perhitunganKomisi.totalperhitunganinsentifpenjualan = Nothing
                    T_perhitunganKomisi.persenklaimperhitunganinsentifpenjualan = Nothing
                    T_perhitunganKomisi.overdue = Nothing
                    T_perhitunganKomisi.persenoverdue = Nothing
                    T_perhitunganKomisi.jtpalinglama = Nothing
                    T_perhitunganKomisi.note = Nothing

                    T_perhitunganKomisi.targetomzet = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "target", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.omzetbruto = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "omzetbruto", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.retur = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "retur", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.omzetnett = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "omzet", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.persenpencapaianomzet = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "persenpencapaiansales", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.targetpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "targetpimt", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.pencapaianpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "realpimt", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.persenpencapaianpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "persenpimt", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                    T_perhitunganKomisi.ppn = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaKomisi & ".msgeneral",, "kategori='ppn'", CONN_.dbType)

                    If (myDataTableSales.Rows(i).Item("kodesales") <> "GAG - KAL") And (myDataTableSales.Rows(i).Item("kodesales") <> "GAG - NTB") Then
                        'Jika bukan gaguk
                        T_perhitunganKomisi.hitomzet = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "hitomzet", CONN_.schemaKomisi & ".trrekapsales",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and company='" & USER_.company & "'", CONN_.dbType)
                        T_perhitunganKomisi.perseninsentifpenjualan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PENJUALAN' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' or luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "') AND luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "' AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet), CONN_.dbType)
                        T_perhitunganKomisi.perhitunganinsentifpenjualan = (T_perhitunganKomisi.hitomzet / ((T_perhitunganKomisi.ppn + 100) / 100)) * (T_perhitunganKomisi.perseninsentifpenjualan / 100)
                        If (myDataTableSales.Rows(i).Item("dalamkota")) Then
                            'Untuk dalam kota
                            T_perhitunganKomisi.ec = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "ec", CONN_.schemaKomisi & ".mseceo",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'", CONN_.dbType)
                            T_perhitunganKomisi.eo = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "eo", CONN_.schemaKomisi & ".mseceo",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'", CONN_.dbType)
                            T_perhitunganKomisi.x = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "x", CONN_.schemaKomisi & ".mseceo",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'", CONN_.dbType)
                            T_perhitunganKomisi.y = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "y", CONN_.schemaKomisi & ".mseceo",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'", CONN_.dbType)
                            T_perhitunganKomisi.z = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='ECEO' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "') AND luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "' AND kembangjepun='" & myDataTableSales.Rows(i).Item("kembangjepun") & "' AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.y), 0, T_perhitunganKomisi.y) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.y), 0, T_perhitunganKomisi.y), CONN_.dbType)
                            If (T_perhitunganKomisi.z = -1) Then
                                'Ini berarti menggunakan akhir yang ada di mseceo, karena tidak mencapai target, dan harus dikurangkan, bukan ditambah
                                T_perhitunganKomisi.z = -(myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "akhir", CONN_.schemaKomisi & ".mseceo",, "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'", CONN_.dbType))
                            End If
                            T_perhitunganKomisi.perhitungansetelaheceo = T_perhitunganKomisi.perhitunganinsentifpenjualan + ((T_perhitunganKomisi.z / 100) * T_perhitunganKomisi.perhitunganinsentifpenjualan)
                            T_perhitunganKomisi.perseninsentifpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PIMTRAKOL' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "' OR luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "') AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol), CONN_.dbType)
                            T_perhitunganKomisi.perhitungansetelahpimtrakol = IIf(IsNothing(T_perhitunganKomisi.perhitungansetelaheceo), 0, T_perhitunganKomisi.perhitungansetelaheceo) + ((T_perhitunganKomisi.perseninsentifpimtrakol / 100) * IIf(IsNothing(T_perhitunganKomisi.perhitungansetelaheceo), 0, T_perhitunganKomisi.perhitungansetelaheceo))
                        Else
                            'Untuk selain dalam kota, dan juga selain gaguk
                            T_perhitunganKomisi.perseninsentifpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PIMTRAKOL' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "' OR luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "') AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol), CONN_.dbType)
                            T_perhitunganKomisi.perhitungansetelahpimtrakol = IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan) + ((T_perhitunganKomisi.perseninsentifpimtrakol / 100) * IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan))
                        End If
                    Else
                        'Jika gaguk
                        T_perhitunganKomisi.hitomzet = T_perhitunganKomisi.omzetnett
                        batasBawahGaguk = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "batasbawah", CONN_.schemaKomisi & ".msinsentif", "Max", "kategori='PENJUALAN' and luarpulau='True'", CONN_.dbType)
                        If (IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet) >= batasBawahGaguk) Then
                            T_perhitunganKomisi.omzetnett90 = (0.9 * IIf(IsNothing(T_perhitunganKomisi.omzetnett), 0, T_perhitunganKomisi.omzetnett))
                            T_perhitunganKomisi.omzetnett10 = (0.1 * IIf(IsNothing(T_perhitunganKomisi.omzetnett), 0, T_perhitunganKomisi.omzetnett))
                            T_perhitunganKomisi.perseninsentifpenjualan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PENJUALAN' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "') AND luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "' AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet), CONN_.dbType)
                            'Untuk mendapatkan komisi yang untuk 90% nya atau yang di 2 level dari terakhir
                            stSQL = "select subq.perseninsentif from (select perseninsentif from " & CONN_.schemaKomisi & ".msinsentif where kategori='PENJUALAN' and luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "' order by batasbawah desc limit 2) as subq order by subq.perseninsentif asc limit 1;"
                            T_perhitunganKomisi.perseninsentifpenjualan90 = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                            T_perhitunganKomisi.perhitunganinsentifpenjualan = (T_perhitunganKomisi.omzetnett10 / ((T_perhitunganKomisi.ppn + 100) / 100)) * (T_perhitunganKomisi.perseninsentifpenjualan / 100)
                            T_perhitunganKomisi.perhitunganinsentifpenjualan90 = (T_perhitunganKomisi.omzetnett90 / ((T_perhitunganKomisi.ppn + 100) / 100)) * (T_perhitunganKomisi.perseninsentifpenjualan90 / 100)
                        Else
                            T_perhitunganKomisi.perseninsentifpenjualan = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PENJUALAN' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "') AND luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "' AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet), CONN_.dbType)
                            T_perhitunganKomisi.perhitunganinsentifpenjualan = (T_perhitunganKomisi.hitomzet / ((T_perhitunganKomisi.ppn + 100) / 100)) * T_perhitunganKomisi.perseninsentifpenjualan
                        End If
                        T_perhitunganKomisi.totalperhitunganinsentifpenjualan = Double.Parse(IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan)) + Double.Parse(IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan90), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan90))
                        T_perhitunganKomisi.perseninsentifpimtrakol = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='PIMTRAKOL' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "' OR luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "') AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol), CONN_.dbType)
                        T_perhitunganKomisi.perhitungansetelahpimtrakol = IIf(IsNothing(T_perhitunganKomisi.totalperhitunganinsentifpenjualan), 0, T_perhitunganKomisi.totalperhitunganinsentifpenjualan) + ((T_perhitunganKomisi.perseninsentifpimtrakol / 100) * IIf(IsNothing(T_perhitunganKomisi.totalperhitunganinsentifpenjualan), 0, T_perhitunganKomisi.totalperhitunganinsentifpenjualan))
                    End If
                    batasMinimalPersenTargetItem = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "kode", CONN_.schemaKomisi & ".msgeneral",, "kategori='targetitem'", CONN_.dbType)
                    targetItem = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".mstargetsales", "Count", "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and qty>0 and kodeitem not in ('OJ0121','OJ0121A','XSTPRS24')")
                    itemMencapaiTarget = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".trpenjualanperitem", "Count", "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and persenjual >= " & batasMinimalPersenTargetItem & " and kodeitem not in ('OJ0121','OJ0121A','XSTPRS24') and company='" & USER_.company & "'")
                    If (targetItem > 0) Then
                        T_perhitunganKomisi.persenpencapaiantargetitem = (itemMencapaiTarget / targetItem) * 100
                    End If
                    T_perhitunganKomisi.persenklaiminsentif = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "perseninsentif", CONN_.schemaKomisi & ".msinsentif",, "kategori='REWARD&PUNISHMENT' AND (dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "' OR luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "' OR luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "') AND batasbawah<=" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaiantargetitem), 0, T_perhitunganKomisi.persenpencapaiantargetitem) & " and batasatas>" & IIf(IsNothing(T_perhitunganKomisi.persenpencapaiantargetitem), 0, T_perhitunganKomisi.persenpencapaiantargetitem), CONN_.dbType)
                    T_perhitunganKomisi.perhitunganinsentifakhir = (T_perhitunganKomisi.persenklaiminsentif / 100) * T_perhitunganKomisi.perhitungansetelahpimtrakol
                    T_perhitunganKomisi.overdue = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "jumlah", CONN_.schemaKomisi & ".trpenjualanperoutlet", "Sum", "overdue>3 and ignoreoverdue='False' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and company='" & USER_.company & "'")
                    T_perhitunganKomisi.persenoverdue = (T_perhitunganKomisi.overdue / T_perhitunganKomisi.omzetbruto) * 100
                    stSQL = "select (namacustomer || ' (' || jmlharilunas || ' hari)') as jtpalinglama from " & CONN_.schemaKomisi & ".trpenjualanperoutlet where ignoreoverdue='False' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and company='" & USER_.company & "' order by jmlharilunas desc limit 1;"
                    T_perhitunganKomisi.jtpalinglama = myCDBOperation.GetDataIndividual(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL)
                    stSQL = "select namacustomer,nonota,tglnota from " & CONN_.schemaKomisi & ".trpenjualanperoutlet where lunas is null and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "' and periode='" & cboPeriode.SelectedValue & "' and company='" & USER_.company & "';"
                    myDataTableNotaBelumLunas = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_NotaBelumLunas")
                    If (myDataTableNotaBelumLunas.Rows.Count > 0) Then
                        T_perhitunganKomisi.note = "Belum Lunas: "
                        For x As Integer = 0 To myDataTableNotaBelumLunas.Rows.Count > 0
                            T_perhitunganKomisi.note &= ControlChars.NewLine & (x + 1) & ". " & myDataTableNotaBelumLunas.Rows(x).Item("nonota")
                        Next
                    End If

                    'For Each f In GetType(perhitunganKomisi).GetFields()
                    '    myDataTableSales.Rows(i).Item(f.Name()) = f.GetValue()
                    '    MsgBox(myDataTableSales.Rows(i).Item(f.Name()))
                    'Next

                    myDataTableSales.Rows(i).Item("targetomzet") = IIf(IsNothing(T_perhitunganKomisi.targetomzet), 0, T_perhitunganKomisi.targetomzet)
                    myDataTableSales.Rows(i).Item("omzetbruto") = IIf(IsNothing(T_perhitunganKomisi.omzetbruto), 0, T_perhitunganKomisi.omzetbruto)
                    myDataTableSales.Rows(i).Item("retur") = IIf(IsNothing(T_perhitunganKomisi.retur), 0, T_perhitunganKomisi.retur)
                    myDataTableSales.Rows(i).Item("omzetnett") = IIf(IsNothing(T_perhitunganKomisi.omzetnett), 0, T_perhitunganKomisi.omzetnett)
                    myDataTableSales.Rows(i).Item("persenpencapaianomzet") = IIf(IsNothing(T_perhitunganKomisi.persenpencapaianomzet), 0, T_perhitunganKomisi.persenpencapaianomzet)
                    myDataTableSales.Rows(i).Item("targetpimtrakol") = IIf(IsNothing(T_perhitunganKomisi.targetpimtrakol), 0, T_perhitunganKomisi.targetpimtrakol)
                    myDataTableSales.Rows(i).Item("pencapaianpimtrakol") = IIf(IsNothing(T_perhitunganKomisi.pencapaianpimtrakol), 0, T_perhitunganKomisi.pencapaianpimtrakol)
                    myDataTableSales.Rows(i).Item("persenpencapaianpimtrakol") = IIf(IsNothing(T_perhitunganKomisi.persenpencapaianpimtrakol), 0, T_perhitunganKomisi.persenpencapaianpimtrakol)
                    myDataTableSales.Rows(i).Item("hitomzet") = IIf(IsNothing(T_perhitunganKomisi.hitomzet), 0, T_perhitunganKomisi.hitomzet)
                    myDataTableSales.Rows(i).Item("ppn") = IIf(IsNothing(T_perhitunganKomisi.ppn), 0, T_perhitunganKomisi.ppn)
                    myDataTableSales.Rows(i).Item("perseninsentifpenjualan") = IIf(IsNothing(T_perhitunganKomisi.perseninsentifpenjualan), 0, T_perhitunganKomisi.perseninsentifpenjualan)
                    myDataTableSales.Rows(i).Item("perhitunganinsentifpenjualan") = IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan)
                    myDataTableSales.Rows(i).Item("ec") = IIf(IsNothing(T_perhitunganKomisi.ec), 0, T_perhitunganKomisi.ec)
                    myDataTableSales.Rows(i).Item("eo") = IIf(IsNothing(T_perhitunganKomisi.eo), 0, T_perhitunganKomisi.eo)
                    myDataTableSales.Rows(i).Item("x") = IIf(IsNothing(T_perhitunganKomisi.x), 0, T_perhitunganKomisi.x)
                    myDataTableSales.Rows(i).Item("y") = IIf(IsNothing(T_perhitunganKomisi.y), 0, T_perhitunganKomisi.y)
                    myDataTableSales.Rows(i).Item("z") = IIf(IsNothing(T_perhitunganKomisi.z), 0, T_perhitunganKomisi.z)
                    myDataTableSales.Rows(i).Item("perhitungansetelaheceo") = IIf(IsNothing(T_perhitunganKomisi.perhitungansetelaheceo), 0, T_perhitunganKomisi.perhitungansetelaheceo)
                    myDataTableSales.Rows(i).Item("perseninsentifpimtrakol") = IIf(IsNothing(T_perhitunganKomisi.perseninsentifpimtrakol), 0, T_perhitunganKomisi.perseninsentifpimtrakol)
                    myDataTableSales.Rows(i).Item("perhitungansetelahpimtrakol") = IIf(IsNothing(T_perhitunganKomisi.perhitungansetelahpimtrakol), 0, T_perhitunganKomisi.perhitungansetelahpimtrakol)
                    myDataTableSales.Rows(i).Item("persenpencapaiantargetitem") = IIf(IsNothing(T_perhitunganKomisi.persenpencapaiantargetitem), 0, T_perhitunganKomisi.persenpencapaiantargetitem)
                    myDataTableSales.Rows(i).Item("persenklaiminsentif") = IIf(IsNothing(T_perhitunganKomisi.persenklaiminsentif), 0, T_perhitunganKomisi.persenklaiminsentif)
                    myDataTableSales.Rows(i).Item("perhitunganinsentifakhir") = IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifakhir), 0, T_perhitunganKomisi.perhitunganinsentifakhir)
                    myDataTableSales.Rows(i).Item("omzetnett90") = IIf(IsNothing(T_perhitunganKomisi.omzetnett90), 0, T_perhitunganKomisi.omzetnett90)
                    myDataTableSales.Rows(i).Item("omzetnett10") = IIf(IsNothing(T_perhitunganKomisi.omzetnett10), 0, T_perhitunganKomisi.omzetnett10)
                    myDataTableSales.Rows(i).Item("perseninsentifpenjualan90") = IIf(IsNothing(T_perhitunganKomisi.perseninsentifpenjualan90), 0, T_perhitunganKomisi.perseninsentifpenjualan90)
                    myDataTableSales.Rows(i).Item("perhitunganinsentifpenjualan90") = IIf(IsNothing(T_perhitunganKomisi.perhitunganinsentifpenjualan90), 0, T_perhitunganKomisi.perhitunganinsentifpenjualan90)
                    myDataTableSales.Rows(i).Item("totalperhitunganinsentifpenjualan") = IIf(IsNothing(T_perhitunganKomisi.totalperhitunganinsentifpenjualan), 0, T_perhitunganKomisi.totalperhitunganinsentifpenjualan)
                    myDataTableSales.Rows(i).Item("persenklaimperhitunganinsentifpenjualan") = IIf(IsNothing(T_perhitunganKomisi.persenklaimperhitunganinsentifpenjualan), 0, T_perhitunganKomisi.persenklaimperhitunganinsentifpenjualan)
                    myDataTableSales.Rows(i).Item("overdue") = IIf(IsNothing(T_perhitunganKomisi.overdue), 0, T_perhitunganKomisi.overdue)
                    myDataTableSales.Rows(i).Item("persenoverdue") = IIf(IsNothing(T_perhitunganKomisi.persenoverdue), 0, T_perhitunganKomisi.persenoverdue)
                    myDataTableSales.Rows(i).Item("jtpalinglama") = IIf(IsNothing(T_perhitunganKomisi.jtpalinglama), Nothing, T_perhitunganKomisi.jtpalinglama)
                    myDataTableSales.Rows(i).Item("note") = IIf(IsNothing(T_perhitunganKomisi.note), Nothing, T_perhitunganKomisi.note)

                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", CONN_.schemaKomisi & ".trperhitungankomisi", "periode='" & cboPeriode.SelectedValue & "' and kodesales='" & myCStringManipulation.SafeSqlLiteral(myDataTableSales.Rows(i).Item("kodesales")) & "'")

                    If Not isExist Then
                        'kalau masih belum ada
                        'Langsung add new
                        myDataTableSales.Rows(i).Item("isnew") = True
                    Else
                        'Kalau sudah ada, update saja
                        myDataTableSales.Rows(i).Item("isnew") = False
                        updateString = "targetomzet=" & myDataTableSales.Rows(i).Item("targetomzet") & ",omzetbruto=" & myDataTableSales.Rows(i).Item("omzetbruto") & ",retur=" & myDataTableSales.Rows(i).Item("retur") & ",omzetnett=" & myDataTableSales.Rows(i).Item("omzetnett") & ",persenpencapaianomzet=" & myDataTableSales.Rows(i).Item("persenpencapaianomzet") & ",targetpimtrakol=" & myDataTableSales.Rows(i).Item("targetpimtrakol") & ",pencapaianpimtrakol=" & myDataTableSales.Rows(i).Item("pencapaianpimtrakol") & ",persenpencapaianpimtrakol=" & myDataTableSales.Rows(i).Item("persenpencapaianpimtrakol") & ",hitomzet=" & myDataTableSales.Rows(i).Item("hitomzet")
                        updateString &= ",ppn=" & myDataTableSales.Rows(i).Item("ppn") & ",perseninsentifpenjualan=" & myDataTableSales.Rows(i).Item("perseninsentifpenjualan") & ",perhitunganinsentifpenjualan=" & myDataTableSales.Rows(i).Item("perhitunganinsentifpenjualan") & ",ec=" & myDataTableSales.Rows(i).Item("ec") & ",eo=" & myDataTableSales.Rows(i).Item("eo") & ",x=" & myDataTableSales.Rows(i).Item("x") & ",y=" & myDataTableSales.Rows(i).Item("y") & ",z=" & myDataTableSales.Rows(i).Item("z") & ",perhitungansetelaheceo=" & myDataTableSales.Rows(i).Item("perhitungansetelaheceo") & ",perseninsentifpimtrakol=" & myDataTableSales.Rows(i).Item("perseninsentifpimtrakol")
                        updateString &= ",perhitungansetelahpimtrakol=" & myDataTableSales.Rows(i).Item("perhitungansetelahpimtrakol") & ",persenpencapaiantargetitem=" & myDataTableSales.Rows(i).Item("persenpencapaiantargetitem") & ",persenklaiminsentif=" & myDataTableSales.Rows(i).Item("persenklaiminsentif") & ",perhitunganinsentifakhir=" & myDataTableSales.Rows(i).Item("perhitunganinsentifakhir") & ",company='" & myDataTableSales.Rows(i).Item("company") & "',dalamkota='" & myDataTableSales.Rows(i).Item("dalamkota") & "',luarkota='" & myDataTableSales.Rows(i).Item("luarkota") & "',luarpulau='" & myDataTableSales.Rows(i).Item("luarpulau") & "',omzetnett90=" & myDataTableSales.Rows(i).Item("omzetnett90") & ",omzetnett10=" & myDataTableSales.Rows(i).Item("omzetnett10")
                        updateString &= ",perseninsentifpenjualan90=" & myDataTableSales.Rows(i).Item("perseninsentifpenjualan90") & ",perhitunganinsentifpenjualan90=" & myDataTableSales.Rows(i).Item("perhitunganinsentifpenjualan90") & ",totalperhitunganinsentifpenjualan=" & myDataTableSales.Rows(i).Item("totalperhitunganinsentifpenjualan") & ",persenklaimperhitunganinsentifpenjualan=" & myDataTableSales.Rows(i).Item("persenklaimperhitunganinsentifpenjualan") & ",overdue=" & myDataTableSales.Rows(i).Item("overdue") & ",persenoverdue=" & myDataTableSales.Rows(i).Item("persenoverdue") & ",jtpalinglama='" & myDataTableSales.Rows(i).Item("jtpalinglama") & "',note='" & myDataTableSales.Rows(i).Item("note") & "',updated_at=clock_timestamp()"

                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, CONN_.schemaKomisi & ".trperhitungankomisi", updateString, "kodesales='" & myDataTableSales.Rows(i).Item("kodesales") & "' and periode='" & cboPeriode.SelectedValue & "'")
                    End If
                Next

                Call myCDBOperation.ConstructorInsertData(CONN_.dbMain, CONN_.comm, CONN_.reader, myDataTableSales, CONN_.schemaKomisi & ".trperhitungankomisi", , "isnew")

                Call myCShowMessage.ShowInfo("DONE!!")
            Else
                Call myCShowMessage.ShowWarning("Silahkan tentukan periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesPerhitunganKomisi_Click Error")
        Finally
            If (cboPeriode.SelectedIndex <> -1) Then
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Try
            If (cboPeriode.SelectedIndex <> -1) Then
                Dim reportType As String
                Select Case True
                    Case rbRekap.Checked
                        reportType = "RekapKomisi"
                        stSQL = "SELECT kodesales,namasales,periode,target,omzet,omzetlm,omzetbr,persenpencapaiansales,sppending,persensppending,overdue,hitomzet,totalpersen,komisireg,targetpimt,realpimt,persenpimt,kmspimt,totalkms,(case when dalamkota=True then '1. Dalam Kota' when luarkota=True then '2. Luar Kota' else 'Lainnya' end) as cakupan FROM " & CONN_.schemaKomisi & ".trrekapsales WHERE periode='" & cboPeriode.SelectedValue & "' ORDER BY namasales;"
                    Case rbPerhitunganKomisi.Checked
                        reportType = "PerhitunganKomisi"
                        stSQL = ""
                End Select
                If Not IsNothing(reportType) Then
                    Dim frmDisplayReport As New FormDisplayReport.FormDisplayReport(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaKomisi, CONN_.dbMain, stSQL, reportType)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmDisplayReport)
                Else
                    Call myCShowMessage.ShowWarning("Silahkan tentukan dulu report yang mau dicetak!!")
                End If
            Else
                Call myCShowMessage.ShowWarning("Silahkan pilih periodenya terlebih dahulu!!")
                cboPeriode.Focus()
            End If

        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnProsesRekap_Click Error")
        End Try
    End Sub

    Private Sub rbCetak_CheckedChanged(sender As Object, e As EventArgs) Handles rbRekap.CheckedChanged, rbPerhitunganKomisi.CheckedChanged, rbDetailPerOutlet.CheckedChanged, rbDetailPerItem.CheckedChanged
        Try
            Select Case True
                Case rbRekap.Checked
                    cboSalesCetak.Enabled = False
                Case rbPerhitunganKomisi.Checked, rbDetailPerOutlet.Checked, rbDetailPerItem.Checked
                    cboSalesCetak.Enabled = True
            End Select
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "rbCetak_CheckedChanged Error")
        End Try
    End Sub
End Class
