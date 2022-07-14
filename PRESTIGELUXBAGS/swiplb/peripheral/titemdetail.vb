Imports System.IO
Public Class titemdetail

    Dim statusTempForm, varTempForm, varTempForm2 As String
    Dim tempForm As Form
    Dim tempObj As Object
    Dim itemtable As New DataTable
    Dim SQLSearch As String
    Dim statSQLSearch As Integer = 0
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32 = Convert.ToInt32(Keys.Escape) Then
            BtnCancel.PerformClick()
        ElseIf msg.WParam.ToInt32 = Convert.ToInt32(Keys.F1) Then
            Me.txtnote.Select()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Public Sub loadSQLSearch(ByVal sql As String, Optional ByVal statSearch As Integer = 0)
        SQLSearch = "SELECT * FROM (" & sql & ") TS"
        statSQLSearch = statSearch
    End Sub
    Public Sub loadStatusTempForm(ByVal tempAsalForm As Form, ByVal tempAsalObj As Object, ByVal temp As String)
        tempForm = tempAsalForm
        tempObj = tempAsalObj
        statusTempForm = temp
    End Sub

    Private Sub search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dgview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.txtnote.Select()
    End Sub
    Private Sub search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cekform(tempForm, "BACK", Me)
        tempObj.select()
    End Sub
    Dim r As Integer = 0, c As Integer = 0

    Private Sub submitsearch()



        'MsgBox(statusTempForm)
        'If statusTempForm = "[note]tpo" Then
        '    Dim a As tpo = CType(Application.OpenForms("tpo"), tpo)
        '    a.Enabled = True

        '    a.dgview.Item("note", a.dgview.CurrentRow.Index).Value = txtnote.Text

        'End If

        tempForm.Select() : tempObj.select()
        Me.Dispose()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        submitsearch()
    End Sub



    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        cekform(tempForm, "BACK", Me)
        tempObj.select()
    End Sub

End Class