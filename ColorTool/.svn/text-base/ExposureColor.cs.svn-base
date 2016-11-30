using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


/// <summary>
/// 颜色曝光
/// </summary>


public class ExposureColor : MonoBehaviour {

    [SerializeField]
    InputField inputVale;

    private int maxNum = 99 ;

    private float oldVal = -1;

    private IdentyCallBack callBack = null;


    private bool proColorIsNoremal = true; 

    
    private Color oldColor; //上一次的颜色

    private float currentMaxNum = 99; //当前最大的值

    float max = -1;

    private float oldExploNum = -1000;

    private bool isSelf = true;

    
   

    /// <summary>
    /// 控制显示
    /// </summary>
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏的函数
    /// </summary>
    public void Hide()
    {
        this.gameObject.SetActive(false);
        callBack = null;
    }

	void Start ()
    {
        inputVale.onEndEdit.AddListener(OnChangeValue);

    }

    public void ResetInfo()
    {
    
    }


    /// <summary>
    /// 入口函数
    /// </summary>
    public void SetColor(Color color,float indenty , IdentyCallBack callBack = null)
    {
        oldColor = color;
        currentMaxNum = indenty;
        isSelf = true;
        oldVal = indenty;
        this.callBack = callBack;
        inputVale.text = indenty.ToString();
       
    }


    /// <summary>
    /// 输入值的响应
    /// </summary>
    /// <param name="val"></param>
    public  void OnChangeValue(string val)
    {
        if (float.Parse(val) > 99)
        {
          
            inputVale.text = "99";
            return;
        } 


        if (oldVal.ToString() == val)
            return;
        if (val == null || val.Length < 1)
            return;
        //if (val.Equals("0"))
        //{
        //    inputVale.text = "";
        //    return;
        //}
        float v = float.Parse(val);
        Color newColor = new Color(0,0,0,1);
        if (v == 0)
        {
            oldVal = 0;
            newColor = new Color(1, 1, 1, 1);
            callBack.Invoke(0, newColor);
            return;
        }

        if ( v > currentMaxNum) //如果大于当前的值
        {
            oldVal = v;
            newColor =(oldColor * currentMaxNum) *(1/v);
            currentMaxNum = v;
            callBack.Invoke(currentMaxNum, newColor);
            return;
        }
        else
        {
            oldVal = v;
            currentMaxNum = v;
            callBack.Invoke(currentMaxNum, oldColor);
            return;
        }

    }






}
