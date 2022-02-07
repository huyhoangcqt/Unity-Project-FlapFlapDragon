using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    private Rigidbody2D body;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.zero;
    }

    // Update is called once per frame
    public void OnbecameVisible(){
        body.velocity = Vector2.left * speed;
    }
    public void OnBecameInvisible(){
        Destroy(this.gameObject);
        Destroy(this);
    }
}
