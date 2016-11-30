using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CicleDrag : MonoBehaviour, IDragHandler
{

    /// <summary>
    /// 位置信息
    /// </summary>
    private RectTransform rectTf;
    private int with = 255;
    private int height = 255;

    private DragEvent callBack;

    // Use this for initialization
    void Awake()
    {
        rectTf = this.GetComponent<RectTransform>();
    }

    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    /// <summary>
    /// 设置回调
    /// </summary>
    public void Init(DragEvent callBack )
    {
        this.callBack = callBack;
    }

    /// <summary>
    /// 拖动的处理函数
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 wordPos;
        //Debug.Log(eventData.position);
        //将UGUI的坐标转为世界坐标  
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTf, eventData.position, eventData.pressEventCamera, out wordPos))
            rectTf.position = wordPos;

        Vector3 newPositon;
        //Debug.Log(rectTf.anchoredPosition);
        if (rectTf.anchoredPosition.x <= 0)
        {
            rectTf.anchoredPosition = new Vector2(0, rectTf.anchoredPosition.y);
        }
        else if (rectTf.anchoredPosition.x >= with)
        {
            rectTf.anchoredPosition = new Vector2(with, rectTf.anchoredPosition.y);
        }
        if (rectTf.anchoredPosition.y >= height)
        {
            rectTf.anchoredPosition = new Vector2(rectTf.anchoredPosition.x,height);
        }
        else if(rectTf.anchoredPosition.y < 0)
        {
            rectTf.anchoredPosition = new Vector2(rectTf.anchoredPosition.x, 0);
        }

        //回调 改变下面的颜色
        if (callBack != null)
            callBack.Invoke(rectTf.anchoredPosition);

    }

    public Vector2 GetColor()
    {
        return rectTf.anchoredPosition;
    }

    public void SetCiclPositon(Vector2 v)
    {
        rectTf.anchoredPosition = v;
    }

}
