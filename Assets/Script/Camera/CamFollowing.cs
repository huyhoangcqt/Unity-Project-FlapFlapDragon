using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowing : MonoBehaviour
{
    public GameObject target; //player
    public float smoothParam; //(0 -> 1);

    private Vector3 defaultOffset;
    private float defaultPositionY;

    // Start is called before the first frame update
    void Start()
    {
        if (smoothParam < 0){
            smoothParam = 0;
        }
        if (smoothParam > 1){
            smoothParam = 1;
        }
        defaultOffset = target.transform.position  - transform.position;
        defaultPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = target.transform.position - defaultOffset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, destination, smoothParam);
        smoothPos.y = defaultPositionY;
        transform.position = smoothPos;
    }
}
