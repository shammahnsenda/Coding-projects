<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRobot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.txtDisplay = New System.Windows.Forms.TextBox()
        Me.txtAssembly = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSecurity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMedical = New System.Windows.Forms.TextBox()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInfo
        '
        Me.btnInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnInfo.Location = New System.Drawing.Point(247, 230)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(180, 68)
        Me.btnInfo.TabIndex = 0
        Me.btnInfo.Text = "Insert Info"
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(482, 83)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(536, 525)
        Me.txtDisplay.TabIndex = 1
        '
        'txtAssembly
        '
        Me.txtAssembly.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssembly.Location = New System.Drawing.Point(12, 40)
        Me.txtAssembly.Name = "txtAssembly"
        Me.txtAssembly.Size = New System.Drawing.Size(100, 34)
        Me.txtAssembly.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(270, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Assembly robot amount:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 29)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Security robot amount:"
        '
        'txtSecurity
        '
        Me.txtSecurity.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecurity.Location = New System.Drawing.Point(12, 181)
        Me.txtSecurity.Name = "txtSecurity"
        Me.txtSecurity.Size = New System.Drawing.Size(100, 34)
        Me.txtSecurity.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(262, 29)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Medical Robot Amount:"
        '
        'txtMedical
        '
        Me.txtMedical.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedical.Location = New System.Drawing.Point(12, 109)
        Me.txtMedical.Name = "txtMedical"
        Me.txtMedical.Size = New System.Drawing.Size(100, 34)
        Me.txtMedical.TabIndex = 6
        '
        'btnDisplay
        '
        Me.btnDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnDisplay.Location = New System.Drawing.Point(247, 342)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(180, 68)
        Me.btnDisplay.TabIndex = 8
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'frmRobot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 666)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMedical)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSecurity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAssembly)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.btnInfo)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRobot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInfo As Button
    Friend WithEvents txtDisplay As TextBox
    Friend WithEvents txtAssembly As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSecurity As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMedical As TextBox
    Friend WithEvents btnDisplay As Button
End Class
