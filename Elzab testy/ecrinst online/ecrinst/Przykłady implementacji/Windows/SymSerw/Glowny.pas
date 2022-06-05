unit Glowny;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, ComCtrls;

type
  TypKomunikatyZFunkcji = set of char;

  TGlowneOknoAplikacji = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    GroupBox1: TGroupBox;
    Label2: TLabel;
    Edit2: TEdit;
    Label3: TLabel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    StaticText1: TStaticText;
    StaticText2: TStaticText;
    StaticText3: TStaticText;
    StaticText4: TStaticText;
    StaticText5: TStaticText;
    StaticText6: TStaticText;
    StaticText7: TStaticText;
    Panel1: TPanel;
    Panel2: TPanel;
    procedure ObslugaKomunikatowZFunkcji(var Komunikat : TMsg; var ObsluzonoKomunikat : boolean);
    procedure TworzenieGlownegoOkna(Sender: TObject);
    procedure ObliczenieNumeruKomunikatu(Sender: TObject);
    procedure ObliczenieIdentyfikatoraKomunikatu(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

const
  NapisOczekiwanie = 'Oczekiwanie na odpowiedü...';
  NapisPusty       = '                           ';

var
  GlowneOknoAplikacji     : TGlowneOknoAplikacji;
  NumerKomunikatu         : UINT;
  IdentyfikatorKomunikatu : WPARAM;
  KomunikatyZFunkcji      : TypKomunikatyZFunkcji  = ['S', 'R', 'B', 'A', 'C', 'L', 'O'];
  LicznikCOUNT            : longint;
  LicznikLINES            : longint;
  LicznikOUTLINES         : longint;

implementation

{$R *.DFM}

{******************************************************************************}

function LicznikPrzekazanyWlParam(lParam : Longword) : string;

begin
  lParam := (lParam and $FFFFFF00) shr $08;
  Str(lParam, Result);
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.ObslugaKomunikatowZFunkcji(var Komunikat : TMsg; var ObsluzonoKomunikat : boolean);
begin
  ObsluzonoKomunikat := false;

  if (Komunikat.message = NumerKomunikatu) then
    if (Komunikat.WParam = IdentyfikatorKomunikatu) then
      if (char(Komunikat.lParam) in KomunikatyZFunkcji) then
        begin
          ObsluzonoKomunikat := true;
          case char(Komunikat.lParam) of
            'S' : begin
                    StaticText1.Caption := NapisPusty;
                  end;
            'R' : begin
                    StaticText2.Caption := NapisPusty;
                  end;
            'B' : begin
                    StaticText3.Caption := NapisPusty;
                  end;
            'A' : begin
                    StaticText4.Caption := NapisPusty;
                  end;
            'C' : begin
                    StaticText5.Caption := LicznikPrzekazanyWlParam(Komunikat.lParam);
                  end;
            'L' : begin
                    StaticText6.Caption := LicznikPrzekazanyWlParam(Komunikat.lParam);
                  end;
            'O' : begin
                    StaticText7.Caption := LicznikPrzekazanyWlParam(Komunikat.lParam);
                  end;
          end;
        end;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.TworzenieGlownegoOkna(Sender: TObject);
begin
  ObliczenieNumeruKomunikatu(Sender);
  ObliczenieIdentyfikatoraKomunikatu(Sender);
  Application.OnMessage := ObslugaKomunikatowZFunkcji;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.ObliczenieNumeruKomunikatu(Sender: TObject);
var
  Blad : integer;
begin
  Val(Edit1.Text, NumerKomunikatu, Blad);
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.ObliczenieIdentyfikatoraKomunikatu(
  Sender: TObject);
var
  Blad : integer;
begin
  Val(Edit2.Text, IdentyfikatorKomunikatu, Blad);
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button1Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('s'))) then
    StaticText1.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button2Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('r'))) then
    StaticText2.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button3Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('b'))) then
    StaticText3.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button4Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('a'))) then
    StaticText4.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button5Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('c'))) then
    StaticText5.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button6Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('l'))) then
    StaticText6.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button7Click(Sender: TObject);
begin
  if (PostMessage(HWND_BROADCAST, NumerKomunikatu, IdentyfikatorKomunikatu, LPARAM('o'))) then
    StaticText7.Caption := NapisOczekiwanie;
end;

{******************************************************************************}

procedure TGlowneOknoAplikacji.Button8Click(Sender: TObject);
begin
  GlowneOknoAplikacji.Button5Click(Sender);
  GlowneOknoAplikacji.Button6Click(Sender);
  GlowneOknoAplikacji.Button7Click(Sender);
end;

{******************************************************************************}

end.
