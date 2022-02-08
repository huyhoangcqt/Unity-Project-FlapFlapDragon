using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : Singleton<FireLight>
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }   

    public void Lighten(){
        anim.SetBool("isLighten", true);
    }

    public void Darken(){
        anim.SetBool("isDarken", true);
        StartCoroutine(TurnOfFireLightIE(1f));
    }

    IEnumerator TurnOfFireLightIE(float time){
        yield return new WaitForSeconds(time);
        anim.SetBool("isLighten", false);
        anim.SetBool("isDarken", false);
    }
}
