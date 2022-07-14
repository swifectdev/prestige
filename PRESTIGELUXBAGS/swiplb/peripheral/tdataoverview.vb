Imports System.IO
Public Class tdataoverview

    Dim statusTempForm, varTempForm, varTempForm2 As String
    Dim tempForm As Form
    Dim tempObj As Object
    Dim itemtable As New DataTable
    Dim SQLSearch As String
    Dim statSQLSearch As Integer = 0
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            BtnCancel.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.Down) Then

        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.Up) Then

        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then

        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub loadSQLSearch(ByVal sql As String, Optional ByVal statSearch As Integer = 0)
        SQLSearch = "SELECT * FROM (" & sql & ") TS"
        statSQLSearch = statSearch
    End Sub
    Public Sub loadStatusTempForm(ByVal tempAsalForm As Form, ByVal tempAsalObj As Object, ByVal temp As String)
        tempForm = tempAsalForm
        tempObj = tempAsalObj
        statusTempForm = temp
    End Sub

    Private Sub search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cekform(tempForm, "BACK", Me)
        tempObj.select()
    End Sub
    Dim r As Integer = 0, c As Integer = 0

    Private Sub submitsearch()

        If dgview.Rows.Count = 0 Then
            MsgBox("Pilih salah satu data !", MsgBoxStyle.Information, "Failed Pick Data")
            Me.Select()
            ' tempForm.Select() ': tempObj.select()
            ' Me.Dispose()
            Exit Sub
        ElseIf tempForm.Visible = False Then
            MsgBox("Last Form Closed !", MsgBoxStyle.Information, "Failed Pick Data")
            'Me.Dispose()
            Exit Sub
        End If

        Dim i As Integer = dgview.CurrentRow.Index
        Dim cekAvailable As Integer = 0
        For z As Integer = 0 To dgview.ColumnCount - 1
            If cl.cchr(dgview.Item(z, i).Value) <> "" Then
                cekAvailable = 1
            End If
        Next

        If cekAvailable = 0 Then
            MsgBox("NULL Data Pick !", MsgBoxStyle.Information, "Failed Pick Data")
            tempForm.Select() : tempObj.select()
            Exit Sub
        End If


        tempForm.Select() : tempObj.select()
        Me.Dispose()
    End Sub

    Private Sub dgview_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgview.CellMouseDoubleClick
        submitsearch()
    End Sub
    Private Sub dgview_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgview.KeyDown
        If e.KeyCode = Keys.Enter Then
            submitsearch()
        End If
    End Sub



    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        submitsearch()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        '    DATAGRIDVIEW_TO_EXCEL((dgview)) ' PARAMETER: YOUR DATAGRIDVIEW
        '  ExportExcel(dgview)
        ' ExportDataToExcel("test.xls", dgview)

        If dgview.RowCount = 0 Then Return

        btnExcel.Text = "Process...."
        btnExcel.Enabled = False
        Application.DoEvents()

        Dim DGV As New DataGridView

        'With DGV
        '    .AllowUserToAddRows = False
        '    .Name = "Student"
        '    .Visible = False
        '    .Columns.Clear()
        '    .Columns.Add("No", "No")
        '    .Columns.Add("NIK", "NIK")
        '    .Columns.Add("Nama", "Nama")
        '    .Columns.Add("Alamat", "Alamat")
        '    .Columns.Add("Telp", "Telp")
        'End With
        'With dgview
        '    If .Rows.Count > 0 Then
        '        For i As Integer = 0 To .Rows.Count - 1
        '            Application.DoEvents()
        '            DGV.Rows.Add(IIf(i = 0, 1, i + 1), .Rows(i).Cells("NIK").Value,
        '                         .Rows(i).Cells("Nama").Value, .Rows(i).Cells("Alamat").Value,
        '                         .Rows(i).Cells("Telp").Value)
        '        Next
        '    End If
        'End With

        SaveFileDialog1.FileName = "search.xls"
        SaveFileDialog1.Filter = "XLSX files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveFileDialog1.RestoreDirectory = True
        Dim res As DialogResult = SaveFileDialog1.ShowDialog()
        If res = DialogResult.Cancel Then
            Exit Sub
        Else
            Dim s As String
            s = SaveFileDialog1.FileName

            FlNm = s
            'FlNm = Application.StartupPath & "\Student " _
            '        & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls"
            If File.Exists(s) Then File.Delete(s)
            ExportToExcel(dgview)

            DGV.Dispose()
            DGV = Nothing

            '   Process.Start("D:\Test.xlsx")

            btnExcel.Text = "Excel"
            btnExcel.Enabled = True
            cl.msgInform("Excel file Saved !", "Information")
            FlNm = ""
        End If

    End Sub

    Private Sub btntpr_Click(sender As Object, e As EventArgs) Handles btntpr.Click
        '  dgview.Rows.Clear()
        dgview.DataSource = Nothing
        Dim sqlwhere As String = ""
        Dim sqlwhere2 As String = ""

        sqlwhere &= " AND tdate BETWEEN '" & Format(dttdt.Value, "yyyyMMdd") & "' AND '" & Format(dttdt2.Value, "yyyyMMdd") & "'"
        sqlwhere2 &= " AND T0.tdt BETWEEN '" & Format(dttdt.Value, "yyyyMMdd") & "' AND '" & Format(dttdt2.Value, "yyyyMMdd") & "'"

        If statusTempForm = "[tgi]tgi" Then
            Dim sqlStr As String =
            "SELECT T0.no, T0.tdate, T1.code_mitem, T1.name_mitem, T2.itemtp, T1.qty, T1.code_muom, T1.code_mwhse FROM tgi T0 INNER JOIN tgid T1 ON T0.id = T1.idh  " &
            " INNER JOIN mitem T2 ON T1.id_mitem = T2.id  " &
            " WHERE T0.tstatus = 1 And T1.tstatus = 1  AND 1=1 " & sqlwhere

            With dgview : .DataSource = cl.table(sqlStr & " order by tdate ASC")
                .Columns("no").HeaderText = "No. Dokumen"
                .Columns("tdate").HeaderText = "Date"
                .Columns("code_mitem").HeaderText = "Item Code"
                .Columns("name_mitem").HeaderText = "Item Name"
                .Columns("itemtp").HeaderText = "Item Type"
                .Columns("qty").HeaderText = "Qty" : .Columns("qty").DefaultCellStyle.Format = "n4"
                .Columns("code_muom").HeaderText = "Satuan"
                .Columns("code_mwhse").HeaderText = "Whse"
            End With

        ElseIf statusTempForm = "[tgr]tgr" Then
            Dim sqlStr As String =
            "SELECT T0.no, T0.tdate, T1.code_mitem, T1.name_mitem, T2.itemtp, T1.qty, T1.code_muom, T1.code_mwhse FROM tgr T0 INNER JOIN tgrd T1 ON T0.id = T1.idh  " &
            " INNER JOIN mitem T2 ON T1.id_mitem = T2.id  " &
            " WHERE T0.tstatus = 1 And T1.tstatus = 1  AND 1=1 " & sqlwhere

            With dgview : .DataSource = cl.table(sqlStr & " order by tdate ASC")
                .Columns("no").HeaderText = "No. Dokumen"
                .Columns("tdate").HeaderText = "Date"
                .Columns("code_mitem").HeaderText = "Item Code"
                .Columns("name_mitem").HeaderText = "Item Name"
                .Columns("itemtp").HeaderText = "Item Type"
                .Columns("qty").HeaderText = "Qty" : .Columns("qty").DefaultCellStyle.Format = "n4"
                .Columns("code_muom").HeaderText = "Satuan"
                .Columns("code_mwhse").HeaderText = "Whse"
            End With

        ElseIf statusTempForm = "[tpur]tpur" Then
            Dim sqlStr As String =
            "SELECT T0.no, T0.tdt 'tdate', T2.code 'code_mitem', T2.name 'name_mitem', T1.qty, T2.code_muom, T1.reqdate, T1.note FROM tpur T0 INNER JOIN tpurd T1 ON T0.id = T1.id_tpur  " &
            " INNER JOIN mitem T2 ON T1.id_mitm = T2.id  " &
            " WHERE T0.tstatus = 1 And T1.tstatus = 1  AND 1=1 " & sqlwhere2

            With dgview : .DataSource = cl.table(sqlStr & " order by tdate ASC")
                .Columns("no").HeaderText = "No. Dokumen"
                .Columns("tdate").HeaderText = "Date"
                .Columns("code_mitem").HeaderText = "Item Code"
                .Columns("name_mitem").HeaderText = "Item Name"
                .Columns("qty").HeaderText = "Qty" : .Columns("qty").DefaultCellStyle.Format = "n4"
                .Columns("code_muom").HeaderText = "Satuan"
                .Columns("reqdate").HeaderText = "Req. Date"
                .Columns("note").HeaderText = "Note"
            End With

        ElseIf statusTempForm = "[tpo]tpo" Then
            Dim sqlStr As String =
            "SELECT T0.no, T0.tdt 'tdate', T3.name 'name_mbp', T0.addr1, T4.code 'code_mcurr', " &
            " T0.exrate, T0.potype, T2.code 'code_mitem', T2.name 'name_mitem', T1.qty, " &
            "  T2.code_muom, T1.price, T1.price2, T1.subtotal, T1.subtotal2, T1.note FROM " &
            " tpo T0 INNER JOIN tpod T1 ON T0.id = T1.id_tpoh  " &
            " INNER JOIN mitem T2 ON T1.id_mitm = T2.id INNER JOIN mbp T3 ON T0.id_msupp = T3.id " &
            " INNER JOIN mcurr T4 ON T0.id_mcurr = T4.id " &
            " WHERE T0.tstatus = 1 And T1.tstatus = 1   AND 1=1 " & sqlwhere2

            With dgview : .DataSource = cl.table(sqlStr & " order by tdate ASC")
                .Columns("no").HeaderText = "No. Dokumen"
                .Columns("tdate").HeaderText = "Date"
                .Columns("name_mbp").HeaderText = "Supplier"
                .Columns("addr1").HeaderText = "Addr"
                .Columns("code_mcurr").HeaderText = "Currency"
                .Columns("exrate").HeaderText = "Ex Rate" : .Columns("exrate").DefaultCellStyle.Format = "n4"
                .Columns("potype").HeaderText = "PO Type"
                .Columns("code_mitem").HeaderText = "Item Code"
                .Columns("name_mitem").HeaderText = "Item Name"
                .Columns("qty").HeaderText = "Qty" : .Columns("qty").DefaultCellStyle.Format = "n4"
                .Columns("code_muom").HeaderText = "Satuan"
                .Columns("price").HeaderText = "Price RP" : .Columns("price").DefaultCellStyle.Format = "n4"
                .Columns("price2").HeaderText = "Price VA" : .Columns("price2").DefaultCellStyle.Format = "n4"
                .Columns("subtotal").HeaderText = "Sub. RP" : .Columns("subtotal").DefaultCellStyle.Format = "n4"
                .Columns("subtotal2").HeaderText = "Sub. VA" : .Columns("subtotal2").DefaultCellStyle.Format = "n4"
                .Columns("note").HeaderText = "Note"
            End With
        ElseIf statusTempForm = "[trec]trec" Then
            Dim sqlStr As String =
            "SELECT T0.no, T0.tdt 'tdate', T3.name 'name_mbp', T0.addr1, T4.code 'code_mcurr', " &
            " T0.exrate, T5.no 'nopo', T2.code 'code_mitem', T2.name 'name_mitem', T1.qty, " &
            "  T2.code_muom, T1.note FROM " &
            " trec T0 INNER JOIN trecd T1 ON T0.id = T1.id_trech " &
            " INNER JOIN mitem T2 ON T1.id_mitm = T2.id INNER JOIN mbp T3 ON T0.id_msupp = T3.id " &
            " INNER JOIN mcurr T4 ON T0.id_mcurr = T4.id LEFT JOIN tpo T5 ON T0.id_tpoh = T5.id" &
            " WHERE T0.tstatus = 1 And T1.tstatus = 1   AND 1=1 " & sqlwhere2

            With dgview : .DataSource = cl.table(sqlStr & " order by tdate ASC")
                .Columns("no").HeaderText = "No. Dokumen"
                .Columns("tdate").HeaderText = "Date"
                .Columns("name_mbp").HeaderText = "Supplier"
                .Columns("addr1").HeaderText = "Addr"
                .Columns("code_mcurr").HeaderText = "Currency"
                .Columns("exrate").HeaderText = "Ex Rate" : .Columns("exrate").DefaultCellStyle.Format = "n4"
                .Columns("nopo").HeaderText = "PO"
                .Columns("code_mitem").HeaderText = "Item Code"
                .Columns("name_mitem").HeaderText = "Item Name"
                .Columns("qty").HeaderText = "Qty" : .Columns("qty").DefaultCellStyle.Format = "n4"
                .Columns("code_muom").HeaderText = "Satuan"
                '.Columns("price").HeaderText = "Price RP" : .Columns("price").DefaultCellStyle.Format = "n4"
                '.Columns("price2").HeaderText = "Price VA" : .Columns("price2").DefaultCellStyle.Format = "n4"
                '.Columns("subtotal").HeaderText = "Sub. RP" : .Columns("subtotal").DefaultCellStyle.Format = "n4"
                '.Columns("subtotal2").HeaderText = "Sub. VA" : .Columns("subtotal2").DefaultCellStyle.Format = "n4"
                .Columns("note").HeaderText = "Note"
            End With
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        cekform(tempForm, "BACK", Me)
        tempObj.select()
    End Sub

    Private Sub dgDetail_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgview.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgview.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture) + 1,
                                   dgview.DefaultCellStyle.Font,
                                   b,
                                   e.RowBounds.Location.X + 5,
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgview_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgview.ColumnHeaderMouseClick
        Me.dgview.CurrentCell = dgview.Item(dgview.CurrentCell.ColumnIndex, 0)
    End Sub

End Class