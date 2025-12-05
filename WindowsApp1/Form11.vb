Imports System.Data.OleDb

Public Class Form11

    ' Connection string to your Access DB
    Private ReadOnly conStr As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;"

    ' Add Username property to receive from login form (Form10)
    Public Property Username As String

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLocations()
        dtpTravelDate.MinDate = Date.Today
    End Sub

    ' Populate ComboBoxes with distinct Origin and Destination locations
    Private Sub LoadLocations()
        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                ' Load Origins
                Dim queryOrigin As String = "SELECT DISTINCT Origin FROM BusDetails ORDER BY Origin"
                Using cmdOrigin As New OleDbCommand(queryOrigin, con)
                    Using readerOrigin As OleDbDataReader = cmdOrigin.ExecuteReader()
                        cboFrom.Items.Clear()
                        While readerOrigin.Read()
                            cboFrom.Items.Add(readerOrigin("Origin").ToString())
                        End While
                    End Using
                End Using

                ' Load Destinations
                Dim queryDest As String = "SELECT DISTINCT Destination FROM BusDetails ORDER BY Destination"
                Using cmdDest As New OleDbCommand(queryDest, con)
                    Using readerDest As OleDbDataReader = cmdDest.ExecuteReader()
                        cboTo.Items.Clear()
                        While readerDest.Read()
                            cboTo.Items.Add(readerDest("Destination").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load locations: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Search Button Click event
    Private Sub btnSearchBus_Click(sender As Object, e As EventArgs) Handles btnSearchBus.Click
        If cboFrom.SelectedItem Is Nothing OrElse cboTo.SelectedItem Is Nothing Then
            MessageBox.Show("Please select both From and To locations.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Prevent selecting same locations for From and To
        If cboFrom.SelectedItem.ToString() = cboTo.SelectedItem.ToString() Then
            MessageBox.Show("Origin and Destination cannot be the same.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fromLoc As String = cboFrom.SelectedItem.ToString().Trim()
        Dim toLoc As String = cboTo.SelectedItem.ToString().Trim()
        Dim travelDate As Date = dtpTravelDate.Value.Date

        Try
            Using con As New OleDbConnection(conStr)
                con.Open()

                Dim query As String = "SELECT COUNT(*) FROM BusDetails WHERE Origin = ? AND Destination = ? AND AvailableDate = ?"
                Using cmd As New OleDbCommand(query, con)
                    cmd.Parameters.AddWithValue("?", fromLoc)
                    cmd.Parameters.AddWithValue("?", toLoc)
                    cmd.Parameters.AddWithValue("?", travelDate)

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        ' Open Form12 and pass parameters
                        Dim frm As New Form12 With {
                            .FromLocation = fromLoc,
                            .ToLocation = toLoc,
                            .TravelDate = travelDate,
                            .Username = Me.Username
                        }
                        frm.Show()
                        frm.BringToFront()
                        frm.Activate()

                        ' ✅ Clear form inputs before hiding
                        ResetSearchForm()

                        Me.Hide()
                    Else
                        MessageBox.Show("No buses found for selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Clears form fields
    Private Sub ResetSearchForm()
        cboFrom.SelectedIndex = -1
        cboTo.SelectedIndex = -1
        dtpTravelDate.Value = Date.Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form10.Show()
        Form10.BringToFront()
        Form10.Activate()
        Me.Hide()
    End Sub



End Class
