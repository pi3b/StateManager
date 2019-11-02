function handle(so){
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
		so.Setnextstate("测试西门子PLC",1);
		break;
	case "测试西门子PLC":
		var PLC_S7=so.GetUserData("PLC_S7");	
		if(PLC_S7.Connected){
			var v=PLC_S7.ReadBool("M100");
			so.status=v;
			PLC_S7.Write("M100",!v); //取反写入PLC
		}
		else{			
			so.status="PLC未连接。"
		}
		so.Setnextstate("",1);
		break;
	case "测试三菱PLC":
		var PLC_MC=so.GetUserData("PLC_MC");	
		if(PLC_MC.Connected){
			var v=PLC_MC.ReadInt("D100");
			so.status=v;
			v=v+1;
			PLC_MC.Write("D100",v); //取反写入PLC
		}
		else{			
			so.status="PLC未连接。"
		}
		so.Setnextstate("",1);
		break;
	}
}

function init(so)
{
	var PLC_S7=plugin.GetPlugIn("连接管理").GetCon("PLC_S7");
	so.SetUserData("PLC_S7",PLC_S7)
	var PLC_MC=plugin.GetPlugIn("连接管理").GetCon("PLC_MC");
	so.SetUserData("PLC_MC",PLC_MC)
	
	var TCP=plugin.GetPlugIn("连接管理").GetCon("TCP");
	so.SetUserData("TCP",TCP);
	
}

function finit(so)
{
}