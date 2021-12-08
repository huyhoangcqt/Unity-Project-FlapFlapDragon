using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{

    private Camera _MainCamera;
    private float startPos;
    public float parallaxEffect = 1; //Move speed same camera speed;
    // Start is called before the first frame update
    void Start()
    {
        _MainCamera = Camera.main;
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = _MainCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos - distance, transform.position.y, transform.position.z);
    }
}
