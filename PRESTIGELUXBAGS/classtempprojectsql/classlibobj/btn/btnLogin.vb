
Public Class btnLogin
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.BackColor = System.Drawing.Color.WhiteSmoke

        Me.Font = New Drawing.Font("Segoe UI", 9.75!, Drawing.FontStyle.Bold)
        Me.Image = My.Resources.rscImg.viewLogin

        Me.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        Me.Size = New Drawing.Size(83, 46)
        Me.TabIndex = 0
        Me.TextAlign = Drawing.ContentAlignment.MiddleRight
        Me.UseVisualStyleBackColor = False
    End Sub

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = "Login"
            Me.Invalidate()
        End Set
    End Property


End Class

