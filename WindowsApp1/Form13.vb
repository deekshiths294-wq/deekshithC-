Imports System.Data.OleDb

Public Class Form13
    Public Property BusNo As String
    Public Property FromLocation As String
    Public Property ToLocation As String
    Public Property TravelDate As Date
    Public Property Username As String

    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    Private SeatButtons As New Dictionary(Of String, Button)
    Public SelectedSeats As New List(Of String)
    Public FarePerSeat As Decimal = 0D
    Private MaxSeatsAllowed As Integer = 3

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetForm()

        ' Make TextBoxes read-only and visually non-editable
        For Each tb As TextBox In {txtFrom, txtTo, txtTravelDate, txtSelectedSeats, txtFarePerSeat, txtTotalFare}
            tb.ReadOnly = True
            tb.TabStop = False                ' Prevent tab focus
            tb.BorderStyle = BorderStyle.None ' Remove border
            tb.BackColor = Me.BackColor       ' Match form background
            tb.Cursor = Cursors.Default       ' Default cursor (no I-beam)
        Next

        txtFrom.Text = FromLocation
        txtTo.Text = ToLocation
        txtTravelDate.Text = TravelDate.ToShortDateString()
        PanelSeats.AutoScroll = True

        LoadFare()
        GenerateSeats()
        LoadBookedSeats()
        UpdateSummary()
    End Sub

    Private Sub ResetForm()
        SelectedSeats.Clear()
        txtSelectedSeats.Text = ""
        txtTotalFare.Text = "0.00"
        txtFarePerSeat.Text = "0.00"

        For Each btn In SeatButtons.Values
            btn.BackColor = Color.LightBlue
            btn.Enabled = True
        Next
    End Sub

    Private Sub LoadFare()
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()
                Dim cmd As New OleDbCommand("SELECT Fare FROM BusDetails WHERE BusNo = ?", con)
                cmd.Parameters.AddWithValue("?", BusNo)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    FarePerSeat = Convert.ToDecimal(result)
                    txtFarePerSeat.Text = FarePerSeat.ToString("0.00")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading fare: " & ex.Message)
        End Try
    End Sub

    Private Sub GenerateSeats()
        PanelSeats.Controls.Clear()
        SeatButtons.Clear()

        Dim rows As Integer = 0
        Dim cols As Integer = 0

        Try
            Using con As New OleDbConnection(conStr)
                con.Open()
                Dim cmd As New OleDbCommand("SELECT SeatRows, SeatCols FROM BusDetails WHERE BusNo = ?", con)
                cmd.Parameters.AddWithValue("?", BusNo)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        rows = Convert.ToInt32(reader("SeatRows"))
                        cols = Convert.ToInt32(reader("SeatCols"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching seat layout: " & ex.Message)
            Return
        End Try

        Dim startX As Integer = 20
        Dim startY As Integer = 20
        Dim btnSize As Integer = 40
        Dim gap As Integer = 5
        Dim seatCounter As Integer = 1

        For r As Integer = 1 To rows
            For c As Integer = 1 To cols
                Dim seatNo As String = seatCounter.ToString()
                Dim btn As New Button()
                btn.Name = "btn" & seatNo
                btn.Text = seatNo
                btn.Width = btnSize
                btn.Height = btnSize
                btn.Left = startX + (c - 1) * (btnSize + gap)
                btn.Top = startY + (r - 1) * (btnSize + gap)
                btn.BackColor = Color.LightBlue
                AddHandler btn.Click, AddressOf Seat_Click

                PanelSeats.Controls.Add(btn)
                SeatButtons(seatNo) = btn
                seatCounter += 1
            Next
        Next
    End Sub

    Private Sub LoadBookedSeats()
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()
                Dim cmd As New OleDbCommand("SELECT SeatNo FROM Bookings WHERE BusNo = ? AND TravelDate = ?", con)
                cmd.Parameters.AddWithValue("?", BusNo)
                cmd.Parameters.AddWithValue("?", TravelDate)

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim seat As String = reader("SeatNo").ToString()
                        If SeatButtons.ContainsKey(seat) Then
                            SeatButtons(seat).BackColor = Color.Red
                            SeatButtons(seat).Enabled = False
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading booked seats: " & ex.Message)
        End Try
    End Sub

    Private Sub Seat_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim seatNo As String = btn.Text

        If btn.BackColor = Color.LightBlue Then
            If SelectedSeats.Count >= MaxSeatsAllowed Then
                MessageBox.Show("You can select only up to 3 seats per person.")
                Return
            End If

            btn.BackColor = Color.Black
            SelectedSeats.Add(seatNo)

        ElseIf btn.BackColor = Color.Black Then
            btn.BackColor = Color.LightBlue
            SelectedSeats.Remove(seatNo)
        End If

        UpdateSummary()
    End Sub

    Private Sub UpdateSummary()
        txtSelectedSeats.Text = String.Join(",", SelectedSeats)
        Dim total As Decimal = SelectedSeats.Count * FarePerSeat
        txtTotalFare.Text = total.ToString("0.00")
    End Sub

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        If SelectedSeats.Count = 0 Then
            MessageBox.Show("Please select at least one seat.")
            Return
        End If

        Dim paymentForm As New Form14()
        paymentForm.TotalFare = SelectedSeats.Count * FarePerSeat
        paymentForm.SeatList = SelectedSeats
        paymentForm.Username = Me.Username
        paymentForm.BusNo = Me.BusNo
        paymentForm.TravelDate = Me.TravelDate
        paymentForm.FromLocation = Me.FromLocation
        paymentForm.ToLocation = Me.ToLocation
        paymentForm.FarePerSeat = Me.FarePerSeat
        paymentForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form10.Show()
        Me.Hide()
    End Sub


End Class
