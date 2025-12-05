Imports System.Data.OleDb

Public Class Form16

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView for viewing only
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        LoadCombinedData()
    End Sub

    Private Sub LoadCombinedData()
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"
        Dim bookingsTable As New DataTable()
        Dim passengersTable As New DataTable()
        Dim combinedTable As New DataTable()

        Try
            Using conn As New OleDbConnection(connString)
                conn.Open()

                ' Load Bookings Table
                Dim bookingsCmd As New OleDbCommand("SELECT * FROM Bookings", conn)
                Dim bookingsAdapter As New OleDbDataAdapter(bookingsCmd)
                bookingsAdapter.Fill(bookingsTable)

                ' Load Passengers Table
                Dim passengersCmd As New OleDbCommand("SELECT * FROM Passengers", conn)
                Dim passengersAdapter As New OleDbDataAdapter(passengersCmd)
                passengersAdapter.Fill(passengersTable)
            End Using

            ' Define columns for combined table
            combinedTable.Columns.Add("SN", GetType(Integer))
            combinedTable.Columns.Add("SeatNo")
            combinedTable.Columns.Add("BusNo")
            combinedTable.Columns.Add("TravelDate", GetType(Date))
            combinedTable.Columns.Add("FromLocation")
            combinedTable.Columns.Add("ToLocation")
            combinedTable.Columns.Add("Fare")
            combinedTable.Columns.Add("Username")
            combinedTable.Columns.Add("FirstName")
            combinedTable.Columns.Add("LastName")
            combinedTable.Columns.Add("Email")
            combinedTable.Columns.Add("Contact")
            combinedTable.Columns.Add("City")

            ' Combine rows
            Dim rowCount As Integer = Math.Min(bookingsTable.Rows.Count, passengersTable.Rows.Count)
            For i As Integer = 0 To rowCount - 1
                Dim bRow = bookingsTable.Rows(i)
                Dim pRow = passengersTable.Rows(i)

                combinedTable.Rows.Add(
                    i + 1, ' SN No
                    bRow("SeatNo").ToString(),
                    bRow("BusNo").ToString(),
                    Convert.ToDateTime(bRow("TravelDate")).Date,
                    bRow("FromLocation").ToString(),
                    bRow("ToLocation").ToString(),
                    bRow("Fare").ToString(),
                    bRow("Username").ToString(),
                    pRow("FirstName").ToString(),
                    pRow("LastName").ToString(),
                    pRow("Email").ToString(),
                    pRow("Contact").ToString(),
                    pRow("City").ToString()
                )
            Next

            ' Display in DataGridView
            DataGridView1.DataSource = combinedTable

            ' Format TravelDate
            If DataGridView1.Columns.Contains("TravelDate") Then
                DataGridView1.Columns("TravelDate").DefaultCellStyle.Format = "dd-MM-yyyy"
            End If

            ' Rename headers
            With DataGridView1
                .Columns("SN").HeaderText = "SN No"
                .Columns("SeatNo").HeaderText = "Seat No"
                .Columns("BusNo").HeaderText = "Bus Number"
                .Columns("TravelDate").HeaderText = "Travel Date"
                .Columns("FromLocation").HeaderText = "From"
                .Columns("ToLocation").HeaderText = "To"
                .Columns("Fare").HeaderText = "Fare"
                .Columns("Username").HeaderText = "Booked User Contact Number "
                .Columns("FirstName").HeaderText = " Passenger First Name"
                .Columns("LastName").HeaderText = "Passenger Last Name"
                .Columns("Email").HeaderText = " Passenger Email"
                .Columns("Contact").HeaderText = " Passenger Phone"
                .Columns("City").HeaderText = " Passenger  City"
            End With

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Form4.BringToFront()
        Form4.Activate()
        Me.Hide()
    End Sub
End Class
