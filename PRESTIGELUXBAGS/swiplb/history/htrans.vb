Imports CrystalDecisions.CrystalReports.Engine
Public Class htrans
    Dim formCond As String = ""
    Dim defCond As String = ""
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
        ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
            '-----------------------------------------------------------------------
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then

        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F2) Then
            btnrefresh.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F5) Then
            btnprint.PerformClick()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub loadcombo()
        Dim dtemptp As DataTable = cl.table(
            "SELECT id AS 'value', username AS 'display' FROM cusr where tstatus = 1")

        cmbuser.DataSource = dtemptp
        cmbuser.ValueMember = "value"
        cmbuser.DisplayMember = "display"

        Dim dtemptp2 As DataTable = cl.table(
          "SELECT 1 AS 'value', 'NEW' AS 'display' UNION ALL SELECT 2 AS 'value', 'UPDATE' AS 'display'" & _
          " UNION ALL SELECT 3 AS 'value', 'DELETE' AS 'display'")

        cmbaction.DataSource = dtemptp2
        cmbaction.ValueMember = "value"
        cmbaction.DisplayMember = "display"
    End Sub

    Private Sub huserlog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initializedg()
        loadcombo()
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

        'setting nama kolom datagrid
        With dgview
            .Columns(0).Name = "code_cusr" : .Columns(0).HeaderText = "Kd User"
            .Columns(1).Name = "name_cusr" : .Columns(1).HeaderText = "User"
            .Columns(2).Name = "act" : .Columns(2).HeaderText = "Action"
            .Columns(3).Name = "jenis" : .Columns(3).HeaderText = "Jenis"
            .Columns(4).Name = "no" : .Columns(4).HeaderText = "No. Transaksi"
            .Columns(5).Name = "note" : .Columns(5).Visible = False
            .Columns(6).Name = "date" : .Columns(6).HeaderText = "Tanggal / Waktu"

        End With
        adjcolumn()
    End Sub

    Private Sub adjcolumn()
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("code_cusr").Width = 80
            .Columns("name_cusr").Width = 100
            .Columns("act").Width = 80
            .Columns("no").Width = 80
            .Columns("jenis").Width = 100
            .Columns("note").Width = 120
            .Columns("date").Width = 150

            .Columns("code_cusr").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("name_cusr").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("act").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("no").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("jenis").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("note").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("date").DefaultCellStyle.BackColor = Color.MistyRose
        End With

    End Sub

    Private Sub viewmode()

        formCond = ""
        If chuser.Checked = True Then : formCond &= " AND  T0.createduser = '" & cmbuser.SelectedValue & "'" : End If
        If chaction.Checked = True Then : formCond &= " AND T0.act = '" & Mid(cmbaction.Text, 1, 3) & "'" : End If
        If chtgl.Checked = True Then : formCond &= _
            " AND (T0.createddate BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "')" : End If

        Dim dtdet As DataTable = Nothing

        dtdet = cl.table(
             "SELECT T0.* FROM htrans T0 where T0.tstatus = 1 " & formCond)

        ' MsgBox("SELECT T0.* FROM huserlog T0 where T0.tstatus = 1 " & formCond)
        dgview.Rows.Clear()

        Dim rrowpl As Integer = 0
        For r As Integer = 0 To dtdet.Rows.Count - 1
            rrowpl = dgview.Rows.Add

            With dtdet
                dgview.Rows(rrowpl).Cells("code_cusr").Value = cl.readData("SELECT code FROM cusr WHERE id = '" & cl.cnum(.Rows(r).Item("createduser")) & "' ")
                dgview.Rows(rrowpl).Cells("name_cusr").Value = cl.readData("SELECT username FROM cusr WHERE id = '" & cl.cnum(.Rows(r).Item("createduser")) & "' ")
                dgview.Rows(rrowpl).Cells("act").Value = cl.cchr(.Rows(r).Item("act"))
                dgview.Rows(rrowpl).Cells("jenis").Value = cl.cchr(.Rows(r).Item("tbl"))
                dgview.Rows(rrowpl).Cells("no").Value = cl.cchr(.Rows(r).Item("notbl"))
                dgview.Rows(rrowpl).Cells("note").Value = .Rows(r).Item("note")
                dgview.Rows(rrowpl).Cells("date").Value = .Rows(r).Item("createddate")
            End With
        Next
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        viewmode()
    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        Dim frm As New htrans
        cekform(frm, "REFRESH", Me)
    End Sub

    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnprint_Click(sender As System.Object, e As System.EventArgs) Handles btnprint.Click

    End Sub

    Private Sub dgDetail_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgview.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgview.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture) + 1, _
                                   dgview.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 5, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub
End Class