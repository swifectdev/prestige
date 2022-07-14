<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cusr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cusr))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtname = New classlibobjswiplb.txtAlphabet()
        Me.txtnote = New classlibobjswiplb.txtNote()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btndelete = New classlibobjswiplb.btnDelete()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtcode = New classlibobjswiplb.txtAlphabet()
        Me.btnlist = New classlibobjswiplb.btnList()
        Me.btnresetpass = New classlibobjswiplb.btnResetPass()
        Me.txtusername = New classlibobjswiplb.txtAlphabet()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chshowmenu = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbcostcenter = New System.Windows.Forms.ComboBox()
        Me.chadmin = New System.Windows.Forms.CheckBox()
        Me.chapprove = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "System Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Pengguna"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Catatan"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtname.Location = New System.Drawing.Point(184, 46)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(320, 22)
        Me.txtname.TabIndex = 2
        '
        'txtnote
        '
        Me.txtnote.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtnote.Location = New System.Drawing.Point(184, 97)
        Me.txtnote.Multiline = True
        Me.txtnote.Name = "txtnote"
        Me.txtnote.Size = New System.Drawing.Size(320, 44)
        Me.txtnote.TabIndex = 5
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(114, 191)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 101
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
        Me.btndelete.Location = New System.Drawing.Point(298, 191)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 46)
        Me.btndelete.TabIndex = 103
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
        Me.btnsave.Location = New System.Drawing.Point(12, 191)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 100
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
        Me.btncancel.Location = New System.Drawing.Point(521, 192)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 105
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtcode
        '
        Me.txtcode.BackColor = System.Drawing.SystemColors.Window
        Me.txtcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcode.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtcode.Location = New System.Drawing.Point(184, 21)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(320, 22)
        Me.txtcode.TabIndex = 1
        Me.txtcode.TabStop = False
        '
        'btnlist
        '
        Me.btnlist.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlist.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlist.Image = CType(resources.GetObject("btnlist.Image"), System.Drawing.Image)
        Me.btnlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlist.Location = New System.Drawing.Point(219, 191)
        Me.btnlist.Name = "btnlist"
        Me.btnlist.Size = New System.Drawing.Size(73, 46)
        Me.btnlist.TabIndex = 102
        Me.btnlist.Text = "List"
        Me.btnlist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlist.UseVisualStyleBackColor = False
        '
        'btnresetpass
        '
        Me.btnresetpass.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnresetpass.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnresetpass.Image = CType(resources.GetObject("btnresetpass.Image"), System.Drawing.Image)
        Me.btnresetpass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnresetpass.Location = New System.Drawing.Point(394, 191)
        Me.btnresetpass.Name = "btnresetpass"
        Me.btnresetpass.Size = New System.Drawing.Size(110, 46)
        Me.btnresetpass.TabIndex = 0
        Me.btnresetpass.Text = "Reset Pass"
        Me.btnresetpass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnresetpass.UseVisualStyleBackColor = False
        '
        'txtusername
        '
        Me.txtusername.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtusername.Location = New System.Drawing.Point(184, 71)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(320, 22)
        Me.txtusername.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 304
        Me.Label4.Text = "Username"
        '
        'chshowmenu
        '
        Me.chshowmenu.AutoSize = True
        Me.chshowmenu.Location = New System.Drawing.Point(510, 75)
        Me.chshowmenu.Name = "chshowmenu"
        Me.chshowmenu.Size = New System.Drawing.Size(88, 17)
        Me.chshowmenu.TabIndex = 305
        Me.chshowmenu.Text = "Show Menu"
        Me.chshowmenu.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 308
        Me.Label6.Text = "Lokasi"
        '
        'cmbcostcenter
        '
        Me.cmbcostcenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcostcenter.FormattingEnabled = True
        Me.cmbcostcenter.Location = New System.Drawing.Point(282, 146)
        Me.cmbcostcenter.Name = "cmbcostcenter"
        Me.cmbcostcenter.Size = New System.Drawing.Size(221, 21)
        Me.cmbcostcenter.TabIndex = 307
        '
        'chadmin
        '
        Me.chadmin.AutoSize = True
        Me.chadmin.Location = New System.Drawing.Point(184, 147)
        Me.chadmin.Name = "chadmin"
        Me.chadmin.Size = New System.Drawing.Size(96, 17)
        Me.chadmin.TabIndex = 309
        Me.chadmin.Text = "Administrator"
        Me.chadmin.UseVisualStyleBackColor = True
        '
        'chapprove
        '
        Me.chapprove.AutoSize = True
        Me.chapprove.Location = New System.Drawing.Point(510, 46)
        Me.chapprove.Name = "chapprove"
        Me.chapprove.Size = New System.Drawing.Size(73, 17)
        Me.chapprove.TabIndex = 310
        Me.chapprove.Text = "Approver"
        Me.chapprove.UseVisualStyleBackColor = True
        '
        'cusr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(620, 259)
        Me.Controls.Add(Me.chapprove)
        Me.Controls.Add(Me.chadmin)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbcostcenter)
        Me.Controls.Add(Me.chshowmenu)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnresetpass)
        Me.Controls.Add(Me.btnlist)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtnote)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "cusr"
        Me.Text = "Users"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcode As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btndelete As classlibobjswiplb.btnDelete
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents txtnote As classlibobjswiplb.txtNote
    Friend WithEvents txtname As classlibobjswiplb.txtAlphabet
    Friend WithEvents btnlist As classlibobjswiplb.btnList
    Friend WithEvents btnresetpass As classlibobjswiplb.btnResetPass
    Friend WithEvents txtusername As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chshowmenu As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbcostcenter As ComboBox
    Friend WithEvents chadmin As CheckBox
    Friend WithEvents chapprove As CheckBox
End Class
