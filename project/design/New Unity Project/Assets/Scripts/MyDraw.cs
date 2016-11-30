using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MyDraw : MonoBehaviour {

    Texture2D tex2d;
    public RawImage ri;

    Texture2D tex2dMy;
    public RawImage raw;
    int TexPixelHeight = 256; 


    int TexPixelLength = 256;
    Color[,] arrayColor;
    // Use this for initialization
    void Start()
    {
        arrayColor = new Color[TexPixelLength, TexPixelLength];
        tex2d = new Texture2D(TexPixelLength, TexPixelLength, TextureFormat.RGB24, true);
        ri.texture = tex2d;

        tex2d = new Texture2D(TexPixelLength, TexPixelLength, TextureFormat.RGB24, true);
        ri.texture = tex2d;

        SetColorPanel(new Color(0.509f, 0.158f, 0.000f, 1.000f));


        
    }

    // Update is called once per frame
    void Update () {
	
	}

    Color[] CalcArrayColor(Color endColor)
    {
        Color value = (endColor - Color.white) / (TexPixelLength - 1);
        for (int i = 0; i < TexPixelLength; i++)
        {
            arrayColor[i, TexPixelLength - 1] = Color.white + value * i;
        }
        for (int i = 0; i < TexPixelLength; i++)
        {
            value = (arrayColor[i, TexPixelLength - 1] - Color.black) / (TexPixelLength - 1);
            for (int j = 0; j < TexPixelLength; j++)
            {
                arrayColor[i, j] = Color.black + value * j;
            }
        }
        List<Color> listColor = new List<Color>();
        for (int i = 0; i < TexPixelLength; i++)
        {
            for (int j = 0; j < TexPixelLength; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }

        return listColor.ToArray();
    }

    /// <summary>
    /// 设置入口颜色切换
    /// </summary>
    /// <param name="endColor"></param>
    public void SetColorPanel(Color endColor)
    {
        Color[] CalcArray = CalcArrayColor(endColor);
        tex2d.SetPixels(CalcArray);
        tex2d.Apply();
    }

    //Color[] CalcArrayColor()
    //{
    //    int addValue = (TexPixelHeight - 1) / 3;
    //    for (int i = 0; i < TexPixelWdith; i++)
    //    {
    //        arrayColor[i, 0] = Color.red;
    //        arrayColor[i, addValue] = Color.green;
    //        arrayColor[i, addValue + addValue] = Color.blue;
    //        arrayColor[i, TexPixelHeight - 1] = Color.red;
    //    }
    //    Color value = (Color.green - Color.red) / addValue;
    //    for (int i = 0; i < TexPixelWdith; i++)
    //    {
    //        for (int j = 0; j < addValue; j++)
    //        {
    //            arrayColor[i, j] = Color.red + value * j;
    //        }
    //    }
    //    value = (Color.blue - Color.green) / addValue;
    //    for (int i = 0; i < TexPixelWdith; i++)
    //    {
    //        for (int j = addValue; j < addValue * 2; j++)
    //        {
    //            arrayColor[i, j] = Color.green + value * (j - addValue);
    //        }
    //    }

    //    value = (Color.red - Color.blue) / ((TexPixelHeight - 1) - addValue - addValue);
    //    for (int i = 0; i < TexPixelWdith; i++)
    //    {
    //        for (int j = addValue * 2; j < TexPixelHeight - 1; j++)
    //        {
    //            arrayColor[i, j] = Color.blue + value * (j - addValue * 2);
    //        }
    //    }

    //    List<Color> listColor = new List<Color>();
    //    for (int i = 0; i < TexPixelHeight; i++)
    //    {
    //        for (int j = 0; j < TexPixelWdith; j++)
    //        {
    //            listColor.Add(arrayColor[j, i]);
    //        }
    //    }

    //    return listColor.ToArray();
    //}
}
