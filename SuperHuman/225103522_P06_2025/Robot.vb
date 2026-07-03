' ************************************************************************************************** 
'  Surname, Initials: Nsenda, SM
'  Student Number: 225103522
'  Practical: P05 
'  Class: Robot
' ************************************************************************************************** 

Option Strict On
Option Explicit On
Option Infer Off

Public MustInherit Class Robot
    Private _name As String
    Protected _level As Integer
    Private _ID As Integer
    'shared variable
    Private Shared _Count As Integer

    Public Sub New(_name As String, _level As Integer)
        Me._name = _name
        Me._level = _level

        _Count += 1

        _ID = _Count
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property


    Public Property Level() As Integer
        Get
            Return _level
        End Get
        Set(value As Integer)
            _level = Validation(value)
        End Set
    End Property

    Protected Function Validation(value As Integer) As Integer
        If value < 0 Then
            value = 0
        End If
        Return value
    End Function

    Protected Function Validation(value As Double) As Double
        If value < 0 Then
            value = 0
        End If
        Return value
    End Function

    Public Overridable Function Display() As String
        Dim out As String

        out = "Name: " & _name & vbNewLine
        out += "ID: " & _ID & vbNewLine
        out += "Level: " & _level & vbNewLine
        Return out

    End Function


End Class

