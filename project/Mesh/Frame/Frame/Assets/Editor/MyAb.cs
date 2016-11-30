using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyAb : Editor {

    [MenuItem("AssetBundle/BuildAssetBundle")]
    public static void CreateAssetBundle()
    {


        BuildPipeline.BuildAssetBundles("Assets", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
