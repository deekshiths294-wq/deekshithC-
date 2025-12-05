Public Class Form15

    ' These properties are passed from the previous form (e.g., payment or seat selection)
    Public Property Username As String
    Public Property TotalFare As Decimal
    Public Property SeatList As List(Of String)
    Public Property CardType As String
    Public Property Bank As String

    ' When the form loads, populate the labels with passed data
    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsername.Text = Username
        lblFare.Text = "₹" & TotalFare.ToString("0.00")
        lblSeats.Text = String.Join(", ", SeatList)
        lblCard.Text = CardType
        lblBank.Text = Bank
        lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt")
    End Sub

    ' === Logout button click - CLOSES APP ===
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Application.Exit() ' Fully exits the application
    End Sub

    ' === Feedback button click - JUST OPENS feedback form ===

    Private Sub Buttondd_Click(sender As Object, e As EventArgs) Handles Buttondd.Click

        feedback.Show()
        feedback.BringToFront()
        feedback.Activate()
        Me.Hide()
    End Sub

    ' Optional: clear stored values (not used since app is closing)
    Private Sub ClearFormData()
        Username = String.Empty
        TotalFare = 0
        SeatList = Nothing
        CardType = String.Empty
        Bank = String.Empty

        lblUsername.Text = String.Empty
        lblFare.Text = String.Empty
        lblSeats.Text = String.Empty
        lblCard.Text = String.Empty
        lblBank.Text = String.Empty
        lblDate.Text = String.Empty
    End Sub

    ' Optional: Custom paint for panel if needed
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' You can draw custom UI elements here if needed
    End Sub



End Class
