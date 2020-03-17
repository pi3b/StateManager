unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, OleServer, SMOPCDevice_TLB,ActiveX, StdCtrls,ComObj;

type
  TForm1 = class(TForm)
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  cls: TSMOPCDevice;
implementation

{$R *.dfm}

procedure TForm1.btn1Click(Sender: TObject);
begin
  cls:=TSMOPCDevice.Create(nil);
end;

procedure TForm1.btn3Click(Sender: TObject);      
var ad:IOPCDeviceLink;   sum:Integer;
begin
  ad:=cls.DefaultInterface as IOPCDeviceLink;
  sum := ad.Add(cls.a,1);
  ShowMessage(IntToStr((sum))) ;
end;

procedure TForm1.btn2Click(Sender: TObject);
var ad:IOPCDeviceLink;   sum:Integer;
  c: TSMOPCDevice;
  HR: HResult;     
  addd:IUnknown;
begin
  //c#实现的COM不支持
//  ad:=GetActiveOleObject('SMOPCDevice') as IOPCDeviceLink;
      HR := GetActiveObject(StringToGUID('{25930171-2872-4EC3-A81B-0E11229501B0}'), nil, addd);
      ad:=addd as IOPCDeviceLink;
//      if not Succeeded(HR) then
//      begin
//        raise EOleSysError.Create('没有运行的', HR, 0);
//      end;
//  c:=TSMOPCDevice.Create(nil);
//  c.Disconnect;
//  c.ConnectKind:=ckRunningInstance;
//  c.Connect();
//  ad:=c.DefaultInterface as IOPCDeviceLink;
  sum := ad.Add(1,1);
  ShowMessage(IntToStr((sum))) ;
end;

end.
