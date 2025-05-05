Partial Class _Default
    Inherits Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Request.HttpMethod.ToUpper() = "POST" Then

            lblMsg.Text = ""
            If IsNumeric(txtValue.Text) Then

                Dim number As Integer = Integer.Parse(txtValue.Text)

                If number > 0 Then

                    Dim board(,) As Integer = FillArray(number)
                    Dim size As Integer = board.GetLength(0) - 1

                    ' opulate the table for display
                    For row As Integer = 0 To size

                        Dim tableRow = New TableRow()

                        For column As Integer = 0 To size

                            Dim cell As New TableCell
                            Dim obj = New LiteralControl(board(row, column).ToString)
                            cell.Controls.Add(obj)
                            tableRow.Cells.Add(cell)
                        Next column
                        Table1.Rows.Add(tableRow)

                    Next row

                    Dim fraction As Double = Math.Sqrt(number + 1) Mod 1

                    If fraction <> 0D Then
                        lblMsg.CssClass = "label-danger"
                        lblMsg.Style.Add(HtmlTextWriterStyle.Color, "White")
                        lblMsg.Text = "With the number provide isn´t be possible go to zero."
                    End If
                Else
                    lblMsg.Text = "Please type a positive number"

                End If

            Else

                lblMsg.Text = "Please type numbers only"
            End If



        End If


    End Sub

    Function FillArray(value As Integer) As Integer(,)
        ' Dim value As Integer = 20

        ' Plus one because the limit is to zero.
        ' Less one because arrays are zero-indexed.
        Dim sizeOfArray As Integer = Math.Sqrt(value + 1) - 1
        Dim board(sizeOfArray, sizeOfArray) As Integer
        Dim row As Integer = 0
        Dim column As Integer = 0
        Dim iterationNumber As Integer = 0
        Dim bottomToTopLimit As Integer = 1

        While value > 0

            ' fill from right to left
            For column = sizeOfArray - iterationNumber To iterationNumber Step -1

                board(row, column) = value
                If value > 0 Then value -= 1
            Next

            If value = 0 Then Exit While

            column = 0 + iterationNumber

            'fill from top to bottom
            For row = 1 + iterationNumber To sizeOfArray - iterationNumber
                board(row, column) = value
                If value > 0 Then value -= 1
            Next

            If value = 0 Then Exit While

            'fill from to left to right

            row = sizeOfArray - iterationNumber
            For column = 1 + iterationNumber To sizeOfArray - iterationNumber
                board(row, column) = value
                If value > 0 Then value -= 1
            Next

            If value = 0 Then Exit While

            'fill from to bottom to top
            column = sizeOfArray - iterationNumber

            'when this loop is finished, so the variable row is set to ( bottomToTopLimit -1 )
            For row = sizeOfArray - bottomToTopLimit To bottomToTopLimit Step -1
                board(row, column) = value
                If value > 0 Then value -= 1
            Next

            bottomToTopLimit += 1
            iterationNumber += 1
            row += 1

            ' Given the provided value and the generated matrix, decrementing to zero may not be feasible.
            ' Thus, reaching this condition indicates that further progress is impossible
            If board.GetLength(1) = bottomToTopLimit Then Exit While
        End While

        Return board
    End Function


End Class