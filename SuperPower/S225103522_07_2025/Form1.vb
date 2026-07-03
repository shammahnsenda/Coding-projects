'********************************************************************************************* 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522 
'  Practical: P07 
'*********************************************************************************************

Option Strict On
Option Explicit On
Option Infer Off

Public Class frmHero
    'global variables
    Private NumHeroes As Integer
    Private Heroes() As Hero

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        'get user input
        NumHeroes = CInt(InputBox("Enter number of heroes"))

        'resize arrays
        ReDim Heroes(NumHeroes)

        For h As Integer = 1 To NumHeroes
            Dim hero As Hero
            'getting user input
            Dim choice As Integer = CInt(InputBox("1-Wizard  2-Tank"))
            Dim name As String = InputBox("Name of hero?")
            Dim basedamage As Integer = CInt(InputBox("Base damage for hero?"))
            Dim experience As Integer = CInt(InputBox("Experience value for hero?"))
            Select Case choice
                Case 1
                    Dim MaxMP As Integer = CInt(InputBox("Max magic points for hero?"))
                    'instantiating
                    Heroes(h) = New Wizard(name, basedamage, experience, MaxMP)
                    'upcasting
                    hero = Heroes(h)
                Case 2
                    Dim armour As Integer = CInt(InputBox("Armour value of hero?"))
                    'instantiating
                    Heroes(h) = New Tank(name, basedamage, experience, armour)
                    'upcasting
                    hero = Heroes(h)
            End Select
        Next h
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        For h As Integer = 1 To NumHeroes
            'polymorphism: display details
            txtDisplay.Text += Heroes(h).Display() & vbNewLine
        Next h
    End Sub

    Private Sub btnBattle_Click(sender As Object, e As EventArgs) Handles btnBattle.Click
        'getting user input
        Dim choice1 As String = InputBox("Enter the name of hero 1")
        Dim choice2 As String = InputBox("Enter the name of hero 2")
        For h As Integer = 1 To NumHeroes
            'finding hero type
            If Heroes(h).Name = choice1 Or Heroes(h).Name = choice2 Then
                Dim wizard As Wizard
                'downcasting
                wizard = TryCast(Heroes(h), Wizard)
                If wizard Is Nothing Then
                    Dim tank As Tank
                    'downcasting
                    tank = TryCast(Heroes(h), Tank)
                End If
            End If
        Next h
        MsgBox("Heroes chosen!")
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click

    End Sub

    Private Sub btnTank_Click(sender As Object, e As EventArgs) Handles btnTank.Click

    End Sub
End Class
