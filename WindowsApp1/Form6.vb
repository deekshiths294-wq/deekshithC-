Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class Form6

    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    Private isRefreshing As Boolean = False

    ' === Load Form ===
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBusData()
    End Sub

    ' === Load Data into Grid ===
    Private Sub LoadBusData()
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()
                Dim query As String =
                    "SELECT BusNo, BusType, SeatRows, SeatCols, Origin, Destination, BusName, Fare, AvailableDate, ArrivalDate, DepartureTime, TotalTravelTime FROM BusDetails"

                Using cmd As New OleDbCommand(query, con)
                    Dim adapter As New OleDbDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    ' ✅ Remove time part from AvailableDate
                    For Each row As DataRow In dt.Rows
                        If Not IsDBNull(row("AvailableDate")) Then
                            row("AvailableDate") = CType(row("AvailableDate"), DateTime).ToString("dd-MM-yyyy")
                        End If
                    Next

                    DataGridView1.DataSource = dt

                    ' ✅ Make BusNo read-only (cannot modify)
                    If DataGridView1.Columns.Contains("BusNo") Then
                        DataGridView1.Columns("BusNo").ReadOnly = True
                    End If

                    ' ✅ Format display
                    If DataGridView1.Columns.Contains("AvailableDate") Then
                        DataGridView1.Columns("AvailableDate").DefaultCellStyle.Format = "dd-MM-yyyy"
                    End If
                    If DataGridView1.Columns.Contains("ArrivalDate") Then
                        DataGridView1.Columns("ArrivalDate").DefaultCellStyle.Format = "HH:mm"
                    End If
                    If DataGridView1.Columns.Contains("DepartureTime") Then
                        DataGridView1.Columns("DepartureTime").DefaultCellStyle.Format = "HH:mm"
                    End If
                    If DataGridView1.Columns.Contains("TotalTravelTime") Then
                        DataGridView1.Columns("TotalTravelTime").DefaultCellStyle.Format = "HH:mm"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    ' === SAVE (Update Bus) ===
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.IsNewRow Then Continue For

                    Dim busNo = row.Cells("BusNo").Value?.ToString().Trim()  ' 🔒 ReadOnly, only used in WHERE
                    Dim busType = row.Cells("BusType").Value?.ToString().Trim().ToUpper()
                    Dim origin = row.Cells("Origin").Value?.ToString().Trim()
                    Dim destination = row.Cells("Destination").Value?.ToString().Trim()
                    Dim busName = row.Cells("BusName").Value?.ToString().Trim()

                    Dim seatRows, seatCols As Integer
                    Dim fare As Decimal
                    Dim availableDate As DateTime
                    Dim arrivalTime As TimeSpan
                    Dim departureTime As TimeSpan
                    Dim totalTravelTime As TimeSpan

                    ' === VALIDATION ===
                    If String.IsNullOrEmpty(busNo) OrElse Not Regex.IsMatch(busNo, "^\d+$") Then
                        MessageBox.Show("BusNo must be digits only.") : Exit Sub
                    End If

                    If String.IsNullOrEmpty(busType) OrElse (busType <> "AC" AndAlso busType <> "NORMAL") Then
                        MessageBox.Show("BusType must be either 'AC' or 'NORMAL'.") : Exit Sub
                    End If

                    If Not Integer.TryParse(row.Cells("SeatRows").Value?.ToString(), seatRows) OrElse seatRows <= 0 Then
                        MessageBox.Show("SeatRows must be a positive integer.") : Exit Sub
                    End If

                    If Not Integer.TryParse(row.Cells("SeatCols").Value?.ToString(), seatCols) OrElse seatCols <= 0 Then
                        MessageBox.Show("SeatCols must be a positive integer.") : Exit Sub
                    End If

                    If String.IsNullOrEmpty(origin) OrElse Not Regex.IsMatch(origin, "^[A-Za-z\s]+$") Then
                        MessageBox.Show("Origin must contain only letters.") : Exit Sub
                    End If

                    If String.IsNullOrEmpty(destination) OrElse Not Regex.IsMatch(destination, "^[A-Za-z\s]+$") Then
                        MessageBox.Show("Destination must contain only letters.") : Exit Sub
                    End If

                    If String.IsNullOrEmpty(busName) OrElse Not Regex.IsMatch(busName, "^[A-Za-z\s]+$") Then
                        MessageBox.Show("Bus Name must contain only letters.") : Exit Sub
                    End If

                    If Not Decimal.TryParse(row.Cells("Fare").Value?.ToString(), fare) OrElse fare < 0 Then
                        MessageBox.Show("Fare must be a positive number.") : Exit Sub
                    End If

                    If Not DateTime.TryParse(row.Cells("AvailableDate").Value?.ToString(), availableDate) Then
                        MessageBox.Show("AvailableDate is invalid.") : Exit Sub
                        ' ElseIf availableDate.Date < Date.Today Then
                        '  MessageBox.Show("AvailableDate cannot be in the past.") : Exit Sub
                    End If

                    If Not TimeSpan.TryParse(row.Cells("ArrivalDate").Value?.ToString(), arrivalTime) Then
                        MessageBox.Show("Arrival Time is invalid. Use HH:mm format.") : Exit Sub
                    End If

                    If Not TimeSpan.TryParse(row.Cells("DepartureTime").Value?.ToString(), departureTime) Then
                        MessageBox.Show("Departure Time is invalid. Use HH:mm format.") : Exit Sub
                    End If

                    If Not TimeSpan.TryParse(row.Cells("TotalTravelTime").Value?.ToString(), totalTravelTime) Then
                        MessageBox.Show("Total Travel Time is invalid. Use HH:mm format.") : Exit Sub
                    End If

                    ' === Update Query (BusNo only in WHERE) ===
                    Using cmd As New OleDbCommand("
                        UPDATE BusDetails 
                        SET BusType=?, SeatRows=?, SeatCols=?, Origin=?, Destination=?, BusName=?, Fare=?, AvailableDate=DateValue(?), ArrivalDate=?, DepartureTime=?, TotalTravelTime=? 
                        WHERE BusNo=?", con)

                        cmd.Parameters.AddWithValue("?", busType)
                        cmd.Parameters.AddWithValue("?", seatRows)
                        cmd.Parameters.AddWithValue("?", seatCols)
                        cmd.Parameters.AddWithValue("?", origin)
                        cmd.Parameters.AddWithValue("?", destination)
                        cmd.Parameters.AddWithValue("?", busName)
                        cmd.Parameters.AddWithValue("?", fare)

                        ' ✅ Save date only (yyyy-MM-dd avoids time)
                        cmd.Parameters.AddWithValue("?", availableDate.ToString("yyyy-MM-dd"))

                        cmd.Parameters.AddWithValue("?", arrivalTime)
                        cmd.Parameters.AddWithValue("?", departureTime)
                        cmd.Parameters.AddWithValue("?", totalTravelTime)
                        cmd.Parameters.AddWithValue("?", busNo)

                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            MessageBox.Show("Data updated successfully.")
            LoadBusData()

        Catch ex As Exception
            MessageBox.Show("Save failed: " & ex.Message)
        End Try
    End Sub

    ' === DELETE Bus ===
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to delete.")
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this bus?", "Confirm Delete", MessageBoxButtons.YesNo)
        If confirm = DialogResult.Yes Then
            Try
                Dim busNo = DataGridView1.SelectedRows(0).Cells("BusNo").Value.ToString()

                Using con As New OleDbConnection(conStr)
                    con.Open()
                    Using cmd As New OleDbCommand("DELETE FROM BusDetails WHERE BusNo = ?", con)
                        cmd.Parameters.AddWithValue("?", busNo)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Bus deleted successfully.")
                LoadBusData()

            Catch ex As Exception
                MessageBox.Show("Delete failed: " & ex.Message)
            End Try
        End If
    End Sub

    ' === REFRESH ===
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            isRefreshing = True
            LoadBusData()
        Finally
            isRefreshing = False
        End Try
    End Sub

    ' === BACK ===
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Form4.Show()
        Form4.BringToFront()
        Form4.Activate()
        Me.Hide()
    End Sub

End Class
