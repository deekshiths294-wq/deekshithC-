Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class addbus

    ' Access database connection string
    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    Private Sub addbus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboBusType.DropDownStyle = ComboBoxStyle.DropDownList
        cboBusType.Items.Clear()
        cboBusType.Items.AddRange(New Object() {"AC", "Normal"})
        cboBusType.SelectedIndex = 0

        ' Setup DateTimePickers for time only
        dtpArrival.Format = DateTimePickerFormat.Custom
        dtpArrival.CustomFormat = "HH:mm"
        dtpArrival.ShowUpDown = True

        dtpDeparture.Format = DateTimePickerFormat.Custom
        dtpDeparture.CustomFormat = "HH:mm"
        dtpDeparture.ShowUpDown = True

        dtpTravelTime.Format = DateTimePickerFormat.Custom
        dtpTravelTime.CustomFormat = "HH:mm"
        dtpTravelTime.ShowUpDown = True
        dtpTravelTime.Enabled = False ' Disable manual editing of travel time

        dtpAvailable.Format = DateTimePickerFormat.Short
        dtpAvailable.MinDate = DateTime.Today ' Restrict to today or future dates

        ' Initial calculation for travel time
        RecalculateTravelTime()
    End Sub

    ' === AUTO CALCULATE TRAVEL TIME ===
    Private Sub RecalculateTravelTime()
        Dim departure As DateTime = dtpDeparture.Value
        Dim arrival As DateTime = dtpArrival.Value

        ' If arrival is earlier than departure, assume next day
        If arrival < departure Then
            arrival = arrival.AddDays(1)
        End If

        Dim duration As TimeSpan = arrival - departure
        Dim formatted As DateTime = DateTime.Today.Add(duration)

        dtpTravelTime.Value = formatted
    End Sub

    ' When arrival or departure time changes, recalculate
    Private Sub dtpArrival_ValueChanged(sender As Object, e As EventArgs) Handles dtpArrival.ValueChanged
        RecalculateTravelTime()
    End Sub

    Private Sub dtpDeparture_ValueChanged(sender As Object, e As EventArgs) Handles dtpDeparture.ValueChanged
        RecalculateTravelTime()
    End Sub

    ' === INSERT BUTTON ===
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim rows As Integer, cols As Integer, fare As Decimal

        ' === Input Validations ===
        If String.IsNullOrWhiteSpace(txtBusNo.Text) OrElse Not Regex.IsMatch(txtBusNo.Text.Trim(), "^\d+$") Then
            MessageBox.Show("Bus No is required and must contain digits only.") : txtBusNo.Focus() : Exit Sub
        End If

        If Not Integer.TryParse(txtSeatRows.Text, rows) OrElse rows <= 0 Then
            MessageBox.Show("Enter a valid number for Seat Rows.") : txtSeatRows.Focus() : Exit Sub
        End If

        If Not Integer.TryParse(txtSeatCols.Text, cols) OrElse cols <= 0 Then
            MessageBox.Show("Enter a valid number for Seat Columns.") : txtSeatCols.Focus() : Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtOrigin.Text) OrElse Not Regex.IsMatch(txtOrigin.Text.Trim(), "^[A-Za-z\s]+$") Then
            MessageBox.Show("Origin must contain only letters.") : txtOrigin.Focus() : Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtDestination.Text) OrElse Not Regex.IsMatch(txtDestination.Text.Trim(), "^[A-Za-z\s]+$") Then
            MessageBox.Show("Destination must contain only letters.") : txtDestination.Focus() : Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtBusName.Text) OrElse Not Regex.IsMatch(txtBusName.Text.Trim(), "^[A-Za-z\s]+$") Then
            MessageBox.Show("Bus Name must contain only letters.") : txtBusName.Focus() : Exit Sub
        End If

        If Not Decimal.TryParse(txtFare.Text.Trim(), fare) Then
            MessageBox.Show("Enter a valid number for Fare.") : txtFare.Focus() : Exit Sub
        End If

        ' === Prepare values ===
        Dim availableDate As Date = dtpAvailable.Value.Date
        Dim arrivalTime As String = dtpArrival.Value.ToString("HH:mm")
        Dim departureTime As String = dtpDeparture.Value.ToString("HH:mm")
        Dim travelTime As String = dtpTravelTime.Value.ToString("HH:mm")

        ' === Insert into DB ===
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                ' Check duplicate BusNo
                Using chk As New OleDbCommand("SELECT COUNT(*) FROM BusDetails WHERE BusNo = ?", con)
                    chk.Parameters.AddWithValue("?", txtBusNo.Text.Trim())
                    If CInt(chk.ExecuteScalar()) > 0 Then
                        MessageBox.Show("This Bus No already exists.") : Exit Sub
                    End If
                End Using

                ' Insert query
                Using cmd As New OleDbCommand("INSERT INTO BusDetails (BusNo, BusType, SeatRows, SeatCols, Origin, Destination, BusName, Fare, AvailableDate, ArrivalDate, DepartureTime, TotalTravelTime) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", con)
                    cmd.Parameters.AddWithValue("?", txtBusNo.Text.Trim())
                    cmd.Parameters.AddWithValue("?", cboBusType.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("?", rows)
                    cmd.Parameters.AddWithValue("?", cols)
                    cmd.Parameters.AddWithValue("?", txtOrigin.Text.Trim())
                    cmd.Parameters.AddWithValue("?", txtDestination.Text.Trim())
                    cmd.Parameters.AddWithValue("?", txtBusName.Text.Trim())
                    cmd.Parameters.AddWithValue("?", fare)
                    cmd.Parameters.AddWithValue("?", availableDate)
                    cmd.Parameters.AddWithValue("?", arrivalTime)
                    cmd.Parameters.AddWithValue("?", departureTime)
                    cmd.Parameters.AddWithValue("?", travelTime)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Bus added successfully!")

            ' Clear form
            txtBusNo.Clear()
            txtSeatRows.Clear()
            txtSeatCols.Clear()
            txtOrigin.Clear()
            txtDestination.Clear()
            txtBusName.Clear()
            txtFare.Clear()
            cboBusType.SelectedIndex = 0
            txtBusNo.Focus()

        Catch ex As Exception
            MessageBox.Show("Insert failed: " & ex.Message)
        End Try
    End Sub

    ' VIEW ALL
    Private Sub btnViewAll_Click(sender As Object, e As EventArgs) Handles btnViewAll.Click
        Form6.Show()
        Form6.BringToFront()
        Form6.Activate()
        Me.Hide()

    End Sub

    ' BACK
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Form4.BringToFront()
        Form4.Activate()
        Me.Hide()

    End Sub

    ' === KEYBOARD VALIDATIONS ===

    ' BusNo: Digits only
    Private Sub txtBusNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusNo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    ' SeatRows and SeatCols: Digits only
    Private Sub txtSeatRows_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSeatRows.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSeatCols_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSeatCols.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    ' Fare: Digits, one dot allowed
    Private Sub txtFare_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFare.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        ElseIf e.KeyChar = "."c AndAlso txtFare.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ' Origin, Destination, BusName: Letters and space only
    Private Sub AlphabetOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrigin.KeyPress, txtDestination.KeyPress, txtBusName.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    ' === LOAD BUS DETAILS FROM BUS NO ===
    Public Sub LoadBusDetails(busNo As String)
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()
                Dim query As String = "SELECT * FROM BusDetails WHERE BusNo = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", busNo)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtBusNo.Text = reader("BusNo").ToString()
                            cboBusType.SelectedItem = reader("BusType").ToString()
                            txtSeatRows.Text = reader("SeatRows").ToString()
                            txtSeatCols.Text = reader("SeatCols").ToString()
                            txtOrigin.Text = reader("Origin").ToString()
                            txtDestination.Text = reader("Destination").ToString()
                            txtBusName.Text = reader("BusName").ToString()
                            txtFare.Text = reader("Fare").ToString()

                            ' Set AvailableDate to date only (time = 00:00:00)
                            dtpAvailable.Value = Convert.ToDateTime(reader("AvailableDate")).Date

                            dtpArrival.Value = DateTime.Today.Add(TimeSpan.Parse(reader("ArrivalDate").ToString()))
                            dtpDeparture.Value = DateTime.Today.Add(TimeSpan.Parse(reader("DepartureTime").ToString()))
                            dtpTravelTime.Value = DateTime.Today.Add(TimeSpan.Parse(reader("TotalTravelTime").ToString()))
                        Else
                            MessageBox.Show("Bus not found.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load bus details: " & ex.Message)
        End Try
    End Sub

End Class
