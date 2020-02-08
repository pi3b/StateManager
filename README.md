# StateManager
StateManager是专为工业智能化设计的状态机框架

![avatar](favicon128.ico)

## StateManager目录结构：
bin 二进制文件，含三方插件等    
--debug    
----Log 用户写日志功能产生的日志，以实例为子目录，以及系统日志    
----Script 用户js/vbs脚本文件    
----HostDemo.exe 类库方式运行状态机的示例宿主程序    
----globaljs 全局js脚本工具代码  
----HslCommunication.dll 一款非常好用的三方通讯连接类库（使用SMConnectionPLCS7.dll和SMConnectionPLCMc.dll时需附带）  
----Interop.MSScriptControl.dll 脚本支持功能  
----Newtonsoft.Json.dll 程序配置json文件的解析工具  
----Oracle.ManagedDataAccess.dll 数据库ORACLE连接工具（使用SMConnectionORACLE.dll时需附带）  
----project.json 状态机配置文件，内含所有配置  
----SMAdmin.dll 状态机实例列表界面（需要显示界面时附带）  
----SMAlarm.dll 报警插件  
----SMAlarm.db  报警插件文件数据库  
----SMConnection.dll  网络连接管理的插件，完成所有网络连接统一管理，自动重连（使用SMConnectionPLCS7.dll、PLCMc、PLCS7、TCP.dll等时需附带）  
----SMConnectionMSSQL.dll  用于连接MSSQL数据库  
----SMConnectionORACLE.dll 用于连接ORACLE数据库  
----SMConnectionPLCMc.dll 用于连接三菱PLC  
----SMConnectionPLCS7.dll 用于连接西门子PLC（如果需要连接OMRON等其他设备可参照此插件源码自行编写dll）  
----SMConnectionTCP.dll  用于连接TCP  
----SMCore.exe  状态机框架核心类库，如果不编写宿主程序的话也可以从这直接运行状态机，从右下角托盘可以打开功能界面 
----System.Data.SQLite.dll  报警插件SMAlarm.dll需要这个，不用报警时可不附带这个 
HostDemo  宿主程序的示例代码
SMConnectionMSSQL  此文件夹为SMConnectionMSSQL源代码  
SMConnectionORACLE  此文件夹为SMConnectionORACLE源代码  
SMConnectionPLCMC  此文件夹为SMConnectionPLCMC源代码  
SMConnectionPLCS7  此文件夹为SMConnectionPLCS7源代码  
StateManager.sln  解决方案  

## StateManager快速上手：
1.直接运行程序目录中的 SMCore.exe。  
2.从右下角托盘图标点右键->执行控制(或连接管理、报警列表)，查看实例列表、连接列表、报警列表的界面。  
3.打开Script目录的js/vbs等文件，修改其中脚本内容，然后在“执行控制”相应的行点击右键->复位，观察执行效果。  
4.更多功能，可加入官方QQ交流群学习：244671697  


