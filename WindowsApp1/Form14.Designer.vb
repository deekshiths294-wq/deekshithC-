<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form14
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RowNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddPassengerDetails = New System.Windows.Forms.Button()
        Me.btnConfirmBooking = New System.Windows.Forms.Button()
        Me.grpCardDetails = New System.Windows.Forms.Panel()
        Me.btnGetOTP = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOTP = New System.Windows.Forms.TextBox()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMakePayment = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBank = New System.Windows.Forms.ComboBox()
        Me.txtCVV = New System.Windows.Forms.TextBox()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.cmbCard = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCardDetails.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNumber, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DataGridView1.Location = New System.Drawing.Point(26, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(837, 150)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 0
        '
        'RowNumber
        '
        Me.RowNumber.HeaderText = "Row Number"
        Me.RowNumber.MinimumWidth = 6
        Me.RowNumber.Name = "RowNumber"
        '
        'Column1
        '
        Me.Column1.HeaderText = "First Name"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Last Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Email"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Contact"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "City"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        '
        'btnAddPassengerDetails
        '
        Me.btnAddPassengerDetails.Location = New System.Drawing.Point(903, 130)
        Me.btnAddPassengerDetails.Name = "btnAddPassengerDetails"
        Me.btnAddPassengerDetails.Size = New System.Drawing.Size(249, 42)
        Me.btnAddPassengerDetails.TabIndex = 1
        Me.btnAddPassengerDetails.Text = "Add New PassengerDetails"
        Me.btnAddPassengerDetails.UseVisualStyleBackColor = True
        '
        'btnConfirmBooking
        '
        Me.btnConfirmBooking.Location = New System.Drawing.Point(68, 219)
        Me.btnConfirmBooking.Name = "btnConfirmBooking"
        Me.btnConfirmBooking.Size = New System.Drawing.Size(125, 52)
        Me.btnConfirmBooking.TabIndex = 2
        Me.btnConfirmBooking.Text = "Confirm Booking"
        Me.btnConfirmBooking.UseVisualStyleBackColor = True
        '
        'grpCardDetails
        '
        Me.grpCardDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.grpCardDetails.Controls.Add(Me.btnGetOTP)
        Me.grpCardDetails.Controls.Add(Me.Label7)
        Me.grpCardDetails.Controls.Add(Me.txtOTP)
        Me.grpCardDetails.Controls.Add(Me.txtMobile)
        Me.grpCardDetails.Controls.Add(Me.Label6)
        Me.grpCardDetails.Controls.Add(Me.btnMakePayment)
        Me.grpCardDetails.Controls.Add(Me.Label2)
        Me.grpCardDetails.Controls.Add(Me.Label3)
        Me.grpCardDetails.Controls.Add(Me.Label4)
        Me.grpCardDetails.Controls.Add(Me.Label5)
        Me.grpCardDetails.Controls.Add(Me.Label1)
        Me.grpCardDetails.Controls.Add(Me.cmbBank)
        Me.grpCardDetails.Controls.Add(Me.txtCVV)
        Me.grpCardDetails.Controls.Add(Me.txtCardNo)
        Me.grpCardDetails.Controls.Add(Me.cmbCard)
        Me.grpCardDetails.Location = New System.Drawing.Point(38, 334)
        Me.grpCardDetails.Name = "grpCardDetails"
        Me.grpCardDetails.Size = New System.Drawing.Size(1050, 334)
        Me.grpCardDetails.TabIndex = 3
        '
        'btnGetOTP
        '
        Me.btnGetOTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetOTP.Location = New System.Drawing.Point(341, 104)
        Me.btnGetOTP.Name = "btnGetOTP"
        Me.btnGetOTP.Size = New System.Drawing.Size(130, 35)
        Me.btnGetOTP.TabIndex = 13
        Me.btnGetOTP.Text = "Get OTP"
        Me.btnGetOTP.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(813, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Enter OTP "
        '
        'txtOTP
        '
        Me.txtOTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTP.Location = New System.Drawing.Point(817, 116)
        Me.txtOTP.Name = "txtOTP"
        Me.txtOTP.Size = New System.Drawing.Size(160, 30)
        Me.txtOTP.TabIndex = 11
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(26, 104)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(217, 30)
        Me.txtMobile.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(245, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Enter You Bank Reg Mobile No "
        '
        'btnMakePayment
        '
        Me.btnMakePayment.Location = New System.Drawing.Point(250, 242)
        Me.btnMakePayment.Name = "btnMakePayment"
        Me.btnMakePayment.Size = New System.Drawing.Size(167, 68)
        Me.btnMakePayment.TabIndex = 8
        Me.btnMakePayment.Text = "Make Payment "
        Me.btnMakePayment.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(538, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Card No "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(538, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "3 Digit CVV Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Select Card "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Card Details For Payment"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Select Bank"
        '
        'cmbBank
        '
        Me.cmbBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBank.FormattingEnabled = True
        Me.cmbBank.Location = New System.Drawing.Point(31, 281)
        Me.cmbBank.Name = "cmbBank"
        Me.cmbBank.Size = New System.Drawing.Size(182, 33)
        Me.cmbBank.TabIndex = 4
        '
        'txtCVV
        '
        Me.txtCVV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCVV.Location = New System.Drawing.Point(541, 78)
        Me.txtCVV.MaxLength = 3
        Me.txtCVV.Name = "txtCVV"
        Me.txtCVV.Size = New System.Drawing.Size(227, 30)
        Me.txtCVV.TabIndex = 5
        '
        'txtCardNo
        '
        Me.txtCardNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardNo.Location = New System.Drawing.Point(542, 159)
        Me.txtCardNo.MaxLength = 16
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(227, 30)
        Me.txtCardNo.TabIndex = 6
        '
        'cmbCard
        '
        Me.cmbCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCard.FormattingEnabled = True
        Me.cmbCard.Location = New System.Drawing.Point(26, 191)
        Me.cmbCard.Name = "cmbCard"
        Me.cmbCard.Size = New System.Drawing.Size(187, 33)
        Me.cmbCard.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(1209, 586)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 48)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Log Out "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Yellow
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnAddPassengerDetails)
        Me.Panel1.Controls.Add(Me.btnConfirmBooking)
        Me.Panel1.Location = New System.Drawing.Point(38, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1182, 292)
        Me.Panel1.TabIndex = 5
        '
        'Form14
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1676, 757)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpCardDetails)
        Me.Name = "Form14"
        Me.Text = "Form14"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCardDetails.ResumeLayout(False)
        Me.grpCardDetails.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RowNumber As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents btnAddPassengerDetails As Button
    Friend WithEvents btnConfirmBooking As Button
    Friend WithEvents grpCardDetails As Panel
    Friend WithEvents btnMakePayment As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBank As ComboBox
    Friend WithEvents txtCVV As TextBox
    Friend WithEvents txtCardNo As TextBox
    Friend WithEvents cmbCard As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtOTP As TextBox
    Friend WithEvents txtMobile As TextBox
    Friend WithEvents btnGetOTP As Button
End Class
