Imports System.Net

Module moduleOnline
    'variabel direktory SETTING RIS
    Public dirSettingDirecPath As String = "C:\SWIOnlineBC"
    Public dirSettingFilePath As String = "C:\SWI\SWIOnlineBC.swi"
    Public dirSettingFileOnline As String = "C:\SWIOnlineBC\SWIOnlineBC.swi"

    'sintaks ODBCD:\Dropbox\swifect_share\[SWISY-RT] Loyaltech Gensu Utama\sistem\swisy_rt\modSWISY-RT.vb
    Public ODBCConnection As New System.Data.Odbc.OdbcConnection
    Public ODBCcommand As New System.Data.Odbc.OdbcCommand
    Public ODBCtransaction As System.Data.Odbc.OdbcTransaction
    Public ODBCreader As System.Data.Odbc.OdbcDataReader
    Public ODBCadapter As New System.Data.Odbc.OdbcDataAdapter

    Public Function cChr(ByVal str, Optional ByVal def = "")
        If IsDBNull(str) Then : Return def
        ElseIf CStr(str) <> "" Then : Return CStr(str).Replace("'", "''")
        Else : Return CStr(str)
        End If
    End Function

    Public Function crypt(ByVal Text As String) As String
        'Encrypts/decrypts the passed string using
        Dim checkCrypt As Integer = 0
        Dim result As String = ""
        Dim Generator As System.Random = New System.Random()

        If Mid(Text, 1, 1) = "^" Then
            checkCrypt = 1 : End If

        If checkCrypt = 0 Then
            result = "^" & Generator.Next(1000, 9999) & StrReverse(Text) & Generator.Next(1000, 9999)
        ElseIf checkCrypt = 1 Then : result = StrReverse(Mid(Text, 6, Len(Text) - 9)) : End If

        Return result
    End Function

    'buka koneksi
    Sub openConOnline()
        Dim pwd As String = "YDVrr@V!N6_NcxK9h2"
        'Dim pwd As String = "Sw1Apps20!@#$%"
        Try
            'Dim list As New List(Of String)
            'Using reader As System.IO.StreamReader =
            '    New System.IO.StreamReader(dirSettingFileOnline, True)
            '    Dim str_line As String = reader.ReadLine

            '    Do While Not str_line Is Nothing
            '        list.Add(str_line)
            '        str_line = reader.ReadLine
            '    Loop
            '    reader.Close()
            'End Using

            '-- 00 hostdb
            '-- 01 port
            '-- 02 user
            '-- 03 pass
            '-- 04 database

            'Dim ODBCStr As String =
            '"Driver={MySQL ODBC 5.2 ANSI Driver}; " & _
            '" Server=182.253.236.4; " & _
            '" Port=3306;" & _
            '" User=u6306811; " & _
            '" Password=ivhan131287;" & _
            '" Database=u6306811_tokowish;" & _
            '" Option=3;"

            'Dim ODBCStr As String =
            '    "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
            '    " Server=" & list.Item(0) & "; " &
            '    " Port=" & list.Item(1) & ";" &
            '    " User=" & list.Item(2) & "; " &
            '    " Password=" & list.Item(3) & "; " &
            '    " Database=" & list.Item(4) & ";" &
            '    " Option=3;"

            Dim ODBCStr As String = ""
            ' -- UPDATE 06/03/2020
            If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BYC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_byc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "AJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_aji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "AST" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ast;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bei;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BHI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bhi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "CHJ" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_chj;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DAI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dai;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DBI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dbi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DLI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dli;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DSI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dsi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EEW" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eew;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPS" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eps;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPS2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eps2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPT" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ept;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "GTC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_gtc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "HGA" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_hga;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "HGA2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_hga2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "INO" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ino;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "IRE" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ire;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KFI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kfi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KND" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_knd;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KRY" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kry;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KSR" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ksr;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KYI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kyi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "MGI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_mgi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "MMI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_mmi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "NEO" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_neo;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "OCI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_oci;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "OEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_oei;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PLI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pli;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ppi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PYI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pyi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "RBC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_rbc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "SCE2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_sce2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "SMD" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_smd;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "TBI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_tbi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "TEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_tei;" &
             " Option=3;"
            Else
                ODBCStr =
               "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
               " Server=swiapps.com; " &
               " Port=3306;" &
               " User=swiappsc; " &
               " Password=" & pwd & "; " &
               " Database=swiappsc_bc;" &
               " Option=3;"
            End If

            ODBCConnection = New System.Data.Odbc.OdbcConnection(ODBCStr)
            ODBCConnection.Open()

        Catch ex As Exception
            MsgBox("Buka Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            ODBCConnection.Close()
        End Try
    End Sub

    'tutup koneksi
    Sub closeConOnline()
        Try
            ODBCConnection.Close()
        Catch ex As Exception
            MsgBox("Tutup Koneksi Database tidak bisa !", MsgBoxStyle.Information, "Konfigurasi System")
            ODBCConnection.Close()
            End
        End Try
    End Sub

    Public sOpenTransOnline As Integer = 0
    Public sProsesTransOnline As Integer = 0
    Public sCloseTransOnline As Integer = 0

    'open ODBC Transaction
    Sub openTransOnline()
        Dim pwd As String = "YDVrr@V!N6_NcxK9h2"
        '   Dim pwd As String = "Sw1Apps20!@#$%"
        Try
            sCloseTransOnline = 0 : sOpenTransOnline = 0 : sProsesTransOnline = 0

            'Dim list As New List(Of String)
            'Using reader As System.IO.StreamReader =
            '    New System.IO.StreamReader(dirSettingFileOnline, True)
            '    Dim str_line As String = reader.ReadLine

            '    Do While Not str_line Is Nothing
            '        list.Add(str_line)
            '        str_line = reader.ReadLine
            '    Loop
            '    reader.Close()
            'End Using

            'Dim ODBCStr As String =
            '"Driver={MySQL ODBC 5.2 ANSI Driver}; " & _
            '" Server=182.253.236.4; " & _
            '" Port=3306;" & _
            '" User=u6306811; " & _
            '" Password=ivhan131287;" & _
            '" Database=u6306811_tokowish;" & _
            '" Option=3;"

            'Dim ODBCStr As String =
            '    "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
            '    " Server=" & list.Item(0) & "; " &
            '    " Port=" & list.Item(1) & ";" &
            '    " User=" & list.Item(2) & "; " &
            '    " Password=" & list.Item(3) & "; " &
            '    " Database=" & list.Item(4) & ";" &
            '    " Option=3;"

            ' -- UPDATE 06/03/2020
            Dim ODBCStr As String = ""
            ' -- UPDATE 06/03/2020
            If cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BYC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_byc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "AJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_aji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "AST" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ast;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bei;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BHI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bhi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "BJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_bji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "CHJ" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_chj;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DAI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dai;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DBI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dbi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DLI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dli;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "DSI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_dsi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EEW" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eew;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPS" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eps;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPS2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_eps2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "EPT" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ept;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "GTC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_gtc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "HGA" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_hga;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "HGA2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_hga2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "INO" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ino;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "IRE" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ire;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KFI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kfi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KND" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_knd;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KRY" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kry;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KSR" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ksr;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "KYI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_kyi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "MGI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_mgi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "MMI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_mmi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "NEO" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_neo;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "OCI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_oci;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "OEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_oei;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PJI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pji;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PLI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pli;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PPI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_ppi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "PYI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_pyi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "RBC" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_rbc;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "SCE2" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_sce2;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "SMD" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_smd;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "TBI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_tbi;" &
             " Option=3;"
            ElseIf cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'") = "TEI" Then
                ODBCStr =
             "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
             " Server=swiapps.com; " &
             " Port=3306;" &
             " User=swiappsc; " &
             " Password=" & pwd & "; " &
             " Database=swiappsc_tei;" &
             " Option=3;"
            Else
                ODBCStr =
               "Driver={MySQL ODBC 5.2 ANSI Driver}; " &
               " Server=swiapps.com; " &
               " Port=3306;" &
               " User=swiappsc; " &
               " Password=" & pwd & "; " &
               " Database=swiappsc_bc;" &
               " Option=3;"
            End If

            ODBCConnection = New System.Data.Odbc.OdbcConnection(ODBCStr)
            ODBCConnection.Open()

            ODBCtransaction = ODBCConnection.BeginTransaction()

            ODBCcommand.Connection = ODBCConnection
            ODBCcommand.Transaction = ODBCtransaction

            sOpenTransOnline = 1
            sProsesTransOnline = 1
        Catch ex As Exception
            MsgBox("SWI ONLINE BC Gagal Open ke Database !" & vbNewLine & vbNewLine &
                   "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical,
                   "Gagal Simpan / Update")
            ODBCConnection.Close() : sOpenTransOnline = 0 : Exit Sub
        End Try
    End Sub

    'Close ODBC Transaction
    Sub closeTransOnline(ByVal tempObj As Object)
        If sProsesTransOnline = 1 Then
            Try
                ODBCtransaction.Commit()
                ODBCConnection.Close()

                sCloseTransOnline = 1 : sOpenTransOnline = 0 : sProsesTransOnline = 0
            Catch ex As Exception
                MsgBox("SWI ONLINE BC failed close from Database !" & vbNewLine & vbNewLine & _
                       "System Message : " & ex.Message, MsgBoxStyle.Critical, _
                       "Failed Save / Update")
                sCloseTransOnline = 0 : sOpenTransOnline = 0 : sProsesTransOnline = 0

                ODBCtransaction.Rollback() : ODBCConnection.Close()
                tempObj.Select() : Exit Sub
            End Try
        Else : tempObj.Select() : Exit Sub : End If
    End Sub

    'eksekusi command query ODBC Transaction
    Sub execCmdTransOnline(ByVal sql As String)
        If sOpenTransOnline = 1 And sProsesTransOnline = 1 Then
            Try

                ODBCcommand.CommandText = sql
                ODBCcommand.ExecuteNonQuery()
                sProsesTransOnline = 1
            Catch ex As Exception
                MsgBox("SWI ONLINE BC failed execution to Database !" & vbNewLine & vbNewLine & _
                       "System Message : " & ex.Message, MsgBoxStyle.Critical, _
                       "Failed Save / Update")
                ODBCConnection.Close() : sProsesTransOnline = 0 : Exit Sub
            End Try
        Else : Exit Sub : End If
    End Sub

    'eksekusi command query ODBC Transaction2
    Sub execCmdTransOnline2(ByVal sql As String)
        If sOpenTransOnline = 1 And sProsesTransOnline = 1 Then
            Try
                ODBCcommand.CommandText = sql
                ODBCcommand.ExecuteNonQuery()
                sProsesTransOnline = 1
            Catch ex As Exception
                MsgBox("SWI ONLINE BC Gagal Eksekusi ke Database !" & vbNewLine & vbNewLine & _
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Simpan / Update")
                ODBCtransaction.Dispose() : ODBCConnection.Close() : sProsesTransOnline = 0 : Exit Sub
            End Try
        Else : Exit Sub : End If
    End Sub

    'get data ODBC Transaction
    Public Function getDataTransOnline(ByVal query As String)
        If sOpenTransOnline = 1 And sProsesTransOnline = 1 Then
            Try
                ODBCcommand.CommandText = query
                getDataTransOnline = ODBCcommand.ExecuteScalar
                If IsDBNull(getDataTransOnline) Then : Return ""
                Else : Return getDataTransOnline : End If
                sProsesTransOnline = 1
            Catch ex As Exception
                MsgBox("SWI ONLINE BC Gagal Ambil Data ke Database !" & vbNewLine & vbNewLine & _
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Simpan / Update")
                ODBCtransaction.Dispose() : ODBCConnection.Close() : sProsesTransOnline = 0
                getDataTransOnline = "0" : Exit Function
            End Try
        Else : getDataTransOnline = "0" : Exit Function : End If
    End Function
    'get data ODBC Transaction2
    Public Function getDataTransOnline2(ByVal query As String)
        If sOpenTransOnline = 1 And sProsesTransOnline = 1 Then
            Try
                ODBCcommand.CommandText = query
                getDataTransOnline2 = ODBCcommand.ExecuteScalar
                If IsDBNull(getDataTransOnline2) Then : Return ""
                Else : Return getDataTransOnline2 : End If
                sProsesTransOnline = 1
            Catch ex As Exception
                MsgBox("SWI ONLINE BC Gagal Ambil Data ke Database !" & vbNewLine & vbNewLine & _
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical, _
                       "Gagal Simpan / Update")
                ODBCtransaction.Dispose() : ODBCConnection.Close() : sProsesTransOnline = 0
                getDataTransOnline2 = "0" : Exit Function
            End Try
        Else : getDataTransOnline2 = "0" : Exit Function : End If
    End Function
    'get data table ODBC Transaction
    Public Function getTableTransOnline(ByVal query As String) As DataTable
        If sOpenTransOnline = 1 And sProsesTransOnline = 1 Then
            Try
                getTableTransOnline = New DataTable
                ODBCcommand.CommandText = query
                Dim dataAdapter As New System.Data.Odbc.OdbcDataAdapter(ODBCcommand)
                dataAdapter.Fill(getTableTransOnline)
                dataAdapter.Dispose()
                dataAdapter = Nothing
                sProsesTransOnline = 1
            Catch ex As Exception
                MsgBox("SWI ONLINE BC Gagal Ambil Table ke Database !" & vbNewLine & vbNewLine &
                       "Pesan Sistem : " & ex.Message, MsgBoxStyle.Critical,
                       "Gagal Simpan / Update")
                ODBCtransaction.Dispose() : ODBCConnection.Close() : sProsesTransOnline = 0
                getTableTransOnline = Nothing : Exit Function
            End Try
        Else : getTableTransOnline = Nothing : Exit Function : End If
    End Function

    Public Function CheckForInternetConnection() As Boolean

        Try
            If cl.readData("SELECT strvl FROM csetting where name = 'companyid'") = "OEI" Then
                Return My.Computer.Network.Ping("www.oei.swiapps.com")
            ElseIf cl.readData("SELECT strvl FROM csetting where name = 'companyid'") = "BEI" Then
                Return My.Computer.Network.Ping("www.bumjin.swiapps.com")
            ElseIf cl.readData("SELECT strvl FROM csetting where name = 'companyid'") = "CHJ" Then
                Return My.Computer.Network.Ping("www.cipta.swiapps.com")
            ElseIf cl.readData("SELECT strvl FROM csetting where name = 'companyid'") = "KRY" Then
                Return My.Computer.Network.Ping("www.korryo.swiapps.com")
            Else
                Return My.Computer.Network.Ping("www.swiapps.com")
            End If

        Catch
            Return False
        End Try
    End Function
End Module
