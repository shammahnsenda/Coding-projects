program FarmingSystem_p;

uses
  Vcl.Forms,
  LandSystem_u in 'LandSystem_u.pas' {frmLogin},
  SIghnup_u in 'SIghnup_u.pas' {frmSignUp},
  dmProperty_u in 'dmProperty_u.pas' {dmProperty: TDataModule};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmLogin, frmLogin);
  Application.CreateForm(TfrmSignUp, frmSignUp);
  Application.CreateForm(TdmProperty, dmProperty);
  Application.Run;
end.
