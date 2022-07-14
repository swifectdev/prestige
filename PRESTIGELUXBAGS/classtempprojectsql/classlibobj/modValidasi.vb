
Module modValidasi

    Public Function cNum(ByVal str, Optional ByVal def = 0)
        If IsDBNull(str) Then : Return 0
        ElseIf CStr(str) = "" Then : Return 0
        Else : Return CDec(str)
        End If
    End Function
    Public Function cDisNum(ByVal str, Optional ByVal def = 0)
        If IsDBNull(str) Then : Return 0
        ElseIf CStr(str) = "" Then : Return 0
        Else : Return Format(Val(CDec(str)), "###,##0")
        End If

    End Function
    Public Function cCur(ByVal str, Optional ByVal def = 0)
        Dim decNumericCur As Integer = 2
        Dim tempNumericCur As String = ""

        If decNumericCur = 0 Then : tempNumericCur = "0"
        ElseIf decNumericCur = 1 Then : tempNumericCur = "0.0"
        ElseIf decNumericCur = 2 Then : tempNumericCur = "0.00"
        ElseIf decNumericCur = 3 Then : tempNumericCur = "0.000"
        ElseIf decNumericCur = 4 Then : tempNumericCur = "0.0000"
        ElseIf decNumericCur = 5 Then : tempNumericCur = "0.00000"
        ElseIf decNumericCur = 6 Then : tempNumericCur = "0.000000"
        End If

        If IsDBNull(str) Then : Return 0
        ElseIf CStr(str) = "" Then : Return 0
        Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
        End If

    End Function

    Public Function cCur2(ByVal str, Optional ByVal def = 0)
        Dim decNumericCur As Integer = 6
        Dim tempNumericCur As String = ""

        If decNumericCur = 0 Then : tempNumericCur = "0"
        ElseIf decNumericCur = 1 Then : tempNumericCur = "0.0"
        ElseIf decNumericCur = 2 Then : tempNumericCur = "0.00"
        ElseIf decNumericCur = 3 Then : tempNumericCur = "0.000"
        ElseIf decNumericCur = 4 Then : tempNumericCur = "0.0000"
        ElseIf decNumericCur = 5 Then : tempNumericCur = "0.00000"
        ElseIf decNumericCur = 6 Then : tempNumericCur = "0.000000"
        End If

        If IsDBNull(str) Then : Return 0
        ElseIf CStr(str) = "" Then : Return 0
        Else : Return Format(Val(CDec(str)), "###,##" & tempNumericCur)
        End If

    End Function

    Public Function cCur4(ByVal str, Optional ByVal def = 0)
        Dim decNumericCur As Integer = 4
        Dim tempNumericCur As String = ""

        If decNumericCur = 0 Then : tempNumericCur = "0"
        ElseIf decNumericCur = 1 Then : tempNumericCur = "0.0"
        ElseIf decNumericCur = 2 Then : tempNumericCur = "0.00"
        ElseIf decNumericCur = 3 Then : tempNumericCur = "0.000"
        ElseIf decNumericCur = 4 Then : tempNumericCur = "0.0000"
        ElseIf decNumericCur = 5 Then : tempNumericCur = "0.00000"
        ElseIf decNumericCur = 6 Then : tempNumericCur = "0.000000"
        End If

        If IsDBNull(str) Then : Return 0
        ElseIf CStr(str) = "" Then : Return 0
        Else : Return Double.Parse(Format(Val(CDec(str)), "###,##" & tempNumericCur))
        End If

    End Function
End Module
