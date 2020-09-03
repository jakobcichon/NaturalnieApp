program example;
{$APPTYPE CONSOLE}
uses
  SysUtils, WinIP;

var
  ErrorNo : byte;
  InFile, OutFile : String;
begin
  InFile  := 'in';
  OutFile := 'out';

  ErrorNo := __TowarMax(String2BCString(InFile), String2BCString(OutFile));

end.
