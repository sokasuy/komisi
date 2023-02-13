<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterPenjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterPenjualan))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnProsesImport = New System.Windows.Forms.Button()
        Me.tbNamaFile = New System.Windows.Forms.TextBox()
        Me.lblNamaFile = New System.Windows.Forms.Label()
        Me.lblNamaSheet = New System.Windows.Forms.Label()
        Me.tbNamaSheet = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbPenjualanPerItem = New System.Windows.Forms.RadioButton()
        Me.rbPiutang = New System.Windows.Forms.RadioButton()
        Me.rbPenjualanPerOutlet = New System.Windows.Forms.RadioButton()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.pnlTanggal = New System.Windows.Forms.Panel()
        Me.lblSD = New System.Windows.Forms.Label()
        Me.dtpAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpAwal = New System.Windows.Forms.DateTimePicker()
        Me.rbCariPenjualanPerItem = New System.Windows.Forms.RadioButton()
        Me.rbCariPenjualanPerOutlet = New System.Windows.Forms.RadioButton()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblCariSales = New System.Windows.Forms.Label()
        Me.cboCariSales = New System.Windows.Forms.ComboBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlTanggal.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDataEntry.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 182
        Me.lblTitle.Text = "MASTER PENJUALAN"
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
        Me.btnProsesImport.Location = New System.Drawing.Point(682, 3)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbPenjualanPerItem)
        Me.Panel1.Controls.Add(Me.rbPiutang)
        Me.Panel1.Controls.Add(Me.rbPenjualanPerOutlet)
        Me.Panel1.Controls.Add(Me.tbNamaFile)
        Me.Panel1.Controls.Add(Me.tbNamaSheet)
        Me.Panel1.Controls.Add(Me.lblNamaSheet)
        Me.Panel1.Controls.Add(Me.btnBrowse)
        Me.Panel1.Controls.Add(Me.lblNamaFile)
        Me.Panel1.Controls.Add(Me.btnProsesImport)
        Me.Panel1.Location = New System.Drawing.Point(12, 617)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(960, 62)
        Me.Panel1.TabIndex = 250
        '
        'rbPenjualanPerItem
        '
        Me.rbPenjualanPerItem.AutoSize = True
        Me.rbPenjualanPerItem.Location = New System.Drawing.Point(514, 40)
        Me.rbPenjualanPerItem.Name = "rbPenjualanPerItem"
        Me.rbPenjualanPerItem.Size = New System.Drawing.Size(113, 17)
        Me.rbPenjualanPerItem.TabIndex = 252
        Me.rbPenjualanPerItem.Text = "Penjualan per Item"
        Me.rbPenjualanPerItem.UseVisualStyleBackColor = True
        '
        'rbPiutang
        '
        Me.rbPiutang.AutoSize = True
        Me.rbPiutang.Location = New System.Drawing.Point(514, 22)
        Me.rbPiutang.Name = "rbPiutang"
        Me.rbPiutang.Size = New System.Drawing.Size(61, 17)
        Me.rbPiutang.TabIndex = 251
        Me.rbPiutang.Text = "Piutang"
        Me.rbPiutang.UseVisualStyleBackColor = True
        '
        'rbPenjualanPerOutlet
        '
        Me.rbPenjualanPerOutlet.AutoSize = True
        Me.rbPenjualanPerOutlet.Checked = True
        Me.rbPenjualanPerOutlet.Location = New System.Drawing.Point(514, 6)
        Me.rbPenjualanPerOutlet.Name = "rbPenjualanPerOutlet"
        Me.rbPenjualanPerOutlet.Size = New System.Drawing.Size(122, 17)
        Me.rbPenjualanPerOutlet.TabIndex = 250
        Me.rbPenjualanPerOutlet.TabStop = True
        Me.rbPenjualanPerOutlet.Text = "Penjualan Per Outlet"
        Me.rbPenjualanPerOutlet.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.pnlTanggal)
        Me.gbView.Controls.Add(Me.rbCariPenjualanPerItem)
        Me.gbView.Controls.Add(Me.rbCariPenjualanPerOutlet)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.lblCariSales)
        Me.gbView.Controls.Add(Me.cboCariSales)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 243)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 370)
        Me.gbView.TabIndex = 251
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'pnlTanggal
        '
        Me.pnlTanggal.Controls.Add(Me.lblSD)
        Me.pnlTanggal.Controls.Add(Me.dtpAkhir)
        Me.pnlTanggal.Controls.Add(Me.dtpAwal)
        Me.pnlTanggal.Location = New System.Drawing.Point(242, 32)
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
        'rbCariPenjualanPerItem
        '
        Me.rbCariPenjualanPerItem.AutoSize = True
        Me.rbCariPenjualanPerItem.Location = New System.Drawing.Point(715, 41)
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
        Me.rbCariPenjualanPerOutlet.Location = New System.Drawing.Point(715, 19)
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
        Me.lblSorting.Location = New System.Drawing.Point(530, 25)
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
        Me.cboSortingType.Location = New System.Drawing.Point(632, 41)
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
        Me.cboSortingCriteria.Location = New System.Drawing.Point(533, 41)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(93, 21)
        Me.cboSortingCriteria.TabIndex = 8
        '
        'lblCariSales
        '
        Me.lblCariSales.AutoSize = True
        Me.lblCariSales.Location = New System.Drawing.Point(6, 24)
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
        Me.cboCariSales.Location = New System.Drawing.Point(6, 40)
        Me.cboCariSales.Name = "cboCariSales"
        Me.cboCariSales.Size = New System.Drawing.Size(109, 21)
        Me.cboCariSales.TabIndex = 5
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
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 334)
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
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(243, 40)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(235, 20)
        Me.tbCari.TabIndex = 7
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(834, 11)
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
        Me.lblCari.Location = New System.Drawing.Point(118, 24)
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
        Me.cboKriteria.Location = New System.Drawing.Point(121, 40)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 6
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(948, 263)
        Me.dgvView.TabIndex = 130
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(541, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 255
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(872, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 254
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Enabled = False
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(523, 214)
        Me.gbDataEntry.TabIndex = 253
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(271, 154)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 11
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(397, 154)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 4
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(852, 116)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 252
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'FormMasterPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 691)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterPenjualan"
        Me.Text = "FORM MASTER PENJUALAN"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlTanggal.ResumeLayout(False)
        Me.pnlTanggal.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDataEntry.ResumeLayout(False)
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
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents lblEntryType As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents ofd1 As OpenFileDialog
    Friend WithEvents rbPenjualanPerOutlet As RadioButton
    Friend WithEvents rbPiutang As RadioButton
    Friend WithEvents rbPenjualanPerItem As RadioButton
    Friend WithEvents rbCariPenjualanPerOutlet As RadioButton
    Friend WithEvents rbCariPenjualanPerItem As RadioButton
    Friend WithEvents pnlTanggal As Panel
    Friend WithEvents lblSD As Label
    Friend WithEvents dtpAkhir As DateTimePicker
    Friend WithEvents dtpAwal As DateTimePicker
End Class
