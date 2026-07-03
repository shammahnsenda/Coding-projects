<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHero
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
        Me.btnTank = New System.Windows.Forms.Button()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.btnBattle = New System.Windows.Forms.Button()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.txtDisplay = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnTank
        '
        Me.btnTank.Location = New System.Drawing.Point(153, 435)
        Me.btnTank.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTank.Name = "btnTank"
        Me.btnTank.Size = New System.Drawing.Size(273, 57)
        Me.btnTank.TabIndex = 11
        Me.btnTank.Text = "Highest tank level"
        Me.btnTank.UseVisualStyleBackColor = True
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(153, 374)
        Me.btnFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(273, 57)
        Me.btnFile.TabIndex = 10
        Me.btnFile.Text = "Save to file"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'btnBattle
        '
        Me.btnBattle.Location = New System.Drawing.Point(153, 312)
        Me.btnBattle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBattle.Name = "btnBattle"
        Me.btnBattle.Size = New System.Drawing.Size(273, 57)
        Me.btnBattle.TabIndex = 9
        Me.btnBattle.Text = "Simulate battle"
        Me.btnBattle.UseVisualStyleBackColor = True
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(153, 250)
        Me.btnDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(273, 57)
        Me.btnDisplay.TabIndex = 8
        Me.btnDisplay.Text = "Display info"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(153, 189)
        Me.btnInput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(273, 57)
        Me.btnInput.TabIndex = 7
        Me.btnInput.Text = "Input"
        Me.btnInput.UseVisualStyleBackColor = True
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(511, 138)
        Me.txtDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(470, 414)
        Me.txtDisplay.TabIndex = 6
        '
        'frmHero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 691)
        Me.Controls.Add(Me.btnTank)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.btnBattle)
        Me.Controls.Add(Me.btnDisplay)
        Me.Controls.Add(Me.btnInput)
        Me.Controls.Add(Me.txtDisplay)
        Me.Name = "frmHero"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnTank As Button
    Friend WithEvents btnFile As Button
    Friend WithEvents btnBattle As Button
    Friend WithEvents btnDisplay As Button
    Friend WithEvents btnInput As Button
    Friend WithEvents txtDisplay As TextBox
End Class
