
Public Class btnCancel
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.BackColor = System.Drawing.Color.WhiteSmoke

        Me.Font = New Drawing.Font("Segoe UI", 9.75!, Drawing.FontStyle.Bold)
        Me.Image = My.Resources.rscImg.cancel

        Me.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.TabIndex = 0
        Me.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.UseVisualStyleBackColor = False
    End Sub

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = "Cancel"
            Me.Invalidate()
        End Set
    End Property
    Public Overloads Property Size As System.Drawing.Size
        Get
            Return MyBase.Size
        End Get
        Set(ByVal value As Drawing.Size)
            MyBase.Size = New Drawing.Size(89, 46)
        End Set
    End Property

End Class

