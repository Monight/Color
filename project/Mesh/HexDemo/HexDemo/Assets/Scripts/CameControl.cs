using UnityEngine;
using System.Collections;

public class CameControl : MonoBehaviour {


    public Transform go = null;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.LookAt(go);
            //Vector3
            Transform oldParent = this.transform.parent;
            transform.SetParent(go.transform);
            transform.localPosition = new Vector3(0, 0f, 0f);
            //transform.localPosition =   go.transform.localPosition.normalized;
           
           

            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //transform.SetParent(oldParent);
            //Debug.Log(GV.gCameraSet.ActiveCamera);

        }
	}
}
 