Imports System.Data.SqlClient
Public Class dbconfig
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
        If System.IO.File.Exists(cl.dirsetfile) = True Then
            Dim listSet As New List(Of String)
            Using reader As System.IO.StreamReader = New System.IO.StreamReader(cl.dirsetfile, True)
                Dim strLine As String = reader.ReadLine
                Do While Not strLine Is Nothing
                    listSet.Add(strLine)
                    strLine = reader.ReadLine
                Loop
                reader.Close()
            End Using
            txtserver.Text = listSet.Item(0)
            txtusr.Text = listSet.Item(1)
            txtpass.Text = listSet.Item(2)

            btngetdb.PerformClick()

            cmbdb.Text = listSet.Item(3)
        End If
    End Sub
    Private Sub sysconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbdb.Enabled = False
        cmbdb.Items.Clear()
        If System.IO.File.Exists(cl.dirsetfile) = True Then
            loaddata()
        End If

        txtserver.Select()
    End Sub

    Private Sub btngetdb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngetdb.Click
        Try
            cmbdb.Items.Clear()

            If txtserver.Text = "" Then
                cl.msgError("Please input server !", "Information") : txtserver.Select()
                Exit Sub : End If
            If txtusr.Text = "" Then
                cl.msgError("Please input user !", "Information") : txtusr.Select()
                Exit Sub : End If


            Dim conn As New SqlConnection

            Dim msstr As String =
              " Server=" & txtserver.Text & "; " &
              " user id=" & txtusr.Text & "; " &
              " password=" & txtpass.Text & ";"

            Dim builder As New SqlConnectionStringBuilder(msstr)

            Dim dtdb, dtresc As DataTable
            Dim restrictions(3) As String

            Try
                Using connection As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
                    connection.Open()
                    dtdb = connection.GetSchema("Databases")
                    connection.Close()
                End Using
            Catch ex As Exception
                cl.msgError("Tidak bisa Mengambil Database !" & vbNewLine & vbNewLine & ex.ToString, "Gagal Ambil Database")
                Exit Sub
            End Try

            Dim holdarrtblname As New ArrayList
            For i As Integer = 0 To dtdb.Rows.Count - 1
                builder("Database") = dtdb.Rows(i).Item("database_name")
                Using connection As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
                    connection.Open()
                    restrictions(1) = "dbo"
                    dtresc = connection.GetSchema("Tables", restrictions)
                    For y As Integer = 0 To dtresc.Rows.Count - 1
                        If dtresc.Rows(y).Item("table_name") = "swisyplb" Then
                            holdarrtblname.Add(dtresc.Rows(y).Item("table_catalog"))

                        End If
                    Next
                    connection.Close()
                End Using
            Next

            cmbdb.Items.Clear()
            For a As Integer = 0 To holdarrtblname.Count - 1
                cmbdb.Items.Add(holdarrtblname.Item(a))
            Next
            If holdarrtblname.Count = 0 Then
                MsgBox("Database doesn't exist, please contact Administrator !", MsgBoxStyle.Exclamation, "Information")
                Exit Sub
            Else
                cmbdb.SelectedIndex = 0
                cmbdb.Enabled = True
                cmbdb.Select()
            End If

            conn.Close()

        Catch ex As Exception
            cl.msgError(ex.Message)
            Exit Sub
        End Try


    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
        If System.IO.File.Exists(cl.dirsetfile) = False Then
            menuutama.Dispose()
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtserver.Text = "" Then
            cl.msgError("Please input server !", "Information") : txtserver.Select()
            Exit Sub : End If
        If txtusr.Text = "" Then
            cl.msgError("Please input user !", "Information") : txtusr.Select()
            Exit Sub : End If
        If cmbdb.Text = "" Then
            cl.msgError("Please choose database !", "Information") : cmbdb.Select()
            Exit Sub : End If

        Dim msstr As String =
              " Server=" & txtserver.Text & "; " & _
              " user id=" & txtusr.Text & "; " & _
              " password=" & txtpass.Text & "; " & _
              " Database=" & cmbdb.Text & ";"

        Dim connection As SqlConnection
        Try
            connection = New SqlConnection(msstr)
            connection.Open()
            connection.Close()
        Catch ex As Exception
            cl.msgError("Koneksi ke Database " & cmbdb.Text & " Gagal !", "Informasi Test Koneksi")
            Exit Sub
        End Try

        
        If System.IO.File.Exists(cl.dirsetfile) = True Then
            System.IO.File.Delete(cl.dirsetfile)
        ElseIf System.IO.File.Exists(cl.dirsetfile) = False Then
            System.IO.Directory.CreateDirectory("C:\SWISYPLB")
        End If

        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(cl.dirsetfile, True)
            writer.WriteLine(txtserver.Text)
            writer.WriteLine(txtusr.Text)
            writer.WriteLine(txtpass.Text)
            writer.WriteLine(cmbdb.Text)
        End Using

        Me.Dispose()

        For Each child As Form In menuutama.MdiChildren
            child.Close()
        Next child

        'If System.IO.File.Exists(cl.dirserfile) = False Then
        '    cekform(cgetserial, "NEW", Me)
        '    Exit Sub
        'Else
        cekform(login, "NEW", Me)
        'End If

        'If cl.readData("SELECT ISNULL(strvl,'') FROM csetting") = "" Then
        '    cl.msgInform("Setting awal belum dilakukan !" & vbNewLine & vbNewLine & _
        '            "Lakukan Setting Company", "Informasi")
        '    cekform(csetting, "NEW", Me)
        'Else
        '    cl.msgInform("Sistem Konfigurasi Berhasil !", "Informasi")
        '    cekform(login, "NEW", Me)
        'End If
    End Sub
End Class