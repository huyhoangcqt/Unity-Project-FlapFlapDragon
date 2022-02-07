using System.Collections;
using UnityEngine;

public class SpiderControllerShowCase : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private GameObject player; //target;
    public float speed = 10f, time;
    public Vector2 moveRange;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        anim.SetBool("isNear", true);
        StartCoroutine(StartMovingIE(time));
    }

    IEnumerator StartMovingIE(float time){
        yield return new WaitForSeconds(Random.Range(0, time));
        body.velocity = Vector2.down * speed;
    }

    private void Update() {
        if (transform.position.y <= moveRange.x){
            body.velocity = Vector2.up * speed;
        }
        else if (transform.position.y >= moveRange.y){
            body.velocity = Vector2.down * speed;
        }
    }
}
