Public Class cusr
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
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F5) Then
            btnresetpass.PerformClick()
            '-----------------------------------------------------------------------
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "SELECT id AS 'value', name AS 'display'  FROM mlocation WHERE tstatus = 1 ")

        cmbcostcenter.DataSource = dtemptp
        cmbcostcenter.ValueMember = "value"
        cmbcostcenter.DisplayMember = "display"

    End Sub

    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub
    Private Sub gencode()
        txtcode.Text = cl.readData("SELECT dbo.fgetcode('cusr','')")
    End Sub
    Private Sub clearData()
        txtcode.Text = ""
        txtname.Text = ""
        txtusername.Text = ""

        txtnote.Text = ""
        chshowmenu.Checked = False
        chapprove.Checked = False
        chadmin.Checked = False
    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            gencode()
            loadcmb()
            btnsave.Text = "Save"

            btndelete.Visible = False
            btnresetpass.Visible = False
        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True
            btnresetpass.Visible = True
        End If


        Me.Select() : txtname.Select()
    End Sub

    Private Sub uom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub

    Private Sub muom_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtname.Select()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl

            '------ start validasi
            If validatetxtnull(txtcode, "Code Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtname, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtusername, "User Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            '------ end validasi

            Dim showmenu As String
            If chshowmenu.Checked = False Then
                showmenu = "N"
            Else
                showmenu = "Y"
            End If

            If btnsave.Text = "Save" Then

                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT CanAdd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'user'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                If .readData("SELECT count(id) FROM cusr where username =  '" & .cchr(txtusername.Text) & "' AND tstatus = 1") > 0 Then
                    .msgError("Username yg di buat sudah ada, mohon gunakan username lain ! !", "Informasi")
                    txtusername.Select()
                    Exit Sub
                End If

                '---------------------END------------------------'

                Dim tny As Integer
                tny = .msgYesNo("Do you want to Save User : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()

                    .execCmdTrans(
                        "EXEC scusr " &
                        " '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtusername.Text) & "'" &
                        " , 'pass'" &
                        " , '" & showmenu & "'" &
                        " , '" & .cnum(cmbcostcenter.SelectedValue) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        " ")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Save User : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then

                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT CanUpdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'user'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                '---------------------END------------------------'

                Dim tny As Integer
                tny = .msgYesNo("Do you want to Update User : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC scusr " &
                        " '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , '" & .cchr(txtusername.Text) & "'" &
                        " , 'pass'" &
                        " , '" & showmenu & "'" &
                        " , '" & .cnum(cmbcostcenter.SelectedValue) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        " ")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Update User : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim frm As New cusr
        cekform(frm, "REFRESH", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New search
        Dim sqlStr As String =
            "SELECT * FROM cusr WHERE tstatus = 1 "

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Name"
            '  .Columns("usrtp").Visible = True : .Columns("usrtp").HeaderText = "Type"
        End With

        a.loadStatusTempForm(Me, Me.btnlist, Me.txtname, "[usr]cusr")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Search : User"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            If idmaster = 1 Then
                .msgError("Tidak dapat delete user default dari system !", "Informasi")
            End If
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT CanDelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'user'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If

            '---------------------END------------------------'

            Dim tny As Integer
            tny = .msgYesNo("Do you want to Delete User : " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                       "EXEC scusr " &
                       " '" & .cchr(txtcode.Text) & "'" &
                       " , '" & .cchr(txtname.Text) & "'" &
                       " , '" & .cchr(txtusername.Text) & "'" &
                       " , 'pass'" &
                       " , ''" &
                       " , '" & .cnum(cmbcostcenter.SelectedValue) & "'" &
                       " , '" & .cchr(txtnote.Text) & "'" &
                       " , '" & idusr & "'" &
                       " , 'del'" &
                       " , '" & idmaster & "'" &
                       " ")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete User : " & txtname.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnresetpass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnresetpass.Click
        With cl
            Dim tny As Integer
            tny = .msgYesNo("Do you want to Reset Password User : " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                       "EXEC scusr " &
                       " '" & .cchr(txtcode.Text) & "'" &
                       " , '" & .cchr(txtname.Text) & "'" &
                       " , '" & .cchr(txtusername.Text) & "'" &
                       " , '12345'" &
                       " , ''" &
                       " , '" & .cnum(cmbcostcenter.SelectedValue) & "'" &
                       " , '" & .cchr(txtnote.Text) & "'" &
                       " , '" & idusr & "'" &
                       " , 'rpass'" &
                       " , '" & idmaster & "'" &
                       " ")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Reset Password User : " & txtname.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub
End Class