<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TxtNumeric1 = New classlibobjswibc.txtNumeric()
        Me.TxtCurrency1 = New classlibobjswibc.txtCurrency()
        Me.BtnResetPass1 = New classlibobjswibc.btnResetPass()
        Me.BtnLast1 = New classlibobjswibc.btnLast()
        Me.BtnPrev1 = New classlibobjswibc.btnPrev()
        Me.BtnNext1 = New classlibobjswibc.btnNext()
        Me.BtnFirst1 = New classlibobjswibc.btnFirst()
        Me.BtnRefresh1 = New classlibobjswibc.btnRefresh()
        Me.BtnLogin1 = New classlibobjswibc.btnLogin()
        Me.BtnList1 = New classlibobjswibc.btnList()
        Me.BtnSave1 = New classlibobjswibc.btnSave()
        Me.BtnPrint1 = New classlibobjswibc.btnPrint()
        Me.BtnView1 = New classlibobjswibc.btnView()
        Me.BtnDelete1 = New classlibobjswibc.btnDelete()
        Me.BtnCancel1 = New classlibobjswibc.btnCancel()
        Me.BtnBrowse1 = New classlibobjswibc.btnBrowse()
        Me.BtnBlank1 = New classlibobjswibc.btnBlank()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtNumeric1
        '
        Me.TxtNumeric1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtNumeric1.Location = New System.Drawing.Point(209, 215)
        Me.TxtNumeric1.Name = "TxtNumeric1"
        Me.TxtNumeric1.Size = New System.Drawing.Size(100, 22)
        Me.TxtNumeric1.TabIndex = 3
        '
        'TxtCurrency1
        '
        Me.TxtCurrency1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TxtCurrency1.Location = New System.Drawing.Point(58, 215)
        Me.TxtCurrency1.Name = "TxtCurrency1"
        Me.TxtCurrency1.Size = New System.Drawing.Size(100, 22)
        Me.TxtCurrency1.TabIndex = 2
        '
        'BtnResetPass1
        '
        Me.BtnResetPass1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnResetPass1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnResetPass1.Image = CType(resources.GetObject("BtnResetPass1.Image"), System.Drawing.Image)
        Me.BtnResetPass1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnResetPass1.Location = New System.Drawing.Point(440, 174)
        Me.BtnResetPass1.Name = "BtnResetPass1"
        Me.BtnResetPass1.Size = New System.Drawing.Size(110, 46)
        Me.BtnResetPass1.TabIndex = 0
        Me.BtnResetPass1.Text = "Reset Pass"
        Me.BtnResetPass1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnResetPass1.UseVisualStyleBackColor = False
        '
        'BtnLast1
        '
        Me.BtnLast1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLast1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnLast1.Location = New System.Drawing.Point(291, 158)
        Me.BtnLast1.Name = "BtnLast1"
        Me.BtnLast1.Size = New System.Drawing.Size(40, 40)
        Me.BtnLast1.TabIndex = 0
        Me.BtnLast1.Text = ">>"
        Me.BtnLast1.UseVisualStyleBackColor = False
        '
        'BtnPrev1
        '
        Me.BtnPrev1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPrev1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnPrev1.Location = New System.Drawing.Point(199, 158)
        Me.BtnPrev1.Name = "BtnPrev1"
        Me.BtnPrev1.Size = New System.Drawing.Size(40, 40)
        Me.BtnPrev1.TabIndex = 0
        Me.BtnPrev1.Text = "<"
        Me.BtnPrev1.UseVisualStyleBackColor = False
        '
        'BtnNext1
        '
        Me.BtnNext1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnNext1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnNext1.Location = New System.Drawing.Point(245, 158)
        Me.BtnNext1.Name = "BtnNext1"
        Me.BtnNext1.Size = New System.Drawing.Size(40, 40)
        Me.BtnNext1.TabIndex = 0
        Me.BtnNext1.Text = ">"
        Me.BtnNext1.UseVisualStyleBackColor = False
        '
        'BtnFirst1
        '
        Me.BtnFirst1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnFirst1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnFirst1.Location = New System.Drawing.Point(153, 158)
        Me.BtnFirst1.Name = "BtnFirst1"
        Me.BtnFirst1.Size = New System.Drawing.Size(40, 40)
        Me.BtnFirst1.TabIndex = 0
        Me.BtnFirst1.Text = "<<"
        Me.BtnFirst1.UseVisualStyleBackColor = False
        '
        'BtnRefresh1
        '
        Me.BtnRefresh1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnRefresh1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnRefresh1.Image = CType(resources.GetObject("BtnRefresh1.Image"), System.Drawing.Image)
        Me.BtnRefresh1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRefresh1.Location = New System.Drawing.Point(423, 84)
        Me.BtnRefresh1.Name = "BtnRefresh1"
        Me.BtnRefresh1.Size = New System.Drawing.Size(95, 46)
        Me.BtnRefresh1.TabIndex = 0
        Me.BtnRefresh1.Text = "Refresh"
        Me.BtnRefresh1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefresh1.UseVisualStyleBackColor = False
        '
        'BtnLogin1
        '
        Me.BtnLogin1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnLogin1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnLogin1.Image = CType(resources.GetObject("BtnLogin1.Image"), System.Drawing.Image)
        Me.BtnLogin1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLogin1.Location = New System.Drawing.Point(334, 84)
        Me.BtnLogin1.Name = "BtnLogin1"
        Me.BtnLogin1.Size = New System.Drawing.Size(83, 46)
        Me.BtnLogin1.TabIndex = 0
        Me.BtnLogin1.Text = "Login"
        Me.BtnLogin1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLogin1.UseVisualStyleBackColor = False
        '
        'BtnList1
        '
        Me.BtnList1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnList1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnList1.Image = CType(resources.GetObject("BtnList1.Image"), System.Drawing.Image)
        Me.BtnList1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnList1.Location = New System.Drawing.Point(153, 84)
        Me.BtnList1.Name = "BtnList1"
        Me.BtnList1.Size = New System.Drawing.Size(73, 46)
        Me.BtnList1.TabIndex = 0
        Me.BtnList1.Text = "List"
        Me.BtnList1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnList1.UseVisualStyleBackColor = False
        '
        'BtnSave1
        '
        Me.BtnSave1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSave1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnSave1.Image = CType(resources.GetObject("BtnSave1.Image"), System.Drawing.Image)
        Me.BtnSave1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave1.Location = New System.Drawing.Point(232, 84)
        Me.BtnSave1.Name = "BtnSave1"
        Me.BtnSave1.Size = New System.Drawing.Size(96, 46)
        Me.BtnSave1.TabIndex = 0
        Me.BtnSave1.Text = "BtnSave1"
        Me.BtnSave1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave1.UseVisualStyleBackColor = False
        '
        'BtnPrint1
        '
        Me.BtnPrint1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnPrint1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnPrint1.Image = CType(resources.GetObject("BtnPrint1.Image"), System.Drawing.Image)
        Me.BtnPrint1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint1.Location = New System.Drawing.Point(242, 32)
        Me.BtnPrint1.Name = "BtnPrint1"
        Me.BtnPrint1.Size = New System.Drawing.Size(83, 46)
        Me.BtnPrint1.TabIndex = 0
        Me.BtnPrint1.Text = "Print"
        Me.BtnPrint1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint1.UseVisualStyleBackColor = False
        '
        'BtnView1
        '
        Me.BtnView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnView1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnView1.Image = CType(resources.GetObject("BtnView1.Image"), System.Drawing.Image)
        Me.BtnView1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnView1.Location = New System.Drawing.Point(153, 32)
        Me.BtnView1.Name = "BtnView1"
        Me.BtnView1.Size = New System.Drawing.Size(83, 46)
        Me.BtnView1.TabIndex = 0
        Me.BtnView1.Text = "View"
        Me.BtnView1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnView1.UseVisualStyleBackColor = False
        '
        'BtnDelete1
        '
        Me.BtnDelete1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnDelete1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnDelete1.Image = CType(resources.GetObject("BtnDelete1.Image"), System.Drawing.Image)
        Me.BtnDelete1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete1.Location = New System.Drawing.Point(426, 32)
        Me.BtnDelete1.Name = "BtnDelete1"
        Me.BtnDelete1.Size = New System.Drawing.Size(90, 46)
        Me.BtnDelete1.TabIndex = 0
        Me.BtnDelete1.Text = "Delete"
        Me.BtnDelete1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete1.UseVisualStyleBackColor = False
        '
        'BtnCancel1
        '
        Me.BtnCancel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCancel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel1.Image = CType(resources.GetObject("BtnCancel1.Image"), System.Drawing.Image)
        Me.BtnCancel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel1.Location = New System.Drawing.Point(331, 32)
        Me.BtnCancel1.Name = "BtnCancel1"
        Me.BtnCancel1.Size = New System.Drawing.Size(89, 46)
        Me.BtnCancel1.TabIndex = 0
        Me.BtnCancel1.Text = "Cancel"
        Me.BtnCancel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel1.UseVisualStyleBackColor = False
        '
        'BtnBrowse1
        '
        Me.BtnBrowse1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse1.BackgroundImage = CType(resources.GetObject("BtnBrowse1.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse1.Location = New System.Drawing.Point(58, 97)
        Me.BtnBrowse1.Name = "BtnBrowse1"
        Me.BtnBrowse1.Size = New System.Drawing.Size(30, 30)
        Me.BtnBrowse1.TabIndex = 1
        Me.BtnBrowse1.UseVisualStyleBackColor = False
        '
        'BtnBlank1
        '
        Me.BtnBlank1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBlank1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBlank1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBlank1.Location = New System.Drawing.Point(40, 44)
        Me.BtnBlank1.Name = "BtnBlank1"
        Me.BtnBlank1.Size = New System.Drawing.Size(75, 23)
        Me.BtnBlank1.TabIndex = 0
        Me.BtnBlank1.Text = "BtnBlank1"
        Me.BtnBlank1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBlank1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "curr"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "num"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 262)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumeric1)
        Me.Controls.Add(Me.TxtCurrency1)
        Me.Controls.Add(Me.BtnResetPass1)
        Me.Controls.Add(Me.BtnLast1)
        Me.Controls.Add(Me.BtnPrev1)
        Me.Controls.Add(Me.BtnNext1)
        Me.Controls.Add(Me.BtnFirst1)
        Me.Controls.Add(Me.BtnRefresh1)
        Me.Controls.Add(Me.BtnLogin1)
        Me.Controls.Add(Me.BtnList1)
        Me.Controls.Add(Me.BtnSave1)
        Me.Controls.Add(Me.BtnPrint1)
        Me.Controls.Add(Me.BtnView1)
        Me.Controls.Add(Me.BtnDelete1)
        Me.Controls.Add(Me.BtnCancel1)
        Me.Controls.Add(Me.BtnBrowse1)
        Me.Controls.Add(Me.BtnBlank1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnBlank1 As classlibobjswibc.btnBlank
    Friend WithEvents BtnBrowse1 As classlibobjswibc.btnBrowse
    Friend WithEvents BtnCancel1 As classlibobjswibc.btnCancel
    Friend WithEvents BtnDelete1 As classlibobjswibc.btnDelete
    Friend WithEvents BtnView1 As classlibobjswibc.btnView
    Friend WithEvents BtnPrint1 As classlibobjswibc.btnPrint
    Friend WithEvents BtnSave1 As classlibobjswibc.btnSave
    Friend WithEvents BtnList1 As classlibobjswibc.btnList
    Friend WithEvents BtnLogin1 As classlibobjswibc.btnLogin
    Friend WithEvents BtnRefresh1 As classlibobjswibc.btnRefresh
    Friend WithEvents BtnFirst1 As classlibobjswibc.btnFirst
    Friend WithEvents BtnNext1 As classlibobjswibc.btnNext
    Friend WithEvents BtnPrev1 As classlibobjswibc.btnPrev
    Friend WithEvents BtnLast1 As classlibobjswibc.btnLast
    Friend WithEvents BtnResetPass1 As classlibobjswibc.btnResetPass
    Friend WithEvents TxtCurrency1 As classlibobjswibc.txtCurrency
    Friend WithEvents TxtNumeric1 As classlibobjswibc.txtNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
