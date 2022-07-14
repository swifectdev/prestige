
Public Class btnBrowse
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.BackColor = System.Drawing.Color.WhiteSmoke

        Me.Font = New Drawing.Font("Segoe UI", 9.75!, Drawing.FontStyle.Bold)
        Me.Size = New Drawing.Size(23, 23)
        Me.UseVisualStyleBackColor = False
        Me.BackgroundImage = My.Resources.rscImg.search
        Me.BackgroundImageLayout = Windows.Forms.ImageLayout.Stretch

    End Sub
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = ""
            Me.Invalidate()
        End Set
    End Property

End Class

