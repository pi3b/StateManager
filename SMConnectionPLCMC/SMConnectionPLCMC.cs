using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HslCommunication;
using HslCommunication.Profinet.Melsec;
using Newtonsoft;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionPLCMC : SMConnection
    {
        public MelsecMcNet MC;
        public override void DoCreateConObj(string UsedConnectionStr)
        {
            MC = new MelsecMcNet();
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
            MC.IpAddress = useIP;
            MC.Port = usePort;
            MC.ConnectClose();
            try
            {
                OperateResult connect = MC.ConnectServer();
                if (!connect.IsSuccess)
                    throw new Exception("连接失败1。");
            }
            catch
            {
                MC.ConnectClose();
                throw;
            }

        }

        public override void DoDisConnect()
        {
            MC.ConnectClose();
        }

        public bool ReadBool(string Address)
        {
            return Hsl(MC.ReadBool(Address));
        }

        public Int32 ReadInt32(string Address)
        {
            return Hsl(MC.ReadInt32(Address));
        }
        public Int16 ReadInt16(string Address)
        {
            return Hsl(MC.ReadInt16(Address));
        }

        public void Write(string Address,dynamic V)
        {
            MC.Write(Address,V);
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
