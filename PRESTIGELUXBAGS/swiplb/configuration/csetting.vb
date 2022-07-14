Imports System.IO
Imports System.Drawing.Printing
Public Class csetting
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
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F3) Then
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F4) Then
        ElseIf Control.ModifierKeys = Keys.Alt AndAlso (msg.WParam.ToInt32 = Convert.ToInt32(Keys.F10)) Then
            Label15.Visible = True
            dtexpiry.Visible = True
            btnsaveexpiry.Visible = True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub clearData()
        cmbjeniscompany.SelectedIndex = 0
        txtcompany.Text = ""
        txtowner.Text = ""
        txtalamat.Text = ""
        txtnoijintpb.Text = ""
        txtphone.Text = ""
        txtfax.Text = ""
        txtNPWP.Text = ""
        txtlogo.Text = ""
        PictureBox1.Visible = False
        cherp.Checked = False

        cmbitemcosting.SelectedIndex = 0
        cmbacctype.SelectedIndex = 0
        cmbonline.SelectedIndex = 0
        cmbautopost.SelectedIndex = 0
    End Sub

    Private Sub loadData()
        With cl
            cmbjeniscompany.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'jeniscompany'"))
            txtcompany.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'company'"))
            txtowner.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'owner'"))
            txtalamat.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'alamat'"))
            txtnoijintpb.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'noijintpb'"))
            txtphone.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'phone'"))
            txtfax.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'fax'"))
            txtNPWP.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'npwp'"))
            txtnegara.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'negara'"))
            txtlogo.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'logolocation'"))
            nudecimal.Value = .cchr(.readData("SELECT intvl FROM csetting WHERE name = 'decimal'"))
            cmbcompanycode.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'companycode'"))

            cmbonline.Text = Mid(.cchr(.readData("SELECT strvl FROM csetting WHERE name = 'online'")), 1, 1)

            cmbstockminus.Text = Mid(.cchr(.readData("SELECT strvl FROM csetting WHERE name = 'stock'")), 1, 1)

            cmbnobckey.SelectedValue = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'nobckey'"))

            txtcompid.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'companyid'"))
            cmbcurrency.SelectedValue = .cnum(.readData("SELECT intvl FROM csetting WHERE name = 'currency'"))

            cmbacctype.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'acctype'"))
            cmbitemcosting.Text = .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'itemcost'"))

            txtipset.Text = .cchr(.readData("SELECT ipset FROM ctpb"))

            If .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'online'")) = "Y" Then
                cmbonline.SelectedIndex = 0
            Else
                cmbonline.SelectedIndex = 1
            End If

            If .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'stock'")) = "Y" Then
                cmbstockminus.SelectedIndex = 0
            Else
                cmbstockminus.SelectedIndex = 1
            End If

            If .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'ERP'")) = "Y" Then
                cherp.Checked = True
            Else
                cherp.Checked = False
            End If

            If .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'autopost'")) = "Y" Then
                cmbautopost.SelectedIndex = 0
            Else
                cmbautopost.SelectedIndex = 1
            End If

            If .cchr(.readData("SELECT strvl FROM csetting WHERE name = 'autoprint'")) = "Y" Then
                cmbautoprint.SelectedIndex = 0
            Else
                cmbautoprint.SelectedIndex = 1
            End If


            'load logo here
            If System.IO.File.Exists(dirImgFilePath & "\" & cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'logolocation'"))) = True Then
                Dim fs As System.IO.FileStream
                fs = New System.IO.FileStream(dirImgFilePath & "\" & cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'logolocation'")),
                     IO.FileMode.Open, IO.FileAccess.Read)
                PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                fs.Dispose()
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Else : PictureBox1.Image = Nothing
            End If

            'LOAD PRINTER
            Try
                For Each printer As String In PrinterSettings.InstalledPrinters
                    cmbPrinterTrans.Items.Add(printer)
                Next printer

            Catch ex As Exception
                MessageBox.Show("Error di dalam Tampilkan Printer !" & vbNewLine & vbNewLine & ex.ToString)
                menuutama.Dispose()
            End Try

            'LOAD PAPER
            Try
                Dim docToPrintTrans As New System.Drawing.Printing.PrintDocument()
                cmbSizePrinterTrans.Items.Clear()
                If cmbPrinterTrans.Text <> "" Then
                    docToPrintTrans.PrinterSettings.PrinterName = cmbPrinterTrans.Text
                    For i = 0 To docToPrintTrans.PrinterSettings.PaperSizes.Count - 1
                        cmbSizePrinterTrans.Items.Add(docToPrintTrans.PrinterSettings.PaperSizes(i).RawKind & " - " & docToPrintTrans.PrinterSettings.PaperSizes(i).PaperName)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show("Error di dalam Tampilkan Size Printer Trans !" & vbNewLine & vbNewLine & ex.ToString)
                menuutama.Dispose()
            End Try

            'LOAD EXISTING SETTINGS
            cmbPrinterTrans.Text = cl.readData("SELECT strvl FROM csetting WHERE name = 'Printer Transaksi'")

            cmbSizePrinterTrans.Text = cl.readData("SELECT strvl FROM csetting WHERE name = 'Size Printer Transaksi'")

            If cl.readData("SELECT strvl FROM csetting WHERE name = 'Cetak Langsung Printer Transaksi'") = "Y" Then
                cbCLPrintTrans.Checked = True : Else : cbCLPrintTrans.Checked = False : End If

        End With
    End Sub

    Private Sub cmbPrinterTrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrinterTrans.SelectedIndexChanged
        Try
            Dim docToPrintTrans As New System.Drawing.Printing.PrintDocument()
            cmbSizePrinterTrans.Items.Clear()
            If cmbPrinterTrans.Text <> "" Then
                docToPrintTrans.PrinterSettings.PrinterName = cmbPrinterTrans.Text
                For i = 0 To docToPrintTrans.PrinterSettings.PaperSizes.Count - 1
                    cmbSizePrinterTrans.Items.Add(docToPrintTrans.PrinterSettings.PaperSizes(i).RawKind & " - " & docToPrintTrans.PrinterSettings.PaperSizes(i).PaperName)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error di dalam Tampilkan Size Printer Trans !" & vbNewLine & vbNewLine & ex.ToString)
            menuutama.Dispose()
        End Try
    End Sub

    Private Sub csetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadcmb()
        loadData()
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl
            '------ start validasi
            If validatetxtnull(txtcompany, "Nama Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtalamat, "Alamat Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtowner, "Owner Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtnoijintpb, "No Ijin TPB Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            ' If validatetxtnull(txtphone, "Telpon Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            'If validatetxtnull(txtfax, "Fax Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtNPWP, "NPWP Perusahaan harus diisi !", "Warning Information") = 1 Then : Exit Sub : End If

            Dim CLPrintTrans As String = ""
            If cbCLPrintTrans.Checked = True Then : CLPrintTrans = "Y"
            ElseIf cbCLPrintTrans.Checked = False Then : CLPrintTrans = "N" : End If

            Dim erp As String = ""
            If cherp.Checked = True Then : erp = "Y"
            ElseIf cherp.Checked = False Then : erp = "N" : End If

            Dim online As String = ""
            If cmbonline.Text = "YES" Then : online = "Y"
            ElseIf cmbonline.Text = "NO" Then : online = "N" : End If


            If txtlogo.Text <> "" And txtlogo.Text <> .readData("SELECT strvl FROM csetting WHERE name = 'logolocation'") Then
                PictureBox1.Image = Nothing
                copyDir(txtlogo.Text, cl.dirimgfolder, "logo")
            ElseIf txtlogo.Text = "" Then
                Dim tempPhoto As String = cl.readData(
                    "SELECT strvl FROM csetting WHERE name = 'logolocation'")
                If File.Exists(cl.dirimgfolder & "\" & tempPhoto) Then
                    File.Delete(cl.dirimgfolder & "\" & tempPhoto)
                End If
            End If

            Dim photo As String = ""
            If txtlogo.Text <> "" Then : photo = "logo" & Path.GetExtension(txtlogo.Text)
            Else : photo = "" : End If

            '   MsgBox(photo)

            Dim tny As Integer
            tny = .msgYesNo("Update setting umum ?", "Information")
            If tny = vbYes Then
                .openTrans()

                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(cmbjeniscompany.Text) & "' WHERE name = 'jeniscompany'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtcompany.Text) & "' WHERE name = 'company'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtowner.Text) & "' WHERE name = 'owner'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtalamat.Text) & "' WHERE name = 'alamat'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtnoijintpb.Text) & "' WHERE name = 'noijintpb'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtphone.Text) & "' WHERE name = 'phone'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtfax.Text) & "' WHERE name = 'fax'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtNPWP.Text) & "' WHERE name = 'npwp'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtnegara.Text) & "' WHERE name = 'negara'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(photo) & "' WHERE name = 'logolocation'")
                .execCmdTrans("UPDATE csetting SET intvl = '" & .cnum(nudecimal.Value) & "' WHERE name = 'decimal'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(Mid(cmbcompanycode.Text, 1, 1)) & "' WHERE name = 'companycode'")

                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(Mid(cmbstockminus.Text, 1, 1)) & "' WHERE name = 'stock'")

                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(txtcompid.Text) & "' WHERE name = 'companyid'")

                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(cmbnobckey.SelectedValue) & "' WHERE name = 'nobckey'")

                .execCmdTrans("UPDATE csetting SET strvl = '" & erp & "' WHERE name = 'ERP'")

                .execCmdTrans("UPDATE csetting SET intvl = '" & cmbcurrency.SelectedValue & "', strvl = '" & cmbcurrency.Text & "' WHERE name = 'currency'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & erp & "' WHERE name = 'ERP'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & cmbacctype.Text & "' WHERE name = 'acctype'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & cmbitemcosting.Text & "' WHERE name = 'itemcost'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & online & "' WHERE name = 'online'")

                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(Mid(cmbautopost.Text, 1, 1)) & "' WHERE name = 'autopost'")
                .execCmdTrans("UPDATE csetting SET strvl = '" & .cchr(Mid(cmbautoprint.Text, 1, 1)) & "' WHERE name = 'autoprint'")

                .execCmdTrans("UPDATE ctpb SET ipset = '" & .cchr(txtipset.Text) & "'")

                .execCmdTrans(
                 "UPDATE csetting SET " &
                " strvl = '" & cmbPrinterTrans.Text & "'" &
                " WHERE name = 'Printer Transaksi'")
                .execCmdTrans(
                 "UPDATE csetting SET " &
                " intvl = '" & cl.cnum(Replace(Replace(Mid(cmbSizePrinterTrans.Text, 1, 3), " ", ""), "-", "")) & "'" &
                " WHERE name = 'Size Printer Transaksi'")
                .execCmdTrans(
                 "UPDATE csetting SET " &
                " strvl = '" & cmbSizePrinterTrans.Text & "'" &
                " WHERE name = 'Size Printer Transaksi'")
                .execCmdTrans(
                "UPDATE csetting SET " &
                " strvl = '" & CLPrintTrans & "'" &
                " WHERE name = 'Cetak Langsung Printer Transaksi'")

                .closeTrans(btnsave)

                If .sCloseTrans = 1 Then
                    ' .msgInform("Sukses update setting umum !", "Informasi")
                    '.msgInform("Sistem akan lakukan otomatis restart !", "Informasi")
                    For Each child As Form In Me.MdiChildren
                        child.Close()
                    Next child
                    Me.Dispose()
                    cekform(login, "NEW", Me)
                End If
            End If

        End With
    End Sub

    Private Sub BtnBrowse1_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse1.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "C:"
        openFileDialog1.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim img = Image.FromFile(openFileDialog1.FileName)
            '------FILE SIZE DOES NOT MATTER----------'
            'If New FileInfo(openFileDialog1.FileName).Length > 2000 * 1024 Then
            '    cl.msgError("Ukuran File Photo tidak bisa melebihi 2 Mb !", "Upload Photo Gagal")
            '    Exit Sub
            'ElseIf Image.FromFile(openFileDialog1.FileName).Size.Width > 3024 OrElse
            '    Image.FromFile(openFileDialog1.FileName).Size.Height > 3024 Then
            '    cl.msgError("Ukuran Photo melebihi 2056 x 2056 pixel !", "Upload Photo Gagal")
            '    Exit Sub
            'End If

            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    txtlogo.Text = openFileDialog1.FileName
                    Dim fs As System.IO.FileStream
                    fs = New System.IO.FileStream(openFileDialog1.FileName,
                         IO.FileMode.Open, IO.FileAccess.Read)
                    PictureBox1.Visible = True
                    PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                    fs.Close()
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file JPEG/PNG from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btncancel_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        Dim frm As New csetting
        cekform(frm, "REFRESH", Me)
    End Sub

    Private Sub txtlogo_DoubleClick(sender As Object, e As System.EventArgs) Handles txtlogo.DoubleClick
        txtlogo.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnsaveexpiry_Click(sender As Object, e As EventArgs) Handles btnsaveexpiry.Click
        With cl
            .openTrans()

            .execCmdTrans("UPDATE csetting SET strvl = '" & Format(dtexpiry.Value, "yyyyMMdd") & "' WHERE name = 'expirydate'")

            .closeTrans(btnsaveexpiry)

            If .sCloseTrans = 1 Then
                .msgInform("Sukses update setting umum !", "Informasi")
                .msgInform("Sistem akan lakukan otomatis restart !", "Informasi")
                For Each child As Form In Me.MdiChildren
                    child.Close()
                Next child
                Me.Dispose()
                cekform(login, "NEW", Me)
            End If
        End With

    End Sub

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "SELECT 'D' AS 'value', 'NO. PENDAFTARAN' AS 'display' " &
            " UNION ALL SELECT 'J' AS 'value', 'NO. AJU' AS 'display' ")

        cmbnobckey.DataSource = dtemptp
        cmbnobckey.ValueMember = "value"
        cmbnobckey.DisplayMember = "display"

        Dim dtemptp2 As DataTable = cl.table(
            "SELECT id AS 'value', code AS 'display' " &
            " FROM mcurr WHERE tstatus = 1 ")

        cmbcurrency.DataSource = dtemptp2
        cmbcurrency.ValueMember = "value"
        cmbcurrency.DisplayMember = "display"

    End Sub

    Private Sub cherp_CheckedChanged(sender As Object, e As EventArgs) Handles cherp.CheckedChanged
        If cherp.Checked = True Then


        End If
    End Sub

    Private Sub txtlogo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtlogo.TextChanged

    End Sub
End Class