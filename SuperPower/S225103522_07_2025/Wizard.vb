'********************************************************************************************* 
'  Surname, Initials: Nsenda, SM 
'  Student Number: 225103522 
'  Practical: P07 
'*********************************************************************************************

Option Strict On
Option Explicit On
Option Infer Off

Public Class Wizard
    'inheritance
    Inherits Hero
    'intance variables
    Private _MagicPoints As Integer
    Private _MaxMagicPoint As Integer

    'constructor
    Public Sub New(Name As String, Basedamage As Integer, Experience As Integer, MaxMP As Integer)
        MyBase.New(Name, Basedamage, Experience)
        _MaxMagicPoint = MaxMP
        'set to max value
        _MagicPoints = _MaxMagicPoint
    End Sub

    'properties
    Public Property MagicPoints As Integer
        Get
            Return _MagicPoints
        End Get
        Set(value As Integer)
            _MagicPoints = value
        End Set
    End Property

    Public Property MaxMagicPoint As Integer
        Get
            Return _MaxMagicPoint
        End Get
        Set(value As Integer)
            _MaxMagicPoint = value
        End Set
    End Property

    'methods
    Public Overrides Function DetermineDamage() As Integer
        'overrides determine damage function from base class
        Return CInt(Basedamage + ((DetermineLevel() * _MagicPoints) / 2))
    End Function

    Public Function RestoreMagicPoints(value As Integer) As Integer
        Dim counter As Integer = 0
        While counter < 1
            _MagicPoints += value
            counter += 1
        End While
        Return _MagicPoints
    End Function

    Public Sub IncreaseMaxMagicPoints()
        Dim counter As Integer = 0
        While counter > 1
            _MaxMagicPoint = CInt(_MagicPoints + DetermineLevel() ^ 2)
        End While
    End Sub

    Public Overrides Function display() As String
        'overriding display function derived class
        Dim out As String
        out = "WIZARD" & vbNewLine
        out += MyBase.Display() & vbNewLine
        out += "Magic Points: " & _MagicPoints & vbNewLine
        out += "Max Magic Point: " & _MaxMagicPoint & vbNewLine
        Return out
    End Function
End Class
