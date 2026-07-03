'********************************************************************************************* 
'  Surname, Initials: Nsenda, SM 
'  Student Number: 225103522 
'  Practical: P07 
'*********************************************************************************************

Option Strict On
Option Explicit On
Option Infer Off

Public MustInherit Class Hero
    'instance variables
    Private _Name As String
    Private _Healthlevel As Integer
    Private _Basedamage As Integer
    Private _Experience As Integer

    'constructors
    Public Sub New(Name As String, Basedamage As Integer, Experience As Integer)
        _Name = Name
        Me.Basedamage = Basedamage
        Me.Experience = Experience
        'set health to 0
        Healthlevel = 100
    End Sub
    'properties
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property Healthlevel As Integer
        Get
            Return _Healthlevel
        End Get
        Set(value As Integer)
            If value > 100 Then
                value = 100
            Else
                If value < 0 Then
                    value = 0
                End If
            End If
            _Healthlevel = value
        End Set
    End Property

    Public Property Basedamage As Integer
        Get
            Return _Basedamage
        End Get
        Set(value As Integer)
            _Basedamage = ValidateInt(value)
        End Set
    End Property

    Public Property Experience As Integer
        Get
            Return _Experience
        End Get
        Set(value As Integer)
            _Experience = ValidateInt(value)
        End Set
    End Property

    'methods
    Public Function ValidateInt(value As Integer) As Integer
        If value < 0 Then
            value = 0
        End If
        Return value
    End Function

    Public Function ReceiveDamage(value As Integer) As Integer
        If IsAlive() Then
            _Healthlevel -= value
        End If
        Return _Healthlevel
    End Function

    Public Function Heal(value As Integer) As Integer
        If IsAlive() Then
            _Healthlevel += value
        End If
        Return _Healthlevel
    End Function

    Public Function IsAlive() As Boolean
        Dim alive As Boolean = True
        If _Healthlevel > 0 Then
            alive = True
        Else
            If _Healthlevel = 0 Then
                alive = False
            End If
        End If
        Return alive
    End Function

    Public MustOverride Function DetermineDamage() As Integer

    Public Function DetermineLevel() As Integer
        Return CInt(_Experience ^ (1 / 2))
    End Function

    Public Overridable Function Display() As String
        Dim out As String
        out = "Name: " & _Name & vbNewLine
        out += "Health Level: " & _Healthlevel & vbNewLine
        out += "Base Damage: " & _Basedamage & vbNewLine
        out += "Level : " & DetermineLevel() & vbNewLine
        out += "Determine Damage: " & DetermineDamage() & vbNewLine
        out += "Is Alive: " & IsAlive()
        Return out
    End Function
End Class