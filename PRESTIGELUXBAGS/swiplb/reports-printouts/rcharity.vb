Imports CrystalDecisions.CrystalReports.Engine
Public Class rcharity
    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        With cl
            Try
                '------PRINT INVOICE
                Dim rpt As New ReportDocument
                Dim f As New print


                rpt.Load(direcCetakan & "\rptcharity.rpt")

                rpt.SetDataSource(cl.table(
                 " SELECT * FROM vcharity " &
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
        Dim frm As New rcharity
        cekform(frm, "NEW", Me)
    End Sub
End Class