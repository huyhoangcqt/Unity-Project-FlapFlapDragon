using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixUIPosition : MonoBehaviour
{
    private Vector2 DEFAULT_SCREEN = new Vector2(1280, 720);
    private Vector2 preScreenSize = new Vector2(1280, 720);

    private RectTransform rt;
    public float left, top, right, bottom;
    
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        Vector2 anchoredPos = rt.anchoredPosition;
        // LogVector2("AnchoredPos", anchoredPos);
    }

    void LogVector2(string tag, Vector2 vector){
        Debug.Log(tag + ": " + vector.x + ", " + vector.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != preScreenSize.x ){
            FixAlignment();
            preScreenSize = new Vector2(Screen.width, Screen.height);
        }
    }

    private void FixAlignment(){
        float rateX = Screen.width/ DEFAULT_SCREEN.x;
        float rateY = Screen.height/ DEFAULT_SCREEN.y;
        float x = (left != 0) ? left : -right;
        float y = (top != 0) ? -top : bottom;
        x *= rateX;
        y *= rateY;
        rt.anchoredPosition = new Vector2(x, y);
    }
}
