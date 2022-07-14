Imports CrystalDecisions.CrystalReports.Engine
Public Class mupdownerprice
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
            ' btnlist.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F4) Then
            ' If idmaster <> 0 And btnsave.Text <> "Save" Then : btndelete.PerformClick() : End If
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F5) Then
            'btnprint.PerformClick()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub

    Private Sub gencode()
        ' txtno.Text = cl.readData("SELECT dbo.fgetcode('tpc','" & Format(CDate(dttdt.Text), "yy") & "')")
    End Sub

    Private Sub initializedg()
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
            .Columns(0).Name = "consignee" : .Columns(0).HeaderText = "Owner"
            .Columns(1).Name = "hp1_consignee" : .Columns(1).HeaderText = "Kode/No Tag"
            .Columns(2).Name = "code_mitem" : .Columns(2).HeaderText = "Kode/No Tag"
            .Columns(3).Name = "name_mitem" : .Columns(3).HeaderText = "Deskripsi"
            .Columns(4).Name = "type_mitem" : .Columns(4).HeaderText = "Jenis"
            .Columns(5).Name = "brand_mitem" : .Columns(5).HeaderText = "Brand"
            .Columns(6).Name = "color_mitem" : .Columns(6).HeaderText = "Color"
            .Columns(7).Name = "sze_mitem" : .Columns(7).HeaderText = "Size"
            .Columns(8).Name = "mtrl_mitem" : .Columns(8).HeaderText = "Material"
            .Columns(9).Name = "price" : .Columns(9).HeaderText = "Harga Owner"
            .Columns(10).Name = "id_mitem" : .Columns(10).Visible = False
            .Columns(11).Name = "edited" : .Columns(11).Visible = False
        End With
        adjcolumn()
    End Sub

    Private Sub adjcolumn()
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("consignee").Width = 80
            .Columns("hp1_consignee").Width = 80
            .Columns("code_mitem").Width = 80
            .Columns("name_mitem").Width = 80
            .Columns("type_mitem").Width = 80
            .Columns("brand_mitem").Width = 80
            .Columns("color_mitem").Width = 70
            .Columns("sze_mitem").Width = 80
            .Columns("mtrl_mitem").Width = 80
            .Columns("price").Width = 100

            .Columns("price").DefaultCellStyle.Format = "n2"

            .Columns("consignee").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("hp1_consignee").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("code_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("name_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("type_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("brand_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("color_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("sze_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("mtrl_mitem").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("price").DefaultCellStyle.BackColor = Color.PaleGreen
        End With

    End Sub

    Private Sub clearData()
        dtfrom.Value = Now
        dtto.Value = Now
        dgview.Rows.Clear()
    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform

        If tstatform = "new" Then
            clearData()
            initializedg()
            gencode()
            btnsave.Text = "Save"


        ElseIf tstatform = "upd" Then
            btnsave.Text = "Update"

        End If

        Me.Select()
    End Sub



    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub

    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
        Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString

        If colname = "price" Then
            If cl.cchr(dgview.Rows(dgview.CurrentRow.Index).Cells("code_mitem").Value) = "" Then
                e.KeyChar = ""
            Else
                If Not (e.KeyChar = "." And InStr((strval), ".") = 0) And Not (e.KeyChar = "-" And InStr((strval), "-") = 0) Then
                    If InStr(("0123456789"), e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                        e.KeyChar = ""
                    End If
                End If
            End If

        ElseIf colname <> "price" Then
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


            '  If btnsave.Text = "Save" Then
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tpc'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                '---------------------END------------------------'
                'Dim tny As Integer
                'tny = .msgYesNo("Apakah anda mau menyimpan dokumen Pembayaran dari Customer : " & txtno.Text & " ?", "Konfirmasi")
                'If tny = vbYes Then
                .openTrans()

                For i As Integer = 0 To dgview.Rows.Count - 1
                    If .cnum(dgview.Rows(i).Cells("id_mitem").Value) <> 0 And .cchr(dgview.Rows(i).Cells("edited").Value) = "Y" Then
                        .execCmdTrans(
                            "UPDATE mitem SET hrgbeli = " &
                            "  '" & .cnum(dgview.Rows(i).Cells("price").Value) & "' WHERE id = '" & .cnum(dgview.Rows(i).Cells("id_mitem").Value) & "'" &
                            " ")

                        '-- UPDATE INVOICE HRG MODAL & PROFIT !
                        .execCmdTrans(
                           "UPDATE tinvoice SET hrgbeli = " &
                           "  '" & .cnum(dgview.Rows(i).Cells("price").Value) & "' WHERE code_mitem = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                           " ")

                        .execCmdTrans(
                           "UPDATE tinvoice SET profit = " &
                           "  hrgjual - hrgbeli WHERE code_mitem = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                           " AND tstatus = 1 ")
                    End If
                Next

                .closeTrans(btnsave)

                If .sCloseTrans = 1 Then
                    .msgInform("Sukses update harga owner !", "Informasi")

                    changestatform("new") : End If
            '  End If
            '  End If
            'End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New mupdownerprice
        cekform(frm, "NEW", Me)
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

    Private Sub btnprint_Click(sender As System.Object, e As System.EventArgs)
        With cl
            Try
                Dim rpt As New ReportDocument
                Dim f As New print

                '    If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                '        rpt.Load(direcCetakan & "\PYRCVoucherCashMSKPFC.rpt")

                '        rpt.SetDataSource(cl.table(
                '" SELECT * FROM vtpcDRCR " &
                '" WHERE id = '" & idmaster & "' " &
                '" "))

                '        ' rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))

                '        f.crv.ReportSource = rpt
                '        cekform(f, "NEW", Me)
                '        Exit Sub
                '    Else
                '        rpt = New rpttpc
                '    End If

                rpt.SetDataSource(cl.table(
             " SELECT * FROM vtpcDRCR " &
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

    End Sub


    Private Sub dgview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellEndEdit

        If cl.cnum(dgview.Item("id_mitem", dgview.CurrentRow.Index).Value) <> 0 Then
            dgview.Item("edited", dgview.CurrentRow.Index).Value = "Y"
            dgview.Item("price", dgview.CurrentRow.Index).Value = cl.ccur(dgview.Item("price", dgview.CurrentRow.Index).Value)
        End If

        'If dgview.Item("paytotal", dgview.CurrentRow.Index).Value > dgview.Item("total", dgview.CurrentRow.Index).Value Then
        '    cl.msgError("Pembayaran tidak boleh melebihi Total harga owner !", "Informasi")
        '    dgview.Item("paytotal", dgview.CurrentRow.Index).Value = 0
        '    Exit Sub
        'End If

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

        '.Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "Kode/No Tag"
        '.Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "Deskripsi"
        '.Columns(2).Name = "type_mitem" : .Columns(2).HeaderText = "Jenis"
        '.Columns(3).Name = "brand_mitem" : .Columns(3).HeaderText = "Brand"
        '.Columns(4).Name = "color_mitem" : .Columns(4).HeaderText = "Color"
        '.Columns(5).Name = "sze_mitem" : .Columns(5).HeaderText = "Size"
        '.Columns(6).Name = "mtrl_mitem" : .Columns(6).HeaderText = "Material"
        '.Columns(7).Name = "price" : .Columns(7).HeaderText = "Harga Owner"
        '.Columns(8).Name = "id_mitem" : .Columns(8).Visible = False

        Dim dttable As DataTable = cl.table(
        "SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.itemstatus <> 'S' AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'")

        If dttable.Rows.Count = 0 Then

        Else
            dgview.Rows.Clear()

            Dim rRow As Integer = 0
            For r As Integer = 0 To dttable.Rows.Count - 1
                rRow = dgview.Rows.Add

                With dttable
                    dgview.Rows(rRow).Cells("consignee").Value = .Rows(r).Item("consignee")
                    dgview.Rows(rRow).Cells("hp1_consignee").Value = .Rows(r).Item("hp1_consignee")
                    dgview.Rows(rRow).Cells("code_mitem").Value = .Rows(r).Item("code")
                    dgview.Rows(rRow).Cells("name_mitem").Value = cl.cchr(.Rows(r).Item("name"))
                    dgview.Rows(rRow).Cells("type_mitem").Value = cl.cchr(.Rows(r).Item("type_mitem"))
                    dgview.Rows(rRow).Cells("brand_mitem").Value = cl.cchr(.Rows(r).Item("brand_mitem"))
                    dgview.Rows(rRow).Cells("color_mitem").Value = cl.cchr(.Rows(r).Item("color"))
                    dgview.Rows(rRow).Cells("sze_mitem").Value = cl.cchr(.Rows(r).Item("sze"))
                    dgview.Rows(rRow).Cells("mtrl_mitem").Value = cl.cchr(.Rows(r).Item("mtrl"))
                    dgview.Rows(rRow).Cells("price").Value = cl.ccur(.Rows(r).Item("hrgbeli"))
                    dgview.Rows(rRow).Cells("id_mitem").Value = cl.cnum(.Rows(r).Item("id"))
                    dgview.Rows(rRow).Cells("edited").Value = "N"

                    '    dgview.Rows(rRow).Cells("id_trans").Value = cl.cnum(.Rows(r).Item("idtrans"))

                End With
            Next
        End If
        getcalculate()
    End Sub



    Private Sub BtnBrowse1_Click(sender As Object, e As EventArgs) Handles BtnBrowse1.Click
        getOutstandingInvoice()
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

    '    a.loadStatusTempForm(Me, Me.txtname_mcust, "[mbp]tpc")
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
    '                     "EXEC stpcj 'I', '" & idmaster & "', '" & idusr & "'")


    '            '-- JOURNAL SELISIH KURS
    '            If cl.cnum(txtexratediff.Text) < 0 Then
    '                .execCmdTrans(
    '                         "EXEC stpcskminj 'I', '" & idmaster & "', '" & idusr & "'")
    '            ElseIf cl.cnum(txtexratediff.Text) > 0 Then
    '                .execCmdTrans(
    '                         "EXEC stpcskplsj 'I', '" & idmaster & "', '" & idusr & "'")
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

    '    a.loadStatusTempForm(Me, Me.dgview, "[mcoa]tpc")
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
    Dim r As Integer = 0, c As Integer = 0

    Private Sub BtnBrowse2_Click(sender As Object, e As EventArgs) Handles BtnBrowse2.Click
        'search()

        If (dgview.Rows.Count > 0) Then
            For Each row As DataGridViewRow In dgview.Rows
                If row.Cells("consignee").Value.ToString.Contains(txtsearch.Text) Then
                    dgview.Rows.Item(row.Index).Visible = True
                Else
                    dgview.Rows.Item(row.Index).Visible = False
                End If
            Next
        End If

    End Sub

    Private Sub search()

        If dgview.Rows.Count > 0 Then
            c = dgview.CurrentCell.ColumnIndex
            r = dgview.CurrentCell.RowIndex

            If txtsearch.Text <> "" Then

                Dim dt As DataTable = cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'")
                Dim dv As New DataView(cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'"))
                Dim dc As DataColumn = dt.Columns(dgview.CurrentCell.ColumnIndex)

                dv.RowFilter = "[" & dc.ColumnName.ToString & "] Like '%" & cl.cchr(txtsearch.Text) & "%'"
                dgview.DataSource = dv

                If dv.Count > r Then
                    Me.dgview.CurrentCell = dgview.Item(c, r)
                End If

            Else
                dgview.DataSource = cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'")
                Me.dgview.CurrentCell = dgview.Item(c, r)
            End If
        Else
            dgview.DataSource = cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'")
            Dim dt As DataTable = cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'")
            Dim dv As New DataView(cl.table("SELECT TX.id, TH.name 'consignee', TH.hp1 'hp1_consignee', TX.code, TX.name, TY.name 'type_mitem', TZ.name 'brand_mitem', TX.color, TX.sze, TX.mtrl, TX.hrgbeli  " &
        " FROM mitem TX INNER JOIN mtype TY ON TX.code_mtype = TY.code INNER JOIN " &
        " mbrand TZ ON TX.code_mbrand = TZ.code INNER JOIN mconsignee TH ON TX.code_mconsign = TH.code WHERE TX.tstatus = 1 And TY.tstatus = 1 And TZ.tstatus = 1 AND TH.tstatus = 1" &
        " AND TX.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'"))
            Dim dc As DataColumn = dt.Columns(c)
            dv.RowFilter = "[" & dc.ColumnName.ToString & "] Like '%" & cl.cchr(txtsearch.Text) & "%'"
            dgview.DataSource = dv

            If dv.Count > r Then
                Me.dgview.CurrentCell = dgview.Item(c, r)
            End If
        End If
        ' -- KHUSUS TABLE TPB 13/09/2019

    End Sub

End Class