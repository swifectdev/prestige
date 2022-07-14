Imports System.IO

Public Class uploadData

    Private Sub uploadFileBC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbtipefile.SelectedIndex = 0
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            Me.Dispose()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub convertToSQL(ByVal tableName As String)
        Try
            Dim dtTemp As New DataTable
            Dim tempField As String = ""

            If cmbtipefile.Text = "Barang" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BARANG$]")
            ElseIf cmbtipefile.Text = "Partner Bisnis" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [PB$]")
            ElseIf cmbtipefile.Text = "Kantor Pabean" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [KP$]")
            ElseIf cmbtipefile.Text = "Mata Uang" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [MU$]")
            ElseIf cmbtipefile.Text = "Satuan" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [ST$]")
            ElseIf cmbtipefile.Text = "Users" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [USER$]")
            ElseIf cmbtipefile.Text = "Hak Akses" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [HAKAKSES$]")
            ElseIf cmbtipefile.Text = "Chart of Account" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [COA$]")
            ElseIf cmbtipefile.Text = "Grup Barang" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [GRP$]")
            ElseIf cmbtipefile.Text = "BOM - Header" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BOMH$]")
            ElseIf cmbtipefile.Text = "BOM - Detail" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BOMD$]")
            ElseIf cmbtipefile.Text = "JE - Header" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [JEH$]")
            ElseIf cmbtipefile.Text = "JE - Detail" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [JED$]")
            ElseIf cmbtipefile.Text = "DELIVERY - HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [DO$]")
            ElseIf cmbtipefile.Text = "DELIVERY - DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [DOD$]")
            ElseIf cmbtipefile.Text = "PENERIMAAN - HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [REC$]")
            ElseIf cmbtipefile.Text = "PENERIMAAN - DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [RECD$]")
            ElseIf cmbtipefile.Text = "PO - HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [PO$]")
            ElseIf cmbtipefile.Text = "PO - DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [POD$]")
                '--------------------------------------------------------------------------'
            ElseIf cmbtipefile.Text = "GOODS ISSUE HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [GIH$]")
            ElseIf cmbtipefile.Text = "GOODS ISSUE DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [GID$]")
            ElseIf cmbtipefile.Text = "GOODS RECEIPT HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [GRH$]")
            ElseIf cmbtipefile.Text = "GOODS RECEIPT DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [GRD$]")
            ElseIf cmbtipefile.Text = "BC 2.3 HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BC23H$]")
            ElseIf cmbtipefile.Text = "BC 2.3 DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [BC23D$]")
            ElseIf cmbtipefile.Text = "BC 4.0 HEADER" Or cmbtipefile.Text = "BC 4.1 HEADER" Or cmbtipefile.Text = "BC 2.6.2 HEADER" Or cmbtipefile.Text = "BC 2.6.1 HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [HEADER$]")
            ElseIf cmbtipefile.Text = "BC 4.0 DETAIL" Or cmbtipefile.Text = "BC 4.1 DETAIL" Or cmbtipefile.Text = "BC 2.6.2 DETAIL" Or cmbtipefile.Text = "BC 2.6.1 DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [DETAILBRG$]")
            ElseIf cmbtipefile.Text = "BC 4.0 DOK" Or cmbtipefile.Text = "BC 4.1 DOK" Or cmbtipefile.Text = "BC 2.6.2 DOK" Or cmbtipefile.Text = "BC 2.6.1 DOK" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [DETAILDOK$]")
            ElseIf cmbtipefile.Text = "OPNAME - HEADER" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [OPH$]")
            ElseIf cmbtipefile.Text = "OPNAME - DETAIL" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [OPD$]")
            ElseIf cmbtipefile.Text = "EXCHANGE RATE" Then
                dtTemp = cl.gettabeldataexcel(txtDirectory.Text, "SELECT * FROM [EXRATE$]")
                '--------------------------------------------------------------------------'
            End If


            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = 10000
            Dim progressCounter As Integer = 10000 / dtTemp.Rows.Count

            'dgview.DataSource = dtTemp : Exit Sub

            For i As Integer = 0 To dtTemp.Rows.Count - 1
                'If cl.cchr(dtTemp.Rows(i).Item(1)) = "" Then
                '    Continue For
                'End If

                If ProgressBar1.Value < ProgressBar1.Maximum And _
                    ProgressBar1.Value + progressCounter < ProgressBar1.Maximum Then
                    ProgressBar1.Value += progressCounter
                End If


                If tableName = "mitem" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1
                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next

                    Dim sql As String = "INSERT INTO " & tableName &
                    " (code, name, itemtp, id_muom, code_muom, id_muom2, code_muom2, othercode, id_mwhse, code_mwhse, nett, gross, note) " &
                    " VALUES (" & tempField & ") "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mbp" Then

                    For j As Integer = 0 To dtTemp.Columns.Count - 1
                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next

                    Dim sql As String = "INSERT INTO mbp " &
                    " (code, name, bptp, npwp, alamat, alamat2, ijintpb, negara, phn, fax, email, cp, pkp, siup, tdp, kb, tax, tpbc, note) VALUES (" &
                    tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mgrp" Then

                    For j As Integer = 0 To dtTemp.Columns.Count - 1
                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next

                    Dim sql As String = "INSERT INTO mgrp " &
                    " (code, name, id_mcoa1, id_mcoa2, id_mcoa3, id_mcoa4, id_mcoa5, id_mcoa6, id_mcoa7, id_mcoa8, id_mcoa9, id_mcoa10, id_mcoa11, note) VALUES (" &
                    tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mkpabean" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mkpabean " &
                    " (code, name, note) VALUES (" &
                    tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mcurr" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mcurr " &
                    " (code, note) VALUES (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "muom" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next

                    Dim sql As String = "INSERT INTO muom " &
                    " (code, note) VALUES (" &
                    " " & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "cusr" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO cusr " &
                    " (code,name,username,pass,showmenu) VALUES (" &
                    " " & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)
                    cl.execCmdTrans("UPDATE cusr SET pass = CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2) WHERE id <> 1")

                ElseIf tableName = "cusrpriv" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO cusrpriv " &
                    " (id_cusr, id_capp, code_capp, name_capp, canopen, canadd, candelete, canupdate, canprint) VALUES (" &
                    " " & tempField & ")" &
                    " "

                    cl.execCmdTrans("DELETE FROM cusrpriv")
                    cl.execCmdTrans("INSERT INTO cusrpriv (id_cusr, id_capp, code_capp, name_capp, canopen, canadd, candelete, canupdate, canprint) " &
                        "(SELECT TA.id, TB.id, TB.code, TB.name, 'Y', 'Y','Y','Y','Y' FROM cusr TA, capp TB)")
                    cl.execCmdTrans(sql)



                ElseIf tableName = "mcoa" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mcoa " &
                    " (code, name, category, id_mcoap, active, balance, dc, rpttype, rptcattype, bgnbalance, note) VALUES (" &
                    " " & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mrate" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mrate " &
                    " (tdate, id_mcurr, code_mcurr, rate, ratetype, note) VALUES (" &
                    " " & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tgi" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tgi " &
                    " (no, tdate, refno, note, createduser, id_bc, type_bc, no_bc) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tgid" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tgid " &
                    " (idh, no_tgi, id_mitem, code_mitem, name_mitem, id_muom, code_muom, qty, id_mwhse, code_mwhse, price, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mbom" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mbom " &
                    " (id_mitm, name_mitm, qty, id_muom, name_muom, id_mwhse, name_mwhse, note) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "mbomd" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO mbomd " &
                    " (id_mbom, id_mitmp, name_mitmp, linenum, id_mitm, name_mitm, qty, id_muom, name_muom, id_mwhse, name_mwhse, note) VALUES " &
                    "( " & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tje" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tje " &
                    " (no, tdate, refno, refno2, refno3, id_mjetype, name_mjetype, id_source, source_no, id_mcurr, code_mcurr, exrate, id_mcost, name_mcost, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tjed" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tjed " &
                    " (idh, no_tje, id_mcoa, code_mcoa, name_mcoa, debit, credit, debitfc, creditfc, refno, refno2, refno3, id_mcost, code_mcost, id_mcurr, code_mcurr, exrate, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tdo" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tdo " &
                    " (no, tdt, tdt2, tdt3, refno, addr1, addr2, id_mcust, id_mcust2, grdtotal, grdtotal2, id_mcurr, exrate, typebc, nobc, noaju, tdtbc, doctype, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tdod" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tdod " &
                    " (id_tdoh, no_tdoh, linenum, id_mitm, qty, id_muom, price, price2, subtotal, subtotal2, id_mwhse, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "trec" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO trec " &
                    " (no, tdt, tdt2, refno, id_msupp, addr1, addr2, grdtotal, grdtotal2, id_mcurr, exrate, typebc, nobc, noaju, tdtbc, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "trecd" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO trecd " &
                    " (id_trech, no_trech, linenum, id_mitm, qty, id_muom, price, price2, subtotal, subtotal2, id_mwhse, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tpo" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tpo " &
                    " (no, tdt, tdt2, id_msupp, addr1, addr2, taxtotal, grdtotal, grdtotal2, id_mcurr, exrate, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tpod" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tpod " &
                    " (id_tpoh, no_tpoh, linenum, id_mitm, qty, id_muom, price, price2, subtotal, subtotal2, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tgr" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tgr " &
                    " (no, tdate, refno, note, createduser, id_bc, type_bc, no_bc) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tgrd" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tgrd " &
                    " (idh, no_tgr, id_mitem, code_mitem, name_mitem, id_muom, code_muom, qty, id_mwhse, code_mwhse, price, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc23h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc23h " &
                    " (NoPengajuan, KantorPabean, Tujuan, JenisBarang, TujuanPengiriman, NoPendaftaran, TglPendaftaran, PemasokNama, PemasokAlamat, " &
                    " PemasokNegara, ImportirNama, ImportirNPWP, ImportAlamat, Valuta, NPDBM, " &
                    " BeratKotor, BeratBersih, CIF, CIFIDR, note, creadetuser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc23d" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc23d " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, NegaraAsal, Tarif, Qty, Satuan, CIF, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc25h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc25h " &
                    " (NoPengajuan, NoAsal, BPAsal, KantorPabean, JenisTPB, NoPendaftaran, TglPendaftaran, JenisBC25, KondisiBarang, " &
                    " TPBNPWP, TPBNama, TPBAlamat, TPBIjin, PBNPWP, PBNama, PBAlamat, Invoice, TglInvoice, PackList, TglPackList, Kontrak, " &
                    " TglKontrak, SKP, TglSKP, DokLainnya, TglDokLainnya, JVA, NDPBM, NilaiCIFUSD, NilaiCIFIDR, HargaPenyerahan, " &
                    " JenisKmsn, MerkKmsn, JmlKmsn, Volume, BeratKotor, BeratBersih, BM, Cukai, PPN, PPNBM, PPH, PNBP, Denda, " &
                    " Bunga, Total, BM2, Cukai2, PPN2, PPNBM2, PPH2, PNBP2, Denda2, Bunga2, Total2, SSPCP, NTB1, tglNTB1, NTPN1, " &
                    " tglNTPN1, SSP, NTB2, tglNTB2, NTPN2, tglNTPN2, NmPejabat, NIP, PengusahaTPB, TempatTPB, TglTPB, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc25di" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc25di " &
                    " (idh, NoPengajuan, LineNum, Kode, NegaraAsal, SkemaTarif, Nama, Qty, UoM, CIF, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc25dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc25dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc40h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc40h " &
                    " (NoPengajuan, NoAsal, BPAsal, KantorPabean, JenisTPB, TujuanPengiriman, NoPendaftaran, TglPendaftaran, TPBNPWP, TPBNama, " &
                    " TPBAlamat, TPBIjin, PBNPWP, PBNama, PackList, TglPackList, Kontrak, TglKontrak, SKP, TglSKP, DokLainnya, TglDokLainnya, " &
                    " JSPD, NoPol, HargaPenyerahan, JenisKmsn, JmlKmsn, Volume, BeratKotor, BeratBersih, NmPejabat, NIP, PengusahaTPB, TempatTPB, TglTPB, Currency, " &
                    " note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc40di" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc40di " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Qty, UoM, CIF, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc40dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc40dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc41h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc41h " &
                    " (NoPengajuan, NoAsal, BPAsal, KantorPabean, JenisTPB, TujuanPengiriman, NoPendaftaran, TglPendaftaran, TPBNPWP, TPBNama, " &
                    " TPBAlamat, TPBIjin, PBNPWP, PBNama, PackList, TglPackList, Kontrak, TglKontrak, SKP, TglSKP, DokLainnya, TglDokLainnya, " &
                    " JSPD, NoPol, HargaPenyerahan, JenisKmsn, JmlKmsn, Volume, BeratKotor, BeratBersih, NmPejabat, NIP, PengusahaTPB, TempatTPB, TglTPB, Currency, " &
                    " note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc40di" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc41di " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Qty, UoM, CIF, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc40dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc41dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc40dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc40dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc27oh" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27oh " &
                    " (NoPengajuan, NoAsal, KPBAsal, KPBTujuan, JenisTPBAsal,  JenisTPBTujuan, TujuanPengiriman, NoPendaftaranBC, TglDaftarBC, " &
                    " TPBAsalNPWP, TPBAsalNama, TPBAsalAlamat, TPBAsalIjin, TPBTujuanNPWP, TPBTujuanNama, TPBTujuanAlamat, TPBTujuanIjin, Invoice, TglInvoice, " &
                    " PackList,TglPackList, Kontrak, TglKontrak, SJ, TglSJ, SKP, TglSKP, Lainnya, TglLainnya, NoTglBC27Asal, JVA, HargaPenyerahan, JSPD, NoPol,  " &
                    " JmlKmsn, JenisKmsn, NoSegel, Jenis, CatBCTujuan, Volume, BeratKotor, BeratBersih, tmptPengusahaTPB, TglTPB, NmPengusahaTPB, " &
                    " NmPejabatKPAsal, NmPejabatKPTuj, NIPPejabatKPTuj, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc27odi" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27odi " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Qty, UoM, CIF, exBCId, exBCNo, exBCType, exBCidh, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc27odd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27odd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc27ih" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27ih " &
                    " (NoPengajuan, NoAsal, KPBAsal, KPBTujuan, JenisTPBAsal, JenisTPBTujuan, TujuanPengiriman, NoPendaftaranBC, " &
                    " TglDaftarBC, TPBAsalNPWP, TPBAsalNama, TPBAsalAlamat, TPBAsalIjin, TPBTujuanNPWP, TPBTTujuanNama, TPBTujuanAlamat, " &
                    " TPBTujuanIjin, Invoice, TglInvoice, PackList, TglPackList, Kontrak, TglKontrak, SJ, TglSJ, SKP, TglSKP, Lainnya, " &
                    " TglLainnya, NoTglBC27Asal, JVA, HargaPenyerahan, JSPD, NoPol, JmlKsmn, JenisKmsn, NoSegel, Jenis, CatBCTujuan, Volume, " &
                    " BeratKotor, BeratBersih, tmptPengusahaTPB, TglTPB, NmPengusahaTPB, NmPejabatKPAsal, " &
                    " NIPPejabatKPAsal, NmPejabatKPTuj, NIPPejabatKPTuj, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc27odi" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27odi " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Qty, UoM, CIF, exBCId, exBCNo, exBCType, exBCidh, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc27odd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc27odd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc262h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc262h " &
                    " (NoPengajuan, NoPengajuanGen, NoAsal, KantorPabean, JenisTPB, TujuanPengiriman, NoPendaftaran, TglPendaftaran, " &
                    " TPBNPWP, TPBNama, TPBAlamat, TPBIjin, PBNPWP, PBNama, PBAlamat, PackLIst, SJ, TglISJ, Kontrak, TglKontrak, SKP, " &
                    " JSPD, NoPol, JVA, nilaiCIF, CIF, JenisKmsn, MerkKmsn, JmlKmsn, JenisJmlKmsn, Volume, BeratKotor, BeratBersih, BM, " &
                    " Cukai, PPN, PPNBM, PPH, Total, JnJam, NoJam, TglNoJam, NilJam, TglJatuhTempo, Penjamin, BPJ, TglBPJ, NamaPejabat, NIP, " &
                    " TempatTPB, TglTPB, PengusahaTPB, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc262di" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc262di " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Qty, UoM, CIF, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc262dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc262dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc261h" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc261h " &
                    " (NoPengajuan, NoAsal, KantorPabean, JenisTPB, TujuanPengiriman, NoPendaftaran, TglPendaftaran, TPBNPWP, " &
                    " TPBNama, TPBAlamat, TPBIjin, PBNPWP, PBNama, PBAlamat, PackList, Kontrak, TglKontrak, DocLainnya, TglDocLainnya, " &
                    " SKP, TglSKP, JSPD, NoPol, JVA, nilaiCIF, NDPBN, JenisKmsn, MerkKsmsn, JmlKsmn, JenisJmlKmsn, Volume, BeratKotor, " &
                    " BertaBersih, BM, Cukai, PPn, PPNBM, PPH, Total, JnJam, NoJam, TglNojam, NilJam, TglJatuhTempo, Penjamin, BPJ, TglBPJ, " &
                    " NamaPejabat, NIP, TempatTPB, TglTPB, PengusahaTPB, note, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)
                ElseIf tableName = "tbc261di" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc261di " &
                    " (idh, NoPengajuan, LineNum, HS, Kode, Nama, Negara, Skema, Qty, UoM, CIF, note, tstatus, createduser) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tbc261dd" Then
                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tbc261dd " &
                    " (idh, NoPengajuan, LineNum, JnDok, NoDok, TglDok, note, createduser)) VALUES " &
                    " " & tempField & "" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tsopname" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tsopname " &
                    " (no, tdate, id_mcost, note) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)

                ElseIf tableName = "tsopnamed" Then
                    'dgview.DataSource = dtTemp
                    'Exit Sub

                    For j As Integer = 0 To dtTemp.Columns.Count - 1

                        If j = dtTemp.Columns.Count - 1 Then
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "''"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "'"
                            End If
                        Else
                            If IsDBNull(dtTemp.Rows(i).Item(j)) Then : tempField += "'',"
                            Else : tempField += "'" + cl.cchr(dtTemp.Rows(i).Item(j)) + "',"
                            End If
                        End If
                    Next


                    Dim sql As String = "INSERT INTO tsopnamed " &
                    " (idh, no_tsopname, id_mitem, code_mitem, name_mitem, id_muom, code_muom, name_muom, stock, so, soresult, id_mcost, name_mcost, note, createduser) VALUES " &
                    " (" & tempField & ")" &
                    " "

                    cl.execCmdTrans(sql)
                End If

                tempField = ""

            Next

            dtTemp.Clear()
            ProgressBar1.Value = 10000

        Catch ex As Exception
            MessageBox.Show("Cannot copy file from disk to BC System. Original error : " & ex.Message)

            Exit Sub
        End Try
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If txtDirectory.Text = "" Then
            MsgBox("Direktori File belum diisi !", MsgBoxStyle.Information, "Gagal Upload")
            Exit Sub
        End If

        Try
            If cmbtipefile.Text = "Barang" Then
                cl.openTrans()
                convertToSQL("mitem")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Barang", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Partner Bisnis" Then
                cl.openTrans()
                convertToSQL("mbp")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Partner Bisnis", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Kantor Pabean" Then
                cl.openTrans()
                convertToSQL("mkpabean")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload file Kantor Pabean", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Mata Uang" Then
                cl.openTrans()
                convertToSQL("mcurr")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Mata Uang", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Satuan" Then
                cl.openTrans()
                convertToSQL("muom")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Satuan", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Users" Then
                cl.openTrans()
                convertToSQL("cusr")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Users", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Chart of Account" Then
                cl.openTrans()
                convertToSQL("mcoa")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Chart of Account", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "EXCHANGE RATE" Then
                cl.openTrans()
                convertToSQL("mrate")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Exchange Rates", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "Grup Barang" Then
                cl.openTrans()
                convertToSQL("mgrp")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Grup Barang", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BOM - Header" Then
                cl.openTrans()
                convertToSQL("mbom")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BOM Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BOM - Detail" Then
                cl.openTrans()
                convertToSQL("mbomd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BOM Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "GOODS ISSUE HEADER" Then
                cl.openTrans()
                convertToSQL("tgi")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Goods Issue Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "GOODS ISSUE DETAIL" Then
                cl.openTrans()
                convertToSQL("tgid")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Goods Issue Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "GOODS RECEIPT HEADER" Then
                cl.openTrans()
                convertToSQL("tgr")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Goods Receipt Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "GOODS RECEIPT DETAIL" Then
                cl.openTrans()
                convertToSQL("tgrd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Goods Receipt Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "JE - Header" Then
                cl.openTrans()
                convertToSQL("tje")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Journal Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "JE - Detail" Then
                cl.openTrans()
                convertToSQL("tjed")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Journal Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "DELIVERY - HEADER" Then
                cl.openTrans()
                convertToSQL("tdo")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Delivery Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "DELIVERY - DETAIL" Then
                cl.openTrans()
                convertToSQL("tdod")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Delivery Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "PENERIMAAN - HEADER" Then
                cl.openTrans()
                convertToSQL("trec")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Penerimaan Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "PENERIMAAN - DETAIL" Then
                cl.openTrans()
                convertToSQL("trecd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Penerimaan Detail", "Success Upload")
                End If

            ElseIf cmbtipefile.Text = "OPNAME - HEADER" Then
                cl.openTrans()
                convertToSQL("tsopname")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Penerimaan Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "OPNAME - DETAIL" Then
                cl.openTrans()
                convertToSQL("tsopnamed")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload Penerimaan Detail", "Success Upload")
                End If

            ElseIf cmbtipefile.Text = "PO - HEADER" Then
                cl.openTrans()
                convertToSQL("tpo")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload PO Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "PO - DETAIL" Then
                cl.openTrans()
                convertToSQL("tpod")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload PO Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.3 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc23h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.3 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.3 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc23d")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.3 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.5 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc25h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.5 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.5 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc25di")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.5 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.0 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc40h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.0 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.0 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc40di")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.1 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.0 DOK" Then
                cl.openTrans()
                convertToSQL("tbc40dd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.1 Dokumen", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.1 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc41h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.1 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.1 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc41di")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.1 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 4.1 DOK" Then
                cl.openTrans()
                convertToSQL("tbc41dd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 4.1 Dokumen", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.2 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc262h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.2 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.2 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc262di")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.2 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.2 DOK" Then
                cl.openTrans()
                convertToSQL("tbc262dd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.2 Dokumen", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.1 HEADER" Then
                cl.openTrans()
                convertToSQL("tbc261h")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.1 Header", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.1 DETAIL" Then
                cl.openTrans()
                convertToSQL("tbc261di")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.1 Detail", "Success Upload")
                End If
            ElseIf cmbtipefile.Text = "BC 2.6.1 DOK" Then
                cl.openTrans()
                convertToSQL("tbc261dd")
                cl.closeTrans(btnBrowse)
                If cl.sCloseTrans = 1 Then
                    cl.msgInform("Success upload BC 2.6.1 Dokumen", "Success Upload")
                End If
            Else
                cl.msgError("Failed upload file Excel to System", "Failed Upload")
            End If

            ProgressBar1.Value = 0
            txtDirectory.Clear()
        Catch ex As Exception
            MessageBox.Show("Cannot copy file from disk to System. Original error : " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "C:"
        openFileDialog1.Filter = "All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 4
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    txtDirectory.Text = openFileDialog1.FileName
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file Excel from disk. Original error : " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnRESET_Click(sender As System.Object, e As System.EventArgs) Handles btnRESET.Click
        'With cl
        '    If cmbtipefile.SelectedIndex = 0 Then
        '        Dim tny As Integer
        '        tny = MessageBox.Show("Delete data from table BC 2.3. This process is irreversible ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If tny = vbYes Then
        '            .openTrans()
        '            .execCmdTrans("DELETE FROM tblBC23Hdr")
        '            .execCmdTrans("DELETE FROM tblBC23Dtl")
        '            .closeTrans(btnRESET)
        '            If .sCloseTrans = 1 Then
        '                MsgBox("Success DELETE data from table BC 2.3", MsgBoxStyle.Information, "Success upload file B25")
        '            End If
        '        End If
        '    ElseIf cmbtipefile.SelectedIndex = 1 Then
        '        Dim tny As Integer
        '        tny = MessageBox.Show("Delete data from table BC 2.5. This process is irreversible ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If tny = vbYes Then
        '            .openTrans()
        '            .execCmdTrans("DELETE FROM tblBC25Hdr")
        '            .execCmdTrans("DELETE FROM tblBC25Dtl")
        '            .closeTrans(btnRESET)
        '            If .sCloseTrans = 1 Then
        '                MsgBox("Success DELETE data from table BC 2.5", MsgBoxStyle.Information, "Success upload file B25")
        '            End If
        '        End If
        '    ElseIf cmbtipefile.SelectedIndex = 2 Then
        '        Dim tny As Integer
        '        tny = MessageBox.Show("Delete data from table BC 3.0. This process is irreversible ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If tny = vbYes Then
        '            .openTrans()
        '            .execCmdTrans("DELETE FROM tblBC30Hdr")
        '            .execCmdTrans("DELETE FROM tblBC30Dtl")
        '            .closeTrans(btnRESET)
        '            If .sCloseTrans = 1 Then
        '                MsgBox("Success DELETE data from table BC 3.0", MsgBoxStyle.Information, "Success upload file B25")
        '            End If
        '        End If
        '    End If
        'End With
    End Sub
End Class