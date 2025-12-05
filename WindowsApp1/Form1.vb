Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Text = "Online Bus Booking System"
            Me.BackColor = Color.White
            Me.Size = New Size(500, 600)
            Me.StartPosition = FormStartPosition.CenterScreen

            ' Title Label
            Dim lblTitle As New Label()
            lblTitle.Text = "Online Bus" & vbCrLf & "Booking System"
            lblTitle.Font = New Font("Arial", 22, FontStyle.Bold)
            lblTitle.ForeColor = Color.Black
            lblTitle.AutoSize = False
            lblTitle.TextAlign = ContentAlignment.MiddleCenter
            lblTitle.Dock = DockStyle.Top
            lblTitle.Height = 120
            Me.Controls.Add(lblTitle)

            ' Admin Login Button
            Dim btnAdmin As New Button()
            btnAdmin.Text = "Admin Login"
            btnAdmin.Size = New Size(200, 50)
            btnAdmin.Location = New Point(150, 180)
            AddHandler btnAdmin.Click, AddressOf BtnAdmin_Click
            Me.Controls.Add(btnAdmin)

            ' User Registration Button
            Dim btnRegister As New Button()
            btnRegister.Text = "User Registration"
            btnRegister.Size = New Size(200, 50)
            btnRegister.Location = New Point(150, 250)
            AddHandler btnRegister.Click, AddressOf BtnRegister_Click
            Me.Controls.Add(btnRegister)

            ' User Login Button
            Dim btnUser As New Button()
            btnUser.Text = "User Login"
            btnUser.Size = New Size(200, 50)
            btnUser.Location = New Point(150, 320)
            AddHandler btnUser.Click, AddressOf BtnUser_Click
            Me.Controls.Add(btnUser)

            ' Search Bus Button
            Dim btnSearch As New Button()
            btnSearch.Text = "Search Bus"
            btnSearch.Size = New Size(200, 50)
            btnSearch.Location = New Point(150, 390)
            AddHandler btnSearch.Click, AddressOf BtnSearch_Click
            Me.Controls.Add(btnSearch)
        End Sub

        ' Admin Login Button Click
        Private Sub BtnAdmin_Click(sender As Object, e As EventArgs)
        Form5.Show()
        Form5.BringToFront()
        Form5.Activate()

        Me.Hide()
    End Sub

        ' User Registration Button Click → Open Form2
        Private Sub BtnRegister_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Form2.BringToFront()
        Form2.Activate()

        Me.Hide()
    End Sub

        ' User Login Button Click → Open Form3
        Private Sub BtnUser_Click(sender As Object, e As EventArgs)
        Form10.Show()
        Form10.BringToFront()
        Form10.Activate()

        Me.Hide()

    End Sub

        ' Search Bus Button Click
        Private Sub BtnSearch_Click(sender As Object, e As EventArgs)
        Form7.Show()
        Form7.BringToFront()
        Form7.Activate()

        Me.Hide()
    End Sub
    End Class

