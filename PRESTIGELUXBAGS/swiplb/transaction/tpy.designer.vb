<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tpy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tpy))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtno = New classlibobjswiplb.txtAlphabet()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblid_mcust = New System.Windows.Forms.Label()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.txtnote = New classlibobjswiplb.txtNote()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttotal = New classlibobjswiplb.txtCurrency()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtname_mcust = New classlibobjswiplb.txtAlphabet()
        Me.txttotalpiutang = New classlibobjswiplb.txtCurrency()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnbrowsecust = New classlibobjswiplb.btnBrowse()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbpaytp = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chfilterdt = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dttdt = New System.Windows.Forms.DateTimePicker()
        Me.btnbrowsecoa = New classlibobjswiplb.btnBrowse()
        Me.txtname_maccount = New classlibobjswiplb.txtAlphabet()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TransactionJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chpayall = New System.Windows.Forms.CheckBox()
        Me.lbluseractivity = New System.Windows.Forms.Label()
        Me.lblcode_maccount = New System.Windows.Forms.Label()
        Me.txtongkir = New classlibobjswiplb.txtCurrency()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbalance = New classlibobjswiplb.txtCurrency()
        Me.BtnBrowse1 = New classlibobjswiplb.btnBrowse()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.BtnBrowse2 = New classlibobjswiplb.btnBrowse()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transaction No."
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgview.Location = New System.Drawing.Point(12, 103)
        Me.dgview.Name = "dgview"
        Me.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgview.Size = New System.Drawing.Size(1078, 228)
        Me.dgview.TabIndex = 200
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(140, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem1.Text = "Copy Total..."
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(996, 433)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 104
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtno
        '
        Me.txtno.BackColor = System.Drawing.SystemColors.Control
        Me.txtno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtno.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtno.Location = New System.Drawing.Point(123, 21)
        Me.txtno.Name = "txtno"
        Me.txtno.ReadOnly = True
        Me.txtno.Size = New System.Drawing.Size(256, 22)
        Me.txtno.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(600, 435)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 318
        Me.Label10.Text = "Customer/Buyer"
        Me.Label10.Visible = False
        '
        'lblid_mcust
        '
        Me.lblid_mcust.AutoSize = True
        Me.lblid_mcust.Location = New System.Drawing.Point(491, 440)
        Me.lblid_mcust.Name = "lblid_mcust"
        Me.lblid_mcust.Size = New System.Drawing.Size(65, 13)
        Me.lblid_mcust.TabIndex = 338
        Me.lblid_mcust.Text = "lblid_mcust"
        Me.lblid_mcust.Visible = False
        '
        'btnprint
        '
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(401, 431)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 340
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'btnlist
        '
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(226, 431)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 339
        Me.btnlist.Text = "List"
        Me.btnlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlist.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(124, 431)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(96, 46)
        Me.btnrefresh.TabIndex = 342
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btndelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndelete.Location = New System.Drawing.Point(305, 431)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 46)
        Me.btndelete.TabIndex = 343
        Me.btndelete.Text = "Delete"
        Me.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(22, 431)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 341
        Me.btnsave.Text = "Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'txtnote
        '
        Me.txtnote.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnote.Location = New System.Drawing.Point(123, 339)
        Me.txtnote.Multiline = True
        Me.txtnote.Name = "txtnote"
        Me.txtnote.Size = New System.Drawing.Size(277, 47)
        Me.txtnote.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 342)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 345
        Me.Label2.Text = "Note"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(484, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 347
        Me.Label7.Text = "Date"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.Control
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txttotal.Location = New System.Drawing.Point(861, 393)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(229, 22)
        Me.txttotal.TabIndex = 351
        Me.txttotal.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(761, 397)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 360
        Me.Label9.Text = "Total Payment"
        '
        'txtname_mcust
        '
        Me.txtname_mcust.BackColor = System.Drawing.SystemColors.Control
        Me.txtname_mcust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname_mcust.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_mcust.Location = New System.Drawing.Point(699, 433)
        Me.txtname_mcust.Name = "txtname_mcust"
        Me.txtname_mcust.ReadOnly = True
        Me.txtname_mcust.Size = New System.Drawing.Size(256, 22)
        Me.txtname_mcust.TabIndex = 361
        Me.txtname_mcust.TabStop = False
        Me.txtname_mcust.Visible = False
        '
        'txttotalpiutang
        '
        Me.txttotalpiutang.BackColor = System.Drawing.SystemColors.Control
        Me.txttotalpiutang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotalpiutang.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txttotalpiutang.Location = New System.Drawing.Point(861, 368)
        Me.txttotalpiutang.Name = "txttotalpiutang"
        Me.txttotalpiutang.ReadOnly = True
        Me.txttotalpiutang.Size = New System.Drawing.Size(229, 22)
        Me.txttotalpiutang.TabIndex = 366
        Me.txttotalpiutang.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(761, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 367
        Me.Label5.Text = "Total Invoice"
        '
        'btnbrowsecust
        '
        Me.btnbrowsecust.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnbrowsecust.BackgroundImage = CType(resources.GetObject("btnbrowsecust.BackgroundImage"), System.Drawing.Image)
        Me.btnbrowsecust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbrowsecust.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnbrowsecust.Location = New System.Drawing.Point(961, 432)
        Me.btnbrowsecust.Name = "btnbrowsecust"
        Me.btnbrowsecust.Size = New System.Drawing.Size(23, 23)
        Me.btnbrowsecust.TabIndex = 3
        Me.btnbrowsecust.UseVisualStyleBackColor = False
        Me.btnbrowsecust.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 372
        Me.Label6.Text = "Transfer Ke"
        '
        'cmbpaytp
        '
        Me.cmbpaytp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpaytp.FormattingEnabled = True
        Me.cmbpaytp.Items.AddRange(New Object() {"BANK TRANSFER", "CASH", "CREDIT CARD", "MARKETPLACE", "CHEQUE/GIRO"})
        Me.cmbpaytp.Location = New System.Drawing.Point(123, 49)
        Me.cmbpaytp.Name = "cmbpaytp"
        Me.cmbpaytp.Size = New System.Drawing.Size(256, 21)
        Me.cmbpaytp.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 374
        Me.Label8.Text = "Metode Bayar"
        '
        'chfilterdt
        '
        Me.chfilterdt.AutoSize = True
        Me.chfilterdt.Location = New System.Drawing.Point(805, 22)
        Me.chfilterdt.Name = "chfilterdt"
        Me.chfilterdt.Size = New System.Drawing.Size(15, 14)
        Me.chfilterdt.TabIndex = 375
        Me.chfilterdt.UseVisualStyleBackColor = True
        Me.chfilterdt.Visible = False
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(163, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItem2.Text = "Get/Refresh Rate"
        '
        'dttdt
        '
        Me.dttdt.CustomFormat = "dd/MM/yyyy"
        Me.dttdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt.Location = New System.Drawing.Point(584, 20)
        Me.dttdt.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt.Name = "dttdt"
        Me.dttdt.Size = New System.Drawing.Size(216, 22)
        Me.dttdt.TabIndex = 401
        '
        'btnbrowsecoa
        '
        Me.btnbrowsecoa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnbrowsecoa.BackgroundImage = CType(resources.GetObject("btnbrowsecoa.BackgroundImage"), System.Drawing.Image)
        Me.btnbrowsecoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbrowsecoa.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnbrowsecoa.Location = New System.Drawing.Point(385, 74)
        Me.btnbrowsecoa.Name = "btnbrowsecoa"
        Me.btnbrowsecoa.Size = New System.Drawing.Size(23, 23)
        Me.btnbrowsecoa.TabIndex = 403
        Me.btnbrowsecoa.UseVisualStyleBackColor = False
        '
        'txtname_maccount
        '
        Me.txtname_maccount.BackColor = System.Drawing.SystemColors.Control
        Me.txtname_maccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname_maccount.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_maccount.Location = New System.Drawing.Point(123, 77)
        Me.txtname_maccount.Name = "txtname_maccount"
        Me.txtname_maccount.ReadOnly = True
        Me.txtname_maccount.Size = New System.Drawing.Size(256, 22)
        Me.txtname_maccount.TabIndex = 404
        Me.txtname_maccount.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionJournalToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 26)
        '
        'TransactionJournalToolStripMenuItem
        '
        Me.TransactionJournalToolStripMenuItem.Image = CType(resources.GetObject("TransactionJournalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TransactionJournalToolStripMenuItem.Name = "TransactionJournalToolStripMenuItem"
        Me.TransactionJournalToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.TransactionJournalToolStripMenuItem.Text = "Transaction Journal..."
        '
        'chpayall
        '
        Me.chpayall.AutoSize = True
        Me.chpayall.Location = New System.Drawing.Point(414, 79)
        Me.chpayall.Name = "chpayall"
        Me.chpayall.Size = New System.Drawing.Size(59, 17)
        Me.chpayall.TabIndex = 405
        Me.chpayall.Text = "Pay All"
        Me.chpayall.UseVisualStyleBackColor = True
        '
        'lbluseractivity
        '
        Me.lbluseractivity.AutoSize = True
        Me.lbluseractivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluseractivity.Location = New System.Drawing.Point(24, 413)
        Me.lbluseractivity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbluseractivity.Name = "lbluseractivity"
        Me.lbluseractivity.Size = New System.Drawing.Size(94, 15)
        Me.lbluseractivity.TabIndex = 427
        Me.lbluseractivity.Text = "lbluseractivity"
        Me.lbluseractivity.Visible = False
        '
        'lblcode_maccount
        '
        Me.lblcode_maccount.AutoSize = True
        Me.lblcode_maccount.Location = New System.Drawing.Point(491, 464)
        Me.lblcode_maccount.Name = "lblcode_maccount"
        Me.lblcode_maccount.Size = New System.Drawing.Size(100, 13)
        Me.lblcode_maccount.TabIndex = 430
        Me.lblcode_maccount.Text = "lblcode_maccount"
        Me.lblcode_maccount.Visible = False
        '
        'txtongkir
        '
        Me.txtongkir.BackColor = System.Drawing.SystemColors.Control
        Me.txtongkir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtongkir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtongkir.Location = New System.Drawing.Point(861, 342)
        Me.txtongkir.Name = "txtongkir"
        Me.txtongkir.ReadOnly = True
        Me.txtongkir.Size = New System.Drawing.Size(229, 22)
        Me.txtongkir.TabIndex = 428
        Me.txtongkir.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(761, 344)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 429
        Me.Label3.Text = "Total Ongkir"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(629, 466)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 432
        Me.Label4.Text = "Saldo Buyer"
        Me.Label4.Visible = False
        '
        'txtbalance
        '
        Me.txtbalance.BackColor = System.Drawing.SystemColors.Control
        Me.txtbalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbalance.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtbalance.Location = New System.Drawing.Point(729, 464)
        Me.txtbalance.Name = "txtbalance"
        Me.txtbalance.ReadOnly = True
        Me.txtbalance.Size = New System.Drawing.Size(216, 22)
        Me.txtbalance.TabIndex = 431
        Me.txtbalance.TabStop = False
        Me.txtbalance.Visible = False
        '
        'BtnBrowse1
        '
        Me.BtnBrowse1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse1.BackgroundImage = CType(resources.GetObject("BtnBrowse1.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse1.Location = New System.Drawing.Point(951, 464)
        Me.BtnBrowse1.Name = "BtnBrowse1"
        Me.BtnBrowse1.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse1.TabIndex = 433
        Me.BtnBrowse1.UseVisualStyleBackColor = False
        Me.BtnBrowse1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(484, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 440
        Me.Label11.Text = "Periode"
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(697, 48)
        Me.dtto.Margin = New System.Windows.Forms.Padding(2)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(103, 22)
        Me.dtto.TabIndex = 439
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(584, 48)
        Me.dtfrom.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(97, 22)
        Me.dtfrom.TabIndex = 438
        '
        'BtnBrowse2
        '
        Me.BtnBrowse2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse2.BackgroundImage = CType(resources.GetObject("BtnBrowse2.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse2.Location = New System.Drawing.Point(808, 48)
        Me.BtnBrowse2.Name = "BtnBrowse2"
        Me.BtnBrowse2.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse2.TabIndex = 437
        Me.BtnBrowse2.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(845, 84)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(245, 15)
        Me.Label12.TabIndex = 441
        Me.Label12.Text = "*Double Click untuk lihat rincian item"
        Me.Label12.Visible = False
        '
        'tpy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1114, 503)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.BtnBrowse2)
        Me.Controls.Add(Me.BtnBrowse1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtbalance)
        Me.Controls.Add(Me.lblcode_maccount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtongkir)
        Me.Controls.Add(Me.lbluseractivity)
        Me.Controls.Add(Me.chpayall)
        Me.Controls.Add(Me.btnbrowsecoa)
        Me.Controls.Add(Me.txtname_maccount)
        Me.Controls.Add(Me.dttdt)
        Me.Controls.Add(Me.chfilterdt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbpaytp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnbrowsecust)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttotalpiutang)
        Me.Controls.Add(Me.txtname_mcust)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtnote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.lblid_mcust)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.txtno)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "tpy"
        Me.Text = "Payment from Customer/Buyer"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtno As classlibobjswiplb.txtAlphabet
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblid_mcust As System.Windows.Forms.Label
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents btndelete As classlibobjswiplb.btnDelete
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents txtnote As classlibobjswiplb.txtNote
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txttotal As classlibobjswiplb.txtCurrency
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtname_mcust As classlibobjswiplb.txtAlphabet
    Friend WithEvents txttotalpiutang As classlibobjswiplb.txtCurrency
    Friend WithEvents Label5 As Label
    Friend WithEvents btnbrowsecust As classlibobjswiplb.btnBrowse
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbpaytp As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chfilterdt As CheckBox
    Friend WithEvents dttdt As DateTimePicker
    Friend WithEvents btnbrowsecoa As classlibobjswiplb.btnBrowse
    Friend WithEvents txtname_maccount As classlibobjswiplb.txtAlphabet
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TransactionJournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents chpayall As CheckBox
    Friend WithEvents lbluseractivity As Label
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents lblcode_maccount As Label
    Friend WithEvents txtongkir As classlibobjswiplb.txtCurrency
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtbalance As classlibobjswiplb.txtCurrency
    Friend WithEvents BtnBrowse1 As classlibobjswiplb.btnBrowse
    Friend WithEvents Label11 As Label
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents BtnBrowse2 As classlibobjswiplb.btnBrowse
    Friend WithEvents Label12 As Label
End Class
