function StateHandle(so){
	switch(so.state){
	case "":
		//var mssql=plugin.GetPlugIn("报警信息").AddAlarm("test","msg","a,b,c");
		so.SetNextState("访问mssql",0,"");
		break;
	case "访问mssql":
		var mssql=so.GetUserData("mssql");
		if(mssql.connected){
			var v=mssql.Query("select value from appcmd where app='WMS' and name='ddj1'");
			so.status="读取到:"+v
		}
		else{
			so.status="数据未连接。"
		}
		so.SetNextState("访问oracle",2000);
		break;
	case "访问oracle":
		var oracle=so.GetUserData("oracle");
		if(oracle.connected){
			var v=oracle.ReadStr("select value from appcmd where app='WMS' and name='ddj1'");
			so.status="读取到:"+v
		}
		else{
			so.status="数据未连接。"
		}
		so.SetNextState("访问mssql",2000);
		break;
	}
}

function StateInit(so)
{
	var mssql=so.Manager.GetSO("mssql");
	so.SetUserData("mssql",mssql);
	
	var oracle=so.Manager.GetSO("oracle");
	so.SetUserData("oracle",oracle);
}

function StateFinit(so)
{
}