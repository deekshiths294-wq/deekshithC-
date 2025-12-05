Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form5

    ' Define the database connection
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Trim input values
        Dim username As String = txtName.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validate input - do NOT clear fields if empty, just warn
        If username = "" Or password = "" Then
            MessageBox.Show("Please enter both username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Open connection if closed
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            ' Prepare SQL query
            cmd = New OleDbCommand("SELECT apassword FROM Admin WHERE aName = @aName", con)
            cmd.Parameters.AddWithValue("@aName", username)

            ' Execute query
            dr = cmd.ExecuteReader()

            ' Check if username exists
            If dr.Read() Then
                Dim dbPassword As String = dr("apassword").ToString()

                ' Compare passwords
                If dbPassword = password Then
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Open Admin Dashboard (Form4)
                    Me.Hide()
                    Form4.ShowDialog()
                    Me.Close()
                Else
                    ' Incorrect password: clear fields
                    MessageBox.Show("Incorrect password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClearInputFields()
                End If
            Else
                ' Username not found: clear fields
                MessageBox.Show("Username not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ClearInputFields()
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' Clean up
            If dr IsNot Nothing Then dr.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    ' Helper method to clear username and password textboxes
    Private Sub ClearInputFields()
        txtName.Clear()
        txtPassword.Clear()
        txtName.Focus()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: Add any logic on form load
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Form1.Show()
        Form1.BringToFront()
        Form1.Activate()

        Me.Hide()


    End Sub


End Class
