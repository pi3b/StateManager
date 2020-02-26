using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMConnectionSocket : SMConnection
    {
        Socket Socket;
        public bool ASync = false; //默认为同步SOCKET
        public override void DoCreateConObj(string UsedConnectionStr)
        {
        }

        public override void DoConnect(string UsedConnectionStr)
        {
            string[] arr = UsedConnectionStr.Split(':'); //UsedConnectionStr = "192.168.1.10:102:Tcp:Syn"
            ProtocolType ProtocolType = (ProtocolType)Enum.Parse(typeof(ProtocolType), arr[2]);
            SocketType SocketType = ProtocolType == ProtocolType.Tcp ? SocketType.Stream : SocketType.Dgram;
            if (Socket != null)
                DoDisConnect();
            Socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType, ProtocolType);
            string useIP = arr[0];
            int usePort = Convert.ToInt32(arr[1]);
            if (arr.Length >= 4 && arr[3] == "Asyn")// 带Asyn表示异步
                ASync = true;
            AsyncRecvString = "";
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(useIP, out address))
            {
                throw new Exception("无效IP");
            } 
            try
            {
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, base.ReadTimeOut);
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, base.ConnectTimeOut);
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
            if (Connected)
            {
                //Socket.Shutdown(SocketShutdown.Both);//不能用这个，断开连接对方会收不到
                Socket.Close(10);
                //if (Connected)
                //{
                    //throw new Exception("断开失败。");
                //}
            }
            Socket = null;
        }

        //public override bool Connected
        //{
        //    get
        //    {
        //        bool V = Socket!=null && Socket.Connected;
        //        if(!V && so.Status!="")
        //        return V;
        //    }
        //}


        private byte[] AsyncBuffer = new byte[2048];
        private byte[] AsyncBuffers = new byte[2048];
        private int AsyncBufferslen = 0;
        public string AsyncEndChar = "\0";
        public string AsyncRecvString = "";
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
        
        public EventHandler OnAsyncRecv;
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
                        if (findindex == -1) break;//继续接收，等待结束符
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
                        AsyncRecvString = str;
                        if (OnAsyncRecv != null)
                            OnAsyncRecv(this, null);

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
        public void ClearRecvBuffer()
        {
            Array.Clear(AsyncBuffers, 0, AsyncBuffers.Length);
            AsyncBufferslen = 0;

            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1);
            try
            {
                byte[] buffer = new byte[2048];
                Socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch { }
            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, ReadTimeOut);
        }

        //以下为同步方法（异步直接使用Async开头的属性字符串AsyncRecvString）
        public byte[] RecvBytes(string EndChar="\0")//结果带结束符.结束符之后的内容舍弃。
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
                    if (findindex == -1)//继续接收，等待结束符
                        continue;
                    byte[] bytes = buffer.Take(findindex + EndChar.Length).ToArray();
                    return bytes;
                }
            }
            catch
            {
                //DisConnect();
                throw;
            }

        }

        public string RecvString(string EndChar = "\0")//结果带结束符
        {
            byte[] bytes = RecvBytes(EndChar);

            string str = System.Text.Encoding.ASCII.GetString(bytes).TrimEnd('\0');
            return str;
            //return "ss";
        }

        public void SendBytes(byte[] b)
        {
            try
            {
                //发送前清空接收缓存区
                ClearRecvBuffer();
                Socket.Send(b);
            }
            catch
            {
                //DisConnect();
                throw;
            }
        }

        public void SendString(string SendStr)
        {
            if (SendStr == null) return;
            byte[] b = (Encoding.GetEncoding(936).GetBytes(SendStr)).ToArray();
            SendBytes(b);
        }


        public override object Form
        {
            get { return null; }
        }
    }
}
