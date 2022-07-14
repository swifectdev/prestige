<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class rstokbrg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rstokbrg))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcode_msupp = New classlibobjswiplb.txtFree()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtaddr1 = New classlibobjswiplb.txtFree()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtno = New classlibobjswiplb.txtFree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SyncOnlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicateRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ItemDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtname_msupp = New classlibobjswiplb.txtFree()
        Me.lblid_msupp = New System.Windows.Forms.Label()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.dttdt = New System.Windows.Forms.DateTimePicker()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DuplicateTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepairLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataOverviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtFree8 = New classlibobjswiplb.txtFree()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtFree2 = New classlibobjswiplb.txtFree()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFree1 = New classlibobjswiplb.txtFree()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtFree9 = New classlibobjswiplb.txtFree()
        Me.TxtCurrency2 = New classlibobjswiplb.txtCurrency()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TxtCurrency1 = New classlibobjswiplb.txtCurrency()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtFree7 = New classlibobjswiplb.txtFree()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtFree3 = New classlibobjswiplb.txtFree()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtFree10 = New classlibobjswiplb.txtFree()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consignee"
        '
        'txtcode_msupp
        '
        Me.txtcode_msupp.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcode_msupp.Location = New System.Drawing.Point(107, 24)
        Me.txtcode_msupp.Name = "txtcode_msupp"
        Me.txtcode_msupp.Size = New System.Drawing.Size(66, 22)
        Me.txtcode_msupp.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Alamat"
        '
        'txtaddr1
        '
        Me.txtaddr1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtaddr1.Location = New System.Drawing.Point(107, 103)
        Me.txtaddr1.Multiline = True
        Me.txtaddr1.Name = "txtaddr1"
        Me.txtaddr1.ReadOnly = True
        Me.txtaddr1.Size = New System.Drawing.Size(321, 39)
        Me.txtaddr1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(435, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Ship To"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Consign No."
        '
        'txtno
        '
        Me.txtno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtno.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtno.Location = New System.Drawing.Point(130, 24)
        Me.txtno.Name = "txtno"
        Me.txtno.ReadOnly = True
        Me.txtno.Size = New System.Drawing.Size(127, 22)
        Me.txtno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(263, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Tgl Consign"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyncOnlineToolStripMenuItem, Me.DuplicateRowToolStripMenuItem, Me.ToolStripSeparator1, Me.ItemDetailToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(151, 76)
        '
        'SyncOnlineToolStripMenuItem
        '
        Me.SyncOnlineToolStripMenuItem.Image = CType(resources.GetObject("SyncOnlineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SyncOnlineToolStripMenuItem.Name = "SyncOnlineToolStripMenuItem"
        Me.SyncOnlineToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SyncOnlineToolStripMenuItem.Text = "Update Qty"
        '
        'DuplicateRowToolStripMenuItem
        '
        Me.DuplicateRowToolStripMenuItem.Image = CType(resources.GetObject("DuplicateRowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DuplicateRowToolStripMenuItem.Name = "DuplicateRowToolStripMenuItem"
        Me.DuplicateRowToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DuplicateRowToolStripMenuItem.Text = "Duplicate Row"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'ItemDetailToolStripMenuItem
        '
        Me.ItemDetailToolStripMenuItem.Image = CType(resources.GetObject("ItemDetailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemDetailToolStripMenuItem.Name = "ItemDetailToolStripMenuItem"
        Me.ItemDetailToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ItemDetailToolStripMenuItem.Text = "Item Detail..."
        '
        'btnlist
        '
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(135, 534)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 140
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
        Me.btnrefresh.Location = New System.Drawing.Point(30, 534)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 139
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(811, 533)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 142
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtname_msupp
        '
        Me.txtname_msupp.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_msupp.Location = New System.Drawing.Point(179, 24)
        Me.txtname_msupp.Name = "txtname_msupp"
        Me.txtname_msupp.Size = New System.Drawing.Size(249, 22)
        Me.txtname_msupp.TabIndex = 143
        '
        'lblid_msupp
        '
        Me.lblid_msupp.AutoSize = True
        Me.lblid_msupp.Location = New System.Drawing.Point(483, 551)
        Me.lblid_msupp.Name = "lblid_msupp"
        Me.lblid_msupp.Size = New System.Drawing.Size(62, 13)
        Me.lblid_msupp.TabIndex = 145
        Me.lblid_msupp.Text = "lblid_msupp"
        Me.lblid_msupp.Visible = False
        '
        'btnprint
        '
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(214, 534)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 148
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'dttdt
        '
        Me.dttdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dttdt.CustomFormat = "dd/MM/yyyy"
        Me.dttdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt.Location = New System.Drawing.Point(331, 24)
        Me.dttdt.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt.Name = "dttdt"
        Me.dttdt.Size = New System.Drawing.Size(118, 20)
        Me.dttdt.TabIndex = 393
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseTransactionToolStripMenuItem, Me.ToolStripSeparator2, Me.DuplicateTransactionToolStripMenuItem, Me.RepairLinkToolStripMenuItem, Me.ToolStripSeparator3, Me.DataOverviewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(188, 104)
        '
        'CloseTransactionToolStripMenuItem
        '
        Me.CloseTransactionToolStripMenuItem.Image = CType(resources.GetObject("CloseTransactionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseTransactionToolStripMenuItem.Name = "CloseTransactionToolStripMenuItem"
        Me.CloseTransactionToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.CloseTransactionToolStripMenuItem.Text = "Close Transaction"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(184, 6)
        '
        'DuplicateTransactionToolStripMenuItem
        '
        Me.DuplicateTransactionToolStripMenuItem.Image = CType(resources.GetObject("DuplicateTransactionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DuplicateTransactionToolStripMenuItem.Name = "DuplicateTransactionToolStripMenuItem"
        Me.DuplicateTransactionToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.DuplicateTransactionToolStripMenuItem.Text = "Duplicate Transaction"
        '
        'RepairLinkToolStripMenuItem
        '
        Me.RepairLinkToolStripMenuItem.Image = CType(resources.GetObject("RepairLinkToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RepairLinkToolStripMenuItem.Name = "RepairLinkToolStripMenuItem"
        Me.RepairLinkToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.RepairLinkToolStripMenuItem.Text = "Repair Link"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(184, 6)
        '
        'DataOverviewToolStripMenuItem
        '
        Me.DataOverviewToolStripMenuItem.Image = CType(resources.GetObject("DataOverviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DataOverviewToolStripMenuItem.Name = "DataOverviewToolStripMenuItem"
        Me.DataOverviewToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.DataOverviewToolStripMenuItem.Text = "Data Overview"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtFree8)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TxtFree2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtFree1)
        Me.GroupBox1.Controls.Add(Me.txtcode_msupp)
        Me.GroupBox1.Controls.Add(Me.txtname_msupp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtaddr1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 200)
        Me.GroupBox1.TabIndex = 434
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Info Customer"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 149
        Me.Label16.Text = "Catatan"
        '
        'TxtFree8
        '
        Me.TxtFree8.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree8.Location = New System.Drawing.Point(107, 148)
        Me.TxtFree8.Multiline = True
        Me.TxtFree8.Name = "TxtFree8"
        Me.TxtFree8.ReadOnly = True
        Me.TxtFree8.Size = New System.Drawing.Size(321, 39)
        Me.TxtFree8.TabIndex = 148
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(19, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 147
        Me.Label25.Text = "No. HP #2"
        '
        'TxtFree2
        '
        Me.TxtFree2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree2.Location = New System.Drawing.Point(107, 76)
        Me.TxtFree2.Name = "TxtFree2"
        Me.TxtFree2.ReadOnly = True
        Me.TxtFree2.Size = New System.Drawing.Size(321, 22)
        Me.TxtFree2.TabIndex = 146
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 145
        Me.Label12.Text = "No. HP #1"
        '
        'TxtFree1
        '
        Me.TxtFree1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree1.Location = New System.Drawing.Point(107, 50)
        Me.TxtFree1.Name = "TxtFree1"
        Me.TxtFree1.Size = New System.Drawing.Size(321, 22)
        Me.TxtFree1.TabIndex = 144
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtFree9)
        Me.GroupBox2.Controls.Add(Me.TxtCurrency2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.TxtCurrency1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TxtFree7)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 283)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 190)
        Me.GroupBox2.TabIndex = 435
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info Barang"
        '
        'TxtFree9
        '
        Me.TxtFree9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFree9.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree9.Location = New System.Drawing.Point(107, 23)
        Me.TxtFree9.Name = "TxtFree9"
        Me.TxtFree9.Size = New System.Drawing.Size(111, 22)
        Me.TxtFree9.TabIndex = 442
        '
        'TxtCurrency2
        '
        Me.TxtCurrency2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCurrency2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtCurrency2.Location = New System.Drawing.Point(253, 24)
        Me.TxtCurrency2.Name = "TxtCurrency2"
        Me.TxtCurrency2.ReadOnly = True
        Me.TxtCurrency2.Size = New System.Drawing.Size(175, 22)
        Me.TxtCurrency2.TabIndex = 440
        Me.TxtCurrency2.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(224, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 439
        Me.Label7.Text = "Qty"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 438
        Me.Label4.Text = "Harga Barang"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"IDR", "USD", "HKD", "SGD", "JPY", "CNY"})
        Me.ComboBox1.Location = New System.Drawing.Point(107, 143)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(71, 21)
        Me.ComboBox1.TabIndex = 437
        '
        'TxtCurrency1
        '
        Me.TxtCurrency1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCurrency1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtCurrency1.Location = New System.Drawing.Point(184, 143)
        Me.TxtCurrency1.Name = "TxtCurrency1"
        Me.TxtCurrency1.ReadOnly = True
        Me.TxtCurrency1.Size = New System.Drawing.Size(244, 22)
        Me.TxtCurrency1.TabIndex = 436
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "No. Tag"
        '
        'TxtFree7
        '
        Me.TxtFree7.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree7.Location = New System.Drawing.Point(107, 51)
        Me.TxtFree7.Multiline = True
        Me.TxtFree7.Name = "TxtFree7"
        Me.TxtFree7.ReadOnly = True
        Me.TxtFree7.Size = New System.Drawing.Size(321, 86)
        Me.TxtFree7.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Deskripsi Barang"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(510, 289)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(385, 184)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 436
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(507, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 437
        Me.Label9.Text = "History Barang"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(809, 479)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 438
        Me.Button1.Text = "<<"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(855, 479)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 23)
        Me.Button2.TabIndex = 439
        Me.Button2.Text = ">>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtFree3
        '
        Me.TxtFree3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree3.Location = New System.Drawing.Point(137, 479)
        Me.TxtFree3.Multiline = True
        Me.TxtFree3.Name = "TxtFree3"
        Me.TxtFree3.ReadOnly = True
        Me.TxtFree3.Size = New System.Drawing.Size(321, 42)
        Me.TxtFree3.TabIndex = 441
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 479)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 441
        Me.Label10.Text = "Catatan Barang"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(643, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(257, 31)
        Me.Label17.TabIndex = 442
        Me.Label17.Text = "STATUS BARANG"
        '
        'TxtFree10
        '
        Me.TxtFree10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFree10.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtFree10.Location = New System.Drawing.Point(130, 49)
        Me.TxtFree10.Name = "TxtFree10"
        Me.TxtFree10.ReadOnly = True
        Me.TxtFree10.Size = New System.Drawing.Size(319, 22)
        Me.TxtFree10.TabIndex = 443
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(49, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 13)
        Me.Label18.TabIndex = 444
        Me.Label18.Text = "Admin"
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgview.Location = New System.Drawing.Point(507, 93)
        Me.dgview.Name = "dgview"
        Me.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgview.Size = New System.Drawing.Size(388, 168)
        Me.dgview.TabIndex = 445
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(507, 273)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 446
        Me.Label13.Text = "Gambar Barang"
        '
        'rstokbrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 598)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtFree10)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtFree3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dttdt)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.lblid_msupp)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rstokbrg"
        Me.Text = "Stok Barang"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcode_msupp As classlibobjswiplb.txtFree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtaddr1 As classlibobjswiplb.txtFree
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtno As classlibobjswiplb.txtFree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents txtname_msupp As classlibobjswiplb.txtFree
    Friend WithEvents lblid_msupp As Label
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents dttdt As DateTimePicker
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents SyncOnlineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ItemDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CloseTransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents DuplicateTransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepairLinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents DataOverviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TxtFree2 As classlibobjswiplb.txtFree
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtFree1 As classlibobjswiplb.txtFree
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TxtCurrency1 As classlibobjswiplb.txtCurrency
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtFree7 As classlibobjswiplb.txtFree
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtCurrency2 As classlibobjswiplb.txtCurrency
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TxtFree3 As classlibobjswiplb.txtFree
    Friend WithEvents Label10 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtFree8 As classlibobjswiplb.txtFree
    Friend WithEvents TxtFree9 As classlibobjswiplb.txtFree
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtFree10 As classlibobjswiplb.txtFree
    Friend WithEvents Label18 As Label
    Friend WithEvents dgview As DataGridView
    Friend WithEvents Label13 As Label
End Class
