using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 测试丁点数据
/// </summary>

public class ShowVertic : MonoBehaviour {

	
	void Start ()
    {
        //获取定点
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] v = mesh.vertices;
        Debug.Log("mesh.cout == " + mesh.vertexCount  );

        for (int i =0; i < mesh.vertexCount; i ++)
        {
            Debug.Log( "第" +i + "个" +  v[i]);
        }
        Vector2[] uv = mesh.uv;
        for (int i =0; i <uv.Length; i ++)
        {
            Debug.Log(string.Format("第{0}个=={1}",i,uv[i]));
        }

    }
	
	
	void Update ()
    {
	    
	}
}
