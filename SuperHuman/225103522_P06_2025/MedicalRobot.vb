' ************************************************************************************************** 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522
'  Practical: P05 
'  Class: MedicalRobot
' ************************************************************************************************** 

Option Strict On
Option Explicit On
Option Infer Off

Public Class MedicalRobot
    Inherits Robot

    Private _healingpower As Integer
    Private _accuracy As Double
    Private _compassion As Integer

    Public Sub New(_name As String, _level As Integer, _HealingPower As Integer, _Accuracy As Double, _Compassion As Integer)
        MyBase.New(_name, _level)

        Me._healingpower = _HealingPower
        Me._accuracy = _Accuracy
        Me._compassion = _Compassion
    End Sub

    Private Function Heal() As Double
        Return _accuracy * _healingpower
    End Function

    Private Function Defend() As Integer
        Return _compassion * _level
    End Function

    Public Property HealinPower() As Integer
        Get
            Return _healingpower
        End Get
        Set(value As Integer)
            _healingpower = Validation(value)
        End Set
    End Property

    Public Property Accuracy() As Double
        Get
            Return _accuracy
        End Get
        Set(value As Double)
            _accuracy = Validation(value)
        End Set
    End Property

    Public Property Compassion() As Integer
        Get
            Return _compassion
        End Get
        Set(value As Integer)
            _compassion = Validation(value)
        End Set
    End Property

    Public Overrides Function Display() As String
        Dim out As String
        out = "<<Security Robot>>" & vbNewLine
        out += MyBase.Display()
        out += "Attack: " & CStr(Heal()) & vbNewLine
        out += "Defense: " & CStr(Defend()) & vbNewLine & vbNewLine

        Return out
    End Function

End Class
