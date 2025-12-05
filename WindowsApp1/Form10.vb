Imports System.Data.OleDb

Public Class Form10

    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb")

    Private passwordShown As Boolean = False

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ResetLoginForm()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Try
            Dim username As String = txtUsername.Text.Trim()
            Dim password As String = txtPassword.Text.Trim()

            If username = "" Or password = "" Then
                MessageBox.Show("Please enter both Username and Password!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            con.Open()

            Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND [Password]=@Password"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)

            Dim count As Integer = CInt(cmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Pass username to next form
                Form11.Username = username
                Form11.Show()



                ' Clear login form so it doesn’t retain data
                ResetLoginForm()

                Me.Hide()
            Else
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub BtnTogglePassword_Click(sender As Object, e As EventArgs) Handles BtnTogglePassword.Click
        If passwordShown Then
            txtPassword.PasswordChar = "•"c
            BtnTogglePassword.Text = "Show"
            passwordShown = False
        Else
            txtPassword.PasswordChar = Nothing
            BtnTogglePassword.Text = "Hide"
            passwordShown = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Form2.BringToFront()
        Form2.Activate()
        Me.Hide()
    End Sub

    Public Sub ResetLoginForm()
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
        txtPassword.PasswordChar = "•"c
        BtnTogglePassword.Text = "Show"
        passwordShown = False
    End Sub

    ' ======== ADDED BELOW THIS LINE ========

    ' Only allow digits and max 10 characters
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        If Not Char.IsDigit(e.KeyChar) OrElse txtUsername.TextLength >= 10 Then
            e.Handled = True
        End If
    End Sub

    ' Clean up pasted text or invalid entries
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        Dim digitsOnly As String = New String(txtUsername.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        If digitsOnly.Length > 10 Then
            digitsOnly = digitsOnly.Substring(0, 10)
        End If

        If txtUsername.Text <> digitsOnly Then
            Dim cursorPos = txtUsername.SelectionStart
            txtUsername.Text = digitsOnly
            txtUsername.SelectionStart = Math.Min(cursorPos, digitsOnly.Length)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Form1.BringToFront()
        Form1.Activate()

        Me.Hide()

    End Sub
End Class
