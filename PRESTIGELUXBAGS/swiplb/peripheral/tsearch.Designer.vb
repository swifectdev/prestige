<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tsearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tsearch))
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.txtsearch = New classlibobjswiplb.txtAlphabet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCancel = New classlibobjswiplb.btnCancel()
        Me.BtnSave = New classlibobjswiplb.btnSave()
        Me.btnExcel = New classlibobjswiplb.btnSave()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnsearching = New classlibobjswiplb.btnBrowse()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnBrowse1 = New classlibobjswiplb.btnBrowse()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.dgview.Size = New System.Drawing.Size(1271, 455)
        Me.dgview.TabIndex = 200
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtsearch.Location = New System.Drawing.Point(96, 12)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(728, 22)
        Me.txtsearch.TabIndex = 302
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Cari"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(1194, 505)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 46)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(13, 505)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(96, 46)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Pilih"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(115, 505)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(101, 46)
        Me.btnExcel.TabIndex = 401
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        Me.btnExcel.Visible = False
        '
        'btnsearching
        '
        Me.btnsearching.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsearching.BackgroundImage = CType(resources.GetObject("btnsearching.BackgroundImage"), System.Drawing.Image)
        Me.btnsearching.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsearching.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsearching.Location = New System.Drawing.Point(830, 12)
        Me.btnsearching.Name = "btnsearching"
        Me.btnsearching.Size = New System.Drawing.Size(23, 23)
        Me.btnsearching.TabIndex = 454
        Me.btnsearching.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd / MM / yyyy"
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(112, 3)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(91, 22)
        Me.dtto.TabIndex = 498
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd / MM / yyyy"
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(3, 3)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(91, 22)
        Me.dtfrom.TabIndex = 499
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 500
        Me.Label1.Text = "-"
        '
        'BtnBrowse1
        '
        Me.BtnBrowse1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse1.BackgroundImage = CType(resources.GetObject("BtnBrowse1.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse1.Location = New System.Drawing.Point(209, 3)
        Me.BtnBrowse1.Name = "BtnBrowse1"
        Me.BtnBrowse1.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse1.TabIndex = 501
        Me.BtnBrowse1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtfrom)
        Me.Panel1.Controls.Add(Me.BtnBrowse1)
        Me.Panel1.Controls.Add(Me.dtto)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(998, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(285, 31)
        Me.Panel1.TabIndex = 502
        Me.Panel1.Visible = False
        '
        'tsearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1292, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnsearching)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgview)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "tsearch"
        Me.Text = "Cari"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents txtsearch As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As classlibobjswiplb.btnCancel
    Friend WithEvents BtnSave As classlibobjswiplb.btnSave
    Friend WithEvents btnExcel As classlibobjswiplb.btnSave
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnsearching As classlibobjswiplb.btnBrowse
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnBrowse1 As classlibobjswiplb.btnBrowse
    Friend WithEvents Panel1 As Panel
End Class

