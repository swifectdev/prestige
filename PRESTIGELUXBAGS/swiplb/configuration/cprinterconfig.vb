Imports System.Drawing.Printing
Public Class cprinterconfig
    Dim idmaster As Integer = 0, statform As String = ""

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
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub loadPrinter()
        Try
            For Each printer As String In PrinterSettings.InstalledPrinters
                cmbPrinterTrans.Items.Add(printer)
            Next printer

        Catch ex As Exception
            MessageBox.Show("Error di dalam Tampilkan Printer !" & vbNewLine & vbNewLine & ex.ToString)
            menuutama.Dispose()
        End Try
    End Sub

    Private Sub loadSizePrinterTrans()
        Try
            Dim docToPrintTrans As New System.Drawing.Printing.PrintDocument()
            cmbSizePrinterTrans.Items.Clear()
            If cmbPrinterTrans.Text <> "" Then




                docToPrintTrans.PrinterSettings.PrinterName = cmbPrinterTrans.Text
                For i = 0 To docToPrintTrans.PrinterSettings.PaperSizes.Count - 1
                    cmbSizePrinterTrans.Items.Add(docToPrintTrans.PrinterSettings.PaperSizes(i).RawKind & " - " & docToPrintTrans.PrinterSettings.PaperSizes(i).PaperName)
                    '    Dim dtemptp As DataTable = cl.table(docToPrintTrans.PrinterSettings.PaperSizes(i).PaperName)
                    '  cmbSizePrinterTrans.DataSource = docToPrintTrans.PrinterSettings.PaperSizes(i).RawKind
                    'cmbSizePrinterTrans.ValueMember = docToPrintTrans.PrinterSettings.PaperSizes(i).RawKind
                    'cmbSizePrinterTrans.DisplayMember = docToPrintTrans.PrinterSettings.PaperSizes(i).PaperName
                    ' MsgBox(cmbSizePrinterTrans.SelectedValue)
                    ' cmbSizePrinterTrans.Items.Add()
                    'cmbSizePrinterTrans.DisplayMember = ""
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error di dalam Tampilkan Size Printer Trans !" & vbNewLine & vbNewLine & ex.ToString)
            menuutama.Dispose()
        End Try
    End Sub

    Private Sub loadisisetting()
        cmbPrinterTrans.Text = cl.readData("SELECT strvl FROM csetting WHERE name = 'Printer Transaksi'")

        cmbSizePrinterTrans.Text = cl.readData("SELECT strvl FROM csetting WHERE name = 'Size Printer Transaksi'")

        If cl.readData("SELECT strvl FROM csetting WHERE name = 'Cetak Langsung Printer Transaksi'") = "Y" Then
            cbCLPrintTrans.Checked = True : Else : cbCLPrintTrans.Checked = False : End If

    End Sub
    Private Sub cprinterconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' loadbranch()
        loadPrinter()
        loadisisetting()
    End Sub

    Private Sub cmbPrinterTrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinterTrans.SelectedIndexChanged
        loadSizePrinterTrans()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim frm As New cprinterconfig
        cekform(frm, "REFRESH", Me)
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim CLPrintTrans As String = ""
        If cbCLPrintTrans.Checked = True Then : CLPrintTrans = "Y"
        ElseIf cbCLPrintTrans.Checked = False Then : CLPrintTrans = "N" : End If

        Dim tny As Integer
        tny = MessageBox.Show(
            "Apakah anda akan menyimpan Data Setting ini ?",
            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tny = vbYes Then
            cl.openTrans()
            cl.execCmdTrans(
                 "UPDATE csetting SET " &
                " strvl = '" & cmbPrinterTrans.Text & "'" &
                " WHERE name = 'Printer Transaksi'")
            cl.execCmdTrans(
                 "UPDATE csetting SET " &
                " intvl = '" & cl.cnum(Replace(Replace(Mid(cmbSizePrinterTrans.Text, 1, 3), " ", ""), "-", "")) & "'" &
                " WHERE name = 'Size Printer Transaksi'")
            cl.execCmdTrans(
                 "UPDATE csetting SET " &
                " strvl = '" & cmbSizePrinterTrans.Text & "'" &
                " WHERE name = 'Size Printer Transaksi'")
            cl.execCmdTrans(
                "UPDATE csetting SET " &
                " strvl = '" & CLPrintTrans & "'" &
                " WHERE name = 'Cetak Langsung Printer Transaksi'")


            cl.closeTrans(cmbPrinterTrans)

            If cl.sCloseTrans = 1 Then
                MsgBox("Sukses menyimpan Data Konfigurasi Sistem !", MsgBoxStyle.Information, "Berhasil Menyimpan Data")

                For Each child As Form In menuutama.MdiChildren
                    child.Close()
                Next child
                menuutama.MenuStrip.Visible = False

                cekform(login, "NEW", Me)
            End If
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub
End Class