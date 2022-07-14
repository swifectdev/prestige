Imports System.IO

Public Class settingonline
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
       ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            Me.Dispose()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Function checkFileSettingOnline()
        If System.IO.File.Exists(dirSettingFileOnline) = True Then : Return 1
        Else : Return 0 : End If
    End Function

    Private Sub settingonline_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim chk As Integer = checkFileSettingOnline()
        If chk = 0 Then
            lblstatus.Text = "Status : NOT AVAILABLE"
            lblstatus.ForeColor = Color.Black
        ElseIf chk = 1 Then
            lblstatus.Text = "Status : AVAILABLE"
            lblstatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "C:"
        openFileDialog1.Filter = "SWI files (*.swi)|*.swi|All files (*.*)|*.*"

        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    txtDirectory.Text = openFileDialog1.FileName
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file SWI from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destPath As String,
                            ByVal filename As String, Optional ByVal statExt As Integer = 0)
        If Not Directory.Exists(destPath) Then
            Directory.CreateDirectory(destPath)
        End If
        Dim sourceExt As String = Path.GetExtension(sourcePath)


        'untuk mengkopi extension file
        Dim dest As String
        If statExt = 0 Then : dest = Path.Combine(destPath, Path.GetFileName(filename))
        Else : dest = Path.Combine(destPath, Path.GetFileName(filename & sourceExt))
        End If

        If File.Exists(dest) Then
            File.Delete(dest)
        End If

        File.Copy(sourcePath, dest)

    End Sub

    Private Sub btnUpload_Click(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click
        If txtDirectory.Text = "" Then
            MsgBox("Direktori tidak boleh kosong", MsgBoxStyle.Exclamation, "Gagal Simpan File Setting")
            Exit Sub
        End If

        If lblstatus.Text = "Status : AVAILABLE" Then
            Dim tny As Integer
            tny = MessageBox.Show("Apakah anda akan menimpa File Setting BC Online ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tny = vbYes Then
                CopyDirectory(txtDirectory.Text, "C:\SWIOnlineBC\", "SWIOnlineBC", 1)
                MsgBox("Berhasil Update File Setting", MsgBoxStyle.Information, "Simpan File Setting")
                Me.Dispose()
            End If
        Else
            CopyDirectory(txtDirectory.Text, "C:\SWIOnlineBC\", "SWIOnlineBC", 1)
            MsgBox("Berhasil Simpan File Setting", MsgBoxStyle.Information, "Simpan File Setting")
            Me.Dispose()
        End If

        Dim a As New settingonline
        cekform(a, "REFRESH", Me)

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub txtDirectory_TextChanged(sender As Object, e As EventArgs) Handles txtDirectory.TextChanged

    End Sub

    Private Sub txtDirectory_DoubleClick(sender As Object, e As EventArgs) Handles txtDirectory.DoubleClick
        txtDirectory.Text = ""
    End Sub
End Class