using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionTCP : SMConnection
    {
        Socket Socket;
        public bool ASync = false; //默认为同步SOCKET
        public override void DoCreateConObj(string UsedConnectionStr)
        {
        }

        public override void DoConnect(string UsedConnectionStr, int ConnectTimeOutMiliSecs = 1000, int ReadTimeOutMiliSecs = 3000)
        {
            if(Socket == null) 
                Socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (Socket.Connected) return;
            string[] arr = UsedConnectionStr.Split(':'); //UsedConnectionStr = "192.168.1.10:102"
            string useIP = arr[0];
            int usePort = Convert.ToInt32(arr[1]);
            if (arr.Length >= 3 && arr[2] == "Y")// 带Y表示异步
                ASync = true;
            AsyncReadString = "";
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(useIP, out address))
            {
                throw new Exception("无效IP");
            } 
            try
            {
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, ReadTimeOutMiliSecs);
                EndPoint ep = new IPEndPoint(IPAddress.Parse(useIP), usePort);
                Socket.Connect(ep);
                if (ASync)
                {
                    Socket.BeginReceive(AsyncBuffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), Socket);
                }
                else
                {
                    Socket.BeginReceive(AsyncBuffer, 0, 2048, SocketFlags.None, null, null); //必须有缓冲区，否则不能正常断开，没有异步回调函数，可以节省资源
                }

                if (!Socket.Connected)
                {
                    throw new Exception("连接失败。");
                }
            }
            catch
            {
                throw;
            }
        }

        public override void DoDisConnect()
        {
            if (Socket != null && Socket.Connected)
            {
                //Socket.Shutdown(SocketShutdown.Both);//不能用这个，断开连接对方会收不到
                Socket.Close(10);
                if (Socket != null && Socket.Connected)
                {
                    throw new Exception("断开失败。");
                }
            }
            Socket = null;
        }

        public override bool Connected
        {
            get
            {
                return Socket!=null && Socket.Connected;
            }
        }


        private byte[] AsyncBuffer = new byte[2048];
        private byte[] AsyncBuffers = new byte[2048];
        private int AsyncBufferslen = 0;
        public string AsyncEndChar = "\0";
        public string AsyncReadString="";
        int FindIndexOfBuffer(byte[] buffers, int bufferslen, string EndChar)
        {
            byte[] EndCharBytes = System.Text.Encoding.ASCII.GetBytes(EndChar); //结束字符串转为数组
            int EndCharLen = EndChar.Length;
            //查找index
            int findindex = -1;
            for (int i = 0; i < bufferslen-EndChar.Length+1; i++)
            {
                bool ok = true;
                for (int j = 0; j < EndCharLen; j++)
                {
                    if (buffers[i] != EndCharBytes[j])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    findindex = i;
                    break;
                }
            }
            //返回
            return findindex;
        }

        public virtual void DataOK(byte[] bytes, string str)
        {
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            if (!Connected) return;
            Socket s = (Socket)ar.AsyncState;
            if (s == null) return;
            try
            {
                int length = s.EndReceive(ar); //等读完,buffer[0]...    
                if (length > 0)
                {
                    //内容追加到缓冲区Asynbuffers
                    Array.Copy(AsyncBuffer, 0, AsyncBuffers, AsyncBufferslen, length); AsyncBufferslen += length;
                    //尝试循环获取所有满足结束符的内容
                    while (true)
                    {
                        int findindex = FindIndexOfBuffer(AsyncBuffers, AsyncBufferslen, AsyncEndChar);
                        if (findindex == -1) break;
                        //byte[] bytes=new byte[1024];
                        //Array.Copy(Asynbuffers, bytes, findindex);
                        byte[] bytes = AsyncBuffers.Take(findindex + AsyncEndChar.Length).ToArray();
                        string str = System.Text.Encoding.ASCII.GetString(bytes).TrimEnd('\0');
                        //整理缓冲区
                        byte[] tmpbytes = AsyncBuffers.Skip(findindex + AsyncEndChar.Length).Take(AsyncBufferslen - findindex - AsyncEndChar.Length).ToArray();
                        Array.Copy(tmpbytes,AsyncBuffer, tmpbytes.Length);
                        Array.Clear(AsyncBuffers, 0, AsyncBuffers.Length);
                        Array.Copy(AsyncBuffer, AsyncBuffers, tmpbytes.Length);
                        AsyncBufferslen = tmpbytes.Length;

                        //调用用户代码
                        AsyncReadString = str;
                        DataOK(bytes, str);

                    }
                    //
                    Array.Clear(AsyncBuffer, 0, AsyncBuffer.Length);
                    s.BeginReceive(AsyncBuffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), s);
                }
            }
            catch
            {
                DisConnect();
            }
        }

        //同步读取
        public string RecvString(string EndChar="\0")
        {
            if (ASync) throw new Exception("异步Socket通讯时不能使用RecvString方法");
            try
            {
                Socket s = Socket;
                byte[] buffer = new byte[2048];
                Array.Clear(buffer, 0, buffer.Length);
                int len = 0;
                while (true)
                {
                    len += s.Receive(buffer, len, buffer.Length-len, SocketFlags.None);
                    int findindex = FindIndexOfBuffer(buffer, len, EndChar);
                    if (findindex == -1)
                        continue;
                    byte[] bytes = buffer.Take(findindex + EndChar.Length).ToArray();
                    string str = System.Text.Encoding.ASCII.GetString(bytes).TrimEnd('\0');
                    return str;
                }
            }
            catch
            {
                DisConnect();
                throw;
            }

        }

        public void SendBytes(byte[] b)
        {
            try
            {
                Socket.Send(b);
            }
            catch
            {
                DisConnect();
            }
        }

        public void SendString(string SendStr)
        {
            if (SendStr == null) return;
            try
            {
                byte[] b = (Encoding.GetEncoding(936).GetBytes(SendStr)).ToArray();
                Socket.Send(b);
            }
            catch
            {
                DisConnect();
            }
        }


        public override object Form
        {
            get { return null; }
        }
    }
}
