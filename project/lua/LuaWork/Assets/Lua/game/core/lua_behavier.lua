--[[
	接收unity 脚本事件的回调  -- 入口 ？
	
--]]

-- 非脚本器脚本对象表
local luaObj = {}
--控制器
local  luaController = {}
--数据类对象
local  luaModels = {}

--界面view类 对应控制器的注册
local  VIEW_CONTROL_ENROLL =
{
	test_view = "test_conttroller",
	main_view = "main_controller"
}


--数据类
MODEL_CONTROL_ENROLL = 
{

	test_controller = "test_model",
    main_controller = "main_model",
}

---unity  初始化以及回调方法的注册
UNITY_TO_LUA_CLICK = 
{
	Awake     = "awake",
	OnEnable  = "onEnable",
	Start     = "start",
	OnDisable = "onDisable",
	OnDestroy = "onDestroy"	
}

--游戏开始时的初始化
MODEL_START_INIT = 
{

	"main_model",	
}




function  awake(objs, prefabs, objsLenght,prefabsLenght,gameObject,insID,className)
	local gameobjectLable = {};
	for i=0,objsLenght-1 do
		local  ss = objs[i]
		if ss == nil then
			error(" objs 对象时空的东西".. i)
			return
		end
	    gameobjectLable[objs.name] = objs
    end

    local prefabLable = {};
	for i=0,prefabsLenght-1 do
		local  ss = prefabs[i]
		if ss== nil then
			error(" prefabs 对象时空的东西"..i);
			return    
		end
		gameobjectLable[prefabs.name] = prefabs;
    end

    ------------------------------------------- 修改一下

    --判断控制器里面有没有   

    local  m_cont = VIEW_CONTROL_ENROLL[className] -- className 传过来的参数 

    if m_cont == nil then
    	local class = _G[className]
    	local luaObj = class.new()
	    luaObj:init(gameobjectLable,prefabLable,gameObject,insID)
	    luaObj[insID] = luaObj;
	    luaObj:awake()
    else
    	local  obj = luaController[m_cont]
    	if obj == nil then -- 数据控制
    		local  modelName = MODEL_CONTROL_ENROLL[m_cont]
    		local  modelObj = luaModels[modelName]
    		if modelObj == nil then
    			local class = _G[modelName]
    			modelObj = class.new()
    			modelObj:ModeInit() -- 調用初始化的東西 
    			luaModels[modelName] = modelObj
    		end

    		class = _G[m_cont]
    		obj =class.new()
    		luaController[m_cont] = obj
    		obj:GameInitData(modelObj)

    	end
      Obj:GameControllerInit(className, gameObject, insID, cacheObjs, cachePrefabs)
      Obj:UnityToLuaClick(insID, UNITY_TO_LUA_CLICK.Awake)
    end 
 
 


    
end

-- 通过 view 找control  通过control 找model
function start(insID,className)
	local  luaObj = luaObj[insID] --  从的是没
	if luaObj ~= nil then
		luaObj:start()
    else
    	local  name  = VIEW_CONTROL_ENROLL[className]
    	if name ~=nil and luaController[name] ~= nil then
    		luaController[name]:UnityToLuaClick(insID,UNITY_TO_LUA_CLICK.Start)
    	else
    		error(insID..+" start view " .. className.. + "---- 没有找到该脚本对象")
	end


	
end

function onEnable(insID,className)
	local  luaObj = luaObj[insID]
	if LuaObj ~= nil then
		luaObj:onEnable()
	else
		local name = VIEW_CONTROL_ENROLL[className]
        if name ~= nil and luaController[name] ~= nil then
             luaController[name]:UnityToLuaClick(insID, UNITY_TO_LUA_CLICK.OnEnable)
        else
            error(insID.."  onEnable  View  "..className.."  ---->  没有查找到该脚本对象")
        end
    end

end

function onDisable(insID,className)
   local luaObj = LuaObj[insID]

    if luaObj ~= nil then
        luaObj:onDisable()
    else
        local name = VIEW_CONTROL_ENROLL[className]
        if name ~= nil and luaController[name] ~= nil then
            luaController[name]:UnityToLuaClick(insID, UNITY_TO_LUA_CLICK.OnDisable)
        else
            error(insID.."   onDisable  View  "..className.."  ---->  没有查找到该脚本对象")
        end
    end
end

function onDestroy(insID,className)
	local  luaObj = luaObj[insID]
	if luaObj ~= nil then 
		luaObj.isDestroy = true
		luaObj:onDestroy()
	else
		local name = VIEW_CONTROL_ENROLL[className]
        if name ~= nil and luaController[name] ~= nil then
            luaController[name]:UnityToLuaClick(insID, UNITY_TO_LUA_CLICK.OnDestroy)
        else
            error(insID.."   OnDestroy  View  "..className.."  ---->  没有查找到该脚本对象")
        end
	end
	luaObj[insID] = nil
end

 --  通过游戏对象获取脚本对象
function find_LuaObject_by_object(gameObject)
	for k,v in pairs(luaObj) do
		if v ~=nil and not v.isDestroy and v.gameObject == gameObject then
			return v
		end
	end
	 ocal luaObj
    for k,v in pairs(luaController) do
        luaObj = v:GetLuaObjFormObj(gameObject)
        if luaObj ~= nil then
          return luaObj
        end
    end
    return nil
end

 -- 通过唯一游戏ID 获取游戏对象脚本
function  find_LuaObject_by_Id(insID)
	local  luaObj = luaObj[insID]
	if luaObj ~= nil then
		return luaObj
	end
    for k,v in pairs(luaController) do
        luaObj = v:GetLuaObjFormInsId(insID)
        if luaObj ~= nil then
          return luaObj
        end
    end
    return nil
end

