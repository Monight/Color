--[[
控制器类
--]]
local LOAD_LUA_SPRITE = 
{
     -------------------基类加载-----------------------------
	 "game/core/base_behaviour",
	 "game/core/Lua_base_model",
     "game/core/Lua_view_controller",
     "game/core/Lua_behaviour",
     -------------------UI界面相关脚本加载-------------------
     "game/core/View",
     -------------------UI控制器类加载-----------------------
     "game/modular/core/controller/main_controller",
     -------------------资源管理类加载-----------------------
}

--外部Lua脚本加载
local function LoadLuas(LuasList)
    if LuasList ~= nil then
        for k,v in pairs(LuasList) do
            require (v)
        end
    end
    
    if Global.isEditor and open_view ~= nil then
        open_view()
    else
        start_new_work()
        --startGame()
    end
end
--加载脚本
function controllerInit()
	print(" ----------------  进入加载")
	LoadLuas(LOAD_LUA_SPRITE)
end