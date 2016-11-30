using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class My : MonoBehaviour
{

    //public override void Select()
    //{
    //    Debug.Log("????");



    //}

    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);
    //    Debug.Log("222");
    //}

    //public override void OnPointerUp(PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);
    //    Debug.Log("2211122");
    //    Debug.Log(EventSystem.current); 
    //}

    float time = 0;
    float temp =0.2f;
    bool isCanChange = false;
    Button but = null;
    int oldId = 0;


    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

     void  Update()
    {
        
        


        if ( Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject!= null)
        {
            if (oldId == EventSystem.current.currentSelectedGameObject.GetInstanceID())
            {
                string.
                //Debug.Log("whi");
                //EventSystem.current.sendNavigationEvents = false;
                return;
            }
            oldId = EventSystem.current.currentSelectedGameObject.GetInstanceID();


        //    but = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //    if (but != null)
        //    {
        //        isCanChange = true;
        //        but.interactable = false;
        //    }
        //}

            //if (isCanChange)
            //{
            //    time += Time.deltaTime;
            //    if (time >= temp)
            //    {
            //        time = 0;
            //        but.interactable = true;
            //        isCanChange = false;
            //    }
        }
    }

    void OnClick()
    {
        Debug.Log(" ni hao a ");
    }


    //void MyOnClick()
    //{
    //    Debug.Log("heihei");
    //}
   
}
