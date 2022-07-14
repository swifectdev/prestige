<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mupdownerprice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mupdownerprice))
        Me.dgview = New System.Windows.Forms.DataGridView()
        Me.btncancel = New classlibobjswiplb.btnCancel()
        Me.btnrefresh = New classlibobjswiplb.btnRefresh()
        Me.btnsave = New classlibobjswiplb.btnSave()
        Me.lbluseractivity = New System.Windows.Forms.Label()
        Me.BtnBrowse1 = New classlibobjswiplb.btnBrowse()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsearch = New classlibobjswiplb.txtAlphabet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnBrowse2 = New classlibobjswiplb.btnBrowse()
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgview
        '
        Me.dgview.AllowUserToAddRows = False
        Me.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgview.Location = New System.Drawing.Point(12, 50)
        Me.dgview.Name = "dgview"
        Me.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgview.Size = New System.Drawing.Size(1078, 360)
        Me.dgview.TabIndex = 200
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btncancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(996, 433)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(89, 46)
        Me.btncancel.TabIndex = 104
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnrefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(124, 431)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(96, 46)
        Me.btnrefresh.TabIndex = 342
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
        Me.btnsave.Location = New System.Drawing.Point(22, 431)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 46)
        Me.btnsave.TabIndex = 341
        Me.btnsave.Text = "Update"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'lbluseractivity
        '
        Me.lbluseractivity.AutoSize = True
        Me.lbluseractivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluseractivity.Location = New System.Drawing.Point(24, 413)
        Me.lbluseractivity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbluseractivity.Name = "lbluseractivity"
        Me.lbluseractivity.Size = New System.Drawing.Size(94, 15)
        Me.lbluseractivity.TabIndex = 427
        Me.lbluseractivity.Text = "lbluseractivity"
        Me.lbluseractivity.Visible = False
        '
        'BtnBrowse1
        '
        Me.BtnBrowse1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse1.BackgroundImage = CType(resources.GetObject("BtnBrowse1.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse1.Location = New System.Drawing.Point(307, 21)
        Me.BtnBrowse1.Name = "BtnBrowse1"
        Me.BtnBrowse1.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse1.TabIndex = 433
        Me.BtnBrowse1.UseVisualStyleBackColor = False
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(83, 21)
        Me.dtfrom.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(97, 22)
        Me.dtfrom.TabIndex = 434
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(196, 21)
        Me.dtto.Margin = New System.Windows.Forms.Padding(2)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(103, 22)
        Me.dtto.TabIndex = 435
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "Periode"
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtsearch.Location = New System.Drawing.Point(813, 22)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(247, 22)
        Me.txtsearch.TabIndex = 438
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(742, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 437
        Me.Label2.Text = "Cari Owner"
        '
        'BtnBrowse2
        '
        Me.BtnBrowse2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnBrowse2.BackgroundImage = CType(resources.GetObject("BtnBrowse2.BackgroundImage"), System.Drawing.Image)
        Me.BtnBrowse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBrowse2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBrowse2.Location = New System.Drawing.Point(1067, 22)
        Me.BtnBrowse2.Name = "BtnBrowse2"
        Me.BtnBrowse2.Size = New System.Drawing.Size(23, 23)
        Me.BtnBrowse2.TabIndex = 439
        Me.BtnBrowse2.UseVisualStyleBackColor = False
        '
        'mupdownerprice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1114, 503)
        Me.Controls.Add(Me.BtnBrowse2)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.BtnBrowse1)
        Me.Controls.Add(Me.lbluseractivity)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.dgview)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mupdownerprice"
        Me.Text = "Update Harga Owner"
        CType(Me.dgview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgview As System.Windows.Forms.DataGridView
    Friend WithEvents btncancel As classlibobjswiplb.btnCancel
    Friend WithEvents btnrefresh As classlibobjswiplb.btnRefresh
    Friend WithEvents btnsave As classlibobjswiplb.btnSave
    Friend WithEvents lbluseractivity As Label
    Friend WithEvents BtnBrowse1 As classlibobjswiplb.btnBrowse
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents txtsearch As classlibobjswiplb.txtAlphabet
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnBrowse2 As classlibobjswiplb.btnBrowse
End Class
