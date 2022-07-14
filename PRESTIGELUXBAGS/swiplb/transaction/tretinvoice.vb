Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.SqlClient
Public Class tretinvoice
    Dim idmaster As Integer = 0, statform As String = ""
    Dim cmd As SqlCommand

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
            btnlist.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F4) Then
            If idmaster <> 0 And btnsave.Text <> "Save" Then : btndelete.PerformClick() : End If
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub getidmaster(ByVal tidmaster As Integer)
        idmaster = tidmaster
    End Sub

    Private Sub gencode()
        txtno.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('tretinvoice','" & Format(CDate(dttdate.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")
        ' txtcode_mcust.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('mcust','') END TRY BEGIN CATCH SELECT '' END CATCH")
    End Sub

    Private Sub clearData()
        txtcode_mcust.Text = ""
        txtname_mcust.Text = ""

        '------------------------------------------------------------------------------------
        txtcode_mitem.Text = ""
        txtname_mitem.Text = ""
        txtspek_mitem.Text = ""

        txthrgbeli.Text = 0
        txthrgjual.Text = 0

        '------------------------------------------------------------------------------------
        lblno_tinvoice.Text = ""
        txtnote.Text = ""
        txtqty.Text = 0

        txtno_tinvoice.Text = ""
        txtsze.Text = ""
        txtmtrl.Text = ""

        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        ' PictureBox3.Image = Nothing

        PictureBox1.Visible = True
        PictureBox2.Visible = True
        ' PictureBox3.Visible = True

        'lblimageorder.Text = 1

        '  cmbpayvia.SelectedIndex = 0
        cmbdoctype.SelectedIndex = 0

        '  lbldocstatus.Text = "OPEN"
        '  lbldocstatus.Visible = True

        '  cmbgender.SelectedIndex = 1
        cmbdoctype.SelectedIndex = 0

        cmbspec1.SelectedIndex = 1
        cmbspec2.SelectedIndex = 1
        cmbspec3.SelectedIndex = 1
        cmbspec4.SelectedIndex = 1
        cmbspec5.SelectedIndex = 1
        cmbspec6.SelectedIndex = 1
        cmbspec7.SelectedIndex = 1

        cmbspec8.SelectedIndex = 1
        cmbspec9.SelectedIndex = 1
        cmbspec10.SelectedIndex = 1
        cmbspec11.SelectedIndex = 1
        cmbspec12.SelectedIndex = 1
        cmbspec13.SelectedIndex = 1
        cmbspec14.SelectedIndex = 1

        cmbspec15.SelectedIndex = 1
        cmbspec16.SelectedIndex = 1

        cmbpayvia.SelectedIndex = 0
        txttotal.Text = 0

        cmbdoctype2.SelectedIndex = 0

        lblpic1.Text = ""
        lblpic2.Text = ""

        txtsales.Text = ""
        txthp_mcust.Text = ""
        txtprofit.Text = 0

        btncustomer.Enabled = True
        btnitem.Enabled = True
    End Sub

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "SELECT code AS 'value', name AS 'display' FROM mtype WHERE tstatus = 1")

        cmbtype_mitem.DataSource = dtemptp
        cmbtype_mitem.ValueMember = "value"
        cmbtype_mitem.DisplayMember = "display"

        Dim dtemptp2 As DataTable = cl.table(
            "SELECT code AS 'value', name AS 'display' FROM mcurr WHERE tstatus = 1")

        cmbcurrb.DataSource = dtemptp2
        cmbcurrb.ValueMember = "value"
        cmbcurrb.DisplayMember = "display"

        Dim dtemptp3 As DataTable = cl.table(
            "SELECT code AS 'value', name AS 'display' FROM mcurr WHERE tstatus = 1")

        cmbcurrj.DataSource = dtemptp3
        cmbcurrj.ValueMember = "value"
        cmbcurrj.DisplayMember = "display"

        Dim dtemptp4 As DataTable = cl.table(
            "SELECT code AS 'value', code AS 'display' FROM muom WHERE tstatus = 1")

        cmbmuom.DataSource = dtemptp4
        cmbmuom.ValueMember = "value"
        cmbmuom.DisplayMember = "display"
    End Sub


    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            btnsave.Text = "Save"
            gencode()
            loadcmb()
            btndelete.Visible = False
            btnprint.Visible = False
        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True
            btnprint.Visible = True
        End If
        Me.Select() : txtno.Select()
    End Sub

    Private Sub mbranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub

    Private Sub mbp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtno.Select()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl

            '------ start validasi
            If validatetxtnull(txtno, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If

            If lblpic2.Text = "" Then
                .msgError("Gambar retur harus di isi !", "Informasi")
                Exit Sub
            End If
            '------ end validasi


            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tretinvoice'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC stretinvoice " &
                        " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbdoctype.Text) & "'" &
                        " , '" & .cchr(cmbdoctype2.Text) & "'" &
                        " , '" & .cchr(txtsales.Text) & "'" &
                        " , '" & .cchr(txtno_tinvoice.Text) & "'" &
                        " , '" & .cchr(cmbpayvia.Text) & "'" &
                        " , '" & .cchr(txtinforek.Text) & "'" &
                        " , " & .cdt(dttglbyr) & "" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")

                    If cmbdoctype2.Text = "SALDO" Then
                        '-- SET BALANCE IF PAID
                        .execCmdTrans("UPDATE mcust SET balance = (SELECT SUM(ISNULL(TX.paytotal,0)) FROM tpyd TX WHERE TX.tstatus = 1 and TX.no_trans = '" & txtno.Text & "' AND TX.doctype = 'INV') WHERE code = '" & txtcode_mcust.Text & "' AND tstatus = 1")
                    End If

                    If cmbdoctype2.Text = "BARANG" Then
                        '-- UPDATE QTY ITEM
                        .execCmdTrans("UPDATE mitem set qty = qty + '" & .cnum(txtqty.Text) & "' where code = '" & txtcode_mitem.Text & "' and tstatus = 1")
                    End If

                    .execCmdTrans("UPDATE tinvoice SET docstat = 'L' WHERE no = '" & lblno_tinvoice.Text & "' and tstatus = 1")


                        .closeTrans(btnsave)
                        If .sCloseTrans = 1 Then

                        '-- SAVE PICTURES
                        If lblpic1.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO tretinvoicepic (no_tretinvoice, code ,picOrder,picName,picData) values (@no, @code,1,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@no", txtno.Text)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic2.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO tretinvoicepic (no_tretinvoice, code ,picOrder,picName,picData) values (@no, @code,2,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@no", txtno.Text)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        .msgInform("Success Save : " & txtno.Text & " !", "Information")
                            changestatform("new") : End If
                    End If
                ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tretinvoice'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                         "EXEC stretinvoice " &
                      " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbdoctype.Text) & "'" &
                        " , '" & .cchr(cmbdoctype2.Text) & "'" &
                        " , '" & .cchr(txtsales.Text) & "'" &
                        " , '" & .cchr(txtno_tinvoice.Text) & "'" &
                        " , '" & .cchr(cmbpayvia.Text) & "'" &
                        " , '" & .cchr(txtinforek.Text) & "'" &
                        " , " & .cdt(dttglbyr) & "" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        "")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Update : " & txtno.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New tretinvoice
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name_mcust, TB.name_mitem FROM tretinvoice TA " &
            " LEFT JOIN tinvoice TB ON TA.no_tinvoice = TB.no WHERE TA.tstatus = 1"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Invoice"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl Inv"
            .Columns("code_mcust").Visible = True : .Columns("code_mcust").HeaderText = "Kd Buyer"
            .Columns("sales").Visible = True : .Columns("sales").HeaderText = "Sales"
            .Columns("doctype").Visible = True : .Columns("doctype").HeaderText = "Alasan Retur"
            .Columns("doctype2").Visible = True : .Columns("doctype2").HeaderText = "Jenis Retur"
            .Columns("name_mcust").Visible = True : .Columns("name_mcust").HeaderText = "Customer"
            .Columns("name_mitem").Visible = True : .Columns("name_mitem").HeaderText = "Nama Barang"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[tretinvoice]tretinvoice")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Retur Invoice"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tretinvoice'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            Dim tny As Integer
            tny = .msgYesNo("Delete Retur Invoice : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                        "EXEC stretinvoice " &
                        " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbdoctype.Text) & "'" &
                        " , '" & .cchr(cmbdoctype2.Text) & "'" &
                        " , '" & .cchr(txtsales.Text) & "'" &
                        " , '" & .cchr(txtno_tinvoice.Text) & "'" &
                        " , '" & .cchr(cmbpayvia.Text) & "'" &
                        " , '" & .cchr(txtinforek.Text) & "'" &
                        " , " & .cdt(dttglbyr) & "" &
                        " , '" & .cchr(txtnote.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Retur Invoice : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub




    Private Sub txthrgjual_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btnbrowsesupp_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick

    End Sub

    Private Sub btnbrowseconsignee_Click(sender As Object, e As EventArgs) Handles btnbrowseconsignee.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TC.name 'name_mconsignee' FROM tinvoice TA INNER JOIN mitem TB " &
            " ON TA.code_mitem = TB.code INNER JOIN mconsignee TC ON TB.code_mconsign = TC.code WHERE TA.tstatus = 1 And TB.tstatus = 1 AND TC.tstatus = 1"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Invoice"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl Inv"
            .Columns("name_mcust").Visible = True : .Columns("name_mcust").HeaderText = "Customer/Buyer"
            .Columns("hp1").Visible = True : .Columns("hp1").HeaderText = "HP"
            '   .Columns("no_tconsign").Visible = True : .Columns("no_tconsign").HeaderText = "No Consign"
            .Columns("code_mitem").Visible = True : .Columns("code_mitem").HeaderText = "No Tag"
            .Columns("name_mitem").Visible = True : .Columns("name_mitem").HeaderText = "Nama Barang"
            .Columns("sendby").Visible = True : .Columns("sendby").HeaderText = "Send By"
            .Columns("name_mconsignee").Visible = True : .Columns("name_mconsignee").HeaderText = "Consignee/Owner"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[tinvoice]tretinvoice")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Invoice"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(opf.FileName)
            lblpic2.Text = opf.FileName
        End If
    End Sub
    Private Sub txtqty_LostFocus(sender As Object, e As EventArgs) Handles txtqty.LostFocus
        txtqty.Text = cl.cdisnum(txtqty.Text)
        txttotal.Text = cl.ccur(cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text))
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        printdata()
    End Sub

    Private Sub printdata()
        With cl
            Try
                '------PRINT INVOICE
                Dim rpt As New ReportDocument
                Dim f As New print


                rpt.Load(direcCetakan & "\rptretinvoice.rpt")

                rpt.SetDataSource(cl.table(
                 " SELECT * FROM vtretinvoice " &
                 " WHERE id = '" & idmaster & "' " &
                 " "))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With

    End Sub

    Private Sub btncustomer_Click(sender As Object, e As EventArgs) Handles btncustomer.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM mcust WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("hp1").Visible = True : .Columns("hp2").HeaderText = "Phone #1"
            .Columns("hp1").Visible = True : .Columns("hp2").HeaderText = "Phone #2"
            .Columns("alamat").Visible = True : .Columns("alamat").HeaderText = "Alamat"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mcust, "[mcust]tretinvoice")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Customer/Buyer"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btnitem_Click(sender As Object, e As EventArgs) Handles btnitem.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA INNER JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.qty > 0"

        With a.dgview : .DataSource = cl.table(sql)
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
            .Columns("phone_mconsignee").Visible = True : .Columns("phone_mconsignee").HeaderText = "Owner Phone"
            .Columns("qty").Visible = True : .Columns("qty").HeaderText = "Stock/Av Qty" : .Columns("qty").DefaultCellStyle.Format = "n0"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[mitem]tretinvoice")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Item/Barang"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub txthrgjual_LostFocus(sender As Object, e As EventArgs) Handles txthrgjual.LostFocus
        txttotal.Text = cl.ccur(cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text))
        If txtprofit.ReadOnly = True Then
            txtprofit.Text = cl.ccur((cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text)) - cl.cnum(txthrgbeli.Text))
            '   txtprofitbuyer.Text = 0
        End If
    End Sub
End Class