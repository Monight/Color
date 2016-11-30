using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// 颜色管理类  包括说明
/// 
/// 说明：  界面入口函数 show(Color Currentcolor,ColorChangBack callBack,bool isNeedHDR = false)  参数一当前颜色 参数二 颜色改变之后的回调  参数三 是否需要改变HDR
///        强度改变入口函数  ChangeExposeure（Color Currentcolor, float value, ColorChangBack call）  参数一当前颜色   参数二 改变的强度值 参数三 颜色改变之后的回调

/// </summary>


//拖动圆圈的回调
public delegate void DragEvent(Vector2 Pos);

public delegate void DownColorChange(Color color,float identy);

public delegate void LeftColorChange(Color color, bool isNeedChangeLefts);

public delegate void AlfaChange(float val);

public delegate void ColorChangBack(Color color,float identy);  //返回一个颜色 一个强度

public delegate void IdentyCallBack(float indety,Color color);// 改变强度的回调

public delegate void RightColorChangeBack(Color color);


public class ColorControl : BaseWin
{

    public event DragEvent DragCicleCallback;

    [SerializeField]
    public LeftColor left;

    [SerializeField]
    public RightColor right;

    [SerializeField]
    public DownColor downR;
    [SerializeField]
    public DownColor downG;
    [SerializeField]
    public DownColor downB;
    [SerializeField]
    public DownColor downA;

    [SerializeField]
    public InputField colorInput;

    [SerializeField]
    public ExposureColor exposureColor;

    [SerializeField]
    private Button closeBut;

    private string old = "";

    /// <summary>
    /// 16进制的处理函数
    /// </summary>
    private const string PATTERN = "^[0-9A-Fa-f]+$";
    private bool isCanChange = false;


    /// <summary>
    /// 当前的强度
    /// </summary>
    private float identy = 0;

    /// <summary>
    /// 当前颜色更改的一个回调
    /// </summary>
    private ColorChangBack callBack = null;

    private bool isNeedHDR = false;


    /// <summary>
    /// 
    /// </summary>


    public ColorControl()
    {
        winType = WinType.eColorControl;
        WinManager.Instance().AddWin(this);
    }


    void Start()
    {
        //TODO:需要修改入口的函数
        Color col = new Color(0.5f, 1f, 0.5f,1) ;
        //transform.FindChild("Close").GetComponent<Button>().onClick.AddListener();

        colorInput.onValueChanged.AddListener(OnInputColorChange);
        closeBut.onClick.AddListener(delegate() { this.gameObject.SetActive(false); } );
        //OnJoin(col);
        //Debug.Log(Convert.ToInt32(235).ToString("X")) ;
        //Show(col,null,true);

        //
    }

    private float oldAF = -1f;



    /// <summary>
    /// 控制显示 计算强度     
    /// </summary>
    public void Show(Color Currentcolor,ColorChangBack callBack,bool isNeedHDR = false)
    {
        this.isNeedHDR = isNeedHDR;
        this.callBack = callBack;
        open();

        if (isNeedHDR)
        {
            identy = 0;

            //计算强度
            //算一算当前的比例
            float[] colorNumArr = new float[3] { (Currentcolor.r), Currentcolor.g, Currentcolor.b};
            //找出最大的
            for (int i = 0; i < colorNumArr.Length; i++)
            {
                if (colorNumArr[i] > identy)
                {
                    identy = colorNumArr[i];
                }
            }
            if (identy.Equals(0))  //当前的RGB值是0
            {
                identy = 0;
                Currentcolor = new Color(1, 1, 1);
            }
            else
            {
                Currentcolor = Currentcolor / identy;
            }
        }
        else
        {
            identy = 1;
        }
        Init(Currentcolor);
    }

