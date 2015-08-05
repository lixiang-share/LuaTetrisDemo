using UnityEngine;
using System.Collections;
using System.IO;

public class GameStart : MonoBehaviour {
    public GameObject gameMgr;

    private LuaScriptMgr LuaMgr;
    void Awake()
    {
        LuaMgr = Dto.LuaMgr;
        UpdateResource();
    }


    private void UpdateResource()
    {
        bool isExist = Directory.Exists(Util.DataPath + "/lua/") && File.Exists(Util.DataPath + "files.txt");
        if (!isExist)
        {
            StartCoroutine(OnExtractResource());
        }
        else
        {
            OnResUpdate();
        }
    }

    IEnumerator OnExtractResource()
    {
        string dataPath = Util.DataPath;  //数据目录
        string resPath = Util.AppContentPath(); //游戏包资源目录

        if (Directory.Exists(dataPath)) Directory.Delete(dataPath, true);
        Directory.CreateDirectory(dataPath);

        string infile = resPath + "/files.txt";
        string outfile = dataPath + "/files.txt";
        if (File.Exists(outfile)) File.Delete(outfile);

        string message = "正在解包文件:>files.txt";
        Debug.Log(message);
      //  facade.SendNotification(NotiConst.UPDATE_MESSAGE, message);

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW www = new WWW(infile);
            yield return www;

            if (www.isDone)
            {
                File.WriteAllBytes(outfile, www.bytes);
            }
            yield return 0;
        }
        else File.Copy(infile, outfile, true);
        yield return new WaitForEndOfFrame();

        //释放所有文件到数据目录
        string[] files = File.ReadAllLines(outfile);
        foreach (var file in files)
        {
            string[] fs = file.Split('|');
            infile = resPath + fs[0];  //
            outfile = dataPath + fs[0];
            message = "正在解包文件:>" + fs[0];
            Debug.Log("正在解包文件:>" + infile);
          //  facade.SendNotification(NotiConst.UPDATE_MESSAGE, message);

           // Wshrzzz.UnityUtil.GUILogDisplay.Log("In File : " + infile);


          //  Wshrzzz.UnityUtil.GUILogDisplay.LogError("Out File : " + outfile);

            string dir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            if (Application.platform == RuntimePlatform.Android)
            {
                WWW www = new WWW(infile);
                yield return www;

                if (www.isDone)
                {
                    File.WriteAllBytes(outfile, www.bytes);
                }
                yield return 0;
            }
            else
            {
                if (File.Exists(outfile))
                {
                    File.Delete(outfile);
                }
                File.Copy(infile, outfile, true);
            }
            yield return new WaitForEndOfFrame();
        }
        message = "解包完成!!!";
      //  facade.SendNotification(NotiConst.UPDATE_MESSAGE, message);

        yield return new WaitForSeconds(0.1f);
        message = string.Empty;

        //释放完成，开始启动更新资源
       // StartCoroutine(OnUpdateResource());
        OnResUpdate();
    }



    private void OnResUpdate()
    {
        LuaMgr.Start();
        Object.Instantiate(gameMgr);
    }
}
