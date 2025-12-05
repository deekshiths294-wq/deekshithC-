<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class feedbackshow
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
        Me.dgvFeedback = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvFeedback, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFeedback
        '
        Me.dgvFeedback.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFeedback.Location = New System.Drawing.Point(230, 90)
        Me.dgvFeedback.Name = "dgvFeedback"
        Me.dgvFeedback.RowHeadersWidth = 51
        Me.dgvFeedback.RowTemplate.Height = 24
        Me.dgvFeedback.Size = New System.Drawing.Size(1152, 236)
        Me.dgvFeedback.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(629, 387)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(97, 49)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refres "
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(840, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 49)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(698, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Feed Back "
        '
        'feedbackshow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Yellow
        Me.ClientSize = New System.Drawing.Size(1607, 568)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dgvFeedback)
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Name = "feedbackshow"
        Me.Text = "feedbackshow"
        CType(Me.dgvFeedback, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvFeedback As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
