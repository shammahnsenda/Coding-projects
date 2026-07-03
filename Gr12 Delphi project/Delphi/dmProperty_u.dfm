object dmProperty: TdmProperty
  Height = 480
  Width = 640
  object conPropertyDatabase: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Farming.mdb;Mode=Re' +
      'adWrite;Persist Security Info=False;Jet OLEDB:System database=""' +
      ';Jet OLEDB:Registry Path="";Jet OLEDB:Database Password="";Jet O' +
      'LEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:G' +
      'lobal Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Je' +
      't OLEDB:New Database Password="";Jet OLEDB:Create System Databas' +
      'e=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don'#39't Copy Lo' +
      'cale on Compact=False;Jet OLEDB:Compact Without Replica Repair=F' +
      'alse;Jet OLEDB:SFP=False'
    LoginPrompt = False
    Mode = cmReadWrite
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 264
    Top = 48
  end
  object tblProperty: TADOTable
    Active = True
    Connection = conPropertyDatabase
    CursorType = ctStatic
    TableName = 'Property'
    Left = 104
    Top = 120
  end
  object dscProperty: TDataSource
    DataSet = tblProperty
    Left = 104
    Top = 176
  end
  object dscSignUp: TDataSource
    DataSet = tblSignUP
    Left = 216
    Top = 184
  end
  object tblSignUP: TADOTable
    Active = True
    Connection = conPropertyDatabase
    CursorType = ctStatic
    TableName = 'Clients sign up info'
    Left = 216
    Top = 120
  end
  object qryProperty: TADOQuery
    Connection = conPropertyDatabase
    Parameters = <>
    Left = 496
    Top = 88
  end
  object dsrProperty: TDataSource
    DataSet = qryProperty
    Left = 488
    Top = 168
  end
end
