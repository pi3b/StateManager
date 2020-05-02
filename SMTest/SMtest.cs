using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

namespace StateManager
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SMtest : MarshalByRefObject, IState 
    {
        public  object Form
        {
            get { return null; }
        }

        public SMHTTPApi Http;

        string DoHandleRequest(HttpListenerRequest request, string postData)
        {
            JObject jo = new JObject();
            JObject data = new JObject();
            switch (request.RawUrl.Split('?')[0])
            {
                case "/web/ha-mes/user/login":
                    jo["code"] = 20000;
                    data["token"] = "admin-token";
                    jo["data"] = data;
                    return jo.ToString();
                case "/web/ha-mes/user/logout":
                    jo["code"] = 20000;
                    jo["data"] = "success";
                    return jo.ToString();
                case "/web/ha-mes/user/info":
                    jo["code"]=20000;
                    data["roles"]=new JArray("admin");
                    data["introduction"]="超级管理员";
                    data["avatar"]="http://127.0.0.1:666/web/data/avatar.gif";
                    data["name"]="超级管理员";
                    jo["data"]= data;
                    return jo.ToString();
                default:
                    jo["code"]=0;
                    jo["message"]="没有这个数据！";
                    return jo.ToString();
            }
        }

        public void StateFInit(SObject so)
        {;
        }

        public void StateHandle(ref SObject so)
        {
            switch (so.State)
            {
                case "":
                    
                    #region test
		
                    //dynamic TCP=so.Manager.GetSOObject("TCP");
                    //if(TCP.Connected)
                    //{
                    //    TCP.SendString("test");
                    //    try{
                    //        var s=TCP.RecvString("\0");
                    //        so.Status=s;
                    //    }
                    //    catch(Exception E){
                    //        dynamic Alarm = so.Manager.GetSOObject("Alarm");
                    //        Alarm.AddAlarm(so.Name, E.Message, "重试,取消");
                    //        so.RepeatState(5000, E.Message);
                    //        return;
                    //    }
                    //    //alert(s)			
                    //}
                    //else{
                    //    so.Status = "TCP未连接。";
                    //} 
	#endregion

                    if (!Http.ServerActive)
                        Http.ServerStart();
                    so.SetNextState("定时采集", 0);
		            break;
                case "定时采集":
                    JObject jo=new JObject();
                    jo.Add("hour1Count",c);c++;
                    Http.HttpRequest(cloudUrl + "/classes/latheSignal/" + latheSignal_id, jo.ToString(), "PUT");
                    so.RepeatState(5000);
                    break;

            }
        }
        int c = 1;
        string cloudUrl = "https://api2.bmob.cn/1";
        //string devices_id = "jpon777N";
        string latheSignal_id = "a6XcGGGR";
        public void StateInit(SObject so)
        {
            Http = so.SManager.GetSOObject("HttpApi") as SMHTTPApi;
            Http.ServerOnHandleRequests += DoHandleRequest;
        }


    }
}
