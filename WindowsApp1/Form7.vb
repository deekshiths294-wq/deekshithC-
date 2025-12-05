Imports System.Data.OleDb

Public Class Form7

    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    ' === Load Form ===
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvBuses.DataSource = Nothing
        dgvBuses.ReadOnly = True
        dgvBuses.AllowUserToAddRows = False
        dgvBuses.AllowUserToDeleteRows = False
        dgvBuses.AllowUserToResizeRows = False
        dgvBuses.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuses.MultiSelect = False
        dgvBuses.EditMode = DataGridViewEditMode.EditProgrammatically

        LoadOriginsAndDestinations()
        dtpTravelDate.Value = Date.Today
    End Sub

    ' === Load Origin & Destination dropdowns ===


    Private Sub LoadOriginsAndDestinations()
        cboFrom.Items.Clear()
        cboTo.Items.Clear()

        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                Using cmd As New OleDbCommand("SELECT DISTINCT Origin FROM BusDetails", con)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboFrom.Items.Add(reader("Origin").ToString())
                        End While
                    End Using
                End Using

                Using cmd As New OleDbCommand("SELECT DISTINCT Destination FROM BusDetails", con)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboTo.Items.Add(reader("Destination").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading combo box data: " & ex.Message)
        End Try
    End Sub

    ' === Search Button Click ===
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim origin As String = cboFrom.Text.Trim()
        Dim destination As String = cboTo.Text.Trim()
        Dim travelDate As Date = dtpTravelDate.Value.Date

        If origin = "" OrElse destination = "" Then
            MessageBox.Show("Please select both Origin and Destination.")
            Return
        End If

        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                Dim query As String =
                    "SELECT B.BusNo, " &
                    "B.BusName, " &
                    "B.ArrivalDate AS [Arrival Time], " &
                    "B.DepartureTime AS [Departure Time], " &
                    "((B.SeatRows * B.SeatCols) - " &
                    "(SELECT COUNT(*) FROM Bookings BK WHERE BK.BusNo = B.BusNo AND BK.TravelDate = ?)) AS [Available Seats], " &
                    "B.Fare " &
                    "FROM BusDetails B " &
                    "WHERE B.Origin = ? AND B.Destination = ? AND B.AvailableDate = ?"

                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", travelDate)
                    cmd.Parameters.AddWithValue("?", origin)
                    cmd.Parameters.AddWithValue("?", destination)
                    cmd.Parameters.AddWithValue("?", travelDate)

                    Dim dt As New DataTable()
                    Using adapter As New OleDbDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Bus not found.")
                        dgvBuses.DataSource = Nothing
                    Else
                        dgvBuses.DataSource = dt

                        If dgvBuses.Columns.Contains("Fare") Then
                            dgvBuses.Columns("Fare").DefaultCellStyle.Format = "C2"
                        End If
                        If dgvBuses.Columns.Contains("Arrival Time") Then
                            dgvBuses.Columns("Arrival Time").DefaultCellStyle.Format = "HH:mm"
                        End If
                        If dgvBuses.Columns.Contains("Departure Time") Then
                            dgvBuses.Columns("Departure Time").DefaultCellStyle.Format = "HH:mm"
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching buses: " & ex.Message)
        End Try
    End Sub

    ' === Back Button ===
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Form1.Show()
        Form1.BringToFront()
        Form1.Activate()
        Me.Hide()
    End Sub



End Class

