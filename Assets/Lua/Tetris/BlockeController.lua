--require "Common/GUIShow";
require "System/Math";
--require "Tetris/GameManager";
require "Tetris/AudioController";
--游戏中方块的控制逻辑
BlockeController = {};
local this = BlockeController;

local Random = System.Random;
local Time = UnityEngine.Time;
local Input = UnityEngine.Input;
local KeyCode = UnityEngine.KeyCode;
local RuntimePlatform = UnityEngine.RuntimePlatform;
local  TouchPhase = UnityEngine.TouchPhase;

--保存游戏中方块的矩阵，1：有方块，，0：无方块
gameMatrix={};
--保存游戏中对应方块的颜色信息
--游戏中共有五中方块的贴图，代表了五中颜色，贴图的引用是从C#层的LuaCompenet中传递过来的
colorMatrix={};
--颜色表，共七种方块的颜色，从1开始索引到7,
colorTable = {};
--游戏中边界的宽
 width = 15;
--边界的高
 height = 20;

--玩家是胜利
isWin = false;
--玩家当前分数,,,没消一行增加100分，，，消50行玩家胜出
playerCurScore = 0;

isPlaying = false;

isFaild = false;

 --一共四种方块类型	1 : I   2:田  3:L   4:T  		其中方块无法变换
 local curBlockeType = 0;

--每个下落的实体都只有4个方块组成，这里用4个坐标去表示
blockePos = {{x=0 , y=0 , color=1} , {x=0 , y=0 , color=1} , {x=0 , y=0 ,color=1} , {x = 0 , y= 0 , color=1}};

function this.Awake( )
	InitMatrixs();
	
end
--初始化游戏中颜色贴图表，便于和colorMatrix对应
function InitColorTable()
	colorTable[1] = this.blue;
	colorTable[2] = this.cyan;
	colorTable[3] = this.green;
	colorTable[4] = this.orange;
	colorTable[5] = this.purple;
	colorTable[6] = this.red;
	colorTable[7] = this.yellow;

end
--初始化游戏中的两个Matrix
function  InitMatrixs( )
	for i=1 , height , 1 do
		gameMatrix[i] = {};
		colorMatrix[i] = {};
		for j=1 , width , 1 do
			gameMatrix[i][j] = 0;
			colorMatrix[i][j] = 0;
		end
	end
end

function this.Start( )
	InitColorTable();
end

local moveDownInterval = 0;
local moveDownRate = 0.5;

local inputInterval = 0;
local inputRate = 0.1;

local dir = {left = 0 , right = 1 , dowm = 2};

local nextState = {{x=0 , y=0 } , {x=0 , y=0 } , {x=0 , y=0 } , {x = 0 , y= 0}};
function this.FixedUpdate( )
	--固定频率使得方块向下移动
	moveDownInterval = moveDownInterval-Time.deltaTime;
	if(moveDownInterval < 0)then
		moveDown();
		moveDownInterval = moveDownRate;
	end


	if Application.platform == RuntimePlatform.WindowsPlayer or Application.platform == RuntimePlatform.WindowsEditor then
		InputOnWin();
	else
		InputOnMobilePhone();
	end
	
	
end

local endinterval = 0.2;
function InputOnMobilePhone( )
		endinterval = endinterval-Time.deltaTime;
        if endinterval < 0 then
        	if Input.touchCount > 0 then
            	local vect = Input.GetTouch(0).deltaPosition;
            	if (math.abs(vect.x) > math.abs(vect.y))then
                	if vect.x > 0 then
                		moveRigtht();
                	else
                		moveLeft();
              	  end
          	  	else
            		if vect.y < 0 then 
            			moveDown();
            		end
            		if vect.y > 0 then
            			rotate();
            		end
            	end
       		end
       		endinterval = 0.2;
        end
end


