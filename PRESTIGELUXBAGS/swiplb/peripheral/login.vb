Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net.NetworkInformation
Public Class login
    Dim expireddate As Date
    Private compid As String = cl.readData("SELECT strvl FROM csetting WHERE name = 'companyid'")

    Public Sub getexpireddate(ByVal tempexpireddate As Date)
        expireddate = tempexpireddate
    End Sub
    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        'Dim list As New List(Of String)
        'Using reader As System.IO.StreamReader =
        '    New System.IO.StreamReader(cl.dirserfile, True)
        '    Dim strLine As String = reader.ReadLine

        '    Do While Not strLine Is Nothing
        '        list.Add(strLine)
        '        strLine = reader.ReadLine
        '    Loop
        '    reader.Close()
        'End Using

        'Dim serialapplication As String = cl.simplecrypt(list.Item(0))

        'Dim nic As NetworkInterface = Nothing
        'Dim macAddress, macAddressLocal As String
        'macAddressLocal = ""
        'Dim Generator As System.Random = New System.Random()
        'For Each nic In NetworkInterface.GetAllNetworkInterfaces
        'Select Case nic.NetworkInterfaceType
        '    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
        '    Case Else
        '        If Not nic.GetPhysicalAddress.ToString = String.Empty And Not nic.GetPhysicalAddress.ToString = "00000000000000E0" Then
        '            macAddress = nic.GetPhysicalAddress.ToString
        '            macAddressLocal = macAddress
        '            'If nic.Name.ToString.ToUpper Like "LOCAL AREA CONNECTION*" And macAddress <> "" Then
        '            '    macAddressLocal = macAddress
        '            'End If
        '        End If
        'End Select
        'Next nic

        'Dim tVal As String = "", tVal2 As String = ""
        'tVal = StrReverse(Mid(serialapplication, 4, Len(serialapplication) - 3))

        'tVal = Mid(tVal, 4, Len(tVal) - 3)
        'tVal2 = Mid(tVal, 1, Len(tVal) - 23)
        'tVal = Mid(tVal, Len(tVal) - 22, 23)

        'Dim a1 As String = Mid(tVal, 8, 1) & Mid(tVal, 10, 1)
        'Dim a2 As String = Mid(tVal, 2, 2)
        'Dim a3 As String = Mid(tVal, 5, 2)
        'Dim a4 As String = Mid(tVal, 13, 2)
        'Dim a5 As String = Mid(tVal, 15, 1) & Mid(tVal, 22, 1)
        'Dim a6 As String = Mid(tVal, Len(tVal), 1) & Mid(tVal, Len(tVal) - 4, 1)

        'Dim macAddressValSwi As String = a1 &
        '                       a2 &
        '                       a3 &
        '                       a4 &
        '                       a5 &
        '                       a6

        'If Len(tVal) <> 23 Then
        '    MsgBox("Serial Key Invalid, contact : info@swifect.com !", MsgBoxStyle.Critical, "Failed Authentication")
        '    cekform(cgetserial, "NEW", Me)
        '    Me.Dispose()
        '    Exit Sub
        'End If

        'If macAddressLocal <> macAddressValSwi Then
        '    cl.msgError("Serial Key invalid, contact : info@swifect.com !")
        '    cekform(cgetserial, "NEW", Me)
        '    Me.Dispose()
        '    Exit Sub
        'End If

        'Dim strDate = Mid(tVal2, CInt(Mid(tVal2, 1, 1)) + 4, 8)
        'Dim waktuexpired As String = Mid(strDate, 7, 2) & Mid(strDate, 1, 2) & Mid(strDate, 3, 4)

        'Dim expireddate As Date = Date.ParseExact(waktuexpired, "ddMMyyyy", Nothing)
        'getexpireddate(expireddate)

        'If Format(expireddate, "yyyyMMdd") = Format(Now, "yyyyMMdd") Then
        '    cl.msgInform("License expired hari ini !", "Information")
        'ElseIf Format(expireddate, "yyyyMMdd") < Format(Now, "yyyyMMdd") Then
        '    cl.msgError("License telah expired ! Hubungi team Swifect !", "Information")
        '    cekform(cgetserial, "NEW", Me)
        '    Me.Dispose()
        '    Exit Sub
        'End If


        '-------------SETTING CONFIG DATABASE CHANGED
        Dim listsettemp As New List(Of String)
        Using reader As System.IO.StreamReader = New System.IO.StreamReader(cl.dirsetfile, True)
            Dim strLine As String = reader.ReadLine
            Do While Not strLine Is Nothing
                listsettemp.Add(strLine)
                strLine = reader.ReadLine
            Loop
            reader.Close()
        End Using

        If System.IO.File.Exists(cl.dirsetfile) = True Then
            System.IO.File.Delete(cl.dirsetfile)
        ElseIf System.IO.File.Exists(cl.dirsetfile) = False Then
            System.IO.Directory.CreateDirectory("C:\SWISYPLB")
        End If

        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(cl.dirsetfile, True)
            writer.WriteLine(listsettemp.Item(0))
            writer.WriteLine(listsettemp.Item(1))
            writer.WriteLine(listsettemp.Item(2))
            writer.WriteLine(cmbdatabase.Text)
        End Using
        '-------------END SETTING DATABASE CHANGED


        Dim pass As String = cl.readData(
           " SELECT pass FROM cusr " &
           " WHERE username = '" & txtusr.Text & "' AND tstatus = 1")

        Dim listSet As New List(Of String)
        Using reader As System.IO.StreamReader = New System.IO.StreamReader(cl.dirsetfile, True)
            Dim strLine As String = reader.ReadLine
            Do While Not strLine Is Nothing
                listSet.Add(strLine)
                strLine = reader.ReadLine
            Loop
            reader.Close()
        End Using

        Dim userDB As String = listSet.Item(1)
        Dim passDB As String = listSet.Item(2)

        If cl.verifymd5hash(txtpass.Text, pass) = True Then

            'Me.Height = 250
            'ProgressBarLogin.Value = 0

            'tmrLogin.Interval = 500 '(1/2 second)
            'tmrLogin.Enabled = True

            ''--LOCK USERS WHO WONT PAY--'
            'Dim checkdate As String = Format(Now(), "yyyyMMdd")
            'If checkdate > "20200405" And compid = "CHJ" Then
            '    cl.msgError("Erroneous data received from server. Application may not work correctly !", "Informasi")
            '    Me.Dispose()
            '    menuutama.Dispose()
            '    Exit Sub
            'End If


            Dim vServer As String = listSet.Item(0)
            Dim vDatabase As String = listSet.Item(3)

            idusr = cl.readData(
            " SELECT id FROM cusr " &
            " WHERE username = '" & txtusr.Text & "'  AND tstatus = 1")

            Dim namausr As String = cl.readData(
            " SELECT name FROM cusr " &
            " WHERE username = '" & txtusr.Text & "'  AND tstatus = 1")

            database = vDatabase

            cl.openTrans()
            cl.execCmdTrans(
                " EXEC shuserlog " &
                " '" & idusr & "'" &
                " , 'LOGIN'" &
                " , ''" &
                " , '" & idusr & "'" &
                " ")
            cl.closeTrans(btnlogin)

            Me.Dispose()

            menuutama.tsStatus.Text =
                "Data Login : " & namausr & ", Server : " & vServer & ", Database : " & vDatabase & ", Licensed To : " &
                cl.readData("SELECT strvl FROM csetting WHERE name = 'company'") &
                "-- Copyright PT. Swifect Solusi Indonesia 2021"
            menuutama.muvisfalse()
            menuutama.muvistrue(idusr)

            If cl.readData("SELECT showmenu FROM CUSR WHERE id = '" & idusr & "'") = "N" Then
                Exit Sub
            End If


            Dim frm As New navprogram
                frm.MdiParent = menuutama
                frm.Show()

                '   menuutama.Panel1.Visible = True

                frm.SetBounds(0, 0, frm.Width, menuutama.Height - 80)


            Else
                cl.msgError("Password or Username is wrong, please contact admin !", "Warning Information")
            Exit Sub
        End If

    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        menuutama.muvisfalse()
        menuutama.tsStatus.Text = ""

        Dim listSet As New List(Of String)
        Using reader As System.IO.StreamReader = New System.IO.StreamReader(cl.dirsetfile, True)
            Dim strLine As String = reader.ReadLine
            Do While Not strLine Is Nothing
                listSet.Add(strLine)
                strLine = reader.ReadLine
            Loop
            reader.Close()
        End Using

        '--------------------LOAD DATABASE
        Dim connectString As String =
             "Server =" & listSet.Item(0) & ";" &
             "user id=" & listSet.Item(1) & ";" &
             "password =" & listSet.Item(2) & ";" &
             ""
        Dim builder As New System.Data.SqlClient.SqlConnectionStringBuilder(connectString)

        Dim dt_database, dt_restrictions As DataTable
        Dim restrictions(3) As String

        Using connection As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
            connection.Open()
            dt_database = connection.GetSchema("Databases")
            connection.Close()
        End Using

        Dim hold_array_table_name As New ArrayList
        For i As Integer = 0 To dt_database.Rows.Count - 1
            builder("Database") = dt_database.Rows(i).Item("database_name")
            Using connection As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
                connection.Open()
                restrictions(1) = "dbo"
                dt_restrictions = connection.GetSchema("Tables", restrictions)
                For y As Integer = 0 To dt_restrictions.Rows.Count - 1
                    If dt_restrictions.Rows(y).Item("table_name") = "swisyplb" Then
                        hold_array_table_name.Add(dt_restrictions.Rows(y).Item("table_catalog"))

                    End If
                Next
                connection.Close()
            End Using
        Next

        cmbdatabase.Items.Clear()
        For a As Integer = 0 To hold_array_table_name.Count - 1
            cmbdatabase.Items.Add(hold_array_table_name.Item(a))
        Next
        '--------------------END LOAD DATABASE

        cmbdatabase.Text = listSet.Item(3).Replace(" ", "")
        '   lblcompany.Text = cl.readData("SELECT strvl FROM csetting WHERE name = 'company'")


        'load logo here
        'If System.IO.File.Exists(dirImgFilePath & "\" & cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'logolocation'"))) = True Then
        '    Dim fs As System.IO.FileStream
        '    fs = New System.IO.FileStream(dirImgFilePath & "\" & cl.cchr(cl.readData("SELECT strvl FROM csetting WHERE name = 'logolocation'")),
        '         IO.FileMode.Open, IO.FileAccess.Read)
        '    PictureBox1.Image = System.Drawing.Image.FromStream(fs)
        '    fs.Dispose()
        '    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        'Else : PictureBox1.Image = Nothing
        'End If

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        'Me.Dispose()
        'menuutama.MenuStrip.Visible = True

        'menuutama.filetsmi.Visible = True
        'menuutama.loginmi.Visible = True
        'menuutama.logoutmi.Visible = False

        'menuutama.helptsmi.Visible = True
        'menuutama.aboutusmi.Visible = True

        Dim tny As Integer = cl.msgYesNo("Keluar dari aplikasi SWI-BC ?", "Confirmation")
        If tny = vbYes Then
            Me.Dispose()
            menuutama.Dispose()
        End If

    End Sub

    Private Sub tmrLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLogin.Tick

        If ProgressBarLogin.Value = 100 Then

            tmrLogin.Enabled = False

            Dim listSet As New List(Of String)
            Using reader As System.IO.StreamReader = New System.IO.StreamReader(cl.dirsetfile, True)
                Dim strLine As String = reader.ReadLine
                Do While Not strLine Is Nothing
                    listSet.Add(strLine)
                    strLine = reader.ReadLine
                Loop
                reader.Close()
            End Using

            Dim vServer As String = listSet.Item(0)
            Dim vDatabase As String = listSet.Item(3)
            database = listSet.Item(3)

            idusr = cl.readData(
            " SELECT id FROM cusr " &
            " WHERE username = '" & txtusr.Text & "'  AND tstatus = 1")

            Dim namausr As String = cl.readData(
            " SELECT name FROM cusr " &
            " WHERE username = '" & txtusr.Text & "'  AND tstatus = 1")

            cl.openTrans()
            cl.execCmdTrans(
                " EXEC shuserlog " &
                " '" & idusr & "'" &
                " , 'LOGIN'" &
                " , ''" &
                " , '" & idusr & "'" &
                " ")
            cl.closeTrans(btnlogin)

            ''test crystal report
            'Dim rpt As New ReportDocument : rpt = New test
            'rpt.SetParameterValue("test", "test")
            'Dim f As New print : f.crv.ReportSource = rpt : f.Dispose()

            Me.Dispose()



            menuutama.tsStatus.Text =
                "Data Login : " & namausr & ", Server : " & vServer & ", Database : " & vDatabase
            menuutama.muvisfalse()
            menuutama.muvistrue(idusr)
        Else : ProgressBarLogin.Value = ProgressBarLogin.Value + 25 : End If

    End Sub
End Class