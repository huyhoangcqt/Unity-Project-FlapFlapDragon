using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoScale : MonoBehaviour
{
    private Vector2 DEFAULT_SCREEN = new Vector2(1280, 720);
    private Vector2 preScreenSize = new Vector2(1280, 720);
    private Transform tf;
    private Vector3 newLocalScale, defaultScale;
    //Default for 1080/720;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        defaultScale = tf.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != preScreenSize.x){
            float rateX = Screen.width / DEFAULT_SCREEN.x / 2;
            Vector3 newLocalScale = defaultScale * rateX;
            tf.localScale = newLocalScale;
            if (transform.childCount > 0){
                for (int i = 0; i < transform.childCount; i++){
                    transform.GetChild(i).localScale = newLocalScale;
                }
            }

            preScreenSize = new Vector2(Screen.width, Screen.height);
        };
    }
}
