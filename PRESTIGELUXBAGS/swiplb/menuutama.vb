
Public Class menuutama
    'Try
    '  Private compid As String = 
    'Catch : End Try
    '    Private compid As String = ""
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Control.ModifierKeys = Keys.Alt AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.F10)) Then
            'cekform(onlineBCOCI, "NEW", Me)
            '     navprogram.Show()

        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Private Shared Sub Main()
    '    Dim cultureInfo As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
    '    Application.CurrentCulture = cultureInfo
    '    Application.EnableVisualStyles()
    '    'Application.SetCompatibleTextRenderingDefault(False)
    '    Application.Run(New tso())

    'End Sub
    Private Sub menuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dateInfo = Globalization.CultureInfo.CurrentCulture.DateTimeFormat()
        Dim sepDecimal = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        'Panel1.Visible = False
        ' Main()
        Application.CurrentCulture = New Globalization.CultureInfo("EN-US")
        'If dateInfo.ShortDatePattern <> "dd/MM/yyyy" Or sepDecimal <> "." Then
        '    MsgBox("Format Tanggal harus : 'dd/MM/yyyy' " & vbNewLine & _
        '           "Format Separator Decimal harus : '.'" & vbNewLine & _
        '           "Format Separator Pemisah Ribuan harus : ','", _
        '           MsgBoxStyle.Exclamation, "Format Data di Komputer Salah")
        '    Call Shell("rundll32.exe shell32.dll,Control_RunDLL intl.cpl,,4", vbNormalFocus)
        '    Me.Dispose()
        '    Exit Sub
        'End If

        ''--SERIAL KEY MODE CHECK--'
        'If System.IO.File.Exists(cl.dirserfile) = False And System.IO.File.Exists(cl.dirsetfile) = True Then
        '    muvisfalse()
        '    cekform(cgetserial, "NEW", Me)
        '    Exit Sub
        'End If
        'If System.IO.File.Exists(cl.dirsetfile) = False And System.IO.File.Exists(cl.dirserfile) = False Then
        '    muvisfalse()
        '    cekform(dbconfig, "NEW", Me)
        'ElseIf cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'company'")) = "" Then
        '    muvisfalse()
        '    cekform(csetting, "NEW", Me)
        'Else
        '    cekform(login, "NEW", Me)

        '    '--DEVELOPMENT MODE--'


        'End If
        ''-----------------------'



        '--NON SERIAL KEY MODE--'
        If System.IO.File.Exists(cl.dirsetfile) = False Then
            muvisfalse()
            cekform(dbconfig, "NEW", Me)
            'ElseIf cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'company'")) = "" Then
            '    muvisfalse()
            '    cekform(csetting, "NEW", Me)
        Else
            '-----------------------
            cekform(login, "NEW", Me)

            '--DEVELOPMENT MODE--'

            'login.txtusr.Text = "admin"
            'login.txtpass.Text = "admin"
            'login.btnlogin.PerformClick()

            'cekform(tpy, "NEW", Me)
        End If

    End Sub

    Public Sub muvisfalse()
        Me.MenuStrip.Visible = False

        Me.filetsmi.Visible = False
        Me.datatsmi.Visible = False
        Me.historytsmi.Visible = False
        Me.helptsmi.Visible = False

        '------------------------------------------
        Me.loginmi.Visible = False
        Me.logoutmi.Visible = False
        '------------------------------------------ MASTER DATA
        '  Me.mitemmi.Visible = False
        '------------------------------------------

        '------------------------------------------ TRANSACTIONS

        '------------------------------------------ REPORTS

        '------------------------------------------ SETTING
        Me.databaseconfigmi.Visible = False
        Me.companysettingsmi.Visible = False
        Me.changepasswordmi.Visible = False
        Me.usermi.Visible = False
        Me.userprivilagemi.Visible = False
        '  Me.backdbmi.Visible = False
        Me.uploaddatami.Visible = False
        Me.resettransmi.Visible = False
        '------------------------------------------
        Me.userlogmi.Visible = False
        Me.datalogmi.Visible = False
        Me.translogmi.Visible = False
        '------------------------------------------
    End Sub

    Public Sub muvistrue(ByVal idusr As Integer)

        Me.MenuStrip.Visible = True


        Dim dtall As DataTable = cl.table(
            "Select T1.code_capp, T1.name_capp, T2.tp  FROM cusrpriv T1 INNER JOIN capp T2 ON T1.id_capp = T2.id " &
            " WHERE T1.id_cusr = '" & idusr & "' AND T1.canopen = 'Y' ")

        For i As Integer = 0 To dtall.Rows.Count - 1
            With dtall.Rows(i)

                If .Item("tp") = "M" Then : Me.datatsmi.Visible = True
                ElseIf .Item("tp") = "R" Then : Me.laporanmi.Visible = True
                ElseIf .Item("tp") = "C" Then : Me.configtsmi.Visible = True
                ElseIf .Item("tp") = "H" Then : Me.historytsmi.Visible = True
                End If


                If .Item("code_capp") = "mitem" Then : Me.mitemmi.Visible = True

                ElseIf .Item("code_capp") = "dbconf" Then : Me.databaseconfigmi.Visible = True
                ElseIf .Item("code_capp") = "companysetting" Then : Me.companysettingsmi.Visible = True
                ElseIf .Item("code_capp") = "changepass" Then : Me.changepasswordmi.Visible = True
                ElseIf .Item("code_capp") = "user" Then : Me.usermi.Visible = True
                ElseIf .Item("code_capp") = "userpriv" Then : Me.userprivilagemi.Visible = True
                    '  ElseIf .Item("code_capp") = "backupdb" Then : Me.backdbmi.Visible = True
                ElseIf .Item("code_capp") = "uploaddata" Then : Me.uploaddatami.Visible = True
                ElseIf .Item("code_capp") = "resettrans" Then : Me.resettransmi.Visible = True

                ElseIf .Item("code_capp") = "userlog" Then : Me.userlogmi.Visible = True
                ElseIf .Item("code_capp") = "datalog" Then : Me.datalogmi.Visible = True
                ElseIf .Item("code_capp") = "translog" Then : Me.translogmi.Visible = True

                End If
            End With
        Next

        Me.filetsmi.Visible = True
        Me.logoutmi.Visible = True

        Me.helptsmi.Visible = True
        Me.aboutusmi.Visible = True
    End Sub

    Private Sub loginmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginmi.Click
        cekform(login, "NEW", Me)
    End Sub

    Private Sub logoutmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logoutmi.Click
        For Each child As Form In Me.MdiChildren
            child.Close()
        Next child

        cl.openTrans()
        cl.execCmdTrans(
            "EXEC shuserlog " &
            " '" & idusr & "'" &
            " , 'LOGOUT'" &
            " , ''" &
            " , '" & idusr & "'" &
            " ")
        cl.closeTrans(MenuStrip)

        cekform(login, "NEW", Me)
    End Sub
    Private Sub exitmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitmi.Click
        Dim tny As Integer = cl.msgYesNo("Keluar dari aplikasi SWI-PLB ?", "Confirmation")
        If tny = vbYes Then
            Me.Close()
        End If
    End Sub


    Private Sub userprivilagemi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles userprivilagemi.Click
        cekform(usrpriv, "NEW", Me)
    End Sub

    Private Sub usermi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usermi.Click
        cekform(cusr, "NEW", Me)
    End Sub
    Private Sub dbconfigmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles databaseconfigmi.Click
        cekform(dbconfig, "NEW", Me)
    End Sub

    Private Sub changepassmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changepasswordmi.Click
        cekform(changepass, "NEW", Me)
    End Sub

    Private Sub aboutusmi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aboutusmi.Click
        cekform(aboutus, "NEW", Me)
    End Sub

    Private Sub barangmi_Click(sender As System.Object, e As System.EventArgs) Handles mitemmi.Click
        cekform(mitem, "NEW", Me)
    End Sub


    Private Sub CompanySettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles companysettingsmi.Click
        cekform(csetting, "NEW", Me)
    End Sub


    Private Sub backdbmi_Click(sender As System.Object, e As System.EventArgs) 
        SaveFileDialog1.FileName = "SWIBC_" & Format(Now(), "yyyyMMdd") & ".bak"
        SaveFileDialog1.Filter = "bak files (*.bak)|*.bak|All files (*.*)|*.*"
        SaveFileDialog1.RestoreDirectory = True
        Dim res As DialogResult = SaveFileDialog1.ShowDialog()
        If res = DialogResult.Cancel Then
            Exit Sub
        Else
            Dim s As String
            s = SaveFileDialog1.FileName
            cl.execCommand("BACKUP DATABASE " & database & " TO DISK ='" & s & "'")

            cl.msgInform("Success backup database !", "Information")
        End If
    End Sub

    Private Sub resettransmi_Click(sender As System.Object, e As System.EventArgs) Handles resettransmi.Click

    End Sub

    Private Sub uploaddatami_Click(sender As System.Object, e As System.EventArgs) Handles uploaddatami.Click
        cekform(uploadUSER, "NEW", Me)
    End Sub

    Private Sub userlogmi_Click(sender As System.Object, e As System.EventArgs) Handles userlogmi.Click
        cekform(huserlog, "NEW", Me)
    End Sub

    Private Sub datalogmi_Click(sender As System.Object, e As System.EventArgs) Handles datalogmi.Click
        cekform(hmstr, "NEW", Me)
    End Sub

    Private Sub translogmi_Click(sender As System.Object, e As System.EventArgs) Handles translogmi.Click
        cekform(htrans, "NEW", Me)
    End Sub


    Private Sub restoredbmi_Click(sender As Object, e As EventArgs) 
        'open.FileName = "KOPRA_" & Format(Now(), "yyyyMMdd") & ".bak"
        OpenFileDialog1.Filter = "bak files (*.bak)|*.bak|All files (*.*)|*.*"
        OpenFileDialog1.RestoreDirectory = True
        Dim res As DialogResult = OpenFileDialog1.ShowDialog()
        If res = DialogResult.Cancel Then
            Exit Sub
        Else


            Dim s As String
            s = OpenFileDialog1.FileName
            cl.execCommand(" USE [master] " &
                        " ALTER DATABASE SWIBC set SINGLE_USER WITH ROLLBACK IMMEDIATE " &
                            "RESTORE DATABASE " & database & " FROM DISK ='" & s & "' WITH REPLACE")

            'Timer1.Enabled = True
            'ToolStripProgressBar1.Visible = True

            cl.execCommand("ALTER DATABASE SWIBC SET MULTI_USER")

            cl.msgInform("Sukses restore database !" & vbNewLine & "Sistem akan melakukan restart", "Information")

            For Each child As Form In Me.MdiChildren
                child.Close()
            Next child

            cl.openTrans()
            cl.execCmdTrans(
                "EXEC shuserlog " &
                " '" & idusr & "'" &
                " , 'LOGOUT'" &
                " , ''" &
                " , '" & idusr & "'" &
                " ")
            cl.closeTrans(MenuStrip)

            cekform(login, "NEW", Me)
        End If
    End Sub


    Private Sub cprinterconfigmi_Click(sender As Object, e As EventArgs) 
        cekform(cprinterconfig, "NEW", Me)
    End Sub


    Private Sub historytsmi_Click(sender As Object, e As EventArgs) Handles historytsmi.Click

    End Sub

    Private Sub InvoicePenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tinvoicemi.Click
        cekform(tinvoice, "NEW", Me)
    End Sub

    Private Sub ConsignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tconsignmi.Click
        cekform(tconsign, "NEW", Me)
    End Sub

    Private Sub VoucherBiayaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles topaymi.Click
        cekform(topay, "NEW", Me)
    End Sub

    Private Sub ReturPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tretinvoicemi.Click
        cekform(tretinvoice, "NEW", Me)
    End Sub

    Private Sub mtypemi_Click(sender As Object, e As EventArgs) Handles mtypemi.Click
        cekform(mtype, "NEW", Me)
    End Sub

    Private Sub muommi_Click(sender As Object, e As EventArgs) Handles muommi.Click
        cekform(muom, "NEW", Me)
    End Sub

    Private Sub mbrandmi_Click(sender As Object, e As EventArgs) Handles mbrandmi.Click
        cekform(mbrand, "NEW", Me)
    End Sub

    Private Sub mconsigneemi_Click(sender As Object, e As EventArgs) Handles mconsigneemi.Click
        cekform(mconsignee, "NEW", Me)
    End Sub

    Private Sub mcustmi_Click(sender As Object, e As EventArgs) Handles mcustmi.Click
        cekform(mcust, "NEW", Me)
    End Sub

    Private Sub mvendormi_Click(sender As Object, e As EventArgs) Handles mvendormi.Click
        cekform(mvendor, "NEW", Me)
    End Sub

    Private Sub msalesmi_Click(sender As Object, e As EventArgs) Handles msalesmi.Click
        cekform(msales, "NEW", Me)
    End Sub

    Private Sub maccountmi_Click(sender As Object, e As EventArgs) Handles maccountmi.Click
        cekform(maccount, "NEW", Me)
    End Sub

    Private Sub mcoami_Click(sender As Object, e As EventArgs) Handles mcoami.Click
        cekform(mcoa, "NEW", Me)
    End Sub

    Private Sub tbuybackmi_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tpymi.Click
        cekform(tpy, "NEW", Me)
    End Sub

    Private Sub PreOrderPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tpomi.Click
        cekform(tpo, "NEW", Me)
    End Sub

    Private Sub tinvjmi_Click(sender As Object, e As EventArgs) Handles tinvjmi.Click
        cekform(tinvj, "NEW", Me)
    End Sub

    Private Sub TransferLokasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles trfmi.Click
        cekform(trf, "NEW", Me)
    End Sub

    Private Sub tpopmi_Click(sender As Object, e As EventArgs) Handles tpopmi.Click
        cekform(tpop, "NEW", Me)
    End Sub

    Private Sub LaporanPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPenjualanToolStripMenuItem.Click
        cekform(rpenjualan, "NEW", Me)
    End Sub

    Private Sub LaporanCharityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanCharityToolStripMenuItem.Click
        cekform(rcharity, "NEW", Me)
    End Sub

    Private Sub LaporanPreOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPreOrderToolStripMenuItem.Click
        cekform(rpreorder, "NEW", Me)
    End Sub

    Private Sub LaporanPaymentPendingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPaymentPendingToolStripMenuItem.Click
        cekform(rpaypending, "NEW", Me)
    End Sub

    Private Sub LaporanLabaRugiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanLabaRugiToolStripMenuItem.Click
        cekform(rlabarugi, "NEW", Me)
    End Sub

    Private Sub tpcmi_Click(sender As Object, e As EventArgs) Handles tpcmi.Click
        cekform(tpc, "NEW", Me)
    End Sub

    Private Sub tpsmi_Click(sender As Object, e As EventArgs) Handles tpsmi.Click
        cekform(tps, "NEW", Me)
    End Sub

    Private Sub mlocationmi_Click(sender As Object, e As EventArgs) Handles mlocationmi.Click
        cekform(mlocation, "NEW", Me)
    End Sub

    Private Sub LaporanItemLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanItemLedgerToolStripMenuItem.Click
        cekform(rledger, "NEW", Me)
    End Sub

    Private Sub UpdateHargaOwnerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateHargaOwnerToolStripMenuItem.Click
        cekform(mupdownerprice, "NEW", Me)
    End Sub

    Private Sub ttsmi_Click(sender As Object, e As EventArgs) Handles ttsmi.Click
        cekform(tts, "NEW", Me)
    End Sub

    Private Sub mitemjewellmi_Click(sender As Object, e As EventArgs) Handles mitemjewellmi.Click
        cekform(mitemjewell, "NEW", Me)
    End Sub
End Class
