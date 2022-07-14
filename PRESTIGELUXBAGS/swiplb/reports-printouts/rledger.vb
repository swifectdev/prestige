Imports CrystalDecisions.CrystalReports.Engine
Public Class rledger
    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        With cl
            If cmbreporttype.SelectedIndex = 0 Then
                Try
                    '------PRINT INVOICE
                    Dim rpt As New ReportDocument
                    Dim f As New print


                    rpt.Load(direcCetakan & "\rptpembelian.rpt")

                    rpt.SetDataSource(cl.table(
                     " SELECT * FROM vpenjualan " &
                     " WHERE tdate BETWEEN '" & Format(dttdatefrom.Value, "yyyyMMdd") & "' " &
                     " AND '" & Format(dttdateto.Value, "yyyyMMdd") & "'"))

                    rpt.SetParameterValue("dtfrom", Format(dttdatefrom.Value, "dd/MM/yyyy"))
                    rpt.SetParameterValue("dtto", Format(dttdateto.Value, "dd/MM/yyyy"))

                    f.crv.ReportSource = rpt
                    cekform(f, "NEW", Me)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            ElseIf cmbreporttype.selectedindex = 1 Then
                Try
                    '------PRINT INVOICE
                    Dim rpt As New ReportDocument
                    Dim f As New print


                    rpt.Load(direcCetakan & "\rptpembelianv2.rpt")

                    rpt.SetDataSource(cl.table(
                     " SELECT * FROM vpenjualan " &
                     " WHERE tdate BETWEEN '" & Format(dttdatefrom.Value, "yyyyMMdd") & "' " &
                     " AND '" & Format(dttdateto.Value, "yyyyMMdd") & "'"))

                    rpt.SetParameterValue("dtfrom", Format(dttdatefrom.Value, "dd/MM/yyyy"))
                    rpt.SetParameterValue("dtto", Format(dttdateto.Value, "dd/MM/yyyy"))

                    f.crv.ReportSource = rpt
                    cekform(f, "NEW", Me)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        End With
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub rledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbreporttype.SelectedIndex = 0
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New rledger
        cekform(frm, "NEW", Me)
    End Sub
End Class