    /// <summary>
    /// 初始化绘制函数
    /// </summary>
    private void Init(Color Currentcolor)
    {
        right.SetColor(Currentcolor,ChangeRight);
        //左边的设置完成了
        left.SetColor(Currentcolor,identy, OnLeftControl);
        downR.SetColor(Currentcolor, identy, ChangDownCallBack,null,isNeedHDR);
        downG.SetColor(Currentcolor, identy, ChangDownCallBack,null,isNeedHDR);
        downB.SetColor(Currentcolor, identy, ChangDownCallBack,null,isNeedHDR);
        //设置强度
        if (isNeedHDR)
        {
            exposureColor.Show();
            colorInput.transform.parent.gameObject.SetActive(false);
            exposureColor.SetColor(Currentcolor, identy, OnChangeIdentyCallBack);
        }

        else
        {
            colorInput.transform.parent.gameObject.SetActive(true);
            exposureColor.Hide();
        }
          
        OnSetInputColorChange(Currentcolor);
    }


    /// <summary>
    /// 左边的比较特殊 需要单独去控制
    /// </summary>
    public void OnLeftControl(Color color,bool isNeedChangeColor)
    {
        if (!isNeedChangeColor)
        {
            callBack.Invoke(color,identy);
            OnSetInputColorChange(color);
            //right.SetColor(color, OnJoin);
            downR.SetColor(color, identy, ChangDownCallBack,null,isNeedHDR);
            downG.SetColor(color, identy, ChangDownCallBack,null,isNeedHDR);
            downB.SetColor(color, identy, ChangDownCallBack,null,isNeedHDR);

        }
    }

    /// <summary>
    /// 改变强度的回调
    /// </summary>
    /// <param name="indenty"></param>
    private void OnChangeIdentyCallBack(float indenty,Color color)
    {

        this.identy = indenty;
        callBack.Invoke(color, identy);
        OnSetInputColorChange(color);
        left.SetColor(color, identy, OnLeftControl);
        downR.SetColor(color, identy, ChangDownCallBack, null, isNeedHDR);
        downG.SetColor(color, identy, ChangDownCallBack, null, isNeedHDR);
        downB.SetColor(color, identy, ChangDownCallBack, null, isNeedHDR);
    }


    /// <summary>
    /// 改变下面的值的回调
    /// </summary>
    private void ChangDownCallBack(Color color,float identy)
    {
        this.identy = identy;

        #region 重置强度 
        #endregion
        callBack.Invoke(color, identy);
        OnSetInputColorChange(color);

        right.SetColor(color, ChangeRight);
        left.SetColor(color, this.identy, OnLeftControl);
        downR.SetColor(color, this.identy, ChangDownCallBack,null,isNeedHDR);
        downG.SetColor(color, this.identy, ChangDownCallBack,null,isNeedHDR);
        downB.SetColor(color, this.identy, ChangDownCallBack,null,isNeedHDR);
        if(isNeedHDR)
            exposureColor.SetColor(color,this.identy, OnChangeIdentyCallBack);

    }

    /// <summary>
    /// 改变右边的回调
    /// </summary>
    /// <param name="color"></param>
    private void ChangeRight(Color color)
    {
        callBack.Invoke(color, identy);
        OnSetInputColorChange(color);

        left.SetColor(color, identy,OnLeftControl);
        downR.SetColor(color,identy, ChangDownCallBack,null,isNeedHDR);
        downG.SetColor(color, identy,ChangDownCallBack,null,isNeedHDR);
        downB.SetColor(color,identy, ChangDownCallBack,null,isNeedHDR);
    }

    /// <summary>
    /// 强度更改入口
    /// </summary>
    /// <param name="Currentcolor"></param>
    /// <param name="value"></param>
    /// <param name="call"></param>
    public void ChangeExposeure(Color Currentcolor, float value, ColorChangBack call)
    {
        float num = 0;
        //identy = 0;
        this.callBack = call;
        //计算强度
        //算一算当前的比例
        float[] colorNumArr = new float[3] { (Currentcolor.r), Currentcolor.g, Currentcolor.b };
        //找出最大的
        for (int i = 0; i < colorNumArr.Length; i++)
        {
            if (colorNumArr[i] > num)
            {
                num = colorNumArr[i];
            }
        }
        if (num.Equals(0))  //当前的RGB值是0
        {
            num = 0;
            Currentcolor = new Color(1, 1, 1);
        }
        else
        {
            Currentcolor = Currentcolor / num;
        }
        callBack.Invoke(Currentcolor, value);
    }

