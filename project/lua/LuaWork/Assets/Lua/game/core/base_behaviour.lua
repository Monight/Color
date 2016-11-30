--require "System/class"
--界面基类

base_behaviour = newclass()
local  mGetAllComponents = GetAllComponets

function  base_behaviour:init(objs, prefabs,gameobject,insID)
	self.gameobject = gameobject
	self.transform = gameobject.transform
	self.name = gameobject.name
	self.insID = insID;
	self.objs = objs;
	self.prefabs = prefabs;

end

function base_behaviour:initModel(modelLuaObj)
	self.modelLuaObj = modelLuaObj
end


function  base_behaviour:awake()


	

end

function base_behaviour:start()
	
end

function base_behaviour:onEnable()
	
end

function base_behaviour:onDisable()
	
end

function base_behaviour:onDestroy()
	
end
