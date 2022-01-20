using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagePoint : MonoBehaviour
{
    public int rage = 5;
    public float speed = 5f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.up * speed;
    }

    public void EndingLifeCycle(){
        RageController.instance.RageUp(rage);
        Destroy(gameObject);
    }
}