    /// <summary>
    /// 改变透明度
    /// </summary>
    private void OnChangeAlfaValue(float val)
    {
        Debug.Log("todoSomeThing");
        oldAF = val;
    }

    /// <summary>
    /// 输入16进制的数字
    /// </summary>
    /// <param name="val"></param>
    public void OnInputColorChange(string val)
    {
        if (val == old.ToUpper()) //说明是没有更新
        {
            return;
        }

        if (val == old.ToUpper()) //说明是没有更新
        {
            return;
        }
        //if (isCanChange)
        //{
        //    跟新颜色
        //    isCanChange = false;

        //}
        //else
        //{
        //    return;
        //}
        //TODO:更新颜色
        //如果old的值是一样的就返回
        if (IsIllegalHexadecimal(val)) //是16进制
        {
            //old = val;
            old = val.ToUpper();
            colorInput.text = val.ToUpper();
        }
        else
        {
            colorInput.text = old.ToUpper();
            return;
        }


        old = val;
        float r = 0;
        float g = 0;
        float b = 0;
        float a = 0;
        switch (val.Length)
        {
            case 1:
                return;
            case 2:
                return;
            case 3: //每一个取出一位 当做颜色
                r = Convert.ToInt32(val.Substring(0, 1), 16) / (float)255;
                g = Convert.ToInt32(val.Substring(1, 1), 16) / (float)255;
                b = Convert.ToInt32(val.Substring(2, 1), 16) / (float)255;
                Init(new Color(r, g, b));
                break;
            case 4:
                r = Convert.ToInt32(val.Substring(0, 1), 16) / (float)255;
                g = Convert.ToInt32(val.Substring(1, 1), 16) / (float)255;
                b = Convert.ToInt32(val.Substring(2, 1), 16) / (float)255;
                a = Convert.ToInt32(val.Substring(3, 1), 16) / (float)255;
                oldAF = a;
                Init(new Color(r, g, b));
                break;
            case 5:
            case 6:
            case 7:
                r = Convert.ToInt32(val.Substring(0, 1), 16) / (float)255;
                g = Convert.ToInt32(val.Substring(1, 1), 16) / (float)255;
                b = Convert.ToInt32(val.Substring(2, 1), 16) / (float)255;
                a = Convert.ToInt32(val.Substring(3, 1), 16) / (float)255;
                oldAF = a;
                Init(new Color(r, g, b));
                break;
            case 8:

                r = Convert.ToInt32(val.Substring(0, 2), 16) / (float)255;
                g = Convert.ToInt32(val.Substring(2, 2), 16) / (float)255;
                b = Convert.ToInt32(val.Substring(4, 2), 16) / (float)255;
                a = Convert.ToInt32(val.Substring(6, 2), 16) / (float)255;
                oldAF = a;
                Init(new Color(r, g, b));
                break;

        }
    }


    /// <summary>
    /// 判断当前是不是16进制的数字
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public bool IsIllegalHexadecimal(string hex)
    {

        Debug.Log(hex);
        return System.Text.RegularExpressions.Regex.IsMatch(hex, PATTERN);
    }


    /// <summary>
    /// 改变里面的值 10进制转换成16进制 大写写进去
    /// </summary>
    private void OnSetInputColorChange(Color col)
    {
        //判断没一个值是不是已经越界了 越界了 就是FF

        string rStr = OnDelColorHexNum(col.r);
        string gStr = OnDelColorHexNum(col.g);
        string bStr = OnDelColorHexNum(col.b);
        string aStr = OnDelColorHexNum(col.a);

        //Debug.Log(Convert.ToInt32(((int)(col.r * 255)).ToString("X")));
        old = string.Format("{0}{1}{2}{3}", rStr, gStr, bStr, aStr).ToUpper();
        colorInput.text = old;
    }

    /// <summary>
    /// 算出当前应该显示的16进制的数字
    /// </summary>
    private string OnDelColorHexNum(float f)
    {
        if ((int)(f * 255) > 255) //超过上线
        {
            return "FF";
        }
        string ss = ((int)(f * 255)).ToString("X");

        if (ss.Length == 1)
            ss = "0" + ss;

        return ss;

    }












}
