using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] public GameObject explosionEff;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void ChangeState(){
        anim.SetBool("isFly", true);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle"){
            Instantiate(explosionEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
