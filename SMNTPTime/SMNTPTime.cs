using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace StateManager
{
    public struct SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;

        /// <summary>
        /// 从System.DateTime转换。
        /// </summary>
        /// <param name="time">System.DateTime类型的时间。</param>
        public void FromDateTime(DateTime time)
        {
            wYear = (ushort)time.Year;
            wMonth = (ushort)time.Month;
            wDayOfWeek = (ushort)time.DayOfWeek;
            wDay = (ushort)time.Day;
            wHour = (ushort)time.Hour;
            wMinute = (ushort)time.Minute;
            wSecond = (ushort)time.Second;
            wMilliseconds = (ushort)time.Millisecond;
        }
        /// <summary>
        /// 转换为System.DateTime类型。
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
        }

        // 获取网络时间
        public void FromNTPServer(string NTPServerIP="ntp1.aliyun.com")
        {
            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];
            // Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; // LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            IPAddress ip;
            if (!IPAddress.TryParse(NTPServerIP, out ip))
            {
                IPAddress[] ipaddresses = Dns.GetHostEntry(NTPServerIP).AddressList;
                foreach (IPAddress ipaddr in ipaddresses)
                {
                    if (ipaddr.ToString()=="::1") continue;
                    ip = ipaddr;
                    break;
                }
            }
            // The UDP port number assigned to NTP is 123
            IPEndPoint ipEndPoint = new IPEndPoint(ip, 123);

            // NTP uses UDP
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                socket.Connect(ipEndPoint);
                // Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;
                socket.Send(ntpData);
                socket.Receive(ntpData);
            }
            finally
            {
                socket.Close();
            }
            // Offset to get to the "Transmit Timestamp" field (time at which the reply 
            // departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;
            // Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
            // Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
            // Convert From big-endian to little-endian
            intPart = swapEndian(intPart);
            fractPart = swapEndian(fractPart);
            ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000UL);

            // UTC time
            DateTime webTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(milliseconds);
            // Local time
            DateTime Loca = webTime.ToLocalTime();
            FromDateTime(Loca);
        }

        // 小端存储与大端存储的转换
        private uint swapEndian(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
            ((x & 0x0000ff00) << 8) +
            ((x & 0x00ff0000) >> 8) +
            ((x & 0xff000000) >> 24));
        }

        public bool SetLocalTime()
        {
            return SYSTEMTIME.SetLocalTime(ref this);
        }

        public void FromLocalTime()
        {
            SYSTEMTIME.GetLocalTime(ref this);
            //等同于下面的方式，不过系统API更直接
            //DateTime t = DateTime.Now;
            //st.FromDateTime(t);
        }

        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME Time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SYSTEMTIME Time);

        public delegate  void delOnPrint(string Str);
        public static void StartNTPServer(delOnPrint OnPrint)
        {
            RegistryKey key = Registry.LocalMachine;
            try
            {
                RegistryKey keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\Parameters", true);
                Console.WriteLine(keyitem.GetValue("Type").ToString());
                keyitem.SetValue("Type", "NTP");
                keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\Config", true);
                Console.WriteLine(keyitem.GetValue("AnnounceFlags").ToString());
                keyitem.SetValue("AnnounceFlags", 5);
                keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\TimeProviders\\NtpServer", true);
                Console.WriteLine(keyitem.GetValue("Enabled").ToString());
                keyitem.SetValue("Enabled", 1);

            }
            finally
            {
                key.Close();
            }

            //通过cmd来执行net start
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = false;   // 是否使用外壳程序 
            process.StartInfo.CreateNoWindow = true;   //是否在新窗口中启动该进程的值 
            process.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
            process.StartInfo.RedirectStandardOutput = true;  //重定向输出流 
            process.StartInfo.RedirectStandardError = true;  //重定向错误流 
            //process.OutputDataReceived += new DataReceivedEventHandler(OnDataReceive);
            //process.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            process.StartInfo.FileName = "cmd.exe";//待输入的执行文件路径

            process.Start();                         // 启动程序

            process.StandardInput.AutoFlush = true;

            process.StandardInput.WriteLine("net stop w32time");
            process.StandardInput.WriteLine("net start w32time");
            process.StandardInput.WriteLine("netsh advfirewall firewall add rule name=\"NTPSERVER\" dir=in action=allow protocol=UDP localport=123");

            process.StandardInput.WriteLine("exit");

            StreamReader reader = process.StandardOutput;//获取exe处理之后的输出信息

            string curLine = reader.ReadLine(); //获取错误信息到error
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(curLine))
                {
                    Console.WriteLine(curLine);
                    OnPrint(curLine);
                }
                curLine = reader.ReadLine();
            }
            reader.Close(); //close进程

            process.WaitForExit();  //等待程序执行完退出进程
            process.Close();



            //net stop w32time && net start w32time
            //netsh firewall add portopening protocol = UDP port =123 name = NTPSERVER
        }
        public static void StopNTPServer(delOnPrint OnPrint)
        {
            RegistryKey key = Registry.LocalMachine;
            try
            {
                RegistryKey keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\Parameters", true);
                Console.WriteLine(keyitem.GetValue("Type").ToString());
                keyitem.SetValue("Type", "NTP");
                keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\Config",true);
                Console.WriteLine(keyitem.GetValue("AnnounceFlags").ToString());
                keyitem.SetValue("AnnounceFlags",10);
                keyitem = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\TimeProviders\\NtpServer", true);
                Console.WriteLine(keyitem.GetValue("Enabled").ToString());
                keyitem.SetValue("Enabled", 0);

            }
            finally
            {
                key.Close();
            }

            //通过cmd来执行net start
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = false;   // 是否使用外壳程序 
            process.StartInfo.CreateNoWindow = true;   //是否在新窗口中启动该进程的值 
            process.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
            process.StartInfo.RedirectStandardOutput = true;  //重定向输出流 
            process.StartInfo.RedirectStandardError = true;  //重定向错误流 
            //process.OutputDataReceived += new DataReceivedEventHandler(OnDataReceive);
            //process.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            process.StartInfo.FileName = "cmd.exe";//待输入的执行文件路径

            process.Start();                         // 启动程序

            process.StandardInput.AutoFlush = true;

            process.StandardInput.WriteLine("net stop w32time");
            //process.StandardInput.WriteLine("net start w32time");
            process.StandardInput.WriteLine("netsh advfirewall firewall del rule name=\"NTPSERVER\" dir=in protocol=UDP localport=123"); 

            process.StandardInput.WriteLine("exit");

            StreamReader reader = process.StandardOutput;//获取exe处理之后的输出信息

            string curLine = reader.ReadLine(); //获取错误信息到error
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(curLine))
                {
                    Console.WriteLine(curLine); 
                    OnPrint(curLine);
                }
                curLine = reader.ReadLine();
            }
            reader.Close(); //close进程

            process.WaitForExit();  //等待程序执行完退出进程
            process.Close();



            //net stop w32time && net start w32time
            //netsh firewall add portopening protocol = UDP port =123 name = NTPSERVER
        }
    }
 
}
