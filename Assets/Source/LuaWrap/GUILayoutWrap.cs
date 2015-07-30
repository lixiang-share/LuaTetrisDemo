using System;
using UnityEngine;
using LuaInterface;

public class GUILayoutWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Label", Label),
			new LuaMethod("Box", Box),
			new LuaMethod("Button", Button),
			new LuaMethod("RepeatButton", RepeatButton),
			new LuaMethod("TextField", TextField),
			new LuaMethod("PasswordField", PasswordField),
			new LuaMethod("TextArea", TextArea),
			new LuaMethod("Toggle", Toggle),
			new LuaMethod("Toolbar", Toolbar),
			new LuaMethod("SelectionGrid", SelectionGrid),
			new LuaMethod("HorizontalSlider", HorizontalSlider),
			new LuaMethod("VerticalSlider", VerticalSlider),
			new LuaMethod("HorizontalScrollbar", HorizontalScrollbar),
			new LuaMethod("VerticalScrollbar", VerticalScrollbar),
			new LuaMethod("Space", Space),
			new LuaMethod("FlexibleSpace", FlexibleSpace),
			new LuaMethod("BeginHorizontal", BeginHorizontal),
			new LuaMethod("EndHorizontal", EndHorizontal),
			new LuaMethod("BeginVertical", BeginVertical),
			new LuaMethod("EndVertical", EndVertical),
			new LuaMethod("BeginArea", BeginArea),
			new LuaMethod("EndArea", EndArea),
			new LuaMethod("BeginScrollView", BeginScrollView),
			new LuaMethod("EndScrollView", EndScrollView),
			new LuaMethod("Window", Window),
			new LuaMethod("Width", Width),
			new LuaMethod("MinWidth", MinWidth),
			new LuaMethod("MaxWidth", MaxWidth),
			new LuaMethod("Height", Height),
			new LuaMethod("MinHeight", MinHeight),
			new LuaMethod("MaxHeight", MaxHeight),
			new LuaMethod("ExpandWidth", ExpandWidth),
			new LuaMethod("ExpandHeight", ExpandHeight),
			new LuaMethod("New", _CreateGUILayout),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.GUILayout", typeof(GUILayout), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGUILayout(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GUILayout obj = new GUILayout();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.New");
		}

		return 0;
	}

	static Type classType = typeof(GUILayout);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Label(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Label(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Label(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Label(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Label(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Label(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Label(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Label");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Box(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Box(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Box(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.Box(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Box(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Box(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.Box(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Box");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Button(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Button(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Button(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Button(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.Button(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.Button(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.Button(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Button");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RepeatButton(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.RepeatButton(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.RepeatButton(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.RepeatButton(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.RepeatButton(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.RepeatButton(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			bool o = GUILayout.RepeatButton(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.RepeatButton");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TextField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			string o = GUILayout.TextField(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			string o = GUILayout.TextField(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			string o = GUILayout.TextField(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			string o = GUILayout.TextField(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.TextField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PasswordField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			char arg1 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			string o = GUILayout.PasswordField(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(char), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			char arg1 = (char)LuaDLL.lua_tonumber(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			string o = GUILayout.PasswordField(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(char), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			char arg1 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			string o = GUILayout.PasswordField(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(char)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			char arg1 = (char)LuaDLL.lua_tonumber(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			string o = GUILayout.PasswordField(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.PasswordField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TextArea(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			string o = GUILayout.TextArea(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			string o = GUILayout.TextArea(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			string o = GUILayout.TextArea(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			string o = GUILayout.TextArea(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.TextArea");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Toggle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			bool o = GUILayout.Toggle(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			bool o = GUILayout.Toggle(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			bool o = GUILayout.Toggle(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Toggle(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Toggle(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(bool), typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			bool arg0 = LuaDLL.lua_toboolean(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			bool o = GUILayout.Toggle(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Toggle");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Toolbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(string[]), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.Toolbar(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Texture[]), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Texture[] objs1 = LuaScriptMgr.GetArrayObject<Texture>(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.Toolbar(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(GUIContent[]), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			GUIContent[] objs1 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.Toolbar(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(string[])) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			int o = GUILayout.Toolbar(arg0,objs1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Texture[])) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Texture[] objs1 = LuaScriptMgr.GetArrayObject<Texture>(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			int o = GUILayout.Toolbar(arg0,objs1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(GUIContent[])) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			GUIContent[] objs1 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			int o = GUILayout.Toolbar(arg0,objs1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Toolbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SelectionGrid(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(string[]), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Texture[]), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Texture[] objs1 = LuaScriptMgr.GetArrayObject<Texture>(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(GUIContent[]), typeof(int), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			GUIContent[] objs1 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(string[]), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Texture[]), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Texture[] objs1 = LuaScriptMgr.GetArrayObject<Texture>(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(GUIContent[]), typeof(int)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			GUIContent[] objs1 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			int o = GUILayout.SelectionGrid(arg0,objs1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.SelectionGrid");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HorizontalSlider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(GUIStyle), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			float o = GUILayout.HorizontalSlider(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			float o = GUILayout.HorizontalSlider(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.HorizontalSlider");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VerticalSlider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(GUIStyle), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			float o = GUILayout.VerticalSlider(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			float o = GUILayout.VerticalSlider(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.VerticalSlider");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HorizontalScrollbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			float o = GUILayout.HorizontalScrollbar(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			float o = GUILayout.HorizontalScrollbar(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.HorizontalScrollbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VerticalScrollbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			float o = GUILayout.VerticalScrollbar(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			float arg0 = (float)LuaDLL.lua_tonumber(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			float o = GUILayout.VerticalScrollbar(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.VerticalScrollbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Space(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayout.Space(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FlexibleSpace(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUILayout.FlexibleSpace();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginHorizontal(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginHorizontal(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginHorizontal(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginHorizontal(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIStyle arg0 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.BeginHorizontal(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 1, count))
		{
			GUILayoutOption[] objs0 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 1, count);
			GUILayout.BeginHorizontal(objs0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.BeginHorizontal");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndHorizontal(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUILayout.EndHorizontal();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginVertical(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Texture arg0 = (Texture)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginVertical(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			GUIContent arg0 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginVertical(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			GUILayout.BeginVertical(arg0,arg1,objs2);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			GUIStyle arg0 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			GUILayout.BeginVertical(arg0,objs1);
			return 0;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 1, count))
		{
			GUILayoutOption[] objs0 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 1, count);
			GUILayout.BeginVertical(objs0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.BeginVertical");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndVertical(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUILayout.EndVertical();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginArea(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			GUILayout.BeginArea(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayout.BeginArea(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayout.BeginArea(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUILayout.BeginArea(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayout.BeginArea(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayout.BeginArea(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayout.BeginArea(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayout.BeginArea(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.BeginArea");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndArea(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUILayout.EndArea();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginScrollView(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 2, typeof(GUIStyle));
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(bool), typeof(bool), typeof(GUIStyle), typeof(GUIStyle), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 7, count - 6))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			bool arg2 = LuaDLL.lua_toboolean(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 6);
			GUILayoutOption[] objs6 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 7, count - 6);
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1,arg2,arg3,arg4,arg5,objs6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(bool), typeof(bool), typeof(GUIStyle), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			bool arg2 = LuaDLL.lua_toboolean(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(bool), typeof(bool)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			bool arg2 = LuaDLL.lua_toboolean(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(GUIStyle), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 4, count - 3))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUILayoutOption[] objs3 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 4, count - 3);
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 3, count - 2))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUILayoutOption[] objs2 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 3, count - 2);
			Vector2 o = GUILayout.BeginScrollView(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 2, count - 1))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			GUILayoutOption[] objs1 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 2, count - 1);
			Vector2 o = GUILayout.BeginScrollView(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.BeginScrollView");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndScrollView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUILayout.EndScrollView();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Window(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			string arg3 = LuaScriptMgr.GetString(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			Texture arg3 = (Texture)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent), typeof(GUIStyle)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 6, count - 5))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			GUIContent arg3 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			GUILayoutOption[] objs5 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 6, count - 5);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,arg4,objs5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			string arg3 = LuaScriptMgr.GetString(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			Texture arg3 = (Texture)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent)) && LuaScriptMgr.CheckParamsType(L, typeof(GUILayoutOption), 5, count - 4))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			Rect arg1 = (Rect)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.WindowFunction arg2 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg2 = (GUI.WindowFunction)LuaScriptMgr.GetLuaObject(L, 3);
			}
			else
			{
				LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
				arg2 = (param0) =>
				{
					int top = func.BeginPCall();
					LuaScriptMgr.Push(L, param0);
					func.PCall(top, 1);
					func.EndPCall(top);
				};
			}

			GUIContent arg3 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 4);
			GUILayoutOption[] objs4 = LuaScriptMgr.GetParamsObject<GUILayoutOption>(L, 5, count - 4);
			Rect o = GUILayout.Window(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUILayout.Window");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Width(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.Width(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MinWidth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.MinWidth(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MaxWidth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.MaxWidth(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Height(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.Height(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MinHeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.MinHeight(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MaxHeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		GUILayoutOption o = GUILayout.MaxHeight(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExpandWidth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
		GUILayoutOption o = GUILayout.ExpandWidth(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExpandHeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
		GUILayoutOption o = GUILayout.ExpandHeight(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

