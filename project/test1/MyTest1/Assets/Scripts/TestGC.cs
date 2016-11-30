using UnityEngine;
using System.Collections;

public class TestGC : MonoBehaviour {

    // Use this for initialization
    //private My my = null;
    //private string[] str;



    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;

    void Start () {


        Debug.Log("go1 = " + go1.GetInstanceID() + "  go2 = " + go2.GetInstanceID()  + "  go3 = " + go3.GetInstanceID()
                 + "  go4 = " + go4.GetInstanceID()
                );
        //Debug.Log(Profiler.GetMonoHeapSize());
        //Debug.Log(Profiler.GetMonoUsedSize() / 1024f / 1024f  + "B") ;
        //my = new My();
        //str = new string[3];
        //foreach (string s in str)
        //{
        //    Debug.Log(s);
        //}
        //Debug.Log(Profiler.GetMonoHeapSize());
        //Debug.Log(Profiler.GetMonoUsedSize() / 1024f / 1024f + "B");
	}
	
	// Update is called once per frame
	void Update ()
    {

	
	}
}

public class My
{

}
