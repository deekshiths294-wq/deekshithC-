Imports System.Data.OleDb

Public Class Form12

    Public Property FromLocation As String
    Public Property ToLocation As String
    Public Property TravelDate As Date
    Public Property Username As String

    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    ' ============================
    ' Form Load
    ' ============================
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBusResults()
    End Sub

    ' ============================
    ' Load bus results
    ' ============================
    Private Sub LoadBusResults()
        Dim dt As New DataTable()

        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                Dim query As String =
                    "SELECT B.BusNo, B.BusName, " &
                    "B.ArrivalDate AS [Arrival Time], B.DepartureTime AS [Departure Time], " &
                    "((B.SeatRows * B.SeatCols) - " &
                    "(SELECT COUNT(*) FROM Bookings BK WHERE BK.BusNo = B.BusNo AND BK.TravelDate = ?)) AS [Available Seats], " &
                    "B.Fare " &
                    "FROM BusDetails B " &
                    "WHERE B.Origin = ? AND B.Destination = ? AND B.AvailableDate = ?"

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", TravelDate)
                    cmd.Parameters.AddWithValue("?", FromLocation.Trim())
                    cmd.Parameters.AddWithValue("?", ToLocation.Trim())
                    cmd.Parameters.AddWithValue("?", TravelDate)

                    Using adapter As New OleDbDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

            ' Bind to DataGridView
            dataGridViewResults.DataSource = dt

            ' Remove existing button column if already added
            For Each col As DataGridViewColumn In dataGridViewResults.Columns
                If TypeOf col Is DataGridViewButtonColumn AndAlso col.Name = "SelectBus" Then
                    dataGridViewResults.Columns.Remove(col)
                    Exit For
                End If
            Next

            ' Add button column
            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.Name = "SelectBus"
            btnColumn.HeaderText = "Action"
            btnColumn.Text = "Select Bus"
            btnColumn.UseColumnTextForButtonValue = True
            dataGridViewResults.Columns.Add(btnColumn)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No buses found for the selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading bus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================
    ' Select Bus Button
    ' ============================
    Private Sub dataGridViewResults_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewResults.CellContentClick
        If e.RowIndex >= 0 AndAlso dataGridViewResults.Columns(e.ColumnIndex).Name = "SelectBus" Then
            Dim selectedBusNo As String = dataGridViewResults.Rows(e.RowIndex).Cells("BusNo").Value.ToString()
            Dim availableSeats As Integer = Convert.ToInt32(dataGridViewResults.Rows(e.RowIndex).Cells("Available Seats").Value)

            If availableSeats <= 0 Then
                MessageBox.Show("Sorry, this bus is fully booked.", "No Seats Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Proceed to Form13
            Dim bookingForm As New Form13 With {
                .BusNo = selectedBusNo,
                .FromLocation = Me.FromLocation,
                .ToLocation = Me.ToLocation,
                .TravelDate = Me.TravelDate,
                .Username = Me.Username
            }

            bookingForm.Show()
            bookingForm.BringToFront()
            bookingForm.Activate()

            ' ✅ Clear and Hide this form
            ResetForm()
            Me.Hide()
        End If
    End Sub

    ' ============================
    ' Back Button
    ' ============================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim prevForm As New Form11 With {
            .Username = Me.Username
        }

        prevForm.Show()
        prevForm.BringToFront()
        prevForm.Activate()

        ' ✅ Clear and Hide this form
        ResetForm()
        Me.Hide()
    End Sub

    ' ============================
    ' Reset/Trim the form
    ' ============================
    Private Sub ResetForm()
        dataGridViewResults.DataSource = Nothing
        dataGridViewResults.Columns.Clear()

        ' Clear properties
        FromLocation = String.Empty
        ToLocation = String.Empty
        TravelDate = Date.MinValue
        Username = String.Empty
    End Sub

End Class
