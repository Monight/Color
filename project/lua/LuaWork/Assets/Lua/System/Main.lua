UpdateBeat = Event("Update", true)
LateUpdateBeat = Event("LateUpdate", true)
CoUpdateBeat = Event("CoUpdate", true)
FixedUpdateBeat = Event("FixedUpdate", true)

 require "containers" 控制器的加载 

--require "game/common/controller"  -- 控制器的加载

 -- TODO： 控制器的加载 后面要进行更改

function Main()
	Time:Init()
	ContainersInit()	 --控制器更改
	--测试协同
	--controllerInit()
	--coroutine.start(TestCo)
	--coroutine.start(TestCo2)
end

function Update(deltatime, unscaledDeltaTime)
	Time:SetDeltaTime(deltatime, unscaledDeltaTime)
	UpdateBeat()
end

function LateUpdate()
	LateUpdateBeat()
	CoUpdateBeat()
end

function FixedUpdate(fixedTime)
	Time:SetFixedDelta(fixedTime)
	FixedUpdateBeat()
end

function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0
end