function handle(so){
	switch(so.state){
	case "":
		var mssql=plugin.GetPlugIn("报警信息").AddAlarm("test","msg","a,b,c");
		so.SetNextState("访问mssql",3000,"");
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
		so.SetNextState("访问oracle",1000);
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
		so.SetNextState("",1000);
		break;
	}
}

function init(so)
{
	var mssql=plugin.GetPlugIn("连接管理").GetCon("mssql");
	so.SetUserData("mssql",mssql)
	var oracle=plugin.GetPlugIn("连接管理").GetCon("oracle");
	so.SetUserData("oracle",oracle)
}

function finit(so)
{
}