Public Class txtFree
    Inherits System.Windows.Forms.TextBox

    Public Sub New()
        Me.Font = New Drawing.Font("Segoe UI", 8, Drawing.FontStyle.Regular)
    End Sub
    Private Sub meGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub
End Class
