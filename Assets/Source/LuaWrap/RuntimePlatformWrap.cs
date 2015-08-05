using System;
using UnityEngine;
using LuaInterface;

public class RuntimePlatformWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("OSXEditor", GetOSXEditor),
		new LuaMethod("OSXPlayer", GetOSXPlayer),
		new LuaMethod("WindowsPlayer", GetWindowsPlayer),
		new LuaMethod("OSXWebPlayer", GetOSXWebPlayer),
		new LuaMethod("OSXDashboardPlayer", GetOSXDashboardPlayer),
		new LuaMethod("WindowsWebPlayer", GetWindowsWebPlayer),
		new LuaMethod("WindowsEditor", GetWindowsEditor),
		new LuaMethod("IPhonePlayer", GetIPhonePlayer),
		new LuaMethod("XBOX360", GetXBOX360),
		new LuaMethod("PS3", GetPS3),
		new LuaMethod("Android", GetAndroid),
		new LuaMethod("NaCl", GetNaCl),
		new LuaMethod("LinuxPlayer", GetLinuxPlayer),
		new LuaMethod("FlashPlayer", GetFlashPlayer),
		new LuaMethod("MetroPlayerX86", GetMetroPlayerX86),
		new LuaMethod("MetroPlayerX64", GetMetroPlayerX64),
		new LuaMethod("MetroPlayerARM", GetMetroPlayerARM),
		new LuaMethod("WP8Player", GetWP8Player),
		new LuaMethod("BlackBerryPlayer", GetBlackBerryPlayer),
		new LuaMethod("TizenPlayer", GetTizenPlayer),
		new LuaMethod("PSP2", GetPSP2),
		new LuaMethod("PS4", GetPS4),
		new LuaMethod("PSMPlayer", GetPSMPlayer),
		new LuaMethod("XboxOne", GetXboxOne),
		new LuaMethod("SamsungTVPlayer", GetSamsungTVPlayer),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RuntimePlatform", typeof(UnityEngine.RuntimePlatform), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOSXEditor(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.OSXEditor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOSXPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.OSXPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWindowsPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.WindowsPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOSXWebPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.OSXWebPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOSXDashboardPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.OSXDashboardPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWindowsWebPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.WindowsWebPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWindowsEditor(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.WindowsEditor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIPhonePlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.IPhonePlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetXBOX360(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.XBOX360);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPS3(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.PS3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAndroid(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.Android);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNaCl(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.NaCl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLinuxPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.LinuxPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFlashPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.FlashPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMetroPlayerX86(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.MetroPlayerX86);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMetroPlayerX64(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.MetroPlayerX64);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMetroPlayerARM(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.MetroPlayerARM);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWP8Player(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.WP8Player);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlackBerryPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.BlackBerryPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTizenPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.TizenPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPSP2(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.PSP2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPS4(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.PS4);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPSMPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.PSMPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetXboxOne(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.XboxOne);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSamsungTVPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, RuntimePlatform.SamsungTVPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RuntimePlatform o = (RuntimePlatform)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

