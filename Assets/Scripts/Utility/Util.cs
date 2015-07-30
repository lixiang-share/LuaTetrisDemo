using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;

public class Util {

    /// <summary>
    /// 取得Lua路径
    /// </summary>
    public static string LuaPath(string name) {
        //string path = Application.dataPath ;
        //string lowerName = name.ToLower();
        //if (lowerName.EndsWith(".lua")) {
        //    int index = name.LastIndexOf('.');
        //    name = name.Substring(0, index);
        //}
        //name = name.Replace('.', '/');
        //return path + "/lua/" + name + ".lua";

        string path = Application.streamingAssetsPath;
        string lowerName = name.ToLower();
        if (lowerName.EndsWith(".lua"))
        {
            int index = name.LastIndexOf('.');
            name = name.Substring(0, index);
        }
        name = name.Replace('.', '/');
        name= path + "/lua/" + name + ".lua";
        return name;
    }

    public static void Log(string str) {
        Debug.Log(str);
    }

    public static void LogWarning(string str) {
        Debug.LogWarning(str);
    }

    public static void LogError(string str) {
        Debug.LogError(str); 
    }


    //===========================自定义Utils功能==============================
    /// <summary>
    /// 执行Lua方法
    /// </summary>
    public static object[] CallMethod(string module, string func, params object[] args)
    {
       // LuaScriptMgr luaMgr = AppFacade.Instance.GetManager<LuaScriptMgr>(ManagerName.Lua);
        LuaScriptMgr luaMgr = Dto.LuaMgr;
        if (luaMgr == null) return null;
        string funcName = module + "." + func;
        funcName = funcName.Replace("(Clone)", "");
        return luaMgr.CallLuaFunction(funcName, args);
    }
}