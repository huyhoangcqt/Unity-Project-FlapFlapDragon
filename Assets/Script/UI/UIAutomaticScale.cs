using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAutomaticScale : MonoBehaviour
{
    private Vector2 DEFAULT_SCREEN = new Vector2(1280, 720);
    private Vector2 preScreenSize = new Vector2(1280, 720);
    private RectTransform rt;
    private Vector3 newLocalScale, defaultScale;
    //Default for 1080/720;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        defaultScale = rt.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != preScreenSize.x){
            float rateX = Screen.width / DEFAULT_SCREEN.x;
            Vector3 newLocalScale = defaultScale * rateX;
            rt.localScale = newLocalScale;
            preScreenSize = new Vector2(Screen.width, Screen.height);
        };
    }
}
