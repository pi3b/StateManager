function StateHandle(so){
	switch(so.state){
	case "":	
		so.Setnextstate("测试TCP",1);
		break;	
	case "测试TCP":	
		var TCP=so.GetUserData("TCP");	
		if(TCP.connected)
		{
			//TCP.BufferStr="";
			TCP.SendString("test");
			//var s=TCP.RecvString("\0");
			var s=TCP.AsyncReadString;
			so.status=s;
			//alert(s)			
		}
		else{			
			so.status="TCP未连接。"
		}
		so.Setnextstate("测试西门子PLC",1000);
		break;
	case "测试西门子PLC":
		var PLC_S7=so.GetUserData("PLC_S7");	
		if(PLC_S7.Connected){
			var v=PLC_S7.ReadInt16("DB10.20");
			so.status=v;
			//PLC_S7.Write("M100",!v); //取反写入PLC
		}
		else{			
			so.status="PLC_S7未连接。"
		}
		so.Setnextstate("测试三菱PLC",1000);
		break;
	case "测试三菱PLC":
		var PLC_MC=so.GetUserData("PLC_MC");	
		if(PLC_MC.Connected){
			var v=PLC_MC.ReadInt16("D1005");
			so.status=v;
			if(v==1)
			{v=0}
			else {v=1;}
			PLC_MC.Write("D1005",v); //取反写入PLC
		}
		else{			
			so.status="PLC_MC未连接。"
		}
		so.Setnextstate("测试TCP",1000);
		break;
	}
}

function StateInit(so)
{
	var TCP=so.Manager.GetSO("TCP");
	so.SetUserData("TCP",TCP);
	
	var PLC_S7=so.Manager.GetSO("PLC_S7");
	so.SetUserData("PLC_S7",PLC_S7);
	
	var PLC_MC=so.Manager.GetSO("PLC_MC");
	so.SetUserData("PLC_MC",PLC_MC);
}

function StateFinit(so)
{
}