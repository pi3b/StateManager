using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Profinet.Siemens;
using StateManager;
using Newtonsoft;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionHsl:SMConnection
    {
        public string v1 = "22";
        dynamic HslDevice; //NetworkDoubleBase<TNetMessage, TTransform>   IReadWriteNet //用dynamic就无法使用隔离了
        public override void DoCreateConObj(string UsedConnectionStr)
        {
            //发生在StateInit时,这里在DoConnect懒加载
        }

        public override void DoConnect(string UsedConnectionStr)
        {
            // "192.168.1.10:102:SiemensS7Net:s71200" 、 "192.168.1.10:102:MelsecMcNet"
            string[] arr = UsedConnectionStr.Split(':');
            if (arr.Count() < 3)
                throw new Exception("参数字符串无效！");
            switch (arr[2])
            {
                case "SiemensS7Net":
                    if (HslDevice == null)
                    {
                        SiemensPLCS SiemensPLCS = (SiemensPLCS)Enum.Parse(typeof(SiemensPLCS), arr[3], true);
                        HslDevice = new SiemensS7Net(SiemensPLCS);
                        HslDevice.Rack = 0;
                        HslDevice.Slot = 0;
                    }
                    break;
                default:
                    if (HslDevice == null)
                    {
                        //创建指定类型的实例
                        //如果创建时需要参数，就和SiemensS7Net一样单独创建就好
                        HslDevice = SPlugIn.CreateObj(arr[2]);
                    }
                    break;
            }
            string useIP = arr[0];
            int usePort = Convert.ToInt32(arr[1]);
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(useIP, out address))
            {
                throw new Exception("无效IP");
            }
            HslDevice.IpAddress = useIP;
            HslDevice.Port = usePort;
            HslDevice.ConnectClose();
            try
            {
                HslDevice.ConnectTimeOut = ConnectTimeOut;
                HslDevice.ReceiveTimeOut = ReadTimeOut;
                OperateResult r = HslDevice.ConnectServer();
                if (!r.IsSuccess)
                    throw new Exception("连接失败。");
            }
            catch
            {
                HslDevice.ConnectClose();
                throw;
            }
        }

        public override void DoDisConnect()
        {
            HslDevice.ConnectClose();
        }

        public bool ReadBool(string Address)
        {
            HslCommunication.Core.IReadWriteNet RW = HslDevice;
            return Hsl(HslDevice.ReadBool(Address));
        }

        public Int32 ReadInt32(string Address)
        {
            return Hsl((HslDevice as IReadWriteNet).ReadInt32(Address));
        }

        public Int16 ReadInt16(string Address)
        {
            return Hsl((HslDevice as IReadWriteNet).ReadInt16(Address));
        }

        public void Write(string Address, dynamic V)
        {
            HslDevice.Write(Address, V);
        }

        public T Hsl<T>(OperateResult<T> r)
        {
            if (!r.IsSuccess)
                throw new Exception(r.Message);
            return r.Content;
        }

        public override object Form
        {
            get { return null; }
        }
    }
}
