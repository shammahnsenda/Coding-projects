' ************************************************************************************************** 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522
'  Practical: P05 
'  Class: AssemblyRobot
' ************************************************************************************************** 

Option Strict On
Option Explicit On
Option Infer Off

Public Class AssemblyRobot
    Inherits Robot

    Private _efficiency As Double
    Private _speed As Double
    Private _precision As Double

    Public Sub New(_name As String, _level As Integer, _Efficientcy As Double, _Speed As Double, _Precision As Double)
        MyBase.New(_name, _level)

        Me._efficiency = _Efficientcy
        Me._speed = _Speed
        Me._precision = _Precision
    End Sub

    Private Function Work() As Double
        Return _speed * _efficiency
    End Function

    Private Function Defend() As Double
        Return _precision * _level
    End Function

    Public Property Efficiency() As Double
        Get
            Return _efficiency
        End Get
        Set(value As Double)
            _efficiency = Validation(value)
        End Set
    End Property

    Public Property Precision() As Double
        Get
            Return _precision
        End Get
        Set(value As Double)
            _precision = Validation(value)
        End Set
    End Property

    Public Property Speed() As Double
        Get
            Return _speed
        End Get
        Set(value As Double)
            _speed = Validation(value)
        End Set
    End Property

    Public Overrides Function Display() As String
        Dim out As String
        out = "<<Assembly Robot>>" & vbNewLine
        out += MyBase.Display()
        out += "Attack: " & CStr(Work()) & vbNewLine
        out += "Defense: " & CStr(Defend()) & vbNewLine & vbNewLine

        Return out
    End Function

End Class
