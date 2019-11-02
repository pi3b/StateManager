# StateManager
StateManager是专为工业智能化设计的状态机框架

![avatar](favicon128.ico)

## StateManager的特点介绍：
https://pi3b.github.io

## StateManager目录结构：
bin 二进制文件，含三方插件等    
--debug    
----Log 用户写日志功能产生的日志，以实例为子目录，以及系统日志    
----Logic 用户逻辑插件，或用户js/vbs脚本文件    
----Demo.exe 类库方式运行状态机的示例宿主程序    
----Demo.pdb 随Demo.exe附带   
----globaljs 全局js脚本工具代码  
----HslCommunication.dll 一款非常好用的三方通讯连接类库（使用SMConnectionPLCS7.dll和SMConnectionPLCMc.dll时需附带）  
----Interop.MSScriptControl.dll 脚本支持功能  
----Newtonsoft.Json.dll 程序配置json文件的解析工具  
----Oracle.ManagedDataAccess.dll 数据库ORACLE连接工具（使用SMConnectionORACLE.dll时需附带）  
----project.so 状态机配置文件，内含实例配置、插件配置等  
----SMAdminForm.dll 状态机实例列表界面（需要显示界面时附带）  
----SMAdminForm.pdb 随SMAdminForm.dll附带  
----SMAlarm.dll 报警插件  
----SMAlarm.db  报警插件文件数据库  
----SMAlarm.dll.config 随SMAlarm.dll附带  
----SMAlarm.pdb  随SMAlarm.dll附带  
----SMConnection.dll  网络连接管理的插件，完成所有网络连接统一管理，自动重连（使用SMConnectionPLCS7.dll、PLCMc、PLCS7、TCP.dll等时需附带）  
----SMConnection.pdb  随SMConnection.dll附带  
----SMConnectionMSSQL.dll  用于连接MSSQL数据库  
----SMConnectionMSSQL.pdb  
----SMConnectionORACLE.dll 用于连接ORACLE数据库  
----SMConnectionORACLE.pdb  
----SMConnectionPLCMc.dll 用于连接三菱PLC  
----SMConnectionPLCMc.pdb  
----SMConnectionPLCS7.dll 用于连接西门子PLC（如果需要连接OMRON等其他设备可参照此插件源码自行编写dll）  
----SMConnectionPLCS7.pdb  
----SMConnectionTCP.dll  用于连接TCP  
----SMConnectionTCP.pdb  
----StateManager.exe  状态机框架核心类库，如果不编写宿主程序的话也可以从这直接运行状态机，从托盘打开功能界面  
----StateManager.pdb  
----System.Data.SQLite.dll  报警插件SMAlarm.dll需要这个，不用报警时可不附带这个  
----System.Data.SQLite.pdb  
HostDemo  宿主程序的示例  
SMConnectionMSSQL  生成SMConnectionMSSQL.dll插件的代码  
SMConnectionORACLE  生成SMConnectionORACLE.dll插件的代码  
SMConnectionPLCMC  生成SMConnectionPLCMC.dll插件的代码  
SMConnectionPLCS7  生成SMConnectionPLCS7.dll插件的代码  
StateManager.sln  解决方案  

## StateManager快速上手：
1.直接运行程序目录中的StateManager.exe。  
2.从托盘图标点右键->执行控制(或连接管理、报警列表)，查看实例列表、连接列表、报警列表的界面。  
3.打开Logic目录的js/vbs等文件，修改其中脚本内容，然后在“执行控制”相应的行点击右键->复位，观察执行效果。  
4.更多功能，可加入官方QQ交流群学习：244671697  


