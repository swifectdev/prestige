<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tdataoverview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tdataoverview))
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.BtnCancel = New classlibobjswiplb.btnCancel()
        Me.btnExcel = New classlibobjswiplb.btnSave()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.dttdt = New System.Windows.Forms.DateTimePicker()
        Me.dttdt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btntpr = New classlibobjswiplb.btnBrowse()
        Me.lbltrans = New System.Windows.Forms.Label()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.AllowUserToDeleteRows = False
        Me.dgview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(12, 40)
        Me.dgview.Name = "dgview"
        Me.dgview.ReadOnly = True
        Me.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgview.Size = New System.Drawing.Size(1168, 455)
        Me.dgview.TabIndex = 200
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(1091, 505)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 46)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(12, 505)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(101, 46)
        Me.btnExcel.TabIndex = 401
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'dttdt
        '
        Me.dttdt.CustomFormat = "dd/MM/yyyy"
        Me.dttdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt.Location = New System.Drawing.Point(62, 13)
        Me.dttdt.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt.Name = "dttdt"
        Me.dttdt.Size = New System.Drawing.Size(107, 22)
        Me.dttdt.TabIndex = 408
        '
        'dttdt2
        '
        Me.dttdt2.CustomFormat = "dd/MM/yyyy"
        Me.dttdt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttdt2.Location = New System.Drawing.Point(185, 13)
        Me.dttdt2.Margin = New System.Windows.Forms.Padding(2)
        Me.dttdt2.Name = "dttdt2"
        Me.dttdt2.Size = New System.Drawing.Size(107, 22)
        Me.dttdt2.TabIndex = 409
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 13)
        Me.Label16.TabIndex = 410
        Me.Label16.Text = "Filter"
        '
        'btntpr
        '
        Me.btntpr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btntpr.BackgroundImage = CType(resources.GetObject("btntpr.BackgroundImage"), System.Drawing.Image)
        Me.btntpr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btntpr.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btntpr.Location = New System.Drawing.Point(297, 13)
        Me.btntpr.Name = "btntpr"
        Me.btntpr.Size = New System.Drawing.Size(23, 23)
        Me.btntpr.TabIndex = 411
        Me.btntpr.UseVisualStyleBackColor = False
        '
        'lbltrans
        '
        Me.lbltrans.AutoSize = True
        Me.lbltrans.Location = New System.Drawing.Point(1024, 24)
        Me.lbltrans.Name = "lbltrans"
        Me.lbltrans.Size = New System.Drawing.Size(46, 13)
        Me.lbltrans.TabIndex = 412
        Me.lbltrans.Text = "lbltrans"
        Me.lbltrans.Visible = False
        '
        'tdataoverview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1189, 561)
        Me.Controls.Add(Me.lbltrans)
        Me.Controls.Add(Me.btntpr)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dttdt2)
        Me.Controls.Add(Me.dttdt)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.dgview)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "tdataoverview"
        Me.Text = "Data Overview"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnExcel As classlibobjswiplb.btnSave
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents dttdt As DateTimePicker
    Friend WithEvents dttdt2 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents btntpr As classlibobjswiplb.btnBrowse
    Friend WithEvents lbltrans As Label
End Class

