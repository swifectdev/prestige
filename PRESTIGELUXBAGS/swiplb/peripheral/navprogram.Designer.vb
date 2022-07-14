<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class navprogram
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(navprogram))
        Me.lbltit = New System.Windows.Forms.Label()
        Me.tvmenu = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnleft = New classlibobjswiplb.btnBlank()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'lbltit
        '
        Me.lbltit.AutoSize = True
        Me.lbltit.BackColor = System.Drawing.Color.White
        Me.lbltit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbltit.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltit.Location = New System.Drawing.Point(3, 9)
        Me.lbltit.Name = "lbltit"
        Me.lbltit.Size = New System.Drawing.Size(182, 39)
        Me.lbltit.TabIndex = 300
        Me.lbltit.Text = "MAIN MENU"
        '
        'tvmenu
        '
        Me.tvmenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvmenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tvmenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvmenu.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tvmenu.ImageIndex = 2
        Me.tvmenu.ImageList = Me.ImageList1
        Me.tvmenu.Location = New System.Drawing.Point(3, 51)
        Me.tvmenu.Name = "tvmenu"
        Me.tvmenu.SelectedImageIndex = 2
        Me.tvmenu.Size = New System.Drawing.Size(217, 434)
        Me.tvmenu.TabIndex = 301
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "book.png")
        Me.ImageList1.Images.SetKeyName(1, "book_open.png")
        Me.ImageList1.Images.SetKeyName(2, "page_white.png")
        '
        'btnleft
        '
        Me.btnleft.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnleft.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnleft.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnleft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnleft.Location = New System.Drawing.Point(12, 498)
        Me.btnleft.Name = "btnleft"
        Me.btnleft.Size = New System.Drawing.Size(27, 28)
        Me.btnleft.TabIndex = 0
        Me.btnleft.Text = "<"
        Me.btnleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnleft.UseVisualStyleBackColor = False
        '
        'navprogram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(229, 538)
        Me.Controls.Add(Me.btnleft)
        Me.Controls.Add(Me.tvmenu)
        Me.Controls.Add(Me.lbltit)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "navprogram"
        Me.Text = "Menu Navigation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltit As System.Windows.Forms.Label
    Friend WithEvents tvmenu As System.Windows.Forms.TreeView
    Friend WithEvents btnleft As classlibobjswiplb.btnBlank
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
