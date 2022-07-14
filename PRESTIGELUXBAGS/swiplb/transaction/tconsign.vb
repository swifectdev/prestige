Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.SqlClient
Public Class tconsign
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
        txtno.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('tconsign','" & Format(CDate(dttdate.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")
        txtcode_mconsignee.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('mconsignee','') END TRY BEGIN CATCH SELECT '' END CATCH")
    End Sub

    Private Sub clearData()
        txtuser.Text = cl.readData("SELECT code + ' - ' + name FROM cusr WHERE id = '" & idusr & "'")
        txthp1.Text = ""
        txthp2.Text = ""
        txtalamat.Text = ""
        dttdate.Value = Now()
        dttdate2.Value = Now()

        '------------------------------------------------------------------------------------
        txtcode_mitem.Text = ""
        txtname_mitem.Text = ""
        txtspek.Text = ""
        txtsze.Text = ""
        txtmtrl.Text = ""
        txtcolor.Text = ""

        txthrgbeli.Text = 0
        txthrgjual.Text = 0

        '------------------------------------------------------------------------------------
        lblcode_mbrand.Text = ""
        lblcode_mconsignee.Text = ""
        txtname_mconsignee.Text = ""
        lblcode_mitem.Text = ""
        txtname_mbrand.Text = ""
        txtnoteb.Text = ""

        txtqty.Text = 1

        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing

        lblpic1.Text = ""
        lblpic2.Text = ""
        lblpic3.Text = ""
        lblpic4.Text = ""
        lblpic5.Text = ""
        lblpic6.Text = ""

        lblimageorder.Text = 1
        cmbgender.SelectedIndex = 0

        lbldocstatus.Text = ""
        lbldocstatus.Visible = False

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

        txtnotespec.Text = ""
        txtnorek.Text = ""
    End Sub

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "Select code As 'value', name AS 'display' FROM mtype WHERE tstatus = 1")

        cmbtype.DataSource = dtemptp
        cmbtype.ValueMember = "value"
        cmbtype.DisplayMember = "display"

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
            If validatetxtnull(txtcode_mitem, "Harus isi item yang di consign !", "Informasi") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtname_mconsignee, "Harus isi Consignee !", "Informasi") = 1 Then : Exit Sub : End If
            '------ end validasi

            If cl.cnum(txtqty.Text) = 0 Then
                cl.msgError("Quantity harus minimal 1", "Informasi")
                txtqty.Focus()
                Exit Sub
            End If

            '-- CHECK FOR DUPLICATE !
            If cl.readData("SELECT COUNT(id) FROM mitem WHERE code = '" & .cchr(txtcode_mitem.Text) & "'") > 0 And lblcode_mitem.Text = "" Then
                cl.msgError("No Tag/Kode item sudah pernah ada di database. Mohon untuk dapat di checking kembali !", "Informasi")
                txtcode_mitem.Focus()
                Exit Sub
            End If



            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tconsign'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC stconsign " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , " & .cdt(dttdate) & "" &
                        " , " & .cdt(dttdate2) & "" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtname_mconsignee.Text) & "'" &
                        " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , ''" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(lblcode_mbrand.Text) & "'" &
                        " , '" & .cchr(txtspek.Text) & "'" &
                        " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgbeli.Text) & "'" &
                        " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgjual.Text) & "'" &
                        " , '" & .cchr(txtnoteb.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")

                    If lblcode_mconsignee.Text = "" Then
                        .execCmdTrans(
                        "EXEC smconsignee " &
                        " '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtname_mconsignee.Text) & "'" &
                        " , ''" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                        " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")
                    End If

                    If lblcode_mitem.Text = "" Then
                        .execCmdTrans(
                        "EXEC smitem " &
                        " '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(lblcode_mconsignee.Text) & "'" &
                         " , '" & .cchr(cmbtype.SelectedValue) & "'" &
                         " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(lblcode_mbrand.Text) & "'" &
                        " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgbeli.Text) & "'" &
                        " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgjual.Text) & "'" &
                        " , '" & .cchr(txtspek.Text) & "'" &
                        " , '" & .cchr(txtcolor.Text) & "'" &
                        " , '" & .cchr(txtsze.Text) & "'" &
                        " , '" & .cchr(txtmtrl.Text) & "'" &
                        " , 'DEFAULT'" &
                        " , 'CONSIGN'" &
                        " , '" & .cchr(txtno.Text) & "'" &
                        " , '" & .cchr(Mid(cmbspec1.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec2.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec3.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec4.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec5.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec6.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec7.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec8.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec9.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec10.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec11.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec12.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec13.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec14.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec15.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec16.Text, 1, 1)) & "'" &
                        " , '" & .cchr(txtnotespec.Text) & "'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")
                    End If

                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then

                        '-- SAVE PICTURES
                        If lblpic1.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,1,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic2.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,2,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic3.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,3,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic4.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,4,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic5.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,5,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic6.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,6,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
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
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tconsign'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If

                If lbldocstatus.Text = "TERJUAL" Or lbldocstatus.Text = "PENARIKAN/CANCEL" Then
                    .msgError("Tidak bisa delete karena barang sudah terjual !", "Informasi")
                    Exit Sub
                End If

                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                       "EXEC stconsign " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , " & .cdt(dttdate) & "" &
                        " , " & .cdt(dttdate2) & "" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtname_mconsignee.Text) & "'" &
                        " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , ''" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(lblcode_mbrand.Text) & "'" &
                        " , '" & .cchr(txtspek.Text) & "'" &
                        " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgbeli.Text) & "'" &
                        " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgjual.Text) & "'" &
                        " , '" & .cchr(txtnoteb.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        "")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then

                        '-- SAVE PICTURES
                        If lblpic1.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,1,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic2.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,2,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic3.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,3,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic4.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,4,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic5.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,5,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic6.Text <> "" And lblcode_mitem.Text = "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,6,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode_mitem.Text)
                            cmd.Parameters.AddWithValue("@name", txtname_mitem.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        .msgInform("Success Update : " & txtno.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New tconsign
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.* FROM tconsign TA WHERE TA.tstatus = 1"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Consign"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl"
            .Columns("name_mconsignee").Visible = True : .Columns("name_mconsignee").HeaderText = "Consignee"
            .Columns("hp1").Visible = True : .Columns("hp1").HeaderText = "HP 1"
            .Columns("hp2").Visible = True : .Columns("hp2").HeaderText = "HP 2"
            .Columns("code_mitem").Visible = True : .Columns("code_mitem").HeaderText = "No Tag"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[tconsign]tconsign")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Consignment"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'tconsign'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            If lbldocstatus.Text = "TERJUAL" Then
                .msgError("Tidak bisa delete karena barang sudah terjual !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Delete Consignment : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                       "EXEC stconsign " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , " & .cdt(dttdate) & "" &
                        " , " & .cdt(dttdate2) & "" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtname_mconsignee.Text) & "'" &
                        " , '" & .cchr(txthp1.Text) & "'" &
                        " , '" & .cchr(txthp2.Text) & "'" &
                        " , '" & .cchr(txtalamat.Text) & "'" &
                        " , '" & .cchr(cmbgender.Text) & "'" &
                        " , '" & .cchr(txtnorek.Text) & "'" &
                        " , ''" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(lblcode_mbrand.Text) & "'" &
                        " , '" & .cchr(txtspek.Text) & "'" &
                        " , '" & .cchr(cmbcurrb.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgbeli.Text) & "'" &
                        " , '" & .cchr(cmbcurrj.SelectedValue) & "'" &
                        " , '" & .cnum(txthrgjual.Text) & "'" &
                        " , '" & .cchr(txtnoteb.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Merk : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btnbrowseconsignee_Click(sender As Object, e As EventArgs) Handles btnbrowseconsignee.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM mconsignee WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
            .Columns("hp1").Visible = True : .Columns("hp2").HeaderText = "Phone #1"
            .Columns("hp1").Visible = True : .Columns("hp2").HeaderText = "Phone #2"
            .Columns("alamat").Visible = True : .Columns("alamat").HeaderText = "Alamat"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[mconsignee]tconsign")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Consignee"

        cekform(a, "SEARCH", Me)
    End Sub


    Private Sub btnbrowsepic1_Click(sender As Object, e As EventArgs)
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(opf.FileName)
            lblpic1.Text = opf.FileName
        End If
    End Sub

    Private Sub btnbrowsepic2_Click(sender As Object, e As EventArgs)
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(opf.FileName)
            lblpic2.Text = opf.FileName
        End If
    End Sub

    Private Sub btnbrowsepic3_Click(sender As Object, e As EventArgs)
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(opf.FileName)
            lblpic3.Text = opf.FileName
        End If
    End Sub

    Private Sub SyncOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyncOnlineToolStripMenuItem.Click
        With cl
            If lbldocstatus.Text = "TERJUAL" Then
                .msgError("Tidak bisa penarikan karena barang sudah terjual !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Penarikan Consignment : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans("UPDATE tconsign set docstat = 'R' where no = '" & txtno.Text & "'")

                '-- UPDATE STATUS ITEM
                .execCmdTrans("UPDATE mitem set itemstatus = 'R' where code = '" & txtcode_mitem.Text & "' and tstatus = 1")

                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Penarikan Consignment!", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnBrowse1_Click(sender As Object, e As EventArgs) Handles BtnBrowse1.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM mbrand WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[mbrand]tconsign")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Brand/Merk"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub ResetNewCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetNewCustomerToolStripMenuItem.Click
        txtcode_mconsignee.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('mconsignee','') END TRY BEGIN CATCH SELECT '' END CATCH")
        txtname_mconsignee.Text = ""
        txthp1.Text = ""
        txthp2.Text = ""
        txtalamat.Text = ""

        txtname_mconsignee.Text = ""
        lblcode_mconsignee.Text = ""
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(opf.FileName)
            lblpic1.Text = opf.FileName

        End If
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



    Private Sub PictureBox3_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(opf.FileName)
            lblpic3.Text = opf.FileName

        End If
    End Sub


    Private Sub PictureBox4_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox4.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox4.Image = Image.FromFile(opf.FileName)
            lblpic4.Text = opf.FileName
        End If
    End Sub



    Private Sub PictureBox5_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox5.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox5.Image = Image.FromFile(opf.FileName)
            lblpic5.Text = opf.FileName
        End If
    End Sub

    Private Sub btnbrowsemitem_Click(sender As Object, e As EventArgs) Handles btnbrowsemitem.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA INNER JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1"

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
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[mitem]tconsign")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Barang/Artikel"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub PictureBox6_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox6.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox5.Image = Image.FromFile(opf.FileName)
            lblpic5.Text = opf.FileName
        End If
    End Sub

    Private Sub ResetPictureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPictureToolStripMenuItem.Click
        PictureBox1.Image = Nothing
        lblpic1.Text = ""
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        PictureBox2.Image = Nothing
        lblpic2.Text = ""
    End Sub

    Private Sub ContextMenuStrip3_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip3.Opening
        PictureBox3.Image = Nothing
        lblpic3.Text = ""
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        PictureBox4.Image = Nothing
        lblpic4.Text = ""
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        PictureBox5.Image = Nothing
        lblpic5.Text = ""
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


                rpt.Load(direcCetakan & "\rpttpo.rpt")

                rpt.SetDataSource(cl.table(
                 " SELECT * FROM vtinvoice " &
                 " WHERE id = '" & idmaster & "' " &
                 " "))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        '-- DISABLE ITEMS
        txtcode_mitem.ReadOnly = False
        txtname_mitem.ReadOnly = False
        cmbtype.Enabled = True
        cmbcurrb.Enabled = True
        cmbcurrj.Enabled = True
        txthrgbeli.ReadOnly = False
        txthrgjual.ReadOnly = False
        txtspek.ReadOnly = False
        txtsze.ReadOnly = False
        txtmtrl.ReadOnly = False
        txtcolor.ReadOnly = False
        cmbmuom.Enabled = True

        txtname_mbrand.ReadOnly = False


        cmbspec1.Enabled = True
        cmbspec2.Enabled = True
        cmbspec3.Enabled = True
        cmbspec4.Enabled = True
        cmbspec5.Enabled = True
        cmbspec6.Enabled = True
        cmbspec7.Enabled = True
        cmbspec8.Enabled = True
        cmbspec9.Enabled = True
        cmbspec10.Enabled = True
        cmbspec11.Enabled = True
        cmbspec12.Enabled = True
        cmbspec13.Enabled = True
        cmbspec14.Enabled = True
        cmbspec15.Enabled = True
        cmbspec16.Enabled = True
        txtnotespec.ReadOnly = False

        PictureBox1.Enabled = True
        PictureBox2.Enabled = True
        PictureBox3.Enabled = True
        PictureBox4.Enabled = True
        PictureBox5.Enabled = True
        PictureBox6.Enabled = True
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        PictureBox6.Image = Nothing
        lblpic6.Text = ""
    End Sub

End Class