'********************************************************************************************* 
'  Surname, Initials: Nsenda, SM 
'  Student Number: 225103522 
'  Practical: P07 
'*********************************************************************************************

Option Strict On
Option Explicit On
Option Infer Off

Public Class Tank
    'inheritance
    Inherits Hero
    'intance variables
    Private _Armour As Integer

    'constructor
    Public Sub New(Name As String, Basedamage As Integer, Experience As Integer, Armour As Integer)
        MyBase.New(Name, Basedamage, Experience)
        _Armour = Armour
    End Sub

    'properties
    Public Property Armour As Integer
        Get
            Return _Armour
        End Get
        Set(value As Integer)
            _Armour = value
        End Set
    End Property

    'methods
    Public Overrides Function DetermineDamage() As Integer
        'overrides determine damage function from base class
        Return CInt((Basedamage / 2) * DetermineLevel())
    End Function

    Public Function Defend() As Integer
        Return CInt(_Armour * DetermineLevel())
    End Function

    Public Overrides Function display() As String
        'overriding display function derived class
        Dim out As String
        out = "TANK" & vbNewLine
        out += MyBase.Display() & vbNewLine
        out += "Armour: " & _Armour & vbNewLine
        out += "Defend: " & Defend() & vbNewLine
        Return out
    End Function
End Class
