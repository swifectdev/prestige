Imports System.IO
Public Class tsearch

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
    Public Sub loadStatusTempForm(ByVal tempAsalForm As Form, ByVal tempAsalObj As Object, ByVal temp As String)
        tempForm = tempAsalForm
        tempObj = tempAsalObj
        statusTempForm = temp
    End Sub

    Private Sub search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.txtsearch.Select()
    End Sub
    Private Sub search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cekform(tempForm, "BACK", Me)
        tempObj.select()
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

        ElseIf statSQLSearch = 1 And (statusTempForm <> "[ceisa]tiv" And statusTempForm <> "[ceisa]trec" And statusTempForm <> "[ceisa]tdo" And
            statusTempForm <> "[ceisa]tret" And statusTempForm <> "[ceisa]tpret" And statusTempForm <> "[ceisa]tgr" And statusTempForm <> "[ceisa]tgi" And statusTempForm <> "[ceisa]tsubin" And statusTempForm <> "[ceisa]tsubout") Then
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
            ' -- KHUSUS TABLE TPB 13/09/2019
        ElseIf statSQLSearch = 1 And (statusTempForm <> "[ceisa]tiv" Or statusTempForm <> "[ceisa]trec" Or statusTempForm <> "[ceisa]tdo" Or
            statusTempForm <> "[ceisa]tret" Or statusTempForm <> "[ceisa]tpret" Or statusTempForm <> "[ceisa]tgr" Or statusTempForm <> "[ceisa]tgi" Or statusTempForm <> "[ceisa]tsubin" Or statusTempForm <> "[ceisa]tsubout") Then
            If dgview.Rows.Count > 0 Then
                c = dgview.CurrentCell.ColumnIndex
                r = dgview.CurrentCell.RowIndex

                If txtsearch.Text <> "" Then

                    Dim dt As DataTable = tableTPB(SQLSearch)
                    Dim dv As New DataView(tableTPB(SQLSearch))
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
                dgview.DataSource = tableTPB(SQLSearch)
                Dim dt As DataTable = tableTPB(SQLSearch)
                Dim dv As New DataView(tableTPB(SQLSearch))
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
            tempForm.Select() : tempObj.select()
            Exit Sub
        End If

        'MsgBox(statusTempForm)
        If statusTempForm = "[mtype]mtype" Then
            Dim a As mtype = CType(Application.OpenForms("mtype"), mtype)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mcurr]mcurr" Then
            Dim a As mcurr = CType(Application.OpenForms("mcurr"), mcurr)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mbrand]mbrand" Then
            Dim a As mbrand = CType(Application.OpenForms("mbrand"), mbrand)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mlocation]mlocation" Then
            Dim a As mlocation = CType(Application.OpenForms("mlocation"), mlocation)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[maccount]maccount" Then
            Dim a As maccount = CType(Application.OpenForms("maccount"), maccount)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[muom]muom" Then
            Dim a As muom = CType(Application.OpenForms("muom"), muom)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mvendor]mvendor" Then
            Dim a As mvendor = CType(Application.OpenForms("mvendor"), mvendor)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtphone.Text = cl.cchr(.Item("phone", i).Value)
                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mcust]mcust" Then
            Dim a As mcust = CType(Application.OpenForms("mcust"), mcust)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)

                a.txtsocmed.Text = cl.cchr(.Item("socmed", i).Value)
                a.txtemail.Text = cl.cchr(.Item("email", i).Value)

                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[msales]msales" Then
            Dim a As msales = CType(Application.OpenForms("msales"), msales)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mconsignee]mconsignee" Then
            Dim a As mconsignee = CType(Application.OpenForms("mconsignee"), mconsignee)
            a.Enabled = True

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.txtktp.Text = cl.cchr(.Item("ktp", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mbrand]mitem" Then
            Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mbrand.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mbrand.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mconsignee]mitem" Then
            Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mconsignee.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.txthp1_mconsignee.Text = cl.cchr(.Item("hp1", i).Value)
            End With

        ElseIf statusTempForm = "[mitem]mitem" Then
            Dim a As mitem = CType(Application.OpenForms("mitem"), mitem)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.dtconsign.Value = cl.cchr(.Item("dtconsign", i).Value)
                a.cmbtype.SelectedValue = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.SelectedValue = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.SelectedValue = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtbasetype.Text = cl.cchr(.Item("basetype", i).Value)

                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtqty.Text = cl.ccur(.Item("qty", i).Value)

                a.cmbmlocation.SelectedValue = cl.cchr(.Item("code_mlocation", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' and tstatus = 1"))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1"))
                a.txthp1_mconsignee.Text = cl.cchr(cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1 "))

                If cl.cchr(.Item("spec1", i).Value) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec2", i).Value) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec3", i).Value) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec4", i).Value) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec5", i).Value) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec6", i).Value) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec7", i).Value) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec8", i).Value) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec9", i).Value) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec10", i).Value) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec11", i).Value) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec12", i).Value) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec13", i).Value) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec14", i).Value) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec15", i).Value) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec16", i).Value) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec17", i).Value) = "N" Then
                    a.cmbspec17.SelectedIndex = 1
                Else
                    a.cmbspec17.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec18", i).Value) = "N" Then
                    a.cmbspec18.SelectedIndex = 1
                Else
                    a.cmbspec18.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec19", i).Value) = "N" Then
                    a.cmbspec19.SelectedIndex = 1
                Else
                    a.cmbspec19.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(.Item("notespec", i).Value)

                If cl.cchr(.Item("itemstatus", i).Value) = "O" Then
                    a.txtqty.ReadOnly = False
                Else
                    a.txtqty.ReadOnly = True
                End If

                If cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "O" Then
                    a.txtitemstatus.Text = "AVAILABLE"
                ElseIf cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "R" Then
                    a.txtitemstatus.Text = "PENARIKAN/CANCEL"
                ElseIf cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "S" Then
                    a.txtitemstatus.Text = "TERJUAL"
                End If

                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If

            End With
            a.changestatform("upd")

        ElseIf statusTempForm = "[mvendor]mitemjewell" Then
            Dim a As mitemjewell = CType(Application.OpenForms("mitemjewell"), mitemjewell)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mvendor.Text = cl.cchr(.Item("code", i).Value)
                a.txtvendor.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.txthp1_mconsignee.Text = cl.cchr(.Item("phone", i).Value)
            End With

        ElseIf statusTempForm = "[mitemjewell]mitemjewell" Then
            Dim a As mitemjewell = CType(Application.OpenForms("mitemjewell"), mitemjewell)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.txtcode.Text = cl.cchr(.Item("code", i).Value)
                a.txtname.Text = cl.cchr(.Item("name", i).Value)
                a.dtconsign.Value = cl.cchr(.Item("dtconsign", i).Value)
                a.cmbtype.SelectedValue = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.SelectedValue = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.SelectedValue = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                a.lblcode_mvendor.Text = cl.cchr(.Item("code_mvendor", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtbasetype.Text = cl.cchr(.Item("basetype", i).Value)

                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtqty.Text = cl.ccur(.Item("qty", i).Value)

                a.cmbmlocation.SelectedValue = cl.cchr(.Item("code_mlocation", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' and tstatus = 1"))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1"))
                a.txthp1_mconsignee.Text = cl.cchr(cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1 "))
                a.txtvendor.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mvendor WHERE code = '" & cl.cchr(.Item("code_mvendor", i).Value) & "' and tstatus = 1"))

                If cl.cchr(.Item("spec1", i).Value) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec2", i).Value) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec3", i).Value) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec4", i).Value) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec5", i).Value) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec6", i).Value) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec7", i).Value) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec8", i).Value) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec9", i).Value) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec10", i).Value) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec11", i).Value) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec12", i).Value) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec13", i).Value) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec14", i).Value) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec15", i).Value) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(.Item("spec16", i).Value) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec17", i).Value) = "N" Then
                    a.cmbspec17.SelectedIndex = 1
                Else
                    a.cmbspec17.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec18", i).Value) = "N" Then
                    a.cmbspec18.SelectedIndex = 1
                Else
                    a.cmbspec18.SelectedIndex = 0
                End If

                If cl.cchr(.Item("spec19", i).Value) = "N" Then
                    a.cmbspec19.SelectedIndex = 1
                Else
                    a.cmbspec19.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(.Item("notespec", i).Value)

                If cl.cchr(.Item("itemstatus", i).Value) = "O" Then
                    a.txtqty.ReadOnly = False
                Else
                    a.txtqty.ReadOnly = True
                End If

                If cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "O" Then
                    a.txtitemstatus.Text = "AVAILABLE"
                ElseIf cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "R" Then
                    a.txtitemstatus.Text = "PENARIKAN/CANCEL"
                ElseIf cl.cchr(cl.readData("SELECT itemstatus FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "S" Then
                    a.txtitemstatus.Text = "TERJUAL"
                End If

                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If

            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mconsignee]tconsign" Then
            Dim a As tconsign = CType(Application.OpenForms("tconsign"), tconsign)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mconsignee.Text = cl.cchr(.Item("name", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)

                a.cmbgender.Text = cl.cchr(cl.readData("SELECT gender FROM mconsignee WHERE code = '" & cl.cchr(.Item("code", i).Value) & "'"))
                a.txtnorek.Text = cl.cchr(cl.readData("SELECT norek FROM mconsignee WHERE code = '" & cl.cchr(.Item("code", i).Value) & "'"))
            End With

        ElseIf statusTempForm = "[mbrand]tconsign" Then
            Dim a As tconsign = CType(Application.OpenForms("tconsign"), tconsign)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mbrand.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mbrand.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mitem]tconsign" Then
            Dim a As tconsign = CType(Application.OpenForms("tconsign"), tconsign)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                a.cmbtype.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek", i).Value)

                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtcode_mconsignee.Text = cl.cchr(cl.readData("SELECT code FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' "))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' "))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' "))

                '-- DISABLE ITEMS
                a.txtcode_mitem.ReadOnly = True
                a.txtname_mitem.ReadOnly = True
                a.cmbtype.Enabled = False
                a.cmbcurrb.Enabled = False
                a.cmbcurrj.Enabled = False
                a.txthrgbeli.ReadOnly = True
                a.txthrgjual.ReadOnly = True
                a.txtspek.ReadOnly = True
                a.txtsze.ReadOnly = True
                a.txtmtrl.ReadOnly = True
                a.txtcolor.ReadOnly = True
                a.cmbmuom.Enabled = False

                a.txtname_mbrand.ReadOnly = True


                a.cmbspec1.Enabled = False
                a.cmbspec2.Enabled = False
                a.cmbspec3.Enabled = False
                a.cmbspec4.Enabled = False
                a.cmbspec5.Enabled = False
                a.cmbspec6.Enabled = False
                a.cmbspec7.Enabled = False
                a.cmbspec8.Enabled = False
                a.cmbspec9.Enabled = False
                a.cmbspec10.Enabled = False
                a.cmbspec11.Enabled = False
                a.cmbspec12.Enabled = False
                a.cmbspec13.Enabled = False
                a.cmbspec14.Enabled = False
                a.cmbspec15.Enabled = False
                a.cmbspec16.Enabled = False
                a.txtnotespec.ReadOnly = True

                a.PictureBox1.Enabled = False
                a.PictureBox2.Enabled = False
                a.PictureBox3.Enabled = False
                a.PictureBox4.Enabled = False
                a.PictureBox5.Enabled = False
                a.PictureBox6.Enabled = False

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox5.Image = Image.FromStream(ms6)
                End If
            End With
        ElseIf statusTempForm = "[tconsign]tconsign" Then
            Dim a As tconsign = CType(Application.OpenForms("tconsign"), tconsign)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)

                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate.Value = cl.cchr(.Item("tdate", i).Value)
                a.dttdate2.Value = cl.cchr(.Item("tdate2", i).Value)
                a.txtuser.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM cusr WHERE id = '" & cl.cnum(.Item("createduser", i).Value) & "'"))

                '-- CONSIGNEE
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.txtname_mconsignee.Text = cl.cchr(.Item("name_mconsignee", i).Value)
                a.cmbgender.SelectedValue = cl.cchr(.Item("gender", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)

                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype.SelectedValue = cl.cchr(.Item("code_mtype", i).Value)
                a.txtqty.Text = cl.cchr(.Item("qty", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)
                a.cmbcurrb.SelectedValue = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.SelectedValue = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek_mitem", i).Value)

                a.txtsze.Text = cl.cchr(cl.readData("SELECT sze FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))
                a.txtmtrl.Text = cl.cchr(cl.readData("SELECT mtrl FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))
                a.txtcolor.Text = cl.cchr(cl.readData("SELECT color FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "' "))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.lbldocstatus.Visible = True

                If cl.cchr(cl.readData("SELECT docstat FROM tconsign WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' ")) = "O" Then
                    a.lbldocstatus.Text = "AVAILABLE"
                ElseIf cl.cchr(cl.readData("SELECT docstat FROM tconsign WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' ")) = "R" Then
                    a.lbldocstatus.Text = "PENARIKAN/CANCEL"
                ElseIf cl.cchr(cl.readData("SELECT docstat FROM tconsign WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' ")) = "C" Then
                    a.lbldocstatus.Text = "TERJUAL"
                End If

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If

                ' Catch : End Try
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[msales]tinvoice" Then
            Dim a As tinvoice = CType(Application.OpenForms("tinvoice"), tinvoice)
            a.Enabled = True

            With Me.dgview
                a.lblcode_msales.Text = cl.cchr(.Item("code", i).Value)
                a.txtsales.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With
        ElseIf statusTempForm = "[mcust]tinvoice" Then
            Dim a As tinvoice = CType(Application.OpenForms("tinvoice"), tinvoice)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mcust.Text = cl.cchr(.Item("code", i).Value)

                a.txtcode_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name", i).Value)
                a.txthp1_mcust.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2_mcust.Text = cl.cchr(.Item("hp2", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txtalamat_mcust.Text = cl.cchr(.Item("alamat", i).Value)
            End With

        ElseIf statusTempForm = "[tconsign]tinvoice" Then
            Dim a As tinvoice = CType(Application.OpenForms("tinvoice"), tinvoice)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.txtno_tconsign.Text = cl.cchr(.Item("no", i).Value)
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.dttdate_tconsign.Value = cl.cchr(.Item("tdate", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype_mitem.SelectedValue = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txtqty.Text = 1
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)

                a.txthp1_mconsignee.Text = cl.cchr(cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "' "))

                a.txtspek_mitem.Text = cl.cchr(.Item("spek_mitem", i).Value)

                a.txtsze.Text = cl.cchr(cl.readData("SELECT sze FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))
                a.txtmtrl.Text = cl.cchr(cl.readData("SELECT mtrl FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))
                a.txtcolor.Text = cl.cchr(cl.readData("SELECT color FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "' "))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                End If

            End With

        ElseIf statusTempForm = "[mitem]tinvoice" Then
            Dim a As tinvoice = CType(Application.OpenForms("tinvoice"), tinvoice)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                a.cmbtype_mitem.SelectedValue = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                a.txthp1_mconsignee.Text = cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "'")
                a.txtspek_mitem.Text = cl.cchr(.Item("spek", i).Value)
                Try : a.dttdate_tconsign.Value = cl.cchr(.Item("dtconsign", i).Value) : Catch : End Try

                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtcode_mconsignee.Text = cl.cchr(cl.readData("SELECT code FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1"))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "'  and tstatus = 1"))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If

                a.txttotal.Text = cl.ccur(cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text))
                If a.txtprofit.ReadOnly = True Then
                    a.txtprofit.Text = cl.ccur((cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text)) - (cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgbeli.Text)))
                    a.txtprofitbuyer.Text = 0
                End If

            End With

        ElseIf statusTempForm = "[tinvoice]tinvoice" Then
            Dim a As tinvoice = CType(Application.OpenForms("tinvoice"), tinvoice)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate.Text = cl.cchr(.Item("tdate", i).Value)
                a.dttdate2.Text = cl.cchr(.Item("tdate2", i).Value)
                a.dttglbyr.Text = cl.cchr(.Item("tglbyr", i).Value)
                a.cmbdoctype.Text = cl.cchr(.Item("doctype", i).Value)
                'a.lblcode_msales.Text = cl.cchr(.Item("code_msales", i).Value)
                a.txtsales.Text = cl.cchr(.Item("sales", i).Value)
                '-- CUSTOMER
                a.txtcode_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name_mcust", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txthp1_mcust.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2_mcust.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtinforek.Text = cl.cchr(.Item("inforek", i).Value)
                a.txtalamat_mcust.Text = cl.cchr(.Item("alamat", i).Value)

                a.txtqty.Text = cl.cdisnum(.Item("qty", i).Value)
                a.lblid_tconsign.Text = cl.cchr(.Item("no_tconsign", i).Value)
                a.txtno_tconsign.Text = cl.cchr(.Item("no_tconsign", i).Value)

                a.txtdp.Text = cl.ccur(.Item("dp", i).Value)
                a.txtsendby.Text = cl.cchr(.Item("sendby", i).Value)
                a.txtvoucher.Text = cl.cchr(.Item("voucher", i).Value)
                a.txtinforek.Text = cl.cchr(.Item("inforek", i).Value)

                'If cl.cchr(.Item("no_tconsign", i).Value) <> "" Then
                'a.dttdate_tconsign.Value = cl.cchr(cl.readData("SELECT dtconsign FROM mitem WHERE tstatus = 1 " &
                '" AND code = '" & cl.cchr(.Item("no_tconsign", i).Value) & "'"))
                'End If

                '-- CONSIGNEE
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE tstatus = 1 And code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "'"))
                a.txthp1_mconsignee.Text = cl.cchr(cl.readData("SELECT hp1 FROM mconsignee WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "'"))

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "SELECT TA.* " &
                    " FROM tinvoice TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.no = '" & cl.cchr(.Item("no", i).Value) & "'")

                a.dgview.Rows.Clear()
                a.dgview2.Rows.Clear()

                Dim rrowpl As Integer = 0
                Dim rrowpl2 As Integer = 0
                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    rrowpl2 = a.dgview2.Rows.Add
                    With dtdet

                        a.dgview.Rows(rrowpl).Cells("code_mitem").Value = .Rows(r).Item("code_mitem")
                        a.dgview.Rows(rrowpl).Cells("name_mitem").Value = .Rows(r).Item("name_mitem")
                        a.dgview.Rows(rrowpl).Cells("qty").Value = cl.cdisnum(.Rows(r).Item("qty"))
                        a.dgview.Rows(rrowpl).Cells("hrgjual").Value = cl.ccur(.Rows(r).Item("hrgjual"))
                        a.dgview.Rows(rrowpl).Cells("name_mconsignee").Value = cl.readData("SELECT name FROM mconsignee WHERE code = '" & .Rows(r).Item("code_mconsignee") & "' ")
                        a.dgview.Rows(rrowpl).Cells("hp_mconsignee").Value = .Rows(r).Item("hp1")
                        a.dgview.Rows(rrowpl).Cells("code_mconsignee").Value = .Rows(r).Item("code_mconsignee")
                        a.dgview.Rows(rrowpl).Cells("hrgbeli").Value = cl.ccur(.Rows(r).Item("hrgbeli"))
                        a.dgview.Rows(rrowpl).Cells("profit").Value = cl.cnum(.Rows(r).Item("profit"))
                        a.dgview.Rows(rrowpl).Cells("profitbuyer").Value = cl.cnum(.Rows(r).Item("profitbuyer"))
                        a.dgview.Rows(rrowpl).Cells("code_mcurrb").Value = .Rows(r).Item("code_mcurrb")
                        a.dgview.Rows(rrowpl).Cells("code_mcurrj").Value = .Rows(r).Item("code_mcurrj")
                        a.dgview.Rows(rrowpl).Cells("no").Value = .Rows(r).Item("no")
                        a.dgview.Rows(rrowpl).Cells("id").Value = cl.cnum(.Rows(r).Item("id"))
                        a.dgview.Rows(rrowpl).Cells("dtconsign").Value = cl.readData("SELECT dtconsign FROM mitem WHERE code = '" & .Rows(r).Item("code_mitem") & "'")

                        a.dgview2.Rows(rrowpl2).Cells("code_mitem").Value = .Rows(r).Item("code_mitem")
                        a.dgview2.Rows(rrowpl2).Cells("name_mitem").Value = .Rows(r).Item("name_mitem")
                        a.dgview2.Rows(rrowpl2).Cells("qty").Value = cl.cdisnum(.Rows(r).Item("qty"))
                        a.dgview2.Rows(rrowpl2).Cells("hrgjual").Value = cl.ccur(.Rows(r).Item("hrgjual"))
                        a.dgview2.Rows(rrowpl2).Cells("name_mconsignee").Value = cl.readData("SELECT name FROM mconsignee WHERE code = '" & .Rows(r).Item("code_mconsignee") & "' ")
                        a.dgview2.Rows(rrowpl2).Cells("hp_mconsignee").Value = .Rows(r).Item("hp1")
                        a.dgview2.Rows(rrowpl2).Cells("code_mconsignee").Value = .Rows(r).Item("code_mconsignee")
                        a.dgview2.Rows(rrowpl2).Cells("hrgbeli").Value = cl.ccur(.Rows(r).Item("hrgbeli"))
                        a.dgview2.Rows(rrowpl2).Cells("profit").Value = cl.cnum(.Rows(r).Item("profit"))
                        a.dgview2.Rows(rrowpl2).Cells("profitbuyer").Value = cl.cnum(.Rows(r).Item("profitbuyer"))
                        a.dgview2.Rows(rrowpl2).Cells("code_mcurrb").Value = .Rows(r).Item("code_mcurrb")
                        a.dgview2.Rows(rrowpl2).Cells("code_mcurrj").Value = .Rows(r).Item("code_mcurrj")
                        a.dgview2.Rows(rrowpl2).Cells("no").Value = .Rows(r).Item("no")
                        a.dgview2.Rows(rrowpl2).Cells("id").Value = cl.cnum(.Rows(r).Item("id"))
                        a.dgview2.Rows(rrowpl2).Cells("dtconsign").Value = cl.readData("SELECT dtconsign FROM mitem WHERE code = '" & .Rows(r).Item("code_mitem") & "'")

                    End With
                Next
                'End With
                a.getcalculate()

            'a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
            'a.txtname_mitem.Text = cl.cchr(cl.readData("SELECT name FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            'Try : a.cmbtype_mitem.SelectedValue = cl.cchr(cl.readData("SELECT ISNULL(code_mtype,'BG') FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'")) : Catch : End Try
            'a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
            'a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
            'a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
            'a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
            'a.lblcode_mbrand.Text = cl.cchr(cl.readData("SELECT code_mbrand FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            'a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
            'a.txtspek_mitem.Text = cl.cchr(cl.readData("SELECT spek FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

            'a.txtsze.Text = cl.cchr(cl.readData("SELECT sze FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            'a.txtcolor.Text = cl.cchr(cl.readData("SELECT color FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            'a.txtmtrl.Text = cl.cchr(cl.readData("SELECT mtrl FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

            'a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & a.lblcode_mbrand.Text & "' "))


            a.txtnotedoc.Text = cl.cchr(.Item("note", i).Value)

                If cl.readData("SELECT DISTINCT ISNULL(grdtotal,0) - dbo.fcgetpayinv(no) FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' AND tstatus = 1") <> 0 Then
                    a.lbldocstatus.Text = "UNPAID"
                ElseIf cl.readData("SELECT DISTINCT docstat FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "'") = "L" Then
                    a.lbldocstatus.Text = "CANCELLED/VOID"
                ElseIf cl.readData("SELECT DISTINCT ISNULL(grdtotal,0) - dbo.fcgetpayinv(no) FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' AND tstatus = 1") = 0 Then
                    a.lbldocstatus.Text = "PAID"
                End If

                a.txtprofit.Text = cl.ccur(.Item("profit", i).Value)
                a.txtprofitbuyer.Text = cl.ccur(.Item("profitbuyer", i).Value)
                If cl.cnum(.Item("profitbuyer", i).Value) = 0 Then
                    a.txtprofit.ReadOnly = True
                    a.txtprofitbuyer.ReadOnly = True
                Else
                    a.txtprofit.ReadOnly = False
                    a.txtprofitbuyer.ReadOnly = False
                End If

                '-- CALCULATE PROFIT AND TOTAL
                a.txttotal.Text = cl.ccur(cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text))
                If a.txtprofit.ReadOnly = True Then
                    a.txtprofit.Text = cl.ccur((cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text)) - (cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgbeli.Text)))
                    a.txtprofitbuyer.Text = 0
                End If

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mcust]tpo" Then
            Dim a As tpo = CType(Application.OpenForms("tpo"), tpo)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)

                a.cmbgender.Text = cl.cchr(cl.readData("SELECT gender FROM mcust WHERE code = '" & cl.cchr(.Item("code", i).Value) & "'"))
                a.txtnorek.Text = cl.cchr(cl.readData("SELECT norek FROM mcust WHERE code = '" & cl.cchr(.Item("code", i).Value) & "'"))
            End With

        ElseIf statusTempForm = "[mbrand]tpo" Then
            Dim a As tpo = CType(Application.OpenForms("tpo"), tpo)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mbrand.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mbrand.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mitem]tpo" Then
            Dim a As tpo = CType(Application.OpenForms("tpo"), tpo)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                a.cmbtype.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                'a.lblcode.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek", i).Value)

                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                ' a.txtname_mcust.Text = cl.cchr(cl.readData("SELECT name FROM mcust WHERE code = '" & cl.cchr(.Item("code_mcust", i).Value) & "' "))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' "))

                '-- DISABLE ITEMS
                a.txtcode_mitem.ReadOnly = True
                a.txtname_mitem.ReadOnly = True
                a.cmbtype.Enabled = False
                a.cmbcurrb.Enabled = False
                a.cmbcurrj.Enabled = False
                a.txthrgbeli.ReadOnly = True
                a.txthrgjual.ReadOnly = True
                a.txtspek.ReadOnly = True
                a.txtsze.ReadOnly = True
                a.txtmtrl.ReadOnly = True
                a.txtcolor.ReadOnly = True
                a.cmbmuom.Enabled = False

                a.txtname_mbrand.ReadOnly = True


                a.cmbspec1.Enabled = False
                a.cmbspec2.Enabled = False
                a.cmbspec3.Enabled = False
                a.cmbspec4.Enabled = False
                a.cmbspec5.Enabled = False
                a.cmbspec6.Enabled = False
                a.cmbspec7.Enabled = False
                a.cmbspec8.Enabled = False
                a.cmbspec9.Enabled = False
                a.cmbspec10.Enabled = False
                a.cmbspec11.Enabled = False
                a.cmbspec12.Enabled = False
                a.cmbspec13.Enabled = False
                a.cmbspec14.Enabled = False
                a.cmbspec15.Enabled = False
                a.cmbspec16.Enabled = False
                a.txtnotespec.ReadOnly = True

                a.PictureBox1.Enabled = False
                a.PictureBox2.Enabled = False
                a.PictureBox3.Enabled = False
                a.PictureBox4.Enabled = False
                a.PictureBox5.Enabled = False
                a.PictureBox6.Enabled = False

                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1 and code = '" & .Item("code", i).Value & "'")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2 and code = '" & .Item("code", i).Value & "'")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3 and code = '" & .Item("code", i).Value & "'")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4 and code = '" & .Item("code", i).Value & "'")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5 and code = '" & .Item("code", i).Value & "'")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6 and code = '" & .Item("code", i).Value & "'")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox5.Image = Image.FromStream(ms6)
                End If
            End With
        ElseIf statusTempForm = "[tpo]tpo" Then
            Dim a As tpo = CType(Application.OpenForms("tpo"), tpo)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)

                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate.Value = cl.cchr(.Item("tdate", i).Value)
                a.dttdate2.Value = cl.cchr(.Item("tdate2", i).Value)
                '-- CONSIGNEE
                a.txtcode_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name_mcust", i).Value)
                a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txthp2.Text = cl.cchr(.Item("hp2", i).Value)
                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)

                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek_mitem", i).Value)

                a.txtdp.Text = cl.ccur(.Item("dp", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtname_mcust.Text = cl.cchr(cl.readData("SELECT name FROM mcust WHERE code = '" & cl.cchr(.Item("code_mcust", i).Value) & "' "))

                a.lbldocstatus.Text = "AVAILABLE"
                a.lbldocstatus.Visible = True

                a.txtqty.Text = cl.cdisnum(a.txtqty.Text)
                a.txttotal.Text = cl.ccur(cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If

            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[tinvoice]tretinvoice" Then
            Dim a As tretinvoice = CType(Application.OpenForms("tretinvoice"), tretinvoice)
            a.Enabled = True

            Dim img() As Byte
            '  Dim img2() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno_tinvoice.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate_tinvoice.Text = cl.cchr(.Item("tdate", i).Value)
                a.txtsales.Text = cl.cchr(.Item("sales", i).Value)
                '-- CUSTOMER
                a.txtcode_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name_mcust", i).Value)
                a.txthp_mcust.Text = cl.cchr(.Item("hp1", i).Value)

                '-- CONSIGNEE
                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype_mitem.Text = cl.cchr(cl.readData("SELECT code_mtype FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)

                a.txtprofit.Text = cl.ccur(.Item("profit", i).Value)

                a.txtqty.Text = cl.ccur(.Item("qty", i).Value)
                a.txtspek_mitem.Text = cl.cchr(cl.readData("SELECT spek FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

                a.txtsze.Text = cl.cchr(cl.readData("SELECT sze FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.txtmtrl.Text = cl.cchr(cl.readData("SELECT mtrl FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.txtcolor.Text = cl.cchr(cl.readData("SELECT color FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.cmbmuom.SelectedValue = cl.cchr(cl.readData("SELECT code_muom FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))


                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                '-- load pictures
                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "' ") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                a.btncustomer.Enabled = False
                a.btnitem.Enabled = False
            End With

        ElseIf statusTempForm = "[mcust]tretinvoice" Then
            Dim a As tretinvoice = CType(Application.OpenForms("tretinvoice"), tretinvoice)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mcust.Text = cl.cchr(.Item("code", i).Value)

                a.txtcode_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("name", i).Value)
                'a.txthp1_mcust.Text = cl.cchr(.Item("hp1", i).Value)
                'a.txthp2_mcust.Text = cl.cchr(.Item("hp2", i).Value)
                'a.cmbgender.Text = cl.cchr(.Item("gender", i).Value)
                'a.txtalamat_mcust.Text = cl.cchr(.Item("alamat", i).Value)
            End With

        ElseIf statusTempForm = "[mitem]tretinvoice" Then
            Dim a As tretinvoice = CType(Application.OpenForms("tretinvoice"), tretinvoice)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                a.cmbtype_mitem.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                'a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                'a.lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                ' a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                'a.txthp1_mconsignee.Text = cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "'")
                a.txtspek_mitem.Text = cl.cchr(.Item("spek", i).Value)
                'a.dttdate_tconsign.Value = cl.cchr(.Item("dtconsign", i).Value)

                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                'a.txtcode_mconsignee.Text = cl.cchr(cl.readData("SELECT code FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "' and tstatus = 1"))
                'a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsign", i).Value) & "'  and tstatus = 1"))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

            End With

        ElseIf statusTempForm = "[tretinvoice]tretinvoice" Then
            Dim a As tretinvoice = CType(Application.OpenForms("tretinvoice"), tretinvoice)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            'Dim img3() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttglbyr.Text = cl.cchr(.Item("tglbyr", i).Value)
                a.cmbdoctype.Text = cl.cchr(.Item("doctype", i).Value)
                a.cmbdoctype2.Text = cl.cchr(.Item("doctype2", i).Value)
                'a.lblcode_msales.Text = cl.cchr(.Item("code_msales", i).Value)
                a.txtsales.Text = cl.cchr(.Item("sales", i).Value)
                '-- CUSTOMER
                a.txtcode_mcust.Text = cl.cchr(cl.readData("SELECT code_mcust FROM tinvoice WHERE tstatus = 1 And no = '" & cl.cchr(.Item("no_tinvoice", i).Value) & "'"))
                a.txtname_mcust.Text = cl.cchr(cl.readData("SELECT name_mcust FROM tinvoice WHERE tstatus = 1 And no = '" & cl.cchr(.Item("no_tinvoice", i).Value) & "'"))
                a.txtinforek.Text = cl.cchr(.Item("inforek", i).Value)

                '-- CONSIGNEE
                a.txtno_tinvoice.Text = cl.cchr(.Item("no_tinvoice", i).Value)
                a.txthp_mcust.Text = cl.cchr(cl.readData("SELECT hp1 FROM tinvoice WHERE tstatus = 1 and no = '" & cl.cchr(.Item("no_tinvoice", i).Value) & "'"))

                a.txtcode_mitem.Text = cl.cchr(cl.readData("SELECT code_mitem FROM tinvoice WHERE tstatus = 1 And no = '" & cl.cchr(.Item("no_tinvoice", i).Value) & "'"))
                a.txtname_mitem.Text = cl.cchr(cl.readData("SELECT name_mitem FROM tinvoice WHERE tstatus = 1 And no = '" & cl.cchr(.Item("no_tinvoice", i).Value) & "'"))
                a.cmbtype_mitem.Text = cl.cchr(cl.readData("SELECT code_mtype FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))
                a.cmbcurrb.Text = cl.cchr(cl.readData("SELECT code_mcurrb FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))
                a.cmbcurrj.Text = cl.cchr(cl.readData("SELECT code_mcurrj FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))
                a.txthrgbeli.Text = cl.ccur(cl.readData("SELECT hrgbeli FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))
                a.txthrgjual.Text = cl.ccur(cl.readData("SELECT hrgjual FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))
                a.txtspek_mitem.Text = cl.cchr(cl.readData("SELECT spek FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "'"))

                '-- CALCULATE PROFIT AND TOTAL
                a.txttotal.Text = cl.ccur(cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text))
                If a.txtprofit.ReadOnly = True Then
                    a.txtprofit.Text = cl.ccur((cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text)) - (cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgbeli.Text)))
                    'a.txtprofitbuyer.Text = 0
                End If

                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM tretinvoicepic TA WHERE TA.tstatus = 1 And code = '" & cl.cchr(a.txtcode_mitem.Text) & "' and picOrder = 1 and no_tretinvoice = '" & .Item("no", i).Value & "'")
                img2 = cl.readData("SELECT TA.picData FROM tretinvoicepic TA WHERE TA.tstatus = 1 and code = '" & cl.cchr(a.txtcode_mitem.Text) & "' and picOrder = 2 and no_tretinvoice = '" & .Item("no", i).Value & "'")

                If cl.readData("SELECT COUNT(id) FROM tretinvoicepic WHERE tstatus = 1 and picOrder = 1 And code = '" & cl.cchr(a.txtcode_mitem.Text) & "' and picOrder = 1 and no_tretinvoice = '" & .Item("no", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM tretinvoicepic WHERE tstatus = 1 and picOrder = 2 And code = '" & cl.cchr(a.txtcode_mitem.Text) & "' and picOrder = 2 and no_tretinvoice = '" & .Item("no", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If
            End With
            a.changestatform("upd")
        ElseIf statusTempForm = "[mcust]tinvj" Then
            Dim a As tinvj = CType(Application.OpenForms("tinvj"), tinvj)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("code", i).Value) + " -  " + cl.cchr(.Item("name", i).Value)
                a.txthp_mcust.Text = cl.cchr(.Item("hp1", i).Value)
            End With

        ElseIf statusTempForm = "[tinvj]tinvj" Then
            Dim a As tinvj = CType(Application.OpenForms("tinvj"), tinvj)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)

                a.lblcode_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtname_mcust.Text = cl.cchr(cl.readData("select code + ' - ' + name from mcust where code = '" & cl.cchr(.Item("code_mcust", i).Value) & "'"))
                a.txthp_mcust.Text = cl.cchr(cl.readData("select hp1 from mcust where code = '" & cl.cchr(.Item("code_mcust", i).Value) & "'"))

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)
                a.txttotal.Text = cl.ccur(.Item("total", i).Value)

                a.lbldocstatus.Visible = True

                If cl.cchr(cl.readData("select total - dbo.fcgetpayinj(no) from tinvj WHERE tstatus = 1 and no = '" & cl.cchr(.Item("no", i).Value) & "'")) <> 0 Then
                    a.lbldocstatus.Text = "UNPAID"
                ElseIf cl.cchr(cl.readData("select total - dbo.fcgetpayinj(no) from tinvj WHERE tstatus = 1 and no = '" & cl.cchr(.Item("no", i).Value) & "'")) = 0 Then
                    a.lbldocstatus.Text = "PAID"
                End If

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*" &
                    " FROM tinvjd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " And TA.id_tinvjh = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
                        '.Columns(0).Name = "dsc" : .Columns(0).HeaderText = "Deskripsi"
                        '.Columns(1).Name = "qty" : .Columns(1).HeaderText = "Qty"
                        '.Columns(2).Name = "price" : .Columns(2).HeaderText = "Price"
                        '.Columns(3).Name = "total" : .Columns(3).HeaderText = "Total"

                        a.dgview.Rows(rrowpl).Cells("dsc").Value = .Rows(r).Item("dsc")
                        a.dgview.Rows(rrowpl).Cells("qty").Value = cl.ccur(.Rows(r).Item("qty"))
                        a.dgview.Rows(rrowpl).Cells("price").Value = cl.ccur(.Rows(r).Item("price"))
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("total"))
                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")

        ElseIf statusTempForm = "[maccount]topay" Then
            Dim a As topay = CType(Application.OpenForms("topay"), topay)
            a.Enabled = True

            With Me.dgview
                a.lblcode_maccount.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcoa.Text = cl.cchr(.Item("code", i).Value) + " -  " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[topay]topay" Then
            Dim a As topay = CType(Application.OpenForms("topay"), topay)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)


                a.lblcode_maccount.Text = cl.cchr(.Item("code_maccount", i).Value)
                a.txtname_mcoa.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM maccount WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_maccount", i).Value) & "'"))

                a.cmbpaytp.Text = cl.cchr(.Item("jenis", i).Value)
                a.txttotal.Text = cl.ccur(.Item("total", i).Value)

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*" &
                    " FROM topayd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.id_topayh = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
                        '.Columns(0).Name = "dsc" : .Columns(0).HeaderText = "Deskripsi"
                        '.Columns(1).Name = "qty" : .Columns(1).HeaderText = "Qty"
                        '.Columns(2).Name = "price" : .Columns(2).HeaderText = "Price"
                        '.Columns(3).Name = "total" : .Columns(3).HeaderText = "Total"

                        a.dgview.Rows(rrowpl).Cells("dsc").Value = .Rows(r).Item("dsc")
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("total"))
                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")

        ElseIf statusTempForm = "[mitem]trf" Then
            Dim a As trf = CType(Application.OpenForms("trf"), trf)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte


            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                'a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsign", i).Value)
                'a.txtname_mconsignee.Text = cl.cchr(.Item("name_mconsignee", i).Value)
                a.txthp1_mconsignee.Text = cl.cchr(.Item("phone_mconsignee", i).Value)
                a.txtqty.Text = cl.cchr(.Item("qty", i).Value)
                'a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)
                a.txtspek_mitem.Text = cl.cchr(.Item("notespec", i).Value)
                'a.txtnamembrand_mitem.Text = cl.cchr(.Item("name_mbrand", i).Value)
                a.cmbtype_mitem.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mconsignee.Text = cl.cchr(cl.readData("select code_mconsignee from tconsign where code_mitem = '" & cl.cchr(.Item("code", i).Value) & "' and tstatus = 1"))
                a.txtcode_mconsignee.Text = cl.cchr(cl.readData("select code_mconsignee from tconsign where code_mitem = '" & cl.cchr(.Item("code", i).Value) & "' and tstatus = 1"))
                a.txthp1_mconsignee.Text = cl.cchr(cl.readData("select hp1 from tconsign where code_mitem = '" & cl.cchr(.Item("code", i).Value) & "' and tstatus = 1"))

                a.txtspek_mitem.Text = cl.cchr(.Item("spek", i).Value)

                a.txtnamembrand_mitem.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("select name_mconsignee from tconsign where code_mitem = '" & cl.cchr(.Item("code", i).Value) & "'"))

                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)


                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox5.Image = Image.FromStream(ms6)
                End If
            End With
        ElseIf statusTempForm = "[trf]trf" Then
            Dim a As trf = CType(Application.OpenForms("trf"), trf)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)

                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate.Value = cl.cchr(.Item("tdate", i).Value)

                '-- CONSIGNEE
                a.txtcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)

                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype_mitem.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.SelectedValue = cl.cchr(cl.readData("SELECT code_mcurrb from mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.cmbmuom.SelectedValue = cl.cchr(cl.readData("SELECT code_muom from mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.txthrgbeli.Text = cl.ccur(cl.readData("SELECT hrgbeli from mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
                a.txtspek_mitem.Text = cl.cchr(cl.readData("SELECT spek from mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

                a.txtqty.Text = 1

                a.txtnamembrand_mitem.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))
                a.txtname_mconsignee.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mconsignee WHERE code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                Else
                    a.PictureBox1.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                Else
                    a.PictureBox2.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                Else
                    a.PictureBox3.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                Else
                    a.PictureBox4.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                Else
                    a.PictureBox5.Image = Nothing
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                Else
                    a.PictureBox6.Image = Nothing
                End If
            End With

        ElseIf statusTempForm = "[msales]tpop" Then
            Dim a As tpop = CType(Application.OpenForms("tpop"), tpop)
            a.Enabled = True

            With Me.dgview
                a.lbluser.Text = cl.cchr(.Item("code", i).Value)
                a.txtuser.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mvendor]tpop" Then
            Dim a As tpop = CType(Application.OpenForms("tpop"), tpop)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mvendor.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mvendor.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mvendor.Text = cl.cchr(.Item("name", i).Value)
                a.txthp1.Text = cl.cchr(.Item("phone", i).Value)
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtnorek.Text = cl.cchr(.Item("norek", i).Value)
            End With

        ElseIf statusTempForm = "[mbrand]tpop" Then
            Dim a As tpop = CType(Application.OpenForms("tpop"), tpop)
            a.Enabled = True

            With Me.dgview
                a.lblcode_mbrand.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mbrand.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mitem]tpop" Then
            Dim a As tpop = CType(Application.OpenForms("tpop"), tpop)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.lblcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtcode_mitem.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name", i).Value)
                a.cmbtype.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))

                a.txtsze.Text = cl.cchr(.Item("sze", i).Value)
                a.txtmtrl.Text = cl.cchr(.Item("mtrl", i).Value)
                a.txtcolor.Text = cl.cchr(.Item("color", i).Value)
                a.cmbmuom.SelectedValue = cl.cchr(.Item("code_muom", i).Value)

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code", i).Value) & "' "))

                '-- DISABLE ITEMS
                a.txtcode_mitem.ReadOnly = True
                a.txtname_mitem.ReadOnly = True
                a.cmbtype.Enabled = False
                a.cmbcurrb.Enabled = False
                a.cmbcurrj.Enabled = False
                a.txthrgbeli.ReadOnly = False
                a.txthrgjual.ReadOnly = False
                a.txtspek.ReadOnly = True
                a.txtsze.ReadOnly = True
                a.txtmtrl.ReadOnly = True
                a.txtcolor.ReadOnly = True
                a.cmbmuom.Enabled = False

                a.txtname_mbrand.ReadOnly = True


                a.cmbspec1.Enabled = False
                a.cmbspec2.Enabled = False
                a.cmbspec3.Enabled = False
                a.cmbspec4.Enabled = False
                a.cmbspec5.Enabled = False
                a.cmbspec6.Enabled = False
                a.cmbspec7.Enabled = False
                a.cmbspec8.Enabled = False
                a.cmbspec9.Enabled = False
                a.cmbspec10.Enabled = False
                a.cmbspec11.Enabled = False
                a.cmbspec12.Enabled = False
                a.cmbspec13.Enabled = False
                a.cmbspec14.Enabled = False
                a.cmbspec15.Enabled = False
                a.cmbspec16.Enabled = False
                a.txtnotespec.ReadOnly = True

                a.PictureBox1.Enabled = False
                a.PictureBox2.Enabled = False
                a.PictureBox3.Enabled = False
                a.PictureBox4.Enabled = False
                a.PictureBox5.Enabled = False
                a.PictureBox6.Enabled = False

                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code", i).Value & "' ") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                End If
            End With
        ElseIf statusTempForm = "[tpop]tpop" Then
            Dim a As tpop = CType(Application.OpenForms("tpop"), tpop)
            a.Enabled = True

            Dim img() As Byte
            Dim img2() As Byte
            Dim img3() As Byte
            Dim img4() As Byte
            Dim img5() As Byte
            Dim img6() As Byte

            With Me.dgview
                a.getidmaster(.Item("id", i).Value)

                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdate.Value = cl.cchr(.Item("tdate", i).Value)
                a.txtuser.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM cusr WHERE id = '" & cl.cnum(.Item("createduser", i).Value) & "'"))

                '-- CONSIGNEE
                a.txtcode_mvendor.Text = cl.cchr(.Item("code_mvendor", i).Value)
                a.txtname_mvendor.Text = cl.cchr(.Item("name_mvendor", i).Value)
                a.txthp1.Text = cl.cchr(.Item("hp1", i).Value)
                a.txtnorek.Text = cl.cchr(cl.readData("SELECT norek FROM mvendor WHERE code = '" & cl.cchr(.Item("code_mvendor", i).Value) & "'"))
                a.txtalamat.Text = cl.cchr(.Item("alamat", i).Value)
                a.txtuser.Text = cl.cchr(.Item("sales", i).Value)

                a.txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
                a.txtname_mitem.Text = cl.cchr(.Item("name_mitem", i).Value)
                a.cmbtype.Text = cl.cchr(.Item("code_mtype", i).Value)
                a.cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
                a.cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
                a.txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
                a.txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mbrand", i).Value)
                a.lblcode_mbrand.Text = cl.cchr(.Item("code_mvendor", i).Value)
                a.txtspek.Text = cl.cchr(.Item("spek_mitem", i).Value)

                a.txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & cl.cchr(.Item("code_mbrand", i).Value) & "' "))

                a.lbldocstatus.Visible = True
                If cl.readData("SELECT hrgbeli - dbo.fcgetpayvend(no) FROM tpop WHERE no = '" & cl.cchr(.Item("no", i).Value) & "'") <> 0 Then
                    a.lbldocstatus.Text = "UNPAID"
                ElseIf cl.readData("SELECT docstat FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "'") = "L" Then
                    a.lbldocstatus.Text = "CANCELLED/VOID"
                Else
                    a.lbldocstatus.Text = "PAID"
                End If

                a.txtqty.Text = cl.cdisnum(a.txtqty.Text)
                a.txttotal.Text = cl.ccur(cl.cnum(a.txtqty.Text) * cl.cnum(a.txthrgjual.Text))

                If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec1.SelectedIndex = 1
                Else
                    a.cmbspec1.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec2.SelectedIndex = 1
                Else
                    a.cmbspec2.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec3.SelectedIndex = 1
                Else
                    a.cmbspec3.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec4.SelectedIndex = 1
                Else
                    a.cmbspec4.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec5.SelectedIndex = 1
                Else
                    a.cmbspec5.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec6.SelectedIndex = 1
                Else
                    a.cmbspec6.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec7.SelectedIndex = 1
                Else
                    a.cmbspec7.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec8.SelectedIndex = 1
                Else
                    a.cmbspec8.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec9.SelectedIndex = 1
                Else
                    a.cmbspec9.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec10.SelectedIndex = 1
                Else
                    a.cmbspec10.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec11.SelectedIndex = 1
                Else
                    a.cmbspec11.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec12.SelectedIndex = 1
                Else
                    a.cmbspec12.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec13.SelectedIndex = 1
                Else
                    a.cmbspec13.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec14.SelectedIndex = 1
                Else
                    a.cmbspec14.SelectedIndex = 0
                End If

                If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec15.SelectedIndex = 1
                Else
                    a.cmbspec15.SelectedIndex = 0
                End If
                If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                    a.cmbspec16.SelectedIndex = 1
                Else
                    a.cmbspec16.SelectedIndex = 0
                End If

                a.txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

                a.lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                a.lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                a.lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                a.lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                a.lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                a.lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
                '-- load pictures
                img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
                img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
                img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
                img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
                img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
                img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms As New MemoryStream(img)
                    a.PictureBox1.Image = Image.FromStream(ms)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms2 As New MemoryStream(img2)
                    a.PictureBox2.Image = Image.FromStream(ms2)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms3 As New MemoryStream(img3)
                    a.PictureBox3.Image = Image.FromStream(ms3)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms4 As New MemoryStream(img4)
                    a.PictureBox4.Image = Image.FromStream(ms4)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms5 As New MemoryStream(img5)
                    a.PictureBox5.Image = Image.FromStream(ms5)
                End If

                If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                    Dim ms6 As New MemoryStream(img6)
                    a.PictureBox6.Image = Image.FromStream(ms6)
                End If
            End With
            a.changestatform("upd")

        ElseIf statusTempForm = "[maccount]tpy" Then
            Dim a As tpy = CType(Application.OpenForms("tpy"), tpy)
            a.Enabled = True

            With Me.dgview
                a.lblcode_maccount.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_maccount.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mcust]tpy" Then
            Dim a As tpy = CType(Application.OpenForms("tpy"), tpy)
            a.Enabled = True

            With Me.dgview
                a.lblid_mcust.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.txtbalance.Text = cl.ccur(.Item("balance", i).Value)
                a.getOutstandingInvoice()
            End With

        ElseIf statusTempForm = "[tpy]tpy" Then
            Dim a As tpy = CType(Application.OpenForms("tpy"), tpy)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)

                a.lblid_mcust.Text = cl.cchr(.Item("code_mcust", i).Value)
                a.txtname_mcust.Text = cl.cchr(cl.readData("select code + ' - ' + name from mcust where code = '" & cl.cchr(.Item("code_mcust", i).Value) & "'"))

                a.lblcode_maccount.Text = cl.cchr(.Item("code_maccount", i).Value)
                a.txtname_maccount.Text = cl.cchr(cl.readData("select code + ' - ' + name from maccount where code = '" & cl.cchr(.Item("code_maccount", i).Value) & "'"))

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*, CASE WHEN TA.doctype = 'INV' THEN 'INVOICE' WHEN TA.doctype = 'INJ' THEN 'INVOICE JASA' ELSE 'PRE-ORDER' END AS 'doctype_view'" &
                    " FROM tpyd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.id_tpyh = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
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

                        a.dgview.Rows(rrowpl).Cells("paidData").Value = True
                        a.dgview.Rows(rrowpl).Cells("no_trans").Value = .Rows(r).Item("no_trans")
                        a.dgview.Rows(rrowpl).Cells("doctype_view").Value = cl.cchr(.Rows(r).Item("doctype_view"))
                        a.dgview.Rows(rrowpl).Cells("date_trans").Value = cl.cchr(.Rows(r).Item("tdate_trans"))
                        a.dgview.Rows(rrowpl).Cells("customer").Value = cl.cchr(cl.readData("SELECT name FROM mcust WHERE code = '" & a.lblid_mcust.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("hp").Value = cl.cchr(cl.readData("SELECT hp1 FROM mcust WHERE code = '" & a.lblid_mcust.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("code_mitem").Value = cl.cchr(.Rows(r).Item("code_mitem"))
                        a.dgview.Rows(rrowpl).Cells("name_mitem").Value = cl.cchr(cl.readData("SELECT name FROM mitem WHERE code = '" & cl.cchr(.Rows(r).Item("code_mitem")) & "'"))
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("grdtotal_trans"))
                        a.dgview.Rows(rrowpl).Cells("ongkir").Value = cl.ccur(.Rows(r).Item("ongkir"))
                        a.dgview.Rows(rrowpl).Cells("paytotal").Value = cl.ccur(.Rows(r).Item("paytotal"))

                        a.dgview.Rows(rrowpl).Cells("id_trans").Value = 0
                        a.dgview.Rows(rrowpl).Cells("doctype").Value = cl.cchr(.Rows(r).Item("doctype"))
                        a.dgview.Rows(rrowpl).Cells("code_mcust").Value = cl.cchr(.Rows(r).Item("code_mcust"))

                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")


        ElseIf statusTempForm = "[maccount]tpc" Then
            Dim a As tpc = CType(Application.OpenForms("tpc"), tpc)
            a.Enabled = True

            With Me.dgview
                a.lblcode_maccount.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_maccount.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mconsignee]tpc" Then
            Dim a As tpc = CType(Application.OpenForms("tpc"), tpc)
            a.Enabled = True

            With Me.dgview
                a.lblid_mconsignee.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.txtnorek_mconsignee.Text = cl.cchr(.Item("norek", i).Value)
                a.getOutstandingInvoice()
            End With

        ElseIf statusTempForm = "[tpc]tpc" Then
            Dim a As tpc = CType(Application.OpenForms("tpc"), tpc)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)

                a.lblid_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
                a.txtname_mcust.Text = cl.cchr(cl.readData("select code + ' - ' + name from mconsignee where code = '" & cl.cchr(.Item("code_mconsignee", i).Value) & "'"))

                a.lblcode_maccount.Text = cl.cchr(.Item("code_maccount", i).Value)
                a.txtname_maccount.Text = cl.cchr(cl.readData("select code + ' - ' + name from maccount where code = '" & cl.cchr(.Item("code_maccount", i).Value) & "'"))

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*" &
                    " FROM tpcd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.id_tpch = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
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

                        a.dgview.Rows(rrowpl).Cells("paidData").Value = True
                        a.dgview.Rows(rrowpl).Cells("no_trans").Value = .Rows(r).Item("no_trans")
                        a.dgview.Rows(rrowpl).Cells("date_trans").Value = cl.cchr(.Rows(r).Item("tdate_trans"))
                        a.dgview.Rows(rrowpl).Cells("consignee").Value = cl.cchr(cl.readData("SELECT name FROM mconsignee WHERE code = '" & a.lblid_mconsignee.Text & "' and tstatus = 1"))
                        a.dgview.Rows(rrowpl).Cells("hp").Value = cl.cchr(cl.readData("SELECT hp1 FROM mconsignee WHERE code = '" & a.lblid_mconsignee.Text & "' and tstatus = 1"))
                        a.dgview.Rows(rrowpl).Cells("code_mitem").Value = cl.cchr(.Rows(r).Item("code_mitem"))
                        a.dgview.Rows(rrowpl).Cells("name_mitem").Value = cl.cchr(cl.readData("SELECT name FROM mitem WHERE code = '" & cl.cchr(.Rows(r).Item("code_mitem")) & "' and tstatus = 1"))
                        a.dgview.Rows(rrowpl).Cells("hrgjual").Value = cl.ccur(cl.readData("SELECT hrgjual FROM tinvoice WHERE no = '" & .Rows(r).Item("no_trans") & "' and tstatus = 1"))
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("grdtotal_trans"))
                        '    a.dgview.Rows(rrowpl).Cells("ongkir").Value = cl.ccur(.Rows(r).Item("ongkir"))
                        a.dgview.Rows(rrowpl).Cells("paytotal").Value = cl.ccur(.Rows(r).Item("paytotal"))

                        a.dgview.Rows(rrowpl).Cells("id_trans").Value = cl.cnum(cl.readData("SELECT id FROM tinvoice WHERE no = '" & .Rows(r).Item("no_trans") & "' and tstatus = 1"))
                        a.dgview.Rows(rrowpl).Cells("doctype").Value = cl.cchr(.Rows(r).Item("doctype"))
                        a.dgview.Rows(rrowpl).Cells("code_mconsignee").Value = cl.cchr(.Rows(r).Item("code_mconsignee"))
                        a.dgview.Rows(rrowpl).Cells("note").Value = cl.cchr(.Rows(r).Item("note"))

                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")

        ElseIf statusTempForm = "[maccount]tps" Then
            Dim a As tps = CType(Application.OpenForms("tps"), tps)
            a.Enabled = True

            With Me.dgview
                a.lblcode_maccount.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_maccount.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mvendor]tps" Then
            Dim a As tps = CType(Application.OpenForms("tps"), tps)
            a.Enabled = True

            With Me.dgview
                a.lblid_mvendor.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.getOutstandingInvoice()
            End With

        ElseIf statusTempForm = "[tps]tps" Then
            Dim a As tps = CType(Application.OpenForms("tps"), tps)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)

                a.lblid_mvendor.Text = cl.cchr(.Item("code_mvendor", i).Value)
                a.txtname_mcust.Text = cl.cchr(cl.readData("select code + ' - ' + name from mvendor where code = '" & cl.cchr(.Item("code_mvendor", i).Value) & "'"))

                a.lblcode_maccount.Text = cl.cchr(.Item("code_maccount", i).Value)
                a.txtname_maccount.Text = cl.cchr(cl.readData("select code + ' - ' + name from maccount where code = '" & cl.cchr(.Item("code_maccount", i).Value) & "'"))

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*" &
                    " FROM tpsd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.id_tpsh = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
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

                        a.dgview.Rows(rrowpl).Cells("paidData").Value = True
                        a.dgview.Rows(rrowpl).Cells("no_trans").Value = .Rows(r).Item("no_trans")
                        a.dgview.Rows(rrowpl).Cells("date_trans").Value = cl.cchr(.Rows(r).Item("tdate_trans"))
                        a.dgview.Rows(rrowpl).Cells("vendor").Value = cl.cchr(cl.readData("SELECT name FROM mvendor WHERE code = '" & a.lblid_mvendor.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("hp").Value = cl.cchr(cl.readData("SELECT phone FROM mvendor WHERE code = '" & a.lblid_mvendor.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("code_mitem").Value = cl.cchr(.Rows(r).Item("code_mitem"))
                        a.dgview.Rows(rrowpl).Cells("name_mitem").Value = cl.cchr(cl.readData("SELECT name FROM mitem WHERE code = '" & cl.cchr(.Rows(r).Item("code_mitem")) & "'"))
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("grdtotal_trans"))
                        'a.dgview.Rows(rrowpl).Cells("ongkir").Value = cl.ccur(.Rows(r).Item("ongkir"))
                        a.dgview.Rows(rrowpl).Cells("paytotal").Value = cl.ccur(.Rows(r).Item("paytotal"))

                        a.dgview.Rows(rrowpl).Cells("id_trans").Value = 0
                        a.dgview.Rows(rrowpl).Cells("doctype").Value = cl.cchr(.Rows(r).Item("doctype"))
                        a.dgview.Rows(rrowpl).Cells("code_mvendor").Value = cl.cchr(.Rows(r).Item("code_mvendor"))

                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")

        ElseIf statusTempForm = "[maccount]tts" Then
            Dim a As tts = CType(Application.OpenForms("tts"), tts)
            a.Enabled = True

            With Me.dgview
                a.lblcode_maccount.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_maccount.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
            End With

        ElseIf statusTempForm = "[mvendor]tts" Then
            Dim a As tts = CType(Application.OpenForms("tts"), tts)
            a.Enabled = True

            With Me.dgview
                a.lblid_mvendor.Text = cl.cchr(.Item("code", i).Value)
                a.txtname_mcust.Text = cl.cchr(.Item("code", i).Value) + " - " + cl.cchr(.Item("name", i).Value)
                a.getOutstandingInvoice()
            End With

        ElseIf statusTempForm = "[tts]tts" Then
            Dim a As tts = CType(Application.OpenForms("tts"), tts)
            a.Enabled = True
            With Me.dgview
                a.getidmaster(.Item("id", i).Value)
                a.txtno.Text = cl.cchr(.Item("no", i).Value)
                a.dttdt.Text = cl.cchr(.Item("tdate", i).Value)

                a.lblid_mvendor.Text = cl.cchr(.Item("code_mvendor", i).Value)
                a.txtname_mcust.Text = cl.cchr(cl.readData("select code + ' - ' + name from mvendor where code = '" & cl.cchr(.Item("code_mvendor", i).Value) & "'"))

                a.lblcode_maccount.Text = cl.cchr(.Item("code_maccount", i).Value)
                a.txtname_maccount.Text = cl.cchr(cl.readData("select code + ' - ' + name from maccount where code = '" & cl.cchr(.Item("code_maccount", i).Value) & "'"))

                a.txtnote.Text = cl.cchr(.Item("note", i).Value)

                Dim dtdet As DataTable = Nothing
                dtdet = cl.table(
                    "Select TA.*" &
                    " FROM ttsd TA " &
                    " WHERE TA.tstatus = 1 " &
                    " AND TA.id_ttsh = '" & cl.cnum(.Item("id", i).Value) & "'")

                a.dgview.Rows.Clear()
                Dim rrowpl As Integer = 0

                For r As Integer = 0 To dtdet.Rows.Count - 1
                    rrowpl = a.dgview.Rows.Add
                    With dtdet
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

                        a.dgview.Rows(rrowpl).Cells("paidData").Value = True
                        a.dgview.Rows(rrowpl).Cells("no_trans").Value = .Rows(r).Item("no_trans")
                        a.dgview.Rows(rrowpl).Cells("date_trans").Value = cl.cchr(.Rows(r).Item("tdate_trans"))
                        a.dgview.Rows(rrowpl).Cells("vendor").Value = cl.cchr(cl.readData("SELECT name FROM mvendor WHERE code = '" & a.lblid_mvendor.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("hp").Value = cl.cchr(cl.readData("SELECT phone FROM mvendor WHERE code = '" & a.lblid_mvendor.Text & "' "))
                        a.dgview.Rows(rrowpl).Cells("code_mitem").Value = cl.cchr(.Rows(r).Item("code_mitem"))
                        a.dgview.Rows(rrowpl).Cells("name_mitem").Value = cl.cchr(cl.readData("SELECT name FROM mitem WHERE code = '" & cl.cchr(.Rows(r).Item("code_mitem")) & "'"))
                        a.dgview.Rows(rrowpl).Cells("total").Value = cl.ccur(.Rows(r).Item("grdtotal_trans"))
                        'a.dgview.Rows(rrowpl).Cells("ongkir").Value = cl.ccur(.Rows(r).Item("ongkir"))
                        a.dgview.Rows(rrowpl).Cells("paytotal").Value = cl.ccur(.Rows(r).Item("paytotal"))

                        a.dgview.Rows(rrowpl).Cells("id_trans").Value = 0
                        a.dgview.Rows(rrowpl).Cells("doctype").Value = cl.cchr(.Rows(r).Item("doctype"))
                        a.dgview.Rows(rrowpl).Cells("code_mvendor").Value = cl.cchr(.Rows(r).Item("code_mvendor"))

                    End With
                Next
            End With
            a.getcalculate()
            a.changestatform("upd")
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

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If statSQLSearch = 1 Then
                search()
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        'If statSQLSearch = 1 Then
        '    search()
        'End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
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

    Private Sub btnsearching_Click(sender As Object, e As EventArgs) Handles btnsearching.Click
        search()
    End Sub

    Private Sub BtnBrowse1_Click(sender As Object, e As EventArgs) Handles BtnBrowse1.Click
        If statusTempForm = "[mitem]mitem" Then
            Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA INNER JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.code_mtype <> 'JW' and TA.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'"

            With dgview : .DataSource = cl.table(sql)
                For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
                .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
                .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
                .Columns("code_muom").Visible = True : .Columns("code_muom").HeaderText = "Satuan"
                .Columns("hrgbeli").Visible = True : .Columns("hrgbeli").HeaderText = "Hrg Beli" : .Columns("hrgbeli").DefaultCellStyle.Format = "n2"
                .Columns("color").Visible = True : .Columns("color").HeaderText = "Color"
                .Columns("sze").Visible = True : .Columns("sze").HeaderText = "Size"
                .Columns("mtrl").Visible = True : .Columns("mtrl").HeaderText = "Material"
                .Columns("name_mconsignee").Visible = True : .Columns("name_mconsignee").HeaderText = "Consignee"
                .Columns("name_mbrand").Visible = True : .Columns("name_mbrand").HeaderText = "Merk"
                .Columns("phone_mconsignee").Visible = True : .Columns("phone_mconsignee").HeaderText = "HP"
                .Columns("no").Visible = True : .Columns("no").HeaderText = "No Consign"
                .Columns("qty").Visible = True : .Columns("qty").HeaderText = "Stock"
                .Columns("dtconsign").Visible = True : .Columns("dtconsign").HeaderText = "Tgl Msk"
            End With
        ElseIf statusTempForm = "[mitemjewell]mitemjewell" Then
            Dim sql As String = " SELECT TA.*, TC.name 'name_mvendor', TC.phone 'phone_mvendor' " &
            " FROM mitem TA  " &
            " LEFT JOIN mvendor TC ON TA.code_mvendor = TC.code WHERE TA.tstatus = 1  AND TA.code_mtype = 'JW' and TA.dtconsign BETWEEN '" & Format(dtfrom.Value, "yyyyMMdd") & "' AND '" & Format(dtto.Value, "yyyyMMdd") & "'"

            With dgview : .DataSource = cl.table(sql)
                For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
                .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
                .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
                .Columns("code_muom").Visible = True : .Columns("code_muom").HeaderText = "Satuan"
                .Columns("hrgbeli").Visible = True : .Columns("hrgbeli").HeaderText = "Hrg Beli" : .Columns("hrgbeli").DefaultCellStyle.Format = "n2"
                .Columns("color").Visible = True : .Columns("color").HeaderText = "Color"
                .Columns("sze").Visible = True : .Columns("sze").HeaderText = "Size"
                .Columns("mtrl").Visible = True : .Columns("mtrl").HeaderText = "Material"
                .Columns("name_mvendor").Visible = True : .Columns("name_mvendor").HeaderText = "Consignee"
                '.Columns("name_mbrand").Visible = True : .Columns("name_mbrand").HeaderText = "Merk"
                .Columns("phone_mvendor").Visible = True : .Columns("phone_mvendor").HeaderText = "Owner Phone"
                .Columns("no").Visible = True : .Columns("no").HeaderText = "No Consign"
                .Columns("qty").Visible = True : .Columns("qty").HeaderText = "Stock"
                .Columns("dtconsign").Visible = True : .Columns("dtconsign").HeaderText = "Tgl Msk"
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