
Imports MySql.Data.MySqlClient
Public Class dbconfig2
    Dim idmaster As Integer = 0

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
        ByVal keyData As System.Windows.Forms.Keys) As Boolean


        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
            btnsave.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F2) Then
            btngetdb.PerformClick()
        End If


        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub loaddata()
        If System.IO.File.Exists(dirSettingFilePath) = True Then
            Dim listSet As New List(Of String)
            Using reader As System.IO.StreamReader = New System.IO.StreamReader(dirSettingFilePath, True)
                Dim strLine As String = reader.ReadLine
                Do While Not strLine Is Nothing
                    listSet.Add(strLine)
                    strLine = reader.ReadLine
                Loop
                reader.Close()
            End Using
            txtserver.Text = listSet.Item(0)
            txtport.Text = listSet.Item(1)
            txtusr.Text = listSet.Item(2)
            txtpass.Text = listSet.Item(3)

            btngetdb.PerformClick()

            cmbdb.Text = listSet.Item(4)
        End If
    End Sub
    Private Sub sysconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbdb.Enabled = False
        cmbdb.Items.Clear()
        loaddata()
    End Sub

    Private Sub btngetdb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngetdb.Click
        cmbdb.Items.Clear()

        If txtserver.Text = "" Then
            cl.msgError("Server tidak boleh kosong !", "Gagal Konfigurasi") : txtserver.Select()
            Exit Sub : End If
        If txtport.Text = "" Then
            cl.msgError("Port tidak boleh kosong !", "Gagal Konfigurasi") : txtport.Select()
            Exit Sub : End If
        If txtusr.Text = "" Then
            cl.msgError("User tidak boleh kosong !", "Gagal Konfigurasi") : txtusr.Select()
            Exit Sub : End If


        Dim conn As New MySqlConnection
        Dim msstr As String =
          " Server=" & txtserver.Text & "; " &
          " Port=" & txtport.Text & "; " &
          " Uid=" & txtusr.Text & "; " &
          " Pwd=" & txtpass.Text & ";"
        conn = New MySqlConnection(msstr)

        conn.Open()

        Dim dtTbl As New DataTable
        Dim myAdapter As New MySqlDataAdapter
        myAdapter = New MySqlDataAdapter("SHOW DATABASES", msstr)
        myAdapter.Fill(dtTbl)

        Dim myStatus As Integer = 0

        For i As Integer = 0 To dtTbl.Rows.Count - 1
            Dim dtTbl2 As New DataTable
            myAdapter = New MySqlDataAdapter("SHOW TABLES FROM swiappsc_bc", msstr)
            myAdapter.Fill(dtTbl2)

            myStatus = 0
            For y As Integer = 0 To dtTbl2.Rows.Count - 1
                Dim tempTbl As String = cl.cchr(dtTbl2.Rows(y).Item(0))
                If UCase(tempTbl) = "SWISYTP" Then
                    myStatus = 1
                End If
            Next

            If myStatus = 1 Then
                cmbdb.Items.Add(dtTbl.Rows(i).Item("Database"))
            End If

            '  GroupBox1.Enabled = True


        Next

        myAdapter.Dispose()
        myAdapter = Nothing

        conn.Close()



        If cmbdb.Items.Count = 0 Then
            cl.msgError("Tidak ada Database untuk server ini", "Tidak ada Database")
            Exit Sub
        Else
            cmbdb.Enabled = True
            cmbdb.Focus()
            cmbdb.SelectedIndex = 0

        End If

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
        If System.IO.File.Exists(cl.dirsetfile) = False Then
            menuutama.Dispose()
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtserver.Text = "" Then
            cl.msgError("Server tidak boleh kosong !", "Gagal Konfigurasi") : txtserver.Select()
            Exit Sub : End If
        If txtport.Text = "" Then
            cl.msgError("Port tidak boleh kosong !", "Gagal Konfigurasi") : txtport.Select()
            Exit Sub : End If
        If txtusr.Text = "" Then
            cl.msgError("User tidak boleh kosong !", "Gagal Konfigurasi") : txtusr.Select()
            Exit Sub : End If
        If cmbdb.Text = "" Then
            cl.msgError("Database tidak boleh kosong !", "Gagal Konfigurasi") : cmbdb.Select()
            Exit Sub : End If

        Dim msstr As String =
              " Server=" & txtserver.Text & "; " &
              " Port=" & txtport.Text & ";" &
              " Uid=" & txtusr.Text & "; " &
              " Pwd=" & txtpass.Text & "; " &
              " Database=" & cmbdb.Text & ";"

        Dim connection As MySqlConnection
        Try
            connection = New MySqlConnection(msstr)
            connection.Open()
            connection.Close()
        Catch ex As Exception
            cl.msgError("Koneksi ke Database " & cmbdb.Text & " Gagal !", "Informasi Test Koneksi")
            Exit Sub
        End Try


        If System.IO.File.Exists(dirSettingFileOnline) = True Then
            System.IO.File.Delete(dirSettingFileOnline)
        ElseIf System.IO.File.Exists(dirSettingFileOnline) = False Then
            System.IO.Directory.CreateDirectory(dirSettingDirecPath)
        End If

        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(dirSettingFileOnline, True)
            writer.WriteLine(txtserver.Text)
            writer.WriteLine(txtport.Text)
            writer.WriteLine(txtusr.Text)
            writer.WriteLine(txtpass.Text)
            writer.WriteLine(cmbdb.Text)
        End Using

        Me.Dispose()

        cl.msgInform("Sistem Konfigurasi Berhasil dibuat !" & vbNewLine & vbNewLine &
                     "Silakan lakukan Login User", "Konfigurasi Selesai")

        For Each child As Form In menuutama.MdiChildren
            child.Close()
        Next child

        cekform(login, "NEW", Me)
    End Sub
End Class