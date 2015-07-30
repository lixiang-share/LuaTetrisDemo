require "Common/functions"
require "Tetris/BlockeController";



GameManager = {};
local this = GameManager;


local Input = UnityEngine.Input;
local KeyCode = UnityEngine.KeyCode;
local Application = UnityEngine.Application;

gameState = {Playing = 0 ,Suspend = 1, Failed = 2,  Win = 3};

--游戏默认当前状态状态暂停
curState = gameState.Suspend;

--游戏默认上一个状态
local lastSate = curState;

function this.Start()
	
--	print(gameState.Suspend);
end

--用户按下esc键就结束游戏
function this.Update()
	if Input.GetKeyDown(KeyCode.Escape) then
		--print("Application.Quit()");
		--print(Application.dataPath );

		Application.Quit();
	end

	handleGameState();
end

--提供给外部调用的更改游戏状态的方法
function handleGameState( )
	if isWin then
		curState = gameState.Win;
	end
	if isFailed then
		curState = gameState.Failed;
	end
end



--开始游戏逻辑
function startGame( ... )
	--print("GameManager Start()");
	curState = gameState.Playing;
	generateBlocke();
	playerCurScore = 0;
	isWin = false;
	isPlaying = true;
	isFailed = false;
--	print(curState);
	--print("gameState : "..curState);
end

--重新开始
function reStartGame()
	print("function reStartGame( ... )");
	InitMatrixs();
	startGame();
end