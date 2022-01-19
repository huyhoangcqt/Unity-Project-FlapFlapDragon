using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    private Animator anim;

    private GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            Vector3 playerPos = player.transform.position;
            if (Mathf.Abs(playerPos.x - transform.position.x) > 1.5
            || Mathf.Abs(playerPos.x - transform.position.x) > 1.64){
                anim.SetBool("isGlow", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            anim.SetBool("isGlow", true);
            player = other.gameObject;
        }
    }
}
