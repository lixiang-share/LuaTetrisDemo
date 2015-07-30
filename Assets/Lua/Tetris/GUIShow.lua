require "Common/functions";
require "Tetris/BlockeController";
require "Tetris/GameManager";
--!!!!!!!为保证场景中坐标位置相对合理，所以把场景中所有向屏幕绘制的的逻辑都放在GUIShow中处理，便于坐标管理

GUIShow = {};
local this = GUIShow;

local  GUILayout = UnityEngine.GUILayout;
local  GUI = UnityEngine.GUI;
local  Rect = UnityEngine.Rect;
local  Screen  = UnityEngine.Screen;
local unitLen = 100;

local boundaryColor = 0;

--将屏幕看成 160*90 的比例,通过计算屏幕的真实尺寸，计算真实的坐标
function this.Awake(  )
	--unitLen = Screen.width / 160 * Screen.currentResolution;
	unitLen = Screen.currentResolution.width/160*2;
	--print("unitLen : ".. unitLen);
end

function this.Start(  )
	--boundaryColor = BlockeController.wall;
	--print("boundaryColor : " .. boundaryColor);
end


--显示游戏的界面，由于ulua默认并没有导入GUI，Rect类型，所以手动在BindLua中手动导入
--使用时需要手动添加namespace或者像上面做一下转换
function this.OnGUI( )
	this.DrawFrame();
	this.DrawGameMatrixs( );
	this.DrawScore();

	if curState ~= gameState.Suspend then 
		this.DrawBlockes();
	end

	if curState == gameState.Suspend then
		this.DrawButton();
	end

	if curState == gameState.Win then
		this.DrawWin("Win!!!");
	end
	if curState == gameState.Failed then
		this.DrawWin("Failed!!");
	end
end

function this.DrawWin(mes)
	local top = 15;
	local left = 38;
	GUI.skin = nil;
	if GUI.Button(Rect(left*unitLen, top*unitLen, unitLen*6, unitLen*2) , mes .. " ReSart!!") then
		reStartGame();
	end
end


function this.DrawButton( )
	local top = 15;
	local left = 38;
	GUI.skin = BlockeController.textSkin;
	if GUI.Button(Rect(left*unitLen, top*unitLen, unitLen*6, unitLen*2) , "") then
		startGame();
	end

end



function this.DrawScore()
	local top = 4;
	local left = 38;
	GUI.skin = BlockeController.textSkin;
	GUI.Label(Rect(left*unitLen, top*unitLen, unitLen*6, unitLen*2), " Score  :  " .. playerCurScore);
end

function this.DrawFrame()

	local top = 10;
	local left = 32;
	--左边界
	for i = 0 , height , 1 do
		DrawBlocke(left*unitLen , (top+i)*unitLen , BlockeController.wall);
		DrawBlocke((left+width+1)*unitLen , (top+i)*unitLen , BlockeController.wall);
	end
	--下边框
	for i=0 , width , 1 do
		DrawBlocke((left+1+i)*unitLen , (top+height)*unitLen ,BlockeController.wall);
	end
end


--绘制游戏中的方块
function this.DrawBlockes( )
	local top  = 9;
	local left = 32;
	--每个方块个体都有四个小方块组成
	for i=1 , 4 , 1 do
		DrawBlocke((blockePos[i].x+left)*unitLen , (blockePos[i].y+top)*unitLen , colorTable[blockePos[i].color]);
	end
end




--绘制游戏场景中的方块
function this.DrawGameMatrixs( )
	local top  = 9;
	local left = 32;
	for i=1 , height , 1 do
		for j=1 , width , 1 do
			if(gameMatrix[i][j] == 1)then
				local color =colorTable[colorMatrix[i][j]];
				--按行，从上到下绘制方块
				DrawBlocke((left+j)*unitLen , (top+i)*unitLen , color);
			end
		end
	end
end

function DrawBlocke(x ,y , texture )
	
	--计算相对坐标
	GUI.DrawTexture(Rect(x, y, unitLen, unitLen) , texture );
end