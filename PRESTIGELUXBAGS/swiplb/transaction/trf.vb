Imports CrystalDecisions.CrystalReports.Engine
Public Class trf
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
        txtno.Text = cl.readData("BEGIN TRY SELECT dbo.fgetcode('trf','" & Format(CDate(dttdate.Value), "yy") & "') END TRY BEGIN CATCH SELECT '' END CATCH")
    End Sub

    Private Sub clearData()

        '------------------------------------------------------------------------------------
        txtcode_mitem.Text = ""
        txtname_mitem.Text = ""
        txtspek_mitem.Text = ""

        txthrgbeli.Text = 0

        '------------------------------------------------------------------------------------
        lblcode_mbrand.Text = ""
        lblcode_mconsignee.Text = ""
        lblcode_mitem.Text = ""
        txtnotedoc.Text = ""


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
        txtqty.Text = 1

        ' lbldocstatus.Text = "OPEN"
        '  lbldocstatus.Visible = True

        dttdate.Value = Now
        txtnamembrand_mitem.Text = ""
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
            "SELECT code AS 'value', name AS 'display' FROM mlocation WHERE tstatus = 1")

        cmbcode_mlocationfr.DataSource = dtemptp3
        cmbcode_mlocationfr.ValueMember = "value"
        cmbcode_mlocationfr.DisplayMember = "display"

        Dim dtemptp4 As DataTable = cl.table(
            "SELECT code AS 'value', name AS 'display' FROM mlocation WHERE tstatus = 1")

        cmbcode_mlocationto.DataSource = dtemptp4
        cmbcode_mlocationto.ValueMember = "value"
        cmbcode_mlocationto.DisplayMember = "display"

        Dim dtemptp5 As DataTable = cl.table(
            "SELECT code AS 'value', code AS 'display' FROM muom WHERE tstatus = 1")

        cmbmuom.DataSource = dtemptp5
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
            '------ end validasi


            If btnsave.Text = "Save" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canadd from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'trf'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Simpan data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC strf " &
                        " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbcode_mlocationfr.SelectedValue) & "'" &
                        " , '" & .cchr(cmbcode_mlocationto.SelectedValue) & "'" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype_mitem.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(txtnamembrand_mitem.Text) & "'" &
                        " , '" & .cchr(txtspek_mitem.Text) & "'" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtnotedoc.Text) & "'" &
                        " , '" & idusr & "'" &
                        " , 'new'" &
                        " , '0'" &
                        "")

                    .closeTrans(btnsave)
                    If .sCloseTrans = 1 Then
                        .msgInform("Success Save : " & txtno.Text & " !", "Information")
                        changestatform("new") : End If
                End If
            ElseIf btnsave.Text = "Update" Then
                '----------USER AUTHORIZATION CHECK--------------'
                If .readData("SELECT canupdate from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'trf'") = "N" Then
                    .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                    Exit Sub
                End If
                '---------------------END------------------------'
                Dim tny As Integer
                tny = .msgYesNo("Update data : " & txtno.Text & " ?", "Confirmation")
                If tny = vbYes Then
                    .openTrans()
                    .execCmdTrans(
                        "EXEC strf " &
                        " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbcode_mlocationfr.SelectedValue) & "'" &
                        " , '" & .cchr(cmbcode_mlocationto.SelectedValue) & "'" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype_mitem.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(txtnamembrand_mitem.Text) & "'" &
                        " , '" & .cchr(txtspek_mitem.Text) & "'" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , '" & .cchr(txtnotedoc.Text) & "'" &
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
        Dim frm As New trf
        cekform(frm, "NEW", Me)
    End Sub

    Private Sub btnlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlist.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.* FROM trf TA WHERE TA.tstatus = 1"

        With a.dgview : .DataSource = cl.table(sql)
            For i As Integer = 0 To .Columns.Count - 1 : .Columns(i).Visible = False : Next
            .Columns("no").Visible = True : .Columns("no").HeaderText = "No Trf"
            .Columns("tdate").Visible = True : .Columns("tdate").HeaderText = "Tgl Trf"
            .Columns("code_mitem").Visible = True : .Columns("code_mitem").HeaderText = "No Tag"
            .Columns("code_mlocationfr").Visible = True : .Columns("code_mlocationfr").HeaderText = "Lokasi Dari"
            .Columns("code_mlocationto").Visible = True : .Columns("code_mlocationto").HeaderText = "Lokasi Tujuan"
        End With
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[trf]trf")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Transfer Lokasi"

        cekform(a, "SEARCH", Me)
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        With cl
            '----------USER AUTHORIZATION CHECK--------------'
            If .readData("SELECT candelete from cusrpriv WHERE id_cusr = '" & idusr & "' AND code_capp = 'trf'") = "N" Then
                .msgError("User tidak dapat melakukan tindakan ini ! Mohon untuk check setting otorisasi !", "Informasi")
                Exit Sub
            End If
            '---------------------END------------------------'

            Dim tny As Integer
            tny = .msgYesNo("Delete Merk : " & txtno.Text & " ?", "Confirmation")
            If tny = vbYes Then
                .openTrans()
                .execCmdTrans(
                        "EXEC strf " &
                        " '" & .cchr(txtno.Text) & "'" &
                       " , " & .cdt(dttdate) & "" &
                        " , '" & .cchr(cmbcode_mlocationfr.SelectedValue) & "'" &
                        " , '" & .cchr(cmbcode_mlocationto.SelectedValue) & "'" &
                        " , '" & .cchr(txtcode_mitem.Text) & "'" &
                        " , '" & .cchr(txtname_mitem.Text) & "'" &
                        " , '" & .cchr(cmbtype_mitem.SelectedValue) & "'" &
                        " , '" & .cnum(txtqty.Text) & "'" &
                        " , '" & .cchr(cmbmuom.SelectedValue) & "'" &
                        " , '" & .cchr(txtnamembrand_mitem.Text) & "'" &
                        " , '" & .cchr(txtspek_mitem.Text) & "'" &
                        " , '" & .cchr(txtcode_mconsignee.Text) & "'" &
                        " , ''" &
                        " , '" & idusr & "'" &
                        " , 'del'" &
                        " , '" & idmaster & "'" &
                        "")
                .closeTrans(btnsave)
                If .sCloseTrans = 1 Then
                    .msgInform("Success Delete Transfer Lokasi : " & txtno.Text & " !", "Information")
                    changestatform("new") : End If
            End If
        End With
    End Sub

    Private Sub btnbrowsecust_Click(sender As Object, e As EventArgs) Handles btnbrowsecust.Click
        Dim a As New tsearch

        Dim sql As String = " SELECT TA.*, TB.name 'name_mbrand', TC.name 'name_mconsignee', TC.hp1 'phone_mconsignee' " &
            " FROM mitem TA INNER JOIN mbrand TB ON TA.code_mbrand = TB.code " &
            " LEFT JOIN mconsignee TC ON TA.code_mconsign = TC.code WHERE TA.tstatus = 1 AND TC.tstatus = 1 AND TA.itemstatus = 'O'"

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
        a.loadStatusTempForm(Me, Me.txtcode_mitem, "[mitem]trf")
        a.loadSQLSearch(sql, 1)
        a.Text = "Pencarian Item/Barang"

        cekform(a, "SEARCH", Me)
    End Sub


    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

End Class