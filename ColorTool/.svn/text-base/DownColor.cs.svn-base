using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// 当前界面的类型
/// </summary>

public enum DrownDrawType
{
    DOWNR,
    DOWNG,
    DOWNB,
    DOWNA
}



public class DownColor : MonoBehaviour {


    [SerializeField]
    public RawImage rImage; //绘制的界面
    [SerializeField]
    public DrownDrawType type;//当前的type

    [SerializeField]
    public Slider slider;  //滑动界面

    [SerializeField]
    public InputField inputFiel;//输入颜色界面





    //public RawImage gImage;
    //public RawImage bImage;

    //Color32 color = new Color32(45, 100, 50, 0);


    Color[] rColorArr; //颜色数组
    //Color[] gColorArr;
    //Color[] bColorArr;


    Texture2D rTexture; //绘制的图片
    //Texture2D gTexture;
    //Texture2D bTexTure;
    int width = 256;
    int height = 16;

    private Color oldColor; // 最原始的颜色
    private int oldValue = -1;// 输入框的上一次的值 避免重复响应 
    private float sliderOldValue = -1;//滑动条的上一次的值 避免重复响应

    private DownColorChange callBack = null;
    private AlfaChange alfaCallBack = null;

    private bool isSelf = false;
    private bool isSelf2 = false;

    private float max = 1; //当前可输入的最大值

    private bool isNeedHDR = false;


    /// <summary>
    /// 初始的值
    /// </summary>
    private string oldRGBstr = "";


    private string oldSliderStr = "";

    /// <summary>
    /// 当前的饿强度
    /// </summary>
    private float identy = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// 初始赋值的操作
    /// </summary>
    void Awake()
    {
        if (inputFiel == null)
            Debug.LogError("输入框没有赋值");
        inputFiel.onEndEdit.AddListener(OnInputValChange);

        if (slider == null)
            Debug.LogError("滑动框没有赋值");
        slider.onValueChanged.AddListener(OnSlidervalChange);
    }

