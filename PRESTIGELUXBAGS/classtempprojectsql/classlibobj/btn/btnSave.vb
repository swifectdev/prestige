
Public Class btnSave
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.BackColor = System.Drawing.Color.WhiteSmoke

        Me.Font = New Drawing.Font("Segoe UI", 9.75!, Drawing.FontStyle.Bold)
        Me.Image = My.Resources.rscImg.save

        Me.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.Size = New Drawing.Size(96, 46)
        Me.TabIndex = 0
        Me.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.UseVisualStyleBackColor = False
    End Sub
End Class