function InputOnWin( )
	--用户输入控制，，美妙最多相应5次用户输入

	local isLeft = Input.GetKey(KeyCode.A) or Input.GetKey(KeyCode.LeftArrow);
	local isRight = Input.GetKey(KeyCode.D) or Input.GetKey(KeyCode.RightArrow);
	local  isDown  = Input.GetKey(KeyCode.S) or Input.GetKey(KeyCode.DownArrow);
	local  isUp = Input.GetKey(KeyCode.W) or Input.GetKey(KeyCode.UpArrow);


	inputInterval  = inputInterval - Time.deltaTime;
	if(inputInterval < 0)then
		move(isLeft , isRight , isDown , isUp);
		inputInterval = inputRate;
	end
end



function move( isLeft , isRight , isDown , isUp)
	--TODO : 此处应配置输入管理器


	if( isLeft )then
		moveLeft();
	elseif( isRight )then
		moveRigtht();
	elseif( isDown )then
		moveDown();
	elseif( isUp) then 
		rotate();
	end
end

--旋转方块..每次90度顺时针旋转
function rotate(  )
	if(curBlockeType == 2)then	--田型方块无法旋转
		return;
	end
	--print("rotate")
	--旋转公式：x2 = y0+x0-y1     y2 = y0 + x1 - x0  --此处旋转点默认为方块实体的第二个坐标点
	copyTable(nextState , blockePos);
	for i=1,4 do
		--print("index  :  " .. i .. "  旋转前  ：  x : " .. blockePos[i].x .."  y : " ..blockePos[i].y);
	end
	for i=1,4 do
		if( i ~= 2)then 
			local x1  = nextState[i].x;	--此处一定要保存需要旋转点的x和y的值，，否则当第一句旋转执行完成会就改变了x值，造成第二句旋转出错
			local y1 = 	nextState[i].y;
			nextState[i].x = nextState[2].y + nextState[2].x - y1;
			nextState[i].y = x1 + nextState[2].y - nextState[2].x;
		end
		--print("index  :  " .. i .."旋转后   ： x : " .. blockePos[i].x .."  y : " ..blockePos[i].y);
	end
	if(detectCollsion(nextState , false) == 1)then
		copyTable(blockePos , nextState);
	end
end

--方块左移
function moveLeft( )
	playVedio_move();
	copyTable(nextState , blockePos);
	for i=1,4 do
		nextState[i].x = nextState[i].x-1;
	end
	if(detectCollsion(nextState , false) == 1)then
		copyTable(blockePos , nextState);
	end
end

--方块右移
function moveRigtht( )
	playVedio_move();
	for i=1,4 do
		nextState[i].x = nextState[i].x+1;
	end
	if(detectCollsion(nextState , false) == 1)then
		copyTable(blockePos , nextState);
	end
end



--固定频率下移，当用户按下向下的方向键时，加速下移
function moveDown( )
	--游戏不是正在进行中
	if not isPlaying then
		return;
	end

	copyTable(nextState , blockePos);
	for i=1,4 do
		nextState[i].y = nextState[i].y+1;
	end
	if(detectCollsion(nextState , true) == 1)then
		copyTable(blockePos , nextState);
	end
end

--拷贝移动方块的信息
function  copyTable( t1 , t2 )
	for i=1,4 do
		t1[i].x = t2[i].x;
		t1[i].y =  t2[i].y;
	end
end

--处理方块碰撞到各种墙壁的情况
function detectCollsion(nextPos ,  isDown)
	local flag = 1;
	for i=1,4 do
		--碰撞左右墙壁、下墙壁、一形成的方块堆
		if(nextPos[i].x <= 0 or nextPos[i].x > width)then
			flag = 0;
		end
		if(nextPos[i].y > 0 and (nextPos[i].y > height or gameMatrix[nextPos[i].y][nextPos[i].x] == 1))then
			if isDown then
				flag = -1;		--表示无法再下落
			else
				flag = 0;
			end
		--	meetWall();
		end
	end
	if(flag == -1)then 
		--先处理生成新的方块 , 然后在处理消行逻辑
		meetWall();
		cleatFullRow();
	
	end
	--print("flag : " ..flag);
	return flag;
