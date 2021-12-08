using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePosition : MonoBehaviour
{
    public Vector3 distance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("BabyDragon");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distance;
    }
}
