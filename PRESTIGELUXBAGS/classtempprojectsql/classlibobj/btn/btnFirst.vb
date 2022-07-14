
Public Class btnFirst
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.BackColor = System.Drawing.Color.WhiteSmoke

        Me.Font = New Drawing.Font("Segoe UI", 9.75!, Drawing.FontStyle.Bold)
        
        Me.Size = New Drawing.Size(40, 40)
        Me.TabIndex = 0
        Me.TextAlign = Drawing.ContentAlignment.MiddleCenter
        Me.UseVisualStyleBackColor = False
    End Sub

    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = "<<"
            Me.Invalidate()
        End Set
    End Property


End Class

