using UnityEngine;
using System.Collections;

public class StartLua : MonoBehaviour {

    public TextAsset startLuaTexts;

    LuaScriptMgr mgr;

    void Start()
    {
        if (LuaScriptMgr.Instance == null)
            new LuaScriptMgr();
        mgr = LuaScriptMgr.Instance;
        Debug.Log(startLuaTexts.name);
        Debug.Log(mgr);
        mgr.DoStringFile(startLuaTexts.name, startLuaTexts.text);

        mgr.CallLuaFunction("test");
        mgr.Start();
    }

}
