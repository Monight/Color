
--每一个界面的控制  是继承于 lua_view_controller

test_controller = newclass(lua_view_controller)

require "game/modul/controller/test_controller"


function test_controller:awake()
	print("awake ------------------------")
end

function test_controller:onEnable()
	-- body
end

function test_controller:start()
	print("--------------- start");
end

function test_controller:onDisable()
	-- body
end