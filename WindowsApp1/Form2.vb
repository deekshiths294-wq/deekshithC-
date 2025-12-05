Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class Form2
    ' Connection to MS Access database (.accdb)
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\deeks\OneDrive\Documents\Desktop\C#pro\UserDB.accdb;")
    Dim cmd As OleDbCommand

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            ' 1. Check required fields
            If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtMobile.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
                MessageBox.Show("Please fill all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 2. Validate names and city
            If Not Regex.IsMatch(txtFirstName.Text, "^[A-Za-z]+$") Then
                MessageBox.Show("Firstname must contain only alphabets.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Regex.IsMatch(txtLastName.Text, "^[A-Za-z]+$") Then
                MessageBox.Show("Lastname must contain only alphabets.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Regex.IsMatch(txtCity.Text, "^[A-Za-z\s]+$") Then
                MessageBox.Show("City must contain only alphabets.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 3. Validate mobile number (10 digits)
            If Not Regex.IsMatch(txtMobile.Text, "^\d{10}$") Then
                MessageBox.Show("Mobile number must be exactly 10 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 4. Validate email
            If Not txtEmail.Text.EndsWith("@gmail.com") Then
                MessageBox.Show("Email must end with @gmail.com", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 5. Validate pincode (6 digits)
            If Not Regex.IsMatch(txtPincode.Text, "^\d{6}$") Then
                MessageBox.Show("Pincode must be exactly 6 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 6. Password confirmation
            If txtPassword.Text <> txtConfirmPassword.Text Then
                MessageBox.Show("Password and Confirm Password do not match.", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            con.Open()

            ' 7. Check if user exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username"
            Dim checkCmd As New OleDbCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("@Username", Convert.ToInt64(txtMobile.Text))
            Dim exists As Integer = CInt(checkCmd.ExecuteScalar())
            If exists > 0 Then
                MessageBox.Show("This mobile number is already registered.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                con.Close()
                Exit Sub
            End If

            ' 8. Insert into database (ConfirmPassword not stored)
            Dim query As String = "INSERT INTO Users (Firstname, LastName, Username, [Password], Email, City, Address, Pincode) " &
                                  "VALUES (@Firstname, @LastName, @Username, @Password, @Email, @City, @Address, @Pincode)"
            cmd = New OleDbCommand(query, con)

            cmd.Parameters.AddWithValue("@Firstname", txtFirstName.Text)
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
            cmd.Parameters.AddWithValue("@Username", Convert.ToInt64(txtMobile.Text))
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@City", txtCity.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Pincode", txtPincode.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    ' Clear all fields
    Private Sub ClearForm()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtMobile.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        txtEmail.Clear()
        txtCity.Clear()
        txtAddress.Clear()
        txtPincode.Clear()
        txtFirstName.Focus()
    End Sub

    ' Show/Hide Password
    Private passwordShown As Boolean = False

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "•"c
        txtConfirmPassword.PasswordChar = "•"c
        btnTogglePassword.Text = "Show"
        passwordShown = False
    End Sub

    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        If passwordShown Then
            txtPassword.PasswordChar = "•"c
            txtConfirmPassword.PasswordChar = "•"c
            btnTogglePassword.Text = "Show"
            passwordShown = False
        Else
            txtPassword.PasswordChar = Nothing
            txtConfirmPassword.PasswordChar = Nothing
            btnTogglePassword.Text = "Hide"
            passwordShown = True
        End If
    End Sub

    ' Navigation button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Form1.BringToFront()
        Form1.Activate()
        Me.Hide()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Form10.Show()
        Form10.BringToFront()
        Form10.Activate()
        Me.Hide()
    End Sub

    ' =======================
    ' MOBILE TEXTBOX HANDLERS
    ' =======================

    ' Only allow 10 digits when typing
    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        If Not Char.IsDigit(e.KeyChar) OrElse txtMobile.TextLength >= 10 Then
            e.Handled = True
        End If
    End Sub

    ' Clean up pasted values or typing errors
    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        Dim digitsOnly As String = New String(txtMobile.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        If digitsOnly.Length > 10 Then
            digitsOnly = digitsOnly.Substring(0, 10)
        End If

        If txtMobile.Text <> digitsOnly Then
            Dim pos = txtMobile.SelectionStart
            txtMobile.Text = digitsOnly
            txtMobile.SelectionStart = Math.Min(pos, digitsOnly.Length)
        End If
    End Sub

End Class
