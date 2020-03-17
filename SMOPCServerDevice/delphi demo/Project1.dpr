program Project1;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  test_TLB in '..\..\..\..\Program Files (x86)\Borland\Delphi7\Imports\test_TLB.pas',
  SMOPCDevice_TLB in 'C:\Program Files (x86)\Borland\Delphi7\Imports\SMOPCDevice_TLB.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
