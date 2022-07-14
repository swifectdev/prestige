Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.SqlClient
Public Class mitem
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
        '  txtno.Text = cl.readData("SELECT dbo.fgetcode('mitem','" & Now() & "')")
        ' txtcode.Text = cl.readData("SELECT dbo.fgetcode('mitem','" & Now() & "')")
    End Sub

    Private Sub clearData()
        txtcode.Text = ""
        txtname.Text = ""

        txtname_mbrand.Text = ""
        txtname_mconsignee.Text = ""

        lblcode_mbrand.Text = ""
        lblcode_mconsignee.Text = ""

        txthrgbeli.Text = 0
        txthrgjual.Text = 0
        txtqty.Text = 1
        txtspek.Text = ""

        txtsze.Text = ""
        txtcolor.Text = ""
        txtmtrl.Text = ""

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

        cmbspec17.SelectedIndex = 1
        cmbspec18.SelectedIndex = 1
        cmbspec19.SelectedIndex = 1

        txtnotespec.Text = ""

        txtbasetype.Text = "ITEM"
        txtitemstatus.Text = "AVAILABLE"

        dtconsign.Value = Now
        txthp1_mconsignee.Text = ""

        txtno.Text = ""

        txtstock.Text = 0

    End Sub

    Private Sub loadcmb()
        Dim dtemptp As DataTable = cl.table(
            "SELECT code AS 'value', name AS 'display' FROM mtype WHERE tstatus = 1 AND code <> 'JW'")

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

        Dim dtemptp5 As DataTable = cl.table(
            "SELECT code AS 'value', code + ' - ' + name AS 'display' FROM mlocation WHERE tstatus = 1")

        cmbmlocation.DataSource = dtemptp5
        cmbmlocation.ValueMember = "value"
        cmbmlocation.DisplayMember = "display"

    End Sub


    Public Sub changestatform(ByVal tstatform As String)
        statform = tstatform
        If tstatform = "new" Then
            clearData()
            btnsave.Text = "Save"
            gencode()
            btndelete.Visible = False
            loadcmb()
            cmbmlocation.Enabled = True
            txtcode.ReadOnly = False
            btnprint.Visible = False

            Label37.Visible = False
            txtstock.Visible = False
        ElseIf tstatform = "upd" Then

            btnsave.Text = "Update"
            btndelete.Visible = True
            cmbmlocation.Enabled = False
            txtcode.ReadOnly = True
            btnprint.Visible = True

            Label37.Visible = True
            txtstock.Visible = True

        End If
        Me.Select() : txtname.Select()
    End Sub

    Private Sub mbranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        changestatform("new")
    End Sub

    Private Sub mbp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.BringToFront() : Me.Select() : txtname.Select()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        With cl

            '------ start validasi
            If validatetxtnull(txtcode, "Kode/No Tag Barang harus di isi !", "Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtname, "Nama Barang harus di isi !", "Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtname_mconsignee, "Consignee harus di isi !", "Information") = 1 Then : Exit Sub : End If
            If validatetxtnull(txtno, "No harus di isi !", "Information") = 1 Then : Exit Sub : End If
            '------ end validasi


            If btnsave.Text = "Save" Then
                If cl.readData("SELECT COUNT(id) FROM mitem where code = '" & txtcode.Text & "' and tstatus = 1") > 0 Then
                    cl.msgError("No Tag sudah ada, mohon untuk dapat di checking kembali !", "Informasi")
                    Exit Sub
                End If
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mitem'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC smitem " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , " & .cdt(dtconsign) & "" &
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
                        " , '" & .cchr(cmbmlocation.SelectedValue) & "'" &
                        " , 'ITEM'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
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
                        " , '" & .cchr(Mid(cmbspec17.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec18.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec19.Text, 1, 1)) & "'" &
                        " , '" & .cchr(txtnotespec.Text) & "'" &
                        " , ''" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")

                    '-- UPDATE STOCK TO MATCH WITH QTY
                    ' .execCmdTrans("UPDATE mitem set stock = '" & cl.cnum(txtqty.Text) & "' WHERE code = '" & txtcode.Text & "' and tstatus = 1")

                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        '-- SAVE PICTURES
                        If lblpic1.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,1,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic2.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,2,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic3.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,3,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic4.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,4,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic5.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,5,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic6.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,6,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        .msgInform("Success Save : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mitem'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtname.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC smitem " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , " & .cdt(dtconsign) & "" &
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
                        " , '" & .cchr(cmbmlocation.SelectedValue) & "'" &
                        " , 'ITEM'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
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
                        " , '" & .cchr(Mid(cmbspec17.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec18.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec19.Text, 1, 1)) & "'" &
                        " , '" & .cchr(txtnotespec.Text) & "'" &
                        " , ''" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'upd'" &
                        " , '" & idmaster & "'" &
                        "")
                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        '-- SAVE PICTURES
                        If lblpic1.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,1,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic2.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,2,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic3.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,3,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic4.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,4,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic5.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,5,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        If lblpic6.Text <> "" Then
                            cl.openCon()
                            Dim query As String = "INSERT INTO mitempic (code,picOrder,picName,picData) values (@code,6,@name,@image)"
                            Dim ms As New MemoryStream
                            PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)

                            cmd = New SqlCommand(query, cl.sqlcon)
                            cmd.Parameters.AddWithValue("@code", txtcode.Text)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            cmd.Parameters.AddWithValue("@image", ms.ToArray)
                            cmd.ExecuteNonQuery()
                            cl.closeCon()
                        End If

                        .msgInform("Success Update : " & txtname.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            End If
        End With
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New mitem
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA INNER JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.code_mtype <> 'JW'"

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
            .Columns("phone_mconsignee").Visible = True : .Columns("phone_mconsignee").HeaderText = "HP"
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Consign"
            .Columns("qty").Visible = True : .Columns("qty").HeaderText = "Stock"
            .Columns("dtconsign").Visible = True : .Columns("dtconsign").HeaderText = "Tgl Msk"
        End With
        a.loadStatusTempForm(Me, Me.txtcode, "[mitem]mitem")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Item/Barang"
        a.Panel1.Visible = True
        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'mitem'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            Dim tny As Integer
            tny = .msgYesNo("Delete Barang/Artikel : " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                        "EXEC smitem " &
                        " '" & .cchr(txtno.Text) & "'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
                        " , '" & .cchr(txtname.Text) & "'" &
                        " , " & .cdt(dtconsign) & "" &
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
                        " , '" & .cchr(cmbmlocation.SelectedValue) & "'" &
                        " , 'ITEM'" &
                        " , '" & .cchr(txtcode.Text) & "'" &
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
                        " , '" & .cchr(Mid(cmbspec17.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec18.Text, 1, 1)) & "'" &
                        " , '" & .cchr(Mid(cmbspec19.Text, 1, 1)) & "'" &
                        " , '" & .cchr(txtnotespec.Text) & "'" &
                        " , ''" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Barang/Artikel : " & txtname.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub


    Private Sub btnbrowsepic2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnbrowsepic3_Click(sender As Object, e As EventArgs)

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

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[mconsignee]mitem")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Consignee"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub txtpic1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub txtpic2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btnbrowsebrand_Click(sender As Object, e As EventArgs) Handles btnbrowsebrand.Click
        Dim a As New tsearch
        Dim sqlStr As String =
                "SELECT * FROM mbrand WHERE tstatus = 1"

        With a.dgview : .DataSource = cl.table(sqlStr)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("code").Visible = True : .Columns("code").HeaderText = "Code"
            .Columns("name").Visible = True : .Columns("name").HeaderText = "Nama"
        End With

        a.loadStatusTempForm(Me, Me.txtname_mconsignee, "[mbrand]mitem")
        a.loadSQLSearch(sqlStr, 1)
        a.Text = "Pencarian : Brand/Merk"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

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

    Private Sub ResetPictureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPictureToolStripMenuItem.Click
        PictureBox1.Image = Nothing
        lblpic1.Text = ""
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        PictureBox2.Image = Nothing
        lblpic2.Text = ""
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        PictureBox3.Image = Nothing
        lblpic3.Text = ""
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        PictureBox4.Image = Nothing
        lblpic4.Text = ""
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        PictureBox5.Image = Nothing
        lblpic5.Text = ""
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        PictureBox6.Image = Nothing
        lblpic6.Text = ""
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub btngetno_Click(sender As Object, e As EventArgs) Handles btngetno.Click
        Dim tny As Integer
        tny = cl.msgYesNo("Ambil nomor baru ?", "Confirmation")
        If tny = vbYes Then
            txtno.Text = cl.readData("SELECT dbo.fgetcode('mitem','" & Now() & "')")
        Else
            txtno.Text = cl.readData("SELECT TOP 1 no FROM mitem WHERE tstatus = 1 ORDER BY no DESC")
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        With cl
            Try
                '------PRINT INVOICE
                Dim rpt As New ReportDocument
                Dim f As New print


                rpt.Load(direcCetakan & "\rptmitem.rpt")

                rpt.SetDataSource(cl.table(
                 " SELECT * FROM vitem " &
                 " WHERE no = '" & txtno.Text & "' " &
                 " "))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        With cl

            If txtitemstatus.Text = "PENARIKAN/CANCEL" Or txtitemstatus.Text = "TERJUAL" Then
                .msgError("Item sudah di retur atau sudah terjual !", "Informasi")
                Exit Sub
            End If

            Dim tny As Integer
            tny = .msgYesNo("Retur/Penarikan item " & txtname.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                    "UPDATE mitem set itemstatus = 'R', qty = 0 WHERE id = '" & idmaster & "'")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then

                    .msgInform("Item telah di retur !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub PictureBox6_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox6.DoubleClick
        Dim opf As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files(*.Jpg)|*.jpg"
        If opf.ShowDialog = DialogResult.OK Then
            PictureBox6.Image = Image.FromFile(opf.FileName)
            lblpic6.Text = opf.FileName
        End If
    End Sub
End Class