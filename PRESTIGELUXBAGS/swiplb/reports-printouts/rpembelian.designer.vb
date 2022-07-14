<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class rpembelian
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rpembelian))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.txttotal = New classlibobjswiplb.txtCurrency()
        Me.dttdatefrom = New System.Windows.Forms.DateTimePicker()
        Me.dttdateto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsuppname = New classlibobjswiplb.txtAlphabet()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtsuppcode = New classlibobjswiplb.txtAlphabet()
        Me.lblidmbp = New System.Windows.Forms.Label()
        Me.txtsearch = New classlibobjswiplb.txtAlphabet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbsearch = New System.Windows.Forms.ComboBox()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btnbrowsebp = New classlibobjswiplb.btnBrowse()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 21.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(241, 40)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "LAPORAN SALES"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(762, 391)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 406
        Me.Label12.Text = "Total Pembelian"
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.AllowUserToDeleteRows = False
        Me.dgview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(12, 110)
        Me.dgview.Name = "dgview"
        Me.dgview.ReadOnly = True
        Me.dgview.Size = New System.Drawing.Size(1074, 271)
        Me.dgview.TabIndex = 408
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txttotal.Location = New System.Drawing.Point(855, 389)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(231, 22)
        Me.txttotal.TabIndex = 407
        '
        'dttdatefrom
        '
        Me.dttdatefrom.CustomFormat = "dd / MM / yyyy"
        Me.dttdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdatefrom.Location = New System.Drawing.Point(117, 55)
        Me.dttdatefrom.Name = "dttdatefrom"
        Me.dttdatefrom.Size = New System.Drawing.Size(121, 22)
        Me.dttdatefrom.TabIndex = 429
        '
        'dttdateto
        '
        Me.dttdateto.CustomFormat = "dd / MM / yyyy"
        Me.dttdateto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdateto.Location = New System.Drawing.Point(244, 55)
        Me.dttdateto.Name = "dttdateto"
        Me.dttdateto.Size = New System.Drawing.Size(121, 22)
        Me.dttdateto.TabIndex = 430
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 431
        Me.Label1.Text = "Filter Tanggal"
        '
        'txtsuppname
        '
        Me.txtsuppname.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtsuppname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsuppname.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtsuppname.Location = New System.Drawing.Point(708, 56)
        Me.txtsuppname.Name = "txtsuppname"
        Me.txtsuppname.ReadOnly = True
        Me.txtsuppname.Size = New System.Drawing.Size(222, 22)
        Me.txtsuppname.TabIndex = 439
        Me.txtsuppname.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(505, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 441
        Me.Label18.Text = "Supplier"
        Me.Label18.Visible = False
        '
        'txtsuppcode
        '
        Me.txtsuppcode.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtsuppcode.Location = New System.Drawing.Point(610, 56)
        Me.txtsuppcode.Name = "txtsuppcode"
        Me.txtsuppcode.Size = New System.Drawing.Size(92, 22)
        Me.txtsuppcode.TabIndex = 438
        Me.txtsuppcode.Visible = False
        '
        'lblidmbp
        '
        Me.lblidmbp.AutoSize = True
        Me.lblidmbp.Location = New System.Drawing.Point(505, 36)
        Me.lblidmbp.Name = "lblidmbp"
        Me.lblidmbp.Size = New System.Drawing.Size(53, 13)
        Me.lblidmbp.TabIndex = 442
        Me.lblidmbp.Text = "lblidmbp"
        Me.lblidmbp.Visible = False
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtsearch.Location = New System.Drawing.Point(216, 82)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(251, 22)
        Me.txtsearch.TabIndex = 444
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 445
        Me.Label2.Text = "Filter/Pencarian"
        '
        'cmbsearch
        '
        Me.cmbsearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsearch.FormattingEnabled = True
        Me.cmbsearch.Items.AddRange(New Object() {"CODE", "NAMA", "SUPPLIER"})
        Me.cmbsearch.Location = New System.Drawing.Point(118, 82)
        Me.cmbsearch.Name = "cmbsearch"
        Me.cmbsearch.Size = New System.Drawing.Size(92, 21)
        Me.cmbsearch.TabIndex = 446
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(12, 417)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 443
        Me.btnsave.Text = "View"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnbrowsebp
        '
        Me.btnbrowsebp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnbrowsebp.BackgroundImage = CType(resources.GetObject("btnbrowsebp.BackgroundImage"), System.Drawing.Image)
        Me.btnbrowsebp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbrowsebp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnbrowsebp.Location = New System.Drawing.Point(936, 55)
        Me.btnbrowsebp.Name = "btnbrowsebp"
        Me.btnbrowsebp.Size = New System.Drawing.Size(23, 23)
        Me.btnbrowsebp.TabIndex = 440
        Me.btnbrowsebp.UseVisualStyleBackColor = False
        Me.btnbrowsebp.Visible = False
        '
        'btnprint
        '
        Me.btnprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(219, 417)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 104
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(114, 417)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 101
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(997, 417)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 105
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'rpembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1109, 473)
        Me.Controls.Add(Me.cmbsearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lblidmbp)
        Me.Controls.Add(Me.btnbrowsebp)
        Me.Controls.Add(Me.txtsuppname)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtsuppcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dttdateto)
        Me.Controls.Add(Me.dttdatefrom)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label8)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rpembelian"
        Me.Text = "Laporan Sales"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents txttotal As classlibobjswiplb.txtCurrency
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents dttdatefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttdateto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnbrowsebp As classlibobjswiplb.btnBrowse
    Friend WithEvents txtsuppname As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtsuppcode As classlibobjswiplb.txtAlphabet
    Friend WithEvents lblidmbp As System.Windows.Forms.Label
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents txtsearch As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbsearch As System.Windows.Forms.ComboBox
End Class
