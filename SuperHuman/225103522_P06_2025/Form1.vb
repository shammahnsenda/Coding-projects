' ************************************************************************************************** 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522
'  Practical: P05 
'  Class: frmRobot
' ************************************************************************************************** 

Option Strict On
Option Explicit On
Option Infer Off
Public Class frmRobot
    Private recRobot() As Robot
    Private numAssembly, numMedical, numSecurity As Integer
    Private RobotAmount As Integer

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        For i As Integer = 1 To RobotAmount
            txtDisplay.Text &= recRobot(i).Display()
        Next
    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        Try
            numAssembly = CInt(txtAssembly.Text)
            numMedical = CInt(txtMedical.Text)
            numSecurity = CInt(txtSecurity.Text)
        Catch ex As FormatException
            MsgBox("Put numbers into the inputbox")
        End Try


        RobotAmount = numSecurity + numMedical + numAssembly
        ReDim recRobot(RobotAmount)

        For i As Integer = 1 To numAssembly
            Dim Assembly As AssemblyRobot

            Dim name As String = InputBox("Name of Robot?")
            Dim level As Integer = CInt(InputBox("Robots level?"))
            Dim Efficiency As Double = CDbl(InputBox("Robots efficiency?"))
            Dim Speed As Double = CDbl(InputBox("Robots speed?"))
            Dim Precision As Double = CDbl(InputBox("Robot precision?"))

            Assembly = New AssemblyRobot(name, level, Efficiency, Speed, Precision)
            recRobot(i) = Assembly
        Next

        For i As Integer = 1 To numSecurity
            Dim Security As SecurityRobot

            Dim name As String = InputBox("Name of Robot?")
            Dim level As Integer = CInt(InputBox("Robots level?"))
            Dim Attack As Integer = CInt(InputBox("Robots attack power?"))
            Dim Durability As Integer = CInt(InputBox("Robots durability?"))
            Dim Threat As Integer = CInt(InputBox("Robot threat level?"))

            Security = New SecurityRobot(name, level, Attack, Threat, Durability)
            recRobot(numAssembly + i) = Security
        Next

        For i As Integer = 1 To numMedical
            Dim Medical As MedicalRobot

            Dim name As String = InputBox("Name of Robot?")
            Dim level As Integer = CInt(InputBox("Robots level?"))
            Dim Heal As Integer = CInt(InputBox("Robots healing power?"))
            Dim Compassion As Integer = CInt(InputBox("Robots compassion?"))
            Dim Accuracy As Double = CDbl(InputBox("Robots accuracy?"))

            Medical = New MedicalRobot(name, level, Heal, Accuracy, Compassion)
            recRobot(numAssembly + numSecurity + i) = Medical
        Next

    End Sub
End Class
