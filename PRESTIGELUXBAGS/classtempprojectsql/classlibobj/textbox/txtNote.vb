Public Class txtNote
    Inherits System.Windows.Forms.TextBox


    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub meGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub
    Private Sub InitializeComponent()
        Me.Font = New Drawing.Font("Segoe UI", 8, Drawing.FontStyle.Regular)
        Me.Multiline = True
        Me.Size = New Drawing.Size(320, 44)
    End Sub
    'Public Overloads Property Size As System.Drawing.Size
    '    Get
    '        Return MyBase.Size
    '    End Get
    '    Set(ByVal value As Drawing.Size)
    '        MyBase.Size = New Drawing.Size(320, 44)
    '    End Set
    'End Property
    

End Class
