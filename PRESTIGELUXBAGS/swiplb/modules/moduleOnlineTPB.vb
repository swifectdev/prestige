Imports System.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.IO
Imports MySql.Data.MySqlClient

Module moduleOnlineTPB

    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    '----VARIABEL----'
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    Public dirApp As String = System.Environment.CurrentDirectory

    Public dirSetting As String = "C:\SWIOnlineBC"
    Public dirSettingAppF As String = "C:\SWIOnlineBC\SWITPB.ini"
    Public dirSerialF As String = "C:\SWITBRS\serial.ini"

    Dim serverCounter As Integer

    Private ReadOnly _md5 As MD5 = MD5.Create()
    Public Function GetMd5Hash(ByVal source As String) As String

        Dim data = _md5.ComputeHash(Encoding.UTF8.GetBytes(source))
        Dim sb As New StringBuilder()
        Array.ForEach(data, Function(x) sb.Append(x.ToString("X2")))
        Return sb.ToString()

    End Function

    Public Function VerifyMd5Hash(ByVal source As String, ByVal hash As String) As Boolean

        Dim sourceHash = GetMd5Hash(source)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        Return If(comparer.Compare(sourceHash, hash) = 0, True, False)

    End Function

    Public Function GetMd5HashBase64(ByVal source As String) As String

        Dim data = _md5.ComputeHash(Encoding.UTF8.GetBytes(source))
        Return Convert.ToBase64String(data)

    End Function

    Public Function VerifyMd5HashBase64(ByVal source As String, ByVal hash As String) As Boolean

        Dim sourceHash = GetMd5HashBase64(source)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        Return If(comparer.Compare(sourceHash, hash) = 0, True, False)

    End Function
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    '----DATABASE----'
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'

    Public mscon As New MySqlConnection
    Public mscommand As New MySqlCommand
    Public mstransaction As MySqlTransaction
    Public msreader As MySqlDataReader
    Public msadapter As New MySqlDataAdapter



    'Public ODBCConnection As New System.Data.Odbc.OdbcConnection
    'Public ODBCcommand As New System.Data.Odbc.OdbcCommand
    'Public ODBCtransaction As System.Data.Odbc.OdbcTransaction
    'Public ODBCreader As System.Data.Odbc.OdbcDataReader
    'Public ODBCadapter As New System.Data.Odbc.OdbcDataAdapter


    Public OLEStr As String
    Public OLEconnection As New OleDb.OleDbConnection
    Public OLEcommand As New OleDb.OleDbCommand
    Public OLEreader As OleDb.OleDbDataReader
    Public OLEadapter As New OleDb.OleDbDataAdapter

    Sub opendataexcel(ByVal dataSource As String)
        Try
            OLEStr = "Provider=Microsoft.Ace.OLEDB.12.0;" &
               "Data Source=" & dataSource & ";Extended Properties= Excel 12.0"
            OLEconnection = New OleDb.OleDbConnection(OLEStr)
            OLEconnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show(ex.Message, "Error Connection to File Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OLEconnection.Close()
        End Try
    End Sub
    Public Function gettabeldataexcel(ByVal dataSource As String, ByVal sql As String) As DataTable
        Try
            Call opendataexcel(dataSource)
            gettabeldataexcel = New DataTable
            OLEadapter = New OleDb.OleDbDataAdapter(sql, OLEconnection)
            OLEadapter.Fill(gettabeldataexcel)
            OLEadapter.Dispose()
            OLEadapter = Nothing
            Call closedDataOLEDB()
        Catch salah As Exception
            MessageBox.Show(salah.Message, "Cannot create table !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Sub closedDataOLEDB()
        Try
            OLEconnection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error when connection close", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OLEconnection.Close()
        End Try
    End Sub

    'buka koneksi
    Public Sub openConTPB()
        Try

            'Dim list As New List(Of String)
            'Using reader As System.IO.StreamReader =
            '    New System.IO.StreamReader(dirSettingAppF, True)
            '    Dim strLine As String = reader.ReadLine

            '    Do While Not strLine Is Nothing
            '        list.Add(strLine)
            '        strLine = reader.ReadLine
            '    Loop
            '    reader.Close()
            'End Using

            '-- 00 hostdb
            '-- 01 port
            '-- 02 user
            '-- 03 pass
            '-- 04 database
            '-- 05 folder cetakan

            'Dim msstr As String =
            '    " Server=" & list.Item(0) & "; " &
            '    " Port=" & list.Item(1) & ";" &
            '    " Uid=" & list.Item(2) & "; " &
            '    " Pwd=" & list.Item(3) & "; " &
            '    " Database=" & list.Item(4) & ";" &
            '    " Connection Timeout=30"

            Dim msstr As String =
                " Server=" & cl.readData("SELECT ipset FROM ctpb") & "; " &
                " Port=" & cl.readData("SELECT prt FROM ctpb") & ";" &
                " Uid=" & cl.readData("SELECT usr FROM ctpb") & "; " &
                " Pwd=" & cl.readData("SELECT pwd FROM ctpb") & "; " &
                " Database=" & cl.readData("SELECT db FROM ctpb") & ";" &
                " Connection Timeout=30"

            mscon = New MySqlConnection(msstr)
            mscon.Open()


        Catch ex As Exception
            MsgBox("Buka Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            mscon.Close()
        End Try
    End Sub

    'tutup koneksi
    Public Sub closeConTPB()
        Try
            mscon.Close()
        Catch ex As Exception
            MsgBox("Tutup Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            mscon.Close()
        End Try
    End Sub

    'eksekusi command query ODBC
    Public Sub execCommandTPB(ByVal query As String)
        Try
            Call openConTPB()
            mscommand.Connection = mscon
            mscommand.CommandText = query
            mscommand.ExecuteNonQuery()
            Call closeConTPB()
        Catch ex As Exception
            MsgBox("Eksekusi Query Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            mscon.Close()
        End Try
    End Sub

    'ambil data ke table
    Public Function tableTPB(ByVal query As String) As DataTable
        Try
            Call openConTPB()
            tableTPB = New DataTable
            msadapter = New MySqlDataAdapter(query, mscon)
            msadapter.SelectCommand.CommandTimeout = 600
            msadapter.Fill(tableTPB)
            msadapter.Dispose()
            msadapter = Nothing
            Call closeConTPB()
        Catch ex As Exception
            MsgBox("Masukkan data ke tabel tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            Return Nothing
        End Try
    End Function

    'ambil data ke variabel
    Public Function readDataTPB(ByVal sql As String)
        Try

            Call openConTPB()
            mscommand.Connection = mscon
            mscommand.CommandType = CommandType.Text
            mscommand.CommandText = sql
            readDataTPB = mscommand.ExecuteScalar
            mscommand.Dispose()
            Call closeConTPB()
            If IsDBNull(readDataTPB) Then : Return ""
            Else : Return readDataTPB : End If
        Catch ex As Exception
            MsgBox("Masukkan data ke variabel tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            Return Nothing
        End Try
    End Function

    Public sOpenTrans As Integer = 0
    Public sProsesTrans As Integer = 0
    Public sCloseTrans As Integer = 0

    'open ODBC Transaction
    Public Sub openTransTPB()
        Try
            sCloseTrans = 0 : sOpenTrans = 0 : sProsesTrans = 0

            'Dim list As New List(Of String)
            'Using reader As System.IO.StreamReader =
            '    New System.IO.StreamReader(dirSettingAppF, True)
            '    Dim strLine As String = reader.ReadLine

            '    Do While Not strLine Is Nothing
            '        list.Add(strLine)
            '        strLine = reader.ReadLine
            '    Loop
            '    reader.Close()
            'End Using

            Dim msstr As String =
                " Server=" & cl.readData("SELECT ipset FROM ctpb") & "; " &
                " Port=" & cl.readData("SELECT prt FROM ctpb") & ";" &
                " Uid=" & cl.readData("SELECT usr FROM ctpb") & "; " &
                " Pwd=" & cl.readData("SELECT pwd FROM ctpb") & "; " &
                " Database=" & cl.readData("SELECT db FROM ctpb") & ";" &
                " Connection Timeout=30"

            mscon = New MySqlConnection(msstr)
            mscon.Open()

            mstransaction = mscon.BeginTransaction()

            mscommand.Connection = mscon
            mscommand.Transaction = mstransaction

            sOpenTrans = 1
            sProsesTrans = 1
        Catch ex As Exception
            MsgBox("Sistem gagal buka transaksi ke Database !" & vbNewLine & vbNewLine &
                   "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical,
                   "Gagal Simpan / Update")
            mscon.Close() : sOpenTrans = 0 : Exit Sub
        End Try
    End Sub

    'Close ODBC Transaction
    Public Sub closeTransTPB(ByVal tempObj As Object)
        If sProsesTrans = 1 Then
            Try
                mstransaction.Commit()
                mscon.Close()

                sCloseTrans = 1 : sOpenTrans = 0 : sProsesTrans = 0
            Catch ex As Exception
                MsgBox("Sistem gagal tutup transaksi dari Database !" & vbNewLine & vbNewLine &
                       "System Message : " & ex.Message, MsgBoxStyle.Critical,
                       "Failed Save / Update")
                sCloseTrans = 0 : sOpenTrans = 0 : sProsesTrans = 0

                mstransaction.Rollback() : mscon.Close()
                tempObj.Select() : Exit Sub
            End Try
        Else : tempObj.Select() : Exit Sub : End If
    End Sub

    'eksekusi command query ODBC Transaction
    Public Sub execCmdTransTPB(ByVal sql As String)
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                mscommand.CommandText = sql
                mscommand.CommandTimeout = 1000
                mscommand.ExecuteNonQuery()
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal eksekusi ke Database !" & vbNewLine & vbNewLine &
                       "System Message : " & ex.Message, MsgBoxStyle.Critical,
                       "Gagal Simpan / Modifikasi")
                mscon.Close() : sProsesTrans = 0 : Exit Sub
            End Try
        Else : Exit Sub : End If
    End Sub

    'get data ODBC Transaction
    Public Function getDataTransTPB(ByVal query As String)
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                mscommand.CommandText = query
                getDataTransTPB = mscommand.ExecuteScalar
                If IsDBNull(getDataTransTPB) Then : Return ""
                Else : Return getDataTransTPB : End If
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal ambil data ke Database !" & vbNewLine & vbNewLine &
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical,
                       "Gagal Ambil Data")
                mstransaction.Connection.Close() : mscon.Close() : sProsesTrans = 0
                getDataTransTPB = "0" : Exit Function
            End Try
        Else : getDataTransTPB = "0" : Exit Function : End If
    End Function

    'get data table ODBC Transaction
    Public Function getTableTransTPB(ByVal query As String) As DataTable
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                getTableTransTPB = New DataTable
                mscommand.CommandText = query
                Dim dataAdapter As New MySqlDataAdapter(mscommand)
                dataAdapter.Fill(getTableTransTPB)
                dataAdapter.Dispose()
                dataAdapter = Nothing
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal ambil table ke Database !" & vbNewLine & vbNewLine &
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical,
                       "Gagal Ambil Data")
                mstransaction.Connection.Close() : mscon.Close() : sProsesTrans = 0
                getTableTransTPB = Nothing : Exit Function
            End Try
        Else : getTableTransTPB = Nothing : Exit Function : End If
    End Function
End Module
