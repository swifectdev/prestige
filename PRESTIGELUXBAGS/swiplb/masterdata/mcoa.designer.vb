<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mcoa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mcoa))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtname = New classlibobjswiplb.txtFree()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.COATView = New System.Windows.Forms.TreeView()
        Me.txtcode = New classlibobjswiplb.txtFree()
        Me.btnbrowsecoa = New classlibobjswiplb.btnBrowse()
        Me.txtname_mcoa = New classlibobjswiplb.txtFree()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblidmcoa = New System.Windows.Forms.Label()
        Me.cmbactive = New System.Windows.Forms.ComboBox()
        Me.cmbdc = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbcoatype = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtname2 = New classlibobjswiplb.txtFree()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chusename = New System.Windows.Forms.CheckBox()
        Me.chusename2 = New System.Windows.Forms.CheckBox()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.cmbrpttype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrptcattype = New classlibobjswiplb.txtFree()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbcurr = New System.Windows.Forms.ComboBox()
        Me.chcontrol = New System.Windows.Forms.CheckBox()
        Me.chcash = New System.Windows.Forms.CheckBox()
        Me.txtrptcattype2 = New classlibobjswiplb.txtFree()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Acc. No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Acc. Name"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname.Location = New System.Drawing.Point(429, 37)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(397, 22)
        Me.txtname.TabIndex = 2
        '
        'btnlist
        '
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(561, 307)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 113
        Me.btnlist.TabStop = False
        Me.btnlist.Text = "List"
        Me.btnlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlist.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btndelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btndelete.Image = CType(resources.GetObject("btndelete.Image"), System.Drawing.Image)
        Me.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndelete.Location = New System.Drawing.Point(663, 307)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 46)
        Me.btndelete.TabIndex = 114
        Me.btndelete.TabStop = False
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
        Me.btnsave.Location = New System.Drawing.Point(354, 307)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 7
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
        Me.btncancel.Location = New System.Drawing.Point(759, 307)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 115
        Me.btncancel.TabStop = False
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'COATView
        '
        Me.COATView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.COATView.Location = New System.Drawing.Point(12, 12)
        Me.COATView.Name = "COATView"
        Me.COATView.Size = New System.Drawing.Size(333, 570)
        Me.COATView.TabIndex = 116
        Me.COATView.TabStop = False
        '
        'txtcode
        '
        Me.txtcode.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcode.Location = New System.Drawing.Point(429, 12)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(418, 22)
        Me.txtcode.TabIndex = 1
        '
        'btnbrowsecoa
        '
        Me.btnbrowsecoa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnbrowsecoa.BackgroundImage = CType(resources.GetObject("btnbrowsecoa.BackgroundImage"), System.Drawing.Image)
        Me.btnbrowsecoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbrowsecoa.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnbrowsecoa.Location = New System.Drawing.Point(824, 138)
        Me.btnbrowsecoa.Name = "btnbrowsecoa"
        Me.btnbrowsecoa.Size = New System.Drawing.Size(23, 23)
        Me.btnbrowsecoa.TabIndex = 3
        Me.btnbrowsecoa.UseVisualStyleBackColor = False
        '
        'txtname_mcoa
        '
        Me.txtname_mcoa.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname_mcoa.Location = New System.Drawing.Point(429, 139)
        Me.txtname_mcoa.Name = "txtname_mcoa"
        Me.txtname_mcoa.ReadOnly = True
        Me.txtname_mcoa.Size = New System.Drawing.Size(389, 22)
        Me.txtname_mcoa.TabIndex = 120
        Me.txtname_mcoa.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(350, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Parent"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(351, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Active"
        '
        'lblidmcoa
        '
        Me.lblidmcoa.AutoSize = True
        Me.lblidmcoa.Location = New System.Drawing.Point(473, 354)
        Me.lblidmcoa.Name = "lblidmcoa"
        Me.lblidmcoa.Size = New System.Drawing.Size(51, 13)
        Me.lblidmcoa.TabIndex = 123
        Me.lblidmcoa.Text = "lblidmcoa"
        Me.lblidmcoa.Visible = False
        '
        'cmbactive
        '
        Me.cmbactive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbactive.FormattingEnabled = True
        Me.cmbactive.Location = New System.Drawing.Point(429, 218)
        Me.cmbactive.Name = "cmbactive"
        Me.cmbactive.Size = New System.Drawing.Size(248, 21)
        Me.cmbactive.TabIndex = 302
        '
        'cmbdc
        '
        Me.cmbdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdc.FormattingEnabled = True
        Me.cmbdc.Location = New System.Drawing.Point(429, 243)
        Me.cmbdc.Name = "cmbdc"
        Me.cmbdc.Size = New System.Drawing.Size(248, 21)
        Me.cmbdc.TabIndex = 303
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(351, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 304
        Me.Label3.Text = "Debit/Credit"
        '
        'cmbcoatype
        '
        Me.cmbcoatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcoatype.FormattingEnabled = True
        Me.cmbcoatype.Location = New System.Drawing.Point(429, 114)
        Me.cmbcoatype.Name = "cmbcoatype"
        Me.cmbcoatype.Size = New System.Drawing.Size(248, 21)
        Me.cmbcoatype.TabIndex = 305
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(351, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 306
        Me.Label6.Text = "Type"
        '
        'txtname2
        '
        Me.txtname2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname2.Location = New System.Drawing.Point(429, 63)
        Me.txtname2.Name = "txtname2"
        Me.txtname2.Size = New System.Drawing.Size(397, 22)
        Me.txtname2.TabIndex = 308
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(350, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 307
        Me.Label7.Text = "Other Name"
        '
        'chusename
        '
        Me.chusename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chusename.AutoSize = True
        Me.chusename.Location = New System.Drawing.Point(832, 41)
        Me.chusename.Name = "chusename"
        Me.chusename.Size = New System.Drawing.Size(15, 14)
        Me.chusename.TabIndex = 370
        Me.chusename.UseVisualStyleBackColor = True
        '
        'chusename2
        '
        Me.chusename2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chusename2.AutoSize = True
        Me.chusename2.Location = New System.Drawing.Point(832, 66)
        Me.chusename2.Name = "chusename2"
        Me.chusename2.Size = New System.Drawing.Size(15, 14)
        Me.chusename2.TabIndex = 371
        Me.chusename2.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(456, 307)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 372
        Me.btnrefresh.TabStop = False
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'cmbrpttype
        '
        Me.cmbrpttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbrpttype.FormattingEnabled = True
        Me.cmbrpttype.Location = New System.Drawing.Point(429, 89)
        Me.cmbrpttype.Name = "cmbrpttype"
        Me.cmbrpttype.Size = New System.Drawing.Size(248, 21)
        Me.cmbrpttype.TabIndex = 373
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(350, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 374
        Me.Label8.Text = "Category"
        '
        'txtrptcattype
        '
        Me.txtrptcattype.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtrptcattype.Location = New System.Drawing.Point(429, 165)
        Me.txtrptcattype.Name = "txtrptcattype"
        Me.txtrptcattype.Size = New System.Drawing.Size(397, 22)
        Me.txtrptcattype.TabIndex = 375
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(351, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 376
        Me.Label9.Text = "Grouping #1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(351, 271)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 378
        Me.Label10.Text = "Dflt Currency"
        '
        'cmbcurr
        '
        Me.cmbcurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcurr.FormattingEnabled = True
        Me.cmbcurr.Location = New System.Drawing.Point(429, 268)
        Me.cmbcurr.Name = "cmbcurr"
        Me.cmbcurr.Size = New System.Drawing.Size(248, 21)
        Me.cmbcurr.TabIndex = 377
        '
        'chcontrol
        '
        Me.chcontrol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chcontrol.AutoSize = True
        Me.chcontrol.Location = New System.Drawing.Point(692, 91)
        Me.chcontrol.Name = "chcontrol"
        Me.chcontrol.Size = New System.Drawing.Size(102, 17)
        Me.chcontrol.TabIndex = 379
        Me.chcontrol.Text = "Control Account"
        Me.chcontrol.UseVisualStyleBackColor = True
        '
        'chcash
        '
        Me.chcash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chcash.AutoSize = True
        Me.chcash.Location = New System.Drawing.Point(692, 116)
        Me.chcash.Name = "chcash"
        Me.chcash.Size = New System.Drawing.Size(93, 17)
        Me.chcash.TabIndex = 380
        Me.chcash.Text = "Cash Account"
        Me.chcash.UseVisualStyleBackColor = True
        '
        'txtrptcattype2
        '
        Me.txtrptcattype2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtrptcattype2.Location = New System.Drawing.Point(429, 191)
        Me.txtrptcattype2.Name = "txtrptcattype2"
        Me.txtrptcattype2.Size = New System.Drawing.Size(397, 22)
        Me.txtrptcattype2.TabIndex = 381
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(351, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 382
        Me.Label11.Text = "Grouping #2"
        '
        'mcoa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 594)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtrptcattype2)
        Me.Controls.Add(Me.chcash)
        Me.Controls.Add(Me.chcontrol)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbcurr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtrptcattype)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbrpttype)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.chusename2)
        Me.Controls.Add(Me.chusename)
        Me.Controls.Add(Me.txtname2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbcoatype)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbdc)
        Me.Controls.Add(Me.cmbactive)
        Me.Controls.Add(Me.lblidmcoa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnbrowsecoa)
        Me.Controls.Add(Me.txtname_mcoa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.COATView)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mcoa"
        Me.Text = "Chart of Accounts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtname As classlibobjswiplb.txtFree
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btndelete As classlibobjswiplb.btnDelete
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents COATView As TreeView
    Friend WithEvents txtcode As classlibobjswiplb.txtFree
    Friend WithEvents btnbrowsecoa As classlibobjswiplb.btnBrowse
    Friend WithEvents txtname_mcoa As classlibobjswiplb.txtFree
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblidmcoa As Label
    Friend WithEvents cmbactive As ComboBox
    Friend WithEvents cmbdc As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbcoatype As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtname2 As classlibobjswiplb.txtFree
    Friend WithEvents Label7 As Label
    Friend WithEvents chusename As CheckBox
    Friend WithEvents chusename2 As CheckBox
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents cmbrpttype As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtrptcattype As classlibobjswiplb.txtFree
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbcurr As ComboBox
    Friend WithEvents chcontrol As CheckBox
    Friend WithEvents chcash As CheckBox
    Friend WithEvents txtrptcattype2 As classlibobjswiplb.txtFree
    Friend WithEvents Label11 As Label
End Class
