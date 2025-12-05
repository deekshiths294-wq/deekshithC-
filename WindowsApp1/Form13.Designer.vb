<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form13
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
        Me.PanelSeats = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblFareList = New System.Windows.Forms.Label()
        Me.lblSelectedSeats = New System.Windows.Forms.Label()
        Me.btnBook = New System.Windows.Forms.Button()
        Me.pnlJourneyDetails = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTravelDate = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalFare = New System.Windows.Forms.TextBox()
        Me.txtFarePerSeat = New System.Windows.Forms.TextBox()
        Me.txtSelectedSeats = New System.Windows.Forms.TextBox()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAvailable = New System.Windows.Forms.Panel()
        Me.pnlBooked = New System.Windows.Forms.Panel()
        Me.pnlSelected = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlJourneyDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSeats
        '
        Me.PanelSeats.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PanelSeats.Location = New System.Drawing.Point(50, 50)
        Me.PanelSeats.Name = "PanelSeats"
        Me.PanelSeats.Size = New System.Drawing.Size(344, 299)
        Me.PanelSeats.TabIndex = 0
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(3, 54)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(170, 20)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "Journey Details From"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.Location = New System.Drawing.Point(3, 197)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(75, 20)
        Me.lblTotalAmount.TabIndex = 2
        Me.lblTotalAmount.Text = "total fare"
        '
        'lblFareList
        '
        Me.lblFareList.AutoSize = True
        Me.lblFareList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFareList.Location = New System.Drawing.Point(3, 158)
        Me.lblFareList.Name = "lblFareList"
        Me.lblFareList.Size = New System.Drawing.Size(104, 20)
        Me.lblFareList.TabIndex = 3
        Me.lblFareList.Text = "fare per seat"
        '
        'lblSelectedSeats
        '
        Me.lblSelectedSeats.AutoSize = True
        Me.lblSelectedSeats.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedSeats.Location = New System.Drawing.Point(3, 105)
        Me.lblSelectedSeats.Name = "lblSelectedSeats"
        Me.lblSelectedSeats.Size = New System.Drawing.Size(179, 20)
        Me.lblSelectedSeats.TabIndex = 4
        Me.lblSelectedSeats.Text = "selected seat numbers"
        '
        'btnBook
        '
        Me.btnBook.Location = New System.Drawing.Point(259, 307)
        Me.btnBook.Name = "btnBook"
        Me.btnBook.Size = New System.Drawing.Size(90, 32)
        Me.btnBook.TabIndex = 5
        Me.btnBook.Text = "Confirm "
        Me.btnBook.UseVisualStyleBackColor = True
        '
        'pnlJourneyDetails
        '
        Me.pnlJourneyDetails.BackColor = System.Drawing.Color.Teal
        Me.pnlJourneyDetails.Controls.Add(Me.Label6)
        Me.pnlJourneyDetails.Controls.Add(Me.txtTravelDate)
        Me.pnlJourneyDetails.Controls.Add(Me.txtTo)
        Me.pnlJourneyDetails.Controls.Add(Me.Label2)
        Me.pnlJourneyDetails.Controls.Add(Me.txtTotalFare)
        Me.pnlJourneyDetails.Controls.Add(Me.txtFarePerSeat)
        Me.pnlJourneyDetails.Controls.Add(Me.txtSelectedSeats)
        Me.pnlJourneyDetails.Controls.Add(Me.txtFrom)
        Me.pnlJourneyDetails.Controls.Add(Me.Label1)
        Me.pnlJourneyDetails.Controls.Add(Me.btnBook)
        Me.pnlJourneyDetails.Controls.Add(Me.LabelTitle)
        Me.pnlJourneyDetails.Controls.Add(Me.lblTotalAmount)
        Me.pnlJourneyDetails.Controls.Add(Me.lblFareList)
        Me.pnlJourneyDetails.Controls.Add(Me.lblSelectedSeats)
        Me.pnlJourneyDetails.Location = New System.Drawing.Point(639, 65)
        Me.pnlJourneyDetails.Name = "pnlJourneyDetails"
        Me.pnlJourneyDetails.Size = New System.Drawing.Size(635, 357)
        Me.pnlJourneyDetails.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Date"
        '
        'txtTravelDate
        '
        Me.txtTravelDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTravelDate.Location = New System.Drawing.Point(259, 254)
        Me.txtTravelDate.Name = "txtTravelDate"
        Me.txtTravelDate.Size = New System.Drawing.Size(173, 30)
        Me.txtTravelDate.TabIndex = 13
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.Location = New System.Drawing.Point(519, 51)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(100, 30)
        Me.txtTo.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(438, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "TO"
        '
        'txtTotalFare
        '
        Me.txtTotalFare.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFare.Location = New System.Drawing.Point(259, 197)
        Me.txtTotalFare.Name = "txtTotalFare"
        Me.txtTotalFare.Size = New System.Drawing.Size(100, 30)
        Me.txtTotalFare.TabIndex = 10
        '
        'txtFarePerSeat
        '
        Me.txtFarePerSeat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFarePerSeat.Location = New System.Drawing.Point(259, 158)
        Me.txtFarePerSeat.Name = "txtFarePerSeat"
        Me.txtFarePerSeat.Size = New System.Drawing.Size(100, 30)
        Me.txtFarePerSeat.TabIndex = 9
        '
        'txtSelectedSeats
        '
        Me.txtSelectedSeats.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedSeats.Location = New System.Drawing.Point(259, 105)
        Me.txtSelectedSeats.Name = "txtSelectedSeats"
        Me.txtSelectedSeats.Size = New System.Drawing.Size(130, 30)
        Me.txtSelectedSeats.TabIndex = 8
        '
        'txtFrom
        '
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(302, 51)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(130, 30)
        Me.txtFrom.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Journey Details"
        '
        'pnlAvailable
        '
        Me.pnlAvailable.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.pnlAvailable.Location = New System.Drawing.Point(67, 397)
        Me.pnlAvailable.Name = "pnlAvailable"
        Me.pnlAvailable.Size = New System.Drawing.Size(25, 25)
        Me.pnlAvailable.TabIndex = 7
        '
        'pnlBooked
        '
        Me.pnlBooked.BackColor = System.Drawing.Color.Red
        Me.pnlBooked.Location = New System.Drawing.Point(180, 397)
        Me.pnlBooked.Name = "pnlBooked"
        Me.pnlBooked.Size = New System.Drawing.Size(25, 25)
        Me.pnlBooked.TabIndex = 8
        '
        'pnlSelected
        '
        Me.pnlSelected.BackColor = System.Drawing.SystemColors.ControlText
        Me.pnlSelected.Location = New System.Drawing.Point(330, 397)
        Me.pnlSelected.Name = "pnlSelected"
        Me.pnlSelected.Size = New System.Drawing.Size(25, 25)
        Me.pnlSelected.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 446)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Booked Seat"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(302, 446)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Selected Seat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 446)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Available Seat"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1175, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 51)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Log Out "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1369, 548)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlSelected)
        Me.Controls.Add(Me.pnlBooked)
        Me.Controls.Add(Me.pnlAvailable)
        Me.Controls.Add(Me.pnlJourneyDetails)
        Me.Controls.Add(Me.PanelSeats)
        Me.Name = "Form13"
        Me.Text = "Form13"
        Me.pnlJourneyDetails.ResumeLayout(False)
        Me.pnlJourneyDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelSeats As FlowLayoutPanel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblFareList As Label
    Friend WithEvents lblSelectedSeats As Label
    Friend WithEvents btnBook As Button
    Friend WithEvents pnlJourneyDetails As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFrom As TextBox
    Friend WithEvents txtTotalFare As TextBox
    Friend WithEvents txtFarePerSeat As TextBox
    Friend WithEvents txtSelectedSeats As TextBox
    Friend WithEvents pnlAvailable As Panel
    Friend WithEvents pnlBooked As Panel
    Friend WithEvents pnlSelected As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTravelDate As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
End Class
