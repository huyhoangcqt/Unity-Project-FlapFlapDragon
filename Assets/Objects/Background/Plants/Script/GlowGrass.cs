using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowGrass : MonoBehaviour
{
    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
        anim.SetBool("isWaiting", true);
    }
    
    void Start()
    {
        Pre();
    }

    public void Darken(){
        anim.SetBool("isDarken", true);
    }

    public void Recover(){
        anim.SetBool("isDarken", false);
        Pre();
    }

    [SerializeField] private float time;
    public void Pre(){
        StartCoroutine(WaitingIE(time));
    }

    IEnumerator WaitingIE(float time){
        yield return new WaitForSeconds(Random.Range(0, time));
        anim.SetBool("isWaiting", false);
    }
}
