Imports System.IO
Public Class mconsignee
    Dim idmaster As Integer = 0, statform As String = ""

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
        ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
            '-----------------------------------------------------------------------
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
            If btnsave.Text = "Save" Or (idmaster <> 0 And btnsave.Text = "Update") Then
                btnsave.PerformClick()
            End If
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F2) Then
            btnrefresh.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F3) Then
            btnlist.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F4) Then
            If idmaster <> 0 And btnsave.Text <> "Save" Then : btndelete.PerformClick() : End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub

    Private Sub gencode()
        txtcode.Text = cl.readData("SELECT dbo.fgetcode('mconsignee','" & Now() & "')")
    End Sub

    Private Sub clearData()
        txtcode.Text = ""
        txtname.Text = ""
        cmbgender.SelectedIndex = 1
        txthp1.Text = ""
        txthp2.Text = ""
        txtnorek.Text = ""
        txtalamat.Text = ""
        txtnote.Text = ""
        txtktp.Text = ""
    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            btnsave.Text = "Save"
            gencode()
            btndelete.Visible = False

        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True

        End If
        Me.Select() : txtname.Select()
    End Sub

    Private Sub mbranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub

    Private Sub mbp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtname.Select()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl

            '------ start validasi
            If validatetxtnull(txtname, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            '------ end validasi


            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mconsignee'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                If cl.readData("SELECT COUNT(id) FROM mconsignee where hp1 = '" & txthp1.Text & "' and tstatus = 1") Then
                    cl.msgError("No HP sudah teregister mohon untuk di checking kembali !", "Informasi")
                    Exit Sub
                End If

                Dim newcode As String = cl.readData("SELECT dbo.fgetcode('mconsignee','" & Now() & "')")
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC smconsignee " &
                        " '" & newcode & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtktp.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                        " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")

                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Save : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mconsignee'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                         "EXEC smconsignee " &
                        " '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtktp.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                         " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        "")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Update : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New mconsignee
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.* FROM mconsignee TA WHERE TA.tstatus = 1"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("hp1").Visible = True : .Columns("hp1").HeaderText = "HP"
            .Columns("norek").Visible = True : .Columns("norek").HeaderText = "Rekening"
            .Columns("alamat").Visible = True : .Columns("alamat").HeaderText = "Alamat"

        End With
        a.loadStatusTempForm(Me, Me.txtcode, "[mconsignee]mconsignee")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Consignee"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mconsignee'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'
            ' -- VALIDATE CANNOT DELETE CONSIGNEE IF USED IN CONSIGNMENT TRANSACTION
            If cl.readData("SELECT COUNT(id) FROM tconsign where code_mconsignee = '" & txtcode.Text & "' AND tstatus = 1") > 0 Then
                .msgError("Tidak bisa delete consignee, sudah ada transaksi aktif !", "Informasi")
                Exit Sub
            End If

            If cl.readData("SELECT COUNT(id) FROM mitem where code_mconsignee = '" & txtcode.Text & "' AND tstatus = 1") > 0 Then
                .msgError("Tidak bisa delete consignee, sudah ada di item yang sedang aktif !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Delete Consignee : " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                        "EXEC smconsignee " &
                       " '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtktp.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                         " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Consignee : " & txtname.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub
End Class