Imports System.IO

Public Class uploadUSER
    Private compid As String = cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'")
    Private Sub uploadFileBC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbtipefile.SelectedIndex = 0
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            Me.Dispose()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



    Private Sub convertToSQL()
        Try
            Dim dtTemp As New DataTable

            Dim tempField As String = ""

            '            ITEM MASTER
            '               BRAND
            '            VENDOR
            '            CONSIGNEE
            '            CUSTOMER
            '            SALES/ ADMIN
            If cmbtipefile.Text = "ITEM MASTER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [ITEM$]")
            ElseIf cmbtipefile.Text = "BRAND" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BRAND$]")
            ElseIf cmbtipefile.Text = "VENDOR" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [VENDOR$]")
            ElseIf cmbtipefile.Text = "CONSIGNEE" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [CONSIGNEE$]")
            ElseIf cmbtipefile.Text = "CUSTOMER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [CUSTOMER$]")
            ElseIf cmbtipefile.Text = "SALES/ADMIN" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [SALES$]")
            Else
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [UPLOAD$]")
            End If

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = 10000
            Dim progressCounter As Integer = 10000 / dtTemp.Rows.Count

            For i As Integer = 0 To dtTemp.Rows.Count - 1


                If ProgressBar1.Value < ProgressBar1.Maximum And
            ProgressBar1.Value + progressCounter < ProgressBar1.Maximum Then
                    ProgressBar1.Value += progressCounter
                End If

                If cmbtipefile.Text = "ITEM MASTER" Then
                    cl.execCmdTrans("IF NOT EXISTS (SELECT TOP 1 code FROM mitem WHERE code = '" & dtTemp.Rows(i).Item(0) & "' AND tstatus = 1) " &
                                    " BEGIN INSERT INTO mitem (code, code_mtype, name, code_mbrand, sze, color,spec1, spec2, spec3, spec4, spec5, spec6, spec7, spec8, spec9, spec10, spec11, spec12, spec13, spec14, spec15, spec16, spec17, spec18, spec19, note, " &
                                    " qty, code_muom, code_mcurrb, hrgbeli, code_mcurrj, hrgjual, code_mlocation, code_mconsign, createduser)  " &
                    " SELECT '" & cl.cchr(dtTemp.Rows(i).Item(0)) & "'" &
                    " , '" & dtTemp.Rows(i).Item(1) & "'" &
                    " , '" & dtTemp.Rows(i).Item(2) & "'" &
                    " , '" & dtTemp.Rows(i).Item(3) & "'" &
                    " , '" & dtTemp.Rows(i).Item(4) & "'" &
                    " , '" & dtTemp.Rows(i).Item(5) & "'" &
                    " , '" & dtTemp.Rows(i).Item(6) & "'" &
                    " , '" & dtTemp.Rows(i).Item(7) & "'" &
                    " , '" & dtTemp.Rows(i).Item(8) & "'" &
                    " , '" & dtTemp.Rows(i).Item(9) & "'" &
                    " , '" & dtTemp.Rows(i).Item(10) & "'" &
                    " , '" & dtTemp.Rows(i).Item(11) & "'" &
                    " , '" & dtTemp.Rows(i).Item(12) & "'" &
                    " , '" & dtTemp.Rows(i).Item(13) & "'" &
                    " , '" & dtTemp.Rows(i).Item(14) & "'" &
                    " , '" & dtTemp.Rows(i).Item(15) & "'" &
                    " , '" & dtTemp.Rows(i).Item(16) & "'" &
                    " , '" & dtTemp.Rows(i).Item(17) & "'" &
                    " , '" & dtTemp.Rows(i).Item(18) & "'" &
                    " , '" & dtTemp.Rows(i).Item(19) & "'" &
                    " , '" & dtTemp.Rows(i).Item(20) & "'" &
                    " , '" & dtTemp.Rows(i).Item(21) & "'" &
                    " , '" & dtTemp.Rows(i).Item(22) & "'" &
                    " , '" & dtTemp.Rows(i).Item(23) & "'" &
                    " , '" & dtTemp.Rows(i).Item(24) & "'" &
                    " , '" & dtTemp.Rows(i).Item(25) & "'" &
                    " , '" & dtTemp.Rows(i).Item(26) & "'" &
                    " , '" & dtTemp.Rows(i).Item(27) & "'" &
                    " , '" & dtTemp.Rows(i).Item(28) & "'" &
                    " , '" & dtTemp.Rows(i).Item(29) & "'" &
                    " , '" & dtTemp.Rows(i).Item(30) & "'" &
                    " , '" & dtTemp.Rows(i).Item(31) & "'" &
                    " , '" & dtTemp.Rows(i).Item(32) & "'" &
                    " , '" & dtTemp.Rows(i).Item(33) & "'" &
                    " , '1' END")

                ElseIf cmbtipefile.Text = "BRAND" Then
                    cl.execCmdTrans("IF NOT EXISTS (SELECT TOP 1 code FROM mbrand WHERE code = '" & dtTemp.Rows(i).Item(0) & "' AND tstatus = 1) " &
                                    " BEGIN INSERT INTO mbrand (code, name, createduser)  " &
                    " SELECT '" & cl.cchr(dtTemp.Rows(i).Item(0)) & "'" &
                    " , '" & cl.cchr(dtTemp.Rows(i).Item(1)) & "'" &
                    " , '1' END")

                End If
            Next

            'If cmbtipefile.Text = "ITEM MASTER" Then
            '    cl.execCmdTrans("UPDATE mitem set ")

            '    tempField = ""

            '    dtTemp.Clear()
            '    ProgressBar1.Value = 10000

            'End If
        Catch ex As Exception
            MessageBox.Show("Cannot copy file from disk to BC System. Original error : " & ex.Message)

            Exit Sub
        End Try
    End Sub


    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If txtDirectory.Text = "" Then
            MsgBox("Direktori File belum diisi !", MsgBoxStyle.Information, "Gagal Upload")
            btnBrowse.Focus()
            Exit Sub
        End If

        Try
            cl.openTrans()
            convertToSQL()


            cl.closeTrans(btnBrowse)
            If cl.sCloseTrans = 1 Then
                cl.msgInform("Success upload data " & cmbtipefile.Text & " !", "Success Upload")
            End If


            ProgressBar1.Value = 0
            txtDirectory.Clear()
        Catch ex As Exception
            cl.msgError("Failed upload file Excel to System", "Failed Upload")
            Exit Sub
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "C:"
        openFileDialog1.Filter = "All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 4
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    txtDirectory.Text = openFileDialog1.FileName
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file Excel from disk. Original error : " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        With cl
            Dim tny As Integer
            tny = .msgYesNo("Reset transaksi " & cmbtipefile.Text & "?", "Konfirmasi")
            If tny = vbYes Then
                .openTrans()
                If cmbtipefile.Text = "GOODS RECEIPT (BARANG MASUK)" Then
                    .execCmdTrans("DELETE FROM tgr")
                    .execCmdTrans("DELETE FROM tgrd")
                    .execCmdTrans("DELETE FROM beigr")
                    .execCmdTrans("UPDATE mitem SET stock = dbo.fcgetstock(id)")
                ElseIf cmbtipefile.Text = "GOODS ISSUE (BARANG KELUAR)" Then
                    .execCmdTrans("DELETE FROM tgi")
                    .execCmdTrans("DELETE FROM tgid")
                    .execCmdTrans("DELETE FROM beigi")
                    .execCmdTrans("UPDATE mitem SET stock = dbo.fcgetstock(id)")
                ElseIf cmbtipefile.Text = "INCOMING" Then
                    .execCmdTrans("DELETE FROM trec")
                    .execCmdTrans("DELETE FROM trecd")
                    .execCmdTrans("DELETE FROM beincoming")
                    .execCmdTrans("UPDATE mitem SET stock = dbo.fcgetstock(id)")
                ElseIf cmbtipefile.Text = "OUTGOING" Then
                    .execCmdTrans("DELETE FROM tdo")
                    .execCmdTrans("DELETE FROM tdod")
                    .execCmdTrans("DELETE FROM beioutgoing")
                    .execCmdTrans("UPDATE mitem SET stock = dbo.fcgetstock(id)")
                End If
                .closeTrans(btnreset)
                .msgInform("Sukses reset transaksi " & cmbtipefile.Text & " !", "Informasi")
            End If
        End With
    End Sub

    Private Sub btnreset2_Click(sender As Object, e As EventArgs) Handles btnreset2.Click
        With cl
            Dim tny As Integer
            tny = .msgYesNo("Reset SEMUA transaksi ?", "Konfirmasi")
            If tny = vbYes Then
                .openTrans()
                '  If cmbtipefile.Text = "GOODS RECEIPT (BARANG MASUK)" Then
                .execCmdTrans("DELETE FROM tgr")
                .execCmdTrans("DELETE FROM tgrd")
                .execCmdTrans("DELETE FROM beigr")
                ' ElseIf cmbtipefile.Text = "GOODS ISSUE (BARANG KELUAR)" Then
                .execCmdTrans("DELETE FROM tgi")
                .execCmdTrans("DELETE FROM tgid")
                .execCmdTrans("DELETE FROM beigi")
                ' ElseIf cmbtipefile.Text = "INCOMING" Then
                .execCmdTrans("DELETE FROM trec")
                .execCmdTrans("DELETE FROM trecd")
                .execCmdTrans("DELETE FROM beincoming")
                'ElseIf cmbtipefile.Text = "OUTGOING" Then
                .execCmdTrans("DELETE FROM tdo")
                .execCmdTrans("DELETE FROM tdod")
                .execCmdTrans("DELETE FROM beioutgoing")
                .execCmdTrans("UPDATE mitem SET stock = dbo.fcgetstock(id)")
                'End If
                .closeTrans(btnreset)
                .msgInform("Sukses reset SEMUA transaksi !", "Informasi")
            End If
        End With
    End Sub

    Private Sub cmbtipefile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipefile.SelectedIndexChanged

    End Sub
End Class