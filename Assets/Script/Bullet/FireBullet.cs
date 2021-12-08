using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    public GameObject explosionEff;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(){
        anim.SetBool("isFly", true);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Player"){
            Instantiate(explosionEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
