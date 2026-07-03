unit LandSystem_u;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Imaging.pngimage,
  Vcl.ExtCtrls, Vcl.Imaging.jpeg, dmProperty_u, SIghnup_u;

type
  TfrmLogin = class(TForm)
    plogin: TPanel;
    Label1: TLabel;
    Label4: TLabel;
    Label6: TLabel;
    Image1: TImage;
    Label3: TLabel;
    Label2: TLabel;
    btnLogin: TButton;
    edtEmail: TEdit;
    edtpassword1: TEdit;
    chkRememberME: TCheckBox;
    procedure FormActivate(Sender: TObject);
    procedure btnLoginClick(Sender: TObject);
    procedure Label2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmLogin: TfrmLogin;

implementation

{$R *.dfm}

procedure TfrmLogin.btnLoginClick(Sender: TObject);
var
sEmail,sPassword,sLine: string;
i,k :integer;
bFind: boolean;
myFile: textfile;
arrEmail: array[1..100] of string;
arrPassword: array[1..100] of string;

begin
sEmail:=(edtEmail.text);
sPassword:=(edtPassword1.text);
bFind:= false;
i:=0;

if FileExists( 'Login.txt') = FALSE then begin
showmessage ('File not found!');
Exit ;
end;

AssignFile(myfile, 'Login.txt');
Reset (myfile);

while NOT eof( myfile) do
begin
readln(myfile,sLine);

inc(i);
arrEmail[i]:= copy(sLine,1,pos(',',sLine)-1);
arrPassword[i]:= copy(sLine,pos(',',sLine)+1,20);
end;
closefile(myfile);

for k := 1 to i do
 begin
   if (sEmail =arrEmail[k]) and (sPassword=arrPassword[k]) then
   bFind:=true;
 end;



  if bFind=false then
  Begin
  Showmessage('Your email or password is incorrect');
  Showmessage('If you are not logged in then you should sign up');
  End;

  if bFind=true then
  begin
  frmSignup.Show;
  //FrmLogin.Hide;
  end;
  FrmSignUp.PageControl1.activepage:=FrmSignup.tb2Menu;

end;

procedure TfrmLogin.FormActivate(Sender: TObject);
begin
label2.font.Color:= clBlue;
label3.font.Color:= clBlack;
Label2.Color:=clGreen;

end;


procedure TfrmLogin.Label2Click(Sender: TObject);
begin

frmSignup.show;
//frmlogin.hide;
frmsignup.PageControl1.activepage:=FrmSignup.tb1CLientInfo;

end;


end.
