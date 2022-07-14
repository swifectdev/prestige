<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uploadData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uploadData))
        Me.txtDirectory = New classlibobjswiplb.txtFree()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbtipefile = New System.Windows.Forms.ComboBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnRESET = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDirectory
        '
        Me.txtDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirectory.Location = New System.Drawing.Point(168, 15)
        Me.txtDirectory.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.ReadOnly = True
        Me.txtDirectory.Size = New System.Drawing.Size(448, 18)
        Me.txtDirectory.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 76)
        Me.ProgressBar1.MarqueeAnimationSpeed = 10
        Me.ProgressBar1.Maximum = 300
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(702, 15)
        Me.ProgressBar1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Direktori Data File"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tipe Master Data"
        '
        'cmbtipefile
        '
        Me.cmbtipefile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipefile.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtipefile.FormattingEnabled = True
        Me.cmbtipefile.Items.AddRange(New Object() {"Barang", "Partner Bisnis", "Kantor Pabean", "Mata Uang", "Satuan", "Users", "Grup Barang", "Hak Akses", "Chart of Account", "BOM - Header", "BOM - Detail", "JE - Header", "JE - Detail", "GOODS RECEIPT HEADER", "GOODS RECEIPT DETAIL", "GOODS ISSUE HEADER", "GOODS ISSUE DETAIL", "BC 2.3 HEADER", "BC 2.3 DETAIL", "BC 2.5 HEADER", "BC 2.5 DETAIL", "BC 4.0 HEADER", "BC 4.0 DETAIL", "BC 4.0 DOK", "BC 4.1 HEADER", "BC 4.1 DETAIL", "BC 4.1 DOK", "BC 2.6.2 HEADER", "BC 2.6.2 DETAIL", "BC 2.6.2 DOK", "BC 2.6.1 HEADER", "BC 2.6.1 DETAIL", "BC 2.6.1 DOK", "DELIVERY - HEADER", "DELIVERY - DETAIL", "PENERIMAAN - HEADER", "PENERIMAAN - DETAIL", "PO - HEADER", "PO - DETAIL", "OPNAME - HEADER", "OPNAME - DETAIL", "EXCHANGE RATE"})
        Me.cmbtipefile.Location = New System.Drawing.Point(168, 37)
        Me.cmbtipefile.Name = "cmbtipefile"
        Me.cmbtipefile.Size = New System.Drawing.Size(274, 20)
        Me.cmbtipefile.TabIndex = 9
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Location = New System.Drawing.Point(552, 37)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(98, 26)
        Me.btnUpload.TabIndex = 396
        Me.btnUpload.Text = "UPLOAD"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(623, 14)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(28, 21)
        Me.btnBrowse.TabIndex = 397
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnRESET
        '
        Me.btnRESET.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRESET.Enabled = False
        Me.btnRESET.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRESET.Location = New System.Drawing.Point(448, 37)
        Me.btnRESET.Name = "btnRESET"
        Me.btnRESET.Size = New System.Drawing.Size(98, 26)
        Me.btnRESET.TabIndex = 398
        Me.btnRESET.Text = "RESET"
        Me.btnRESET.UseVisualStyleBackColor = False
        '
        'uploadData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(721, 99)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRESET)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbtipefile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtDirectory)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "uploadData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDirectory As classlibobjswiplb.txtFree
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbtipefile As System.Windows.Forms.ComboBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnRESET As System.Windows.Forms.Button
End Class
