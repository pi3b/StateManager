sub handle(so)
	select case so.state
	case "检测网络"
		so.SetNextState "脚本检测网络",2000,""
	case "脚本检测网络"
		so.SetNextState "脚本完成",2000,"" 
	case "脚本完成"
		so.SetNextState "",2000,""
	end select
end sub

sub init(so)

end sub

sub finit(so)

end sub