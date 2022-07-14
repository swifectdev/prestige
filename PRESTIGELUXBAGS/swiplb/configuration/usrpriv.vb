Public Class usrpriv
    
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            Dim tny As Integer
            tny = MessageBox.Show( _
                "Exit from " & Me.Text & "?" & vbNewLine & "Save all outgoing transactions !", _
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tny = vbYes Then
                Me.Dispose()
            Else
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub loadcombo()
        Dim dtemptp As DataTable = cl.table(
            "SELECT id AS 'value', username + ' - ' +  name AS 'display' FROM cusr WHERE tstatus = 1 ")

        cmbusr.DataSource = dtemptp
        cmbusr.ValueMember = "value"
        cmbusr.DisplayMember = "display"

        cmbusr.SelectedIndex = 0
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        With cl
            If dgview.Rows.Count = 0 Then
                MsgBox("Data Hak Akses tidak boleh kosong", MsgBoxStyle.Information, "Gagal Menyimpan Data")
                Exit Sub
            End If

            .openTrans()
            For i As Integer = 0 To dgview.Rows.Count - 1
                If dgview.Item("CheckCanOpen", i).Value = True Then
                    .execCmdTrans("UPDATE cusrpriv SET CanOpen = 'Y' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                        " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                Else
                    .execCmdTrans("UPDATE cusrpriv SET CanOpen = 'N' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                      " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                End If

                If dgview.Item("CheckCanAdd", i).Value = True Then
                    .execCmdTrans("UPDATE cusrpriv SET CanAdd = 'Y' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                        " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                Else
                    .execCmdTrans("UPDATE cusrpriv SET CanAdd = 'N' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                      " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                End If

                If dgview.Item("CheckCanUpdate", i).Value = True Then
                    .execCmdTrans("UPDATE cusrpriv SET CanUpdate = 'Y' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                         " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                Else
                    .execCmdTrans("UPDATE cusrpriv SET CanUpdate = 'N' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                      " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                End If

                If dgview.Item("CheckCanDelete", i).Value = True Then
                    .execCmdTrans("UPDATE cusrpriv SET CanDelete = 'Y' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                         " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                Else
                    .execCmdTrans("UPDATE cusrpriv SET CanDelete = 'N' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                      " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                End If

                If dgview.Item("CheckCanPrint", i).Value = True Then
                    .execCmdTrans("UPDATE cusrpriv SET CanPrint = 'Y' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                         " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                Else
                    .execCmdTrans("UPDATE cusrpriv SET CanPrint = 'N' WHERE id_cusr = " & cmbusr.SelectedValue() & _
                      " AND code_capp = '" & dgview.Item("code", i).Value & "'")
                End If
                '   execCommand(SQLstr)
            Next
            .closeTrans(btnsave)
            If .sCloseTrans = 1 Then
                .msgInform("Berhasil update Setting Hak Akses User" & vbNewLine & _
                   "Sebaiknya Aplikasi untuk User tersebut di Restart (Logout - Login)" & vbNewLine & _
                   "Untuk langsung mendapatkan Hak Akses yang Baru", "Save Data Success")
                btnrefresh.PerformClick() : End If
        End With
    End Sub

    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub
    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim namaKolom As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
        Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString
        If namaKolom = "HAK AKSES USER" Or namaKolom = "TIPE" Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        Dim frm As New usrpriv
        cekform(frm, "REFRESH", Me)
    End Sub

    Private Sub loadTable()
        With cl

            '   loadcombo()

            dgview.DataSource = Nothing

            dgview.DataSource = .table(
             "SELECT TA.code, TA.name AS 'JENIS'" &
             "   , CASE WHEN TA.tp = 'M' THEN 'MASTER DATA' " &
             "       WHEN TA.tp = 'C' THEN 'SETTING' " &
             "       WHEN TA.tp = 'T' THEN 'TRANSAKSI' " &
             "       WHEN TA.tp = 'R' THEN 'REPORT' " &
             "       WHEN TA.tp = 'H' THEN 'HISTORY' " &
             "   END AS 'TIPE', TB.CanOpen, TB.CanAdd, TB.CanUpdate, TB.CanDelete, TB.CanPrint " &
             " FROM capp TA, cusrpriv TB " &
             " WHERE TA.code = TB.code_capp " &
             " AND TB.id_cusr = '" & cmbusr.SelectedValue() & "'" &
             "")

            dgview.Columns("CanOpen").Visible = False
            dgview.Columns("CanAdd").Visible = False
            dgview.Columns("CanUpdate").Visible = False
            dgview.Columns("CanDelete").Visible = False
            dgview.Columns("CanPrint").Visible = False

            dgview.Columns("code").Visible = False
            dgview.Columns("JENIS").Width = 280

            Dim statusCheckData As Integer = 0
            For j As Integer = 0 To dgview.Columns.Count - 1
                If dgview.Columns(j).HeaderText = "Check Data" Then
                    statusCheckData = 1
                End If
            Next
            If statusCheckData = 0 Then
                Dim chkCanOpen As New DataGridViewCheckBoxColumn()
                dgview.Columns.Add(chkCanOpen)
                chkCanOpen.HeaderText = "Open"
                chkCanOpen.Name = "CheckCanOpen"
                dgview.Columns("CheckCanOpen").Width = 75

                Dim chkCanAdd As New DataGridViewCheckBoxColumn()
                dgview.Columns.Add(chkCanAdd)
                chkCanAdd.HeaderText = "Add"
                chkCanAdd.Name = "CheckCanAdd"
                dgview.Columns("CheckCanAdd").Width = 75

                Dim chkCanUpdate As New DataGridViewCheckBoxColumn()
                dgview.Columns.Add(chkCanUpdate)
                chkCanUpdate.HeaderText = "Update"
                chkCanUpdate.Name = "CheckCanUpdate"
                dgview.Columns("CheckCanUpdate").Width = 75

                Dim chkCanDelete As New DataGridViewCheckBoxColumn()
                dgview.Columns.Add(chkCanDelete)
                chkCanDelete.HeaderText = "Delete"
                chkCanDelete.Name = "CheckCanDelete"
                dgview.Columns("CheckCanDelete").Width = 75

                Dim chkCanPrint As New DataGridViewCheckBoxColumn()
                dgview.Columns.Add(chkCanPrint)
                chkCanPrint.HeaderText = "Print"
                chkCanPrint.Name = "CheckCanPrint"
                dgview.Columns("CheckCanPrint").Width = 75
            End If


            For z As Integer = 0 To dgview.Rows.Count - 1

                If dgview.Item("CanOpen", z).Value = "Y" Then
                    dgview.Item("CheckCanOpen", z).Value = True
                End If

                If dgview.Item("CanAdd", z).Value = "Y" Then
                    dgview.Item("CheckCanAdd", z).Value = True
                End If

                If dgview.Item("CanUpdate", z).Value = "Y" Then
                    dgview.Item("CheckCanUpdate", z).Value = True
                End If

                If dgview.Item("CanDelete", z).Value = "Y" Then
                    dgview.Item("CheckCanDelete", z).Value = True
                End If

                If dgview.Item("CanPrint", z).Value = "Y" Then
                    dgview.Item("CheckCanPrint", z).Value = True
                End If

            Next

        End With
    End Sub

    Private Sub usrpriv_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '  loadTable()
        loadcombo()
    End Sub

    Private Sub dgDetail_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgview.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgview.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture) + 1, _
                                   dgview.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 20, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub BtnBrowse1_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse1.Click
        If cmbusr.SelectedIndex = -1 Then
            cl.msgError("Pilih salah satu user !", "Informasi")
        Else
            dgview.Columns.Clear()
            loadTable()
        End If
    End Sub

    Private Sub cmbusr_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbusr.SelectedIndexChanged
        '  loadTable()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Dim tny As Integer
        tny = MessageBox.Show(
                "Exit from " & Me.Text & "?" & vbNewLine & "Save all outgoing transactions !",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tny = vbYes Then
            Me.Dispose()
        Else
        End If
    End Sub

    Private Sub chpayall_CheckedChanged(sender As Object, e As EventArgs) Handles chpayall.CheckedChanged
        With dgview
            If chpayall.Checked = True Then
                For a As Integer = 0 To dgview.Rows.Count - 1
                    .Rows(a).Cells("CheckCanOpen").Value = vbTrue
                    .Rows(a).Cells("CheckCanAdd").Value = vbTrue
                    .Rows(a).Cells("CheckCanUpdate").Value = vbTrue
                    .Rows(a).Cells("CheckCanDelete").Value = vbTrue
                    .Rows(a).Cells("CheckCanPrint").Value = vbTrue

                    .Rows(a).Cells("CanOpen").Value = "Y"
                    .Rows(a).Cells("CanAdd").Value = "Y"
                    .Rows(a).Cells("CanUpdate").Value = "Y"
                    .Rows(a).Cells("CanDelete").Value = "Y"
                    .Rows(a).Cells("CanPrint").Value = "Y"
                Next
            ElseIf chpayall.Checked = False Then
                For a As Integer = 0 To dgview.Rows.Count - 1
                    .Rows(a).Cells("CheckCanOpen").Value = vbFalse
                    .Rows(a).Cells("CheckCanAdd").Value = vbFalse
                    .Rows(a).Cells("CheckCanUpdate").Value = vbFalse
                    .Rows(a).Cells("CheckCanDelete").Value = vbFalse
                    .Rows(a).Cells("CheckCanPrint").Value = vbFalse

                    .Rows(a).Cells("CanOpen").Value = "N"
                    .Rows(a).Cells("CanAdd").Value = "N"
                    .Rows(a).Cells("CanUpdate").Value = "N"
                    .Rows(a).Cells("CanDelete").Value = "N"
                    .Rows(a).Cells("CanPrint").Value = "N"
                Next
            End If
        End With
    End Sub
End Class