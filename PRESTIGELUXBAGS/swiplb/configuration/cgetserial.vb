Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices

Public Class cgetserial

    Dim idmaster As Integer = 0, statform As String = ""

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
       ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            btncancel.PerformClick()
            '-----------------------------------------------------------------------
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click

        Me.Dispose()
        menuutama.Dispose()

    End Sub

    Private Sub cgetserial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Select()
        txtserial.Select()

        Try
            Dim nic As NetworkInterface = Nothing
            Dim macAddress, macAddressLocal As String
            macAddressLocal = ""
            Dim Generator As System.Random = New System.Random()
            For Each nic In NetworkInterface.GetAllNetworkInterfaces
                Select Case nic.NetworkInterfaceType
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not nic.GetPhysicalAddress.ToString = String.Empty And Not nic.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            macAddress = nic.GetPhysicalAddress.ToString
                            macAddressLocal = macAddress
                            'If nic.Name.ToString.ToUpper Like "LOCAL AREA CONNECTION*" And macAddress <> "" Then
                            '    macAddressLocal = macAddress
                            'End If
                        End If
                End Select
            Next nic
            txtserial.Text = macAddressLocal
            txtserial.Text = Generator.Next(1000, 9999) &
                                StrReverse(
                                    Mid(macAddressLocal, 1, 1) &
                                    Mid(macAddressLocal, 2, 2) &
                                    Mid(macAddressLocal, 3, 3) &
                                    Generator.Next(1000, 9999) &
                                    Mid(macAddressLocal, 4, 4) &
                                    Mid(macAddressLocal, 5, 5) &
                                    Mid(macAddressLocal, 10, 3) &
                                    Generator.Next(1000, 9999)
                                )
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cgetserial_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Select()
        txtserial.Select()
    End Sub

    Private Sub txtserial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserial.TextChanged
        Me.Select()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Dim nic As NetworkInterface = Nothing
            Dim macAddress, macAddressLocal As String
            macAddressLocal = ""
            Dim Generator As System.Random = New System.Random()
            For Each nic In NetworkInterface.GetAllNetworkInterfaces
                Select Case nic.NetworkInterfaceType
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not nic.GetPhysicalAddress.ToString = String.Empty And Not nic.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            macAddress = nic.GetPhysicalAddress.ToString
                            macAddressLocal = macAddress
                            'If nic.Name.ToString.ToUpper Like "LOCAL AREA CONNECTION*" And macAddress <> "" Then
                            '    macAddressLocal = macAddress
                            'End If
                        End If
                End Select
            Next nic

            Dim tVal As String = "", tVal2 As String = ""
            tVal = StrReverse(Mid(txtserialapplication.Text, 4, Len(txtserialapplication.Text) - 3))

            tVal = Mid(tVal, 4, Len(tVal) - 3)
            tVal2 = Mid(tVal, 1, Len(tVal) - 23)
            tVal = Mid(tVal, Len(tVal) - 22, 23)

            If Len(tVal) <> 23 Then
                MsgBox("Serial Aplikasi dari SWIFECT salah, silahkan hubungi : info@swifect.com !", MsgBoxStyle.Critical, "Failed Authentication")
                txtserialapplication.Select()
                Exit Sub
            End If

            Dim a1 As String = Mid(tVal, 8, 1) & Mid(tVal, 10, 1)
            Dim a2 As String = Mid(tVal, 2, 2)
            Dim a3 As String = Mid(tVal, 5, 2)
            Dim a4 As String = Mid(tVal, 13, 2)
            Dim a5 As String = Mid(tVal, 15, 1) & Mid(tVal, 22, 1)
            Dim a6 As String = Mid(tVal, Len(tVal), 1) & Mid(tVal, Len(tVal) - 4, 1)

            
            Dim macAddressValSwi As String = a1 & _
                                    a2 & _
                                    a3 & _
                                    a4 & _
                                    a5 & _
                                    a6

            'strDate adalah hasil STR tval2 yang diambil str user dan komp nya dan belum diolah
            Dim strUC = Mid(tVal2, 2, (Mid(tVal2, 1, 1)))
            Dim jmlU As Integer = Mid(strUC, 1, 1)
            Dim jmlC As Integer = Mid(strUC, Mid(strUC, 1, 1) + 2, 1)

            'strDate adalah hasil STR tval2 yang diambil str waktunya dan belum diolah
            Dim strDate = Mid(tVal2, CInt(Mid(tVal2, 1, 1)) + 4, 8)

            'cl.msgInform("Mac Address : " & a1 & "-" & a2 & "-" & a3 & "-" & a4 & "-" & a5 & "-" & a6)
            cl.msgInform("Serial key valid ! " & vbNewLine &
                         "Users available : " & Mid(strUC, 2, jmlU) & vbNewLine & vbNewLine &
                         "Devices available : " & Mid(strUC, Mid(strUC, 1, 1) + 3, jmlC) & vbNewLine & vbNewLine &
                         "License Expires on : " & Mid(strDate, 7, 2) & "/" & Mid(strDate, 1, 2) & "/" & Mid(strDate, 3, 4))

            'formatnya harus berupa ddMMyy

            If macAddressLocal <> macAddressValSwi Then
                cl.msgError("Serial Aplikasi dari SWIFECT salah, hubungi : info@swifect.com !")
                txtserialapplication.Select()
            Else
                'hapus file setting.ini
                System.IO.File.Delete(cl.dirserfile)

                'buat file setting.ini dan tulis txt_isi.text
                Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(cl.dirserfile, True)
                    writer.WriteLine(cl.simplecrypt(txtserialapplication.Text))
                End Using

                ' MsgBox("Serial Key from SWIFECT is correct !", MsgBoxStyle.Information, "Success Authentication")

                'Try
                '    Dim myProcess As New Process()
                '    myProcess.StartInfo.FileName = "cmd.exe"
                '    myProcess.StartInfo.UseShellExecute = False

                '    myProcess.StartInfo.RedirectStandardInput = True
                '    myProcess.StartInfo.RedirectStandardOutput = True
                '    myProcess.Start()

                '    Dim myStreamWriter As System.IO.StreamWriter = myProcess.StandardInput
                '    Dim mystreamreader As System.IO.StreamReader = myProcess.StandardOutput

                '    myStreamWriter.WriteLine"sqlcmd -S .\SQLEXPRESS -i """ & cl.dirapp & "\setup\db\createdb.sql""")
                '    myStreamWriter.WriteLine"sqlcmd -S .\SQLEXPRESS -i """ & cl.dirapp & "\setup\db\[allawyer]db.sql""")
                '    myStreamWriter.WriteLine"sqlcmd -S .\SQLEXPRESS -i """ & cl.dirapp & "\setup\db\[allawyer]sp.sql""")
                '    myStreamWriter.WriteLine"sqlcmd -S .\SQLEXPRESS -i """ & cl.dirapp & "\setup\db\[allawyer]fn.sql""")
                '    myStreamWriter.WriteLine"sqlcmd -S .\SQLEXPRESS -i """ & cl.dirapp & "\setup\db\[allawyer]vw.sql""")

                '    myStreamWriter.Close()

                '    myProcess.WaitForExit()
                '    myProcess.Close()

                'Catch ex As Exception
                '    MsgBox("Tidak bisa melakukan konfigurasi database", MsgBoxStyle.Exclamation, "Konfigurasi DB Gagal")
                'End Try

                Me.Dispose()

                cekform(login, "NEW", Me)

            End If

            'TaskBarAndStartShowHide(SW_SHOW)
            'menuutama.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            'menuutama.MaximizeBox = True
            'menuutama.MinimizeBox = True

        Catch ex As Exception
            MsgBox("Serialnya salah !", MsgBoxStyle.Exclamation, "Gagal Cek Serial")
        End Try
    End Sub
End Class