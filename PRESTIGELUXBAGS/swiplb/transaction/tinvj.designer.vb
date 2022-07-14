<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tinvj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tinvj))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtno = New classlibobjswiplb.txtFree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnote = New classlibobjswiplb.txtFree()
        Me.dttdt = New System.Windows.Forms.DateTimePicker()
        Me.lbluseractivity = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttotal = New classlibobjswiplb.txtCurrency()
        Me.txtname_mcust = New classlibobjswiplb.txtAlphabet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txthp_mcust = New classlibobjswiplb.txtAlphabet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblcode_mcust = New System.Windows.Forms.Label()
        Me.btnbrowsecust = New classlibobjswiplb.btnBrowse()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.lbldocstatus = New System.Windows.Forms.Label()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "No. Dokumen"
        '
        'txtno
        '
        Me.txtno.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtno.Location = New System.Drawing.Point(112, 21)
        Me.txtno.Name = "txtno"
        Me.txtno.ReadOnly = True
        Me.txtno.Size = New System.Drawing.Size(199, 22)
        Me.txtno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 49)
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
        Me.dgview.Location = New System.Drawing.Point(12, 88)
        Me.dgview.Name = "dgview"
        Me.dgview.Size = New System.Drawing.Size(890, 271)
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
        'dttdt
        '
        Me.dttdt.CustomFormat = "dd/MM/yyyy"
        Me.dttdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt.Location = New System.Drawing.Point(112, 49)
        Me.dttdt.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt.Name = "dttdt"
        Me.dttdt.Size = New System.Drawing.Size(199, 20)
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
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(647, 368)
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
        Me.txttotal.Location = New System.Drawing.Point(700, 366)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(202, 22)
        Me.txttotal.TabIndex = 377
        Me.txttotal.TabStop = False
        '
        'txtname_mcust
        '
        Me.txtname_mcust.BackColor = System.Drawing.SystemColors.Control
        Me.txtname_mcust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname_mcust.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_mcust.Location = New System.Drawing.Point(455, 22)
        Me.txtname_mcust.Name = "txtname_mcust"
        Me.txtname_mcust.ReadOnly = True
        Me.txtname_mcust.Size = New System.Drawing.Size(199, 22)
        Me.txtname_mcust.TabIndex = 381
        Me.txtname_mcust.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(358, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 380
        Me.Label10.Text = "Customer/Buyer"
        '
        'txthp_mcust
        '
        Me.txthp_mcust.BackColor = System.Drawing.SystemColors.Control
        Me.txthp_mcust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txthp_mcust.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txthp_mcust.Location = New System.Drawing.Point(455, 49)
        Me.txthp_mcust.Name = "txthp_mcust"
        Me.txthp_mcust.ReadOnly = True
        Me.txthp_mcust.Size = New System.Drawing.Size(199, 22)
        Me.txthp_mcust.TabIndex = 382
        Me.txthp_mcust.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "HP"
        '
        'lblcode_mcust
        '
        Me.lblcode_mcust.AutoSize = True
        Me.lblcode_mcust.Location = New System.Drawing.Point(494, 459)
        Me.lblcode_mcust.Name = "lblcode_mcust"
        Me.lblcode_mcust.Size = New System.Drawing.Size(75, 13)
        Me.lblcode_mcust.TabIndex = 384
        Me.lblcode_mcust.Text = "lblcode_mcust"
        Me.lblcode_mcust.Visible = False
        '
        'btnbrowsecust
        '
        Me.btnbrowsecust.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnbrowsecust.BackgroundImage = CType(resources.GetObject("btnbrowsecust.BackgroundImage"), System.Drawing.Image)
        Me.btnbrowsecust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbrowsecust.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnbrowsecust.Location = New System.Drawing.Point(660, 22)
        Me.btnbrowsecust.Name = "btnbrowsecust"
        Me.btnbrowsecust.Size = New System.Drawing.Size(23, 23)
        Me.btnbrowsecust.TabIndex = 379
        Me.btnbrowsecust.UseVisualStyleBackColor = False
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
        'lbldocstatus
        '
        Me.lbldocstatus.AutoSize = True
        Me.lbldocstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldocstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbldocstatus.Location = New System.Drawing.Point(700, 21)
        Me.lbldocstatus.Name = "lbldocstatus"
        Me.lbldocstatus.Size = New System.Drawing.Size(202, 25)
        Me.lbldocstatus.TabIndex = 483
        Me.lbldocstatus.Text = "STATUS BARANG"
        Me.lbldocstatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tinvj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 503)
        Me.Controls.Add(Me.lbldocstatus)
        Me.Controls.Add(Me.lblcode_mcust)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txthp_mcust)
        Me.Controls.Add(Me.btnbrowsecust)
        Me.Controls.Add(Me.txtname_mcust)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lbluseractivity)
        Me.Controls.Add(Me.dttdt)
        Me.Controls.Add(Me.btnprint)
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
        Me.Name = "tinvj"
        Me.Text = "Invoice Jasa"
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
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents dttdt As DateTimePicker
    Friend WithEvents lbluseractivity As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txttotal As classlibobjswiplb.txtCurrency
    Friend WithEvents btnbrowsecust As classlibobjswiplb.btnBrowse
    Friend WithEvents txtname_mcust As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label10 As Label
    Friend WithEvents txthp_mcust As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label1 As Label
    Friend WithEvents lblcode_mcust As Label
    Friend WithEvents lbldocstatus As Label
End Class
