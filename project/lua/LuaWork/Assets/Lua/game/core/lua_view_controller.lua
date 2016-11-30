---控制器的基類

lua_view_controller = newclass(base_behavior)

-- 初始化数据
function lua_view_controller:GameInitData(modelluaObj)
	self.LuaObjs = {}  --  不知道是干嘛的
	self.modelluaObj = modelluaObj
end

--初始化
function lua_view_controller:GameControllerInit(className,gameobject,insID,cacheObjs,cachePrefabs)
	local  class = _G[className]
	local  Obj = class.new()
	Obj:init(gameobject,cachePrefabs,cacheObjs,insID)
	Obj:initModel(self.modelluaObj)
	self.LuaObjs[insID] = Obj
end

--  回调
function lua_view_controller:UnityToLuaClick(insID,clickName)
	local LuaObj = self.LuaObjs[insID]
	if LuaObj ~=  nil then 
		 if clickName == UNITY_TO_LUA_CLICK.OnEnable  then
		 	self.onEnable(luaObj)
		 elseif clickName == UNITY_TO_LUA_CLICK.Start then
		 	self.start(LuaObj)
		 elseif clickName == UNITY_TO_LUA_CLICK.OnDisable then
		 	self.onDisable(LuaObj)
		 elseif clickName == UNITY_TO_LUA_CLICK.Awake then
		 	self.awake(luaObj)
		 elseif clickName == UNITY_TO_LUA_CLICK.OnDestroy then
		 	self:onDestroy(luaObj)
		 end
    else
    	error("错误 ："..insID .. "脚本名字 ：" ..clickName )
    end
end

function Lua_view_controller:awake(luaObj)
	luaObj:awake()
end

function Lua_view_controller:onEnable(luaObj)
	luaObj:onEnable()
end

function Lua_view_controller:start(luaObj)
	luaObj:start()
end

function Lua_view_controller:onDisable(luaObj)
	luaObj:onDisable()
end

function Lua_view_controller:onDestroy(luaObj)
	luaObj:onDestroy()
end

-- 通过id 去找到脚本对象
function Lua_view_controller:GetLuaObjFormInsId(insID)
	local luaObj = self.LuaObjs[insID]
	if luaObj ~= nil then
		return luaObj
	end
	return nil
end

--通过 游戏对象 去找到 脚本的对象
function Lua_view_controller:GetLuaObjFormObj(gameObject)
	for k,v in pairs(self.LuaObjs) do
		if v.gameObject == gameObject then
			return v
		end
	end
	return nil
end