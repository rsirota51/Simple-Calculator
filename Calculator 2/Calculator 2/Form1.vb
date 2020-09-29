Public Class Form1
    'Robert Sirota
    Dim operand1 As Double = 0
    Dim operand2 As Double = 0
    Dim op As String = Nothing
    Dim newOperand As Boolean = True

    Private Sub Number_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDot.Click, btn0.Click, btn1.Click, btn2.Click, _
    btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim btnNumberClicked As Button = sender
        If newOperand Then
            Me.txtDisplay.Text = btnNumberClicked.Tag
            newOperand = False
        Else
            Me.txtDisplay.Text &= btnNumberClicked.Tag
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtDisplay.Text = "0"
        operand1 = 0
        operand2 = 0
        newOperand = True
        op = Nothing
    End Sub

    Private Sub btnOff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOff.Click
        Application.Exit()
    End Sub

    Private Sub btnOperator_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlus.Click, btnMinus.Click, btnTimes.Click, _
    btnDivide.Click, btnEqual.Click, btnIntDivsion.Click, btnMod.Click, btnSquareRoot.Click, btnRndNum.Click, btnPercent.Click
        Dim decimalstring As String = "."
        Dim decimalcount As Integer
        Dim TextCheck As String = Me.txtDisplay.Text
        For index As Integer = 0 To TextCheck.Length() - 1
            If TextCheck.Chars(index) = decimalstring Then
                decimalcount += 1
            ElseIf decimalcount = 2 Then
                Me.txtDisplay.Text = "ERROR"
            End If
        Next
        Dim operatorSelected As Button = sender
        If (operand1 = 0 And op = Nothing) Or op = "=" Then
            operand1 = Val(Me.txtDisplay.Text)
        Else
            operand2 = Val(Me.txtDisplay.Text)
            operand1 = Calculate(operand1, operand2, op)
            Me.txtDisplay.Text = operand1
        End If
        op = operatorSelected.Tag
        newOperand = True
    End Sub

    Function Calculate(ByVal firstOperand As Double, ByVal secondOperand As Double, ByVal op As String) As Double
        Select Case op
            Case "+"
                Return (firstOperand + secondOperand)
            Case "-"
                Return (firstOperand - secondOperand)
            Case "*"
                Return (firstOperand * secondOperand)
            Case "/"
                If secondOperand = 0 Then
                    Me.txtDisplay.Text = "ERROR"
                End If
                Return (firstOperand / secondOperand)
            Case "\"
                Return (firstOperand \ secondOperand)
            Case "Mod"
                Return (firstOperand Mod secondOperand)
            Case "11"
                If firstOperand < 0 Then
                    firstOperand = Math.Abs(firstOperand)
                    firstOperand = Math.Sqrt(firstOperand)
                    Return (firstOperand & "i")
                ElseIf firstOperand > 0 Then
                    firstOperand = Math.Sqrt(firstOperand)
                    Return (firstOperand)
                End If
            Case "Rnd"
                If firstOperand < secondOperand Then
                    Me.txtDisplay.Text = "Chose Highest Number First"
                End If
                Return ((firstOperand - secondOperand + 1) * Rnd() + secondOperand)
            Case "%"
                Return (firstOperand * 100)
        End Select
    End Function
End Class
