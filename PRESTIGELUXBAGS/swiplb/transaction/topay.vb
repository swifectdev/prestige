Imports CrystalDecisions.CrystalReports.Engine
Public Class topay
    Dim idmaster As Integer = 0, statform As String = "", createuser As String = ""
    Private compid As String = cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'")
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
            btnprint.PerformClick()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub

    Public Sub getiduser(ByVal userid As String)
        createuser = userid
    End Sub

    Private Sub gencode()
        txtno.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('topay','" & Format(CDate(dttdt.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")
    End Sub

    Private Sub initializedg()

        'deklarasi jumlah datagrid kolom
        dgview.ColumnCount = 2
        dgview.ColumnHeadersVisible = True

        'untuk melakukan konfigurasi style dari kolo header 
        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        dgview.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        dgview.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        'setting nama kolom datagrid
        With dgview
            .Columns(0).Name = "dsc" : .Columns(0).HeaderText = "Deskripsi"
            .Columns(1).Name = "total" : .Columns(1).HeaderText = "Total"

        End With
        adjcolumn()
    End Sub

    Private Sub adjcolumn()
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("dsc").Width = 80
            .Columns("total").Width = 150

            .Columns("total").DefaultCellStyle.Format = "n2"

            .Columns("dsc").DefaultCellStyle.BackColor = Color.PaleGreen
            .Columns("total").DefaultCellStyle.BackColor = Color.PaleGreen

        End With

    End Sub

    Private Sub clearData()
        txtno.Text = ""

        dttdt.Value = Now()
        txtname_mcoa.Text = ""
        txtnote.Text = ""
        lblcode_maccount.Text = ""
        txttotal.Text = 0

        txttotal.Text = 0
        cmbpaytp.SelectedIndex = 1
        dgview.Rows.Clear()
    End Sub


    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform

        If tstatform = "new" Then
            clearData()
            initializedg()
            '    initializedg2()
            '   loadcmb()
            gencode()
            btnsave.Text = "Save"

            btndelete.Visible = False
            btnprint.Visible = False
            ' btnpost.Visible = False
        ElseIf tstatform = "upd" Then
            btnsave.Text = "Update"
            btndelete.Visible = True
            btnprint.Visible = True
            ' btnclose.Visible = True
            ' btnpost.Visible = True
        End If

        Me.Select()
    End Sub

    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub

    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
        Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString

        If colname = "total" Then
            If cl.cchr(dgview.Rows(dgview.CurrentRow.Index).Cells("dsc").Value) = "" Then
                e.KeyChar = ""
            Else
                If Not (e.KeyChar = "." And InStr(strval, ".") = 0) Then
                    If InStr("0123456789", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                        e.KeyChar = ""
                    End If
                End If
            End If

        ElseIf colname <> "total" And colname <> "dsc" Then
            e.KeyChar = ""
        End If
    End Sub
    Dim statloadform As Integer = 0

    Private Sub tgi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cultureSet()
        changestatform("new")
        statloadform = 1
    End Sub

    Private Sub tinvoicetax_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select()
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        With cl

            '------ start validasi
            If lblcode_maccount.Text = "" Then
                .msgError("Mohon untuk isi Account !", "Informasi")
                Exit Sub
            End If

            If .cnum(txttotal.Text) = 0 Then
                .msgError("Mohon untuk isi total !", "Informasi")
                Exit Sub
            End If

            If validatedgnull(dgview, "dsc", "Data Grid tidak boleh Kosong !", "Informasi Peringatan", "CHR") = 1 Then : Exit Sub : End If
            '------ end validasi

            If btnsave.Text = "Save" Then

                '---VALIDATE CANNOT HAVE DUPLICATE NUMBER !
                If .readData("SELECT COUNT(id) FROM topay WHERE no = '" & txtno.Text & "' AND tstatus = 1") > 0 Then
                    cl.msgError("Sudah ada nomor yang sama, mohon untuk check kembali", "Informasi")
                    Exit Sub
                End If

                'Dim tny As Integer
                'tny = .msgYesNo("Apakah anda mau menyimpan dokumen Sales Order : " & txtsno.Text & " ?", "Konfirmasi")
                'If tny = vbYes Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'topay'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim getlastno As String
                getlastno = cl.readData("SELECT dbo.fgetcode('topay','" & Format(dttdt.Value, "yyyyMMdd") & "')")


                .openTrans()

                .execCmdTrans(
                        "EXEC stopay " &
                        " '" & txtno.Text & "'" &
                        " , " & .cdt(dttdt) & "" &
                        " , '" & .cchr(cmbpaytp.Text) & "'" &
                        " , '" & .cchr(lblcode_maccount.Text) & "'" &
                        " , '" & .cnum(txttotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '" & idmaster & "'" &
                        "")

                For i As Integer = 0 To dgview.Rows.Count - 1
                    If .cchr(dgview.Rows(i).Cells("dsc").Value) <> "" Then
                        .execCmdTrans(
                            "EXEC stopayd " &
                            " '" & txtno.Text & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("dsc").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("total").Value) & "'" &
                            " , ''" &
                            " , '" & idusr & "'" &
                            " , 'new'" &
                            " , '" & idmaster & "'" &
                            "")

                        ' .execCmdTrans("UPDATE mitm SET stock = IFNULL(stock,0) + '" & .cNum(dgview.Rows(i).Cells("qty").Value) & "' WHERE id = '" & .cNum(dgview.Rows(i).Cells("id_mitem").Value) & "' AND tstatus = 1 ")
                    End If
                Next

                'If cl.getDataTrans("SELECT strvl FROM csetting WHERE name = 'autopost'") = "Y" And cl.getDataTrans("SELECT intvl FROM caccount WHERE name = 'CYP'") = Year(dttdt.Value) Then
                '    .execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYK'")
                '    .execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYM'")

                '    If cmbpaytp.SelectedValue = "UANG KELUAR" Then
                '        .execCmdTrans(
                '         "EXEC stopayj 'I', '" & .getDataTrans("SELECT TOP 1 id FROM topay ORDER BY id DESC") & "', '" & idusr & "'")
                '    ElseIf cmbpaytp.SelectedValue = "UANG MASUK" Then
                '        .execCmdTrans(
                '         "EXEC stopayj2 'I', '" & .getDataTrans("SELECT TOP 1 id FROM topay ORDER BY id DESC") & "', '" & idusr & "'")
                '    End If
                'End If

                .closeTrans(btnsave)

                If .sCloseTrans = 1 Then
                    .msgInform("Sukses menyimpan dokumen Voucher Pembayaran : " & txtno.Text & " !", "Informasi")
                    'idmaster = .readData("SELECT  id FROM topay WHERE tstatus = 1 and usin = '" & idusr & "' order by id desc limit 1 ")
                    'printdata()

                    changestatform("new") : End If
                ' End If
            ElseIf btnsave.Text = "Update" Then
                'Dim tny As Integer
                'tny = .msgYesNo("Apakah anda mau update dokumen Sales Order : " & txtno.Text & " ?", "Konfirmasi")
                'If tny = vbYes Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'topay'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'

                .openTrans()

                .execCmdTrans(
                        "EXEC stopay " &
                        " '" & txtno.Text & "'" &
                        " , " & .cdt(dttdt) & "" &
                        " , '" & .cchr(cmbpaytp.Text) & "'" &
                        " , '" & .cchr(lblcode_maccount.Text) & "'" &
                        " , '" & .cnum(txttotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        "")

                For i As Integer = 0 To dgview.Rows.Count - 1
                    If .cchr(dgview.Rows(i).Cells("dsc").Value) <> "" Then
                        .execCmdTrans(
                             "EXEC stopayd " &
                            " '" & txtno.Text & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("dsc").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("total").Value) & "'" &
                            " , ''" &
                            " , '" & idusr & "'" &
                            " , 'upd'" &
                            " , '" & idmaster & "'" &
                            "")
                    End If
                Next


                'If cl.getDataTrans("SELECT strvl FROM csetting WHERE name = 'autopost'") = "Y" And cl.getDataTrans("SELECT intvl FROM caccount WHERE name = 'CYP'") = Year(dttdt.Value) Then
                '    .execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYK'")
                '    .execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYM'")

                '    If cmbpaytp.SelectedValue = "UANG KELUAR" Then
                '        .execCmdTrans(
                '         "EXEC stopayj 'I', '" & idmaster & "', '" & idusr & "'")
                '    ElseIf cmbpaytp.SelectedValue = "UANG MASUK" Then
                '        .execCmdTrans(
                '         "EXEC stopayj2 'I', '" & idmaster & "', '" & idusr & "'")
                '    End If
                'End If

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Update Voucher Pembayaran : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
            ' End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New topay
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sqlwhere As String = ""

        Dim sqlStr As String = "SELECT * from topay where tstatus = 1 " & sqlwhere

        With a.dgview : .DataSource = cl.table(sqlStr & " order by tdate DESC")
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No. Doc"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Date"
            .Columns("jenis").Visible = True : .Columns("jenis").HeaderText = "Type"
            .Columns("code_maccount").Visible = True : .Columns("code_maccount").HeaderText = "Account"
            .Columns("note").Visible = True : .Columns("note").HeaderText = "Deskripsi"
            .Columns("total").Visible = True : .Columns("total").HeaderText = "Total" : .Columns("total").DefaultCellStyle.Format = "n2"
        End With

        a.loadStatusTempForm(Me, Me.btnlist, "[topay]topay")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Voucher Pembayaran"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'topay'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            ''CHECK CANNOT UPDATE DOCUMENT ALREADY EXISTS
            'If .readData("SELECT COUNT(id) FROM trec WHERE tstatus = 1 AND id_topay = '" & idmaster & "'") > 0 Then
            '    .msgError("Tidak bisa hapus PO, sudah ada Penerimaan aktif !", "Informasi")
            '    Exit Sub
            'End If

            Dim tny As Integer
            tny = .msgYesNo("Apakah anda mau menghapus Voucher Pembayaran : " & txtno.Text & " ?", "Konfirmasi")
            If tny = vbYes Then
                .openTrans()

                .execCmdTrans(
                       "EXEC stopay " &
                        " '" & txtno.Text & "'" &
                        " , " & .cdt(dttdt) & "" &
                        " , '" & .cchr(cmbpaytp.Text) & "'" &
                        " , '" & .cchr(lblcode_maccount.Text) & "'" &
                        " , '" & .cnum(txttotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")

                '.execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYK'")
                '.execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYK'")

                '.execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYM'")
                '.execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'OPYM'")

                'For i As Integer = 0 To dgview2.Rows.Count - 1
                '    '----UNDO STOCK
                '    .execCmdTrans("UPDATE mitm SET stock = IFNULL(stock,0) - '" & .cNum(dgview2.Rows(i).Cells("qty").Value) & "' WHERE id = '" & .cNum(dgview2.Rows(i).Cells("id_mitem").Value) & "' AND tstatus = 1 ")
                'Next

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Sukses menghapus Voucher Pembayaran : " & txtno.Text & " !", "Informasi")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        With cl
            Dim tny As Integer
            tny = .msgYesNo("Exit dari " & Me.Text & " ?", "Konfirmasi")
            If tny = vbYes Then
                Me.Dispose()
            End If
        End With
    End Sub


    Private Sub printdata()
        With cl
            Try
                '------PRINT INVOICE
                '  MsgBox(idmaster)
                Dim rpt As New ReportDocument
                Dim f As New print

                If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                    If cmbpaytp.SelectedValue = "UANG KELUAR" Then
                        rpt.Load(direcCetakan & "\PYRCVoucherCashKELUAR.rpt")
                    ElseIf cmbpaytp.SelectedValue = "UANG MASUK" Then
                        rpt.Load(direcCetakan & "\PYRCVoucherCashMSK.rpt")
                    End If
                End If

                rpt.SetDataSource(cl.table(
         " SELECT * FROM vtopayDRCR " &
         " WHERE id = '" & idmaster & "' " &
         " "))

                If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                    If cmbpaytp.Text = "IN" Then
                        rpt.SetParameterValue("type", "RECEIVED")
                    Else
                        rpt.SetParameterValue("type", "PAYMENT")
                    End If
                End If

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With

    End Sub

    Private Sub dgview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellContentClick

    End Sub

    Private Sub dgDetail_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgview.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgview.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture) + 1,
                                   dgview.DefaultCellStyle.Font,
                                   b,
                                   e.RowBounds.Location.X + 10,
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgview_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgview.CellBeginEdit

    End Sub

    Public Sub getcalculate()

        Dim totaldetail As Decimal = 0

        With dgview
            For a As Integer = 0 To .Rows.Count - 1
                If cl.cchr(.Rows(a).Cells("dsc").Value) <> "" Then
                    ' .Rows(a).Cells("price").Value = cl.cCur(.Rows(a).Cells("price").Value)
                    .Rows(a).Cells("total").Value = cl.ccur(.Rows(a).Cells("total").Value)

                    totaldetail += cl.cnum(.Rows(a).Cells("total").Value)
                End If
            Next

            txttotal.Text = cl.ccur(totaldetail)

        End With
    End Sub

    'Private Sub chdisc_CheckedChanged(sender As Object, e As EventArgs)
    '    If chdisc.Checked = True Then
    '        txtdisctotal.ReadOnly = False
    '        txtdiscpcg.ReadOnly = False
    '    ElseIf chdisc.Checked = False Then
    '        txtdisctotal.ReadOnly = True
    '        txtdiscpcg.ReadOnly = True
    '        txtdisctotal.Text = 0
    '        txtdiscpcg.Text = 0
    '    End If
    'End Sub



    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        printdata()
    End Sub

    'Private Sub dttdt_GotFocus(sender As Object, e As EventArgs)
    '    dttdt.SelectAll()
    'End Sub

    'Private Sub dttdt2_GotFocus(sender As Object, e As EventArgs)
    '    dttdt2.SelectAll()
    'End Sub

    Private Sub dgview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellEndEdit
        getcalculate()
    End Sub

    Private Sub btncoa_Click(sender As Object, e As EventArgs) Handles btncoa.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM maccount WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Name"
        End With

        a.loadStatusTempForm(Me, Me.txtno, "[maccount]topay")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Rekening"

        cekform(a, "SEARCH", Me)
    End Sub


    Private Sub dgview_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgview.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgview.CurrentRow.Index <> dgview.Rows.Count - 1 Then
                dgview.Rows.RemoveAt(dgview.CurrentRow.Index)
                getcalculate()
            End If
        End If

    End Sub

    'Private Sub btnclose_Click(sender As Object, e As EventArgs)
    '    With cl
    '        If cl.readData("SELECT IFNULL(closed,'N') FROM topay WHERE id = '" & idmaster & "' AND tstatus = 1") = "Y" Or
    '            lblprocess.Text = "Received" Then
    '            .msgError("PO sudah closed atau sudah di terima !", "Informasi")
    '            Exit Sub
    '        End If

    '        Dim tny As Integer
    '        tny = .msgYesNo("Close Purchase Order : " & txtno.Text & " ?", "Konfirmasi")
    '        If tny = vbYes Then
    '            .openTrans()

    '            .execCmdTrans(
    '                "UPDATE topay SET closed = 'Y' WHERE id = '" & idmaster & "'" &
    '                "")

    '            .closeTrans(btnsave)
    '            If .sCloseTrans = 1 Then
    '                .msgInform("Sukses Close Purchase Order : " & txtno.Text & " !", "Informasi")
    '                changestatform("new") : End If
    '        End If
    '    End With
    'End Sub

End Class