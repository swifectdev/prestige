Public Class changepass
    
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
        ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
            btnsave.PerformClick()
        End If


        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    
    Private Sub changepass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtcode.Text = cl.readData("SELECT code FROM cusr WHERE id = '" & idusr & "'")
        txtusername.Text = cl.readData("SELECT username FROM cusr WHERE id = '" & idusr & "'")
        txtname.Text = cl.readData("SELECT name FROM cusr WHERE id = '" & idusr & "'")
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtoldpass.Text = "" Then
            cl.msgError("Password can't NULL !", "Failed Verification")
            Exit Sub
        ElseIf txtnewpass.Text = "" Then
            cl.msgError("New Password can't NULL !", "Failed Verification")
            Exit Sub
        ElseIf txtnewpass2.Text = "" Then
            cl.msgError("New Password Confirmation can't NULL !", "Failed Verification")
            Exit Sub
        ElseIf txtnewpass.Text <> txtnewpass2.Text Then
            cl.msgError("New Password must same with New Password Confirmation !", "Failed Verification")
            Exit Sub
        End If

        Dim pass As String = cl.readData(
           " SELECT pass FROM cusr " & _
           " WHERE code = '" & txtcode.Text & "' AND tstatus = 1")
        With cl
            If .VerifyMd5Hash(txtoldpass.Text, pass) = True Then
                Dim tny As Integer
                tny = .msgYesNo("Apakah anda mau Ganti Password ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()


                    .execCmdTrans(
                        "EXEC scusr " &
                        " '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtusername.Text) & "'" &
                        " , '" & .cchr(txtnewpass.Text) & "'" &
                        " , ''" &
                        " , '0'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'cpass'" &
                        " , '" & idusr & "'" &
                        " ")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success change Password User : " & txtcode.Text & " !", "Information")
                        txtoldpass.Select()
                        txtoldpass.Text = ""
                        txtnewpass.Text = ""
                        txtnewpass2.Text = ""
                    End If
                End If
            Else
                cl.msgError("Password is wrong, please repeat !", "Verification Failed")
                Exit Sub
            End If

        End With
    End Sub
End Class