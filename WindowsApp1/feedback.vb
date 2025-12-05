Imports System.Data.OleDb

Public Class feedback

    ' === Database connection string ===
    Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb"

    ' === Form Load Event ===
    Private Sub feedback_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load combo box items only once
        If cmbEaseOfBooking.Items.Count = 0 Then
            cmbEaseOfBooking.Items.AddRange(New String() {"Very Easy", "Easy", "Average", "Difficult", "Very Difficult"})
        End If

        If cmbExperience.Items.Count = 0 Then
            cmbExperience.Items.AddRange(New String() {"Excellent", "Good", "Neutral", "Bad", "Very Bad"})
        End If

        If cmbResponsive.Items.Count = 0 Then
            cmbResponsive.Items.AddRange(New String() {"Very Responsive", "Responsive", "Neutral", "Unresponsive", "Very Unresponsive"})
        End If

        ResetFormFields()
    End Sub

    ' === Submit Feedback ===
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim mobile As String = txtContactNos.Text.Trim()
        Dim name As String = txtNames.Text.Trim()

        ' === Validations ===
        If name = "" Then
            MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If mobile = "" OrElse mobile.Length <> 10 OrElse Not IsNumeric(mobile) Then
            MessageBox.Show("Please enter a valid 10-digit mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                ' === Check if feedback already exists ===
                Dim checkQuery As String = "SELECT COUNT(*) FROM FeedbackDB WHERE ContactNo = ?"
                Using checkCmd As New OleDbCommand(checkQuery, conn)
                    checkCmd.Parameters.Add("ContactNo", OleDbType.VarChar).Value = mobile
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Feedback already submitted for this mobile number.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' === Insert new feedback ===
                Dim insertQuery As String = "INSERT INTO FeedbackDB (EaseOfBooking, Experience, Responsiveness, InfoFound, FeedbackText, SubmittedAt, Name, ContactNo) " &
                                            "VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
                Using cmd As New OleDbCommand(insertQuery, conn)
                    cmd.Parameters.Add("EaseOfBooking", OleDbType.VarChar).Value = cmbEaseOfBooking.Text
                    cmd.Parameters.Add("Experience", OleDbType.VarChar).Value = cmbExperience.Text
                    cmd.Parameters.Add("Responsiveness", OleDbType.VarChar).Value = cmbResponsive.Text
                    cmd.Parameters.Add("InfoFound", OleDbType.Integer).Value = CInt(numInfoFound.Value)
                    cmd.Parameters.Add("FeedbackText", OleDbType.VarChar).Value = txtFeedback.Text
                    cmd.Parameters.Add("SubmittedAt", OleDbType.Date).Value = DateTime.Now
                    cmd.Parameters.Add("Name", OleDbType.VarChar).Value = name
                    cmd.Parameters.Add("ContactNo", OleDbType.VarChar).Value = mobile
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetFormFields()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === Reset All Fields ===
    Private Sub ResetFormFields()
        cmbEaseOfBooking.SelectedIndex = 0
        cmbExperience.SelectedIndex = 0
        cmbResponsive.SelectedIndex = 0
        numInfoFound.Minimum = 0
        numInfoFound.Maximum = 10
        numInfoFound.Value = 5
        txtFeedback.Clear()
        txtNames.Clear()
        txtContactNos.Clear()
    End Sub

    ' === Logout Button Click ===
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to logout?",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
