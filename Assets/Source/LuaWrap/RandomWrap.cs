using System;
using LuaInterface;

public class RandomWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Next", Next),
			new LuaMethod("NextBytes", NextBytes),
			new LuaMethod("NextDouble", NextDouble),
			new LuaMethod("New", _CreateRandom),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "System.Random", typeof(Random), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRandom(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Random obj = new Random();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Random obj = new Random(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Random.New");
		}

		return 0;
	}

	static Type classType = typeof(Random);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Next(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Random obj = (Random)LuaScriptMgr.GetNetObjectSelf(L, 1, "Random");
			int o = obj.Next();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Random obj = (Random)LuaScriptMgr.GetNetObjectSelf(L, 1, "Random");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = obj.Next(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Random obj = (Random)LuaScriptMgr.GetNetObjectSelf(L, 1, "Random");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.Next(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Random.Next");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NextBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Random obj = (Random)LuaScriptMgr.GetNetObjectSelf(L, 1, "Random");
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		obj.NextBytes(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NextDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Random obj = (Random)LuaScriptMgr.GetNetObjectSelf(L, 1, "Random");
		double o = obj.NextDouble();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

