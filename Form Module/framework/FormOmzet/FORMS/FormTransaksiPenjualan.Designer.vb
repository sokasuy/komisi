<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTransaksiPenjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTransaksiPenjualan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnProsesImport = New System.Windows.Forms.Button()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.lblNamaSheet = New System.Windows.Forms.Label()
        Me.tbNamaSheet = New System.Windows.Forms.TextBox()
        Me.pnlImportExcel = New System.Windows.Forms.Panel()
        Me.rbTmpTopKhusus = New System.Windows.Forms.RadioButton()
        Me.rbDataPelunasan = New System.Windows.Forms.RadioButton()
        Me.rbTOPKhususLuarKota = New System.Windows.Forms.RadioButton()
        Me.rbTOPKhususDalamKota = New System.Windows.Forms.RadioButton()
        Me.rbPenjualanPerItem = New System.Windows.Forms.RadioButton()
        Me.rbPenjualanPerOutlet = New System.Windows.Forms.RadioButton()
        Me.cboPeriode = New System.Windows.Forms.ComboBox()
        Me.lblPeriodeImport = New System.Windows.Forms.Label()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblSum3 = New System.Windows.Forms.Label()
        Me.tbSum3 = New System.Windows.Forms.TextBox()
        Me.lblSum2 = New System.Windows.Forms.Label()
        Me.tbSum2 = New System.Windows.Forms.TextBox()
        Me.tbSum1 = New System.Windows.Forms.TextBox()
        Me.lblSum1 = New System.Windows.Forms.Label()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.cboCariPeriode = New System.Windows.Forms.ComboBox()
        Me.rbCariPenjualanPerItem = New System.Windows.Forms.RadioButton()
        Me.rbCariPenjualanPerOutlet = New System.Windows.Forms.RadioButton()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblCariSales = New System.Windows.Forms.Label()
        Me.cboCariSales = New System.Windows.Forms.ComboBox()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblProsesTOPKhusus = New System.Windows.Forms.Label()
        Me.btnProsesTOPKhusus = New System.Windows.Forms.Button()
        Me.btnProsesOverdue = New System.Windows.Forms.Button()
        Me.lblProsesOverdue = New System.Windows.Forms.Label()
        Me.btnProsesRekap = New System.Windows.Forms.Button()
        Me.lblProsesRekap = New System.Windows.Forms.Label()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.pnlCetak = New System.Windows.Forms.Panel()
        Me.lblSalesCetak = New System.Windows.Forms.Label()
        Me.rbDetailPerItem = New System.Windows.Forms.RadioButton()
        Me.rbDetailPerOutlet = New System.Windows.Forms.RadioButton()
        Me.cboSalesCetak = New System.Windows.Forms.ComboBox()
        Me.rbPerhitunganKomisi = New System.Windows.Forms.RadioButton()
        Me.rbRekap = New System.Windows.Forms.RadioButton()
        Me.btnProsesPerhitunganKomisi = New System.Windows.Forms.Button()
        Me.lblProsesPerhitunganKomisi = New System.Windows.Forms.Label()
        Me.btnProsesPencapaianTargetItem = New System.Windows.Forms.Button()
        Me.lblProsesPencapaianTargetItem = New System.Windows.Forms.Label()
        Me.lblTargetItem = New System.Windows.Forms.Label()
        Me.lblSum4 = New System.Windows.Forms.Label()
        Me.tbSum4 = New System.Windows.Forms.TextBox()
        Me.lblSum5 = New System.Windows.Forms.Label()
        Me.tbSum5 = New System.Windows.Forms.TextBox()
        Me.pnlImportExcel.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTanggal.SuspendLayout()
        Me.pnlCetak.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1209, 25)
        Me.lblTitle.TabIndex = 182
        Me.lblTitle.Text = "TRANSAKSI PENJUALAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(475, 1)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowse.TabIndex = 247
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnProsesImport
        '
        Me.btnProsesImport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProsesImport.Image = CType(resources.GetObject("btnProsesImport.Image"), System.Drawing.Image)
        Me.btnProsesImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesImport.Location = New System.Drawing.Point(910, 3)
        Me.btnProsesImport.Name = "btnProsesImport"
        Me.btnProsesImport.Size = New System.Drawing.Size(120, 54)
        Me.btnProsesImport.TabIndex = 246
        Me.btnProsesImport.Text = "IMPORT"
        Me.btnProsesImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesImport.UseVisualStyleBackColor = True
        '
        'tbNamaFile
        '
        Me.tbNamaFile.Location = New System.Drawing.Point(99, 3)
        Me.tbNamaFile.Name = "tbNamaFile"
        Me.tbNamaFile.Size = New System.Drawing.Size(370, 20)
        Me.tbNamaFile.TabIndex = 242
        '
        'lblNamaFile
        '
        Me.lblNamaFile.AutoSize = True
        Me.lblNamaFile.Location = New System.Drawing.Point(4, 6)
        Me.lblNamaFile.Name = "lblNamaFile"
        Me.lblNamaFile.Size = New System.Drawing.Size(89, 13)
        Me.lblNamaFile.TabIndex = 244
        Me.lblNamaFile.Text = "Nama File Excel :"
        '
        'lblNamaSheet
        '
        Me.lblNamaSheet.AutoSize = True
        Me.lblNamaSheet.Location = New System.Drawing.Point(21, 32)
        Me.lblNamaSheet.Name = "lblNamaSheet"
        Me.lblNamaSheet.Size = New System.Drawing.Size(72, 13)
        Me.lblNamaSheet.TabIndex = 245
        Me.lblNamaSheet.Text = "Nama Sheet :"
        '
        'tbNamaSheet
        '
        Me.tbNamaSheet.Location = New System.Drawing.Point(99, 29)
        Me.tbNamaSheet.Name = "tbNamaSheet"
        Me.tbNamaSheet.Size = New System.Drawing.Size(144, 20)
        Me.tbNamaSheet.TabIndex = 243
        Me.tbNamaSheet.Text = "Sheet1"
        '
        'pnlImportExcel
        '
        Me.pnlImportExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlImportExcel.Controls.Add(Me.rbTmpTopKhusus)
        Me.pnlImportExcel.Controls.Add(Me.rbDataPelunasan)
        Me.pnlImportExcel.Controls.Add(Me.rbTOPKhususLuarKota)
        Me.pnlImportExcel.Controls.Add(Me.rbTOPKhususDalamKota)
        Me.pnlImportExcel.Controls.Add(Me.rbPenjualanPerItem)
        Me.pnlImportExcel.Controls.Add(Me.rbPenjualanPerOutlet)
        Me.pnlImportExcel.Controls.Add(Me.tbNamaFile)
        Me.pnlImportExcel.Controls.Add(Me.tbNamaSheet)
        Me.pnlImportExcel.Controls.Add(Me.lblNamaSheet)
        Me.pnlImportExcel.Controls.Add(Me.btnBrowse)
        Me.pnlImportExcel.Controls.Add(Me.lblNamaFile)
        Me.pnlImportExcel.Controls.Add(Me.btnProsesImport)
        Me.pnlImportExcel.Location = New System.Drawing.Point(12, 473)
        Me.pnlImportExcel.Name = "pnlImportExcel"
        Me.pnlImportExcel.Size = New System.Drawing.Size(1189, 62)
        Me.pnlImportExcel.TabIndex = 250
        '
        'rbTmpTopKhusus
        '
        Me.rbTmpTopKhusus.AutoSize = True
        Me.rbTmpTopKhusus.Location = New System.Drawing.Point(654, 42)
        Me.rbTmpTopKhusus.Name = "rbTmpTopKhusus"
        Me.rbTmpTopKhusus.Size = New System.Drawing.Size(111, 17)
        Me.rbTmpTopKhusus.TabIndex = 258
        Me.rbTmpTopKhusus.Text = "TMP TOP Khusus"
        Me.rbTmpTopKhusus.UseVisualStyleBackColor = True
        '
        'rbDataPelunasan
        '
        Me.rbDataPelunasan.AutoSize = True
        Me.rbDataPelunasan.Location = New System.Drawing.Point(519, 42)
        Me.rbDataPelunasan.Name = "rbDataPelunasan"
        Me.rbDataPelunasan.Size = New System.Drawing.Size(101, 17)
        Me.rbDataPelunasan.TabIndex = 257
        Me.rbDataPelunasan.Text = "Data Pelunasan"
        Me.rbDataPelunasan.UseVisualStyleBackColor = True
        '
        'rbTOPKhususLuarKota
        '
        Me.rbTOPKhususLuarKota.AutoSize = True
        Me.rbTOPKhususLuarKota.Location = New System.Drawing.Point(654, 24)
        Me.rbTOPKhususLuarKota.Name = "rbTOPKhususLuarKota"
        Me.rbTOPKhususLuarKota.Size = New System.Drawing.Size(134, 17)
        Me.rbTOPKhususLuarKota.TabIndex = 256
        Me.rbTOPKhususLuarKota.Text = "TOP Khusus Luar Kota"
        Me.rbTOPKhususLuarKota.UseVisualStyleBackColor = True
        '
        'rbTOPKhususDalamKota
        '
        Me.rbTOPKhususDalamKota.AutoSize = True
        Me.rbTOPKhususDalamKota.Location = New System.Drawing.Point(654, 6)
        Me.rbTOPKhususDalamKota.Name = "rbTOPKhususDalamKota"
        Me.rbTOPKhususDalamKota.Size = New System.Drawing.Size(143, 17)
        Me.rbTOPKhususDalamKota.TabIndex = 255
        Me.rbTOPKhususDalamKota.Text = "TOP Khusus Dalam Kota"
        Me.rbTOPKhususDalamKota.UseVisualStyleBackColor = True
        '
        'rbPenjualanPerItem
        '
        Me.rbPenjualanPerItem.AutoSize = True
        Me.rbPenjualanPerItem.Location = New System.Drawing.Point(519, 24)
        Me.rbPenjualanPerItem.Name = "rbPenjualanPerItem"
        Me.rbPenjualanPerItem.Size = New System.Drawing.Size(113, 17)
        Me.rbPenjualanPerItem.TabIndex = 252
        Me.rbPenjualanPerItem.Text = "Penjualan per Item"
        Me.rbPenjualanPerItem.UseVisualStyleBackColor = True
        '
        'rbPenjualanPerOutlet
        '
        Me.rbPenjualanPerOutlet.AutoSize = True
        Me.rbPenjualanPerOutlet.Checked = True
        Me.rbPenjualanPerOutlet.Location = New System.Drawing.Point(519, 6)
        Me.rbPenjualanPerOutlet.Name = "rbPenjualanPerOutlet"
        Me.rbPenjualanPerOutlet.Size = New System.Drawing.Size(122, 17)
        Me.rbPenjualanPerOutlet.TabIndex = 250
        Me.rbPenjualanPerOutlet.TabStop = True
        Me.rbPenjualanPerOutlet.Text = "Penjualan Per Outlet"
        Me.rbPenjualanPerOutlet.UseVisualStyleBackColor = True
        '
        'cboPeriode
        '
        Me.cboPeriode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPeriode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPeriode.FormattingEnabled = True
        Me.cboPeriode.IntegralHeight = False
        Me.cboPeriode.Location = New System.Drawing.Point(75, 446)
        Me.cboPeriode.Name = "cboPeriode"
        Me.cboPeriode.Size = New System.Drawing.Size(131, 21)
        Me.cboPeriode.TabIndex = 253
        '
        'lblPeriodeImport
        '
        Me.lblPeriodeImport.AutoSize = True
        Me.lblPeriodeImport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeriodeImport.Location = New System.Drawing.Point(16, 448)
        Me.lblPeriodeImport.Name = "lblPeriodeImport"
        Me.lblPeriodeImport.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriodeImport.TabIndex = 254
        Me.lblPeriodeImport.Text = "Periode :"
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblSum5)
        Me.gbView.Controls.Add(Me.tbSum5)
        Me.gbView.Controls.Add(Me.lblSum4)
        Me.gbView.Controls.Add(Me.tbSum4)
        Me.gbView.Controls.Add(Me.lblSum3)
        Me.gbView.Controls.Add(Me.tbSum3)
        Me.gbView.Controls.Add(Me.lblSum2)
        Me.gbView.Controls.Add(Me.tbSum2)
        Me.gbView.Controls.Add(Me.tbSum1)
        Me.gbView.Controls.Add(Me.lblSum1)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 98)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(1185, 342)
        Me.gbView.TabIndex = 251
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblSum3
        '
        Me.lblSum3.AutoSize = True
        Me.lblSum3.Location = New System.Drawing.Point(975, 291)
        Me.lblSum3.Name = "lblSum3"
        Me.lblSum3.Size = New System.Drawing.Size(43, 13)
        Me.lblSum3.TabIndex = 179
        Me.lblSum3.Text = "SUM 3:"
        '
        'tbSum3
        '
        Me.tbSum3.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbSum3.Location = New System.Drawing.Point(1024, 288)
        Me.tbSum3.Name = "tbSum3"
        Me.tbSum3.ReadOnly = True
        Me.tbSum3.Size = New System.Drawing.Size(156, 20)
        Me.tbSum3.TabIndex = 178
        Me.tbSum3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSum2
        '
        Me.lblSum2.AutoSize = True
        Me.lblSum2.Location = New System.Drawing.Point(751, 291)
        Me.lblSum2.Name = "lblSum2"
        Me.lblSum2.Size = New System.Drawing.Size(43, 13)
        Me.lblSum2.TabIndex = 177
        Me.lblSum2.Text = "SUM 2:"
        '
        'tbSum2
        '
        Me.tbSum2.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbSum2.Location = New System.Drawing.Point(800, 288)
        Me.tbSum2.Name = "tbSum2"
        Me.tbSum2.ReadOnly = True
        Me.tbSum2.Size = New System.Drawing.Size(156, 20)
        Me.tbSum2.TabIndex = 176
        Me.tbSum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbSum1
        '
        Me.tbSum1.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbSum1.Location = New System.Drawing.Point(576, 288)
        Me.tbSum1.Name = "tbSum1"
        Me.tbSum1.ReadOnly = True
        Me.tbSum1.Size = New System.Drawing.Size(156, 20)
        Me.tbSum1.TabIndex = 174
        Me.tbSum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSum1
        '
        Me.lblSum1.AutoSize = True
        Me.lblSum1.Location = New System.Drawing.Point(527, 291)
        Me.lblSum1.Name = "lblSum1"
        Me.lblSum1.Size = New System.Drawing.Size(43, 13)
        Me.lblSum1.TabIndex = 173
        Me.lblSum1.Text = "SUM 1:"
        '
        'pnlNavigasi
        '
        Me.pnlNavigasi.Controls.Add(Me.btnAddNew)
        Me.pnlNavigasi.Controls.Add(Me.btnFFBack)
        Me.pnlNavigasi.Controls.Add(Me.lblRecord)
        Me.pnlNavigasi.Controls.Add(Me.btnForward)
        Me.pnlNavigasi.Controls.Add(Me.lblOfPages)
        Me.pnlNavigasi.Controls.Add(Me.tbRecordPage)
        Me.pnlNavigasi.Controls.Add(Me.btnFFForward)
        Me.pnlNavigasi.Controls.Add(Me.btnBack)
        Me.pnlNavigasi.Location = New System.Drawing.Point(7, 288)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(425, 29)
        Me.pnlNavigasi.TabIndex = 172
        '
        'btnAddNew
        '
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Location = New System.Drawing.Point(280, 3)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(31, 23)
        Me.btnAddNew.TabIndex = 169
        Me.btnAddNew.Text = ">*"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnFFBack
        '
        Me.btnFFBack.Location = New System.Drawing.Point(56, 3)
        Me.btnFFBack.Name = "btnFFBack"
        Me.btnFFBack.Size = New System.Drawing.Size(31, 23)
        Me.btnFFBack.TabIndex = 164
        Me.btnFFBack.Text = "<<"
        Me.btnFFBack.UseVisualStyleBackColor = True
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(2, 8)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(38, 13)
        Me.lblRecord.TabIndex = 163
        Me.lblRecord.Text = "Page :"
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(206, 3)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(31, 23)
        Me.btnForward.TabIndex = 167
        Me.btnForward.Text = ">"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'lblOfPages
        '
        Me.lblOfPages.AutoSize = True
        Me.lblOfPages.Location = New System.Drawing.Point(317, 8)
        Me.lblOfPages.Name = "lblOfPages"
        Me.lblOfPages.Size = New System.Drawing.Size(65, 13)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "Of : x Pages"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(130, 5)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 20)
        Me.tbRecordPage.TabIndex = 166
        Me.tbRecordPage.Text = "1"
        Me.tbRecordPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(243, 3)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(93, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(31, 23)
        Me.btnBack.TabIndex = 165
        Me.btnBack.Text = "<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(7, 19)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(1173, 263)
        Me.dgvView.TabIndex = 130
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.lblSD)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(395, 52)
        Me.pnlTanggal.Name = "pnlTanggal"
        Me.pnlTanggal.Size = New System.Drawing.Size(285, 30)
        Me.pnlTanggal.TabIndex = 254
        '
        'lblSD
        '
        Me.lblSD.AutoSize = True
        Me.lblSD.Location = New System.Drawing.Point(129, 12)
        Me.lblSD.Name = "lblSD"
        Me.lblSD.Size = New System.Drawing.Size(21, 13)
        Me.lblSD.TabIndex = 5
        Me.lblSD.Text = "s.d"
        '
        'dtpAkhir
        '
        Me.dtpAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAkhir.Location = New System.Drawing.Point(156, 6)
        Me.dtpAkhir.Name = "dtpAkhir"
        Me.dtpAkhir.Size = New System.Drawing.Size(120, 20)
        Me.dtpAkhir.TabIndex = 3
        '
        'dtpAwal
        '
        Me.dtpAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAwal.Location = New System.Drawing.Point(3, 6)
        Me.dtpAwal.Name = "dtpAwal"
        Me.dtpAwal.Size = New System.Drawing.Size(120, 20)
        Me.dtpAwal.TabIndex = 2
        '
        'cboCariPeriode
        '
        Me.cboCariPeriode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCariPeriode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCariPeriode.FormattingEnabled = True
        Me.cboCariPeriode.IntegralHeight = False
        Me.cboCariPeriode.Location = New System.Drawing.Point(395, 57)
        Me.cboCariPeriode.Name = "cboCariPeriode"
        Me.cboCariPeriode.Size = New System.Drawing.Size(109, 21)
        Me.cboCariPeriode.TabIndex = 255
        '
        'rbCariPenjualanPerItem
        '
        Me.rbCariPenjualanPerItem.AutoSize = True
        Me.rbCariPenjualanPerItem.Location = New System.Drawing.Point(856, 58)
        Me.rbCariPenjualanPerItem.Name = "rbCariPenjualanPerItem"
        Me.rbCariPenjualanPerItem.Size = New System.Drawing.Size(113, 17)
        Me.rbCariPenjualanPerItem.TabIndex = 253
        Me.rbCariPenjualanPerItem.Text = "Penjualan per Item"
        Me.rbCariPenjualanPerItem.UseVisualStyleBackColor = True
        '
        'rbCariPenjualanPerOutlet
        '
        Me.rbCariPenjualanPerOutlet.AutoSize = True
        Me.rbCariPenjualanPerOutlet.Checked = True
        Me.rbCariPenjualanPerOutlet.Location = New System.Drawing.Point(856, 36)
        Me.rbCariPenjualanPerOutlet.Name = "rbCariPenjualanPerOutlet"
        Me.rbCariPenjualanPerOutlet.Size = New System.Drawing.Size(121, 17)
        Me.rbCariPenjualanPerOutlet.TabIndex = 251
        Me.rbCariPenjualanPerOutlet.TabStop = True
        Me.rbCariPenjualanPerOutlet.Text = "Penjualan per Outlet"
        Me.rbCariPenjualanPerOutlet.UseVisualStyleBackColor = True
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(683, 42)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(46, 13)
        Me.lblSorting.TabIndex = 184
        Me.lblSorting.Text = "Sorting :"
        '
        'cboSortingType
        '
        Me.cboSortingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortingType.FormattingEnabled = True
        Me.cboSortingType.Location = New System.Drawing.Point(785, 58)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(65, 21)
        Me.cboSortingType.TabIndex = 9
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(686, 58)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(93, 21)
        Me.cboSortingCriteria.TabIndex = 8
        '
        'lblCariSales
        '
        Me.lblCariSales.AutoSize = True
        Me.lblCariSales.Location = New System.Drawing.Point(21, 41)
        Me.lblCariSales.Name = "lblCariSales"
        Me.lblCariSales.Size = New System.Drawing.Size(39, 13)
        Me.lblCariSales.TabIndex = 178
        Me.lblCariSales.Text = "Sales :"
        '
        'cboCariSales
        '
        Me.cboCariSales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCariSales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCariSales.FormattingEnabled = True
        Me.cboCariSales.IntegralHeight = False
        Me.cboCariSales.Location = New System.Drawing.Point(21, 57)
        Me.cboCariSales.Name = "cboCariSales"
        Me.cboCariSales.Size = New System.Drawing.Size(246, 21)
        Me.cboCariSales.TabIndex = 5
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(395, 57)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(235, 20)
        Me.tbCari.TabIndex = 7
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(975, 28)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 10
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(270, 41)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(45, 13)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.IntegralHeight = False
        Me.cboKriteria.Location = New System.Drawing.Point(273, 57)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 6
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(1101, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 254
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(1081, 541)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 252
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'ofd1
        '
        '
        'lblProsesTOPKhusus
        '
        Me.lblProsesTOPKhusus.AutoSize = True
        Me.lblProsesTOPKhusus.Location = New System.Drawing.Point(16, 546)
        Me.lblProsesTOPKhusus.Name = "lblProsesTOPKhusus"
        Me.lblProsesTOPKhusus.Size = New System.Drawing.Size(114, 13)
        Me.lblProsesTOPKhusus.TabIndex = 259
        Me.lblProsesTOPKhusus.Text = "1. Proses TOP Khusus"
        '
        'btnProsesTOPKhusus
        '
        Me.btnProsesTOPKhusus.Location = New System.Drawing.Point(136, 541)
        Me.btnProsesTOPKhusus.Name = "btnProsesTOPKhusus"
        Me.btnProsesTOPKhusus.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesTOPKhusus.TabIndex = 260
        Me.btnProsesTOPKhusus.Text = "1. PROSES"
        Me.btnProsesTOPKhusus.UseVisualStyleBackColor = True
        '
        'btnProsesOverdue
        '
        Me.btnProsesOverdue.Location = New System.Drawing.Point(136, 570)
        Me.btnProsesOverdue.Name = "btnProsesOverdue"
        Me.btnProsesOverdue.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesOverdue.TabIndex = 262
        Me.btnProsesOverdue.Text = "2. PROSES"
        Me.btnProsesOverdue.UseVisualStyleBackColor = True
        '
        'lblProsesOverdue
        '
        Me.lblProsesOverdue.AutoSize = True
        Me.lblProsesOverdue.Location = New System.Drawing.Point(16, 575)
        Me.lblProsesOverdue.Name = "lblProsesOverdue"
        Me.lblProsesOverdue.Size = New System.Drawing.Size(95, 13)
        Me.lblProsesOverdue.TabIndex = 261
        Me.lblProsesOverdue.Text = "2. Proses Overdue"
        '
        'btnProsesRekap
        '
        Me.btnProsesRekap.Location = New System.Drawing.Point(409, 541)
        Me.btnProsesRekap.Name = "btnProsesRekap"
        Me.btnProsesRekap.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesRekap.TabIndex = 264
        Me.btnProsesRekap.Text = "3. PROSES"
        Me.btnProsesRekap.UseVisualStyleBackColor = True
        '
        'lblProsesRekap
        '
        Me.lblProsesRekap.AutoSize = True
        Me.lblProsesRekap.Location = New System.Drawing.Point(259, 546)
        Me.lblProsesRekap.Name = "lblProsesRekap"
        Me.lblProsesRekap.Size = New System.Drawing.Size(86, 13)
        Me.lblProsesRekap.TabIndex = 263
        Me.lblProsesRekap.Text = "4. Proses Rekap"
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCetak.Image = CType(resources.GetObject("btnCetak.Image"), System.Drawing.Image)
        Me.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetak.Location = New System.Drawing.Point(416, 11)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(120, 54)
        Me.btnCetak.TabIndex = 265
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'pnlCetak
        '
        Me.pnlCetak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCetak.Controls.Add(Me.lblSalesCetak)
        Me.pnlCetak.Controls.Add(Me.rbDetailPerItem)
        Me.pnlCetak.Controls.Add(Me.rbDetailPerOutlet)
        Me.pnlCetak.Controls.Add(Me.cboSalesCetak)
        Me.pnlCetak.Controls.Add(Me.rbPerhitunganKomisi)
        Me.pnlCetak.Controls.Add(Me.rbRekap)
        Me.pnlCetak.Controls.Add(Me.btnCetak)
        Me.pnlCetak.Location = New System.Drawing.Point(532, 538)
        Me.pnlCetak.Name = "pnlCetak"
        Me.pnlCetak.Size = New System.Drawing.Size(543, 82)
        Me.pnlCetak.TabIndex = 266
        '
        'lblSalesCetak
        '
        Me.lblSalesCetak.AutoSize = True
        Me.lblSalesCetak.Location = New System.Drawing.Point(2, 53)
        Me.lblSalesCetak.Name = "lblSalesCetak"
        Me.lblSalesCetak.Size = New System.Drawing.Size(39, 13)
        Me.lblSalesCetak.TabIndex = 271
        Me.lblSalesCetak.Text = "Sales :"
        '
        'rbDetailPerItem
        '
        Me.rbDetailPerItem.AutoSize = True
        Me.rbDetailPerItem.Location = New System.Drawing.Point(293, 27)
        Me.rbDetailPerItem.Name = "rbDetailPerItem"
        Me.rbDetailPerItem.Size = New System.Drawing.Size(117, 17)
        Me.rbDetailPerItem.TabIndex = 270
        Me.rbDetailPerItem.Text = "DETAIL PER ITEM"
        Me.rbDetailPerItem.UseVisualStyleBackColor = True
        '
        'rbDetailPerOutlet
        '
        Me.rbDetailPerOutlet.AutoSize = True
        Me.rbDetailPerOutlet.Location = New System.Drawing.Point(153, 27)
        Me.rbDetailPerOutlet.Name = "rbDetailPerOutlet"
        Me.rbDetailPerOutlet.Size = New System.Drawing.Size(134, 17)
        Me.rbDetailPerOutlet.TabIndex = 269
        Me.rbDetailPerOutlet.Text = "DETAIL PER OUTLET"
        Me.rbDetailPerOutlet.UseVisualStyleBackColor = True
        '
        'cboSalesCetak
        '
        Me.cboSalesCetak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesCetak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesCetak.FormattingEnabled = True
        Me.cboSalesCetak.IntegralHeight = False
        Me.cboSalesCetak.Location = New System.Drawing.Point(47, 50)
        Me.cboSalesCetak.Name = "cboSalesCetak"
        Me.cboSalesCetak.Size = New System.Drawing.Size(230, 21)
        Me.cboSalesCetak.TabIndex = 268
        '
        'rbPerhitunganKomisi
        '
        Me.rbPerhitunganKomisi.AutoSize = True
        Me.rbPerhitunganKomisi.Location = New System.Drawing.Point(3, 27)
        Me.rbPerhitunganKomisi.Name = "rbPerhitunganKomisi"
        Me.rbPerhitunganKomisi.Size = New System.Drawing.Size(144, 17)
        Me.rbPerhitunganKomisi.TabIndex = 267
        Me.rbPerhitunganKomisi.Text = "PERHITUNGAN KOMISI"
        Me.rbPerhitunganKomisi.UseVisualStyleBackColor = True
        '
        'rbRekap
        '
        Me.rbRekap.AutoSize = True
        Me.rbRekap.Checked = True
        Me.rbRekap.Location = New System.Drawing.Point(3, 4)
        Me.rbRekap.Name = "rbRekap"
        Me.rbRekap.Size = New System.Drawing.Size(61, 17)
        Me.rbRekap.TabIndex = 266
        Me.rbRekap.TabStop = True
        Me.rbRekap.Text = "REKAP"
        Me.rbRekap.UseVisualStyleBackColor = True
        '
        'btnProsesPerhitunganKomisi
        '
        Me.btnProsesPerhitunganKomisi.Location = New System.Drawing.Point(409, 570)
        Me.btnProsesPerhitunganKomisi.Name = "btnProsesPerhitunganKomisi"
        Me.btnProsesPerhitunganKomisi.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesPerhitunganKomisi.TabIndex = 272
        Me.btnProsesPerhitunganKomisi.Text = "4. PROSES"
        Me.btnProsesPerhitunganKomisi.UseVisualStyleBackColor = True
        '
        'lblProsesPerhitunganKomisi
        '
        Me.lblProsesPerhitunganKomisi.AutoSize = True
        Me.lblProsesPerhitunganKomisi.Location = New System.Drawing.Point(259, 575)
        Me.lblProsesPerhitunganKomisi.Name = "lblProsesPerhitunganKomisi"
        Me.lblProsesPerhitunganKomisi.Size = New System.Drawing.Size(144, 13)
        Me.lblProsesPerhitunganKomisi.TabIndex = 273
        Me.lblProsesPerhitunganKomisi.Text = "5. Proses Perhitungan Komisi"
        '
        'btnProsesPencapaianTargetItem
        '
        Me.btnProsesPencapaianTargetItem.Location = New System.Drawing.Point(136, 599)
        Me.btnProsesPencapaianTargetItem.Name = "btnProsesPencapaianTargetItem"
        Me.btnProsesPencapaianTargetItem.Size = New System.Drawing.Size(90, 23)
        Me.btnProsesPencapaianTargetItem.TabIndex = 275
        Me.btnProsesPencapaianTargetItem.Text = "3. PROSES"
        Me.btnProsesPencapaianTargetItem.UseVisualStyleBackColor = True
        '
        'lblProsesPencapaianTargetItem
        '
        Me.lblProsesPencapaianTargetItem.AutoSize = True
        Me.lblProsesPencapaianTargetItem.Location = New System.Drawing.Point(16, 604)
        Me.lblProsesPencapaianTargetItem.Name = "lblProsesPencapaianTargetItem"
        Me.lblProsesPencapaianTargetItem.Size = New System.Drawing.Size(111, 13)
        Me.lblProsesPencapaianTargetItem.TabIndex = 274
        Me.lblProsesPencapaianTargetItem.Text = "3. Proses Pencapaian"
        '
        'lblTargetItem
        '
        Me.lblTargetItem.AutoSize = True
        Me.lblTargetItem.Location = New System.Drawing.Point(26, 617)
        Me.lblTargetItem.Name = "lblTargetItem"
        Me.lblTargetItem.Size = New System.Drawing.Size(61, 13)
        Me.lblTargetItem.TabIndex = 276
        Me.lblTargetItem.Text = "Target Item"
        '
        'lblSum4
        '
        Me.lblSum4.AutoSize = True
        Me.lblSum4.Location = New System.Drawing.Point(751, 317)
        Me.lblSum4.Name = "lblSum4"
        Me.lblSum4.Size = New System.Drawing.Size(43, 13)
        Me.lblSum4.TabIndex = 181
        Me.lblSum4.Text = "SUM 4:"
        '
        'tbSum4
        '
        Me.tbSum4.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbSum4.Location = New System.Drawing.Point(800, 314)
        Me.tbSum4.Name = "tbSum4"
        Me.tbSum4.ReadOnly = True
        Me.tbSum4.Size = New System.Drawing.Size(156, 20)
        Me.tbSum4.TabIndex = 180
        Me.tbSum4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSum5
        '
        Me.lblSum5.AutoSize = True
        Me.lblSum5.Location = New System.Drawing.Point(975, 317)
        Me.lblSum5.Name = "lblSum5"
        Me.lblSum5.Size = New System.Drawing.Size(43, 13)
        Me.lblSum5.TabIndex = 183
        Me.lblSum5.Text = "SUM 5:"
        '
        'tbSum5
        '
        Me.tbSum5.BackColor = System.Drawing.Color.LemonChiffon
        Me.tbSum5.Location = New System.Drawing.Point(1024, 314)
        Me.tbSum5.Name = "tbSum5"
        Me.tbSum5.ReadOnly = True
        Me.tbSum5.Size = New System.Drawing.Size(156, 20)
        Me.tbSum5.TabIndex = 182
        Me.tbSum5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormTransaksiPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1209, 637)
        Me.Controls.Add(Me.lblTargetItem)
        Me.Controls.Add(Me.btnProsesPencapaianTargetItem)
        Me.Controls.Add(Me.lblProsesPencapaianTargetItem)
        Me.Controls.Add(Me.lblProsesPerhitunganKomisi)
        Me.Controls.Add(Me.btnProsesPerhitunganKomisi)
        Me.Controls.Add(Me.pnlCetak)
        Me.Controls.Add(Me.btnProsesRekap)
        Me.Controls.Add(Me.lblProsesRekap)
        Me.Controls.Add(Me.btnProsesOverdue)
        Me.Controls.Add(Me.lblProsesOverdue)
        Me.Controls.Add(Me.btnProsesTOPKhusus)
        Me.Controls.Add(Me.cboPeriode)
        Me.Controls.Add(Me.lblPeriodeImport)
        Me.Controls.Add(Me.lblProsesTOPKhusus)
        Me.Controls.Add(Me.pnlTanggal)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.cboCariPeriode)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.rbCariPenjualanPerItem)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.rbCariPenjualanPerOutlet)
        Me.Controls.Add(Me.pnlImportExcel)
        Me.Controls.Add(Me.lblSorting)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.cboSortingType)
        Me.Controls.Add(Me.cboCariSales)
        Me.Controls.Add(Me.cboSortingCriteria)
        Me.Controls.Add(Me.cboKriteria)
        Me.Controls.Add(Me.lblCariSales)
        Me.Controls.Add(Me.lblCari)
        Me.Controls.Add(Me.btnTampilkan)
        Me.Controls.Add(Me.tbCari)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormTransaksiPenjualan"
        Me.Text = "FORM TRANSAKSI PENJUALAN"
        Me.pnlImportExcel.ResumeLayout(False)
        Me.pnlImportExcel.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        Me.pnlCetak.ResumeLayout(False)
        Me.pnlCetak.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnProsesImport As Button
    Friend WithEvents tbNamaFile As TextBox
    Friend WithEvents lblNamaFile As Label
    Friend WithEvents lblNamaSheet As Label
    Friend WithEvents tbNamaSheet As TextBox
    Friend WithEvents pnlImportExcel As Panel
    Friend WithEvents gbView As GroupBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents lblCariSales As Label
    Friend WithEvents cboCariSales As ComboBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnKeluar As Button
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents rbPenjualanPerOutlet As RadioButton
    Friend WithEvents rbPenjualanPerItem As RadioButton
    Friend WithEvents rbCariPenjualanPerOutlet As RadioButton
    Friend WithEvents rbCariPenjualanPerItem As RadioButton
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
    Friend WithEvents cboCariPeriode As ComboBox
    Friend WithEvents rbTOPKhususDalamKota As RadioButton
    Friend WithEvents rbTOPKhususLuarKota As RadioButton
    Friend WithEvents lblSum1 As Label
    Friend WithEvents tbSum1 As TextBox
    Friend WithEvents lblProsesTOPKhusus As Label
    Friend WithEvents btnProsesTOPKhusus As Button
    Friend WithEvents btnProsesOverdue As Button
    Friend WithEvents lblProsesOverdue As Label
    Friend WithEvents rbDataPelunasan As RadioButton
    Friend WithEvents cboPeriode As ComboBox
    Friend WithEvents lblPeriodeImport As Label
    Friend WithEvents rbTmpTopKhusus As RadioButton
    Friend WithEvents btnProsesRekap As Button
    Friend WithEvents lblProsesRekap As Label
    Friend WithEvents btnCetak As Button
    Friend WithEvents pnlCetak As Panel
    Friend WithEvents rbRekap As RadioButton
    Friend WithEvents rbPerhitunganKomisi As RadioButton
    Friend WithEvents cboSalesCetak As ComboBox
    Friend WithEvents rbDetailPerOutlet As RadioButton
    Friend WithEvents rbDetailPerItem As RadioButton
    Friend WithEvents lblSalesCetak As Label
    Friend WithEvents btnProsesPerhitunganKomisi As Button
    Friend WithEvents lblProsesPerhitunganKomisi As Label
    Friend WithEvents btnProsesPencapaianTargetItem As Button
    Friend WithEvents lblProsesPencapaianTargetItem As Label
    Friend WithEvents lblTargetItem As Label
    Friend WithEvents tbSum2 As TextBox
    Friend WithEvents lblSum2 As Label
    Friend WithEvents lblSum3 As Label
    Friend WithEvents tbSum3 As TextBox
    Friend WithEvents lblSum5 As Label
    Friend WithEvents tbSum5 As TextBox
    Friend WithEvents lblSum4 As Label
    Friend WithEvents tbSum4 As TextBox
End Class
