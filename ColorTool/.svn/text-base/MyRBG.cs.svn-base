using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class MyRBG : MonoBehaviour {


    public RawImage rImage;
    public RawImage gImage;
    public RawImage bImage;

    Color32 color =/* new Color32(45,100,50,0);*/Color.red;


    Color[] rColorArr;
    Color[] gColorArr;
    Color[] bColorArr;


    Texture2D rTexture;
    Texture2D gTexture;
    Texture2D bTexTure;


    void Start()
    {
        Color newColor = new Color( color.r/(float)255,color.g/(float)255,color.b/(float)255);

        float newR = color.r / (float)255;
        float newG = color.g / (float)255;
        float newB = color.g / (float)255;

        rColorArr = new Color[256 * 16];
        gColorArr = new Color[256 * 16];
        bColorArr = new Color[256 * 16];
        //初始化R数组
        for (int i = 0; i < 256 ; i++)
        {
            for (int j =0; j <16; j ++)
            {
                rColorArr[i + j*256] = new Color(i / (float)255, newG, newB);
                gColorArr[i + j * 256] = new Color(newR, i / (float)255, newB);
                bColorArr[i + j * 256] = new Color(newR, newG, i / (float)255);

            }
        }


        //绘制R 面板
        rTexture = new Texture2D(256,16, TextureFormat.RGB24,true);
        gTexture = new Texture2D(256, 16, TextureFormat.RGB24, true);
        bTexTure = new Texture2D(256, 16, TextureFormat.RGB24, true);

        DrawRaw();
    }

    //绘制界面
    void DrawRaw()
    {


        rTexture.SetPixels(rColorArr);
        rTexture.Apply();
        rImage.texture = rTexture;

        gTexture.SetPixels(gColorArr);
        gTexture.Apply();
        gImage.texture = gTexture;

        bTexTure.SetPixels(bColorArr);
        bTexTure.Apply();
        bImage.texture = bTexTure;
    }


}
