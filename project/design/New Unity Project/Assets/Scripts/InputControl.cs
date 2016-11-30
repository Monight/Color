using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<InputField>().onEndEdit.AddListener(OnValChenge);
        //this.GetComponent<InputField>().text = "100";
        this.GetComponent<InputField>().text = "100";

        float a = 0.000000000000f;
        float b = 0;
        Debug.Log(a.Equals(b));


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnValChenge(string val)
    {
        Debug.Log(val);
    }
}
