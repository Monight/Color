using UnityEngine;
using System.Collections;


public class LuaUnit : MonoBehaviour
{

    public string luaClaseeName = "";   //lua类型
    public GameObject[] objs;    //游戏对象
    public GameObject[] prefabs; //实例化的东东
    public int insID;            //实例ID
    LuaScriptMgr tolua;          //交互的接口


    void Awake()
    {
        if (LuaScriptMgr.Instance == null)
            new LuaScriptMgr();
        

        tolua = LuaScriptMgr.Instance;

        insID = gameObject.GetInstanceID();
        int objsLenght = objs == null ? 0 : objs.Length;
        int prefabsLenght = prefabs == null ? 0 : prefabs.Length;

        //UnityEngine.Debug.Log(Process.GetProcesses().Length);
        //UnityEngine.Debug.Log(Process.GetProcesses()[1].ProcessName);
        Debug.Log(objs.Length);
        Debug.Log(objs);
        CallMethod("awake", objs, prefabs, objsLenght, prefabsLenght, gameObject,insID,luaClaseeName);
        //tolua.Start();
        // Debug.Log("开始载入");


    }
    //   object[] CallMethod(string funcName, params Object[] objs)
    //｛
    //		//调用




    //｝

    object[] CallMethod(string funcName,params object[] objs )
    {
      //Debug.Log(tolua.CallLuaFunction(funcName, objs));
      return  tolua.CallLuaFunction(funcName, objs);
    }

    
}
