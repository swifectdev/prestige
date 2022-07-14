<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cprinterconfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cprinterconfig))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.cmbPrinterTrans = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSizePrinterTrans = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCLPrintTrans = New System.Windows.Forms.CheckBox()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(320, 39)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "KONFIGURASI PRINTER"
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(12, 158)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 100
        Me.btnsave.Text = "Simpan"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(354, 158)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 104
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'cmbPrinterTrans
        '
        Me.cmbPrinterTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterTrans.FormattingEnabled = True
        Me.cmbPrinterTrans.Location = New System.Drawing.Point(127, 70)
        Me.cmbPrinterTrans.Name = "cmbPrinterTrans"
        Me.cmbPrinterTrans.Size = New System.Drawing.Size(285, 21)
        Me.cmbPrinterTrans.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 303
        Me.Label4.Text = "Printer Transaksi"
        '
        'cmbSizePrinterTrans
        '
        Me.cmbSizePrinterTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSizePrinterTrans.FormattingEnabled = True
        Me.cmbSizePrinterTrans.Location = New System.Drawing.Point(127, 97)
        Me.cmbSizePrinterTrans.Name = "cmbSizePrinterTrans"
        Me.cmbSizePrinterTrans.Size = New System.Drawing.Size(285, 21)
        Me.cmbSizePrinterTrans.TabIndex = 304
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 305
        Me.Label1.Text = "Ukuran"
        '
        'cbCLPrintTrans
        '
        Me.cbCLPrintTrans.AutoSize = True
        Me.cbCLPrintTrans.Location = New System.Drawing.Point(127, 124)
        Me.cbCLPrintTrans.Name = "cbCLPrintTrans"
        Me.cbCLPrintTrans.Size = New System.Drawing.Size(109, 17)
        Me.cbCLPrintTrans.TabIndex = 306
        Me.cbCLPrintTrans.Text = "Cetak Langsung"
        Me.cbCLPrintTrans.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(114, 158)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(104, 46)
        Me.btnrefresh.TabIndex = 307
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'cprinterconfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(472, 221)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.cbCLPrintTrans)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbSizePrinterTrans)
        Me.Controls.Add(Me.cmbPrinterTrans)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label8)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "cprinterconfig"
        Me.ShowIcon = False
        Me.Text = "Konfigurasi Sistem"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents cmbPrinterTrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSizePrinterTrans As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCLPrintTrans As CheckBox
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
End Class
