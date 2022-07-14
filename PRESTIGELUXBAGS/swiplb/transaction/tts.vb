Imports CrystalDecisions.CrystalReports.Engine
Public Class tts
    Dim idmaster As Integer = 0, statform As String = ""
    '  Private compid As String = cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'")
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

    Private Sub gencode()
        txtno.Text = cl.readData("SELECT dbo.fgetcode('tts','" & Format(CDate(dttdt.Text), "yy") & "')")
    End Sub

    Private Sub initializedg()

        Dim desc As New DataGridViewCheckBoxColumn()
        dgview.Columns.Add(desc)
        desc.Name = "paidData"
        dgview.Columns("paidData").HeaderText = "Paid"
        dgview.Columns("paidData").Visible = True

        'deklarasi jumlah datagrid kolom
        dgview.ColumnCount = 12
        dgview.ColumnHeadersVisible = True

        'untuk melakukan konfigurasi style dari kolo header 
        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        dgview.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        dgview.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        'setting nama kolom datagrid
        With dgview
            .Columns(1).Name = "no_trans" : .Columns(1).HeaderText = "No. Trans"
            .Columns(2).Name = "date_trans" : .Columns(2).HeaderText = "Tgl Beli"
            .Columns(3).Name = "vendor" : .Columns(3).HeaderText = "Vendor"
            .Columns(4).Name = "hp" : .Columns(4).HeaderText = "Phone"
            .Columns(5).Name = "code_mitem" : .Columns(5).HeaderText = "No Tag"
            .Columns(6).Name = "name_mitem" : .Columns(6).HeaderText = "Nama Barang"
            .Columns(7).Name = "total" : .Columns(7).HeaderText = "Total/Sisa Total"
            .Columns(8).Name = "paytotal" : .Columns(8).HeaderText = "Total Bayar"

            .Columns(9).Name = "id_trans" : .Columns(9).Visible = False
            .Columns(10).Name = "doctype" : .Columns(10).Visible = False
            .Columns(11).Name = "code_mvendor" : .Columns(11).Visible = False
        End With
        adjcolumn()
    End Sub

    Private Sub adjcolumn()
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("paidData").Width = 60
            .Columns("no_trans").Width = 80
            .Columns("date_trans").Width = 80
            .Columns("vendor").Width = 120
            .Columns("hp").Width = 70
            .Columns("code_mitem").Width = 80
            .Columns("name_mitem").Width = 80
            .Columns("total").Width = 100
            .Columns("paytotal").Width = 100

            .Columns("paytotal").DefaultCellStyle.Format = "n2"
            .Columns("total").DefaultCellStyle.Format = "n2"


            .Columns("paidData").DefaultCellStyle.BackColor = Color.PaleGreen
            .Columns("no_trans").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("date_trans").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("vendor").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("hp").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("code_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("name_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("total").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("paytotal").DefaultCellStyle.BackColor = Color.PaleGreen
        End With

    End Sub

    Private Sub clearData()
        ' txtno.Text = ""
        txtname_mcust.Text = ""
        lblid_mvendor.Text = ""
        lblcode_maccount.Text = ""

        dttdt.Value = Now()

        'dtfrom.Value = Now()
        'dtto.Value = Now()

        txtnote.Text = ""
        txttotal.Text = 0

        txttotalpiutang.Text = 0
        dgview.Rows.Clear()

        txtname_maccount.Text = ""

        chpayall.Checked = False
        cmbpaytp.SelectedIndex = 0
        '  dgview2.Rows.Clear()
    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform

        If tstatform = "new" Then
            ' loadcmb()
            clearData()
            initializedg()
            '   initializedg2()
            gencode()
            btnsave.Text = "Save"

            btndelete.Visible = False
            btnprint.Visible = False
            '   btnpost.Visible = False
            '  lbluseractivity.Visible = False
            txtno.ReadOnly = False

        ElseIf tstatform = "upd" Then
            btnsave.Text = "Update"
            btndelete.Visible = True
            btnprint.Visible = True
            '  btnpost.Visible = True
            lbluseractivity.Visible = True
            txtno.ReadOnly = False
        End If

        Me.Select()
    End Sub



    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub

    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
        Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString

        If colname = "paytotal" Then
            If cl.cchr(dgview.Rows(dgview.CurrentRow.Index).Cells("no_trans").Value) = "" Then
                e.KeyChar = ""
            Else
                If Not (e.KeyChar = "." And InStr((strval), ".") = 0) And Not (e.KeyChar = "-" And InStr((strval), "-") = 0) Then
                    If InStr(("0123456789"), e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                        e.KeyChar = ""
                    End If
                End If
            End If

        ElseIf colname <> "paytotal" Then
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
            If lblid_mvendor.Text = "" Then
                .msgInform("Mohon untuk isi customer !", "Informasi")
                Exit Sub
            End If

            If lblcode_maccount.Text = "" Then
                .msgInform("Mohon untuk isi Rekening !", "Informasi")
                Exit Sub
            End If

            '-- NO FUTURE POSTING DATE --'
            If dttdt.Value > Now() Then
                .msgError("Tanggal tidak bisa tanggal pada masa depan!", "Informasi")
                dttdt.Value = Now()
                Exit Sub
            End If

            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tts'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                '---VALIDATE CANNOT HAVE DUPLICATE NUMBER !
                If .readData("SELECT COUNT(id) FROM tts WHERE no = '" & txtno.Text & "' AND tstatus = 1") > 0 Then
                    cl.msgError("Sudah ada nomor yang sama, mohon untuk check kembali", "Informasi")
                    Exit Sub
                End If

                '---------------------END------------------------'
                'Dim tny As Integer
                'tny = .msgYesNo("Apakah anda mau menyimpan dokumen Pembayaran dari Customer : " & txtno.Text & " ?", "Konfirmasi")
                'If tny = vbYes Then
                .openTrans()

                .execCmdTrans(
                    "EXEC stts " &
                    " '" & .cchr(txtno.Text) & "'" &
                    " , " & .cdt(dttdt) & "" &
                    " , '" & .cchr(cmbpaytp.Text) & "'" &
                    " , '" & .cchr(lblid_mvendor.Text) & "'" &
                    " , '" & .cchr(lblcode_maccount.Text) & "'" &
                    " , '" & .cnum(txttotalpiutang.Text) & "'" &
                    " , '" & .cnum(txttotal.Text) & "'" &
                    " , '" & .cchr(txtnote.Text) & "'" &
                    " , '" & idusr & "'" &
                    " , 'new'" &
                    " , '" & idmaster & "'" &
                    "")

                '.Columns(1).Name = "no_trans" : .Columns(1).HeaderText = "No. Trans"
                '.Columns(2).Name = "date_trans" : .Columns(2).HeaderText = "Date"
                '.Columns(3).Name = "customer" : .Columns(3).HeaderText = "Customer/Buyer"
                '.Columns(4).Name = "hp" : .Columns(4).HeaderText = "HP"
                '.Columns(5).Name = "code_mitem" : .Columns(5).HeaderText = "No Tag"
                '.Columns(6).Name = "name_mitem" : .Columns(6).HeaderText = "Nama Barang"
                '.Columns(7).Name = "total" : .Columns(7).HeaderText = "Total"
                '.Columns(8).Name = "ongkir" : .Columns(8).HeaderText = "O. Kirim"
                '.Columns(9).Name = "paytotal" : .Columns(9).HeaderText = "Total Bayar"

                '.Columns(10).Name = "id_trans" : .Columns(10).Visible = False
                '.Columns(11).Name = "doctype" : .Columns(11).Visible = False

                For i As Integer = 0 To dgview.Rows.Count - 1
                    If .cnum(dgview.Rows(i).Cells("paytotal").Value) <> 0 Then
                        .execCmdTrans(
                            "EXEC sttsd " &
                            " '" & .cchr(txtno.Text) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("doctype").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("no_trans").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("date_trans").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("code_mvendor").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("total").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("paytotal").Value) & "'" &
                            " , ''" &
                            " , '" & idusr & "'" &
                            " , 'new'" &
                            " , '" & idmaster & "'" &
                            "")
                    End If
                Next

                'If cl.getDataTrans("SELECT strvl FROM csetting WHERE name = 'autopost'") = "Y" And
                '    cl.getDataTrans("SELECT intvl FROM caccount WHERE name = 'CYP'") = Year(dttdt.Value) And
                '    (compid <> "KRY" Or compid <> "BEI") Then
                '    .execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")
                '    .execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")

                '    .execCmdTrans(
                '        "EXEC stpsj " &
                '        "  'I'" &
                '        " ,'" & .getDataTrans("SELECT TOP 1 id FROM tpayh ORDER BY id DESC") & "'" &
                '        " , '" & idusr & "'" &
                '        "")

                '    '-- JOURNAL SELISIH KURS
                '    If cl.cnum(txtexratediff.Text) < 0 Then
                '        .execCmdTrans(
                '             "EXEC stpsskminj 'I', '" & .getDataTrans("SELECT TOP 1 id FROM tpayh ORDER BY id DESC") & "', '" & idusr & "'")
                '    ElseIf cl.cnum(txtexratediff.Text) > 0 Then
                '        .execCmdTrans(
                '             "EXEC stpsskplsj 'I', '" & .getDataTrans("SELECT TOP 1 id FROM tpayh ORDER BY id DESC") & "', '" & idusr & "'")
                '    End If
                'End If

                .closeTrans(btnsave)

                If .sCloseTrans = 1 Then
                    .msgInform("Sukses menyimpan dokumen Pembayaran dari Customer : " & txtno.Text & " !", "Informasi")
                    'idmaster = .readData("SELECT TOP 1 id FROM tgi WHERE tstatus = 1 AND invoicetp = 'T' AND createduser = '" & idusr & "' ORDER BY createddate DESC")

                    changestatform("new") : End If
                '  End If
            ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tts'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                'Dim tny As Integer
                'tny = .msgYesNo("Apakah anda mau update dokumen Pembayaran dari Customer : " & txtno.Text & " ?", "Konfirmasi")
                'If tny = vbYes Then
                .openTrans()

                .execCmdTrans(
                    "EXEC stts " &
                    " '" & .cchr(txtno.Text) & "'" &
                    " , " & .cdt(dttdt) & "" &
                    " , '" & .cchr(cmbpaytp.Text) & "'" &
                    " , '" & .cchr(lblid_mvendor.Text) & "'" &
                    " , '" & .cchr(lblcode_maccount.Text) & "'" &
                    " , '" & .cnum(txttotalpiutang.Text) & "'" &
                    " , '" & .cnum(txttotal.Text) & "'" &
                    " , '" & .cchr(txtnote.Text) & "'" &
                    " , '" & idusr & "'" &
                    " , 'upd'" &
                    " , '" & idmaster & "'" &
                    "")

                For i As Integer = 0 To dgview.Rows.Count - 1
                    If .cnum(dgview.Rows(i).Cells("paytotal").Value) <> 0 Then
                        .execCmdTrans(
                          "EXEC sttsd " &
                            " '" & .cchr(txtno.Text) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("doctype").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("no_trans").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("date_trans").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("code_mvendor").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("ongkir").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("total").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("paytotal").Value) & "'" &
                            " , ''" &
                            " , '" & idusr & "'" &
                            " , 'new'" &
                            " , '" & idmaster & "'" &
                            "")
                    End If
                Next

                'If cl.getDataTrans("SELECT strvl FROM csetting WHERE name = 'autopost'") = "Y" And
                '    cl.getDataTrans("SELECT intvl FROM caccount WHERE name = 'CYP'") = Year(dttdt.Value) And
                '    (compid <> "KRY" Or compid <> "BEI") Then

                '    .execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")
                '    .execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")

                '    .execCmdTrans(
                '        "EXEC stpsj " &
                '        "  'I'" &
                '        " , '" & idmaster & "'" &
                '        " , '" & idusr & "'" &
                '        "")

                '    '-- JOURNAL SELISIH KURS
                '    If cl.cnum(txtexratediff.Text) < 0 Then
                '        .execCmdTrans(
                '             "EXEC stpsskminj 'I', '" & idmaster & "', '" & idusr & "'")
                '    ElseIf cl.cnum(txtexratediff.Text) > 0 Then
                '        .execCmdTrans(
                '             "EXEC stpsskplsj 'I', '" & idmaster & "', '" & idusr & "'")
                '    End If

                'End If

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Update Pembayaran dari Customer : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
            'End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New tts
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch
        Dim sqlStr As String

        Dim sqlwhere As String = ""
        If chfilterdt.Checked = True Then
            sqlwhere &= " AND MONTH(T0.tdate) = '" & Month(dttdt.Text) & "' AND YEAR(T0.tdate) = '" & Year(dttdt.Text) & "'"
        End If

        sqlStr =
            "SELECT T0.* " &
            " FROM tts T0 WHERE T0.tstatus = 1 " & sqlwhere

        With a.dgview : .DataSource = cl.table(sqlStr & " order by tdate DESC")
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No. Doc"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl Byr"
            .Columns("paytype").Visible = True : .Columns("paytype").HeaderText = "Tipe Byr"
            .Columns("code_mvendor").Visible = True : .Columns("code_mvendor").HeaderText = "Vendor"
            .Columns("code_maccount").Visible = True : .Columns("code_maccount").HeaderText = "Rekening"
            .Columns("total").Visible = True : .Columns("total").HeaderText = "Total" : .Columns("total").DefaultCellStyle.Format = "n2"

        End With

        a.loadStatusTempForm(Me, Me.btnlist, "[tts]tts")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Payment dari Vendor"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tts'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'
            Dim tny As Integer
            tny = .msgYesNo("Apakah anda mau menghapus Payment ke Vendor : " & txtno.Text & " ?", "Konfirmasi")
            If tny = vbYes Then
                .openTrans()

                .execCmdTrans(
                    "EXEC stts " &
                    " '" & .cchr(txtno.Text) & "'" &
                    " , " & .cdt(dttdt) & "" &
                    " , '" & .cchr(cmbpaytp.Text) & "'" &
                    " , '" & .cchr(lblid_mvendor.Text) & "'" &
                    " , '" & .cchr(lblcode_maccount.Text) & "'" &
                    " , '" & .cnum(txttotalpiutang.Text) & "'" &
                    " , '" & .cnum(txttotal.Text) & "'" &
                    " , '" & .cchr(txtnote.Text) & "'" &
                    " , '" & idusr & "'" &
                    " , 'del'" &
                    " , '" & idmaster & "'" &
                    "")

                '.execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")
                '.execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE id_source = '" & idmaster & "' AND refno = 'TPY'")

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Sukses menghapus Payment dari Vendor : " & txtno.Text & " !", "Informasi")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub printdata()
        'Try
        '    Dim rpt As New ReportDocument
        '    Dim f As New print
        '    rpt = New crinvoice

        '    If btnsave.Text = "Save" Then
        '        rpt.SetDataSource(cl.table(
        '       " SELECT * FROM vinvoice WHERE id = (SELECT TOP 1 id FROM vinvoice ORDER BY id DESC)" & _
        '       " "))
        '    ElseIf btnsave.Text = "Update" Then
        '        rpt.SetDataSource(cl.table(
        '       " SELECT * FROM vinvoice WHERE id = '" & idmaster & "' " & _
        '       " "))
        '    End If

        '    f.crv.ReportSource = rpt
        '    f.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '    cekform(f, "NEW", Me)

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnprint_Click(sender As System.Object, e As System.EventArgs) Handles btnprint.Click
        With cl
            Try
                Dim rpt As New ReportDocument
                Dim f As New print

                '    If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                '        rpt.Load(direcCetakan & "\PYRCVoucherCashMSKPFC.rpt")

                '        rpt.SetDataSource(cl.table(
                '" SELECT * FROM vtpsDRCR " &
                '" WHERE id = '" & idmaster & "' " &
                '" "))

                '        ' rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))

                '        f.crv.ReportSource = rpt
                '        cekform(f, "NEW", Me)
                '        Exit Sub
                '    Else
                '        rpt = New rpttps
                '    End If

                rpt.SetDataSource(cl.table(
             " SELECT * FROM vtpsDRCR " &
             " WHERE id = '" & idmaster & "' " &
             " "))

                ' rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub dgview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellContentClick

    End Sub

    Public Sub getcalculate()
        Dim subtotal As Decimal = 0
        Dim grdtotal As Decimal = 0
        Dim grdtotal2 As Decimal = 0
        Dim grdtotal3 As Decimal = 0

        With dgview
            For a As Integer = 0 To .Rows.Count - 1
                If cl.cnum(.Rows(a).Cells("paidData").Value) = vbTrue Then

                    '.Columns(1).Name = "no_trans" : .Columns(1).HeaderText = "No. Trans"
                    '.Columns(2).Name = "date_trans" : .Columns(2).HeaderText = "Date"
                    '.Columns(3).Name = "customer" : .Columns(3).HeaderText = "Customer/Buyer"
                    '.Columns(4).Name = "hp" : .Columns(4).HeaderText = "HP"
                    '.Columns(5).Name = "code_mitem" : .Columns(5).HeaderText = "No Tag"
                    '.Columns(6).Name = "name_mitem" : .Columns(6).HeaderText = "Nama Barang"
                    '.Columns(7).Name = "total" : .Columns(7).HeaderText = "Total"
                    '.Columns(8).Name = "ongkir" : .Columns(8).HeaderText = "O. Kirim"
                    '.Columns(9).Name = "paytotal" : .Columns(9).HeaderText = "Total Bayar"

                    '.Columns(10).Name = "id_trans" : .Columns(10).Visible = False
                    '.Columns(11).Name = "doctype" : .Columns(11).Visible = False

                    '    .Rows(a).Cells("ongkir").Value = cl.ccur(.Rows(a).Cells("ongkir").Value)
                    .Rows(a).Cells("total").Value = cl.ccur(.Rows(a).Cells("total").Value)
                    .Rows(a).Cells("paytotal").Value = cl.ccur(.Rows(a).Cells("paytotal").Value)

                    grdtotal += cl.cnum(.Rows(a).Cells("total").Value)
                    ' grdtotal2 += cl.cnum(.Rows(a).Cells("ongkir").Value)
                    grdtotal3 += cl.cnum(.Rows(a).Cells("paytotal").Value)

                End If
            Next
            'MsgBox(grdtotal2)
            'txtongkir.Text = cl.ccur(Math.Floor(grdtotal2))
            txttotalpiutang.Text = cl.ccur(Math.Floor(grdtotal))
            txttotal.Text = cl.ccur(Math.Floor(grdtotal3))

        End With
    End Sub

    Private Sub btnbrowsecust_Click(sender As Object, e As EventArgs) Handles btnbrowsecust.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM mvendor WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("phone").Visible = True : .Columns("phone").HeaderText = "Phone "
            .Columns("norek").Visible = True : .Columns("norek").HeaderText = "Rekening"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mcust, "[mvendor]tts")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Vendor"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub dgview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellEndEdit

        'If dgview.Item("paidData", dgview.CurrentRow.Index).Value = True Then
        '    dgview.Item("paytotal", dgview.CurrentRow.Index).Value = cl.ccur(dgview.Item("total", dgview.CurrentRow.Index).Value)
        'ElseIf dgview.Item("paidData", dgview.CurrentRow.Index).Value = False Then
        '    dgview.Item("paytotal", dgview.CurrentRow.Index).Value = 0
        'End If


        If dgview.Item("paytotal", dgview.CurrentRow.Index).Value > dgview.Item("total", dgview.CurrentRow.Index).Value Then
            cl.msgError("Pembayaran tidak boleh melebihi Total harga Vendor !", "Informasi")
            dgview.Item("paytotal", dgview.CurrentRow.Index).Value = 0
            Exit Sub
        End If

        getcalculate()

        ''-- GET ALL THE NOTES FROM THE TABLE
        'Dim s As String = ""
        'Dim lastRow As Integer
        'For v As Integer = 0 To dgview.Rows.Count - 1
        '    If dgview.Item("paidData", v).Value = True Then
        '        lastRow = v
        '    End If
        'Next
        'For b As Integer = 0 To dgview.Rows.Count - 1

        '    If dgview.Item("paidData", b).Value = True And dgview.Item("note", b).Value <> "" Then
        '        If b = lastRow Then
        '            s += "'" & dgview.Item("note", b).Value & "'"
        '        Else
        '            s += "'" & dgview.Item("note", b).Value & "',"
        '        End If
        '    End If
        '    ' MsgBox(s)
        'Next
        'txtnote.Text = ""
        'Dim value2 As String = s.Replace("'", "")
        'txtnote.Text = value2
    End Sub

    Public Sub getOutstandingInvoice()
        'Dim dttable As DataTable = cl.table(
        '"SELECT T0.id, T0.no, T0.tdt, T0.refno, T2.name AS 'name_mcust', T0.grdtotal 'total', " &
        '" SUM(T0.grdtotal)-ISNULL(SUM(T3.paytotal),0)-ISNULL((SELECT SUM(payment) FROM tpayd TX WHERE TX.idtrans = T0.id AND TX.tstatus = 1),0)-  " &
        '" ISNULL((SELECT SUM(grdtotal*-1) FROM treth TY WHERE TY.id_tsalh = T0.id AND TY.tstatus = 1),0) 'sisatotal' " &
        '" FROM tsalh T0 INNER JOIN tsald T1 ON T0.id = T1.id_tsalh " &
        '" LEFT JOIN tsalp T3 ON T0.id = T3.id_tsalh " &
        '" INNER JOIN mbp T2 ON T0.id_mcust = T2.id " &
        '" WHERE T0.tstatus = 1 AND T1.tstatus = 1  AND T0.id_mcust = '" & cl.cNum(lblid_mcust.Text) & "' " &
        '" GROUP BY T0.id, T0.no, T0.tdt, T0.refno,T2.name, T0.grdtotal  " &
        '" HAVING SUM(T0.grdtotal)-ISNULL(SUM(T3.paytotal),0)-ISNULL((SELECT SUM(payment) FROM tpayd TX WHERE TX.idtrans = T0.id AND TX.tstatus = 1),0)- " &
        '" ISNULL((SELECT SUM(grdtotal*-1) FROM treth TY WHERE TY.id_tsalh = T0.id AND TY.tstatus = 1),0) > 0")

        '.Columns(1).Name = "no_trans" : .Columns(1).HeaderText = "No. Trans"
        '.Columns(2).Name = "date_trans" : .Columns(2).HeaderText = "Date"
        '.Columns(3).Name = "customer" : .Columns(3).HeaderText = "Customer/Buyer"
        '.Columns(4).Name = "hp" : .Columns(4).HeaderText = "HP"
        '.Columns(5).Name = "code_mitem" : .Columns(5).HeaderText = "No Tag"
        '.Columns(6).Name = "name_mitem" : .Columns(6).HeaderText = "Nama Barang"
        '.Columns(7).Name = "total" : .Columns(7).HeaderText = "Total"
        '.Columns(8).Name = "ongkir" : .Columns(8).HeaderText = "O. Kirim"
        '.Columns(9).Name = "paytotal" : .Columns(9).HeaderText = "Total Bayar"

        '.Columns(10).Name = "id_trans" : .Columns(10).Visible = False
        '.Columns(11).Name = "doctype" : .Columns(11).Visible = False

        Dim dttable As DataTable = cl.table(
        "SELECT T0.no, T0.tdate, T0.name_mvendor, T0.hp1, T0.code_mitem, T1.name 'name_mitem', T0.hrgjual 'total', T0.id 'idtrans', 'VND' 'doctype', T0.code_mvendor FROM tpop T0 " &
        "INNER JOIN mitem T1 On T0.code_mitem = T1.code WHERE T0.tstatus = 1 And T1.tstatus = 1 AND T0.code_mvendor = '" & lblid_mvendor.Text & "' AND T0.hrgbeli - dbo.fcgetpayvend(T0.no) <> 0")

        If dttable.Rows.Count = 0 Then
            cl.msgError("Tidak ada Invoice outstanding !", "Information")
            lblid_mvendor.Text = 0
            txtname_mcust.Text = ""
            Exit Sub
        Else
            dgview.Rows.Clear()

            Dim rRow As Integer = 0
            For r As Integer = 0 To dttable.Rows.Count - 1
                rRow = dgview.Rows.Add

                With dttable
                    dgview.Rows(rRow).Cells("no_trans").Value = .Rows(r).Item("no")
                    dgview.Rows(rRow).Cells("date_trans").Value = cl.cchr(.Rows(r).Item("tdate"))
                    dgview.Rows(rRow).Cells("vendor").Value = cl.cchr(.Rows(r).Item("name_mvendor"))
                    dgview.Rows(rRow).Cells("hp").Value = cl.cchr(.Rows(r).Item("hp1"))
                    dgview.Rows(rRow).Cells("code_mitem").Value = cl.cchr(.Rows(r).Item("code_mitem"))
                    dgview.Rows(rRow).Cells("name_mitem").Value = cl.cchr(.Rows(r).Item("name_mitem"))
                    dgview.Rows(rRow).Cells("total").Value = cl.ccur(.Rows(r).Item("total"))
                    '  dgview.Rows(rRow).Cells("ongkir").Value = 0
                    dgview.Rows(rRow).Cells("paytotal").Value = 0
                    dgview.Rows(rRow).Cells("doctype").Value = cl.cchr(.Rows(r).Item("doctype"))
                    dgview.Rows(rRow).Cells("code_mvendor").Value = cl.cchr(.Rows(r).Item("code_mvendor"))
                    '    dgview.Rows(rRow).Cells("id_trans").Value = cl.cnum(.Rows(r).Item("idtrans"))

                End With
            Next
        End If
        getcalculate()
    End Sub

    Private Sub btnbrowsecoa_Click(sender As Object, e As EventArgs) Handles btnbrowsecoa.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM maccount WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mcust, "[maccount]tts")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Rekening"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub chpayall_CheckedChanged(sender As Object, e As EventArgs) Handles chpayall.CheckedChanged
        With dgview
            If chpayall.Checked = True Then
                For a As Integer = 0 To dgview.Rows.Count - 1
                    .Rows(a).Cells("paidData").Value = vbTrue
                Next
            ElseIf chpayall.Checked = False Then
                For a As Integer = 0 To dgview.Rows.Count - 1
                    .Rows(a).Cells("paidData").Value = vbFalse
                Next
            End If
        End With
        getcalculate()
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

    'Private Sub btnbrowsecust_Click(sender As Object, e As EventArgs) Handles btnbrowsecust.Click
    '    Dim a As New tsearch
    '    Dim sqlStr As String =
    '            "SELECT * FROM mbp WHERE tstatus = 1 and bptp = 'C'"

    '    With a.dgview : .DataSource = cl.table(sqlStr)
    '        For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
    '        .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
    '        .Columns("phn").Visible = True : .Columns("phn").HeaderText = "Phone"
    '        .Columns("alamat").Visible = True : .Columns("alamat").HeaderText = "Alamat Ship To"
    '        .Columns("alamat2").Visible = True : .Columns("alamat2").HeaderText = "Alamat Bill To"
    '    End With

    '    a.loadStatusTempForm(Me, Me.txtname_mcust, "[mbp]tps")
    '    a.loadSQLSearch(sqlStr, 1)
    '    a.Text = "Pencarian : Customer"

    '    cekform(a, "SEARCH", Me)
    'End Sub

    'Private Sub btnpost_Click(sender As Object, e As EventArgs)
    '    'JOURNAL ENTRY
    '    'DR. CASH BANK
    '    'CR. PIUTANG CUSTOMER
    '    If idmaster = 0 Then
    '        cl.msgInform("Mohon untuk pilih transaksi yang ingin di post !", "Informasi")
    '        Exit Sub
    '    End If

    '    If cl.readData("SELECT ISNULL(id_mcoa,0) FROM mbp WHERE id = '" & lblid_mcust.Text & "'") = 0 Then
    '        cl.msgInform("Akun piutang belum di set pada master data !", "Informasi")
    '        Exit Sub
    '    End If

    '    If cl.readData("SELECT intvl FROM caccount WHERE name = 'CYP'") <> Year(dttdt.Value) Then
    '        cl.msgError("Tidak bisa post, period telah terkunci !", "Informasi")
    '        Exit Sub
    '    End If

    '    With cl

    '        Dim tny As Integer
    '        tny = .msgYesNo("Post Pembayaran Customer : " & txtno.Text & " ?", "Konfirmasi")
    '        If tny = vbYes Then
    '            .openTrans()

    '            .execCmdTrans("UPDATE tje2 SET tstatus = 0 WHERE source_no = '" & txtno.Text & "' AND refno = 'TPY'")
    '            .execCmdTrans("UPDATE tjed2 SET tstatus = 0 WHERE source_no = '" & txtno.Text & "' AND refno = 'TPY'")

    '            .execCmdTrans(
    '                     "EXEC stpsj 'I', '" & idmaster & "', '" & idusr & "'")


    '            '-- JOURNAL SELISIH KURS
    '            If cl.cnum(txtexratediff.Text) < 0 Then
    '                .execCmdTrans(
    '                         "EXEC stpsskminj 'I', '" & idmaster & "', '" & idusr & "'")
    '            ElseIf cl.cnum(txtexratediff.Text) > 0 Then
    '                .execCmdTrans(
    '                         "EXEC stpsskplsj 'I', '" & idmaster & "', '" & idusr & "'")
    '            End If

    '            .closeTrans(btnsave)
    '            If .sCloseTrans = 1 Then
    '                .msgInform("Sukses Posting Journal : " & txtno.Text & " !", "Informasi")
    '                changestatform("new") : End If
    '        End If
    '    End With

    'End Sub

    'Private Sub btnbrowsecoa_Click(sender As Object, e As EventArgs) Handles btnbrowsecoa.Click
    '    Dim a As New tsearch
    '    Dim sqlstr As String =
    '        " SELECT id, name, code FROM mcoa WHERE tstatus = 1 and active = 'Y' "

    '    With a.dgview : .DataSource = cl.table(sqlstr & " ORDER BY code ASC")
    '        For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
    '        .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
    '        .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
    '    End With

    '    a.loadStatusTempForm(Me, Me.dgview, "[mcoa]tps")
    '    a.loadSQLSearch(sqlstr, 1)
    '    a.Text = "Pencarian : Chart of Accounts"

    '    cekform(a, "SEARCH", Me)
    'End Sub

    'Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
    '    If dgview.Item("paidData", dgview.CurrentRow.Index).Value = True Then
    '        dgview.Item("paytotal", dgview.CurrentRow.Index).Value = cl.ccur4(dgview.Item("sisa", dgview.CurrentRow.Index).Value)
    '    ElseIf dgview.Item("paidData", dgview.CurrentRow.Index).Value = False Then
    '        dgview.Item("paytotal", dgview.CurrentRow.Index).Value = 0
    '    End If

    'End Sub

    'Private Sub chpayall_CheckedChanged(sender As Object, e As EventArgs) Handles chpayall.CheckedChanged
    '    With dgview
    '        If chpayall.Checked = True Then
    '            For a As Integer = 0 To dgview.Rows.Count - 1
    '                .Rows(a).Cells("paidData").Value = vbTrue
    '            Next
    '        ElseIf chpayall.Checked = False Then
    '            For a As Integer = 0 To dgview.Rows.Count - 1
    '                .Rows(a).Cells("paidData").Value = vbFalse
    '            Next
    '        End If
    '    End With
    '    getcalculate()
    'End Sub

    'Private Sub dttdt_ValueChanged(sender As Object, e As EventArgs) Handles dttdt.ValueChanged
    '    If cl.cnum(cl.readData("SELECT COUNT(id) FROM mrate WHERE tdate = '" & Format(dttdt.Value, "yyyyMMdd") & "' and tstatus = 1 and ratetype = 'BANK INDONESIA'")) <> 0 Then
    '        txtexrate.Text = cl.ccur(cl.readData("SELECT CASE WHEN ISNULL(rate,1) = 0 THEN 1 ELSE ISNULL(rate,1) END FROM mrate WHERE tdate = '" & Format(dttdt.Value, "yyyyMMdd") & "' and id_mcurr = '" & cmbcurr.SelectedValue & "' AND ratetype = 'BANK INDONESIA'"))
    '    Else
    '        txtexrate.Text = 1
    '    End If
    'End Sub

    'Private Sub dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
    '    'Dim a As New tsalpay2
    '    ''MsgBox(cl.readData("SELECT ISNULL(SUM(paytotal),0) FROM tsalp WHERE tstatus = 1 And id_tsalh = '" & cl.cNum(dgview.Item("id_trans", dgview.CurrentRow.Index).Value) & "'"))
    '    'If cl.readData("SELECT ISNULL(SUM(paytotal),0) FROM tsalp WHERE tstatus = 1 AND id_tsalh = '" & cl.cNum(dgview.Item("id_trans", dgview.CurrentRow.Index).Value) & "'") <= 0 Or
    '    '   cl.readData("SELECT ISNULL(SUM(payment),0) FROM tpayd WHERE tstatus = 1 AND idtrans = '" & cl.cNum(dgview.Item("id_trans", dgview.CurrentRow.Index).Value) & "'") <= 0 Then
    '    '    '    MsgBox("1")
    '    '    a.initializedg()

    '    '    For Each row As DataGridViewRow In dgview2.Rows
    '    '        If row.Cells(.Item("id_trans").Value = dgview.Item("id_trans", dgview.CurrentRow.Index).Value Then
    '    '            dgview2.Rows.Remove(row)
    '    '        End If
    '    '    Next

    '    '    Dim rrowpl As Integer = 0
    '    '    With dgview2
    '    '        For r As Integer = 0 To .Rows.Count - 1
    '    '            If cl.cNum(.Rows(r).Cells("paytotal").Value) <> 0 Then
    '    '                rrowpl = a.dgview.Rows.Add
    '    '                a.dgview.Rows(rrowpl).Cells("paytotal").Value = .Rows(r).Cells("paytotal").Value
    '    '                a.dgview.Rows(rrowpl).Cells("paydate").Value = .Rows(r).Cells("paydate").Value
    '    '                a.dgview.Rows(rrowpl).Cells("macctp").Value = .Rows(r).Cells("macctp").Value
    '    '                a.dgview.Rows(rrowpl).Cells("paynote").Value = .Rows(r).Cells("paynote").Value
    '    '                a.dgview.Rows(rrowpl).Cells("mpaytp").Value = .Rows(r).Cells("mpaytp").Value
    '    '            End If
    '    '        Next
    '    '    End With
    '    '    a.getcalculate()
    '    'Else
    '    '    '  MsgBox(cl.cNum(dgview.Item("id_trans", dgview.CurrentRow.Index).Value))
    '    '    Dim dtdet2 As DataTable = Nothing
    '    '    dtdet2 = cl.table(
    '    '            "SELECT TA.id, TA.id_tsalh, TA.no_tsal " &
    '    '            " , TA.id_mpaytp, TA.paytotal,  TA.paydate, TA.id_macctp " &
    '    '            " , TA.paynote " &
    '    '            " FROM tsalp TA  " &
    '    '            " WHERE TA.tstatus = 1 " &
    '    '            " AND TA.id_tsalh = " & cl.cNum(dgview.Item("id_trans", dgview.CurrentRow.Index).Value))

    '    '    dgview2.Rows.Clear()

    '    '    For Each row As DataGridViewRow In dgview2.Rows
    '    '        If row.Cells(.Item("id_trans").Value = dgview.Item("id_trans", dgview.CurrentRow.Index).Value Then
    '    '            dgview2.Rows.Remove(row)
    '    '        End If
    '    '    Next

    '    '    Dim rrowpl2 As Integer = 0
    '    '    For r2 As Integer = 0 To dtdet2.Rows.Count - 1
    '    '        rrowpl2 = dgview2.Rows.Add
    '    '        With dtdet2
    '    '            dgview2.Rows(rrowpl2).Cells("mpaytp").Value = .Rows(r2).Item("id_mpaytp")
    '    '            dgview2.Rows(rrowpl2).Cells("paytotal").Value = .Rows(r2).Item("paytotal")
    '    '            dgview2.Rows(rrowpl2).Cells("macctp").Value = .Rows(r2).Item("macctp")
    '    '            dgview2.Rows(rrowpl2).Cells("paydate").Value = cl.cChr(.Rows(r2).Item("paydate"))
    '    '            dgview2.Rows(rrowpl2).Cells("paynote").Value = cl.cChr(.Rows(r2).Item("paynote"))
    '    '        End With
    '    '    Next

    '    '    If dgview2.Rows.Count <> -1 Then
    '    '        a.initializedg()
    '    '        a.dgview.Rows.Clear()
    '    '        Dim rrowpl As Integer = 0
    '    '        With dgview2
    '    '            For r As Integer = 0 To .Rows.Count - 1
    '    '                If cl.cNum(.Rows(r).Cells("paytotal").Value) <> 0 Then
    '    '                    rrowpl = a.dgview.Rows.Add
    '    '                    a.dgview.Rows(rrowpl).Cells("paytotal").Value = .Rows(r).Cells("paytotal").Value
    '    '                    a.dgview.Rows(rrowpl).Cells("paydate").Value = .Rows(r).Cells("paydate").Value
    '    '                    a.dgview.Rows(rrowpl).Cells("paynote").Value = .Rows(r).Cells("paynote").Value
    '    '                    a.dgview.Rows(rrowpl).Cells("macctp").Value = .Rows(r).Cells("macctp").Value
    '    '                    a.dgview.Rows(rrowpl).Cells("mpaytp").Value = .Rows(r).Cells("mpaytp").Value
    '    '                End If
    '    '            Next
    '    '        End With
    '    '        a.getcalculate()
    '    '    End If

    '    'End If
    '    ''  a.lblprevbalance.Text = 0
    '    'a.txttotal.Text = cl.ccur4(dgview.Item("total", dgview.CurrentRow.Index).Value)
    '    'a.txttotal2.Text = cl.ccur4(dgview.Item("paytotal", dgview.CurrentRow.Index).Value)
    '    'a.lblprevbalance.Text = cl.cNum(dgview.Item("total", dgview.CurrentRow.Index).Value) - cl.cNum(dgview.Item("sisa", dgview.CurrentRow.Index).Value)
    '    'a.txttotal3.Text = cl.ccur4(dgview.Item("sisa", dgview.CurrentRow.Index).Value)

    '    'a.loadStatusTempForm(Me, Me.txtname_mcust, "[tpaysal]tpay")
    '    'cekform(a, "SEARCH", Me)
    'End Sub

    'Private Sub dgview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellValueChanged
    '    '-- AUTOMATIC PAYMENT
    '    With dgview
    '        For a As Integer = 0 To .Rows.Count - 1
    '            If cl.cnum(.Rows(a).Cells("paidData").Value) = vbTrue And .Rows(a).Cells("paytotal").Value = 0 Then
    '                If cmbcurr.SelectedValue = 2 Then
    '                    .Rows(a).Cells("paytotal").Value = cl.ccur4(cl.cnum(.Rows(a).Cells("sisa").Value))
    '                ElseIf cmbcurr.SelectedValue <> 2 And .Rows(a).Cells("paytotal").Value = 0 Then
    '                    .Rows(a).Cells("paytotal").Value = cl.ccur4(cl.cnum(.Rows(a).Cells("sisa2").Value))
    '                End If
    '            ElseIf cl.cnum(.Rows(a).Cells("paidData").Value) = vbFalse Then
    '                .Rows(a).Cells("paytotal").Value = cl.ccur4(0)
    '                .Rows(a).Cells("sisa").Value = cl.ccur4(.Rows(a).Cells("sisaori").Value)
    '                .Rows(a).Cells("sisa2").Value = cl.ccur4(.Rows(a).Cells("sisaori2").Value)
    '                '  getcalculate()
    '            End If
    '        Next
    '    End With
    '    getcalculate()
    'End Sub

    'Private Sub txtexrate_TextChanged(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub dgview_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgview.CurrentCellDirtyStateChanged
    '    If dgview.IsCurrentCellDirty Then
    '        dgview.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '    End If
    'End Sub

    'Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
    '    If cl.cnum(cl.readData("SELECT COUNT(id) FROM mrate WHERE tdate = '" & Format(dttdt.Value, "yyyyMMdd") & "' and tstatus = 1 and id_mcurr = '" & cmbcurr.SelectedValue & "' and ratetype = 'BANK INDONESIA'")) <> 0 Then
    '        txtexrate.Text = cl.ccur(cl.readData("SELECT CASE WHEN ISNULL(rate,1) = 0 THEN 1 ELSE ISNULL(rate,1) END FROM mrate WHERE tdate = '" & Format(dttdt.Value, "yyyyMMdd") & "' and id_mcurr = '" & cmbcurr.SelectedValue & "' and tstatus = 1 and ratetype = 'BANK INDONESIA'"))
    '    Else
    '        txtexrate.Text = 1
    '    End If
    'End Sub

    'Private Sub TransactionJournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionJournalToolStripMenuItem.Click
    '    If idmaster = 0 Then
    '        cl.msgError("Mohon untuk pilih transaksi !", "Informasi")
    '        Exit Sub
    '    End If

    '    Try
    '        '------PRINT INVOICE
    '        '  MsgBox(idmaster)
    '        Dim rpt As New ReportDocument
    '        Dim f As New print

    '        rpt = New rpttje

    '        rpt.SetDataSource(cl.table(
    '     " SELECT * FROM vtje2 " &
    '     " WHERE id_source = '" & idmaster & "' and refno = 'TPY' " &
    '     " "))

    '        rpt.SetParameterValue("company", cl.readData("SELECT strvl FROM csetting WHERE name = 'company'"))
    '        rpt.SetParameterValue("addr", cl.readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

    '        f.crv.ReportSource = rpt
    '        cekform(f, "NEW", Me)

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub txtexrate_LostFocus(sender As Object, e As EventArgs)
    '    getcalculate()
    'End Sub
End Class