<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tje
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tje))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnote = New classlibobjswiplb.txtAlphabet()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyDetailRemarksNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtno = New classlibobjswiplb.txtAlphabet()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.lblid_source = New System.Windows.Forms.Label()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GetRateBIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetRatePajakToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtdbtotal = New classlibobjswiplb.txtCurrency()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcrtotal = New classlibobjswiplb.txtCurrency()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbluseractivity = New System.Windows.Forms.Label()
        Me.dttdate = New System.Windows.Forms.DateTimePicker()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "No. Voucher"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Note"
        '
        'txtnote
        '
        Me.txtnote.ContextMenuStrip = Me.ContextMenuStrip2
        Me.txtnote.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnote.Location = New System.Drawing.Point(126, 49)
        Me.txtnote.Name = "txtnote"
        Me.txtnote.Size = New System.Drawing.Size(325, 22)
        Me.txtnote.TabIndex = 4
        Me.txtnote.TabStop = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyDetailRemarksNotesToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(220, 26)
        '
        'CopyDetailRemarksNotesToolStripMenuItem
        '
        Me.CopyDetailRemarksNotesToolStripMenuItem.Image = CType(resources.GetObject("CopyDetailRemarksNotesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyDetailRemarksNotesToolStripMenuItem.Name = "CopyDetailRemarksNotesToolStripMenuItem"
        Me.CopyDetailRemarksNotesToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.CopyDetailRemarksNotesToolStripMenuItem.Text = "Copy Detail Remarks/Notes"
        '
        'btnlist
        '
        Me.btnlist.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(221, 431)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 123
        Me.btnlist.TabStop = False
        Me.btnlist.Text = "List"
        Me.btnlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlist.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btndelete.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btndelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndelete.Location = New System.Drawing.Point(300, 431)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 46)
        Me.btndelete.TabIndex = 124
        Me.btndelete.TabStop = False
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
        Me.btnsave.Location = New System.Drawing.Point(14, 431)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 7
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
        Me.btncancel.Location = New System.Drawing.Point(798, 431)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 125
        Me.btncancel.TabStop = False
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtno
        '
        Me.txtno.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtno.Location = New System.Drawing.Point(126, 22)
        Me.txtno.Name = "txtno"
        Me.txtno.Size = New System.Drawing.Size(187, 22)
        Me.txtno.TabIndex = 2
        '
        'btnprint
        '
        Me.btnprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(396, 431)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 349
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'dgview
        '
        Me.dgview.AllowUserToOrderColumns = True
        Me.dgview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(14, 85)
        Me.dgview.Name = "dgview"
        Me.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgview.Size = New System.Drawing.Size(874, 283)
        Me.dgview.TabIndex = 9
        Me.dgview.TabStop = False
        '
        'lblid_source
        '
        Me.lblid_source.AutoSize = True
        Me.lblid_source.Location = New System.Drawing.Point(1002, 29)
        Me.lblid_source.Name = "lblid_source"
        Me.lblid_source.Size = New System.Drawing.Size(63, 13)
        Me.lblid_source.TabIndex = 350
        Me.lblid_source.Text = "lblid_source"
        Me.lblid_source.Visible = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(116, 431)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 351
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetRateBIToolStripMenuItem, Me.GetRatePajakToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 48)
        '
        'GetRateBIToolStripMenuItem
        '
        Me.GetRateBIToolStripMenuItem.Name = "GetRateBIToolStripMenuItem"
        Me.GetRateBIToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.GetRateBIToolStripMenuItem.Text = "Get Rate BI"
        '
        'GetRatePajakToolStripMenuItem
        '
        Me.GetRatePajakToolStripMenuItem.Name = "GetRatePajakToolStripMenuItem"
        Me.GetRatePajakToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.GetRatePajakToolStripMenuItem.Text = "Get Rate Pajak"
        '
        'txtdbtotal
        '
        Me.txtdbtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdbtotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtdbtotal.Location = New System.Drawing.Point(506, 380)
        Me.txtdbtotal.Name = "txtdbtotal"
        Me.txtdbtotal.ReadOnly = True
        Me.txtdbtotal.Size = New System.Drawing.Size(152, 22)
        Me.txtdbtotal.TabIndex = 399
        Me.txtdbtotal.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(437, 383)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 400
        Me.Label9.Text = "DB Total"
        '
        'txtcrtotal
        '
        Me.txtcrtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcrtotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcrtotal.Location = New System.Drawing.Point(719, 380)
        Me.txtcrtotal.Name = "txtcrtotal"
        Me.txtcrtotal.ReadOnly = True
        Me.txtcrtotal.Size = New System.Drawing.Size(169, 22)
        Me.txtcrtotal.TabIndex = 401
        Me.txtcrtotal.TabStop = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(664, 383)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 402
        Me.Label10.Text = "CR Total"
        '
        'lbluseractivity
        '
        Me.lbluseractivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbluseractivity.AutoSize = True
        Me.lbluseractivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluseractivity.Location = New System.Drawing.Point(-238, 402)
        Me.lbluseractivity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbluseractivity.Name = "lbluseractivity"
        Me.lbluseractivity.Size = New System.Drawing.Size(94, 15)
        Me.lbluseractivity.TabIndex = 409
        Me.lbluseractivity.Text = "lbluseractivity"
        Me.lbluseractivity.Visible = False
        '
        'dttdate
        '
        Me.dttdate.CustomFormat = "dd/MM/yyyy"
        Me.dttdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdate.Location = New System.Drawing.Point(318, 24)
        Me.dttdate.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdate.Name = "dttdate"
        Me.dttdate.Size = New System.Drawing.Size(133, 20)
        Me.dttdate.TabIndex = 410
        '
        'tje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 489)
        Me.Controls.Add(Me.dttdate)
        Me.Controls.Add(Me.lbluseractivity)
        Me.Controls.Add(Me.txtcrtotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtdbtotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.lblid_source)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.txtno)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.txtnote)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "tje"
        Me.Text = "Journal Voucher"
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtnote As classlibobjswiplb.txtAlphabet
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btndelete As classlibobjswiplb.btnDelete
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents txtno As classlibobjswiplb.txtAlphabet
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents lblid_source As Label
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents txtdbtotal As classlibobjswiplb.txtCurrency
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcrtotal As classlibobjswiplb.txtCurrency
    Friend WithEvents Label10 As Label
    Friend WithEvents lbluseractivity As Label
    Friend WithEvents dttdate As DateTimePicker
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents GetRateBIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GetRatePajakToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyDetailRemarksNotesToolStripMenuItem As ToolStripMenuItem
End Class
