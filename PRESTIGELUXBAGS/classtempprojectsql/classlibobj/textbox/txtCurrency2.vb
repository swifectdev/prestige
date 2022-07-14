Public Class txtCurrency2
    Inherits System.Windows.Forms.TextBox

    Public Sub New()
        Me.Font = New Drawing.Font("Segoe UI", 8, Drawing.FontStyle.Regular)
    End Sub
    Private Sub meKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Not (e.KeyChar = "." And InStr(Me.Text, ".") And InStr(Me.Text, ",") = 0) Then
            If InStr("0123456789.", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                e.KeyChar = ""
            End If
        End If
    End Sub
    Private Sub meGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.SelectAll()
        Me.Text = Me.Text.Replace(",", "")
    End Sub
    Private Sub meLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Tag = Val(Me.Text)
        Me.Text = cCur4(Me.Text)
    End Sub
    'Public Overloads Property Size As System.Drawing.Size
    '    Get
    '        Return MyBase.Size
    '    End Get
    '    Set(ByVal value As Drawing.Size)
    '        MyBase.Size = New Drawing.Size(320, 22)
    '    End Set
    'End Property
End Class
