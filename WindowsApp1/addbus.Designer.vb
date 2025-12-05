<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addbus
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBusName = New System.Windows.Forms.TextBox()
        Me.txtOrigin = New System.Windows.Forms.TextBox()
        Me.txtSeatRows = New System.Windows.Forms.TextBox()
        Me.txtBusNo = New System.Windows.Forms.TextBox()
        Me.txtSeatCols = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.cboBusType = New System.Windows.Forms.ComboBox()
        Me.btnViewAll = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpAvailable = New System.Windows.Forms.DateTimePicker()
        Me.dtpArrival = New System.Windows.Forms.DateTimePicker()
        Me.dtpDeparture = New System.Windows.Forms.DateTimePicker()
        Me.txtFare = New System.Windows.Forms.TextBox()
        Me.dtpTravelTime = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(748, 283)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Destination"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(748, 189)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Seats  Column"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(748, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bus Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 85)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Bus No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 189)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = " No Of Seats Rows"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 274)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 22)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Origin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(40, 360)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 22)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Busname"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Yellow
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label8.Location = New System.Drawing.Point(381, 18)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(231, 32)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Add Bus Details"
        '
        'txtBusName
        '
        Me.txtBusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusName.Location = New System.Drawing.Point(44, 405)
        Me.txtBusName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBusName.Name = "txtBusName"
        Me.txtBusName.Size = New System.Drawing.Size(124, 30)
        Me.txtBusName.TabIndex = 9
        '
        'txtOrigin
        '
        Me.txtOrigin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigin.Location = New System.Drawing.Point(44, 309)
        Me.txtOrigin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOrigin.Name = "txtOrigin"
        Me.txtOrigin.Size = New System.Drawing.Size(124, 30)
        Me.txtOrigin.TabIndex = 10
        '
        'txtSeatRows
        '
        Me.txtSeatRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeatRows.Location = New System.Drawing.Point(44, 227)
        Me.txtSeatRows.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSeatRows.Name = "txtSeatRows"
        Me.txtSeatRows.Size = New System.Drawing.Size(124, 30)
        Me.txtSeatRows.TabIndex = 11
        '
        'txtBusNo
        '
        Me.txtBusNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusNo.Location = New System.Drawing.Point(44, 140)
        Me.txtBusNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBusNo.Name = "txtBusNo"
        Me.txtBusNo.Size = New System.Drawing.Size(124, 30)
        Me.txtBusNo.TabIndex = 12
        '
        'txtSeatCols
        '
        Me.txtSeatCols.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeatCols.Location = New System.Drawing.Point(752, 227)
        Me.txtSeatCols.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSeatCols.Name = "txtSeatCols"
        Me.txtSeatCols.Size = New System.Drawing.Size(124, 30)
        Me.txtSeatCols.TabIndex = 14
        '
        'txtDestination
        '
        Me.txtDestination.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestination.Location = New System.Drawing.Point(752, 331)
        Me.txtDestination.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(148, 30)
        Me.txtDestination.TabIndex = 15
        '
        'btnInsert
        '
        Me.btnInsert.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnInsert.Location = New System.Drawing.Point(332, 469)
        Me.btnInsert.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(94, 32)
        Me.btnInsert.TabIndex = 16
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'cboBusType
        '
        Me.cboBusType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBusType.FormattingEnabled = True
        Me.cboBusType.Location = New System.Drawing.Point(752, 138)
        Me.cboBusType.Name = "cboBusType"
        Me.cboBusType.Size = New System.Drawing.Size(121, 33)
        Me.cboBusType.TabIndex = 18
        '
        'btnViewAll
        '
        Me.btnViewAll.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnViewAll.Location = New System.Drawing.Point(479, 469)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(91, 32)
        Me.btnViewAll.TabIndex = 19
        Me.btnViewAll.Text = "View"
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Button1.Location = New System.Drawing.Point(596, 469)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 32)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(45, 610)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 22)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Total Travel Time"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(748, 453)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 22)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = " Arrival"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(748, 383)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 22)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = " Fare"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(44, 531)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(135, 22)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Departure Time"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 453)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 22)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Available Date"
        '
        'dtpAvailable
        '
        Me.dtpAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAvailable.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAvailable.Location = New System.Drawing.Point(48, 490)
        Me.dtpAvailable.MinDate = New Date(2025, 8, 27, 0, 0, 0, 0)
        Me.dtpAvailable.Name = "dtpAvailable"
        Me.dtpAvailable.Size = New System.Drawing.Size(200, 30)
        Me.dtpAvailable.TabIndex = 27
        '
        'dtpArrival
        '
        Me.dtpArrival.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArrival.Location = New System.Drawing.Point(752, 490)
        Me.dtpArrival.Name = "dtpArrival"
        Me.dtpArrival.Size = New System.Drawing.Size(200, 30)
        Me.dtpArrival.TabIndex = 28
        '
        'dtpDeparture
        '
        Me.dtpDeparture.CustomFormat = """HH:mm"""
        Me.dtpDeparture.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeparture.Location = New System.Drawing.Point(44, 565)
        Me.dtpDeparture.Name = "dtpDeparture"
        Me.dtpDeparture.Size = New System.Drawing.Size(200, 30)
        Me.dtpDeparture.TabIndex = 29
        '
        'txtFare
        '
        Me.txtFare.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFare.Location = New System.Drawing.Point(752, 408)
        Me.txtFare.Name = "txtFare"
        Me.txtFare.Size = New System.Drawing.Size(100, 30)
        Me.txtFare.TabIndex = 30
        '
        'dtpTravelTime
        '
        Me.dtpTravelTime.CustomFormat = "HH:mm"
        Me.dtpTravelTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTravelTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTravelTime.Location = New System.Drawing.Point(49, 652)
        Me.dtpTravelTime.Name = "dtpTravelTime"
        Me.dtpTravelTime.ShowUpDown = True
        Me.dtpTravelTime.Size = New System.Drawing.Size(200, 30)
        Me.dtpTravelTime.TabIndex = 31
        '
        'addbus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cyan
        Me.ClientSize = New System.Drawing.Size(1067, 712)
        Me.Controls.Add(Me.dtpTravelTime)
        Me.Controls.Add(Me.txtFare)
        Me.Controls.Add(Me.dtpDeparture)
        Me.Controls.Add(Me.dtpArrival)
        Me.Controls.Add(Me.dtpAvailable)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnViewAll)
        Me.Controls.Add(Me.cboBusType)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.txtSeatCols)
        Me.Controls.Add(Me.txtBusNo)
        Me.Controls.Add(Me.txtSeatRows)
        Me.Controls.Add(Me.txtOrigin)
        Me.Controls.Add(Me.txtBusName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "addbus"
        Me.Text = "addbus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBusName As TextBox
    Friend WithEvents txtOrigin As TextBox
    Friend WithEvents txtSeatRows As TextBox
    Friend WithEvents txtBusNo As TextBox
    Friend WithEvents txtSeatCols As TextBox
    Friend WithEvents txtDestination As TextBox
    Friend WithEvents btnInsert As Button
    Friend WithEvents cboBusType As ComboBox
    Friend WithEvents btnViewAll As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpAvailable As DateTimePicker
    Friend WithEvents dtpArrival As DateTimePicker
    Friend WithEvents dtpDeparture As DateTimePicker
    Friend WithEvents txtFare As TextBox
    Friend WithEvents dtpTravelTime As DateTimePicker
End Class
