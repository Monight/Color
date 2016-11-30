using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeftColor : MonoBehaviour {

    /// <summary>
    /// 成员变量
    /// </summary>

    [SerializeField]
    RawImage Img;

    [SerializeField]
    public CicleDrag cicle;

    Texture2D texture;

    [SerializeField]
    int with = 256;
    [SerializeField]
    int height = 256;

    Color[,] arrayColor;      //颜色数组


    private LeftColorChange callBack;

    private float identy = 0f;

    /// <summary>
    /// 当前颜色和位置的一个存储
    /// </summary>
    private Dictionary<Color,Vector2> colorPositons  = new Dictionary<Color ,Vector2>();


    void Awake ()
    {
        texture = new Texture2D(with, height, TextureFormat.ARGB32,true);
        Img.texture = texture;
        arrayColor = new Color[with,height];
        cicle.Init(CicleDragCallBack);
    }
	
	// Update is called once per frame
	void Update ()
    {



    }




    /// <summary>
    /// 进入设置颜色
    /// </summary>
    public void SetColor(Color endColor,float identy, LeftColorChange callback = null)
    {
        this.identy = identy;
        this.callBack = callback;
        Color[] CalcArray = MyCalArryColor(endColor);
        texture.SetPixels(CalcArray);
        texture.Apply();
        ////取得drg的颜色
        //Color co = arrayColor[(int)cicle.GetColor().x, (int)cicle.GetColor().y];
        //callback.Invoke(co,false);

        //设置drag的位置

        //cicle.SetCiclPositon();

    }



    /// <summary>
    /// 我计算的颜色
    /// </summary>
    /// <returns></returns>
    Color[] MyCalArryColor(Color endColor)
    {

        //Debug.Log(arrayColor.Length);
        //计算当前的HSV
        float h, s, v;
        Color.RGBToHSV(endColor, out h, out s, out v);
        bool isNeedChange = false;
        //取出h值
        List<Color> listColor = new List<Color>();
        for (int j =0; j < with;j ++)
        {
            for (int i =0; i < height; i ++)
            {
                Color co = Color.HSVToRGB(h, i / (float)255, j / (float)255);
                //TODO当强度是0的时候
                if (identy == 0)
                    arrayColor[i, j] = co;
                else
                    arrayColor[i, j] = co * identy;
                listColor.Add(arrayColor[i, j]);

                if (Mathf.Abs(endColor.r - co.r) < 0.01
                    && Mathf.Abs(endColor.g - co.g) < 0.01
                    && Mathf.Abs(endColor.b - co.b) < 0.01
                    && !isNeedChange
                    )
                {
                    isNeedChange = true;
                    cicle.SetCiclPositon(new Vector2(i,j));
                }

                
            }
        }
        return listColor.ToArray();
    }


    /// <summary>
    /// 计算颜色
    /// </summary>

    Color[] CalcArrayColor(Color endColor)
    {
        Color value = (endColor - Color.white) / (with - 1);
        for (int i = 0; i < with; i++)
        {
            arrayColor[i, with - 1] = Color.white + value * i;
        }
        for (int i = 0; i < with; i++)
        {
            value = (arrayColor[i, with - 1] - Color.black) / (with - 1);
            for (int j = 0; j < height; j++)
            {
                arrayColor[i, j] = Color.black + value * j;
            }
        }
        List<Color> listColor = new List<Color>();
        for (int i = 0; i < with; i++)
        {
            for (int j = 0; j < height; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }

        return listColor.ToArray();
    }


    /// <summary>
    /// 拖动左边的圆圈回调
    /// </summary>
    public void CicleDragCallBack(Vector2 pos)
    {
        Color co = arrayColor[(int)pos.x,(int)pos.y]/(float) identy;
        if (callBack != null)
            callBack.Invoke(co,false);
    }

}
