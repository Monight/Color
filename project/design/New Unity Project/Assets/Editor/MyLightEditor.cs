using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class MyLightEditor : Editor {



    public static void My()
    {
        //GUILayoutOption
        Color c1 = Color.white;
        EditorGUILayout.ColorField("颜色1", c1);

        
    }


}
