Imports System.IO
Module modsistem
    Public cl As New classlibsysswiplb.mainClass
    Public idusr As Integer
    Public chdirectprintsales As String
    Public id_mcost As Integer = 0


    Public dirAppPath As String = System.Environment.CurrentDirectory
    Public dirImgFilePath As String = dirAppPath & "\img"
    Public direcCetakan As String = dirAppPath & "\printout\"
    Public database As String
    ' Public compid As String = 


    Public Sub cekform(ByVal tfrm As Form, ByVal st As String, ByVal frfrm As Form)
        If st = "NEW" Then
            tfrm.Show() : tfrm.MdiParent = menuutama

            'nama form yang mau di set full screen
            If tfrm.Name = "" Then
                tfrm.SetBounds(0,
                    0,
                    menuutama.Width - 10,
                    menuutama.Height - 80)
            ElseIf tfrm.Name = "login" Or tfrm.Name = "aboutus" Or tfrm.Name = "cgetserial" Or tfrm.Name = "dbconfig" Then
                tfrm.SetBounds((menuutama.Width - tfrm.Width) / 2,
                           (menuutama.Height - tfrm.Height) / 2 - 100,
                           tfrm.Width, tfrm.Height)
            Else
                Dim statnav As Integer = 0
                For Each child As Form In menuutama.MdiChildren
                    If child.Name = "navprogram" Then
                        statnav = 1
                    End If
                Next child
                If statnav = 1 Then
                    tfrm.SetBounds(navprogram.Width, 0, tfrm.Width, tfrm.Height)
                Else
                    tfrm.SetBounds(0, 0, tfrm.Width, tfrm.Height)
                End If
            End If

            tfrm.Select()
        ElseIf st = "BACK" Then
            frfrm.Dispose() : tfrm.Enabled = True : tfrm.BringToFront()
        ElseIf st = "SEARCH" Then
            frfrm.Enabled = False : tfrm.Show() : tfrm.MdiParent = menuutama
            tfrm.SetBounds((menuutama.Width - tfrm.Width) / 2,
                           (menuutama.Height - tfrm.Height) / 2,
                           tfrm.Width, tfrm.Height) : tfrm.Select()
            tfrm.Select()
        ElseIf st = "REFRESH" Then

            frfrm.Dispose()

            tfrm.Show() : tfrm.MdiParent = menuutama

            'nama form yang mau di set full screen
            If tfrm.Name = "" Then
                tfrm.SetBounds(0,
                    0,
                    menuutama.Width - 10,
                    menuutama.Height - 80)
            Else
                Dim statnav As Integer = 0
                For Each child As Form In menuutama.MdiChildren
                    If child.Name = "navprogram" Then
                        statnav = 1
                    End If
                Next child
                If statnav = 1 Then
                    tfrm.SetBounds(navprogram.Width, 0, tfrm.Width, tfrm.Height)
                Else
                    tfrm.SetBounds(0, 0, tfrm.Width, tfrm.Height)
                End If
            End If

            tfrm.Select()

        End If
    End Sub
    Public Sub encol(ByVal dg As DataGridView,
                      ByVal nm As String,
                      ByVal hdr As String,
                      Optional ByVal w As Integer = 0)
        With dg.Columns(nm)
            .Visible = True
            If w <> 0 Then : .Width = w : End If
            .HeaderText = hdr
        End With
    End Sub
    Public Function validatetxtnull(ByVal tobj As TextBox,
                               ByVal msg As String,
                               ByVal tmsg As String,
                               Optional ByVal tp As String = "CHR")
        Dim treturn As Integer = 0

        If tp = "CHR" Then
            If cl.cchr(tobj.Text) = "" Then : cl.msgError(msg, tmsg) : tobj.Select() : treturn = 1
            End If
        ElseIf tp = "NUM" Then
            If cl.cnum(tobj.Text) = 0 Then : cl.msgError(msg, tmsg) : tobj.Select() : treturn = 1
            End If
        End If

        Return treturn
    End Function
    Public Function validatedgnull(ByVal tDG As DataGridView,
                               ByVal colint As String,
                               ByVal msg As String,
                               ByVal tmsg As String,
                               Optional ByVal tp As String = "NUM")
        Dim treturn As Integer = 0

        If tDG.Rows.Count - 1 = 0 Then
            treturn = 1
        Else
            For i As Integer = 0 To tDG.Rows.Count - 2
                If tp = "CHR" Then
                    If cl.cchr(tDG.Rows(i).Cells(colint).Value) = "" Then
                        treturn = 1
                    Else
                        treturn = 0
                    End If
                Else
                    If cl.cnum(tDG.Rows(i).Cells(colint).Value) = 0 Then
                        treturn = 1
                    Else
                        treturn = 0
                    End If
                End If

            Next
        End If

        If treturn = 1 Then
            cl.msgError(msg, tmsg) : tDG.Select() : treturn = 1
        End If

        Return treturn
    End Function

    Public Sub copyDir(ByVal sourcePath As String, ByVal destPath As String,
                           ByVal filename As String, Optional ByVal withExt As Integer = 1)


        If Not Directory.Exists(destPath) Then
            Directory.CreateDirectory(destPath)
        End If
        Dim sourceExt As String = Path.GetExtension(sourcePath).ToLower

        'untuk mengkopi extension file
        Dim dest As String
        If withExt = 0 Then : dest = Path.Combine(destPath, Path.GetFileName(filename))
        Else : dest = Path.Combine(destPath, Path.GetFileName(filename & sourceExt))
        End If

        'direktori mainTemp
        Dim mainTemp As String = dirImgFilePath & "\main\temp" & sourceExt
        If File.Exists(mainTemp) Then : System.IO.File.Delete(mainTemp) : End If

        If File.Exists(dest) = False Then
            File.Copy(sourcePath, dest)
        Else

            File.Copy(sourcePath, mainTemp)
            File.Delete(dest)
            File.Copy(mainTemp, dest)
            File.Delete(mainTemp)
        End If

    End Sub

    Public Function ccur4(ByVal str, Optional ByVal def = 0)
        Try
            Dim tempNumericCur As String = "0.0000"

            If IsDBNull(str) Then : Return 0
            ElseIf CStr(str) = "" Then : Return 0
            Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
            End If
        Catch ex As Exception
            cl.msgError("Can't convert to currency !", "Error System") : Return 0
        End Try
    End Function

    Public Sub cultureSet()
        Dim cultureInfo As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
        Application.CurrentCulture = cultureInfo
        '    System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo.GetCultureInfo("en-US")
        cultureInfo.NumberFormat.NumberDecimalSeparator = "."
        cultureInfo.NumberFormat.NumberGroupSeparator = ","
        cultureInfo.DateTimeFormat.DateSeparator = "/"
        cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
    End Sub

    Public FlNm As String

    Public Sub ExportToExcel(ByVal DGV As DataGridView)
        Dim fs As New StreamWriter(FlNm, False)
        With fs
            Try
                .WriteLine("<?xml version=""1.0""?>")
                .WriteLine("<?mso-application progid=""Excel.Sheet""?>")
                .WriteLine("<ss:Workbook xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")
                .WriteLine("    <ss:Styles>")
                .WriteLine("        <ss:Style ss:ID=""1"">")
                .WriteLine("           <ss:Font ss:Bold=""1""/>")
                .WriteLine("           <ss:FontName=""Courier New""/>")
                .WriteLine("        </ss:Style>")
                .WriteLine("    </ss:Styles>")
                .WriteLine("    <ss:Worksheet ss:Name=""Sheet1"">")
                .WriteLine("        <ss:Table>")
                For x As Integer = 0 To DGV.Columns.Count - 1
                    .WriteLine("            <ss:Column ss:Width=""{0}""/>", DGV.Columns.Item(x).Width)
                Next
                .WriteLine("            <ss:Row ss:StyleID=""1"">")
                For i As Integer = 0 To DGV.Columns.Count - 1
                    .WriteLine("                <ss:Cell>")
                    .WriteLine(String.Format("                   <ss:Data ss:Type=""String"">{0}</ss:Data>", DGV.Columns.Item(i).HeaderText))
                    .WriteLine("</ss:Cell>")
                Next
                .WriteLine("            </ss:Row>")
                For intRow As Integer = 0 To DGV.RowCount - 1
                    .WriteLine(String.Format("            <ss:Row ss:Height =""{0}"">", DGV.Rows(intRow).Height))
                    For intCol As Integer = 0 To DGV.Columns.Count - 1
                        .WriteLine("                <ss:Cell>")
                        'MsgBox(String.Format("                   <ss:Data ss:Type=""String"">{0}</ss:Data>", DGV.Item(intCol, intRow).Value.ToString))
                        .WriteLine(String.Format("                   <ss:Data ss:Type=""String"">{0}</ss:Data>", DGV.Item(intCol, intRow).Value))
                        .WriteLine("                </ss:Cell>")
                    Next
                    .WriteLine("            </ss:Row>")
                Next
                .WriteLine("        </ss:Table>")
                .WriteLine("    </ss:Worksheet>")
                .WriteLine("</ss:Workbook>")
                .Close()
                .Dispose()
                fs = Nothing
            Catch ex As Exception
                .Close()
                .Dispose()
                fs = Nothing
                MessageBox.Show("Error While Exporting Data To Excel. Error : " & ex.Message)
            End Try
        End With
    End Sub

End Module
