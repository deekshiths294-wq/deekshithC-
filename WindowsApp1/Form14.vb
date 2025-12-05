Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class Form14
    Public Property TotalFare As Decimal
    Public Property SeatList As List(Of String)
    Public Property Username As String
    Public Property BusNo As String
    Public Property TravelDate As Date
    Public Property FromLocation As String
    Public Property ToLocation As String
    Public Property FarePerSeat As Decimal

    Private bookingConfirmed As Boolean = False
    Private generatedOTP As String

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCard.Items.AddRange({"Debit", "Credit"})
        cmbBank.Items.AddRange({"SBI", "HDFC", "ICICI", "CANARA", "BANK OF BARODA"})

        ' Clear any default row
        DataGridView1.Rows.Clear()
        DataGridView1.AllowUserToAddRows = False

        ' Add first row to start
        If SeatList IsNot Nothing AndAlso SeatList.Count > 0 Then
            DataGridView1.Rows.Add(1, "", "", "", "", "")
        End If
    End Sub

    ' ✅ Add Passenger Row
    Private Sub btnAddPassengerDetails_Click(sender As Object, e As EventArgs) Handles btnAddPassengerDetails.Click
        ' Validate current last row is filled
        Dim lastRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
        If String.IsNullOrWhiteSpace(Convert.ToString(lastRow.Cells(1).Value)) Then
            MessageBox.Show("Fill current passenger details before adding new.")
            Return
        End If

        ' Prevent exceeding seat count
        If DataGridView1.Rows.Count >= SeatList.Count Then
            MessageBox.Show("All seat passenger details have been entered.")
            Return
        End If

        DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, "", "", "", "", "")
        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
        DataGridView1.BeginEdit(True)
    End Sub

    ' ✅ Confirm Passenger Data
    Private Sub btnConfirmBooking_Click(sender As Object, e As EventArgs) Handles btnConfirmBooking.Click
        Dim filledRowCount As Integer = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim fname = Convert.ToString(row.Cells(1).Value).Trim()
            Dim lname = Convert.ToString(row.Cells(2).Value).Trim()
            Dim email = Convert.ToString(row.Cells(3).Value).Trim()
            Dim contact = Convert.ToString(row.Cells(4).Value).Trim()
            Dim city = Convert.ToString(row.Cells(5).Value).Trim()

            If String.IsNullOrWhiteSpace(fname) OrElse Not Regex.IsMatch(fname, "^[A-Za-z]+$") Then
                MessageBox.Show($"Row {row.Index + 1}: Invalid First Name")
                Return
            End If

            If String.IsNullOrWhiteSpace(lname) OrElse Not Regex.IsMatch(lname, "^[A-Za-z]+$") Then
                MessageBox.Show($"Row {row.Index + 1}: Invalid Last Name")
                Return
            End If

            If Not IsValidGmail(email) Then
                MessageBox.Show($"Row {row.Index + 1}: Invalid Email")
                Return
            End If

            If Not Regex.IsMatch(contact, "^\d{10}$") Then
                MessageBox.Show($"Row {row.Index + 1}: Contact must be 10 digits.")
                Return
            End If

            If String.IsNullOrWhiteSpace(city) OrElse Not Regex.IsMatch(city, "^[A-Za-z\s]+$") Then
                MessageBox.Show($"Row {row.Index + 1}: Invalid City")
                Return
            End If

            filledRowCount += 1
        Next

        If filledRowCount < SeatList.Count Then
            MessageBox.Show($"Please enter all {SeatList.Count} passenger details.")
            Return
        End If

        bookingConfirmed = True
        MessageBox.Show("Passenger details confirmed. Proceed to payment.")
    End Sub

    ' ✅ Generate OTP
    Private Function GenerateOTP() As String
        Dim rnd As New Random()
        Return rnd.Next(100000, 999999).ToString()
    End Function

    ' ✅ Get OTP Button
    Private Sub btnGetOTP_Click(sender As Object, e As EventArgs) Handles btnGetOTP.Click
        If String.IsNullOrWhiteSpace(txtMobile.Text) OrElse Not Regex.IsMatch(txtMobile.Text, "^\d{10}$") Then
            MessageBox.Show("Enter a valid 10-digit registered mobile number.")
            Return
        End If

        generatedOTP = GenerateOTP()
        MessageBox.Show("Your OTP is: " & generatedOTP)
    End Sub

    ' ✅ Make Payment
    Private Sub btnMakePayment_Click(sender As Object, e As EventArgs) Handles btnMakePayment.Click
        If Not bookingConfirmed Then
            MessageBox.Show("Confirm passenger details first.")
            Return
        End If

        If cmbCard.SelectedIndex = -1 OrElse cmbBank.SelectedIndex = -1 Then
            MessageBox.Show("Select Card type and Bank.")
            Return
        End If

        ' ✅ Card number must be exactly 16 digits
        If String.IsNullOrWhiteSpace(txtCardNo.Text) OrElse Not IsNumeric(txtCardNo.Text) OrElse txtCardNo.Text.Length <> 16 Then
            MessageBox.Show("Card number must be exactly 16 digits.")
            Return
        End If

        ' ✅ CVV Validation (3 digits)
        If String.IsNullOrWhiteSpace(txtCVV.Text) OrElse Not IsNumeric(txtCVV.Text) OrElse txtCVV.Text.Length <> 3 Then
            MessageBox.Show("Invalid CVV.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtOTP.Text) OrElse txtOTP.Text.Trim() <> generatedOTP Then
            MessageBox.Show("Invalid OTP. Please try again.")
            Return
        End If

        ' ✅ Save to database
        Dim conStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                ' Insert into Bookings
                For Each seat In SeatList
                    Dim cmd As New OleDbCommand("INSERT INTO Bookings (BusNo, TravelDate, SeatNo, FromLocation, ToLocation, Fare, Username) VALUES (?, ?, ?, ?, ?, ?, ?)", con)
                    cmd.Parameters.AddWithValue("?", BusNo)
                    cmd.Parameters.AddWithValue("?", TravelDate)
                    cmd.Parameters.AddWithValue("?", seat)
                    cmd.Parameters.AddWithValue("?", FromLocation)
                    cmd.Parameters.AddWithValue("?", ToLocation)
                    cmd.Parameters.AddWithValue("?", FarePerSeat)
                    cmd.Parameters.AddWithValue("?", Username)
                    cmd.ExecuteNonQuery()
                Next

                ' Insert into Passengers
                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim fname = row.Cells(1).Value.ToString()
                    Dim lname = row.Cells(2).Value.ToString()
                    Dim email = row.Cells(3).Value.ToString()
                    Dim contact = row.Cells(4).Value.ToString()
                    Dim city = row.Cells(5).Value.ToString()

                    Dim cmd As New OleDbCommand("INSERT INTO Passengers (FirstName, LastName, Email, Contact, City) VALUES (?, ?, ?, ?, ?)", con)
                    cmd.Parameters.AddWithValue("?", fname)
                    cmd.Parameters.AddWithValue("?", lname)
                    cmd.Parameters.AddWithValue("?", email)
                    cmd.Parameters.AddWithValue("?", contact)
                    cmd.Parameters.AddWithValue("?", city)
                    cmd.ExecuteNonQuery()
                Next
            End Using

            ' Show invoice
            Dim invoiceForm As New Form15()
            invoiceForm.Username = Username
            invoiceForm.TotalFare = TotalFare
            invoiceForm.SeatList = SeatList
            invoiceForm.CardType = cmbCard.SelectedItem.ToString()
            invoiceForm.Bank = cmbBank.SelectedItem.ToString()
            invoiceForm.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Payment failed: " & ex.Message)
        End Try
    End Sub

    ' ✅ Gmail Validation
    Private Function IsValidGmail(email As String) As Boolean
        Return Regex.IsMatch(email, "^[A-Za-z0-9._%+-]+@gmail\.com$")
    End Function

    ' ✅ Logout
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' No painting logic needed
    End Sub

    Private Sub txtCardNo_TextChanged(sender As Object, e As EventArgs) Handles txtCardNo.TextChanged

    End Sub


End Class
