using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// 一键打包的测试
/// </summary>


public class MyOneAb : Editor
{

    //一键打包

    [MenuItem("AssetBundle/一键打包")]
    public static void CreatAbInfo()
    {

        string path = "Assets/Prefab/object1.prefab";

        string fullPath = "Assets/Prefab";
        List<string> allPrefab = new List<string>();
        if (Directory.Exists(fullPath))
        {
            DirectoryInfo direction = new DirectoryInfo(fullPath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            Debug.Log(files.Length);
            //移出生成的.meta文件
            
            for (int i =0; i  < files.Length; i ++)
            {
                if (files[i].Name.Contains(".meta"))
                    continue;
                allPrefab.Add(files[i].Name);
            }
           
        }



        //处理所有的关联打包
        for (int i = 0; i < allPrefab.Count; i ++)
        {
            //Debug.Log(fullPath + "/" + allPrefab[i]  + "-----------------");
            string[] name = AssetDatabase.GetDependencies(fullPath + "/"+ allPrefab[i],true);  //AssetDatabase.GetDependencies
            //Debug.Log(allPrefab[i]);
            //Debug.Log(name.Length);


            for (int j =0; j < name.Length; j ++)
            {

                if (name[j].Contains(allPrefab[i]))
                    continue;

                //TODO:打包操作
               // Debug.Log(j + "-------------" +  name[j] + " ------------------");

                Debug.Log(AssetImporter.GetAtPath(name[j]).assetBundleName);

                //获取资源的唯一的ID
                string assetName = AssetDatabase.AssetPathToGUID(name[j]);
                //打包的名字更改
                AssetImporter.GetAtPath(name[j]).assetBundleName = assetName;
                Debug.Log(AssetImporter.GetAtPath(name[j]).assetBundleName);
                ////如果name 是空的话    设置他的名字
                //if (AssetImporter.GetAtPath(name[i]).assetBundleName == null)
                //{
                //    AssetImporter.GetAtPath(name[i]).assetBundleName = string.Format("{0}.ob", name[i]); 
                //}
            }
        }

        BuildPipeline.BuildAssetBundles("Assets/Output", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
