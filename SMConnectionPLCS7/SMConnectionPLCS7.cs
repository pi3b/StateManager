using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
using StateManager;
using Newtonsoft;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionPLCS7:SMConnection
    {
        SiemensS7Net S7;
        public override void DoCreateConObj(string UsedConnectionStr)
        {
            string[] arr = UsedConnectionStr.Split(':'); //UsedConnectionStr = "192.168.1.10:102:s71200"
            string usePLCVer = arr[2];
            SiemensPLCS SiemensPLCS1 = (SiemensPLCS)Enum.Parse(typeof(SiemensPLCS), usePLCVer, true);
            //S1200 = 1,
            //S300 = 2,
            //S400 = 3,
            //S1500 = 4,
            //S200Smart = 5,     
            S7 = new SiemensS7Net(SiemensPLCS1);
        }

        public override void DoConnect(string UsedConnectionStr, int ConnectTimeOutMiliSecs = 1000, int ReadTimeOutMiliSecs = 3000)
        {
            string[] arr = UsedConnectionStr.Split(':'); //UsedConnectionStr = "192.168.1.10:102:s71200"
            string useIP = arr[0];
            int usePort = Convert.ToInt32(arr[1]);
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(useIP, out address))
            {
                throw new Exception("无效IP");
            }
            S7.IpAddress = useIP;
            S7.Port = usePort;
            S7.Rack = 0;
            S7.Slot = 0;
            S7.ConnectClose();
            try
            {
                S7.ConnectTimeOut = ConnectTimeOutMiliSecs;
                S7.ReceiveTimeOut = ReadTimeOutMiliSecs;
                OperateResult r = S7.ConnectServer();
                if (!r.IsSuccess)
                    throw new Exception("连接失败。");
            }
            catch
            {
                S7.ConnectClose();
                throw;
            }
        }

        public override void DoDisConnect()
        {
            S7.ConnectClose();
        }

        public bool ReadBool(string Address)
        {
            return Hsl(S7.ReadBool(Address));
        }

        public int ReadInt(string Address)
        {
            return Hsl(S7.ReadInt32(Address));
        }

        public void Write(string Address, dynamic V)
        {
            S7.Write(Address, V);
        }

        public T Hsl<T>(OperateResult<T> r)
        {
            if (!r.IsSuccess)
                throw new Exception(r.Message);
            return r.Content;
        }
    }
}
