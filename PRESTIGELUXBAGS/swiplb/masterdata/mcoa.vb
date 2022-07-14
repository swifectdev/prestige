Public Class mcoa
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
            'btnprint.PerformClick()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub
    Private Sub clearData()
        idmaster = 0

        txtcode.Text = ""
        txtname.Text = ""
        txtname2.Text = ""
        txtname_mcoa.Text = ""
        ' txtactive.Text = ""
        txtrptcattype.Text = ""
        txtrptcattype2.Text = ""
        chusename.Checked = False
        chusename2.Checked = False

        chcontrol.Checked = False
        chcash.Checked = False

        lblidmcoa.Text = 0
    End Sub

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "SELECT 'Y' AS 'value', 'YES' AS 'display'  UNION ALL  " &
            " SELECT 'N' AS 'value', 'NO' AS 'display'  ")

        cmbactive.DataSource = dtemptp
        cmbactive.ValueMember = "value"
        cmbactive.DisplayMember = "display"

        Dim dtemptp2 As DataTable = cl.table(
            "SELECT 1 AS 'value', 'Debit' AS 'display'  UNION ALL  " &
            " SELECT 0 AS 'value', 'Credit' AS 'display'  ")

        cmbdc.DataSource = dtemptp2
        cmbdc.ValueMember = "value"
        cmbdc.DisplayMember = "display"

        Dim dtemptp4 As DataTable = cl.table(
           "SELECT 'B' AS 'value', 'BALANCE SHEET/NERACA' AS 'display' UNION ALL " &
           " SELECT 'R' AS 'value', 'PROFIT LOSS/LABA RUGI' AS 'display' ")

        cmbrpttype.DataSource = dtemptp4
        cmbrpttype.ValueMember = "value"
        cmbrpttype.DisplayMember = "display"

        Dim dtemptp3 As DataTable = cl.table(
          "SELECT id AS 'value', name AS 'display'  " &
          " FROM mcoatype WHERE tstatus = 1 AND rpttype = '" & cmbrpttype.SelectedValue & "' ")

        cmbcoatype.DataSource = dtemptp3
        cmbcoatype.ValueMember = "value"
        cmbcoatype.DisplayMember = "display"

        Dim dtemptp5 As DataTable = cl.table(
        "SELECT id AS 'value', code AS 'display'  " &
        " FROM mcurr WHERE tstatus = 1 ")

        cmbcurr.DataSource = dtemptp5
        cmbcurr.ValueMember = "value"
        cmbcurr.DisplayMember = "display"
    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            loadcmb()
            btnsave.Text = "Save"
            '   gencode()
            btndelete.Visible = False
            loadTview()

        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True

        End If
        Me.Select() : txtname.Select()
    End Sub



    Private Sub Bank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub
    Private Sub mbp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtname.Select()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        With cl
            '------ start validasi
            If validatetxtnull(txtname, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            '------ end validasi
            Dim rpttype As String
            If Mid(txtcode.Text, 1, 1) = "1" Or Mid(txtcode.Text, 1, 1) = "2" Or Mid(txtcode.Text, 1, 1) = "3" Then
                rpttype = "B"
            Else
                rpttype = "R"
            End If

            Dim usename, usename2, control, cashbank As String
            If chusename.Checked = True Then
                usename = "Y"
            Else
                usename = "N"
            End If

            If chusename2.Checked = True Then
                usename2 = "Y"
            Else
                usename2 = "N"
            End If

            If chcontrol.Checked = True Then
                control = "Y"
            Else
                control = "N"
            End If

            If chcash.Checked = True Then
                cashbank = "Y"
            Else
                cashbank = "N"
            End If


            If btnsave.Text = "Save" Then

                '------ start validasi
                'If .ValidateTxtNull(txtname, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
                'If .ValidateTxtNull(txtactive, "Aktif harus di isi Y atau N !", "Warning Information") = 1 Then : Exit Sub : End If
                '------ end validasi

                'validasi akun tidak boleh ada yang double !
                If .readData("SELECT COUNT(id) FROM mcoa WHERE code = '" & txtcode.Text & "' AND tstatus = 1") > 0 Then
                    .msgError("Kode CoA sudah ada, silahkan gunakan kode lain !", "Informasi")
                    txtcode.Focus()
                    Exit Sub
                End If

                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT CanAdd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mcoa'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'

                Dim tny As Integer
                tny = .msgYesNo("Save COA : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC smcoa " &
                    " '" & .cchr(txtcode.Text) & "'" &
                    " , '" & .cchr(txtname.Text) & "'" &
                    " , '" & .cchr(txtname2.Text) & "'" &
                    " , '" & usename & "'" &
                    " , '" & usename2 & "'" &
                    " , '" & Mid(txtcode.Text, 1, 1) & "'" &
                    " , '" & cmbcoatype.SelectedValue & "'" &
                    " , '" & .cnum(lblidmcoa.Text) & "'" &
                    " , '" & .cchr(cmbactive.SelectedValue) & "'" &
                    " , '" & .cnum(cmbdc.SelectedValue) & "'" &
                    " , '" & .cchr(cmbrpttype.SelectedValue) & "'" &
                    " , '" & .cchr(txtrptcattype.Text) & "'" &
                    " , '" & .cchr(txtrptcattype2.Text) & "'" &
                    " , '" & .cchr(cmbcurr.SelectedValue) & "'" &
                    " , '" & control & "'" &
                    " , '" & cashbank & "'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        " ")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Save CoA : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then

                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT CanUpdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mcoa'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'

                Dim tny As Integer
                tny = .msgYesNo("Update COA " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                      "EXEC smcoa " &
                    " '" & .cchr(txtcode.Text) & "'" &
                    " , '" & .cchr(txtname.Text) & "'" &
                    " , '" & .cchr(txtname2.Text) & "'" &
                    " , '" & usename & "'" &
                    " , '" & usename2 & "'" &
                    " , '" & Mid(txtcode.Text, 1, 1) & "'" &
                    " , '" & cmbcoatype.SelectedValue & "'" &
                    " , '" & .cnum(lblidmcoa.Text) & "'" &
                    " , '" & .cchr(cmbactive.SelectedValue) & "'" &
                    " , '" & .cnum(cmbdc.SelectedValue) & "'" &
                    " , '" & .cchr(cmbrpttype.SelectedValue) & "'" &
                    " , '" & .cchr(txtrptcattype.Text) & "'" &
                    " , '" & .cchr(txtrptcattype2.Text) & "'" &
                    " , '" & .cchr(cmbcurr.SelectedValue) & "'" &
                    " , '" & control & "'" &
                    " , '" & cashbank & "'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                    " , 'upd'" &
                    " , '" & idmaster & "'" &
                    " ")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Update COA : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnlist_Click(sender As Object, e As EventArgs) Handles btnlist.Click
        Dim a As New search
        Dim sqlStr As String =
            "SELECT * " &
            " FROM mcoa WHERE tstatus = 1 "

        With a.dgview : .DataSource = cl.table(sqlStr & " ORDER BY code ASC")
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("name2").Visible = True : .Columns("name2").HeaderText = "Nama Lain"
            .Columns("active").Visible = True : .Columns("active").HeaderText = "Aktif"
            .Columns("rptcattype").Visible = True : .Columns("rptcattype").HeaderText = "Grouping"
        End With

        a.loadStatusTempForm(Me, Me.txtname, Me.txtname, "[mcoa]mcoa")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Search : Chart of Account"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        With cl

            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT CanDelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mcoa'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            Dim tny As Integer
            tny = .msgYesNo("Delete CoA : " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                      "EXEC smcoa " &
                    " '" & .cchr(txtcode.Text) & "'" &
                    " , '" & .cchr(txtname.Text) & "'" &
                    " , '" & .cchr(txtname2.Text) & "'" &
                    " , ''" &
                    " , ''" &
                    " , '" & Mid(txtcode.Text, 1, 1) & "'" &
                    " , '" & cmbcoatype.SelectedValue & "'" &
                    " , '" & .cnum(lblidmcoa.Text) & "'" &
                    " , '" & .cchr(cmbactive.SelectedValue) & "'" &
                    " , '" & .cnum(cmbdc.SelectedValue) & "'" &
                    " , '" & .cchr(cmbrpttype.SelectedValue) & "'" &
                    " , '" & .cchr(txtrptcattype.Text) & "'" &
                    " , '" & .cchr(txtrptcattype2.Text) & "'" &
                    " , '" & .cchr(cmbcurr.SelectedValue) & "'" &
                    " , ''" &
                    " , ''" &
                        " , ''" &
                        " , '" & idusr & "'" &
                    " , 'del'" &
                    " , '" & idmaster & "'" &
                    " ")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Delete Chart of Accounts : " & txtname.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnbrowsecoa_Click(sender As Object, e As EventArgs) Handles btnbrowsecoa.Click
        Dim a As New search
        Dim sqlStr As String =
            "SELECT id, name, code FROM mcoa WHERE tstatus = 1 AND active = 'N'"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mcoa, Me.txtname_mcoa, "[mcoap]mcoa")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Chart of Accounts"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub txtactive_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub chusename_CheckedChanged(sender As Object, e As EventArgs) Handles chusename.CheckedChanged
        If chusename.Checked = True Then
            chusename2.Checked = False
            chusename2.Enabled = False
        Else
            chusename2.Enabled = True
        End If
    End Sub

    Private Sub chusename2_CheckedChanged(sender As Object, e As EventArgs) Handles chusename2.CheckedChanged
        If chusename2.Checked = True Then
            chusename.Checked = False
            chusename.Enabled = False
        Else
            chusename.Enabled = True
        End If
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New mcoa
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub cmbrpttype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbrpttype.SelectedIndexChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub loadTview()
        COATView.Nodes.Clear()
        Dim tM As DataTable = cl.table(
            "SELECT Id, code, name FROM mcoa WHERE id_mcoap = 0 AND tstatus = 1 ORDER BY code"
            )
        Dim tD As DataTable = cl.table(
            "SELECT Id, id_mcoap, code, name FROM mcoa WHERE id_mcoap <> 0 AND tstatus = 1 ORDER BY code  "
            )

        For i As Integer = 0 To tM.Rows.Count - 1
            COATView.Nodes.Add(tM.Rows(i).Item("Id"), tM.Rows(i).Item("code") & " - " & tM.Rows(i).Item("name"))
            For j As Integer = 0 To tD.Rows.Count - 1
                If tM.Rows(i).Item("Id") = tD.Rows(j).Item("id_mcoap") Then
                    COATView.Nodes("" & tM.Rows(i).Item("Id") & "").Nodes _
                        .Add(tD.Rows(j).Item("Id"), tD.Rows(j).Item("code") & " - " & tD.Rows(j).Item("name"))
                    For k As Integer = 0 To tD.Rows.Count - 1
                        If tD.Rows(j).Item("Id") = tD.Rows(k).Item("id_mcoap") Then
                            COATView.Nodes("" & tM.Rows(i).Item("Id") & "") _
                                .Nodes("" & tD.Rows(j).Item("Id") & "").Nodes _
                                .Add(tD.Rows(k).Item("Id"), tD.Rows(k).Item("code") & " - " & tD.Rows(k).Item("name"))
                            For l As Integer = 0 To tD.Rows.Count - 1
                                If tD.Rows(k).Item("Id") = tD.Rows(l).Item("id_mcoap") Then
                                    COATView.Nodes("" & tM.Rows(i).Item("Id") & "") _
                                        .Nodes("" & tD.Rows(j).Item("Id") & "") _
                                        .Nodes("" & tD.Rows(k).Item("Id") & "").Nodes _
                                        .Add(tD.Rows(l).Item("Id"), tD.Rows(l).Item("code") & "-" & tD.Rows(l).Item("name"))
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next
        COATView.ExpandAll()
    End Sub

    Private Sub cmbrpttype_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbrpttype.SelectedValueChanged

    End Sub

    Private Sub cmbrpttype_LostFocus(sender As Object, e As EventArgs) Handles cmbrpttype.LostFocus
        Dim dtemptp3 As DataTable = cl.table(
         "SELECT id AS 'value', name AS 'display'  " &
         " FROM mcoatype WHERE tstatus = 1 AND rpttype = '" & cmbrpttype.SelectedValue & "' ")

        cmbcoatype.DataSource = dtemptp3
        cmbcoatype.ValueMember = "value"
        cmbcoatype.DisplayMember = "display"
    End Sub
End Class