using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMtest : MarshalByRefObject, IState 
    {
        public  object Form
        {
            get { return null; }
        }


        public void StateFInit(SObject so)
        {;
        }

        public void StateHandle(ref SObject so)
        {
            switch (so.State)
            {
                case "":
		            dynamic TCP=so.Manager.GetSOObject("TCP");
		            if(TCP.Connected)
		            {
			            TCP.SendString("test");
			            try{
				            var s=TCP.RecvString("\0");
				            so.Status=s;
			            }
			            catch(Exception E){
                            dynamic Alarm = so.Manager.GetSOObject("Alarm");
                            Alarm.AddAlarm(so.Name, E.Message, "重试,取消");
                            so.RepeatState(5000, E.Message);
				            return;
			            }
			            //alert(s)			
		            }
		            else{
                        so.Status = "TCP未连接。";
		            }
		            break;

            }
            //return null;
            Console.WriteLine(System.Threading.Thread.GetDomain().FriendlyName+"2");
        }

        public void StateInit(SObject so)
        {
        }


    }
}
