--lua开发中常用的函数模板，，，方便创建lua脚本
VedioController = {};
local this = VedioController;

local Camera = UnityEngine.Camera;
local AudioSource = UnityEngine.AudioSource;

local cameraPos;
function this.Start()
	print("VedioController");
	cameraPos = Camera.main.transform.position;
end
function playVedio_move()
	print("cameraPos : "..cameraPos.z);
	print(VedioController.vedio_move);
	AudioSource.PlayClipAtPoint(this.vedio_move, cameraPos , 0.5);
end


