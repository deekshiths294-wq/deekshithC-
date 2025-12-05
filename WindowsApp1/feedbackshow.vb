Imports System.Data.OleDb

Public Class feedbackshow

    Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb"

    Private Sub feedbackshow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeedbackData()
    End Sub

    Private Sub LoadFeedbackData()
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()
                Dim query As String = "SELECT SubmittedAt, Name, ContactNo, EaseOfBooking, Experience, Responsiveness, InfoFound, FeedbackText FROM FeedbackDB ORDER BY SubmittedAt DESC"
                Dim adapter As New OleDbDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvFeedback.DataSource = dt
                dgvFeedback.AutoResizeColumns()
                dgvFeedback.ReadOnly = True  ' Prevent editing
                dgvFeedback.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading feedback data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadFeedbackData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Form4.BringToFront()
        Form4.Activate()
        Me.Hide()
    End Sub

End Class
