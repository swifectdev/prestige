Imports System.IO
Public Class search
    Dim statusTempForm, varTempForm, varTempForm2 As String
    Dim tempForm As Form
    Dim tempFromObj As Object, tempToObj As Object
    Dim itemtable As New DataTable
    Dim SQLSearch As String
    Dim statSQLSearch As Integer = 0
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.Down) Then
            If dgview.Rows.Count = 0 Then
                txtsearch.Select()
            Else
                If txtsearch.Focused = True Then
                    Me.dgview.Select()
                ElseIf dgview.CurrentRow.Index = dgview.Rows.Count - 1 Then
                    txtsearch.Select()
                End If
            End If
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.Up) Then
            If dgview.CurrentRow.Index = 0 Then
                txtsearch.Select()
            Else
                Me.dgview.Select()
            End If

        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
            Me.txtsearch.Select()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub loadSQLSearch(ByVal sql As String, Optional ByVal statSearch As Integer = 0)
        SQLSearch = "SELECT * FROM (" & sql & ") TS"
        statSQLSearch = statSearch
    End Sub
    Public Sub loadStatusTempForm(ByVal tempAsalForm As Form, ByVal fromObj As Object, ByVal toObj As Object, ByVal temp As String)
        tempForm = tempAsalForm
        tempFromObj = fromObj
        tempToObj = toObj

        statusTempForm = temp
    End Sub

    Private Sub search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.txtsearch.Select()
    End Sub
    Private Sub search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cekform(tempForm, "BACK", Me)
        tempFromObj.select()
    End Sub
    Dim r As Integer = 0, c As Integer = 0
    Private Sub search()
        '  Try
        If statSQLSearch = 0 Then
            Dim Row As Integer = 0
            Dim Column As Integer = 0

            For Row = 0 To (dgview.RowCount - 1)
                For Column = 0 To (dgview.ColumnCount - 1)
                    If IsDBNull(dgview.Rows(Row).Cells(Column).Value) = False Then
                        If dgview.Rows(Row).Cells(Column).Visible = True Then
                            If UCase(dgview.Rows(Row).Cells(Column).Value) Like "*" & UCase(txtsearch.Text) & "*" Then
                                dgview.ClearSelection()
                                Me.dgview.CurrentCell = dgview.Item(Column, Row)
                            End If
                        Else
                            Me.dgview.CurrentCell = dgview.Item(0, 0)
                        End If
                    End If
                Next
            Next

        ElseIf statSQLSearch = 1 Then
            If dgview.Rows.Count > 0 Then
                c = dgview.CurrentCell.ColumnIndex
                r = dgview.CurrentCell.RowIndex

                If txtsearch.Text <> "" Then

                    Dim dt As DataTable = cl.table(SQLSearch)
                    Dim dv As New DataView(cl.table(SQLSearch))
                    Dim dc As DataColumn = dt.Columns(dgview.CurrentCell.ColumnIndex)


                    dv.RowFilter = "[" & dc.ColumnName.ToString & "] Like '%" & cl.cchr(txtsearch.Text) & "%'"
                    dgview.DataSource = dv

                    If dv.Count > r Then
                        Me.dgview.CurrentCell = dgview.Item(c, r)
                    End If

                Else
                    dgview.DataSource = cl.table(SQLSearch)
                    Me.dgview.CurrentCell = dgview.Item(c, r)
                End If
            Else
                dgview.DataSource = cl.table(SQLSearch)
                Dim dt As DataTable = cl.table(SQLSearch)
                Dim dv As New DataView(cl.table(SQLSearch))
                Dim dc As DataColumn = dt.Columns(c)
                dv.RowFilter = "[" & dc.ColumnName.ToString & "] Like '%" & cl.cchr(txtsearch.Text) & "%'"
                dgview.DataSource = dv

                If dv.Count > r Then
                    Me.dgview.CurrentCell = dgview.Item(c, r)
                End If
            End If
        End If
        'Catch ex As Exception
        '    cl.msgError("Gagal Pencarian " & txtsearch.Text & vbNewLine & vbNewLine &
        '            ex.Message, "Gagal Pencarian")
        'End Try
    End Sub
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
            Exit Sub
        End If

        If statusTempForm = "[usr]cusr" Then
            Dim a As cusr = CType(Application.OpenForms("cusr"), cusr)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(cl.cnum(.Item("id", i).Value))
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtusername.Text = cl.cchr(.Item("username", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                a.cmbcostcenter.SelectedValue = cl.cnum(.Item("id_mcost", i).Value)

                If cl.cchr(.Item("showmenu", i).Value) = "Y" Then
                    a.chshowmenu.Checked = True
                Else
                    a.chshowmenu.Checked = False
                End If
            End With
            a.changestatform("upd")

            'ElseIf statusTempForm = "[mitem]mitem" Then
            '    Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            '    a.Enabled = True

            '    With Me.dgview
            '        a.getidmaster(cl.cnum(.Item("id", i).Value))
            '        a.txtcode.Text = cl.cchr(.Item("code", i).Value)
            '        a.txtname.Text = cl.cchr(.Item("name", i).Value)
            '        a.cmbitmtp.SelectedValue = cl.cchr(.Item("itemtp", i).Value)
            '        a.cmbsatuan.SelectedValue = cl.cnum(.Item("id_muom", i).Value)
            '        a.cmbsatuan2.SelectedValue = cl.cnum(.Item("id_muom2", i).Value)
            '        a.txtothercode.Text = cl.cchr(.Item("othercode", i).Value)
            '        a.cmbwhse.SelectedValue = cl.cnum(.Item("id_mwhse", i).Value)
            '        a.cmbmgrp.SelectedValue = cl.cnum(.Item("id_mgrp", i).Value)
            '        a.cmbvariety.SelectedValue = cl.cnum(.Item("id_mvariety", i).Value)

            '        a.txtnett.Text = cl.cnum(.Item("nett", i).Value)
            '        a.txtgross.Text = cl.cnum(.Item("gross", i).Value)

            '        a.txtcost.Text = cl.ccur4(.Item("itemcost", i).Value)

            '        a.txtprice.Text = cl.ccur4(.Item("price", i).Value)
            '        a.txtprice2.Text = cl.ccur4(.Item("price2", i).Value)
            '        a.txtprice3.Text = cl.ccur4(.Item("price3", i).Value)
            '        a.txtprice4.Text = cl.ccur4(.Item("price4", i).Value)

            '        a.txtspec1.Text = cl.cchr(.Item("spec1", i).Value)
            '        a.txtspec2.Text = cl.cchr(.Item("spec2", i).Value)
            '        a.txtspec3.Text = cl.cchr(.Item("spec3", i).Value)
            '        a.txtspec4.Text = cl.cchr(.Item("spec4", i).Value)
            '        a.txtspec5.Text = cl.cchr(.Item("spec5", i).Value)
            '        a.txtspec6.Text = cl.cchr(.Item("spec6", i).Value)
            '        a.txtspec7.Text = cl.cchr(.Item("spec7", i).Value)
            '        a.txtspec8.Text = cl.cchr(.Item("spec8", i).Value)

            '        a.txtnote.Text = cl.cchr(.Item("note", i).Value)

            '        a.lbluseractivity.Text = "Dibuat Oleh : " & cl.readData("SELECT name FROM cusr WHERE id = '" & cl.cnum(.Item("createduser", i).Value) & "' ") & " pada Tgl : " &
            '            cl.cchr(.Item("createddate", i).Value)

            '        a.txtqtyperpack.Text = cl.cdisnum(.Item("qtyperpack", i).Value)

            '        If cl.cchr(.Item("inactive", i).Value) = "Y" Then
            '            a.chactive.Checked = True
            '        Else
            '            a.chactive.Checked = False
            '        End If

            '        If cl.cchr(.Item("invcheck", i).Value) = "Y" Then
            '            a.chinvcheck.Checked = True
            '        Else
            '            a.chinvcheck.Checked = False
            '        End If

            '        Dim dirFilePIM As String = dirImgFilePath
            '        If cl.cchr(.Item("pic1", i).Value) <> "" Then
            '            a.lblpic1.Text = dirFilePIM & "\" & cl.cchr(.Item("pic1", i).Value)
            '        End If

            '        If cl.cchr(.Item("pic2", i).Value) <> "" Then
            '            a.lblpic2.Text = dirFilePIM & "\" & cl.cchr(.Item("pic2", i).Value)
            '        End If

            '        If cl.cchr(.Item("pic3", i).Value) <> "" Then
            '            a.lblpic3.Text = dirFilePIM & "\" & cl.cchr(.Item("pic3", i).Value)
            '        End If

            '        If cl.cchr(.Item("pic4", i).Value) <> "" Then
            '            a.lblpic4.Text = dirFilePIM & "\" & cl.cchr(.Item("pic4", i).Value)
            '        End If

            '        If System.IO.File.Exists(dirFilePIM & "\" & cl.cchr(.Item("pic1", i).Value)) = True Then
            '            Dim fs As System.IO.FileStream
            '            fs = New System.IO.FileStream(dirFilePIM & "\" & cl.cchr(.Item("pic1", i).Value),
            '                     IO.FileMode.Open, IO.FileAccess.Read)
            '            a.PictureBox1.Image = System.Drawing.Image.FromStream(fs)
            '            fs.Dispose()
            '            a.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            '        Else : a.PictureBox1.Image = Nothing
            '        End If

            '        If System.IO.File.Exists(dirFilePIM & "\" & cl.cchr(.Item("pic2", i).Value)) = True Then
            '            Dim fs As System.IO.FileStream
            '            fs = New System.IO.FileStream(dirFilePIM & "\" & cl.cchr(.Item("pic2", i).Value),
            '                     IO.FileMode.Open, IO.FileAccess.Read)
            '            a.PictureBox2.Image = System.Drawing.Image.FromStream(fs)
            '            fs.Dispose()
            '            a.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            '        Else : a.PictureBox2.Image = Nothing
            '        End If

            '        If System.IO.File.Exists(dirFilePIM & "\" & cl.cchr(.Item("pic3", i).Value)) = True Then
            '            Dim fs As System.IO.FileStream
            '            fs = New System.IO.FileStream(dirFilePIM & "\" & cl.cchr(.Item("pic3", i).Value),
            '                     IO.FileMode.Open, IO.FileAccess.Read)
            '            a.PictureBox3.Image = System.Drawing.Image.FromStream(fs)
            '            fs.Dispose()
            '            a.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            '        Else : a.PictureBox3.Image = Nothing
            '        End If

            '        If System.IO.File.Exists(dirFilePIM & "\" & cl.cchr(.Item("pic4", i).Value)) = True Then
            '            Dim fs As System.IO.FileStream
            '            fs = New System.IO.FileStream(dirFilePIM & "\" & cl.cchr(.Item("pic4", i).Value),
            '                     IO.FileMode.Open, IO.FileAccess.Read)
            '            a.PictureBox4.Image = System.Drawing.Image.FromStream(fs)
            '            fs.Dispose()
            '            a.PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
            '        Else : a.PictureBox4.Image = Nothing
            '        End If



            '        Dim dtdet As DataTable = Nothing
            '        dtdet = cl.table(
            '            "Select TA.*, TB.code 'code_mbp', TB.name_mcurr" &
            '            " FROM mitemprc TA INNER JOIN mbp TB ON TA.id_mbp = TB.id " &
            '            " WHERE TA.tstatus = 1 " &
            '            " AND TA.id_mitem = " & cl.cnum(.Item("id", i).Value))

            '        a.dgview.Rows.Clear()
            '        Dim rrowpl As Integer = 0
            '        For r As Integer = 0 To dtdet.Rows.Count - 1
            '            rrowpl = a.dgview.Rows.Add
            '            With dtdet
            '                a.dgview.Rows(rrowpl).Cells("id_mbp").Value = .Rows(r).Item("id_mbp")

            '                a.dgview.Rows(rrowpl).Cells("code_mbp").Value = .Rows(r).Item("code_mbp")
            '                a.dgview.Rows(rrowpl).Cells("name_mbp").Value = .Rows(r).Item("name_mbp")
            '                a.dgview.Rows(rrowpl).Cells("name_mcurr").Value = .Rows(r).Item("name_mcurr")

            '                a.dgview.Rows(rrowpl).Cells("price").Value = ccur4(.Rows(r).Item("price"))


            '            End With
            '        Next

            '        Dim dtdet2 As DataTable = Nothing
            '        dtdet2 = cl.table(
            '            "Select TA.*, TB.code 'code_mbp', TB.name_mcurr" &
            '            " FROM mitemprc2 TA INNER JOIN mbp TB ON TA.id_mbp = TB.id " &
            '            " WHERE TA.tstatus = 1 " &
            '            " AND TA.id_mitem = " & cl.cnum(.Item("id", i).Value))

            '        a.dgview2.Rows.Clear()
            '        Dim rrowpl2 As Integer = 0
            '        For r As Integer = 0 To dtdet2.Rows.Count - 1
            '            rrowpl2 = a.dgview2.Rows.Add
            '            With dtdet2
            '                a.dgview2.Rows(rrowpl2).Cells("id_mbp").Value = .Rows(r).Item("id_mbp")

            '                a.dgview2.Rows(rrowpl2).Cells("code_mbp").Value = .Rows(r).Item("code_mbp")
            '                a.dgview2.Rows(rrowpl2).Cells("name_mbp").Value = .Rows(r).Item("name_mbp")
            '                a.dgview2.Rows(rrowpl2).Cells("name_mcurr").Value = .Rows(r).Item("name_mcurr")

            '                a.dgview2.Rows(rrowpl2).Cells("price").Value = ccur4(.Rows(r).Item("price"))


            '            End With
            '        Next

            '        Dim dtdet3 As DataTable = Nothing
            '        dtdet3 = cl.table(
            '            "Select TA.*, TB.code 'code_mbp', TB.name_mcurr" &
            '            " FROM mitemcode TA INNER JOIN mbp TB ON TA.id_mbp = TB.id " &
            '            " WHERE TA.tstatus = 1 " &
            '            " AND TA.id_mitem = " & cl.cnum(.Item("id", i).Value))

            '        a.dgview3.Rows.Clear()
            '        Dim rrowpl3 As Integer = 0
            '        For r As Integer = 0 To dtdet3.Rows.Count - 1
            '            rrowpl3 = a.dgview3.Rows.Add
            '            With dtdet3
            '                a.dgview3.Rows(rrowpl3).Cells("id_mbp").Value = .Rows(r).Item("id_mbp")

            '                a.dgview3.Rows(rrowpl3).Cells("code_mbp").Value = .Rows(r).Item("code_mbp")
            '                a.dgview3.Rows(rrowpl3).Cells("name_mbp").Value = .Rows(r).Item("name_mbp")
            '                a.dgview3.Rows(rrowpl3).Cells("code_mitem").Value = .Rows(r).Item("code_mitem")
            '            End With
            '        Next

            '        Dim dtdet4 As DataTable = Nothing
            '        dtdet4 = cl.table(
            '            "Select TA.* " &
            '            " FROM mitemprc3 TA " &
            '            " WHERE TA.tstatus = 1 " &
            '            " AND TA.id_mitem = " & cl.cnum(.Item("id", i).Value))

            '        a.dgview4.Rows.Clear()
            '        Dim rrowpl4 As Integer = 0
            '        For r As Integer = 0 To dtdet4.Rows.Count - 1
            '            rrowpl4 = a.dgview4.Rows.Add
            '            With dtdet4
            '                a.dgview4.Rows(rrowpl4).Cells("min").Value = cl.cdisnum(.Rows(r).Item("minqty"))
            '                a.dgview4.Rows(rrowpl4).Cells("max").Value = cl.cdisnum(.Rows(r).Item("maxqty"))
            '                a.dgview4.Rows(rrowpl4).Cells("price").Value = cl.ccur4(.Rows(r).Item("price"))
            '                a.dgview4.Rows(rrowpl4).Cells("mpaytp").Value = cl.cchr(.Rows(r).Item("prctype"))
            '            End With
            '        Next

            '    End With
            '    a.changestatform("upd")

            'ElseIf statusTempForm = "[mbp]mitem" Then
            '    Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            '    a.Enabled = True

            '    a.dgview.CurrentCell = a.dgview.Item("price", a.dgview.CurrentRow.Index)
            '    a.dgview.NotifyCurrentCellDirty(True)
            '    With Me.dgview
            '        a.dgview.Rows(a.dgview.CurrentRow.Index).Cells("code_mbp").Value = .Rows(i).Cells("code").Value
            '        a.dgview.Rows(a.dgview.CurrentRow.Index).Cells("name_mbp").Value = .Rows(i).Cells("name").Value
            '        a.dgview.Rows(a.dgview.CurrentRow.Index).Cells("name_mcurr").Value = .Rows(i).Cells("name_mcurr").Value

            '        a.dgview.Rows(a.dgview.CurrentRow.Index).Cells("id_mbp").Value = .Rows(i).Cells("id").Value
            '    End With
            '    a.dgview.BeginEdit(True) : SendKeys.Send("") : a.dgview.EndEdit(False)

            'ElseIf statusTempForm = "[mbp2]mitem" Then
            '    Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            '    a.Enabled = True

            '    a.dgview2.CurrentCell = a.dgview2.Item("price", a.dgview2.CurrentRow.Index)
            '    a.dgview2.NotifyCurrentCellDirty(True)
            '    With Me.dgview
            '        a.dgview2.Rows(a.dgview2.CurrentRow.Index).Cells("code_mbp").Value = .Rows(i).Cells("code").Value
            '        a.dgview2.Rows(a.dgview2.CurrentRow.Index).Cells("name_mbp").Value = .Rows(i).Cells("name").Value
            '        a.dgview2.Rows(a.dgview2.CurrentRow.Index).Cells("name_mcurr").Value = .Rows(i).Cells("name_mcurr").Value

            '        a.dgview2.Rows(a.dgview2.CurrentRow.Index).Cells("id_mbp").Value = .Rows(i).Cells("id").Value
            '    End With
            '    a.dgview2.BeginEdit(True) : SendKeys.Send("") : a.dgview2.EndEdit(False)

            'ElseIf statusTempForm = "[mbp3]mitem" Then
            '    Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            '    a.Enabled = True

            '    a.dgview3.CurrentCell = a.dgview3.Item("code_mitem", a.dgview3.CurrentRow.Index)
            '    a.dgview3.NotifyCurrentCellDirty(True)
            '    With Me.dgview
            '        a.dgview3.Rows(a.dgview3.CurrentRow.Index).Cells("code_mbp").Value = .Rows(i).Cells("code").Value
            '        a.dgview3.Rows(a.dgview3.CurrentRow.Index).Cells("name_mbp").Value = .Rows(i).Cells("name").Value

            '        a.dgview3.Rows(a.dgview3.CurrentRow.Index).Cells("id_mbp").Value = .Rows(i).Cells("id").Value
            '    End With
            '    a.dgview3.BeginEdit(True) : SendKeys.Send("") : a.dgview3.EndEdit(False)


        End If

        tempForm.Select() : tempToObj.select()
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

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtsearch.Text <> "" Then
                search()
            Else
                submitsearch()
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        If statSQLSearch = 1 Then
            search()
        End If
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        submitsearch()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        cekform(tempForm, "BACK", Me)
        tempFromObj.select()
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

    Private Sub dgview_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgview.ColumnHeaderMouseClick
        Me.dgview.CurrentCell = dgview.Item(dgview.CurrentCell.ColumnIndex, 0)
    End Sub
End Class