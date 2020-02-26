function StateHandle(so){//状态处理函数，固定格式
	switch(so.State){//判断状态	
	case "":	//如果状态为空
		so.SetNextState("访问TCP",0,"");//那么将在下一扫描周期进入状态：访问西门子PLC
		break;	
		
	case "访问西门子PLC":
		var PLC_S7=so.Manager.GetSOObject("PLC_S7");//获取PLC对象
		if(PLC_S7.Connected){//如果已连接
			var v=PLC_S7.ReadBool("M100"); //从PLC读取线圈M100
			PLC_S7.Write("M100",!v); //数据取反后写入PLC
			so.Status=v; //显示到界面上的状态详情
		}
		else{			
			so.Status="PLC_S7未连接。"//显示到界面上
		}
		so.SetNextState("访问西门子PLC",1000,"");//进入下一状态：访问TCP，延时1秒执行
		break;
			
	case "访问mssql": 
			var mssql=so.Manager.GetSOObject("mssql");//获取mssql对象
			if(mssql.connected){
				var v=mssql.ReadFirstInt("select TESTVALUE from Test where TESTNAME='测试数据'");//从sql server数据库读取一个数据
				so.status="从数据库读取到:"+v;//显示到界面上
				v=v+1;
				mssql.Execute("update Test set TESTVALUE ="+ v +" where  TESTNAME='测试数据'")//加1后回写到数据库
			}
			else{
				so.status="数据库未连接。"
			}
		so.SetNextState("访问mssql",2000);
		break;
		
	case "访问TCP":	
		var TCP=so.Manager.GetSOObject("TCP");//获取TCP对象
		if(TCP.Connected)
		{
			try{
				TCP.SendString("请求数据！");//向TCP设备请求数据
			}
			catch(E){
			}
		}
		else{			
			so.Status="TCP未连接。";
		}
		so.SetNextState("访问TCP-接收",1000,"");
		break;
	case "访问TCP-接收":
		var TCP=so.Manager.GetSOObject("TCP");//获取TCP对象
		if(TCP.Connected)
		{
			try{
				var data=TCP.RecvString("!");//同步方式读取数据
				so.Status="收到的数据："+data;//显示到界面上
				TCP.SendString("已经收到（"+data+"）下次聊。");//将数据返回给TCP设备表示收到
			}
			catch(E){//超时等异常情况
				var Alarm = so.Manager.GetSOObject("Alarm");//获取Alarm对象
				Alarm.AddSOAlarm(so, E.message, "重试,重试（再次发送请求）,跳过");//添加一条报警内容,提供三个处理选项
				so.SetNextState("访问TCP-异常处理",0);
				return;
			}
		}
		else{
			so.Status="TCP未连接。";
		}
		so.SetNextState("访问TCP",5000,"");
		break;
	case "访问TCP-异常处理":
		var Alarm = so.Manager.GetSOObject("Alarm");//获取Alarm对象
		var Reply = Alarm.ReadAlarmReply(so.Name);
		if(Reply=="重试")
		{
			so.SetNextState("访问TCP-接收",0,"正在重试");
		}
		else if(Reply=="重试（再次发送请求）")
		{
			so.SetNextState("访问TCP",0,"正在重试");
		}
		else if(Reply=="跳过")
		{
			so.SetNextState("",0,"正在重试");
		}
		else
			so.RepeatState(1000,"等待人工处理报警");//重复当前状态，延时5秒执行
		break;	
	}
}

function StateInit(so)
{
}

function StateFinit(so)
{
}