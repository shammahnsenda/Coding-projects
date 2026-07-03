program farming_u;

uses
  Vcl.Forms,
  UniversityManagement_p in 'UniversityManagement_p.pas' {frmLogin},
  signup_u in 'signup_u.pas' {frmSignup},
  dmUniManagement_u in 'dmUniManagement_u.pas' {dmUniManagement: TDataModule};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmLogin, frmLogin);
  Application.CreateForm(TfrmSignup, frmSignup);
  Application.CreateForm(TdmUniManagement, dmUniManagement);
  Application.Run;
end.
