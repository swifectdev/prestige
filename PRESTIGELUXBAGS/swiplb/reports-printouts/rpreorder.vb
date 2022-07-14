Imports CrystalDecisions.CrystalReports.Engine
Public Class rpreorder
    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        With cl
            Try
                '------PRINT INVOICE
                Dim rpt As New ReportDocument
                Dim f As New print
                ' MsgBox(direcCetakan & "\rptpreorder.rpt")

                rpt.Load(direcCetakan & "rptpreorder.rpt")

                rpt.SetDataSource(cl.table(
                 " SELECT * FROM vpreorder " &
                 " WHERE tdate BETWEEN '" & Format(dttdatefrom.Value, "yyyyMMdd") & "' " &
                 " AND '" & Format(dttdateto.Value, "yyyyMMdd") & "'"))

                rpt.SetParameterValue("dtfrom", Format(dttdatefrom.Value, "dd/MM/yyyy"))
                rpt.SetParameterValue("dtto", Format(dttdateto.Value, "dd/MM/yyyy"))

                f.crv.ReportSource = rpt
                cekform(f, "NEW", Me)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End With
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Me.Dispose()
        Dim frm As New rpreorder
        cekform(frm, "NEW", Me)
    End Sub
End Class