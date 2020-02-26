function StateHandle(so){
	switch(so.State){
	case "":	
		so.SetData("v",1);
		so.SetNextState("加1",1000);//延时1秒后进入下一周状态”加1“
		alert("确定后开始。。。");
		so.Log("开始..");
		break;			
	case "加1":
		var v=so.GetData("v");
		if(v>10)
		{
			so.Log("完成");
			so.OpenLogFile();
			alert("完成");
			so.SetNextState("完成",0);
			return;
		}
		so.Log("v="+v);
		v = v + 1;
		so.SetData("v",v);
		so.RepeatState(10);//延时10毫秒后重复当前状态
		break;	
	case "完成":
		so.Auto=false;
		break;
	}
}

function StateInit(so)
{
}

function StateFinit(so)
{
}