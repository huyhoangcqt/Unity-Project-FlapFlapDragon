using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private GameObject player; //target;
    public float speed = 10f;
    public float distanceToPlayer1, distanceToPlayer2;

    private bool isNear, onClosed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        isNear = false;
        onClosed = false;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < distanceToPlayer1){
            if (!isNear){
                anim.SetBool("isNear", true);
                isNear = true;
            }
        } else {
            if (isNear){
                anim.SetBool("isNear", false);
                isNear = false;
            }
        }
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < distanceToPlayer2){
            if (!onClosed){
                // anim.SetBool("onClosed", true);
                onClosed = true;
            }
            if (onClosed){
                if (transform.position.y > 2){
                    body.velocity = Vector2.down * speed;
                }  
                else {
                    body.velocity = new Vector2(0f, 0f);
                }
            }
        }
        else {
            if (onClosed){
                // anim.SetBool("onClosed", false);
                onClosed = false;
            }
            else {
                if (transform.position.y < 5){
                    body.velocity = Vector2.up * speed;
                }
                else if (transform.position.y >= 5){
                    body.velocity = new Vector2(0f, 0f);
                }
            }
            
        }
    }
}
