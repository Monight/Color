using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RightColor : MonoBehaviour {



    [SerializeField]
    public RawImage ri;
    [SerializeField]
    public Slider slider;


    private int width = 16;
    private int height = 256;
    private Texture2D tex2d;

    private RightColorChangeBack callBack = null;


    Color[,] arrayColor;
    private List<Color32> colorLists = new List<Color32>();

    private Dictionary<Color, int> colorSliders = new Dictionary<Color, int>();

    private float oldVal = 0f;
    /// <summary>
    /// 初始化的函数
    /// </summary>
    void Awake()
    {

        //Color col1 = new Color(0.2f, 0.33f, 0.111f);
        //Color col2 = new Color(0.2f,0.33f,0.111f);
        //Debug.Log( (col1 == col2)  + "判断当前的颜色是否相等");


        arrayColor = new Color[width, height];
        tex2d = new Texture2D(width, height, TextureFormat.RGB24, true);
        Color col = new Color(2 / (float)255, 211 / (float)255f, 100 / (float)255f, 1);
        //Debug.Log(tex2d.GetPixel(8, 21) + "---------------");
        Color[] calcArray = CalArryColor(col);
        tex2d.SetPixels(calcArray);
        tex2d.Apply();
        ri.texture = tex2d;


    }

    void Start()
    {
        slider.onValueChanged.AddListener(OnValueChange);
    }



	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Color c in colorSliders.Keys)
            {
                //Debug.Log(c + " -------" + colorSliders[c]);
            }
        }
	}


    private void OnValueChange(float value)
    {
        if (oldVal == value)
            return;
        Color getColor = tex2d.GetPixel(0, (int)((height - 1) * (1 - value)));
        if (callBack != null)
            callBack.Invoke(getColor);


    }


    /// <summary>
    /// 设置颜色
    /// </summary>

    public void SetColor(Color color, RightColorChangeBack callBack)
    {

        this.callBack = callBack;
        // Color32 co = new  Color32((byte) color.r*  )
        //Color
        //Debug.Log(color + "-------------传进来的颜色");
        //Debug.Log(colorSliders.ContainsKey(color));
        float h, s, v;

        Color.RGBToHSV(color,out h,out s,out v);

        oldVal = 1 - h;
        slider.value = 1-h;


    }

    /// <summary>
    /// 我的计算颜色
    /// </summary>
    public Color[]  CalArryColor(Color color)
    {

        //取出 
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);


        List<Color> listColor = new List<Color>();
        for (int j =0; j < height; j ++)
        {
            for (int i= 0; i < width; i ++)
            {
                Color color1 =  Color.HSVToRGB(j/(float) 255,s,v);
                arrayColor[i, j] = color1;
                listColor.Add(color1);
            }
        }

        return listColor.ToArray();
    }




}
