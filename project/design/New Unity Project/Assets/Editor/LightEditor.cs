using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Light))]
[ExecuteInEditMode]
public class LightEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        if (GUILayout.Button("Adding this button"))
        {
            Debug.Log("Adding this button");
        }

        Light test = (Light)target;

        Debug.Log(RenderSettings.ambientMode);
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        Debug.Log(test.color);




        //Debug.Log(test.transform.GetComponent<Light>());
    }





    }
