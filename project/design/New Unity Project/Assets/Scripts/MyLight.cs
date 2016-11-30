using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Rendering;

public class MyLight : MonoBehaviour {

	// Use this for initialization
	void Start () {


        float h, s, v;
        Color col = new Color(0.27f,0.07f,0.87f);

        Color.RGBToHSV(col,out h,out s,out v);
        Debug.Log(h);




    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
