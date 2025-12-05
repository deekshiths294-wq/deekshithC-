Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Admin Dashboard"

        ' Removed "Bus Details Report"
        Dim menuItems As String() = {
            "Add Bus",
            "Route Details",
            "Booking Report",
            "Feedback"
        }

        Dim buttonWidth As Integer = 200
        Dim buttonHeight As Integer = 40
        Dim spacing As Integer = 10

        Dim totalHeight As Integer = menuItems.Length * (buttonHeight + spacing) - spacing
        Dim startY As Integer = (Me.ClientSize.Height - totalHeight) \ 2
        Dim startX As Integer = (Me.ClientSize.Width - buttonWidth) \ 2

        For i As Integer = 0 To menuItems.Length - 1
            Dim btn As New Button()
            btn.Text = menuItems(i)
            btn.Width = buttonWidth
            btn.Height = buttonHeight
            btn.Left = startX
            btn.Top = startY + i * (buttonHeight + spacing)
            btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            AddHandler btn.Click, AddressOf MenuButton_Click
            Me.Controls.Add(btn)
        Next
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)

        Select Case clickedButton.Text
            Case "Add Bus"
                addbus.Show()
                addbus.BringToFront()
                addbus.Activate()
                Me.Hide()

            Case "Route Details"
                Form6.Show()
                Form6.BringToFront()
                Form6.Activate()
                Me.Hide()

            Case "Booking Report"
                Form16.Show()
                Form16.BringToFront()
                Form16.Activate()
                Me.Hide()
            Case "Feedback"
                feedbackshow.Show()
                feedbackshow.BringToFront()
                feedbackshow.Activate()
                Me.Hide()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Form1.BringToFront()
        Form1.Activate()
        Me.Hide()
    End Sub
End Class
