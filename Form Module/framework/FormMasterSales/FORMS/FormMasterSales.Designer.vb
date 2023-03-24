<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSales))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.cbLuarPulau = New System.Windows.Forms.CheckBox()
        Me.cboPerusahaan = New System.Windows.Forms.ComboBox()
        Me.lblPerusahaan = New System.Windows.Forms.Label()
        Me.cbLuarKota = New System.Windows.Forms.CheckBox()
        Me.cbDalamKota = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboWilayah = New System.Windows.Forms.ComboBox()
        Me.lblWilayah = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKode = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.tbKode = New System.Windows.Forms.TextBox()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNama = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblCariWilayah = New System.Windows.Forms.Label()
        Me.cboCariWilayah = New System.Windows.Forms.ComboBox()
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
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.gbDataEntry.SuspendLayout()
        Me.gbView.SuspendLayout()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(804, 25)
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "MASTER SALES"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(541, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 202
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(692, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 201
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.cbLuarPulau)
        Me.gbDataEntry.Controls.Add(Me.cboPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.lblPerusahaan)
        Me.gbDataEntry.Controls.Add(Me.cbLuarKota)
        Me.gbDataEntry.Controls.Add(Me.cbDalamKota)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.cboWilayah)
        Me.gbDataEntry.Controls.Add(Me.lblWilayah)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblKode)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.tbKode)
        Me.gbDataEntry.Controls.Add(Me.lblNama)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.tbNama)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(523, 180)
        Me.gbDataEntry.TabIndex = 200
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'cbLuarPulau
        '
        Me.cbLuarPulau.AutoSize = True
        Me.cbLuarPulau.Location = New System.Drawing.Point(192, 123)
        Me.cbLuarPulau.Name = "cbLuarPulau"
        Me.cbLuarPulau.Size = New System.Drawing.Size(82, 19)
        Me.cbLuarPulau.TabIndex = 225
        Me.cbLuarPulau.Text = "Luar Pulau"
        Me.cbLuarPulau.UseVisualStyleBackColor = True
        '
        'cboPerusahaan
        '
        Me.cboPerusahaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPerusahaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPerusahaan.FormattingEnabled = True
        Me.cboPerusahaan.IntegralHeight = False
        Me.cboPerusahaan.Location = New System.Drawing.Point(99, 90)
        Me.cboPerusahaan.Name = "cboPerusahaan"
        Me.cboPerusahaan.Size = New System.Drawing.Size(371, 23)
        Me.cboPerusahaan.TabIndex = 4
        '
        'lblPerusahaan
        '
        Me.lblPerusahaan.AutoSize = True
        Me.lblPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPerusahaan.Location = New System.Drawing.Point(67, 93)
        Me.lblPerusahaan.Name = "lblPerusahaan"
        Me.lblPerusahaan.Size = New System.Drawing.Size(26, 15)
        Me.lblPerusahaan.TabIndex = 224
        Me.lblPerusahaan.Text = "PT :"
        '
        'cbLuarKota
        '
        Me.cbLuarKota.AutoSize = True
        Me.cbLuarKota.Location = New System.Drawing.Point(99, 148)
        Me.cbLuarKota.Name = "cbLuarKota"
        Me.cbLuarKota.Size = New System.Drawing.Size(76, 19)
        Me.cbLuarKota.TabIndex = 222
        Me.cbLuarKota.Text = "Luar Kota"
        Me.cbLuarKota.UseVisualStyleBackColor = True
        '
        'cbDalamKota
        '
        Me.cbDalamKota.AutoSize = True
        Me.cbDalamKota.Location = New System.Drawing.Point(99, 123)
        Me.cbDalamKota.Name = "cbDalamKota"
        Me.cbDalamKota.Size = New System.Drawing.Size(87, 19)
        Me.cbDalamKota.TabIndex = 221
        Me.cbDalamKota.Text = "Dalam Kota"
        Me.cbDalamKota.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(323, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "*"
        '
        'cboWilayah
        '
        Me.cboWilayah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWilayah.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWilayah.FormattingEnabled = True
        Me.cboWilayah.IntegralHeight = False
        Me.cboWilayah.Location = New System.Drawing.Point(99, 66)
        Me.cboWilayah.Name = "cboWilayah"
        Me.cboWilayah.Size = New System.Drawing.Size(218, 23)
        Me.cboWilayah.TabIndex = 3
        '
        'lblWilayah
        '
        Me.lblWilayah.AutoSize = True
        Me.lblWilayah.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblWilayah.Location = New System.Drawing.Point(38, 69)
        Me.lblWilayah.Name = "lblWilayah"
        Me.lblWilayah.Size = New System.Drawing.Size(55, 15)
        Me.lblWilayah.TabIndex = 219
        Me.lblWilayah.Text = "Wilayah :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(212, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "*"
        '
        'lblKode
        '
        Me.lblKode.AutoSize = True
        Me.lblKode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKode.Location = New System.Drawing.Point(53, 21)
        Me.lblKode.Name = "lblKode"
        Me.lblKode.Size = New System.Drawing.Size(40, 15)
        Me.lblKode.TabIndex = 216
        Me.lblKode.Text = "Kode :"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(271, 119)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 5
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'tbKode
        '
        Me.tbKode.Location = New System.Drawing.Point(99, 18)
        Me.tbKode.Name = "tbKode"
        Me.tbKode.Size = New System.Drawing.Size(107, 23)
        Me.tbKode.TabIndex = 1
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNama.Location = New System.Drawing.Point(48, 45)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(45, 15)
        Me.lblNama.TabIndex = 214
        Me.lblNama.Text = "Nama :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(476, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "*"
        '
        'tbNama
        '
        Me.tbNama.Location = New System.Drawing.Point(99, 42)
        Me.tbNama.Name = "tbNama"
        Me.tbNama.Size = New System.Drawing.Size(371, 23)
        Me.tbNama.TabIndex = 2
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(397, 119)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 6
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.lblCariWilayah)
        Me.gbView.Controls.Add(Me.cboCariWilayah)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 214)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(780, 370)
        Me.gbView.TabIndex = 199
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(432, 22)
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
        Me.cboSortingType.Location = New System.Drawing.Point(557, 40)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(91, 21)
        Me.cboSortingType.TabIndex = 11
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(435, 40)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboSortingCriteria.TabIndex = 10
        '
        'lblCariWilayah
        '
        Me.lblCariWilayah.AutoSize = True
        Me.lblCariWilayah.Location = New System.Drawing.Point(3, 22)
        Me.lblCariWilayah.Name = "lblCariWilayah"
        Me.lblCariWilayah.Size = New System.Drawing.Size(49, 13)
        Me.lblCariWilayah.TabIndex = 178
        Me.lblCariWilayah.Text = "Wiayah :"
        '
        'cboCariWilayah
        '
        Me.cboCariWilayah.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCariWilayah.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCariWilayah.FormattingEnabled = True
        Me.cboCariWilayah.IntegralHeight = False
        Me.cboCariWilayah.Location = New System.Drawing.Point(6, 40)
        Me.cboCariWilayah.Name = "cboCariWilayah"
        Me.cboCariWilayah.Size = New System.Drawing.Size(109, 21)
        Me.cboCariWilayah.TabIndex = 7
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
        Me.tbCari.Size = New System.Drawing.Size(186, 20)
        Me.tbCari.TabIndex = 9
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(654, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 12
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
        Me.cboKriteria.TabIndex = 8
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
        Me.dgvView.Size = New System.Drawing.Size(768, 263)
        Me.dgvView.TabIndex = 130
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(672, 147)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 13
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'FormMasterSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(804, 591)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterSales"
        Me.Text = "FORM MASTER SALES"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblEntryType As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblKode As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents tbKode As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbNama As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents lblCariWilayah As Label
    Friend WithEvents cboCariWilayah As ComboBox
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
    Friend WithEvents btnKeluar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboWilayah As ComboBox
    Friend WithEvents lblWilayah As Label
    Friend WithEvents cbLuarKota As CheckBox
    Friend WithEvents cbDalamKota As CheckBox
    Friend WithEvents cboPerusahaan As ComboBox
    Friend WithEvents lblPerusahaan As Label
    Friend WithEvents cbLuarPulau As CheckBox
End Class
