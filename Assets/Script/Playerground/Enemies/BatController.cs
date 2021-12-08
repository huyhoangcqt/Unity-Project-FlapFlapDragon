using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    private Rigidbody2D body;
    public float speed = 10f;

    public BatVisible batVisible;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (batVisible.GetIsVisible()){
            body.velocity = Vector2.left * speed;
        }
        else {
            body.velocity = new Vector2(0, 0);
        }
    }
}
