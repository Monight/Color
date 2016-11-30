
--  总的控制器 
local  LOADD_LUA_SPRITE = 
{
	-- 基类的加载
	"game/core/base_behaviour",
	"game/core/lua_view_controller",	
	"game/core/lua_behaviour",

	--UI界面相关脚本加载
    "game/core/view",

    "game/modular/controller/test_controller"
}

--初始化

function ContainersInit()
	print("wori")
    for k,v in pairs(LOADD_LUA_SPRITE) do
        require(v)
    end
end


--外部Lua脚本加载
local function LoadLuas(LuasList)
    if LuasList ~= nil then
        for k,v in pairs(LuasList) do
            require (v)
        end
    end
    
   --[[ if Global.isEditor and open_view ~= nil then
        open_view()
    else
        start_new_work()
        --startGame()
    end --]]
end
