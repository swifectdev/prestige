<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cgetserial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cgetserial))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtserial = New classlibobjswiplb.txtAlphabet()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtserialapplication = New classlibobjswiplb.txtAlphabet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.btnviewserial = New classlibobjswiplb.btnBlank()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Serial Komputer"
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(458, 122)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 105
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtserial
        '
        Me.txtserial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtserial.Location = New System.Drawing.Point(134, 18)
        Me.txtserial.Name = "txtserial"
        Me.txtserial.ReadOnly = True
        Me.txtserial.Size = New System.Drawing.Size(320, 22)
        Me.txtserial.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(460, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 87)
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(336, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "* Kirim serial ini ke admin SWIFECT, tunggu untuk balasan 1 x 24 jam"
        '
        'txtserialapplication
        '
        Me.txtserialapplication.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtserialapplication.Location = New System.Drawing.Point(134, 83)
        Me.txtserialapplication.Name = "txtserialapplication"
        Me.txtserialapplication.Size = New System.Drawing.Size(320, 22)
        Me.txtserialapplication.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Serial Aplikasi"
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnsave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(15, 122)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(135, 46)
        Me.btnsave.TabIndex = 111
        Me.btnsave.Text = "Simpan Serial"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnviewserial
        '
        Me.btnviewserial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnviewserial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnviewserial.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewserial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewserial.Location = New System.Drawing.Point(374, 48)
        Me.btnviewserial.Name = "btnviewserial"
        Me.btnviewserial.Size = New System.Drawing.Size(80, 25)
        Me.btnviewserial.TabIndex = 106
        Me.btnviewserial.Text = "TAMPILKAN"
        Me.btnviewserial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnviewserial.UseVisualStyleBackColor = False
        Me.btnviewserial.Visible = False
        '
        'cgetserial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(556, 178)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtserialapplication)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnviewserial)
        Me.Controls.Add(Me.txtserial)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "cgetserial"
        Me.Text = "Serial Key"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents txtserial As classlibobjswiplb.txtAlphabet
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtserialapplication As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents btnviewserial As classlibobjswiplb.btnBlank
End Class
