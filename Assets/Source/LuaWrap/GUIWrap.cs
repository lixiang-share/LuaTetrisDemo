using System;
using UnityEngine;
using LuaInterface;

public class GUIWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Label", Label),
			new LuaMethod("DrawTexture", DrawTexture),
			new LuaMethod("DrawTextureWithTexCoords", DrawTextureWithTexCoords),
			new LuaMethod("Box", Box),
			new LuaMethod("Button", Button),
			new LuaMethod("RepeatButton", RepeatButton),
			new LuaMethod("TextField", TextField),
			new LuaMethod("PasswordField", PasswordField),
			new LuaMethod("TextArea", TextArea),
			new LuaMethod("SetNextControlName", SetNextControlName),
			new LuaMethod("GetNameOfFocusedControl", GetNameOfFocusedControl),
			new LuaMethod("FocusControl", FocusControl),
			new LuaMethod("Toggle", Toggle),
			new LuaMethod("Toolbar", Toolbar),
			new LuaMethod("SelectionGrid", SelectionGrid),
			new LuaMethod("HorizontalSlider", HorizontalSlider),
			new LuaMethod("VerticalSlider", VerticalSlider),
			new LuaMethod("Slider", Slider),
			new LuaMethod("HorizontalScrollbar", HorizontalScrollbar),
			new LuaMethod("VerticalScrollbar", VerticalScrollbar),
			new LuaMethod("BeginGroup", BeginGroup),
			new LuaMethod("EndGroup", EndGroup),
			new LuaMethod("BeginScrollView", BeginScrollView),
			new LuaMethod("EndScrollView", EndScrollView),
			new LuaMethod("ScrollTo", ScrollTo),
			new LuaMethod("ScrollTowards", ScrollTowards),
			new LuaMethod("Window", Window),
			new LuaMethod("ModalWindow", ModalWindow),
			new LuaMethod("DragWindow", DragWindow),
			new LuaMethod("BringWindowToFront", BringWindowToFront),
			new LuaMethod("BringWindowToBack", BringWindowToBack),
			new LuaMethod("FocusWindow", FocusWindow),
			new LuaMethod("UnfocusWindow", UnfocusWindow),
			new LuaMethod("New", _CreateGUI),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("skin", get_skin, set_skin),
			new LuaField("color", get_color, set_color),
			new LuaField("backgroundColor", get_backgroundColor, set_backgroundColor),
			new LuaField("contentColor", get_contentColor, set_contentColor),
			new LuaField("changed", get_changed, set_changed),
			new LuaField("enabled", get_enabled, set_enabled),
			new LuaField("matrix", get_matrix, set_matrix),
			new LuaField("tooltip", get_tooltip, set_tooltip),
			new LuaField("depth", get_depth, set_depth),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.GUI", typeof(GUI), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGUI(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GUI obj = new GUI();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.New");
		}

		return 0;
	}

	static Type classType = typeof(GUI);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skin(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.skin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.backgroundColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_contentColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.contentColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_changed(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.changed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_matrix(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, GUI.matrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tooltip(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.tooltip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		LuaScriptMgr.Push(L, GUI.depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skin(IntPtr L)
	{
		GUI.skin = (GUISkin)LuaScriptMgr.GetUnityObject(L, 3, typeof(GUISkin));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		GUI.color = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backgroundColor(IntPtr L)
	{
		GUI.backgroundColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_contentColor(IntPtr L)
	{
		GUI.contentColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_changed(IntPtr L)
	{
		GUI.changed = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		GUI.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_matrix(IntPtr L)
	{
		GUI.matrix = (Matrix4x4)LuaScriptMgr.GetNetObject(L, 3, typeof(Matrix4x4));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tooltip(IntPtr L)
	{
		GUI.tooltip = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		GUI.depth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Label(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.Label(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.Label(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUI.Label(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Label(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Label(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Label(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Label");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			GUI.DrawTexture(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			ScaleMode arg2 = (ScaleMode)LuaScriptMgr.GetNetObject(L, 3, typeof(ScaleMode));
			GUI.DrawTexture(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			ScaleMode arg2 = (ScaleMode)LuaScriptMgr.GetNetObject(L, 3, typeof(ScaleMode));
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			GUI.DrawTexture(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			ScaleMode arg2 = (ScaleMode)LuaScriptMgr.GetNetObject(L, 3, typeof(ScaleMode));
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			GUI.DrawTexture(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.DrawTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawTextureWithTexCoords(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			Rect arg2 = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
			GUI.DrawTextureWithTexCoords(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Texture arg1 = (Texture)LuaScriptMgr.GetUnityObject(L, 2, typeof(Texture));
			Rect arg2 = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			GUI.DrawTextureWithTexCoords(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.DrawTextureWithTexCoords");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Box(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.Box(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.Box(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUI.Box(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Box(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Box(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.Box(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Box");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Button(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			bool o = GUI.Button(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			bool o = GUI.Button(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			bool o = GUI.Button(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.Button(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.Button(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.Button(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Button");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RepeatButton(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			bool o = GUI.RepeatButton(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			bool o = GUI.RepeatButton(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			bool o = GUI.RepeatButton(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.RepeatButton(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.RepeatButton(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.RepeatButton(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.RepeatButton");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TextField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			string o = GUI.TextField(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			string o = GUI.TextField(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			string o = GUI.TextField(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 4, typeof(GUIStyle));
			string o = GUI.TextField(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.TextField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PasswordField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			char arg2 = (char)LuaScriptMgr.GetNumber(L, 3);
			string o = GUI.PasswordField(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(char), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			char arg2 = (char)LuaDLL.lua_tonumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			string o = GUI.PasswordField(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(char), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			char arg2 = (char)LuaDLL.lua_tonumber(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			string o = GUI.PasswordField(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			char arg2 = (char)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 5, typeof(GUIStyle));
			string o = GUI.PasswordField(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.PasswordField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TextArea(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			string o = GUI.TextArea(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			string o = GUI.TextArea(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			string o = GUI.TextArea(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 4, typeof(GUIStyle));
			string o = GUI.TextArea(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.TextArea");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetNextControlName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GUI.SetNextControlName(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNameOfFocusedControl(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = GUI.GetNameOfFocusedControl();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FocusControl(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GUI.FocusControl(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Toggle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			GUIContent arg2 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.Toggle(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			Texture arg2 = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			bool o = GUI.Toggle(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			bool o = GUI.Toggle(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			GUIContent arg2 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			bool o = GUI.Toggle(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			Texture arg2 = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			bool o = GUI.Toggle(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(bool), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			bool arg1 = LuaDLL.lua_toboolean(L, 2);
			string arg2 = LuaScriptMgr.GetString(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			bool o = GUI.Toggle(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			GUIContent arg3 = (GUIContent)LuaScriptMgr.GetNetObject(L, 4, typeof(GUIContent));
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 5, typeof(GUIStyle));
			bool o = GUI.Toggle(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Toggle");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Toolbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(GUIContent[])))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIContent[] objs2 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 3);
			int o = GUI.Toolbar(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(Texture[])))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture[] objs2 = LuaScriptMgr.GetArrayObject<Texture>(L, 3);
			int o = GUI.Toolbar(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(string[])))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string[] objs2 = LuaScriptMgr.GetArrayString(L, 3);
			int o = GUI.Toolbar(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(GUIContent[]), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIContent[] objs2 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			int o = GUI.Toolbar(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(Texture[]), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture[] objs2 = LuaScriptMgr.GetArrayObject<Texture>(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			int o = GUI.Toolbar(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(string[]), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string[] objs2 = LuaScriptMgr.GetArrayString(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			int o = GUI.Toolbar(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Toolbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SelectionGrid(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(GUIContent[]), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIContent[] objs2 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(Texture[]), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture[] objs2 = LuaScriptMgr.GetArrayObject<Texture>(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(string[]), typeof(int)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string[] objs2 = LuaScriptMgr.GetArrayString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(GUIContent[]), typeof(int), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			GUIContent[] objs2 = LuaScriptMgr.GetArrayObject<GUIContent>(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(Texture[]), typeof(int), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture[] objs2 = LuaScriptMgr.GetArrayObject<Texture>(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(int), typeof(string[]), typeof(int), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string[] objs2 = LuaScriptMgr.GetArrayString(L, 3);
			int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			int o = GUI.SelectionGrid(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.SelectionGrid");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HorizontalSlider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float o = GUI.HorizontalSlider(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 5, typeof(GUIStyle));
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
			float o = GUI.HorizontalSlider(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.HorizontalSlider");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VerticalSlider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float o = GUI.VerticalSlider(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 5, typeof(GUIStyle));
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
			float o = GUI.VerticalSlider(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.VerticalSlider");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Slider(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 9);
		Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
		GUIStyle arg6 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 7, typeof(GUIStyle));
		bool arg7 = LuaScriptMgr.GetBoolean(L, 8);
		int arg8 = (int)LuaScriptMgr.GetNumber(L, 9);
		float o = GUI.Slider(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HorizontalScrollbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 5)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float o = GUI.HorizontalScrollbar(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
			float o = GUI.HorizontalScrollbar(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.HorizontalScrollbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VerticalScrollbar(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 5)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float o = GUI.VerticalScrollbar(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
			float o = GUI.VerticalScrollbar(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.VerticalScrollbar");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginGroup(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			GUI.BeginGroup(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.BeginGroup(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIStyle arg1 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.BeginGroup(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUI.BeginGroup(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUI.BeginGroup(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(GUIContent), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			GUIContent arg1 = (GUIContent)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.BeginGroup(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(Texture), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.BeginGroup(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(string), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GUIStyle arg2 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 3);
			GUI.BeginGroup(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.BeginGroup");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUI.EndGroup();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginScrollView(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
			Rect arg2 = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
			Vector2 o = GUI.BeginScrollView(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(LuaTable), typeof(Rect), typeof(GUIStyle), typeof(GUIStyle)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
			Rect arg2 = (Rect)LuaScriptMgr.GetLuaObject(L, 3);
			GUIStyle arg3 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 4);
			GUIStyle arg4 = (GUIStyle)LuaScriptMgr.GetLuaObject(L, 5);
			Vector2 o = GUI.BeginScrollView(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(Rect), typeof(LuaTable), typeof(Rect), typeof(bool), typeof(bool)))
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetLuaObject(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
			Rect arg2 = (Rect)LuaScriptMgr.GetLuaObject(L, 3);
			bool arg3 = LuaDLL.lua_toboolean(L, 4);
			bool arg4 = LuaDLL.lua_toboolean(L, 5);
			Vector2 o = GUI.BeginScrollView(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
			Rect arg2 = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			GUIStyle arg5 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 6, typeof(GUIStyle));
			GUIStyle arg6 = (GUIStyle)LuaScriptMgr.GetNetObject(L, 7, typeof(GUIStyle));
			Vector2 o = GUI.BeginScrollView(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.BeginScrollView");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndScrollView(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GUI.EndScrollView();
			return 0;
		}
		else if (count == 1)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			GUI.EndScrollView(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.EndScrollView");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScrollTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
		GUI.ScrollTo(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScrollTowards(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		bool o = GUI.ScrollTowards(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Window(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent), typeof(GUIStyle)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture), typeof(GUIStyle)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string), typeof(GUIStyle)))
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
			Rect o = GUI.Window(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.Window");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ModalWindow(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(GUIContent), typeof(GUIStyle)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(Texture), typeof(GUIStyle)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(Rect), typeof(GUI.WindowFunction), typeof(string), typeof(GUIStyle)))
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
			Rect o = GUI.ModalWindow(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.ModalWindow");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DragWindow(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GUI.DragWindow();
			return 0;
		}
		else if (count == 1)
		{
			Rect arg0 = (Rect)LuaScriptMgr.GetNetObject(L, 1, typeof(Rect));
			GUI.DragWindow(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GUI.DragWindow");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BringWindowToFront(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		GUI.BringWindowToFront(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BringWindowToBack(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		GUI.BringWindowToBack(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FocusWindow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		GUI.FocusWindow(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnfocusWindow(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GUI.UnfocusWindow();
		return 0;
	}
}

