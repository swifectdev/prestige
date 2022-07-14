<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class csetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(csetting))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtowner = New classlibobjswiplb.txtAlphabet()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.cmbjeniscompany = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcompany = New classlibobjswiplb.txtAlphabet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtalamat = New classlibobjswiplb.txtAlphabet()
        Me.txtnoijintpb = New classlibobjswiplb.txtAlphabet()
        Me.txtphone = New classlibobjswiplb.txtAlphabet()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtfax = New classlibobjswiplb.txtAlphabet()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNPWP = New classlibobjswiplb.txtAlphabet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtlogo = New classlibobjswiplb.txtAlphabet()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnBrowse1 = New classlibobjswiplb.btnBrowse()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtnegara = New classlibobjswiplb.txtAlphabet()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudecimal = New System.Windows.Forms.NumericUpDown()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbautoprint = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbautopost = New System.Windows.Forms.ComboBox()
        Me.cmbitemcosting = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbstockminus = New System.Windows.Forms.ComboBox()
        Me.cmbonline = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbacctype = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbcurrency = New System.Windows.Forms.ComboBox()
        Me.cherp = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtcompid = New classlibobjswiplb.txtAlphabet()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbnobckey = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbcompanycode = New System.Windows.Forms.ComboBox()
        Me.btnsaveexpiry = New classlibobjswiplb.btnSave()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtexpiry = New System.Windows.Forms.DateTimePicker()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cbCLPrintTrans = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbSizePrinterTrans = New System.Windows.Forms.ComboBox()
        Me.cmbPrinterTrans = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtipset = New classlibobjswiplb.txtFree()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jenis Perusahaan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Perusahaan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "No. Ijin TPB"
        '
        'txtowner
        '
        Me.txtowner.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtowner.Location = New System.Drawing.Point(117, 61)
        Me.txtowner.Name = "txtowner"
        Me.txtowner.Size = New System.Drawing.Size(320, 22)
        Me.txtowner.TabIndex = 3
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(118, 396)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 101
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        Me.btnrefresh.Visible = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(16, 396)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 10
        Me.btnsave.Text = "Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(584, 396)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 105
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'cmbjeniscompany
        '
        Me.cmbjeniscompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjeniscompany.FormattingEnabled = True
        Me.cmbjeniscompany.Items.AddRange(New Object() {"GUDANG BERIKAT", "KAWASAN BERIKAT", "KAWASAN & GUDANG BERIKAT", "PUSAT LOGISTIK BERIKAT", "NON FASILITAS"})
        Me.cmbjeniscompany.Location = New System.Drawing.Point(117, 10)
        Me.cmbjeniscompany.Name = "cmbjeniscompany"
        Me.cmbjeniscompany.Size = New System.Drawing.Size(320, 21)
        Me.cmbjeniscompany.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "Alamat"
        '
        'txtcompany
        '
        Me.txtcompany.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcompany.Location = New System.Drawing.Point(117, 35)
        Me.txtcompany.Name = "txtcompany"
        Me.txtcompany.Size = New System.Drawing.Size(320, 22)
        Me.txtcompany.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 304
        Me.Label4.Text = "Nama Pemilik"
        '
        'txtalamat
        '
        Me.txtalamat.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtalamat.Location = New System.Drawing.Point(117, 87)
        Me.txtalamat.Name = "txtalamat"
        Me.txtalamat.Size = New System.Drawing.Size(320, 22)
        Me.txtalamat.TabIndex = 4
        '
        'txtnoijintpb
        '
        Me.txtnoijintpb.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnoijintpb.Location = New System.Drawing.Point(117, 113)
        Me.txtnoijintpb.Name = "txtnoijintpb"
        Me.txtnoijintpb.Size = New System.Drawing.Size(320, 22)
        Me.txtnoijintpb.TabIndex = 5
        '
        'txtphone
        '
        Me.txtphone.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtphone.Location = New System.Drawing.Point(117, 139)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(320, 22)
        Me.txtphone.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 308
        Me.Label5.Text = "Phone"
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtfax.Location = New System.Drawing.Point(117, 165)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(320, 22)
        Me.txtfax.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Fax"
        '
        'txtNPWP
        '
        Me.txtNPWP.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtNPWP.Location = New System.Drawing.Point(117, 191)
        Me.txtNPWP.Name = "txtNPWP"
        Me.txtNPWP.Size = New System.Drawing.Size(320, 22)
        Me.txtNPWP.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 312
        Me.Label7.Text = "NPWP"
        '
        'txtlogo
        '
        Me.txtlogo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtlogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlogo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtlogo.Location = New System.Drawing.Point(117, 241)
        Me.txtlogo.Name = "txtlogo"
        Me.txtlogo.ReadOnly = True
        Me.txtlogo.Size = New System.Drawing.Size(320, 22)
        Me.txtlogo.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtlogo, "Doble klik untuk reset gambar")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Logo"
        '
        'BtnBrowse1
        '
        Me.BtnBrowse1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse1.BackgroundImage = CType(resources.GetObject("BtnBrowse1.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse1.Location = New System.Drawing.Point(440, 241)
        Me.BtnBrowse1.Name = "BtnBrowse1"
        Me.BtnBrowse1.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse1.TabIndex = 315
        Me.BtnBrowse1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(452, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(173, 139)
        Me.PictureBox1.TabIndex = 316
        Me.PictureBox1.TabStop = False
        '
        'txtnegara
        '
        Me.txtnegara.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnegara.Location = New System.Drawing.Point(117, 216)
        Me.txtnegara.Name = "txtnegara"
        Me.txtnegara.Size = New System.Drawing.Size(111, 22)
        Me.txtnegara.TabIndex = 317
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 318
        Me.Label9.Text = "Negara"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 320
        Me.Label11.Text = "Stock Minus"
        '
        'nudecimal
        '
        Me.nudecimal.Location = New System.Drawing.Point(488, 193)
        Me.nudecimal.Name = "nudecimal"
        Me.nudecimal.Size = New System.Drawing.Size(111, 22)
        Me.nudecimal.TabIndex = 321
        Me.nudecimal.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Informasi"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(665, 378)
        Me.TabControl1.TabIndex = 324
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtipset)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.cmbautoprint)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.cmbautopost)
        Me.TabPage1.Controls.Add(Me.cmbitemcosting)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.cmbstockminus)
        Me.TabPage1.Controls.Add(Me.cmbonline)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.cmbacctype)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.cmbcurrency)
        Me.TabPage1.Controls.Add(Me.cherp)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtcompid)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.nudecimal)
        Me.TabPage1.Controls.Add(Me.txtowner)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbjeniscompany)
        Me.TabPage1.Controls.Add(Me.txtnegara)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtcompany)
        Me.TabPage1.Controls.Add(Me.BtnBrowse1)
        Me.TabPage1.Controls.Add(Me.txtalamat)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtnoijintpb)
        Me.TabPage1.Controls.Add(Me.txtlogo)
        Me.TabPage1.Controls.Add(Me.txtphone)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtNPWP)
        Me.TabPage1.Controls.Add(Me.txtfax)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(657, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Company"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(238, 270)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 13)
        Me.Label24.TabIndex = 338
        Me.Label24.Text = "Auto Print"
        '
        'cmbautoprint
        '
        Me.cmbautoprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbautoprint.FormattingEnabled = True
        Me.cmbautoprint.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbautoprint.Location = New System.Drawing.Point(310, 268)
        Me.cmbautoprint.Name = "cmbautoprint"
        Me.cmbautoprint.Size = New System.Drawing.Size(127, 21)
        Me.cmbautoprint.TabIndex = 337
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(440, 296)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 336
        Me.Label23.Text = "Auto Post"
        '
        'cmbautopost
        '
        Me.cmbautopost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbautopost.FormattingEnabled = True
        Me.cmbautopost.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbautopost.Location = New System.Drawing.Point(518, 293)
        Me.cmbautopost.Name = "cmbautopost"
        Me.cmbautopost.Size = New System.Drawing.Size(133, 21)
        Me.cmbautopost.TabIndex = 335
        '
        'cmbitemcosting
        '
        Me.cmbitemcosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbitemcosting.FormattingEnabled = True
        Me.cmbitemcosting.Items.AddRange(New Object() {"MOVING AVERAGE", "FIFO", "STANDARD COST"})
        Me.cmbitemcosting.Location = New System.Drawing.Point(518, 319)
        Me.cmbitemcosting.Name = "cmbitemcosting"
        Me.cmbitemcosting.Size = New System.Drawing.Size(133, 21)
        Me.cmbitemcosting.TabIndex = 334
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(440, 321)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 333
        Me.Label22.Text = "Item Costing"
        '
        'cmbstockminus
        '
        Me.cmbstockminus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstockminus.FormattingEnabled = True
        Me.cmbstockminus.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbstockminus.Location = New System.Drawing.Point(117, 268)
        Me.cmbstockminus.Name = "cmbstockminus"
        Me.cmbstockminus.Size = New System.Drawing.Size(111, 21)
        Me.cmbstockminus.TabIndex = 332
        '
        'cmbonline
        '
        Me.cmbonline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbonline.FormattingEnabled = True
        Me.cmbonline.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbonline.Location = New System.Drawing.Point(310, 293)
        Me.cmbonline.Name = "cmbonline"
        Me.cmbonline.Size = New System.Drawing.Size(127, 21)
        Me.cmbonline.TabIndex = 331
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(238, 295)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.TabIndex = 330
        Me.Label21.Text = "Realtime"
        '
        'cmbacctype
        '
        Me.cmbacctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbacctype.FormattingEnabled = True
        Me.cmbacctype.Items.AddRange(New Object() {"PERIODIK", "PERPETUAL"})
        Me.cmbacctype.Location = New System.Drawing.Point(310, 319)
        Me.cmbacctype.Name = "cmbacctype"
        Me.cmbacctype.Size = New System.Drawing.Size(127, 21)
        Me.cmbacctype.TabIndex = 329
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(238, 321)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 13)
        Me.Label20.TabIndex = 328
        Me.Label20.Text = "Accounting"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 322)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 327
        Me.Label19.Text = "Mata Uang"
        '
        'cmbcurrency
        '
        Me.cmbcurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcurrency.FormattingEnabled = True
        Me.cmbcurrency.Location = New System.Drawing.Point(117, 319)
        Me.cmbcurrency.Name = "cmbcurrency"
        Me.cmbcurrency.Size = New System.Drawing.Size(111, 21)
        Me.cmbcurrency.TabIndex = 326
        '
        'cherp
        '
        Me.cherp.AutoSize = True
        Me.cherp.Location = New System.Drawing.Point(443, 12)
        Me.cherp.Name = "cherp"
        Me.cherp.Size = New System.Drawing.Size(67, 17)
        Me.cherp.TabIndex = 325
        Me.cherp.Text = "Use ERP"
        Me.cherp.UseVisualStyleBackColor = True
        Me.cherp.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 296)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 13)
        Me.Label17.TabIndex = 325
        Me.Label17.Text = "Company Online ID"
        '
        'txtcompid
        '
        Me.txtcompid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcompid.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcompid.Location = New System.Drawing.Point(117, 293)
        Me.txtcompid.MaxLength = 3
        Me.txtcompid.Name = "txtcompid"
        Me.txtcompid.Size = New System.Drawing.Size(111, 22)
        Me.txtcompid.TabIndex = 324
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.cmbnobckey)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.cmbcompanycode)
        Me.TabPage2.Controls.Add(Me.btnsaveexpiry)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.dtexpiry)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(657, 352)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Features"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 401
        Me.Label18.Text = "BC Doc. Key"
        Me.Label18.Visible = False
        '
        'cmbnobckey
        '
        Me.cmbnobckey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbnobckey.FormattingEnabled = True
        Me.cmbnobckey.Items.AddRange(New Object() {"PENGAJUAN", "PENDAFTARAN"})
        Me.cmbnobckey.Location = New System.Drawing.Point(130, 75)
        Me.cmbnobckey.Name = "cmbnobckey"
        Me.cmbnobckey.Size = New System.Drawing.Size(292, 21)
        Me.cmbnobckey.TabIndex = 402
        Me.cmbnobckey.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 13)
        Me.Label16.TabIndex = 400
        Me.Label16.Text = "Company Item Code"
        Me.Label16.Visible = False
        '
        'cmbcompanycode
        '
        Me.cmbcompanycode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcompanycode.FormattingEnabled = True
        Me.cmbcompanycode.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbcompanycode.Location = New System.Drawing.Point(130, 48)
        Me.cmbcompanycode.Name = "cmbcompanycode"
        Me.cmbcompanycode.Size = New System.Drawing.Size(292, 21)
        Me.cmbcompanycode.TabIndex = 399
        Me.cmbcompanycode.Visible = False
        '
        'btnsaveexpiry
        '
        Me.btnsaveexpiry.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsaveexpiry.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsaveexpiry.Image = CType(resources.GetObject("btnsaveexpiry.Image"), System.Drawing.Image)
        Me.btnsaveexpiry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsaveexpiry.Location = New System.Drawing.Point(443, 9)
        Me.btnsaveexpiry.Name = "btnsaveexpiry"
        Me.btnsaveexpiry.Size = New System.Drawing.Size(96, 46)
        Me.btnsaveexpiry.TabIndex = 325
        Me.btnsaveexpiry.Text = "Save"
        Me.btnsaveexpiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsaveexpiry.UseVisualStyleBackColor = False
        Me.btnsaveexpiry.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 398
        Me.Label15.Text = "Expiry Date"
        Me.Label15.Visible = False
        '
        'dtexpiry
        '
        Me.dtexpiry.CustomFormat = "dd-MM-yyyy"
        Me.dtexpiry.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dtexpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtexpiry.Location = New System.Drawing.Point(102, 20)
        Me.dtexpiry.Name = "dtexpiry"
        Me.dtexpiry.Size = New System.Drawing.Size(320, 22)
        Me.dtexpiry.TabIndex = 397
        Me.dtexpiry.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cbCLPrintTrans)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.cmbSizePrinterTrans)
        Me.TabPage3.Controls.Add(Me.cmbPrinterTrans)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(657, 352)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Printing Setup"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cbCLPrintTrans
        '
        Me.cbCLPrintTrans.AutoSize = True
        Me.cbCLPrintTrans.Location = New System.Drawing.Point(116, 70)
        Me.cbCLPrintTrans.Name = "cbCLPrintTrans"
        Me.cbCLPrintTrans.Size = New System.Drawing.Size(109, 17)
        Me.cbCLPrintTrans.TabIndex = 311
        Me.cbCLPrintTrans.Text = "Cetak Langsung"
        Me.cbCLPrintTrans.UseVisualStyleBackColor = True
        Me.cbCLPrintTrans.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 310
        Me.Label13.Text = "Ukuran"
        Me.Label13.Visible = False
        '
        'cmbSizePrinterTrans
        '
        Me.cmbSizePrinterTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSizePrinterTrans.FormattingEnabled = True
        Me.cmbSizePrinterTrans.Location = New System.Drawing.Point(116, 43)
        Me.cmbSizePrinterTrans.Name = "cmbSizePrinterTrans"
        Me.cmbSizePrinterTrans.Size = New System.Drawing.Size(285, 21)
        Me.cmbSizePrinterTrans.TabIndex = 309
        Me.cmbSizePrinterTrans.Visible = False
        '
        'cmbPrinterTrans
        '
        Me.cmbPrinterTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterTrans.FormattingEnabled = True
        Me.cmbPrinterTrans.Location = New System.Drawing.Point(116, 16)
        Me.cmbPrinterTrans.Name = "cmbPrinterTrans"
        Me.cmbPrinterTrans.Size = New System.Drawing.Size(285, 21)
        Me.cmbPrinterTrans.TabIndex = 307
        Me.cmbPrinterTrans.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 308
        Me.Label14.Text = "Printer Transaksi"
        Me.Label14.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(238, 219)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 340
        Me.Label12.Text = "IP TPB CEISA"
        '
        'txtipset
        '
        Me.txtipset.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtipset.Location = New System.Drawing.Point(310, 216)
        Me.txtipset.Name = "txtipset"
        Me.txtipset.Size = New System.Drawing.Size(127, 22)
        Me.txtipset.TabIndex = 341
        '
        'csetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(689, 454)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "csetting"
        Me.Text = "General Settings"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudecimal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents txtowner As classlibobjswiplb.txtAlphabet
    Friend WithEvents cmbjeniscompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcompany As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtalamat As classlibobjswiplb.txtAlphabet
    Friend WithEvents txtnoijintpb As classlibobjswiplb.txtAlphabet
    Friend WithEvents txtphone As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtfax As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNPWP As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtlogo As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnBrowse1 As classlibobjswiplb.btnBrowse
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtnegara As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nudecimal As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnsaveexpiry As classlibobjswiplb.btnSave
    Friend WithEvents Label15 As Label
    Friend WithEvents dtexpiry As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbcompanycode As ComboBox
    Friend WithEvents cbCLPrintTrans As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbSizePrinterTrans As ComboBox
    Friend WithEvents cmbPrinterTrans As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtcompid As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbnobckey As ComboBox
    Friend WithEvents cherp As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbcurrency As ComboBox
    Friend WithEvents cmbacctype As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbonline As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbstockminus As ComboBox
    Friend WithEvents cmbitemcosting As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbautopost As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cmbautoprint As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtipset As classlibobjswiplb.txtFree
End Class
