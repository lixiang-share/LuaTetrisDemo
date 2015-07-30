using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class ParamItem
{
    public string name;
    public Object value;
}


public class LuaBehaviour : MonoBehaviour {
    public string luaFilename;
    protected string moduleName;
    private bool isInitialize = false;
    [SerializeField]
    protected List<ParamItem> m_params;
   protected  void Awake()
    {
        Dto.LuaMgr.DoFile(luaFilename);
        Init(luaFilename);
    }


    private void Init(string filename)
    {
        if (filename != null)
        {
            Dto.LuaMgr.DoFile(filename);
            string name = filename;
            int index = filename.LastIndexOf('/');
            if (index != -1)
            {
                name = filename.Substring(index + 1);
            }
            isInitialize = true;
            moduleName = name;
        }
    }

    protected object[] CallMethod(string func, params object[] args)
    {
        if (!isInitialize) return null;
        return Util.CallMethod(moduleName, func, args);
    }
}
