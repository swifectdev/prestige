<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.lbltit = New System.Windows.Forms.Label()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.txtusr = New classlibobjswiplb.txtAlphabet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpass = New classlibobjswiplb.txtAlphabet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnlogin = New classlibobjswiplb.btnLogin()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbdatabase = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ProgressBarLogin = New System.Windows.Forms.ProgressBar()
        Me.tmrLogin = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltit
        '
        Me.lbltit.AutoSize = True
        Me.lbltit.BackColor = System.Drawing.Color.White
        Me.lbltit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltit.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltit.ForeColor = System.Drawing.Color.Black
        Me.lbltit.Location = New System.Drawing.Point(12, 9)
        Me.lbltit.Name = "lbltit"
        Me.lbltit.Size = New System.Drawing.Size(369, 39)
        Me.lbltit.TabIndex = 300
        Me.lbltit.Text = "LOGIN - PRESTIGELUXBAGS"
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(331, 124)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 4
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'txtusr
        '
        Me.txtusr.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtusr.Location = New System.Drawing.Point(100, 62)
        Me.txtusr.Name = "txtusr"
        Me.txtusr.Size = New System.Drawing.Size(320, 22)
        Me.txtusr.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Username"
        '
        'txtpass
        '
        Me.txtpass.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtpass.Location = New System.Drawing.Point(100, 90)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(320, 22)
        Me.txtpass.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 303
        Me.Label1.Text = "Password"
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnlogin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnlogin.Image = CType(resources.GetObject("btnlogin.Image"), System.Drawing.Image)
        Me.btnlogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogin.Location = New System.Drawing.Point(12, 124)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(83, 46)
        Me.btnlogin.TabIndex = 3
        Me.btnlogin.Text = "Login"
        Me.btnlogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlogin.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.swisyBC.My.Resources.Resources._2298934_904bd1ca_0d1a_4501_9df5_928c4ec393e1
        Me.PictureBox1.Location = New System.Drawing.Point(448, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 136)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 304
        Me.PictureBox1.TabStop = False
        '
        'cmbdatabase
        '
        Me.cmbdatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdatabase.FormattingEnabled = True
        Me.cmbdatabase.Location = New System.Drawing.Point(124, 139)
        Me.cmbdatabase.Name = "cmbdatabase"
        Me.cmbdatabase.Size = New System.Drawing.Size(52, 21)
        Me.cmbdatabase.TabIndex = 307
        Me.cmbdatabase.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(182, 142)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 308
        Me.Label9.Text = "Database"
        Me.Label9.Visible = False
        '
        'ProgressBarLogin
        '
        Me.ProgressBarLogin.Location = New System.Drawing.Point(12, 218)
        Me.ProgressBarLogin.Name = "ProgressBarLogin"
        Me.ProgressBarLogin.Size = New System.Drawing.Size(613, 21)
        Me.ProgressBarLogin.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBarLogin.TabIndex = 309
        '
        'tmrLogin
        '
        Me.tmrLogin.Interval = 500
        '
        'login
        '
        Me.AcceptButton = Me.btnlogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btncancel
        Me.ClientSize = New System.Drawing.Size(638, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBarLogin)
        Me.Controls.Add(Me.cmbdatabase)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtusr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.lbltit)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltit As System.Windows.Forms.Label
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents txtusr As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpass As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnlogin As classlibobjswiplb.btnLogin
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbdatabase As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ProgressBarLogin As System.Windows.Forms.ProgressBar
    Friend WithEvents tmrLogin As System.Windows.Forms.Timer
End Class
