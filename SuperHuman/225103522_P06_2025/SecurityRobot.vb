' ************************************************************************************************** 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522
'  Practical: P05 
'  Class: SecurityRobot
' ************************************************************************************************** 

Option Strict On
Option Explicit On
Option Infer Off

Public Class SecurityRobot
    Inherits Robot

    Private _attackpower As Integer
    Private _threatlevel As Integer
    Private _durability As Integer

    Public Sub New(_name As String, _level As Integer, _Attackpower As Integer, _Threatlevel As Integer, _Durability As Integer)
        MyBase.New(_name, _level)

        Me._attackpower = _Attackpower
        Me._threatlevel = _Threatlevel
        Me._durability = _Durability
    End Sub

    Private Function Attack() As Integer
        Return _attackpower + _threatlevel + _durability
    End Function

    Private Function Defend() As Integer
        Return _threatlevel * _durability
    End Function

    Public Property AttackPower() As Integer
        Get
            Return _attackpower
        End Get
        Set(value As Integer)
            _attackpower = Validation(value)
        End Set
    End Property

    Public Property ThreatLevel() As Integer
        Get
            Return _threatlevel
        End Get
        Set(value As Integer)
            _threatlevel = Validation(value)
        End Set
    End Property

    Public Property Durability() As Integer
        Get
            Return _durability
        End Get
        Set(value As Integer)
            _durability = Validation(value)
        End Set
    End Property

    Public Overrides Function Display() As String
        Dim out As String
        out = "<<Security Robot>>" & vbNewLine
        out += MyBase.Display()
        out += "Attack: " & CStr(Attack()) & vbNewLine
        out += "Defense: " & CStr(Defend()) & vbNewLine & vbNewLine

        Return out
    End Function

End Class
