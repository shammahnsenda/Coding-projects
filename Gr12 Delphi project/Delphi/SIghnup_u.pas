unit SIghnup_u;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.Imaging.pngimage, Vcl.ComCtrls,
  Vcl.StdCtrls, Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.Menus, Data.DB, Vcl.Grids,
  Vcl.DBGrids, dmProperty_u, Vcl.Samples.Spin, Vcl.Mask, Vcl.DBCtrls;

type
  TfrmSignUp = class(TForm)
    PageControl1: TPageControl;
    tb1ClientInfo: TTabSheet;
    Panel1: TPanel;
    Image1: TImage;
    Label44: TLabel;
    Label22: TLabel;
    btnNext1: TButton;
    pLinfo: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label8: TLabel;
    edtName1: TEdit;
    edtSurname1: TEdit;
    edtID: TEdit;
    edtAddress1: TEdit;
    edtMnum1: TEdit;
    edtEmail1: TEdit;
    dtpDOB: TDateTimePicker;
    tb2Menu: TTabSheet;
    Image4: TImage;
    lblWelcome: TLabel;
    tb3Mainpage: TTabSheet;
    Label7: TLabel;
    Label9: TLabel;
    edtPassword: TEdit;
    edtPasswordC: TEdit;
    Label10: TLabel;
    btnAdmin: TButton;
    Panel2: TPanel;
    Panel3: TPanel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    cmbArea: TComboBox;
    cmbTOLand: TComboBox;
    cmbElectricity: TComboBox;
    Panel4: TPanel;
    Label17: TLabel;
    btnPurchase: TButton;
    btnSeeProp: TButton;
    Label21: TLabel;
    edtCountry: TEdit;
    Label23: TLabel;
    cbGender1: TComboBox;
    sedPrice: TSpinEdit;
    tb4Admin: TTabSheet;
    Label24: TLabel;
    Label25: TLabel;
    edtUsername: TEdit;
    edtPassword1: TEdit;
    Label26: TLabel;
    Button3: TButton;
    Panel5: TPanel;
    btnAdminEnter: TButton;
    btnFilter: TButton;
    dbgProperty: TDBGrid;
    edtPID: TEdit;
    tb5Buying: TTabSheet;
    Panel6: TPanel;
    Image3: TImage;
    Label16: TLabel;
    Label20: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    Label29: TLabel;
    Label30: TLabel;
    Label31: TLabel;
    Label32: TLabel;
    Label33: TLabel;
    Label34: TLabel;
    lblArea: TLabel;
    lblAddress: TLabel;
    lblType: TLabel;
    lblSize: TLabel;
    lblElectricity: TLabel;
    lblWaterS: TLabel;
    lblWaterE: TLabel;
    lblPrice: TLabel;
    lblLandOwner: TLabel;
    Shape1: TShape;
    btnConfirmPurchase: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Label35: TLabel;
    Label36: TLabel;
    tb6AdminB: TTabSheet;
    Panel7: TPanel;
    DBGrid1: TDBGrid;
    Label19: TLabel;
    Label37: TLabel;
    Panel8: TPanel;
    btnDelete: TButton;
    Label38: TLabel;
    btnPendingP: TButton;
    btnCart: TButton;
    Panel9: TPanel;
    tb7Cart: TTabSheet;
    Panel10: TPanel;
    redCart: TRichEdit;
    Button12: TButton;
    Button1: TButton;
    btnBackA: TButton;
    procedure btnNext1Click(Sender: TObject);
    procedure btnSeePropClick(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure btnAdminClick(Sender: TObject);
    procedure btnFilterClick(Sender: TObject);
    procedure btnPurchaseClick(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Label36Click(Sender: TObject);
    procedure btnConfirmPurchaseClick(Sender: TObject);
    procedure btnAdminEnterClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure Label39Click(Sender: TObject);
    procedure btnCartClick(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure FormActivate(Sender: TObject);
    procedure btnPendingPClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure btnBackAClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSignUp: TfrmSignUp;
  sEmail,sNAmeDelete: string;
  iPID,iBuy:integer;
  bCartS: boolean;
  arrIpd:array [1..100]of integer;
  sLandOwner:string;
implementation

{$R *.dfm}

uses LandSystem_u;

procedure TfrmSignUp.btnNext1Click(Sender: TObject);
var
sName,sSurname,sID,sAddress,sGender,sEmail,sMobileNum,sCountry,sPassword,sPasswordC: String;
i,k,z,x,s,v,iLength,iLength1,iLength2,iLength3,iLength4: integer;
ddate: tDate;
bName,bSurname,bEmail,bMnum,bGender,bDate,bAddress,bCountry,bPassword : Boolean;
c:char;

begin

sName := edtName1.Text;          
sSurname:= edtSurname1.Text;     
sID:= edtId.Text +'1'; 
sAddress:= edtAddress1.text;     
sGender:= cbGender1.items[cbgender1.Itemindex];
sEmail:= edtEmail1.Text;        
sMobileNum:= edtMnum1.Text;
sCountry:= edtCountry.text;
sPassword:= edtPassword.Text;
sPasswordC:= edtPasswordC.Text;
iLength:= length(sName);
iLength1:= length(sSurname);
iLength2 := length(sEmail);
iLength3:=length(sMobileNum);
dDate:= date;


//Name
for i := 1 to iLength do
begin
 if (sName[i] IN ['1','2','3','4','5','6','7','8','9','0']) or (length(sName)>10) or (sName[i] IN ['!','@','#','$','%','^','&','*','(',')','-','_','=','+','{',',','}','|','[',']','\',':','”',';','’','<','>','?','.','/'])
 or (sName='') then
	bNAme:= False
 else
 bName:= True;
 
end;

//Surname
for k := 1 to iLength1 do
begin
 if (sSurname[k] IN ['1','2','3','4','5','6','7','8','9','0']) or (length(sSurname)>10) or (sSurname[k] IN ['!','@','#','$','%','^','&','*','(',')','-','_','=','+','{',',','}','|','[',']','\',':','”',';','’','<','>','?','.','/'])
 or (sSurname='') then
	bSurname:= False
 else
 bSurname:=True;

end;

//Email
for z := 1 to iLength2 do
 begin
 if (length(sEmail)>30) or (sEmail[z] IN ['!','#','$','%','^','&','*','(',')','-','_','=','+','{',',','}','|','[',']','\',':','”',';','’','<','>','?','/'])
 or  (sEmail='')  {(not(sEmail[z] in ['@','.'])) } then
  bEmail:=false
 else
 bEmail:=True;
 end;

//Gender
if (sGender='')  then
showmessage('Please pick a gender')
else
 bGender:=true;

//Mobile Number
for x := 1 to iLength3 do
 begin
 if (length(sMobileNum)<>10) or (sMobileNum[x] IN ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'])
 or (sMobileNum='') or  not (sMobileNum[1] in ['0']) then
 bMnum:=false
 else
 bMnum:=True;
 end;

//DOB
if (dtpDOB.date=dDate) then
begin
Showmessage('Please enter a date');
bDate:= False;
end
else
bDate:= True;

//Address
if sAddress='' then
begin
Showmessage('Please enter a Address');
bAddress := false;
end
else
bAddress:= True;

//Country
if sCountry='' then
begin
Showmessage('Please enter a country');
bCountry:=false
end
else
bcountry:=true;

//Password
if (sPassword<>sPasswordC) then
begin
Showmessage('Your passwords do not match');
bPassword:=false;
end else
bPassword:= true;

//ShowMessage
if bName= false then
showmessage('The Name you entered is invalid');

if bSurname=False then
showmessage('The Surname you entered is invalid');

if bEmail=False then
showmessage('The Email you entered is invalid');

if bMnum=False then
showmessage('The Moblie Number you entered is invalid');


//Validation
if (bName and bSurname and bEmail and bGender  and bMnum and bDate and bcountry and bAddress ) =True then
pagecontrol1.Activepage:= tb2Menu;

//Data base
with dmProperty do
begin
  qryProperty.Close;
  qryProperty.Sql.clear;

  qryProperty.Sql.Text := ('Update [Client Info] set [Name]='+(Quotedstr(sNAme))+',[Surname]='+(Quotedstr(sSurname))+',[Country]='+(Quotedstr(sCountry))+', [Address]='+(Quotedstr(sAddress))+',[Gender]='+(Quotedstr(sGender))+',[Date Of Birth]='+(datetostr(dDate)));
  qryProperty.ExecSQL;

  qryProperty.SQL.Text := ('Update [Client Info] set [Phone Number]='+(Quotedstr(sMobileNum))+', [Email]='+(Quotedstr(sEmail))+',[Date Logged] In="dDate"'+', [Password]='+(Quotedstr(sPasswordC)) );

  qryProperty.ExecSQL;

  //redCart
  if sname='' then
  bcarts:=false
  else
  bcarts:=true;

end;
end;

procedure TfrmSignUp.Button11Click(Sender: TObject);
begin
PageControl1.activepage:=tb2Menu;
end;

procedure TfrmSignUp.Button12Click(Sender: TObject);
begin
pagecontrol1.ActivePage:= tb3Mainpage;
end;

procedure TfrmSignUp.Button1Click(Sender: TObject);
begin
pagecontrol1.ActivePage:=tb2Menu;
btnBackA.Hide;
end;

procedure TfrmSignUp.btnDeleteClick(Sender: TObject);
var
sDelete: string;
bTrue: boolean;
begin
sDelete:=inputbox('Deleting a property','Which property are you trying to delete','');
bTrue:= false;


with dmProperty do
  begin
   tblProperty.First;
  while not tblProperty.eof do
  begin
   if (sDelete = tblProperty['Propery ID']) and (tblProperty['Land owner']=sNameDelete) then
   Begin
    tblProperty.Delete;
    tblProperty.Post;
    bTrue:= True;
    end;//end of if
    tblProperty.Next;
  end;

  end;
  if bTrue = true  then
  Showmessage('The record has been succesfully deleted')
    else
   Showmessage('The record you have entered is invalid');

end;

procedure TfrmSignUp.btnAddClick(Sender: TObject);
var
sAdd: string;
bTrue:boolean;
begin
sAdd:=inputbox('Deleting a property','Which property are you trying to delete','');
bTrue:= false;


with dmProperty do
  begin
   tblProperty.First;
  while not tblProperty.eof do
  begin
   if (sAdd = tblProperty['Propery ID']) and (tblProperty['Land owner']=sNameDelete) then
   Begin
    qryProperty.Close;
    qryProperty.Sql.clear;
    qryProperty.Sql.Add('Update from Property where [Propery ID]= "'+sAdd +'" and [Land Owner]='+quotedstr(sNameDelete));
    qryProperty.Execsql;
     qryProperty.Close;
    bTrue:= True;
    end;//end of if
    tblProperty.Next;
  end;



  end;
  if bTrue = true  then
  Showmessage('The record has been succesfully deleted')
    else
   Showmessage('The record you have entered is invalid');

 end;


procedure TfrmSignUp.btnPendingPClick(Sender: TObject);
var
sBuy:string;
i,iCounter:integer;
myFile:textFile;
sLand,sLine:string;
begin
sBuy:= inttostr(iBuy);
i:=0;

AssignFile(myfile, 'Cart.txt');
Reset (myfile);

while NOT eof( myfile) do
begin
readln(myfile,sLine);

inc(i);
delete(sLine,1,pos(',',sLine)-1);
delete(sLine,1,pos(',',sLine)-1);
sLand:=sLine;



begin
with dmProperty do
begin
tblProperty.First;
if (sLand=tblProperty['Land owner'])and (tblProperty['Propery ID']=inttostr(ipid)) then
while not tblProperty.eof do
 begin
 redCart.Lines.Add('Land'+#9+inttostr(iCounter));
  redCart.Lines.Add('Area:'+#9+tblProperty['Area']);
  redCart.Lines.Add('Address:'+#9+tblProperty['Address']);
  redCart.Lines.Add('Type of land:'+#9+tblProperty['Type of land']);
  redCart.Lines.Add('Size:'+#9+inttostr(tblProperty['Size']));
  redCart.Lines.Add('Electricity By:'+#9+tblProperty['Electricity by?']);
  redCart.Lines.Add('Water source:'+#9+tblProperty['Water Source']);
  redCart.Lines.Add('Water estimate:'+#9+inttostr(tblProperty['Water estimate'])+'ml');
  redCart.Lines.Add('Price:'+'R'+#9+inttostr(tblProperty['Price']));
  redCart.Lines.Add('Land owner:'+#9+tblProperty['Land owner']);
 end;
tblProperty.Next;
end;
end;
end;
closefile(myfile);

pageControl1.activepage:= tb7Cart;
btnBackA.Show;

end;//end of tbl while

procedure TfrmSignUp.btnSeePropClick(Sender: TObject);
begin
pagecontrol1.Activepage:= tb3Mainpage;
end;

procedure TfrmSignUp.Button3Click(Sender: TObject);
begin
PageControl1.activepage:=tb2Menu;
edtUsername.Clear;
edtPassword1.Clear;
end;

procedure TfrmSignUp.btnAdminClick(Sender: TObject);
begin
PageControl1.activepage:=tb4Admin;
end;

procedure TfrmSignUp.btnPurchaseClick(Sender: TObject);
var
propertyID,sPrice: string;
i,iCount: integer;
bPID: boolean;

begin
iPID:= strtoint(edtPID.Text);
bPID:= false;
iCount:=0;

with dmProperty do
begin

tblProperty.First;
while not tblProperty.eof do
 begin
 if (iPID<> null) and (iPID= tblProperty['Propery ID']) then
 pagecontrol1.ActivePage:=tb5Buying;


 if iPID= tblProperty['Propery ID'] then
  begin
  lblArea.Caption := tblProperty['Area'];
  lblAddress.Caption := tblProperty['Address'];
  lblType.Caption := tblProperty['Type of land'];
  lblSize.Caption := tblProperty['Size'];
  lblElectricity.Caption := tblProperty['Electricity by?'];
  lblWaterS.Caption := tblProperty['Water Source'];
  lblWaterE.Caption := tblProperty['Water estimate']+'ml';
  lblPrice.Caption := 'R'+inttostr(tblProperty['Price']);
  lblLandOwner.Caption := tblProperty['Land owner'];
  bPID:= true;

  sLandOwner:= tblProperty['Land owner'];
  //sPrice:=inttostr(tblProperty['Price']);//try
  end;//end of if

  //Ask maam price
  { for i := length(sPrice) to 1 do
  begin
  inc(icount);
  if icount mod 3 =0 then
  sPrice := sPrice[i]+' ';

  end;
  lblPrice.Caption := 'R'+inttostr(tblProperty['Price']);//try }

  tblProperty.Next
 end;//end of while
 if bPID= false then
 showmessage('The property ID you entered is invalid');

end;//end of with

end;

procedure TfrmSignUp.btnAdminEnterClick(Sender: TObject);
var
sLO,sPassword,sNAme: string;
myFile: textFile;
i,iPos:Integer;
bNAme: boolean;
begin
sName:= edtUsername.text;
bName:= False;
sPassword:= edtPassword1.Text;

with dmProperty do
begin
tblProperty.First;
while not tblProperty.eof do
 begin
 ipos:=pos(' ',tblProperty['Land owner']) ;
 sLO:= copy(tblProperty['Land owner'],ipos+1,length(tblProperty['Land owner']));

 if (Lowercase(sName) = lowerCase(sLO)) and (sPassword= '12345') then
 Begin
 PageControl1.activepage:=tb6AdminB;
 bName:= true;
 sNamedelete:=tblProperty['Land owner'];
 End;

tblProperty.Next;
end;//end of tbl while

end;//end of with

if bName=false then
showmessage('The username or password you have entered is invalid') else
 begin
//dbGrid on Admin main page
 with dmProperty do
  begin
  qryProperty.Close;
  qryProperty.Sql.clear;
  qryProperty.Sql.Add('Select * from Property Where [Land owner] like "%'+sName+'"');
  qryProperty.Open;
  end;//end of with
 end;//end of else




end;

procedure TfrmSignUp.btnBackAClick(Sender: TObject);
begin
pagecontrol1.Activepage:=tb6AdminB;
end;

procedure TfrmSignUp.btnCartClick(Sender: TObject);
var
arrName:array [1..100]of string;

myFile:textFile;
sLine,sName,sIPid:string;
i,k,iCounter:integer;
begin
i:=0;
iCounter:=1;
pagecontrol1.ActivePage:= tb7Cart;

if bCartS=true then
sName:= edtSurname1.text
else
sName:= frmLogin.edtEmail.text;

AssignFile(myfile, 'Cart.txt');
Reset (myfile);

while NOT eof( myfile) do
begin
readln(myfile,sLine);

inc(i);
arrName[i]:= copy(sLine,1,pos(',',sLine)-1);
arrIPD[i]:= strtoint(copy(sLine,pos(',',sLine)+1,4));
end;
closefile(myfile);

for k := 1 to i do
if sName=arrName[k]  then
begin
sIPid:=inttostr(arrIPD[k]);

with dmProperty do
begin

tblProperty.First;
while not tblProperty.eof do
 begin
 if sIPid= tblProperty['Propery ID'] then
  begin
  redCart.Lines.Add('Land'+#9+inttostr(iCounter));
  redCart.Lines.Add('Area:'+#9+tblProperty['Area']);
  redCart.Lines.Add('Address:'+#9+tblProperty['Address']);
  redCart.Lines.Add('Type of land:'+#9+tblProperty['Type of land']);
  redCart.Lines.Add('Size:'+#9+inttostr(tblProperty['Size']));
  redCart.Lines.Add('Electricity By:'+#9+tblProperty['Electricity by?']);
  redCart.Lines.Add('Water source:'+#9+tblProperty['Water Source']);
  redCart.Lines.Add('Water estimate:'+#9+inttostr(tblProperty['Water estimate'])+'ml');
  redCart.Lines.Add('Price:'+'R'+#9+inttostr(tblProperty['Price']));
  redCart.Lines.Add('Land owner:'+#9+tblProperty['Land owner']);

  redCart.Lines.Add(#13+#13);
  inc(iCounter);

  end;//end of if

  tblProperty.Next
 end;//end of while

end;//end of with
end;

end;

procedure TfrmSignUp.btnFilterClick(Sender: TObject);
var
sArea,sLand,sElectricity:string;
iPrice: integer;
begin
sArea:= cmbArea.Items[cmbArea.ItemIndex];
sLand:= cmbTOLand.Items[cmbTOLand.ItemIndex];
sElectricity:= cmbElectricity.Items[cmbElectricity.ItemIndex];
iPrice:= sedPrice.Value;

if (sArea<>'') or (sLand<> '')or (sElectricity<> '') then
begin
dbgProperty.DataSource := dmProperty.dsrProperty;
end;

if sArea<>'' then
begin
 with dmProperty do
begin
  qryProperty.Close;
  qryProperty.Sql.clear;
  qryProperty.Sql.Add('Select * from Property Where Area = '+QuotedStr(sArea));
  qryProperty.Open;
end;//end of with
end;//end of if


if sLand<> '' then
begin
with dmProperty do
begin
  qryProperty.Close;
  qryProperty.Sql.clear;
  qryProperty.Sql.Add('Select * from Property Where [Type of land] = '+QuotedStr(sLand));
  qryProperty.Open;

end;
end;//end of if

if sElectricity<>'' then
begin
 with dmProperty do
begin
  qryProperty.Close;
  qryProperty.Sql.clear;
  qryProperty.Sql.Add('Select * from Property Where [Electricity by?] = '+QuotedStr(sElectricity));
  qryProperty.Open;
end;//end of with
end;//end of if

 end;


procedure TfrmSignUp.btnConfirmPurchaseClick(Sender: TObject);
var
myFile:textFile;
sLine,sName:String;
begin
showMessage('Thank you for shopping with Shammah D farming');
showMessage('The your purchase is bieng processed');
if (MessageDlg('Do you wish to continue shopping?',mtInformation,[mbYes,mbNo],0)=mrYes) then
begin
PageControl1.activepage:=tb3Mainpage;
end         else
frmLogin.close;

//textfile
if bCartS=true then
sName:= edtSurname1.text
else
sName:= frmLogin.edtEmail.text;

AssignFile(myfile, 'Cart.txt');
append(myfile);

writeln(myfile,sName+','+inttostr(iPID)+','+sLandOwner);
closefile(myfile);


end;

procedure TfrmSignUp.Button9Click(Sender: TObject);
begin
PageControl1.activepage:=tb3Mainpage;
end;


procedure TfrmSignUp.FormActivate(Sender: TObject);
begin
redCart.Paragraph.TabCount:=2;
redCart.Paragraph.Tab[1]:=5;
redCart.Paragraph.Tab[2]:=50;

btnBackA.Hide;
end;

procedure TfrmSignUp.Label36Click(Sender: TObject);
begin
frmLogin.show;
frmsignup.hide;

end;


procedure TfrmSignUp.Label39Click(Sender: TObject);
begin
frmLogin.Close;
end;

end.
