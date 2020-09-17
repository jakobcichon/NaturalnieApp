unit WinIP;

interface

const
   WinIPDLL  = 'WinIP.dll';

type
  TypBCString   = array [$00..$FF] of char;

  function __TowarMax(PlikIn, PlikOut : TypBCString): byte;cdecl;


  function String2BCString(StringDoKonwersji : string) : TypBCString;
  function StringBC2String(StringDoKonwersji : TypBCString) : string;

implementation

{******************************************************************************}

function String2BCString(StringDoKonwersji : string) : TypBCString;

var
  TmpBCString : TypBCString;
  I       : integer;

begin
  for I := 1 to Length(StringDoKonwersji) do
    TmpBCString[I-1] := StringDoKonwersji[I];
  TmpBCString[Length(StringDoKonwersji)] := char($00);

  result := TmpBCString;
end;

{******************************************************************************}

function StringBC2String(StringDoKonwersji : TypBCString) : string;

var
  TmpString   : string;
  I : integer;

begin
  I := 0;
  TmpString   := '';

  while StringDoKonwersji[I] <> char($00) do
    begin
      if (StringDoKonwersji[I] <> char($00)) then
      TmpString := TmpString+StringDoKonwersji[I];
      Inc(I);
    end;

  result := TmpString;
end;

{******************************************************************************}
  function __TowarMax(PlikIn, PlikOut : TypBCString): byte;cdecl;external WinIPDLL;

end.