end

function meetWall()
	for i=1,4 do
		--print("blockePos[i].y  :  " .. blockePos[i].y);
		if(blockePos[i].y > 0)then
			gameMatrix[blockePos[i].y][blockePos[i].x] = 1;
			colorMatrix[blockePos[i].y][blockePos[i].x] = blockePos[i].color;
		end
	
	end
	generateBlocke();
end


--消行逻辑实现
function cleatFullRow( )
--	print("cleatFullRow");
--	printGameMatrix();
	--首先需要由底向上扫描一次
	for i = height , 1 , -1 do
		if isFullRow(i) then
			--print(isFullRow(i));
			local fullRowNum = 1;
			while(isFullRow(i-fullRowNum)) do 
				fullRowNum = fullRowNum +1;
			end
			--把满行覆盖
			for j=i,fullRowNum+1 ,-1 do
				for k=1,width do
					gameMatrix[j][k] = gameMatrix[j-fullRowNum][k];
				end
			end
			--剩余行置空
			for k=fullRowNum+1,1,-1 do
				for x=1,width do
					gameMatrix[k][x] = 0;
				end	
			end
			--消行结束就增加玩家的分数
			addScore();
		end
	end
end

--判断指定行是否是满行
function isFullRow( j )
	--print("行号 : " .. j);
	local flag = true;
	for i=1 , width do
		--print("行号 : " .. j .. " : " .. gameMatrix[j][i]);
		if gameMatrix[j][i] ~= 1 then
			flag = false;
			break;
		end
	end
	return flag;
end

function printGameMatrix()
	for i = height , 1 , -1 do
		print("============================================================");
		print("行号 : " .. i .. " : " .."  ".. gameMatrix[i][1] .."  ".. gameMatrix[i][2] .."  ".. gameMatrix[i][3] .."  ".. gameMatrix[i][4] .."  ".. gameMatrix[i][5] .."  ".. gameMatrix[i][6] .."  ".. gameMatrix[i][7] .."  ".. gameMatrix[i][8] .."  ".. gameMatrix[i][9] .."  ".. gameMatrix[i][10] .."  ".. gameMatrix[i][11] .."  ".. gameMatrix[i][12] .."  ".. gameMatrix[i][13] .."  ".. gameMatrix[i][14] .."  ".. gameMatrix[i][15] );
	end
end


--增加分数
function addScore()
	playerCurScore = playerCurScore + 100;
	if playerCurScore >= 5000 then
		isWin = true;
		isPlaying = false;
	end
end





--生成四种方块的逻辑，，，此处实现不太优雅，，，具体的做法可以在斟酌
generateBlockeTable = {{ {x=7 , y=-4} , {x = 7 , y=-3 } , {x=7 , y=-2} , {x=7 , y=-1}}  ,  { {x=7 , y =-2} , {x=8 , y=-2} , {x=7 , y=-1} , {x=8 , y=-1}}   ,   { {x=8 , y =-1} , {x=7 , y=-1} , {x=7 , y=-2} , {x=7 , y=-3}} ,  { {x=6 , y =-1} , {x=7 , y=-1} , {x=7 , y=-2} , {x=8 , y=-1} } };
local random = Random();
function generateBlocke()

	local type = random:Next(1,5);
	curBlockeType = type;
	--local type = 3;
	--print("type : " .. type);
	for i=1 , 4 , 1 do
		--print(generateBlockeTable[type][i].x);
		--print(generateBlockeTable[type][i].y);
		blockePos[i].x = generateBlockeTable[type][i].x;
		blockePos[i].y = generateBlockeTable[type][i].y;
		blockePos[i].color = random:Next(1,8);
	end
	isGameOver();
end

--判断游戏是否终止
function isGameOver( )
	if gameMatrix[1][7] == 1 or gameMatrix[1][8] == 1 then
		isPlaying = false;
		isWin = false;
		isFailed = true;
	end
end


