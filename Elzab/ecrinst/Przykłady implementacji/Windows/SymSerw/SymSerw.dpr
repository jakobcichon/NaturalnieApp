program SymSerw;

uses
  Forms,
  Glowny in 'Glowny.pas' {GlowneOknoAplikacji};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TGlowneOknoAplikacji, GlowneOknoAplikacji);
  Application.Run;
end.
