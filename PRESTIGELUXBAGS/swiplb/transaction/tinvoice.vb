Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class tinvoice
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
        txtno.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('tinvoice','" & Format(CDate(dttdate.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")
        txtcode_mcust.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('mcust','') END TRY BEGIN CATCH SELECT '' END CATCH")
    End Sub

    Private Sub initializedg()
        'deklarasi jumlah datagrid kolom
        dgview.ColumnCount = 15
        dgview.ColumnHeadersVisible = True

        'untuk melakukan konfigurasi style dari kolo header 
        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        dgview.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        dgview.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        With dgview
            .Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
            .Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "DESKRIPSI"
            .Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
            .Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG (RP)"
            .Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
            .Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "HP"

            .Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
            .Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
            .Columns(8).Name = "profit" : .Columns(8).Visible = False
            .Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
            .Columns(10).Name = "code_mcurrb" : .Columns(10).Visible = False
            .Columns(11).Name = "code_mcurrj" : .Columns(11).Visible = False

            .Columns(12).Name = "no" : .Columns(12).Visible = False
            .Columns(13).Name = "id" : .Columns(13).Visible = False
            .Columns(14).Name = "dtconsign" : .Columns(14).Visible = False

        End With
        adjcolumn()
        'setting nama kolom datagrid

    End Sub

    Private Sub adjcolumn()
        'dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        With dgview
            .Columns("code_mitem").Width = 70
            .Columns("name_mitem").Width = 120
            .Columns("qty").Width = 80
            .Columns("hrgjual").Width = 80
            .Columns("name_mconsignee").Width = 120
            .Columns("hp_mconsignee").Width = 80

            .Columns("qty").DefaultCellStyle.Format = "n2"
            .Columns("hrgjual").DefaultCellStyle.Format = "n2"

        End With

        dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    Private Sub initializedg2()
        'deklarasi jumlah datagrid kolom
        dgview2.ColumnCount = 15
        dgview2.ColumnHeadersVisible = True

        'untuk melakukan konfigurasi style dari kolo header 
        Dim columnHeaderStyle As New DataGridViewCellStyle()
        columnHeaderStyle.BackColor = Color.Beige
        columnHeaderStyle.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        dgview2.ColumnHeadersDefaultCellStyle = columnHeaderStyle
        dgview2.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True

        With dgview2
            .Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
            .Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "NAMA BARANG"
            .Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
            .Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG JUAL (RP)"
            .Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
            .Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "NO HP CONSIGNEE"

            .Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
            .Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
            .Columns(8).Name = "profit" : .Columns(8).Visible = False
            .Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
            .Columns(10).Name = "code_mcurrb" : .Columns(10).Visible = False
            .Columns(11).Name = "code_mcurrj" : .Columns(11).Visible = False

            .Columns(12).Name = "no" : .Columns(12).Visible = False
            .Columns(13).Name = "id" : .Columns(13).Visible = False
            .Columns(14).Name = "dtconsign" : .Columns(14).Visible = False

        End With
        'setting nama kolom datagrid

    End Sub


    Private Sub clearData()
        txtcode_mcust.Text = ""
        txtname_mcust.Text = ""
        txthp1_mcust.Text = ""
        txthp2_mcust.Text = ""
        txtalamat_mcust.Text = ""

        '------------------------------------------------------------------------------------
        txtcode_mitem.Text = ""
        txtname_mitem.Text = ""
        txtspek_mitem.Text = ""

        txtname_mbrand.Text = ""
        txtname_mconsignee.Text = ""
        txtcode_mconsignee.Text = ""
        txthp1_mconsignee.Text = ""
        txttotal.Text = 0
        txtprofit.Text = 0
        txtprofitbuyer.Text = 0

        txthrgbeli.Text = 0
        txthrgjual.Text = 0

        '------------------------------------------------------------------------------------
        lblcode_mbrand.Text = ""
        lblcode_mconsignee.Text = ""
        lblcode_mitem.Text = ""
        txtnotedoc.Text = ""

        txtsze.Text = ""
        txtcolor.Text = ""
        txtmtrl.Text = ""

        txtsales.Text = ""

        lblpic1.Text = ""
        lblpic2.Text = ""
        lblpic3.Text = ""
        lblpic4.Text = ""
        lblpic5.Text = ""
        lblpic6.Text = ""

        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing


        lblimageorder.Text = 1

        cmbpayvia.SelectedIndex = 0
        cmbdoctype.SelectedIndex = 0

        lbldocstatus.Text = "OPEN"
        lbldocstatus.Visible = True

        cmbgender.SelectedIndex = 1

        dttdate.Value = Now
        dttdate2.Value = Now

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


        txtcode_mconsignee.Text = ""
        txtname_mconsignee.Text = ""
        txtname_mbrand.Text = ""
        txtprofit.Text = 0
        txtprofitbuyer.Text = 0

        txtprofit.ReadOnly = True
        txtprofitbuyer.ReadOnly = True

        txtinforek.Text = ""
        txthp1_mconsignee.Text = ""
        txthp1_mcust.Text = ""
        txthp2_mcust.Text = ""

        lblcode_mcust.Text = ""
        lblid_tconsign.Text = ""

        txtqty.Text = 1

        txtsendby.Text = ""
        txtdp.Text = 0
        txttotal.Text = 0

        txtvoucher.Text = ""

        txtgrdtotal.Text = 0

        dgview.Rows.Clear()
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

            initializedg()
            initializedg2()

        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True
            btnprint.Visible = True
        End If
        Me.Select() : txtno.Select()
    End Sub

    Private Sub dgview_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf CellValidation
    End Sub

    Sub CellValidation(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim colname As String = dgview.Columns(dgview.CurrentCellAddress.X).Name
        Dim strval As String = dgview.CurrentCell.EditedFormattedValue.ToString

        If colname = "qty" Then
            If cl.cchr(dgview.Rows(dgview.CurrentRow.Index).Cells("code_mitem").Value) = "" Then
                e.KeyChar = ""
            Else
                If Not (e.KeyChar = "." And InStr((strval), ".") = 0) Then
                    If InStr("0123456789", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Then
                        e.KeyChar = ""
                    End If
                End If
            End If

        ElseIf colname <> "qty" Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub mbranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub

    Private Sub mbp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtno.Select()
    End Sub
    Dim time As Integer
    'Private Sub timediff(ByVal dt1 As DateTime, ByVal dt2 As DateTime)
    '    time = 0

    '    If dt1.time < dt2.Date Then
    '        cl.msgError("Tanggal transfer tidak boleh sebelum dari taggal consign!", "Informasi")
    '        Exit Sub
    '    End If
    'End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl
            'Dim dt1 As DateTime = DateTime.Parse(dttdate.Text)
            'Dim dt2 As DateTime = DateTime.Parse(dttdate2.Text)
            ''dt1 = Format(dttdate.Value, "yyyyMMdd")
            ''dt2 = Format(dttdate2.Value, "yyyyMMdd")
            'If dt1 < dt2 Then
            '    cl.msgError("Tanggal transfer tidak boleh sebelum dari taggal consign!", "Informasi")
            '    Exit Sub
            'End If


            '------ start validasi
            If validatetxtnull(txtno, "Name Can't NULL !", "Warning Information") = 1 Then : Exit Sub : End If
            '------ end validasi


            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tinvoice'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                'If txtno_tconsign.Text = .readData("SELECT no_tconsign FROM tinvoice WHERE no_tconsign = '" & txtno_tconsign.Text & "' AND tstatus = 1") Then
                '    cl.msgError("Nomer Consign sudah pernah dipakai!", "Informasi")
                '    Exit Sub
                'End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()

                    Dim getlastno As String
                    getlastno = cl.getDataTrans("BEGIN TRY SELECT dbo.fgetcode('tinvoice','" & Format(CDate(dttdate.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")


                    '.execCmdTrans(
                    '    "EXEC stinvoice " &
                    '    " '" & getlastno & "'" &
                    '   " , " & .cdt(dttdate) & "" &
                    '   " , " & .cdt(dttdate2) & "" &
                    '    " , '" & .cchr(cmbdoctype.Text) & "'" &
                    '    " , '" & .cchr(txtsales.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mcust.Text) & "'" &
                    '    " , '" & .cchr(txtname_mcust.Text) & "'" &
                    '    " , '" & .cchr(txthp1_mcust.Text) & "'" &
                    '    " , '" & .cchr(txthp2_mcust.Text) & "'" &
                    '    " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                    '    " , '" & .cchr(cmbgender.Text) & "'" &
                    '    " , '" & .cchr(txtno_tconsign.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                    '    " , '" & .cchr(txtname_mitem.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mitem.Text) & "'" &
                    '    " , '" & .cnum(txtqty.Text) & "'" &
                    '    " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                    '    " , '" & .cnum(txthrgbeli.Text) & "'" &
                    '    " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                    '    " , '" & .cnum(txthrgjual.Text) & "'" &
                    '    " , '" & .cnum(txtprofit.Text) & "'" &
                    '    " , '" & .cnum(txtprofitbuyer.Text) & "'" &
                    '    " , '" & .cchr(cmbpayvia.Text) & "'" &
                    '    " , '" & .cchr(txtinforek.Text) & "'" &
                    '    " , " & .cdt(dttglbyr) & "" &
                    '    " , '" & .cnum(txtdp.Text) & "'" &
                    '    " , '" & .cchr(txtsendby.Text) & "'" &
                    '    " , '" & .cchr(txtvoucher.Text) & "'" &
                    '    " , '" & .cchr(txtnotedoc.Text) & "'" &
                    '    " , '" & idusr & "'" &
                    '    " , 'new'" &
                    '    " , '0'" &
                    '    "")

                    For i As Integer = 0 To dgview.Rows.Count - 1
                        If .cchr(dgview.Rows(i).Cells("code_mitem").Value) <> "" Then

                            '.Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
                            '.Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "NAMA BARANG"
                            '.Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
                            '.Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG JUAL (RP)"
                            '.Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
                            '.Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "NO HP CONSIGNEE"

                            '.Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
                            '.Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
                            '.Columns(8).Name = "profit" : .Columns(8).Visible = False
                            '.Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
                            '.Columns(10).Name = "code_mcurrb" : .Columns(10).Visible = False
                            '.Columns(11).Name = "code_mcurrj" : .Columns(11).Visible = False

                            '.Columns(12).Name = "no" : .Columns(12).Visible = False
                            '.Columns(13).Name = "id" : .Columns(13).Visible = False

                            .execCmdTrans(
                                "EXEC stinvoice " &
                                " '" & getlastno & "'" &
                               " , " & .cdt(dttdate) & "" &
                               " , " & .cdt(dttdate2) & "" &
                                " , '" & .cchr(cmbdoctype.Text) & "'" &
                                " , '" & .cchr(txtsales.Text) & "'" &
                                " , '" & .cchr(txtcode_mcust.Text) & "'" &
                                " , '" & .cchr(txtname_mcust.Text) & "'" &
                                " , '" & .cchr(txthp1_mcust.Text) & "'" &
                                " , '" & .cchr(txthp2_mcust.Text) & "'" &
                                " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                                " , '" & .cchr(cmbgender.Text) & "'" &
                                " , '" & .cchr(txtno_tconsign.Text) & "'" &
                                " , '" & .cchr(dgview.Rows(i).Cells("code_mconsignee").Value) & "'" &
                                " , '" & .cchr(dgview.Rows(i).Cells("name_mitem").Value) & "'" &
                                " , '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                                " , '" & .cnum(dgview.Rows(i).Cells("qty").Value) & "'" &
                                " , '" & .cchr(dgview.Rows(i).Cells("code_mcurrb").Value) & "'" &
                                 " , '" & .cnum(dgview.Rows(i).Cells("hrgbeli").Value) & "'" &
                                " , '" & .cchr(dgview.Rows(i).Cells("code_mcurrj").Value) & "'" &
                                " , '" & .cnum(dgview.Rows(i).Cells("hrgjual").Value) & "'" &
                                " , '" & .cnum(dgview.Rows(i).Cells("profit").Value) & "'" &
                                " , '" & .cnum(dgview.Rows(i).Cells("profitbuyer").Value) & "'" &
                                " , '" & .cchr(cmbpayvia.Text) & "'" &
                                " , '" & .cchr(txtinforek.Text) & "'" &
                                " , " & .cdt(dttglbyr) & "" &
                                " , '" & .cnum(txtdp.Text) & "'" &
                                " , '" & .cchr(txtsendby.Text) & "'" &
                                " , '" & .cchr(txtvoucher.Text) & "'" &
                                " , '" & .cnum(txtgrdtotal.Text) & "'" &
                                " , '" & .cchr(txtnotedoc.Text) & "'" &
                                " , '" & idusr & "'" &
                                " , 'new'" &
                                " , '0'" &
                                "")

                            '-- UPDATE QTY ITEM
                            .execCmdTrans("UPDATE mitem set qty = qty - '" & .cnum(dgview.Rows(i).Cells("qty").Value) & "' " &
                                          " where code = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "' and tstatus = 1")

                            '-- UPDATE STATUS ITEM
                            .execCmdTrans("UPDATE mitem set itemstatus = 'S' where code = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                                          " And tstatus = 1 And ISNULL(qty,0) <= 0")

                        End If
                    Next

                    If lblcode_mcust.Text = "" Then
                        .execCmdTrans(
                               "EXEC smcust " &
                               " '" & .cchr(txtcode_mcust.Text) & "'" &
                               " , '" & .cchr(txtname_mcust.Text) & "'" &
                               " , '" & .cchr(cmbgender.Text) & "'" &
                                " , '" & .cchr(txthp1_mcust.Text) & "'" &
                               " , '" & .cchr(txthp2_mcust.Text) & "'" &
                               " , ''" &
                               " , ''" &
                               " , '" & .cchr(txtinforek.Text) & "'" &
                               " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                               " , ''" &
                               " , '" & idusr & "'" &
                               " , 'new'" &
                               " , '0'" &
                               "")
                    End If

                    '-- UPDATE STATUS CONSIGNMENT
                    .execCmdTrans("UPDATE tconsign set docstat = 'C' where no = '" & txtno_tconsign.Text & "' and tstatus = 1")



                    .closeTrans(btnsave)
                            If .sCloseTrans = 1 Then
                                .msgInform("Success Save : " & txtno.Text & " !", "Information")
                                changestatform("new") : End If
                        End If
                        ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tinvoice'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    '.execCmdTrans(
                    '    "EXEC stinvoice " &
                    '    " '" & .cchr(txtno.Text) & "'" &
                    '   " , " & .cdt(dttdate) & "" &
                    '   " , " & .cdt(dttdate2) & "" &
                    '    " , '" & .cchr(cmbdoctype.Text) & "'" &
                    '    " , '" & .cchr(txtsales.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mcust.Text) & "'" &
                    '    " , '" & .cchr(txtname_mcust.Text) & "'" &
                    '    " , '" & .cchr(txthp1_mcust.Text) & "'" &
                    '    " , '" & .cchr(txthp2_mcust.Text) & "'" &
                    '    " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                    '    " , '" & .cchr(cmbgender.Text) & "'" &
                    '    " , '" & .cchr(txtno_tconsign.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                    '    " , '" & .cchr(txtname_mitem.Text) & "'" &
                    '    " , '" & .cchr(txtcode_mitem.Text) & "'" &
                    '    " , '" & .cnum(txtqty.Text) & "'" &
                    '    " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                    '    " , '" & .cnum(txthrgbeli.Text) & "'" &
                    '    " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                    '    " , '" & .cnum(txthrgjual.Text) & "'" &
                    '    " , '" & .cnum(txtprofit.Text) & "'" &
                    '    " , '" & .cnum(txtprofitbuyer.Text) & "'" &
                    '    " , '" & .cchr(cmbpayvia.Text) & "'" &
                    '    " , '" & .cchr(txtinforek.Text) & "'" &
                    '    " , " & .cdt(dttglbyr) & "" &
                    '    " , '" & .cnum(txtdp.Text) & "'" &
                    '    " , '" & .cchr(txtsendby.Text) & "'" &
                    '    " , '" & .cchr(txtvoucher.Text) & "'" &
                    '    " , '" & .cchr(txtnotedoc.Text) & "'" &
                    '    " , '" & idusr & "'" &
                    '    " , 'upd'" &
                    '    " , '" & idmaster & "'" &
                    '    "")

                    '-- DELETE PREVIOUSLY INVOICE
                    .execCmdTrans("UPDATE tinvoice SET tstatus = 0 where no = '" & txtno.Text & "' and tstatus = 1")

                    For i As Integer = 0 To dgview2.Rows.Count - 1
                        If .cchr(dgview2.Rows(i).Cells("code_mitem").Value) <> "" Then
                            '-- UPDATE QTY ITEM
                            .execCmdTrans("UPDATE mitem set qty = qty + '" & .cnum(dgview2.Rows(i).Cells("qty").Value) & "' " &
                                          " where code = '" & .cchr(dgview2.Rows(i).Cells("code_mitem").Value) & "' and tstatus = 1")
                        End If
                    Next

                    For i As Integer = 0 To dgview.Rows.Count - 1
                                If .cchr(dgview.Rows(i).Cells("code_mitem").Value) <> "" Then

                            '.Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
                            '.Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "NAMA BARANG"
                            '.Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
                            '.Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG JUAL (RP)"
                            '.Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
                            '.Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "NO HP CONSIGNEE"

                            '.Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
                            '.Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
                            '.Columns(8).Name = "profit" : .Columns(8).Visible = False
                            '.Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
                            '.Columns(10).Name = "code_mcurrb" : .Columns(10).Visible = False
                            '.Columns(11).Name = "code_mcurrj" : .Columns(11).Visible = False

                            '.Columns(12).Name = "no" : .Columns(12).Visible = False
                            '.Columns(13).Name = "id" : .Columns(13).Visible = False

                            .execCmdTrans(
                                        "EXEC stinvoice " &
                                        " '" & txtno.Text & "'" &
                                       " , " & .cdt(dttdate) & "" &
                                       " , " & .cdt(dttdate2) & "" &
                                        " , '" & .cchr(cmbdoctype.Text) & "'" &
                                        " , '" & .cchr(txtsales.Text) & "'" &
                                        " , '" & .cchr(txtcode_mcust.Text) & "'" &
                                        " , '" & .cchr(txtname_mcust.Text) & "'" &
                                        " , '" & .cchr(txthp1_mcust.Text) & "'" &
                                        " , '" & .cchr(txthp2_mcust.Text) & "'" &
                                        " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                                        " , '" & .cchr(cmbgender.Text) & "'" &
                                        " , '" & .cchr(txtno_tconsign.Text) & "'" &
                                        " , '" & .cchr(dgview.Rows(i).Cells("code_mconsignee").Value) & "'" &
                                        " , '" & .cchr(dgview.Rows(i).Cells("name_mitem").Value) & "'" &
                                        " , '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                                        " , '" & .cnum(dgview.Rows(i).Cells("qty").Value) & "'" &
                                        " , '" & .cchr(dgview.Rows(i).Cells("code_mcurrb").Value) & "'" &
                                         " , '" & .cnum(dgview.Rows(i).Cells("hrgbeli").Value) & "'" &
                                        " , '" & .cchr(dgview.Rows(i).Cells("code_mcurrj").Value) & "'" &
                                        " , '" & .cnum(dgview.Rows(i).Cells("hrgjual").Value) & "'" &
                                        " , '" & .cnum(dgview.Rows(i).Cells("profit").Value) & "'" &
                                        " , '" & .cnum(dgview.Rows(i).Cells("profitbuyer").Value) & "'" &
                                        " , '" & .cchr(cmbpayvia.Text) & "'" &
                                        " , '" & .cchr(txtinforek.Text) & "'" &
                                        " , " & .cdt(dttglbyr) & "" &
                                        " , '" & .cnum(txtdp.Text) & "'" &
                                        " , '" & .cchr(txtsendby.Text) & "'" &
                                        " , '" & .cchr(txtvoucher.Text) & "'" &
                                        " , '" & .cnum(txtgrdtotal.Text) & "'" &
                                        " , '" & .cchr(txtnotedoc.Text) & "'" &
                                        " , '" & idusr & "'" &
                                        " , 'new'" &
                                        " , '0'" &
                                        "")

                            '-- UPDATE QTY ITEM
                            .execCmdTrans("UPDATE mitem set qty = qty - '" & .cnum(dgview.Rows(i).Cells("qty").Value) & "' " &
                                                  " where code = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "' and tstatus = 1")

                            '-- UPDATE STATUS ITEM
                            .execCmdTrans("UPDATE mitem set itemstatus = 'S' where code = '" & .cchr(dgview.Rows(i).Cells("code_mitem").Value) & "'" &
                                                  " And tstatus = 1 And ISNULL(qty,0) <= 0")

                                End If
                            Next
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
        Dim frm As New tinvoice
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TC.name 'name_mconsignee' FROM tinvoice TA INNER JOIN mitem TB " &
            " ON TA.code_mitem = TB.code LEFT JOIN mconsignee TC ON TB.code_mconsign = TC.code WHERE TA.tstatus = 1 And TB.tstatus = 1 AND TC.tstatus = 1 AND TB.code_mtype <> 'JW' UNION ALL " &
            " SELECT TA.*, TC.name 'name_mconsignee' FROM tinvoice TA INNER JOIN mitem TB " &
            " ON TA.code_mitem = TB.code LEFT JOIN mvendor TC ON TB.code_mvendor = TC.code WHERE TA.tstatus = 1 And TB.tstatus = 1 AND TC.tstatus = 1 AND TB.code_mtype  ='JW'"

        With a.dgview : .DataSource = cl.table(sql & " ORDER BY TA.tdate, TA.no")
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
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[tinvoice]tinvoice")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Invoice"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tinvoice'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'
            '-- VALIDATE CANNOT DELETE INVOICE IF PAID !
            If cl.readData("SELECT COUNT(id) FROM tpyd WHERE tstatus = 1 AND no_trans = '" & txtno.Text & "' and doctype = 'INV'") > 0 Then
                .msgError("Tidak bisa delete Invoice karena sudah ada payment dari buyer !", "Informasi")
                Exit Sub
            End If

            '-- VALIDATE CANNOT DELETE INVOICE IF PAID !
            If cl.readData("SELECT COUNT(id) FROM tpcd WHERE tstatus = 1 AND no_trans = '" & txtno.Text & "' and doctype = 'CNS'") > 0 Then
                .msgError("Tidak bisa delete Invoice karena sudah ada payment ke Consignee !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Delete Invoice Penjualan : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                '.execCmdTrans(
                '        "EXEC stinvoice " &
                '        " '" & .cchr(txtno.Text) & "'" &
                '       " , " & .cdt(dttdate) & "" &
                '       " , " & .cdt(dttdate2) & "" &
                '        " , '" & .cchr(cmbdoctype.Text) & "'" &
                '        " , '" & .cchr(txtsales.Text) & "'" &
                '        " , '" & .cchr(txtcode_mcust.Text) & "'" &
                '        " , '" & .cchr(txtname_mcust.Text) & "'" &
                '        " , '" & .cchr(txthp1_mcust.Text) & "'" &
                '        " , '" & .cchr(txthp2_mcust.Text) & "'" &
                '        " , '" & .cchr(txtalamat_mcust.Text) & "'" &
                '        " , '" & .cchr(cmbgender.Text) & "'" &
                '        " , '" & .cchr(txtno_tconsign.Text) & "'" &
                '        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                '        " , '" & .cchr(txtname_mitem.Text) & "'" &
                '        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                '        " , '" & .cnum(txtqty.Text) & "'" &
                '        " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                '        " , '" & .cnum(txthrgbeli.Text) & "'" &
                '        " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                '        " , '" & .cnum(txthrgjual.Text) & "'" &
                '        " , '" & .cnum(txtprofit.Text) & "'" &
                '        " , '" & .cnum(txtprofitbuyer.Text) & "'" &
                '        " , '" & .cchr(cmbpayvia.Text) & "'" &
                '        " , '" & .cchr(txtinforek.Text) & "'" &
                '        " , " & .cdt(dttglbyr) & "" &
                '        " , '" & .cnum(txtdp.Text) & "'" &
                '        " , '" & .cchr(txtsendby.Text) & "'" &
                '        " , '" & .cchr(txtvoucher.Text) & "'" &
                '        " , '" & .cchr(txtnotedoc.Text) & "'" &
                '        " , '" & idusr & "'" &
                '        " , 'del'" &
                '        " , '" & idmaster & "'" &
                '        "")

                .execCmdTrans("UPDATE tinvoice set tstatus = 0 WHERE no = '" & txtno.Text & "' and tstatus = 1")

                For i As Integer = 0 To dgview2.Rows.Count - 1
                    If .cchr(dgview2.Rows(i).Cells("code_mitem").Value) <> "" Then
                        .execCmdTrans("UPDATE mitem set itemstatus = 'O' " &
                                      " where code = '" & .cchr(dgview2.Rows(i).Cells("code_mitem").Value) & "' and tstatus = 1 ")

                        '-- UPDATE QTY ITEM
                        .execCmdTrans("UPDATE mitem set qty = qty + '" & .cnum(dgview2.Rows(i).Cells("qty").Value) & "'" &
                                      " where code = '" & .cchr(dgview2.Rows(i).Cells("code_mitem").Value) & "' and tstatus = 1")

                    End If
                Next
                '-- REOPEN ITEM STATUS

                .closeTrans(btnsave)
                        If .sCloseTrans = 1 Then
                            .msgInform("Success Delete Invoice Penjualan :  " & txtno.Text & " !", "Information")
                            changestatform("new") : End If
                    End If
        End With
    End Sub

    Private Sub btnbrowseconsignee_Click(sender As Object, e As EventArgs) Handles btnbrowseconsignee.Click
        Dim a As New tsearch
        'Dim sqlStr As String =
        '        "SELECT * FROM tconsign WHERE tstatus = 1"
        'Dim sqlStr As String = "SELECT TA.* FROM tconsign TA LEFT JOIN tinvoice TB on TA.id = TB.id WHERE TB.no_tconsign IS NULL AND TA.tstatus=1"
        Dim sqlStr As String = "SELECT TA.* FROM tconsign TA WHERE TA.tstatus = 1 AND TA.no NOT IN (SELECT TX.no_tconsign FROM tinvoice TX WHERE TX.tstatus = 1)"
        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Consign"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl Consign"
            .Columns("name_mconsignee").Visible = True : .Columns("name_mconsignee").HeaderText = "Consignee"
            .Columns("hp1").Visible = True : .Columns("hp1").HeaderText = "HP"
            .Columns("code_mitem").Visible = True : .Columns("code_mitem").HeaderText = "No Tag"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[tconsign]tinvoice")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Invoice"

        cekform(a, "SEARCH", Me)
    End Sub


    Private Sub btnbrowsecust_Click(sender As Object, e As EventArgs) Handles btnbrowsecust.Click
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

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[mcust]tinvoice")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Customer/Buyer"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub BtnBrowse1_Click(sender As Object, e As EventArgs) Handles btnbrowsesales.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM msales WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[msales]tinvoice")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Sales"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub txthrgjual_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub ResetNewCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetNewCustomerToolStripMenuItem.Click
        txtcode_mcust.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('mcust','') END TRY BEGIN CATCH SELECT '' END CATCH")
        txtname_mcust.Text = ""
        txthp1_mcust.Text = ""
        txthp2_mcust.Text = ""
        txtalamat_mcust.Text = ""

        lblcode_mcust.Text = ""
    End Sub

    Private Sub CancelTransaksiInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelTransaksiInvoiceToolStripMenuItem.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tinvoice'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'
            If cl.readData("SELECT ISNULL(approver,'N') FROM cusr WHERE id = '" & idusr & "' and tstatus = 1") = "N" Then
                .msgError("User tidak dapat cancel Invoice !", "Informasi")
                Exit Sub
            End If

            '---------------------END------------------------'
            If cl.readData("SELECT docstat FROM tinvoice WHERE id = '" & idmaster & "' and tstatus = 1") = "L" Then
                .msgError("Tidak bisa cancel invoice yang sudah di cancel !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Cancel Invoice Penjualan : " & txtno.Text & " ? Nominal Pembayaran akan otomatis menjadi Saldo Buyer", "Confirmation")
            If tny = vbYes Then
                .openTrans()

                '-- SET BALANCE IF PAID
                .execCmdTrans("UPDATE mcust SET balance = (SELECT SUM(ISNULL(TX.paytotal,0)) FROM tpyd TX WHERE TX.tstatus = 1 and TX.no_trans = '" & txtno.Text & "' AND TX.doctype = 'INV') WHERE code = '" & txtcode_mcust.Text & "' AND tstatus = 1")

                '-- UPDATE QTY ITEM
                .execCmdTrans("UPDATE mitem set qty = qty + '" & .cnum(txtqty.Text) & "' where code = '" & txtcode_mitem.Text & "' and tstatus = 1")

                .execCmdTrans("UPDATE tinvoice SET docstat = 'L' WHERE id = '" & idmaster & "' and tstatus = 1")

                ''-- REOPEN CONSIGNMENT
                '.execCmdTrans("UPDATE tconsign set docstat = 'O' where no = '" & txtno_tconsign.Text & "' and tstatus = 1")

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Cancel Invoice Penjualan : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txthrgjual_LostFocus(sender As Object, e As EventArgs) Handles txthrgjual.LostFocus
        txttotal.Text = cl.ccur(cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text))
        If txtprofit.ReadOnly = True Then
            txtprofit.Text = cl.ccur((cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text)) - (cl.cnum(txtqty.Text) * cl.cnum(txthrgbeli.Text)))
            txtprofitbuyer.Text = 0
        End If
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
                'MsgBox(lblcode_mitem.Text)

                If cl.readData("SELECT code_mtype FROM mitem WHERE code = '" & txtcode_mitem.Text & "'") = "JW" Then

                    If .readData("SELECT COUNT(id) FROM tinvoice WHERE no = '" & txtno.Text & "' and tstatus = 1") = 1 Then
                        rpt.Load(direcCetakan & "\rptinvoicejewell.rpt")
                    Else
                        rpt.Load(direcCetakan & "\rptinvoicejewellMULTIPLE.rpt")
                    End If

                Else

                    If .readData("SELECT COUNT(id) FROM tinvoice WHERE no = '" & txtno.Text & "' and tstatus = 1") = 1 Then
                        rpt.Load(direcCetakan & "\rptinvoicebag.rpt")
                    Else
                        rpt.Load(direcCetakan & "\rptinvoicebagMULTIPLE.rpt")
                    End If

                End If

                    rpt.SetDataSource(cl.table(
                 " SELECT * FROM vtinvoice " &
                 " WHERE no = '" & txtno.Text & "' " &
                 " "))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With

    End Sub

    Private Sub BtnBrowse1_Click_1(sender As Object, e As EventArgs) Handles BtnBrowse1.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA LEFT JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.qty > 0 and TA.code_mtype <> 'JW' UNION ALL " &
            "  SELECT TA.*, '' 'name_mbrand', TC.name 'name_mconsignee', TC.phone 'phone_mconsignee' " &
            " FROM mitem TA  " &
            " LEFT JOIN mvendor TC ON TA.code_mvendor = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.qty > 0 and TA.code_mtype = 'JW'"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Kode"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("code_muom").Visible = True : .Columns("code_muom").HeaderText = "Satuan"
            .Columns("hrgbeli").Visible = True : .Columns("hrgbeli").HeaderText = "Hrg Beli" : .Columns("hrgbeli").DefaultCellStyle.Format = "n2"
            .Columns("color").Visible = True : .Columns("color").HeaderText = "Color"
            .Columns("sze").Visible = True : .Columns("sze").HeaderText = "Size"
            .Columns("mtrl").Visible = True : .Columns("mtrl").HeaderText = "Material"
            .Columns("name_mconsignee").Visible = True : .Columns("name_mconsignee").HeaderText = "Consignee/Vendor"
            .Columns("name_mbrand").Visible = True : .Columns("name_mbrand").HeaderText = "Merk"
            .Columns("phone_mconsignee").Visible = True : .Columns("phone_mconsignee").HeaderText = "HP"
            .Columns("qty").Visible = True : .Columns("qty").HeaderText = "Stock/Av Qty" : .Columns("qty").DefaultCellStyle.Format = "n0"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[mitem]tinvoice")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Item/Barang"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        txtprofit.ReadOnly = False
        txtprofitbuyer.ReadOnly = False

        txtprofit.Text = 0
        txtprofitbuyer.Text = 0
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        txtprofit.ReadOnly = True
        txtprofitbuyer.ReadOnly = True

        txtprofit.Text = 0
        txtprofitbuyer.Text = 0
    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick

    End Sub

    Private Sub TabPage7_Click(sender As Object, e As EventArgs) Handles TabPage7.Click

    End Sub

    Private Sub txthrgjual_TextChanged_1(sender As Object, e As EventArgs) Handles txthrgjual.TextChanged

    End Sub

    Private Sub BtnBrowse2_Click(sender As Object, e As EventArgs) Handles BtnBrowse2.Click
        If txtcode_mitem.Text = "" Then
            cl.msgError("Mohon untuk pilih item terlebih dahulu !", "Information")
        Else
            cl.msgInform("Sisa Stock : " & cl.cdisnum(cl.readData("SELECT ISNULL(qty,0) FROM mitem WHERE code = '" & txtcode_mitem.Text & "' and tstatus = 1")))
        End If
    End Sub

    Private Sub txtqty_LostFocus(sender As Object, e As EventArgs) Handles txtqty.LostFocus
        If cl.readData("SELECT ISNULL(qty,0) FROM mitem WHERE code = '" & txtcode_mitem.Text & "' and tstatus = 1") <= 0 Then
            cl.msgError("Stock sudah tidak tersedia !", "Informasi")
            Exit Sub
        End If

        txtqty.Text = cl.cdisnum(txtqty.Text)
        txttotal.Text = cl.ccur(cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text))
        txtprofit.Text = cl.ccur((cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text)) - (cl.cnum(txtqty.Text) * cl.cnum(txthrgbeli.Text)))
    End Sub

    Public Sub getcalculate()
        Dim grdtotal As Decimal = 0

        With dgview
            For a As Integer = 0 To .Rows.Count - 1
                If cl.cchr(.Rows(a).Cells("code_mitem").Value) <> "" Then
                    grdtotal += cl.cnum(.Rows(a).Cells("qty").Value) * cl.cnum(.Rows(a).Cells("hrgjual").Value)
                End If
            Next
            txtgrdtotal.Text = cl.ccur(grdtotal)
        End With
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        '.Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
        '.Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "NAMA BARANG"
        '.Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
        '.Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG JUAL (RP)"
        '.Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
        '.Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "NO HP CONSIGNEE"

        '.Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
        '.Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
        '.Columns(8).Name = "profit" : .Columns(8).Visible = False
        '.Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
        '.Columns(10).Name = "currb" : .Columns(10).Visible = False
        '.Columns(11).Name = "currj" : .Columns(11).Visible = False

        '.Columns(12).Name = "no" : .Columns(12).Visible = False
        '.Columns(13).Name = "id" : .Columns(13).Visible = False

        If cl.cnum(txthrgjual.Text) = 0 Then
            cl.msgError("Harga jual harus di isi !", "Informasi")
            Exit Sub
        End If

        If cl.cnum(txtqty.Text) = 0 Then
            cl.msgError("Qty tidak boleh 0 !", "Informasi")
            Exit Sub
        End If

        If cl.cchr(txtname_mcust.Text) = "" Then
            cl.msgError("Customer harus di isi !", "Informasi")
            Exit Sub
        End If

        If cl.cchr(txthp1_mcust.Text) = "" Then
            cl.msgError("HP Customer harus di isi !", "Informasi")
            Exit Sub
        End If

        If cl.cchr(txtsales.Text) = "" Then
            cl.msgError("Sales harus di isi !", "Informasi")
            Exit Sub
        End If

        Dim row As String() = New String() {txtcode_mitem.Text, txtname_mitem.Text, txtqty.Text, cl.ccur(txthrgjual.Text) _
            , txtname_mconsignee.Text, txthp1_mconsignee.Text, txtcode_mconsignee.Text, txthrgbeli.Text,
            txtprofit.Text, txtprofitbuyer.Text, cmbcurrb.Text, cmbcurrj.Text, txtno.Text, 0}
        dgview.Rows.Add(row)

        '------------------------------------------------------------------------------------
        txtcode_mitem.Text = ""
        txtname_mitem.Text = ""
        txtspek_mitem.Text = ""

        txthrgbeli.Text = 0
        txthrgjual.Text = 0

        '------------------------------------------------------------------------------------
        lblcode_mbrand.Text = ""
        lblcode_mconsignee.Text = ""
        lblcode_mitem.Text = ""
        ' txtnotedoc.Text = ""

        txtsze.Text = ""
        txtcolor.Text = ""
        txtmtrl.Text = ""

        '   txtsales.Text = ""

        lblpic1.Text = ""
        lblpic2.Text = ""
        lblpic3.Text = ""
        lblpic4.Text = ""
        lblpic5.Text = ""
        lblpic6.Text = ""

        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing

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

        txtname_mbrand.Text = ""
        txtname_mconsignee.Text = ""
        txtcode_mconsignee.Text = ""
        txthp1_mconsignee.Text = ""
        txttotal.Text = 0
        txtprofit.Text = 0
        txtprofitbuyer.Text = 0

        getcalculate()
    End Sub

    Private Sub dgview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellContentClick

    End Sub

    Public Sub getdatainvoice()

    End Sub

    Private Sub btnremove_Click(sender As Object, e As EventArgs) Handles btnremove.Click

        Try
            dgview.Rows.RemoveAt(dgview.CurrentRow.Index)

            '------------------------------------------------------------------------------------
            txtcode_mitem.Text = ""
            txtname_mitem.Text = ""
            txtspek_mitem.Text = ""

            txthrgbeli.Text = 0
            txthrgjual.Text = 0

            '------------------------------------------------------------------------------------
            lblcode_mbrand.Text = ""
            lblcode_mconsignee.Text = ""
            lblcode_mitem.Text = ""
            ' txtnotedoc.Text = ""

            txtsze.Text = ""
            txtcolor.Text = ""
            txtmtrl.Text = ""

            '   txtsales.Text = ""

            lblpic1.Text = ""
            lblpic2.Text = ""
            lblpic3.Text = ""
            lblpic4.Text = ""
            lblpic5.Text = ""
            lblpic6.Text = ""

            PictureBox1.Image = Nothing
            PictureBox2.Image = Nothing
            PictureBox3.Image = Nothing
            PictureBox4.Image = Nothing
            PictureBox5.Image = Nothing
            PictureBox6.Image = Nothing

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

            txtname_mbrand.Text = ""
            txtname_mconsignee.Text = ""
            txtcode_mconsignee.Text = ""
            txthp1_mconsignee.Text = ""
            txttotal.Text = 0
            txtprofit.Text = 0
            txtprofitbuyer.Text = 0

            getcalculate()
        Catch : End Try
    End Sub

    Private Sub dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick

        Dim img() As Byte
        Dim img2() As Byte
        Dim img3() As Byte
        Dim img4() As Byte
        Dim img5() As Byte
        Dim img6() As Byte

        Dim i As Integer = dgview.CurrentRow.Index

        With Me.dgview


            '.Columns(0).Name = "code_mitem" : .Columns(0).HeaderText = "NO TAG"
            '.Columns(1).Name = "name_mitem" : .Columns(1).HeaderText = "NAMA BARANG"
            '.Columns(2).Name = "qty" : .Columns(2).HeaderText = "QTY"
            '.Columns(3).Name = "hrgjual" : .Columns(3).HeaderText = "HRG JUAL (RP)"
            '.Columns(4).Name = "name_mconsignee" : .Columns(4).HeaderText = "CONSIGNEE"
            '.Columns(5).Name = "hp_mconsignee" : .Columns(5).HeaderText = "NO HP CONSIGNEE"

            '.Columns(6).Name = "code_mconsignee" : .Columns(6).Visible = False
            '.Columns(7).Name = "hrgbeli" : .Columns(7).Visible = False
            '.Columns(8).Name = "profit" : .Columns(8).Visible = False
            '.Columns(9).Name = "profitbuyer" : .Columns(9).Visible = False
            '.Columns(10).Name = "currb" : .Columns(10).Visible = False
            '.Columns(11).Name = "currj" : .Columns(11).Visible = False

            '.Columns(12).Name = "no" : .Columns(12).Visible = False
            '.Columns(13).Name = "id" : .Columns(13).Visible = False

            getidmaster(.Item("id", i).Value)

            txtqty.Text = cl.cdisnum(.Item("qty", i).Value)

            lblid_tconsign.Text = idmaster
            txtno_tconsign.Text = txtno.Text

            txtcode_mitem.Text = cl.cchr(.Item("code_mitem", i).Value)
            txtname_mitem.Text = cl.cchr(cl.readData("SELECT name FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            Try : cmbtype_mitem.SelectedValue = cl.cchr(cl.readData("SELECT ISNULL(code_mtype,'BG') FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'")) : Catch : End Try
            cmbcurrb.Text = cl.cchr(.Item("code_mcurrb", i).Value)
            cmbcurrj.Text = cl.cchr(.Item("code_mcurrj", i).Value)
            txthrgbeli.Text = cl.ccur(.Item("hrgbeli", i).Value)
            txthrgjual.Text = cl.ccur(.Item("hrgjual", i).Value)
            lblcode_mbrand.Text = cl.cchr(cl.readData("SELECT code_mbrand FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            lblcode_mconsignee.Text = cl.cchr(.Item("code_mconsignee", i).Value)
            txtspek_mitem.Text = cl.cchr(cl.readData("SELECT spek FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

            txtsze.Text = cl.cchr(cl.readData("SELECT sze FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            txtcolor.Text = cl.cchr(cl.readData("SELECT color FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))
            txtmtrl.Text = cl.cchr(cl.readData("SELECT mtrl FROM mitem WHERE tstatus = 1 and code = '" & cl.cchr(.Item("code_mitem", i).Value) & "'"))

            txtname_mbrand.Text = cl.cchr(cl.readData("SELECT code + ' - ' + name FROM mbrand WHERE code = '" & lblcode_mbrand.Text & "' "))

            'If cl.readData("SELECT (qty*hrgjual) - dbo.fcgetpayinv(no) FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' AND tstatus = 1") <> 0 Then
            '    lbldocstatus.Text = "UNPAID"
            'ElseIf cl.readData("SELECT docstat FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "'") = "L" Then
            '    lbldocstatus.Text = "CANCELLED/VOID"
            'ElseIf cl.readData("SELECT (qty*hrgjual) - dbo.fcgetpayinv(no) FROM tinvoice WHERE no = '" & cl.cchr(.Item("no", i).Value) & "' AND tstatus = 1") = 0 Then
            '    lbldocstatus.Text = "PAID"
            'End If

            txtprofit.Text = cl.ccur(.Item("profit", i).Value)
            txtprofitbuyer.Text = cl.ccur(.Item("profitbuyer", i).Value)

            If cl.cnum(.Item("profitbuyer", i).Value) = 0 Then
                txtprofit.ReadOnly = True
                txtprofitbuyer.ReadOnly = True
            Else
                txtprofit.ReadOnly = False
                txtprofitbuyer.ReadOnly = False
            End If

            '-- CALCULATE PROFIT AND TOTAL
            txttotal.Text = cl.ccur(cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text))
            If txtprofit.ReadOnly = True Then
                txtprofit.Text = cl.ccur((cl.cnum(txtqty.Text) * cl.cnum(txthrgjual.Text)) - (cl.cnum(txtqty.Text) * cl.cnum(txthrgbeli.Text)))
                txtprofitbuyer.Text = 0
            End If

            If cl.cchr(cl.readData("SELECT spec1 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec1.SelectedIndex = 1
            Else
                cmbspec1.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec2 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec2.SelectedIndex = 1
            Else
                cmbspec2.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec3 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec3.SelectedIndex = 1
            Else
                cmbspec3.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec4 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec4.SelectedIndex = 1
            Else
                cmbspec4.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec5 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec5.SelectedIndex = 1
            Else
                cmbspec5.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec6 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec6.SelectedIndex = 1
            Else
                cmbspec6.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec7 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec7.SelectedIndex = 1
            Else
                cmbspec7.SelectedIndex = 0
            End If

            If cl.cchr(cl.readData("SELECT spec8 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec8.SelectedIndex = 1
            Else
                cmbspec8.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec9 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec9.SelectedIndex = 1
            Else
                cmbspec9.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec10 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec10.SelectedIndex = 1
            Else
                cmbspec10.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec11 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec11.SelectedIndex = 1
            Else
                cmbspec11.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec12 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec12.SelectedIndex = 1
            Else
                cmbspec12.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec13 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec13.SelectedIndex = 1
            Else
                cmbspec13.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec14 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec14.SelectedIndex = 1
            Else
                cmbspec14.SelectedIndex = 0
            End If

            If cl.cchr(cl.readData("SELECT spec15 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec15.SelectedIndex = 1
            Else
                cmbspec15.SelectedIndex = 0
            End If
            If cl.cchr(cl.readData("SELECT spec16 FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' ")) = "N" Then
                cmbspec16.SelectedIndex = 1
            Else
                cmbspec16.SelectedIndex = 0
            End If

            txtnotespec.Text = cl.cchr(cl.readData("SELECT notespec FROM mitem WHERE code = '" & cl.cchr(.Item("code_mitem", i).Value) & "' "))

            lblpic1.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
            lblpic2.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
            lblpic3.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
            lblpic4.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
            lblpic5.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
            lblpic6.Text = cl.readData("SELECT TA.picName FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")
            '-- load pictures
            img = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 And code = '" & .Item("code_mitem", i).Value & "' and picOrder = 1")
            img2 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 2")
            img3 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 3")
            img4 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 4")
            img5 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 5")
            img6 = cl.readData("SELECT TA.picData FROM mitempic TA WHERE TA.tstatus = 1 and code = '" & .Item("code_mitem", i).Value & "' and picOrder = 6")

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 1 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms As New MemoryStream(img)
                PictureBox1.Image = Image.FromStream(ms)
            Else
                PictureBox1.Image = Nothing
            End If

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 2 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms2 As New MemoryStream(img2)
                PictureBox2.Image = Image.FromStream(ms2)
            Else
                PictureBox2.Image = Nothing
            End If

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 3 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms3 As New MemoryStream(img3)
                PictureBox3.Image = Image.FromStream(ms3)
            Else
                PictureBox3.Image = Nothing
            End If

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 4 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms4 As New MemoryStream(img4)
                PictureBox4.Image = Image.FromStream(ms4)
            Else
                PictureBox4.Image = Nothing
            End If

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 5 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms5 As New MemoryStream(img5)
                PictureBox5.Image = Image.FromStream(ms5)
            Else
                PictureBox5.Image = Nothing
            End If

            If cl.readData("SELECT COUNT(id) FROM mitempic WHERE tstatus = 1 and picOrder = 6 And code = '" & .Item("code_mitem", i).Value & "'") <> 0 Then
                Dim ms6 As New MemoryStream(img6)
                PictureBox6.Image = Image.FromStream(ms6)
            Else
                PictureBox6.Image = Nothing
            End If
        End With
    End Sub

    Private Sub txthrgbeli_TextChanged(sender As Object, e As EventArgs) Handles txthrgbeli.TextChanged

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

    Private Sub dgview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellEndEdit
        getcalculate()
    End Sub
End Class