    /// <summary>
    /// 绘制的入口
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color,float identy,DownColorChange colorChangeCallBack = null,AlfaChange alfaChangeCallBack =null,bool isNeedHDR = false)
    {

        this.identy = identy;
        oldColor = color;
        this.callBack = colorChangeCallBack;
        this.alfaCallBack = alfaChangeCallBack;
        this.isNeedHDR = isNeedHDR;
        if (isNeedHDR)
            max = 99;
        else
            max = 1;



        float newR = color.r;
        float newG = color.g;
        float newB = color.b;



        rColorArr = null;
        rColorArr = new Color[width * height];
        switch (type)
        {
            case DrownDrawType.DOWNR:
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {

                        rColorArr[i + j * width] = new Color(i / (float)255, newG, newB);
                        //gColorArr[i + j * 256] = new Color(newR, i / (float)255, newB);
                        //bColorArr[i + j * 256] = new Color(newR, newG, i / (float)255);

                    }
                }
                if (identy == 0)
                      SetInputFieldValue(color.r);
                else
                    SetInputFieldValue(color.r*identy );

                OnSetSliderVal(color.r);
               
                break;
            case DrownDrawType.DOWNG:
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {

                        //rColorArr[i + j * width] = new Color(i / (float)255, newG, newB);
                        rColorArr[i + j * 256] = new Color(newR, i / (float)255, newB);
                        //bColorArr[i + j * 256] = new Color(newR, newG, i / (float)255);

                    }
                }
              
                if(identy == 0)
                    SetInputFieldValue(color.g);
                else
                    SetInputFieldValue(color.g * identy);
                OnSetSliderVal(color.g);
                break;
            case DrownDrawType.DOWNB:
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {

                        //rColorArr[i + j * width] = new Color(i / (float)255, newG, newB);
                        //rColorArr[i + j * 256] = new Color(newR, i / (float)255, newB);
                        rColorArr[i + j * 256] = new Color(newR, newG, i / (float)255);
                    }
                }
                if (identy == 0)
                    SetInputFieldValue(color.b);
                else
                    SetInputFieldValue(color.b * identy);
               
                OnSetSliderVal(color.b);
                break;
            case DrownDrawType.DOWNA:  //如果是透明度的话
              
                //SetInputFieldValue(color.a);
                //OnSetSliderVal(color.a);
                break;
        }






        //绘制R 面板
        rTexture = new Texture2D(width, height, TextureFormat.RGB24, true);
        //gTexture = new Texture2D(256, 16, TextureFormat.RGB24, true);
        //bTexTure = new Texture2D(256, 16, TextureFormat.RGB24, true);

        DrawRaw();
        
    }

    /// <summary>
    /// 开始绘制赋值
    /// </summary>
    void DrawRaw()
    {


        rTexture.SetPixels(rColorArr);
        rTexture.Apply();
        //Debug.Log(rImage);
        //Debug.Log(rTexture);
        rImage.texture = rTexture;

        //gTexture.SetPixels(gColorArr);
        //gTexture.Apply();
        //gImage.texture = gTexture;s

        //bTexTure.SetPixels(bColorArr);
        //bTexTure.Apply();
        //bImage.texture = bTexTure;
        //rColorArr = null;
    }

    /// <summary>
    /// 设置输入文本的数值
    /// </summary>
    /// <param name="color"></param>
    void SetInputFieldValue(float val)
    {
        oldRGBstr = val.ToString("0.000");
        inputFiel.text = val.ToString("0.000");
        
    }

    /// <summary>
    /// 输入框的改变响应
    /// </summary>
    /// <param name="val"></param>
    void OnInputValChange( string val)
    {
         val = float.Parse(val).ToString("0.000");
        if (float.Parse(val) > max)
        {
            val = max.ToString();
            SetInputFieldValue(float.Parse(val) );
        }
           

        if (oldRGBstr.Equals(val.ToString()))
            return;
        oldRGBstr = val;
       
        //if (oldValue == Convert.ToInt32(val))
        //    return;
        //SetInputFieldValue(Convert.ToInt32(val) );

        if (type == DrownDrawType.DOWNA)
        {
            ////提供改变透明度的接口
            //alfaCallBack.Invoke(Convert.ToInt32(val)/(float) 255);
            //OnSetSliderVal(Convert.ToInt32(val) / (float)255);
            //return;
        }

        Color newColor = Color.white;

        ///判断当前是否需要HDR

        if (isNeedHDR)
        {
            //判断以下当前的是变小还是变大
            if (float.Parse(val) > identy) //如果输入大于当前的最大值 计算所有的颜色 和强度
            {
                float oldIdenty = this.identy;
                this.identy = float.Parse(val);

                if (oldIdenty == 0)
                    oldIdenty = 1;


                switch (type)
                {
                    case DrownDrawType.DOWNR:
                        newColor = new Color(1, oldColor.g * oldIdenty / identy, oldColor.b * oldIdenty / identy, oldColor.a);
                        break;
                    case DrownDrawType.DOWNG:
                        newColor = new Color(oldColor.r * oldIdenty / identy, 1, oldColor.b * oldIdenty / identy, oldColor.a);
                        break;
                    case DrownDrawType.DOWNB:
                        newColor = new Color(oldColor.r * oldIdenty / identy, oldColor.b * oldIdenty / identy, 1, oldColor.a);
                        break;
                }
               

            }
            else
            {

                float v = float.Parse(val);

                switch (type)
                {
                    case DrownDrawType.DOWNR:
                        newColor = new Color(v / identy, oldColor.g, oldColor.b, oldColor.a);
                        break;
                    case DrownDrawType.DOWNG:
                        newColor = new Color(oldColor.r, v / identy, oldColor.b, oldColor.a);
                        break;
                    case DrownDrawType.DOWNB:
                        newColor = new Color(oldColor.r, oldColor.g, v / identy, oldColor.a);
                        break;
                }
            }
        }
        else
        {
            float v = float.Parse(val);
            switch (type)
            {
                case DrownDrawType.DOWNR:
                    newColor = new Color(v, oldColor.g, oldColor.b, oldColor.a);
                    break;
                case DrownDrawType.DOWNG:
                    newColor = new Color(oldColor.r, v , oldColor.b, oldColor.a);
                    break;
                case DrownDrawType.DOWNB:
                    newColor = new Color(oldColor.r, oldColor.g, v, oldColor.a);
                    break;
            }
        }
        if (callBack != null)
            callBack.Invoke(newColor,identy);
    }

    /// <summary>
    /// 滑动界面的值改变了
    /// </summary>
    void OnSlidervalChange(float val )
    {

        val = float.Parse(val.ToString("0.000"));
        if(oldSliderStr.Equals(val.ToString()))
            return;
        oldSliderStr = val.ToString();


        if (type == DrownDrawType.DOWNA)
        {
            ////提供改变透明度的接口
            //alfaCallBack.Invoke(Convert.ToInt32(val) / (float)255);
            //SetInputFieldValue((int)(val * 255));
            return;
        }

        Color newColor = Color.white;
        switch (type)
        {
            case DrownDrawType.DOWNR:
                newColor = new Color(val , oldColor.g, oldColor.b, oldColor.a);
                break;
            case DrownDrawType.DOWNG:
                newColor = new Color(oldColor.r, val, oldColor.b, oldColor.a);
                break;
            case DrownDrawType.DOWNB:
                newColor = new Color(oldColor.r, oldColor.g, val, oldColor.a);
                break;
        }
        ////设置回调 TODO:透明度的回调
        if (callBack != null)
            callBack.Invoke(newColor,identy);
    }


    /// <summary>
    /// 设置滑动条的值
    /// </summary>
    /// <param name="val"></param>
    void OnSetSliderVal(float val)
    {
        val = float.Parse(val.ToString("0.000")) ;
        oldSliderStr = val.ToString();
        slider.value = val;
    }


}
