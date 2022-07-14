Imports System.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient

Public Class mainClass

    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    '----VARIABEL----'
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    Public dirapp As String = System.Environment.CurrentDirectory

    Public dirsetfile As String = "C:\SWISYPLB\setting.ini"
    Public dirserfile As String = "C:\SWISYPLB\serial.ini"

    Public dirimgfolder As String = dirapp & "\img"
    Public dirprintfolder As String = dirapp & "\print"
    Public diropeningdbfolder As String = dirapp & "\opdb"

    Private ReadOnly _md5 As MD5 = MD5.Create()
    Public Function getmd5hash(ByVal source As String) As String

        Dim data = _md5.ComputeHash(Encoding.UTF8.GetBytes(source))
        Dim sb As New StringBuilder()
        Array.ForEach(data, Function(x) sb.Append(x.ToString("X2")))
        Return sb.ToString()

    End Function

    Public Function verifymd5hash(ByVal source As String, ByVal hash As String) As Boolean

        Dim sourceHash = getmd5hash(source)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        Return If(comparer.Compare(sourceHash, hash) = 0, True, False)

    End Function

    Public Function getmd5hashbase64(ByVal source As String) As String

        Dim data = _md5.ComputeHash(Encoding.UTF8.GetBytes(source))
        Return Convert.ToBase64String(data)

    End Function

    Public Function verifymd5hashbase64(ByVal source As String, ByVal hash As String) As Boolean

        Dim sourceHash = getmd5hashbase64(source)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        Return If(comparer.Compare(sourceHash, hash) = 0, True, False)

    End Function

    Public Function simplecrypt(ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String = "", i As Integer
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar =
                CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar =
                CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    '----VALIDASI----'
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'

    Public Function cdt(ByVal dt As System.Windows.Forms.DateTimePicker)
        Dim hasil As String
        If dt.Checked = True Then : hasil = "'" & Format(dt.Value, "yyyyMMdd") & "'" : Else : hasil = "NULL" : End If
        Return hasil
    End Function
    Public Function cdtfull(ByVal dt As System.Windows.Forms.DateTimePicker)
        Dim hasil As String
        If dt.Checked = True Then : hasil = "'" & Format(dt.Value, "yyyyMMdd hh:mm:ss") & "'" : Else : hasil = "NULL" : End If
        Return hasil
    End Function
    Public Function cchr(ByVal str, Optional ByVal def = "")
        Try
            If IsDBNull(str) Then : Return def
            ElseIf CStr(str) <> "" Then : Return CStr(str).Replace("'", "''")
            Else : Return CStr(str)
            End If
        Catch ex As Exception
            msgError("Can't convert to character string !", "Error System") : Return ""
        End Try
    End Function
    Public Function cnum(ByVal str, Optional ByVal def = 0)
        Try
            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return CDec(str)
            End If
        Catch ex As Exception
            msgError("Can't convert to number !", "Error System") : Return 0
        End Try
    End Function
    Public Function cdisnum(ByVal str, Optional ByVal def = 0)
        Try
            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return Format(Val(CDec(str)), "###,##0")
            End If
        Catch ex As Exception
            msgError("Can't convert to display number !", "Error System") : Return 0
        End Try
    End Function
    Public Function ccur(ByVal str, Optional ByVal def = 0)
        Try
            Dim tempNumericCur As String = "0.00"

            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
            End If
        Catch ex As Exception
            msgError("Can't convert to currency !", "Error System") : Return 0
        End Try
    End Function

    Public Function ccur2(ByVal str, Optional ByVal def = 0)
        Try
            Dim tempNumericCur As String = "0.000000"

            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
            End If
        Catch ex As Exception
            msgError("Can't convert to currency !", "Error System") : Return 0
        End Try
    End Function

    Public Function ccur4(ByVal str, Optional ByVal def = 0)
        Try
            Dim tempNumericCur As String = "0.00000"

            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
            End If
        Catch ex As Exception
            msgError("Can't convert to currency !", "Error System") : Return 0
        End Try
    End Function
    Public Function chkdgnull(ByVal tempDG As DataGridView, ByVal nameColumn As String)
        Dim cntRowEntry As Integer = 0
        For i As Integer = 0 To tempDG.Rows.Count - 1
            If cnum(tempDG.Item(nameColumn, i).Value) <> 0 Then
                cntRowEntry += 1
            End If
        Next
        Return cntRowEntry
    End Function
    Public Function cchkdgnullstr(ByVal tempDG As DataGridView, ByVal nameColumn As String)
        Dim cntRowEntry As Integer = 0
        For i As Integer = 0 To tempDG.Rows.Count - 1
            If cchr(tempDG.Item(nameColumn, i).Value) <> "" Then
                cntRowEntry += 1
            End If
        Next
        Return cntRowEntry
    End Function
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'
    '----DATABASE----'
    '------------------------------------------------------------------------------------------------'
    '------------------------------------------------------------------------------------------------'

    Public sqlcon As New SqlConnection
    Public sqlcommand As New SqlCommand
    Public sqltransaction As SqlTransaction
    Public sqlreader As SqlDataReader
    Public sqladapter As New SqlDataAdapter

    Public OLEStr As String
    Public OLEconnection As New OleDb.OleDbConnection
    Public OLEcommand As New OleDb.OleDbCommand
    Public OLEreader As OleDb.OleDbDataReader
    Public OLEadapter As New OleDb.OleDbDataAdapter

    Sub opendataexcel(ByVal dataSource As String)
        Try
            OLEstr = "Provider=Microsoft.Ace.OLEDB.12.0;" & _
               "Data Source=" & dataSource & ";Extended Properties= Excel 8.0"
            OLEconnection = New OleDb.OleDbConnection(OLEstr)
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
            getTabelDataExcel = New DataTable
            OLEadapter = New OleDb.OleDbDataAdapter(sql, OLEconnection)
            OLEadapter.Fill(getTabelDataExcel)
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
    Public Sub openCon()
        Try

            Dim list As New List(Of String)
            Using reader As System.IO.StreamReader = _
                New System.IO.StreamReader(dirsetfile, True)
                Dim strLine As String = reader.ReadLine

                Do While Not strLine Is Nothing
                    list.Add(strLine)
                    strLine = reader.ReadLine
                Loop
                reader.Close()
            End Using

            '-- 00 hostdb
            '-- 01 user
            '-- 02 pass
            '-- 03 database
            
            Dim sqlstr As String =
                " Server=" & list.Item(0) & "; " & _
                " user id=" & list.Item(1) & "; " & _
                " password=" & list.Item(2) & "; " & _
                " Database=" & list.Item(3) & ";"

            sqlcon = New SqlConnection(sqlstr)
            sqlcon.Open()


        Catch ex As Exception
            MsgBox("Buka Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            sqlcon.Close()
        End Try
    End Sub

    'tutup koneksi
    Public Sub closeCon()
        Try
            sqlcon.Close()
        Catch ex As Exception
            MsgBox("Tutup Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            sqlcon.Close()
        End Try
    End Sub

    'eksekusi command query ODBC
    Public Sub execCommand(ByVal sqlstr As String)
        Try
            Call openCon()
            sqlcommand.Connection = sqlcon
            sqlcommand.CommandTimeout = 600
            sqlcommand.CommandText = sqlstr
            sqlcommand.ExecuteNonQuery()
            Call closeCon()
        Catch ex As Exception
            MsgBox("Command Execution Failed [execCommand] !", MsgBoxStyle.Information, "Konfigurasi System")
            sqlcon.Close()
        End Try
    End Sub

    'ambil data ke table
    Public Function table(ByVal sqlstr As String) As DataTable
        Try
            Call openCon()
            table = New DataTable
            sqladapter = New SqlDataAdapter(sqlstr, sqlcon)
            sqladapter.SelectCommand.CommandTimeout = 600
            sqladapter.Fill(table)
            sqladapter.Dispose()
            sqladapter = Nothing
            Call closeCon()
        Catch ex As Exception
            MsgBox("Initialized data table failed [table] !", MsgBoxStyle.Information, "Konfigurasi System")
            Return Nothing
        End Try
    End Function

    'ambil data ke variabel
    Public Function readData(ByVal sqlstr As String)
        Try

            Call openCon()
            sqlcommand.Connection = sqlcon
            sqlcommand.CommandTimeout = 600
            sqlcommand.CommandType = CommandType.Text
            sqlcommand.CommandText = sqlstr
            readData = sqlcommand.ExecuteScalar
            sqlcommand.Dispose()
            Call closeCon()
            If IsDBNull(readData) Then : Return ""
            Else : Return readData : End If
        Catch ex As Exception
            MsgBox("Read failed [readData]!", MsgBoxStyle.Information, "Konfigurasi System")
            Return Nothing
        End Try
    End Function

    Public sOpenTrans As Integer = 0
    Public sProsesTrans As Integer = 0
    Public sCloseTrans As Integer = 0

    'open ODBC Transaction
    Public Sub openTrans()
        Try
            sCloseTrans = 0 : sOpenTrans = 0 : sProsesTrans = 0

            Dim list As New List(Of String)
            Using reader As System.IO.StreamReader = _
                New System.IO.StreamReader(dirsetfile, True)
                Dim strLine As String = reader.ReadLine

                Do While Not strLine Is Nothing
                    list.Add(strLine)
                    strLine = reader.ReadLine
                Loop
                reader.Close()
            End Using

            Dim sqlstr As String =
                " Server=" & list.Item(0) & "; " & _
                " user id=" & list.Item(1) & "; " & _
                " password=" & list.Item(2) & "; " & _
                " Database=" & list.Item(3) & ";"

            sqlcon = New SqlConnection(sqlstr)
            sqlcon.Open()

            sqltransaction = sqlcon.BeginTransaction()

            sqlcommand.Connection = sqlcon
            sqlcommand.Transaction = sqltransaction

            sOpenTrans = 1
            sProsesTrans = 1
        Catch ex As Exception
            MsgBox("Sistem gagal buka transaksi ke Database !" & vbNewLine & vbNewLine & _
                   "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                   "Gagal Simpan / Update")
            sqlcon.Close() : sOpenTrans = 0 : Exit Sub
        End Try
    End Sub

    'Close ODBC Transaction
    Public Sub closeTrans(ByVal tempObj As Object)
        If sProsesTrans = 1 Then
            Try
                sqltransaction.Commit()
                sqlcon.Close()

                sCloseTrans = 1 : sOpenTrans = 0 : sProsesTrans = 0
            Catch ex As Exception
                MsgBox("Sistem gagal tutup transaksi dari Database !" & vbNewLine & vbNewLine & _
                       "System Message : " & ex.Message, MsgBoxStyle.Critical, _
                       "Failed Save / Update")
                sCloseTrans = 0 : sOpenTrans = 0 : sProsesTrans = 0

                sqltransaction.Rollback() : sqlcon.Close()
                tempObj.Select() : Exit Sub
            End Try
        Else : tempObj.Select() : Exit Sub : End If
    End Sub

    'eksekusi command query ODBC Transaction
    Public Sub execCmdTrans(ByVal sqlstr As String)
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                sqlcommand.CommandText = sqlstr
                sqlcommand.ExecuteNonQuery()
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal eksekusi ke Database !" & vbNewLine & vbNewLine & _
                       "SQL : " & sqlstr & vbNewLine & vbNewLine & _
                       "System Message : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Simpan / Modifikasi")
                sqlcon.Close() : sProsesTrans = 0 : Exit Sub
            End Try
        Else : Exit Sub : End If
    End Sub

    'get data ODBC Transaction
    Public Function getDataTrans(ByVal sqlstr As String)
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                sqlcommand.CommandText = sqlstr
                getDataTrans = sqlcommand.ExecuteScalar
                If IsDBNull(getDataTrans) Then : Return ""
                Else : Return getDataTrans : End If
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal ambil data ke Database !" & vbNewLine & vbNewLine & _
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Ambil Data")
                sqltransaction.Connection.Close() : sqlcon.Close() : sProsesTrans = 0
                getDataTrans = "0" : Exit Function
            End Try
        Else : getDataTrans = "0" : Exit Function : End If
    End Function

    'get data table ODBC Transaction
    Public Function getTableTrans(ByVal sqlstr As String) As DataTable
        If sOpenTrans = 1 And sProsesTrans = 1 Then
            Try
                getTableTrans = New DataTable
                sqlcommand.CommandText = sqlstr
                Dim dataAdapter As New SqlDataAdapter(sqlcommand)
                dataAdapter.Fill(getTableTrans)
                dataAdapter.Dispose()
                dataAdapter = Nothing
                sProsesTrans = 1
            Catch ex As Exception
                MsgBox("Sistem gagal ambil table ke Database !" & vbNewLine & vbNewLine & _
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Ambil Data")
                sqltransaction.Connection.Close() : sqlcon.Close() : sProsesTrans = 0
                getTableTrans = Nothing : Exit Function
            End Try
        Else : getTableTrans = Nothing : Exit Function : End If
    End Function

    Public Function crypt(ByVal Text As String) As String
        'Encrypts/decrypts the passed string using
        Dim checkCrypt As Integer = 0
        Dim result As String = "", resultGenerator As String = "", resultGenerator2 As String = ""
        Dim Generator As System.Random = New System.Random()

        If Mid(Text, 1, 1) = "^" Then
            checkCrypt = 1 : End If

        resultGenerator = Generator.Next(1000, 9999)
        resultGenerator2 = Generator.Next(1000, 9999)

        If checkCrypt = 0 Then
            result = "^" & resultGenerator & StrReverse(Text) & resultGenerator2
        ElseIf checkCrypt = 1 Then : result = StrReverse(Mid(Text, 6, Len(Text) - 9)) : End If

        Return result

    End Function
    Public Sub getRowHeightSameDG(ByVal tempDG As DataGridView,
                                  Optional ByVal cRow As Integer = 0,
                                  Optional ByVal statDel As Integer = 0)
        Dim rRow As Integer = 0
        Dim countHeightRow As Integer = 62 + (cRow * 24)

        If statDel = 0 Then
            While countHeightRow < tempDG.Height
                rRow = tempDG.Rows.Add
                Dim row As DataGridViewRow = tempDG.Rows(0)
                countHeightRow += row.Height
            End While
        ElseIf statDel = 1 Then
            rRow = tempDG.Rows.Add
            Dim row As DataGridViewRow = tempDG.Rows(0)
        End If
    End Sub
    Public Sub getRowHeightSameDGforDT(ByVal tempDG As DataGridView, ByVal SQLSearch As String)
        Dim rRow As Integer = 0
        Dim countHeightRow As Integer
        Dim dtTemp As New DataTable
        Dim newRow As DataRow

        dtTemp = table(SQLSearch)
        countHeightRow = (dtTemp.Rows.Count * 24) + 48
        tempDG.DataSource = dtTemp

        tempDG.AllowUserToAddRows = True
        '-----------------------------------------------------'
        While countHeightRow < tempDG.Height

            newRow = dtTemp.NewRow
            dtTemp.Rows.Add(newRow)

            Dim row As DataGridViewRow = tempDG.Rows(0)
            countHeightRow += row.Height

        End While
        '-----------------------------------------------------'
        tempDG.AllowUserToAddRows = False
    End Sub

    Public Sub msgInform(ByVal msg As String, Optional ByVal title As String = "Information")
        MsgBox(msg, MsgBoxStyle.Information, title)
    End Sub
    Public Sub msgError(ByVal msg As String, Optional ByVal title As String = "Error")
        MsgBox(msg, MsgBoxStyle.Critical, title)
    End Sub
    Public Function msgYesNo(ByVal msg As String, Optional ByVal title As String = "Are you sure ?")
        msgYesNo = MsgBox(msg, MsgBoxStyle.YesNo, title)
    End Function

    '--BEA CUKAI--

    Sub opendataBC(ByVal dataSourceBC As String)
        Try
            OLEStr = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
               "Data Source=" & dataSourceBC & ";Persist Security Info=False;"
            OLEconnection = New OleDb.OleDbConnection(OLEStr)
            OLEconnection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show(ex.Message, "Error Connection to File Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OLEconnection.Close()
        End Try
    End Sub
    Public Function gettabeldataexcelBC(ByVal dataSourceBC As String, ByVal sql As String) As DataTable
        Try
            Call opendataBC(dataSourceBC)
            gettabeldataexcelBC = New DataTable
            OLEadapter = New OleDb.OleDbDataAdapter(sql, OLEconnection)
            OLEadapter.Fill(gettabeldataexcelBC)
            OLEadapter.Dispose()
            OLEadapter = Nothing
            Call closedDataOLEDB()
        Catch salah As Exception
            MessageBox.Show(salah.Message, "Cannot create table !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    '--END BEA CUKAI--
End Class
