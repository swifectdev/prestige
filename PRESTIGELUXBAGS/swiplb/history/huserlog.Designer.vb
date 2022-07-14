<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class huserlog
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(huserlog))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.btnprint = New classlibobjswiplb.btnPrint()
        Me.cmbuser = New System.Windows.Forms.ComboBox()
        Me.chuser = New System.Windows.Forms.CheckBox()
        Me.chaction = New System.Windows.Forms.CheckBox()
        Me.cmbaction = New System.Windows.Forms.ComboBox()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chtgl = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Action"
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(137, 414)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 46)
        Me.btnrefresh.TabIndex = 101
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(35, 414)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 100
        Me.btnsave.Text = "View"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(772, 415)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 105
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.AllowUserToDeleteRows = False
        Me.dgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(35, 94)
        Me.dgview.Name = "dgview"
        Me.dgview.ReadOnly = True
        Me.dgview.Size = New System.Drawing.Size(826, 315)
        Me.dgview.TabIndex = 394
        '
        'btnprint
        '
        Me.btnprint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprint.Location = New System.Drawing.Point(242, 415)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(83, 46)
        Me.btnprint.TabIndex = 0
        Me.btnprint.Text = "Print"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'cmbuser
        '
        Me.cmbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbuser.FormattingEnabled = True
        Me.cmbuser.Location = New System.Drawing.Point(146, 41)
        Me.cmbuser.Name = "cmbuser"
        Me.cmbuser.Size = New System.Drawing.Size(201, 21)
        Me.cmbuser.TabIndex = 396
        '
        'chuser
        '
        Me.chuser.AutoSize = True
        Me.chuser.Location = New System.Drawing.Point(125, 44)
        Me.chuser.Name = "chuser"
        Me.chuser.Size = New System.Drawing.Size(15, 14)
        Me.chuser.TabIndex = 397
        Me.chuser.UseVisualStyleBackColor = True
        '
        'chaction
        '
        Me.chaction.AutoSize = True
        Me.chaction.Location = New System.Drawing.Point(125, 68)
        Me.chaction.Name = "chaction"
        Me.chaction.Size = New System.Drawing.Size(15, 14)
        Me.chaction.TabIndex = 399
        Me.chaction.UseVisualStyleBackColor = True
        '
        'cmbaction
        '
        Me.cmbaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbaction.FormattingEnabled = True
        Me.cmbaction.Location = New System.Drawing.Point(146, 67)
        Me.cmbaction.Name = "cmbaction"
        Me.cmbaction.Size = New System.Drawing.Size(201, 21)
        Me.cmbaction.TabIndex = 398
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd-MM-yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(146, 14)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(89, 22)
        Me.dtfrom.TabIndex = 400
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd-MM-yyyy"
        Me.dtto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(258, 14)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(89, 22)
        Me.dtto.TabIndex = 401
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "-"
        '
        'chtgl
        '
        Me.chtgl.AutoSize = True
        Me.chtgl.Location = New System.Drawing.Point(125, 20)
        Me.chtgl.Name = "chtgl"
        Me.chtgl.Size = New System.Drawing.Size(15, 14)
        Me.chtgl.TabIndex = 403
        Me.chtgl.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 404
        Me.Label5.Text = "Tanggal"
        '
        'huserlog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(895, 472)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chtgl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.chaction)
        Me.Controls.Add(Me.cmbaction)
        Me.Controls.Add(Me.chuser)
        Me.Controls.Add(Me.cmbuser)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.dgview)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "huserlog"
        Me.Text = "User Log"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents btnprint As classlibobjswiplb.btnPrint
    Friend WithEvents cmbuser As System.Windows.Forms.ComboBox
    Friend WithEvents chuser As System.Windows.Forms.CheckBox
    Friend WithEvents chaction As System.Windows.Forms.CheckBox
    Friend WithEvents cmbaction As System.Windows.Forms.ComboBox
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chtgl As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
