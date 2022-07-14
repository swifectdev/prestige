Public Class navprogram

    Private Sub navprogramtemp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TREEVIEW DESIGN
            Me.tvmenu.ShowRootLines = False
            Me.tvmenu.ShowLines = False
            Me.tvmenu.ShowPlusMinus = False
            Me.tvmenu.FullRowSelect = True
            Me.tvmenu.ItemHeight = 32


            Dim tblmasterdata As DataTable = cl.table(
           "SELECT T2.code, T2.name, T2.tpchild FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp=T2.id " &
           " WHERE T1.id_cusr = " & idusr & " AND T2.tp = 'M' AND T1.canopen = 'Y'")

            Dim tbltransaction As DataTable = cl.table(
            "SELECT T2.code, T2.name, T2.tpchild FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp=T2.id " &
            " WHERE T1.id_cusr = " & idusr & " AND T2.tp = 'T' AND T1.canopen = 'Y'")

            Dim tblconfig As DataTable = cl.table(
           "SELECT T2.code, T2.name, T2.tpchild FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp=T2.id " &
           " WHERE T1.id_cusr = " & idusr & " AND T2.tp = 'C' AND T1.canopen = 'Y'")

            Dim tblhistory As DataTable = cl.table(
           "SELECT T2.code, T2.name, T2.tpchild FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp=T2.id " &
           " WHERE T1.id_cusr = " & idusr & " AND T2.tp = 'H' AND T1.canopen = 'Y'")

            Dim tblreport As DataTable = cl.table(
           "SELECT T2.code, T2.name, T2.tpchild FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp=T2.id " &
           " WHERE T1.id_cusr = " & idusr & " AND T2.tp = 'R' AND T1.canopen = 'Y'")

            If tblmasterdata.Rows.Count > 0 Or tbltransaction.Rows.Count > 0 _
            Or tblconfig.Rows.Count > 0 Or tblreport.Rows.Count > 0 Then

                Dim statnodeprice As Integer = 0
                If tblmasterdata.Rows.Count > 0 Then
                    tvmenu.Nodes.Add("masterdata", "MASTER DATA")
                    For i As Integer = 0 To tblmasterdata.Rows.Count - 1
                        tvmenu.Nodes("masterdata").Nodes.Add(tblmasterdata.Rows(i).Item("code"), tblmasterdata.Rows(i).Item("name"))
                    Next
                End If

                Dim statnodepur As Integer = 0, statnodesales As Integer = 0, statnodepayment As Integer = 0,
                statnodeacc As Integer = 0, statnodeinv As Integer = 0

                If tbltransaction.Rows.Count > 0 Then
                    tvmenu.Nodes.Add("transaction", "TRANSAKSI")
                    For i As Integer = 0 To tbltransaction.Rows.Count - 1
                        tvmenu.Nodes("transaction").Nodes.Add(tbltransaction.Rows(i).Item("code"), tbltransaction.Rows(i).Item("name"))
                    Next
                End If


                If tblconfig.Rows.Count > 0 Then
                    tvmenu.Nodes.Add("config", "CONFIG")
                    For i As Integer = 0 To tblconfig.Rows.Count - 1
                        tvmenu.Nodes("config").Nodes.Add(tblconfig.Rows(i).Item("code"), tblconfig.Rows(i).Item("name"))
                    Next
                End If

                If tblhistory.Rows.Count > 0 Then
                    tvmenu.Nodes.Add("history", "HISTORY")
                    For i As Integer = 0 To tblhistory.Rows.Count - 1
                        tvmenu.Nodes("history").Nodes.Add(tblhistory.Rows(i).Item("code"), tblhistory.Rows(i).Item("name"))
                    Next
                End If

                If tblreport.Rows.Count > 0 Then
                    tvmenu.Nodes.Add("laporan", "LAPORAN")
                    For i As Integer = 0 To tblreport.Rows.Count - 1
                        tvmenu.Nodes("laporan").Nodes.Add(tblreport.Rows(i).Item("code"), tblreport.Rows(i).Item("name"))
                    Next
                End If
            End If


            Me.tvmenu.Nodes("masterdata").ImageIndex = 0
            Me.tvmenu.Nodes("masterdata").SelectedImageIndex = 1
            Me.tvmenu.Nodes("transaction").ImageIndex = 0
            Me.tvmenu.Nodes("transaction").SelectedImageIndex = 1
            Me.tvmenu.Nodes("config").ImageIndex = 0
            Me.tvmenu.Nodes("config").SelectedImageIndex = 1
            Me.tvmenu.Nodes("history").ImageIndex = 0
            Me.tvmenu.Nodes("history").SelectedImageIndex = 1
            Me.tvmenu.Nodes("laporan").ImageIndex = 0
            Me.tvmenu.Nodes("laporan").SelectedImageIndex = 1


            Me.SetBounds(0, 0, Me.Width, Me.Height)
        Catch : End Try
    End Sub
    Private Sub enterMenu()
        Try
            Dim frm As New Form
            Dim Tfrm As String = tvmenu.SelectedNode.Name.ToString

            '  master Data
            If Tfrm = "maccount" Then : frm = maccount
            ElseIf Tfrm = "muom" Then : frm = muom
            ElseIf Tfrm = "mbrand" Then : frm = mbrand
            ElseIf Tfrm = "mconsignee" Then : frm = mconsignee
            ElseIf Tfrm = "mcust" Then : frm = mcust
            ElseIf Tfrm = "mcurr" Then : frm = mcurr
            ElseIf Tfrm = "mitem" Then : frm = mitem
            ElseIf Tfrm = "mtype" Then : frm = mtype
            ElseIf Tfrm = "mvendor" Then : frm = mvendor
                '  ElseIf Tfrm = "mcoa" Then : frm = mcoa
            ElseIf Tfrm = "msales" Then : frm = msales
            ElseIf Tfrm = "mlocation" Then : frm = mlocation

                'transactions
                'ElseIf Tfrm = "tconsign" Then : frm = tconsign
            ElseIf Tfrm = "tinvoice" Then : frm = tinvoice
            ElseIf Tfrm = "tretinvoice" Then : frm = tretinvoice
            ElseIf Tfrm = "topay" Then : frm = topay
                ' ElseIf Tfrm = "tje" Then : frm = tje
            ElseIf Tfrm = "tpo" Then : frm = tpo
            ElseIf Tfrm = "tpop" Then : frm = tpop
            ElseIf Tfrm = "trf" Then : frm = trf
            ElseIf Tfrm = "tpy" Then : frm = tpy
            ElseIf Tfrm = "tpc" Then : frm = tpc
            ElseIf Tfrm = "tps" Then : frm = tps

                'reports
            ElseIf Tfrm = "rsales" Then : frm = rpenjualan
            ElseIf Tfrm = "rcharity" Then : frm = rcharity
            ElseIf Tfrm = "rpreorder" Then : frm = rpreorder
            ElseIf Tfrm = "rpaypending" Then : frm = rpaypending
                '  ElseIf Tfrm = "rstock" Then : frm = rledger
            ElseIf Tfrm = "rbukubesar" Then : frm = rledger
            ElseIf Tfrm = "rlabarugi" Then : frm = rlabarugi
                'ElseIf Tfrm = "tks1" Then
                '    If Format(Now(), "yyyyMMdd") = "20160610" Then
                '        cl.msgError("Versi trial selesai!", "Information")
                '        Exit Sub
                '    End If

                '    frm = lapkartustock
            End If

            If frm.Name <> "" Then
                    cekform(frm, "NEW", Me)
                End If
        Catch : End Try
    End Sub

    Private Sub tvmenu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvmenu.DoubleClick
        enterMenu()
    End Sub

    Private Sub tvmenu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tvmenu.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
        '    enterMenu()
        'End If
    End Sub

    Private Sub btnleft_Click(sender As Object, e As EventArgs) Handles btnleft.Click
        Me.Hide()
    End Sub
End Class