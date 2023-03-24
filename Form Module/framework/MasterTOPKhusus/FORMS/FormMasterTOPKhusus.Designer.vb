<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterTOPKhusus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterTOPKhusus))
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.cbDiscontinue = New System.Windows.Forms.CheckBox()
        Me.lblSampaiDengan = New System.Windows.Forms.Label()
        Me.cboPeriodeSelesaiBerlaku = New System.Windows.Forms.ComboBox()
        Me.lblPeriodeBerlaku = New System.Windows.Forms.Label()
        Me.cboPeriodeMulaiBerlaku = New System.Windows.Forms.ComboBox()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTOPKhusus = New System.Windows.Forms.Label()
        Me.tbTOPKhusus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlNavigasi.SuspendLayout()
        Me.gbDataEntry.SuspendLayout()
        Me.gbView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.cboSortingType.TabIndex = 60
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
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(435, 40)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboSortingCriteria.TabIndex = 55
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(136, 40)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(293, 20)
        Me.tbCari.TabIndex = 50
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(654, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 65
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(8, 23)
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
        Me.cboKriteria.Location = New System.Drawing.Point(11, 39)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 45
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(541, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 208
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
        Me.clbUserRight.TabIndex = 207
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cbDiscontinue)
        Me.gbDataEntry.Controls.Add(Me.lblSampaiDengan)
        Me.gbDataEntry.Controls.Add(Me.cboPeriodeSelesaiBerlaku)
        Me.gbDataEntry.Controls.Add(Me.lblPeriodeBerlaku)
        Me.gbDataEntry.Controls.Add(Me.cboPeriodeMulaiBerlaku)
        Me.gbDataEntry.Controls.Add(Me.cboCustomer)
        Me.gbDataEntry.Controls.Add(Me.Label3)
        Me.gbDataEntry.Controls.Add(Me.lblTOPKhusus)
        Me.gbDataEntry.Controls.Add(Me.tbTOPKhusus)
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.lblCustomer)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 28)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(523, 180)
        Me.gbDataEntry.TabIndex = 206
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'cbDiscontinue
        '
        Me.cbDiscontinue.AutoSize = True
        Me.cbDiscontinue.Location = New System.Drawing.Point(121, 95)
        Me.cbDiscontinue.Name = "cbDiscontinue"
        Me.cbDiscontinue.Size = New System.Drawing.Size(89, 19)
        Me.cbDiscontinue.TabIndex = 25
        Me.cbDiscontinue.Text = "Discontinue"
        Me.cbDiscontinue.UseVisualStyleBackColor = True
        '
        'lblSampaiDengan
        '
        Me.lblSampaiDengan.AutoSize = True
        Me.lblSampaiDengan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSampaiDengan.Location = New System.Drawing.Point(308, 69)
        Me.lblSampaiDengan.Name = "lblSampaiDengan"
        Me.lblSampaiDengan.Size = New System.Drawing.Size(12, 15)
        Me.lblSampaiDengan.TabIndex = 233
        Me.lblSampaiDengan.Text = "-"
        '
        'cboPeriodeSelesaiBerlaku
        '
        Me.cboPeriodeSelesaiBerlaku.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPeriodeSelesaiBerlaku.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPeriodeSelesaiBerlaku.FormattingEnabled = True
        Me.cboPeriodeSelesaiBerlaku.IntegralHeight = False
        Me.cboPeriodeSelesaiBerlaku.Location = New System.Drawing.Point(326, 66)
        Me.cboPeriodeSelesaiBerlaku.Name = "cboPeriodeSelesaiBerlaku"
        Me.cboPeriodeSelesaiBerlaku.Size = New System.Drawing.Size(160, 23)
        Me.cboPeriodeSelesaiBerlaku.TabIndex = 20
        '
        'lblPeriodeBerlaku
        '
        Me.lblPeriodeBerlaku.AutoSize = True
        Me.lblPeriodeBerlaku.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeriodeBerlaku.Location = New System.Drawing.Point(20, 69)
        Me.lblPeriodeBerlaku.Name = "lblPeriodeBerlaku"
        Me.lblPeriodeBerlaku.Size = New System.Drawing.Size(95, 15)
        Me.lblPeriodeBerlaku.TabIndex = 231
        Me.lblPeriodeBerlaku.Text = "Periode Berlaku :"
        '
        'cboPeriodeMulaiBerlaku
        '
        Me.cboPeriodeMulaiBerlaku.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPeriodeMulaiBerlaku.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPeriodeMulaiBerlaku.FormattingEnabled = True
        Me.cboPeriodeMulaiBerlaku.IntegralHeight = False
        Me.cboPeriodeMulaiBerlaku.Location = New System.Drawing.Point(121, 66)
        Me.cboPeriodeMulaiBerlaku.Name = "cboPeriodeMulaiBerlaku"
        Me.cboPeriodeMulaiBerlaku.Size = New System.Drawing.Size(160, 23)
        Me.cboPeriodeMulaiBerlaku.TabIndex = 15
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.IntegralHeight = False
        Me.cboCustomer.Location = New System.Drawing.Point(121, 18)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(321, 23)
        Me.cboCustomer.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(212, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 15)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "*"
        '
        'lblTOPKhusus
        '
        Me.lblTOPKhusus.AutoSize = True
        Me.lblTOPKhusus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTOPKhusus.Location = New System.Drawing.Point(40, 45)
        Me.lblTOPKhusus.Name = "lblTOPKhusus"
        Me.lblTOPKhusus.Size = New System.Drawing.Size(75, 15)
        Me.lblTOPKhusus.TabIndex = 227
        Me.lblTOPKhusus.Text = "TOP Khusus :"
        '
        'tbTOPKhusus
        '
        Me.tbTOPKhusus.Location = New System.Drawing.Point(121, 42)
        Me.tbTOPKhusus.Name = "tbTOPKhusus"
        Me.tbTOPKhusus.Size = New System.Drawing.Size(85, 23)
        Me.tbTOPKhusus.TabIndex = 10
        Me.tbTOPKhusus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(448, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "*"
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCustomer.Location = New System.Drawing.Point(50, 21)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(65, 15)
        Me.lblCustomer.TabIndex = 216
        Me.lblCustomer.Text = "Customer :"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(271, 119)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 30
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(397, 119)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 35
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
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 214)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(780, 370)
        Me.gbView.TabIndex = 205
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
        Me.btnKeluar.TabIndex = 70
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
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
        Me.lblTitle.TabIndex = 204
        Me.lblTitle.Text = "MASTER TOP KHUSUS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(287, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "*"
        '
        'FormMasterTOPKhusus
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
        Me.Name = "FormMasterTOPKhusus"
        Me.Text = "FORM MASTER TOP KHUSUS"
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents lblEntryType As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCustomer As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents gbView As GroupBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents btnKeluar As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTOPKhusus As Label
    Friend WithEvents tbTOPKhusus As TextBox
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents cboPeriodeMulaiBerlaku As ComboBox
    Friend WithEvents lblPeriodeBerlaku As Label
    Friend WithEvents cboPeriodeSelesaiBerlaku As ComboBox
    Friend WithEvents lblSampaiDengan As Label
    Friend WithEvents cbDiscontinue As CheckBox
    Friend WithEvents Label2 As Label
End Class
