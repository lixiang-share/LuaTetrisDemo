using UnityEngine;
using System.Collections;
/// <summary>
/// 对象传输流的模式，封装一些常用的管理器对象，便于C#层或者lua层的调用
/// </summary>
public class Dto{
    private static LuaScriptMgr _LuaMgr;

    public static LuaScriptMgr LuaMgr
    {
        get
        {
            if (_LuaMgr == null)
            {
                _LuaMgr = new LuaScriptMgr();
               // _LuaMgr.Start();
            }
            return _LuaMgr;
        }
    }
}
