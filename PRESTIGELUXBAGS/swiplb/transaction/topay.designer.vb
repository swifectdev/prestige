<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class topay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(topay))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtno = New classlibobjswiplb.txtFree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnote = New classlibobjswiplb.txtFree()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.lblcode_maccount = New System.Windows.Forms.Label()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.dttdt = New System.Windows.Forms.DateTimePicker()
        Me.lbluseractivity = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbpaytp = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttotal = New classlibobjswiplb.txtCurrency()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncoa = New classlibobjswiplb.btnBrowse()
        Me.txtname_mcoa = New classlibobjswiplb.txtAlphabet()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "No. Dokumen"
        '
        'txtno
        '
        Me.txtno.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtno.Location = New System.Drawing.Point(18, 37)
        Me.txtno.Name = "txtno"
        Me.txtno.ReadOnly = True
        Me.txtno.Size = New System.Drawing.Size(167, 22)
        Me.txtno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(214, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Tgl Dokumen"
        '
        'dgview
        '
        Me.dgview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(12, 117)
        Me.dgview.Name = "dgview"
        Me.dgview.Size = New System.Drawing.Size(890, 242)
        Me.dgview.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 368)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Catatan"
        '
        'txtnote
        '
        Me.txtnote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtnote.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnote.Location = New System.Drawing.Point(85, 365)
        Me.txtnote.Multiline = True
        Me.txtnote.Name = "txtnote"
        Me.txtnote.Size = New System.Drawing.Size(258, 39)
        Me.txtnote.TabIndex = 24
        '
        'btnlist
        '
        Me.btnlist.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(217, 441)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 140
        Me.btnlist.Text = "List"
        Me.btnlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlist.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(112, 441)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 139
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btndelete.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btndelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndelete.Location = New System.Drawing.Point(296, 441)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 46)
        Me.btndelete.TabIndex = 0
        Me.btndelete.Text = "Delete"
        Me.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(10, 441)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 138
        Me.btnsave.Text = "Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(813, 445)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 142
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'lblcode_maccount
        '
        Me.lblcode_maccount.AutoSize = True
        Me.lblcode_maccount.Location = New System.Drawing.Point(329, 66)
        Me.lblcode_maccount.Name = "lblcode_maccount"
        Me.lblcode_maccount.Size = New System.Drawing.Size(94, 13)
        Me.lblcode_maccount.TabIndex = 145
        Me.lblcode_maccount.Text = "lblcode_maccount"
        Me.lblcode_maccount.Visible = False
        '
        'btnprint
        '
        Me.btnprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(392, 441)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 148
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'dttdt
        '
        Me.dttdt.CustomFormat = "dd/MM/yyyy"
        Me.dttdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt.Location = New System.Drawing.Point(190, 37)
        Me.dttdt.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt.Name = "dttdt"
        Me.dttdt.Size = New System.Drawing.Size(107, 20)
        Me.dttdt.TabIndex = 372
        '
        'lbluseractivity
        '
        Me.lbluseractivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbluseractivity.AutoSize = True
        Me.lbluseractivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluseractivity.Location = New System.Drawing.Point(15, 423)
        Me.lbluseractivity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbluseractivity.Name = "lbluseractivity"
        Me.lbluseractivity.Size = New System.Drawing.Size(94, 15)
        Me.lbluseractivity.TabIndex = 374
        Me.lbluseractivity.Text = "lbluseractivity"
        Me.lbluseractivity.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 376
        Me.Label8.Text = "Jenis"
        '
        'cmbpaytp
        '
        Me.cmbpaytp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpaytp.FormattingEnabled = True
        Me.cmbpaytp.Items.AddRange(New Object() {"UANG MASUK", "UANG KELUAR", "CHARITY"})
        Me.cmbpaytp.Location = New System.Drawing.Point(123, 63)
        Me.cmbpaytp.Name = "cmbpaytp"
        Me.cmbpaytp.Size = New System.Drawing.Size(194, 21)
        Me.cmbpaytp.TabIndex = 375
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(495, 368)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 378
        Me.Label9.Text = "Total"
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.BackColor = System.Drawing.SystemColors.Control
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txttotal.Location = New System.Drawing.Point(582, 366)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(320, 22)
        Me.txttotal.TabIndex = 377
        Me.txttotal.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 380
        Me.Label1.Text = "Rekening"
        '
        'btncoa
        '
        Me.btncoa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncoa.BackgroundImage = CType(resources.GetObject("btncoa.BackgroundImage"), System.Drawing.Image)
        Me.btncoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncoa.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncoa.Location = New System.Drawing.Point(449, 88)
        Me.btncoa.Name = "btncoa"
        Me.btncoa.Size = New System.Drawing.Size(23, 23)
        Me.btncoa.TabIndex = 394
        Me.btncoa.UseVisualStyleBackColor = False
        '
        'txtname_mcoa
        '
        Me.txtname_mcoa.BackColor = System.Drawing.SystemColors.Control
        Me.txtname_mcoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname_mcoa.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_mcoa.Location = New System.Drawing.Point(123, 88)
        Me.txtname_mcoa.Name = "txtname_mcoa"
        Me.txtname_mcoa.ReadOnly = True
        Me.txtname_mcoa.Size = New System.Drawing.Size(320, 22)
        Me.txtname_mcoa.TabIndex = 396
        Me.txtname_mcoa.TabStop = False
        '
        'topay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 503)
        Me.Controls.Add(Me.btncoa)
        Me.Controls.Add(Me.txtname_mcoa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbpaytp)
        Me.Controls.Add(Me.lbluseractivity)
        Me.Controls.Add(Me.dttdt)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.lblcode_maccount)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.txtnote)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtno)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "topay"
        Me.Text = "Voucher"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtno As classlibobjswiplb.txtFree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtnote As classlibobjswiplb.txtFree
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents btndelete As classlibobjswiplb.btnDelete
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents lblcode_maccount As Label
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents dttdt As DateTimePicker
    Friend WithEvents lbluseractivity As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbpaytp As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txttotal As classlibobjswiplb.txtCurrency
    Friend WithEvents Label1 As Label
    Friend WithEvents btncoa As classlibobjswiplb.btnBrowse
    Friend WithEvents txtname_mcoa As classlibobjswiplb.txtAlphabet
End Class
