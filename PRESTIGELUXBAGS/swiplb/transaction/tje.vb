Imports CrystalDecisions.CrystalReports.Engine
Public Class tje
    Dim idmaster As Integer = 0, statform As String = ""
    Private compid As String = cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'")

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.C)) Then
            '  btncancel.PerformClick()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.A)) Then
            btnsave.PerformClick()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.E)) Then
            'btnUpdate.PerformClick()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.D)) Then
            btndelete.PerformClick()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.S)) Then

        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.U)) Then

        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.Left)) Then

        ElseIf Control.ModifierKeys = Keys.Control AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.Right)) Then
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub

    Private Sub gencode()
        If compid = "CHJ" Then
            txtno.Text = cl.readData("SELECT dbo.fgetcode('tjechj','" & Format(CDate(dttdate.Value), "yy") & "')")
        Else
            txtno.Text = cl.readData("SELECT dbo.fgetcode('tje','" & Format(CDate(dttdate.Value), "yy") & "')")
        End If
    End Sub

    Private Sub initializedg()
        'deklarasi jumlah datagrid kolom
        dgview.ColumnCount = 7
        dgview.ColumnHeadersVisible = True

        'untuk melakukan konfigurasi style dari kolo header 
        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        dgview.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        dgview.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        With dgview
                .Columns(0).Name = "code_mcoa" : .Columns(0).HeaderText = "ACT NO."
            .Columns(1).Name = "name_mcoa" : .Columns(1).HeaderText = "ACCOUNT"
            .Columns(2).Name = "debit" : .Columns(2).HeaderText = "DEBIT RP"
            .Columns(3).Name = "credit" : .Columns(3).HeaderText = "CREDIT RP"
            .Columns(4).Name = "note" : .Columns(4).HeaderText = "NOTE"

            .Columns(5).Name = "id_mcoa" : .Columns(5).Visible = False
            .Columns(6).Name = "id_mcurr" : .Columns(6).Visible = False
        End With
            adjcolumn()
        'setting nama kolom datagrid

    End Sub

    Private Sub adjcolumn()
        'dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("code_mcoa").Width = 70
            .Columns("name_mcoa").Width = 120
            .Columns("debit").Width = 80
            .Columns("credit").Width = 80
            .Columns("note").Width = 120
            '   .Columns("usenote").Width = 40

            .Columns("debit").DefaultCellStyle.Format = "n2"
                .Columns("credit").DefaultCellStyle.Format = "n2"
                .Columns("debitfc").DefaultCellStyle.Format = "n2"
            .Columns("creditfc").DefaultCellStyle.Format = "n2"

            .Columns("code_mcoa").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("name_mcoa").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("debit").DefaultCellStyle.BackColor = Color.PaleGreen
            .Columns("credit").DefaultCellStyle.BackColor = Color.PaleGreen
            .Columns("note").DefaultCellStyle.BackColor = Color.PaleGreen
            '   .Columns("usenote").DefaultCellStyle.BackColor = Color.PaleGreen
        End With

        If dgview.Width < GetWidth(dgview) Then
            dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        ElseIf dgview.Width > GetWidth(dgview) Then
            dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub
    Private Sub clearData()
        idmaster = 0

        ' txtid.Text = ""
        txtno.Text = ""
        dttdate.Value = Now()
        txtnote.Text = ""
        ' txtid.Text = "MANUAL JOURNAL ENTRY"
        dgview.Rows.Clear()
        lblid_source.Text = 0

        txtdbtotal.Text = 0
        txtcrtotal.Text = 0

        lbluseractivity.Text = ""

    End Sub

    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            '  loadcmb()
            btnsave.Text = "Save"
            '  gencode()
            btndelete.Visible = False
            btnprint.Visible = False

            initializedg()
        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True
            btnprint.Visible = True

        End If
        Me.Select() : txtno.Select()
    End Sub


    Private Sub Bank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cultureSet()
        changestatform("new")
        'dgview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        With cl

            If validatedgnull(dgview, "name_mcoa", "Data Grid tidak boleh Kosong !", "Informasi Peringatan", "CHR") = 1 Then : Exit Sub : End If


            If btnsave.Text = "Save" Then

                '------ start validasi
                '    If .ValidateTxtNull(txtno, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
                '------ end validasi


                '--CHECK BALANCE HARUS 0
                If .readData("SELECT COUNT(id) FROM tje WHERE tstatus = 1 AND no = '" & txtno.Text & "'") > 0 Then
                    .msgError("Nomor tidak boleh duplikat. Silahkan gunakan nomor lain !", "Information")
                    Exit Sub
                End If

                Dim tny As Integer
                tny = .msgYesNo("Save Journal : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC stje " &
                        "  '" & .cchr(txtno.Text) & "'" &
                         " , " & .cdt(dttdate) & "" &
                        " , '" & .cnum(txtdbtotal.Text) & "'" &
                        " , '" & .cnum(txtcrtotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        " ")

                    For i As Integer = 0 To dgview.Rows.Count - 1
                        If .cnum(dgview.Rows(i).Cells("id_mcoa").Value) <> 0 Then
                            .execCmdTrans(
                           "EXEC stjed " &
                            " '" & .cchr(txtno.Text) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("id_mcoa").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("debit").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("credit").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("note").Value) & "'" &
                            " , '" & idusr & "'" &
                            " , 'new'" &
                            " , '" & idmaster & "'" &
                            " ")
                        End If
                    Next

                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Save Journal : " & txtno.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then
                ''--CHECK BALANCE HARUS 0
                'If .cnum(txtgrdtotal.Text) <> 0 Then
                '    .msgError("Balance harus 0 sebelum menyimpan !", "Information")
                '    Exit Sub
                'End If
                ''---------------------END------------------------'

                Dim tny As Integer
                tny = .msgYesNo("Update Journal " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC stje " &
                        "  '" & .cchr(txtno.Text) & "'" &
                         " , " & .cdt(dttdate) & "" &
                        " , '" & .cnum(txtdbtotal.Text) & "'" &
                        " , '" & .cnum(txtcrtotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        " ")

                    For i As Integer = 0 To dgview.Rows.Count - 1
                        If .cnum(dgview.Rows(i).Cells("id_mcoa").Value) <> 0 Then
                            .execCmdTrans(
                           "EXEC stjed " &
                            " '" & .cchr(txtno.Text) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("id_mcoa").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("debit").Value) & "'" &
                            " , '" & .cnum(dgview.Rows(i).Cells("credit").Value) & "'" &
                            " , '" & .cchr(dgview.Rows(i).Cells("note").Value) & "'" &
                            " , '" & idusr & "'" &
                            " , 'upd'" &
                            " , '" & idmaster & "'" &
                            " ")
                        End If
                    Next
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Update Journal : " & txtno.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnlist_Click(sender As Object, e As EventArgs) Handles btnlist.Click
        Dim a As New tsearch
        Dim sqlStr As String = ""

        sqlStr =
            "select T0.id, T0.no, T0.refno2, T0.tdate, T0.note, SUM(T1.DEBIT) 'grdtotal', SUM(T1.DEBITFC) 'grdtotal2', T0.source_no, T0.refno, " &
            " T0.id_mcurr, T0.code_mcurr, T0.exrate, T0.refno3 , T0.jecurrtype, T0.dp, T0.createduser, T0.createddate  " &
            " from tje T0 INNER JOIN tjed T1 ON T0.id = T1.idh WHERE T0.tstatus = 1 And T1.tstatus = 1 " &
            " GROUP BY T0.id, T0.no, T0.tdate, T0.id_mcurr, T0.code_mcurr, T0.exrate, T0.id, T0.note, T0.source_no, T0.refno, T0.refno2, T0.refno3,T0.jecurrtype, T0.dp, T0.createduser,T0.createddate "

        With a.dgview

            .DataSource = cl.table(sqlStr & " ORDER BY tdate DESC")


            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "Journal ID"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Date"
            .Columns("note").Visible = True : .Columns("note").HeaderText = "Note"
            ' .Columns("refno2").Visible = True : .Columns("refno2").HeaderText = "Supplier/Buyer"
            .Columns("grdtotal").Visible = True : .Columns("grdtotal").HeaderText = "Total RP" : .Columns("grdtotal").DefaultCellStyle.Format = "n2"
            .Columns("grdtotal2").Visible = True : .Columns("grdtotal2").HeaderText = "Total VA" : .Columns("grdtotal2").DefaultCellStyle.Format = "n2"
            '    .Columns("source_no").Visible = True : .Columns("source_no").HeaderText = "Asal Transaksi"
            '  .Columns("refno").Visible = True : .Columns("refno").HeaderText = "Type"
            .Columns("code_mcurr").Visible = True : .Columns("code_mcurr").HeaderText = "Currency"
            .Columns("exrate").Visible = True : .Columns("exrate").HeaderText = "Rate" : .Columns("exrate").DefaultCellStyle.Format = "n2"
        End With

        a.loadStatusTempForm(Me, Me.btnlist, "[tje]tje")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Search : Journal Entry"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        With cl

            If idmaster = 0 Then
                .msgError("Pilih Transaksi yang ingin di delete !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Delete Journal Entry : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                        "EXEC stje " &
                    "  '" & .cchr(txtno.Text) & "'" &
                      " , " & .cdt(dttdate) & "" &
                        " , '" & .cnum(txtdbtotal.Text) & "'" &
                        " , '" & .cnum(txtcrtotal.Text) & "'" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        " ")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Journal : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Dim tny As Integer
        tny = cl.msgYesNo("Exit without saving Journal Entry", "Confirmation")
        If tny = vbYes Then
            Me.Dispose()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub dgDetail_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgview.RowPostPaint
        'Coding ini digunakan untuk memberi nomor baris pada RowHeader
        Using b As SolidBrush = New SolidBrush(dgview.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture) + 1,
                                   dgview.DefaultCellStyle.Font,
                                   b,
                                   e.RowBounds.Location.X + 20,
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgview_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgview.KeyDown
        If e.KeyCode = Keys.Tab Then
            Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
            If colname = "code_mcoa" Then
                Dim a As New tsearch
                Dim sqlstr As String =
                    " SELECT id, name, code FROM mcoa WHERE tstatus = 1 and active = 'Y' "

                With a.dgview : .DataSource = cl.table(sqlstr & " ORDER BY code ASC")
                    For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
                    .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
                    .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
                End With

                a.loadStatusTempForm(Me, Me.dgview, "[mcoa]tje")
                a.loadSQLSearch(sqlstr, 1)
                a.Text = "Pencarian : Chart of Accounts"

                cekform(a, "SEARCH", Me)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            If dgview.CurrentRow.Index <> dgview.Rows.Count - 1 Then
                dgview.Rows.RemoveAt(dgview.CurrentRow.Index)
                getValCalculate()
            End If
        End If

    End Sub

    Private Sub dgview_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgview.CellEndEdit
        getValCalculate()

        'Dim olddgvsize As Integer = dgview.Width
        ''    textBox1.Text = dgview.Columns(0).Width.ToString()
        'Dim h As Integer = dgview.Height
        'Dim tw As Integer = 0

        'For i As Integer = 0 To dgview.Columns.Count - 1
        '    tw += dgview.Columns(i).Width
        'Next

        'tw += 50
        'dgview.Size = New Size(tw, h)
        'dgview.Width = tw
        '' textBox1.Text = "tw=" & tw & " " & "dgvw=" & " " & dataGridView1.Width & "  " & "col 1:" + dataGridView1.Columns(0).Width & " col 2:" + dataGridView1.Columns(1).Width & " col 3:" + dataGridView1.Columns(2).Width
        'Dim newdgvsize As Integer = dgview.Width
        'Dim differenceinsizeofdgv As Integer = newdgvsize - olddgvsize
        'Me.Width = Me.Width + differenceinsizeofdgv

    End Sub

    Public Sub getValCalculate()
        Dim DBTotal As Decimal = 0
        Dim CRTotal As Decimal = 0

        Dim Balance As Decimal = 0

        With dgview
            For a As Integer = 0 To .Rows.Count - 1
                If cl.cnum(.Rows(a).Cells("id_mcoa").Value) <> 0 Then

                    .Rows(a).Cells("exrate").Value = cl.ccur4(.Rows(a).Cells("exrate").Value)

                    .Rows(a).Cells("debit").Value = cl.ccur(.Rows(a).Cells("debit").Value)
                    .Rows(a).Cells("credit").Value = cl.ccur(.Rows(a).Cells("credit").Value)

                    DBTotal +=
                            cl.cnum(.Rows(a).Cells("debit").Value)


                    CRTotal +=
                        cl.cnum(.Rows(a).Cells("credit").Value)

                    Balance = DBTotal - CRTotal

                    txtdbtotal.Text = cl.ccur(DBTotal)
                    txtcrtotal.Text = cl.ccur(CRTotal)
                End If
            Next
        End With


    End Sub

    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Dim frm As New tje
        cekform(frm, "REFRESH", Me)
    End Sub

    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
            Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString

            If colname = "debit" Or colname = "credit" Then
                If cl.cnum(dgview.Rows(dgview.CurrentRow.Index).Cells("id_mcoa").Value) = 0 Then
                    e.KeyChar = ""
                Else
                    If Not (e.KeyChar = "." And InStr(strval, ".") = 0) And Not (e.KeyChar = "-" And InStr((strval), "-") = 0) Then
                        If InStr("0123456789", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                            e.KeyChar = ""
                        End If
                    End If
                End If

            ElseIf colname <> "debit" And colname <> "credit" Then
                e.KeyChar = ""
            End If
        Catch : End Try
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        'With cl
        '    If .readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EEW" Then
        '        Dim prompt As String = String.Empty
        '        Dim title As String = String.Empty
        '        Dim defaultResponse As String = String.Empty

        '        Dim answer As Object
        '        prompt = "Pilih jenis cetakan " & vbNewLine &
        '                  "1 : TRANSFER VOUCHER" & vbNewLine &
        '                  "2 : SALES VOUCHER" & vbNewLine &
        '                  "3 : MEMORIAL VOUCHER" & vbNewLine &
        '                  "4 : BANK PAYMENT VOUCHER" & vbNewLine &
        '                  "5 : CASH PAYMENT VOUCHER" & vbNewLine &
        '                  "6 : BANK RECEIPT VOUCHER"

        '        title = "Pilih"
        '        defaultResponse = "1"

        '        answer = InputBox(prompt, title, defaultResponse)

        '        If answer = "1" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\TransferVoucher.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try
        '        ElseIf answer = "2" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\SalesVoucherEbara.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try
        '        ElseIf answer = "3" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\MemorialVoucher.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try
        '        ElseIf answer = "4" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\BankPaymentVoucher.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try

        '        ElseIf answer = "5" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\CashPaymentVoucher.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try

        '        ElseIf answer = "6" Then
        '            Try
        '                '------PRINT INVOICE
        '                '  MsgBox(idmaster)
        '                Dim rpt As New ReportDocument
        '                Dim f As New print

        '                rpt.Load(direcCetakan & "\BankReceiptvoucher.rpt")

        '                rpt.SetDataSource(cl.table(
        '             " SELECT * FROM vtje " &
        '             " WHERE id = '" & idmaster & "' " &
        '             " "))

        '                'rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '                'rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '                f.crv.ReportSource = rpt
        '                cekform(f, "NEW", Me)

        '            Catch ex As Exception
        '                MsgBox(ex.Message, MsgBoxStyle.Critical)
        '            End Try
        '        End If
        '    ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KYI" Then
        '        Try
        '            '------PRINT INVOICE
        '            '  MsgBox(idmaster)
        '            Dim rpt As New ReportDocument
        '            Dim f As New print

        '            rpt.Load(direcCetakan & "\AccountVoucher.rpt")

        '            rpt.SetDataSource(cl.table(
        '         " SELECT * FROM vtje " &
        '         " WHERE id = '" & idmaster & "' " &
        '         " "))

        '            rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '            rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '            f.crv.ReportSource = rpt
        '            cekform(f, "NEW", Me)

        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try

        '    ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DAI" Then
        '        Try
        '            '------PRINT INVOICE
        '            '  MsgBox(idmaster)
        '            Dim rpt As New ReportDocument
        '            Dim f As New print

        '            If cmbcurr.SelectedValue = 2 Then
        '                rpt.Load(direcCetakan & "\rpttjeLC.rpt")
        '            Else
        '                rpt.Load(direcCetakan & "\rpttjeVA.rpt")
        '            End If


        '            rpt.SetDataSource(cl.table(
        '         " SELECT * FROM vtje " &
        '         " WHERE id = '" & idmaster & "' " &
        '         " "))

        '            rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '            rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '            f.crv.ReportSource = rpt
        '            cekform(f, "NEW", Me)

        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try

        '    ElseIf .readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DLI" Then
        '        Try
        '            '------PRINT INVOICE
        '            '  MsgBox(idmaster)
        '            Dim rpt As New ReportDocument
        '            Dim f As New print

        '            rpt.Load(direcCetakan & "\rpttje.rpt")

        '            rpt.SetDataSource(cl.table(
        '     " SELECT * FROM vtje " &
        '     " WHERE id = '" & idmaster & "' " &
        '     " "))

        '            rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '            rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '            f.crv.ReportSource = rpt
        '            cekform(f, "NEW", Me)

        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try
        '    Else
        '        Try
        '            '------PRINT INVOICE
        '            '  MsgBox(idmaster)
        '            Dim rpt As New ReportDocument
        '            Dim f As New print

        '            rpt = New rpttje

        '            rpt.SetDataSource(cl.table(
        '         " SELECT * FROM vtje " &
        '         " WHERE id = '" & idmaster & "' " &
        '         " "))

        '            rpt.SetParameterValue("company", .readData("SELECT strvl FROM csetting WHERE name = 'company'"))
        '            rpt.SetParameterValue("addr", .readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))

        '            f.crv.ReportSource = rpt
        '            cekform(f, "NEW", Me)

        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try
        '    End If


        'End With
    End Sub

    Private Sub dttdate_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub
    Private Sub cmbtype2_SelectedIndexChanged(sender As Object, e As EventArgs)
        'With cl
        '    If cmbtype2.SelectedIndex = 1 Then
        '        For i As Integer = 0 To dgview.Rows.Count - 1
        '            If .cnum(dgview.Rows(i).Cells("id_mcoa").Value) <> 0 Then
        '                dgview.Rows(i).Cells("debit").Value = 0
        '                dgview.Rows(i).Cells("credit").Value = 0
        '            End If
        '        Next
        '    End If
        'End With
    End Sub

    Private Sub CopyDetailRemarksNotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyDetailRemarksNotesToolStripMenuItem.Click
        '-- GET ALL THE NOTES FROM THE TABLE
        Dim s As String = ""
        Dim lastRow As Integer
        For v As Integer = 0 To dgview.Rows.Count - 1
            If cl.cnum(dgview.Item("id_mcoa", v).Value) <> 0 Then
                lastRow = v
            End If
        Next
        For b As Integer = 0 To dgview.Rows.Count - 1

            If cl.cnum(dgview.Item("id_mcoa", b).Value) <> 0 Then
                If b = lastRow Then
                    s += "'" & dgview.Item("note", b).Value & "'"
                Else
                    s += "'" & dgview.Item("note", b).Value & "',"
                End If
            End If
            ' MsgBox(s)
        Next
        txtnote.Text = ""
        Dim value2 As String = s.Replace("'", "")
        txtnote.Text = value2
    End Sub

    Private Sub BtnBrowse2_Click(sender As Object, e As EventArgs) 
        For i As Integer = 0 To dgview.Rows.Count - 1
            If cl.cnum(dgview.Rows(i).Cells("id_mcoa").Value) <> 0 Then
                dgview.Rows(i).Cells("note").Value = txtnote.Text
            End If
        Next
    End Sub

    Private Shared Function GetWidth(ByVal grid As DataGridView) As Integer
        Dim width As Integer = 0

        For Each col As DataGridViewColumn In grid.Columns
            width += col.Width
        Next

        Return width
    End Function
End Class