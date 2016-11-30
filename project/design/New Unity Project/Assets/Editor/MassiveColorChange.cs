using UnityEngine;
using System.Collections;
using UnityEditor;

class MassiveColorChange : EditorWindow
{

    Color matColor = Color.white;

    [MenuItem("Examples/Mass Color Change")]
    static void Init()
    {
        var window = GetWindow(typeof(MassiveColorChange) );
        window.Show();
    }


    void OnGUI()
    {
        Debug.Log(Event.current);
        Debug.Log(Selection.objects);

        ColorPickerHDRConfig vongif = new ColorPickerHDRConfig(0,1,0,1);

        //vongif.minBrightness = 1;
        GUIContent con = new GUIContent("my");
        matColor = EditorGUILayout.ColorField(con, matColor,true,true,true, vongif);
        


        if (GUILayout.Button("Change!"))
            ChangeColors();
    }


    void ChangeColors()
    {
        //    if (Selection.activeGameObject)
        //        for (var t: GameObject in Selection.gameObjects)
        //        {
        //            var rend = t.GetComponent.< Renderer > ();

        //            if (rend != null)
        //                rend.sharedMaterial.color = matColor;
        //        }
        //}
    }
}

